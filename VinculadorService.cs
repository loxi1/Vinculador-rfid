using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Concurrent;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DS9908R_App
{
    public class VinculadorService
    {
        private readonly BDPrenda _bdPrenda = new BDPrenda();
        private readonly BDPrendaScm _bdPrendaScm = new BDPrendaScm();

        private readonly ConcurrentQueue<VinculacionRequest> _queue = new ConcurrentQueue<VinculacionRequest>();
        private readonly Dictionary<string, bool> _cacheRFID = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
        private const int MaxCacheSize = 500;

        private bool _isProcessing;
        private readonly object _queueLock = new object();

        public event Action<string> OnInfo;
        public event Action<string> OnError;
        public event Action<Dictionary<string, object>> OnInsertadoOk;
        public event Action<List<Dictionary<string, object>>, Dictionary<string, List<Dictionary<string, object>>>> OnConsolidadoGenerado;
        public event Action<DataTable, string> OnHistorialPrenda;
        public event Action<DataTable, List<Dictionary<string, object>>, Dictionary<string, List<Dictionary<string, object>>>> OnHMGenerado;

        public void Enqueue(VinculacionRequest request)
        {
            _queue.Enqueue(request);
            _ = StartProcessingQueue();
        }

        private async Task StartProcessingQueue()
        {
            lock (_queueLock)
            {
                if (_isProcessing) return;
                _isProcessing = true;
            }

            try
            {
                while (_queue.TryDequeue(out var request))
                {
                    await Task.Run(() => ProcesarVinculacion(request));
                }
            }
            finally
            {
                lock (_queueLock)
                {
                    _isProcessing = false;
                }

                if (!_queue.IsEmpty)
                {
                    _ = StartProcessingQueue();
                }
            }
        }

        private void ProcesarVinculacion(VinculacionRequest request)
        {
            try
            {
                string codigoBarra = (request.CodigoBarras ?? "").Trim();
                string rfid = NormalizarRfid(request.Rfid);
                bool usarRfid = request.UsarRfid;

                if (string.IsNullOrWhiteSpace(codigoBarra))
                {
                    OnError?.Invoke("El código de barras está vacío.");
                    return;
                }

                // ✅ si no usa RFID, se permite guardar
                if (!usarRfid)
                {
                    rfid = "";
                }

                // ✅ si usa RFID, debe haber solo uno válido
                if (usarRfid && string.IsNullOrWhiteSpace(rfid))
                {
                    OnError?.Invoke("El RFID está vacío.");
                    return;
                }

                // ✅ protección extra por si llega un string raro con varios RFID
                if (!string.IsNullOrWhiteSpace(rfid) &&
                    (rfid.Contains(",") || rfid.Contains(";") || rfid.Contains("|")))
                {
                    OnError?.Invoke("Error: se detectó más de un RFID en la solicitud.");
                    return;
                }

                if (usarRfid && !string.IsNullOrWhiteSpace(rfid) && _cacheRFID.ContainsKey(rfid))
                {
                    OnError?.Invoke("RFID repetido: " + rfid);
                    return;
                }

                Tuple<int, string> result;

                // Siempre pasar por Sybase para que:
                // 1) valide negocio
                // 2) actualice estado
                // 3) inserte en tmp_etiq_timbradas
                string rfidParaGuardar = usarRfid ? rfid : "";

                result = _bdPrenda.SaveRFID(
                    codigoBarra,
                    request.Empresa,
                    request.CodTrabajador,
                    rfidParaGuardar,
                    request.HojaMarcacion
                );

                if (result.Item1 != 0)
                {
                    if (result.Item1 == 3 && !string.IsNullOrWhiteSpace(rfidParaGuardar))
                        GuardarEnCache(rfidParaGuardar);

                    OnError?.Invoke(result.Item2);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(rfidParaGuardar))
                    GuardarEnCache(rfidParaGuardar);

                DataTable dataTimbrado = _bdPrenda.GetTimbradasByWorkerAndEtiqueta(
                    request.CodTrabajador,
                    codigoBarra
                );

                if (dataTimbrado.Rows.Count == 0)
                {
                    OnError?.Invoke("No se registraron datos en tmp_etiq_timbradas para el código: " + codigoBarra);
                    return;
                }

                DataRow row = dataTimbrado.Rows[0];

                var insertData = new Dictionary<string, object>
                {
                    { "id_rfid", usarRfid ? rfid : "" },
                    { "id_barras", row["etiqueta"] },
                    { "op", row["op"] },
                    { "corte", row["corte"] },
                    { "subcorte", row["sub_corte"] },
                    { "cod_talla", row["cod_talla"] },
                    { "id_talla", row["id_talla"] },
                    { "talla", row["talla"] },
                    { "cod_combinacion", row["cod_comb"] },
                    { "color", row["color"] },
                    { "cod_trabajador", row["fotocheck"] },
                    { "hoja_marcacion", request.HojaMarcacion }
                };

                long insertReturn = _bdPrendaScm.Insert(insertData);

                if (insertReturn != 1)
                {
                    string mysqlError = _bdPrendaScm.GetError();
                    OnError?.Invoke(string.IsNullOrWhiteSpace(mysqlError)
                        ? "No se pudo insertar en bd_ci_scm.prenda."
                        : mysqlError);
                    return;
                }

                insertData["fecha"] = DateTime.Now;
                insertData["linea"] = row["linea"];

                if (insertData.ContainsKey("id_barras")) insertData.Remove("id_barras");
                if (insertData.ContainsKey("cod_combinacion")) insertData.Remove("cod_combinacion");
                if (insertData.ContainsKey("cod_trabajador")) insertData.Remove("cod_trabajador");

                OnInsertadoOk?.Invoke(insertData);
                OnInfo?.Invoke("Prenda registrada exitosamente.");
            }
            catch (Exception ex)
            {
                OnError?.Invoke("Error inesperado al registrar: " + ex.Message);
            }
        }

        private string NormalizarRfid(string rfid)
        {
            rfid = (rfid ?? "").Trim().Replace(" ", "");
            if (rfid.Length > 24)
                rfid = rfid.Substring(rfid.Length - 24);
            return rfid;
        }

        private void GuardarEnCache(string rfid)
        {
            if (string.IsNullOrWhiteSpace(rfid)) return;

            if (_cacheRFID.Count >= MaxCacheSize)
            {
                string firstKey = null;
                foreach (var key in _cacheRFID.Keys)
                {
                    firstKey = key;
                    break;
                }

                if (firstKey != null)
                    _cacheRFID.Remove(firstKey);
            }

            _cacheRFID[rfid] = true;
        }

        public Tuple<int, string, DataTable> ListarTimbradas(Dictionary<string, object> whereParameters)
        {
            return _bdPrenda.ListarTimbradas(whereParameters);
        }

        public int UpdateTimbrado(
    Dictionary<string, object> whereParameters,
    Dictionary<string, object> updateParameters)
        {
            return _bdPrenda.UpdateTimbrado(whereParameters, updateParameters);
        }

        public void GenerarConsolidado(string codTrabajador)
        {
            var whereParameters = new Dictionary<string, object> { { "fotocheck", codTrabajador } };
            var resultado = _bdPrenda.VerConsolidado(whereParameters);

            if (resultado.Item1 <= 0)
                return;

            OnConsolidadoGenerado?.Invoke(resultado.Item3, resultado.Item4);
        }

        public void BuscarPrenda(string codigoBarras)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigoBarras) || codigoBarras.Length < 18)
                {
                    OnError?.Invoke("Código de barras inválido.");
                    return;
                }

                string op = codigoBarras.Substring(0, 10);
                string corte = codigoBarras.Substring(10, 4);
                string talla = codigoBarras.Substring(14, 2);
                string idTalla = codigoBarras.Substring(16);

                string subcorte = _bdPrenda.ObtenerSubCorte(op, corte, talla, idTalla);

                System.Threading.Thread.Sleep(300);

                DataTable tabla = _bdPrenda.GetHistorialPrenda(op, corte, subcorte, talla, idTalla);

                string mensaje = "";

                if (tabla.Rows.Count > 0)
                {
                    DataRow ultimaFila = tabla.Rows[tabla.Rows.Count - 1];

                    if (ultimaFila["AREA"] != DBNull.Value)
                    {
                        mensaje = $"La Prenda Timbrada Se Encuentra Actualmente En: {ultimaFila["AREA"]}";
                    }
                }

                OnHistorialPrenda?.Invoke(tabla, mensaje);
            }
            catch (Exception ex)
            {
                OnError?.Invoke("Error al buscar prenda: " + ex.Message);
            }
        }

        public void GenerarHM(string op, string hm)
        {
            Task.Run(() =>
            {
                try
                {
                    var where = new Dictionary<string, object>
            {
                { "norpd", op },
                { "nhjmr", hm }
            };

                    var cabecera = _bdPrenda.BuscarHMCabecera(where);
                    var detalle = _bdPrenda.BuscarHMDetalle(where);

                    if (detalle.Item1 == 0)
                    {
                        OnError?.Invoke("No hay datos de HM.");
                        return;
                    }

                    OnHMGenerado?.Invoke(cabecera, detalle.Item2, detalle.Item3);
                }
                catch (Exception ex)
                {
                    OnError?.Invoke("Error GenerarHM: " + ex.Message);
                }
            });
        }

        public string ValidarHM(string op, string hm)
        {
            const string tipo = "nhjmr";

            if (string.IsNullOrWhiteSpace(hm) || hm.Length < 1 || hm.Length > 3)
                return null;

            var whereParameters = new Dictionary<string, object>
    {
        { "norpd", op },
        { tipo, hm.PadLeft(3, '0') }
    };

            var resultado = _bdPrenda.ValidarOP(whereParameters, tipo);

            return resultado.Item1 == 1 ? resultado.Item3 : null;
        }


        public string ValidarOP(string op)
        {
            const string tipo = "norpd";
            var whereParameters = new Dictionary<string, object> { { tipo, op } };

            var resultado = _bdPrenda.ValidarOP(whereParameters, tipo);

            if (resultado.Item1 == 1)
            {
                return resultado.Item3; // valor válido
            }
            else
            {
                OnError?.Invoke($"ValidarOP: {resultado.Item2}");
                return null;
            }
        }

    }
}