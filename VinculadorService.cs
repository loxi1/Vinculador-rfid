using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Concurrent;

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

        public event Action<string> OnInfo;
        public event Action<string> OnError;
        public event Action<Dictionary<string, object>> OnInsertadoOk;

        public void Enqueue(VinculacionRequest request)
        {
            _queue.Enqueue(request);
            _ = StartProcessingQueue();
        }

        private async Task StartProcessingQueue()
        {
            if (_isProcessing) return;
            _isProcessing = true;

            try
            {
                while (_queue.TryDequeue(out var request))
                {
                    await Task.Run(() => ProcesarVinculacion(request));
                }
            }
            finally
            {
                _isProcessing = false;
            }
        }

        private void ProcesarVinculacion(VinculacionRequest request)
        {
            try
            {
                string codigoBarra = (request.CodigoBarras ?? "").Trim();
                string rfid = NormalizarRfid(request.Rfid);

                if (string.IsNullOrWhiteSpace(codigoBarra))
                {
                    OnError?.Invoke("El código de barras está vacío.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(rfid))
                {
                    OnError?.Invoke("El RFID está vacío.");
                    return;
                }

                if (_cacheRFID.ContainsKey(rfid))
                {
                    OnError?.Invoke("Error: El RFID ya existe. Verifique.");
                    return;
                }

                var result = _bdPrenda.SaveRFID(
                    codigoBarra,
                    request.Empresa,
                    request.CodTrabajador,
                    rfid,
                    request.HojaMarcacion
                );

                if (result.Item1 != 0)
                {
                    if (result.Item1 == 3)
                        GuardarEnCache(rfid);

                    OnError?.Invoke(result.Item2);
                    return;
                }

                GuardarEnCache(rfid);

                DataTable dataTimbrado = _bdPrenda.GetTimbradasByWorkerAndEtiqueta(
                    request.CodTrabajador,
                    codigoBarra
                );

                if (dataTimbrado.Rows.Count == 0)
                {
                    OnError?.Invoke("No se registraron datos en tmp_etiq_timbradas.");
                    return;
                }

                DataRow row = dataTimbrado.Rows[0];

                var insertData = new Dictionary<string, object>
                {
                    { "id_rfid", rfid },
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
                    OnError?.Invoke("No se pudo insertar en bd_ci_scm.prenda.");
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
    }
}
