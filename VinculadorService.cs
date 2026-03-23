Sí, aquí el ajuste clave está en la validación para que soporte ambos casos:
con RFID
sin RFID
Tu VinculadorService.cs actual siempre obliga RFID, por eso hay que corregir ProcesarVinculacion.
Problemas actuales
Ahora mismo tienes estas dos validaciones fijas:
C#
if (string.IsNullOrWhiteSpace(rfid))
{
    OnError?.Invoke("El RFID está vacío.");
    return;
}
y
C#
if (_cacheRFID.ContainsKey(rfid))
{
    OnError?.Invoke("RFID repetido: " + rfid);
    return;
}
Eso rompe el escenario de clientes que solo usarán código de barras.
Versión corregida de VinculadorService.cs
Reemplaza tu clase por esta versión:
C#
using System;
using System.Collections.Generic;
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
        private readonly object _queueLock = new object();

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

                if (usarRfid && string.IsNullOrWhiteSpace(rfid))
                {
                    OnError?.Invoke("El RFID está vacío.");
                    return;
                }

                if (usarRfid && !string.IsNullOrWhiteSpace(rfid) && _cacheRFID.ContainsKey(rfid))
                {
                    OnError?.Invoke("RFID repetido: " + rfid);
                    return;
                }

                Tuple<int, string> result;

                if (usarRfid)
                {
                    result = _bdPrenda.SaveRFID(
                        codigoBarra,
                        request.Empresa,
                        request.CodTrabajador,
                        rfid,
                        request.HojaMarcacion
                    );

                    if (result.Item1 != 0)
                    {
                        if (result.Item1 == 3 && !string.IsNullOrWhiteSpace(rfid))
                            GuardarEnCache(rfid);

                        OnError?.Invoke(result.Item2);
                        return;
                    }

                    if (!string.IsNullOrWhiteSpace(rfid))
                        GuardarEnCache(rfid);
                }
                else
                {
                    result = Tuple.Create(0, "OK");
                }

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
Qué cambia aquí
1. RFID solo se exige si UsarRfid == true
C#
if (usarRfid && string.IsNullOrWhiteSpace(rfid))
2. Duplicado RFID solo se valida si realmente usas RFID
C#
if (usarRfid && !string.IsNullOrWhiteSpace(rfid) && _cacheRFID.ContainsKey(rfid))
3. SaveRFID(...) solo se llama si hay RFID
C#
if (usarRfid)
{
    result = _bdPrenda.SaveRFID(...)
}
else
{
    result = Tuple.Create(0, "OK");
}
4. En MySQL, id_rfid queda vacío si no aplica RFID
C#
{ "id_rfid", usarRfid ? rfid : "" }
Ahora revisa también VinculacionRequest.cs
Debe tener esto:
C#
namespace DS9908R_App
{
    public class VinculacionRequest
    {
        public string CodigoBarras { get; set; }
        public string Rfid { get; set; }
        public string HojaMarcacion { get; set; }
        public string CodTrabajador { get; set; }
        public string Empresa { get; set; }
        public bool UsarRfid { get; set; }
    }
}
Y en frmLector.cs, IntentarVincular() debe mandar bien UsarRfid
Debe verse así:
C#
private void IntentarVincular()
{
    string codigo = (_ultimoCodigoBarra ?? "").Trim();
    string rfid = (_ultimoRfid ?? "").Trim();
    string hojaMarcacion = (nroHM.Text ?? "").Trim();

    if (string.IsNullOrWhiteSpace(codigo))
        return;

    if (_rfidPendientes.Count > 1)
    {
        toolStripStatusLbl.Text = "Error: múltiples RFID detectados.";
        return;
    }

    var request = new VinculacionRequest
    {
        CodigoBarras = codigo,
        Rfid = rfid,
        HojaMarcacion = hojaMarcacion,
        CodTrabajador = mCodTrabajador,
        Empresa = mEmpresa,
        UsarRfid = !string.IsNullOrWhiteSpace(rfid)
    };

    _vinculador.Enqueue(request);
}
Validación funcional esperada
Caso 1: solo código de barras
no hay RFID
UsarRfid = false
guarda sin exigir RFID
Caso 2: un RFID + código de barras
UsarRfid = true
guarda con RFID
Caso 3: más de un RFID
frmLector debe bloquear antes de llegar al service
no debería encolar nada
Cómo va hasta ahora
Por lo que vienes contando, la arquitectura ya está mejor que antes:
login funciona
scanner se detecta
RFID ya lee
ya separaste UI / servicio / acceso a datos
solo faltaba cerrar bien las validaciones de negocio
Vas bien. El siguiente punto crítico ya no es el service, sino verificar que en frmLector:
SetRfid() agregue al grid
cantidadRfid suba
CodBarras_KeyDown sea el que dispare el guardado
Si quieres, el siguiente mensaje te dejo una revisión completa de frmLector.cs enfocada en:
múltiples RFID
Enter automático del barcode
limpiar como en tu .NET original.