using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using CoreScanner;

namespace DS9908R_App
{
    public partial class frmLector : Form
    {
        private VinculadorService _vinculador;
        private string _ultimoCodigoBarra = "";
        private string _ultimoRfid = "";
        private string _hojaMarcacionActual = "";

        private string mEmpresa = "COFACO";
        private string mCodTrabajador;
        private string mUsuTrabajador;
        private string mTurnoTrabajador;

        private CCoreScannerClass m_pCoreScanner;
        private bool m_bScannerOpen = false;
        private readonly HashSet<string> _rfidLeidos = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly List<ScannerInfoItem> _scanners = new List<ScannerInfoItem>();

        public frmLector()
        {
            InitializeComponent();
        }

        private class ScannerInfoItem
        {
            public string ScannerId { get; set; }
            public string DisplayText { get; set; }

            public override string ToString()
            {
                return DisplayText;
            }
        }

        // Constructor con parámetros
        public frmLector(string codTrabajador, string datoUsuario, string turno)
        {
            InitializeComponent();

            // Asignar valores a propiedades privadas
            mCodTrabajador = codTrabajador;
            mUsuTrabajador = datoUsuario;
            mTurnoTrabajador = turno;

            // Configurar el título del formulario con los datos recibidos
            this.Text = $"Vincular - Usuario: {mUsuTrabajador} - Trabajador: {mCodTrabajador}";
        }

        private void frmLector_Load(object sender, EventArgs e)
        {
            ActualizarEstadoConexion("DESCONECTADO", Color.Firebrick);
            HabilitarTabsTrabajo(false);

            try
            {
                m_pCoreScanner = new CCoreScannerClass();

                m_pCoreScanner.BarcodeEvent +=
                    new _ICoreScannerEvents_BarcodeEventEventHandler(OnBarcodeEventLector);

                m_pCoreScanner.PNPEvent +=
                    new _ICoreScannerEvents_PNPEventEventHandler(OnPnpEventLector);

                ActualizarEstadoConexion("SDK INICIALIZADO", Color.DarkOrange);

                _vinculador = new VinculadorService();

                _vinculador.OnInfo += Vinculador_OnInfo;
                _vinculador.OnError += Vinculador_OnError;
                _vinculador.OnInsertadoOk += Vinculador_OnInsertadoOk;

                CodBarras.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inicializando CoreScanner: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbScanners.Items.Clear();
            cmbScanners.DropDownStyle = ComboBoxStyle.DropDownList;


            this.KeyPreview = true;
        }

        private void frmLector_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnLimpiarRFID_Click(object sender, EventArgs e)
        {
        }
        
        private void ActualizarEstadoConexion(string texto, Color color)
        {
            lblEstadoConexion.Text = texto;
            lblEstadoConexion.BackColor = color;
            lblEstadoConexion.ForeColor = Color.White;
            lblEstadoConexion.TextAlign = ContentAlignment.MiddleCenter;

            if (toolStripStatusLbl != null)
                toolStripStatusLbl.Text = texto;
        }

        private void HabilitarTabsTrabajo(bool habilitar)
        {
            if (tabVinculador != null) tabVinculador.Enabled = habilitar;
            if (tablaBuscarPrenda != null) tablaBuscarPrenda.Enabled = habilitar;
            if (tabHojaMarcacion != null) tabHojaMarcacion.Enabled = habilitar;
        }

        private void btnBuscarScanners_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarEstadoConexion("BUSCANDO...", Color.DarkOrange);

                if (!m_bScannerOpen)
                {
                    short[] types = new short[1];
                    types[0] = 1; // todos

                    int status;
                    m_pCoreScanner.Open(0, types, 1, out status);

                    if (status != 0)
                    {
                        ActualizarEstadoConexion("ERROR OPEN: " + status, Color.Firebrick);
                        return;
                    }

                    m_bScannerOpen = true;
                }

                RegistrarEventos();
                CargarScannersEnCombo();

                if (cmbScanners.Items.Count > 0)
                {
                    cmbScanners.SelectedIndex = 0;
                    HabilitarTabsTrabajo(true);
                    ActualizarEstadoConexion("SCANNER DETECTADO", Color.SeaGreen);
                }
                else
                {
                    ActualizarEstadoConexion("SIN SCANNERS", Color.Firebrick);
                }
            }
            catch (Exception ex)
            {
                ActualizarEstadoConexion("ERROR BUSCANDO", Color.Firebrick);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbScanners_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbScanners.SelectedItem == null)
                {
                    HabilitarTabsTrabajo(false);
                    ActualizarEstadoConexion("SIN SELECCIÓN", Color.Firebrick);
                    return;
                }

                var scanner = cmbScanners.SelectedItem as ScannerInfoItem;
                if (scanner == null)
                {
                    HabilitarTabsTrabajo(false);
                    ActualizarEstadoConexion("SCANNER INVÁLIDO", Color.Firebrick);
                    return;
                }

                ActualizarEstadoConexion("CONECTADO: " + scanner.DisplayText, Color.SeaGreen);
                HabilitarTabsTrabajo(true);
            }
            catch (Exception ex)
            {
                HabilitarTabsTrabajo(false);
                ActualizarEstadoConexion("ERROR DE SELECCIÓN", Color.Firebrick);

                MessageBox.Show("Error al seleccionar scanner: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnBarcodeEventLector(short eventType, ref string scanData)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(scanData))
                    return;

                string valor = ExtraerDatoLeido(scanData);

                if (string.IsNullOrWhiteSpace(valor))
                    return;

                if (PareceRfid(valor))
                {
                    AgregarRfid(valor);
                }
                else
                {
                    SetCodigoBarras(valor);
                }
            }
            catch (Exception ex)
            {
                BeginInvoke(new Action(() =>
                {
                    toolStripStatusLbl.Text = "Error lectura: " + ex.Message;
                }));
            }
        }

        private string ExtraerDatoLeido(string xml)
        {
            try
            {
                var doc = new System.Xml.XmlDocument();
                doc.LoadXml(xml);

                var nodo = doc.SelectSingleNode("//datalabel");
                if (nodo == null) return string.Empty;

                string raw = nodo.InnerText.Trim();

                // Convierte "0x45 0x32 ..." a texto si viene así
                if (raw.Contains("0x"))
                    return HexTokensATexto(raw);

                return raw;
            }
            catch
            {
                return string.Empty;
            }
        }

        private bool PareceRfid(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return false;

            valor = valor.Trim().Replace(" ", "");

            // EPC típico: hex puro, longitud 24 o más
            if (valor.Length >= 24 && Regex.IsMatch(valor, "^[0-9A-Fa-f]+$"))
                return true;

            return false;
        }

        private void SetCodigoBarras(string codigo)
        {
            BeginInvoke(new Action(() =>
            {
                CodBarras.Text = codigo.Trim();
                toolStripStatusLbl.Text = "Código de barras leído";
            }));
        }

        private void AgregarRfid(string epc)
        {
            BeginInvoke(new Action(() =>
            {
                epc = epc.Trim().ToUpperInvariant();

                if (_rfidLeidos.Contains(epc))
                {
                    toolStripStatusLbl.Text = "RFID repetido";
                    return;
                }

                _rfidLeidos.Add(epc);
                toolStripStatusLbl.Text = "RFID leído";
            }));
        }

        private string HexTokensATexto(string entrada)
        {
            var matches = Regex.Matches(entrada, @"0x([0-9A-Fa-f]{2})");
            var bytes = new List<byte>();

            foreach (Match m in matches)
            {
                bytes.Add(Convert.ToByte(m.Groups[1].Value, 16));
            }

            return Encoding.ASCII.GetString(bytes.ToArray()).Trim('\r', '\n', '\0').Trim();
        }

        private void CargarScannersEnCombo()
        {
            cmbScanners.Items.Clear();
            _scanners.Clear();

            int status;
            string outXml = "";
            string inXml =
                "<inArgs>" +
                "<cmdArgs><arg-int>0</arg-int></cmdArgs>" +
                "</inArgs>";

            m_pCoreScanner.ExecCommand(5000, ref inXml, out outXml, out status);

            if (status != 0 || string.IsNullOrWhiteSpace(outXml))
                return;

            var doc = new System.Xml.XmlDocument();
            doc.LoadXml(outXml);

            var nodos = doc.SelectNodes("//scanner");
            if (nodos == null) return;

            foreach (System.Xml.XmlNode n in nodos)
            {
                string id = n["scannerID"]?.InnerText ?? "";
                string modelo = n["modelnumber"]?.InnerText ?? "";
                string tipo = n.Attributes?["type"]?.Value ?? "";

                var item = new ScannerInfoItem
                {
                    ScannerId = id,
                    DisplayText = $"{id} - {modelo} - {tipo}"
                };

                _scanners.Add(item);
                cmbScanners.Items.Add(item);
            }
        }

        private void RegistrarEventos()
        {
            int status;
            string outXml = "";

            // Barcode + PNP
            string inXml =
                "<inArgs>" +
                "<cmdArgs>" +
                "<arg-int>2</arg-int>" +
                "<arg-int>1,2</arg-int>" +
                "</cmdArgs>" +
                "</inArgs>";

            m_pCoreScanner.ExecCommand(1001, ref inXml, out outXml, out status);
        }

        private void OnPnpEventLector(short eventType, ref string pnpData)
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    toolStripStatusLbl.Text = "Evento PNP: " + eventType;

                    try
                    {
                        CargarScannersEnCombo();

                        if (cmbScanners.Items.Count > 0)
                        {
                            if (cmbScanners.SelectedIndex < 0)
                                cmbScanners.SelectedIndex = 0;

                            ActualizarEstadoConexion("SCANNER DETECTADO", Color.SeaGreen);
                            HabilitarTabsTrabajo(true);
                        }
                        else
                        {
                            ActualizarEstadoConexion("SIN SCANNERS", Color.Firebrick);
                            HabilitarTabsTrabajo(false);
                        }
                    }
                    catch (Exception ex2)
                    {
                        toolStripStatusLbl.Text = "Error refrescando scanners: " + ex2.Message;
                    }
                }));
            }
            catch (Exception ex)
            {
                BeginInvoke(new Action(() =>
                {
                    toolStripStatusLbl.Text = "Error PNP: " + ex.Message;
                }));
            }
        }

        private void CodBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _ultimoCodigoBarra = CodBarras.Text.Trim();
                IntentarVincular();
            }
        }

        private void SetRfid(string rfid)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetRfid), rfid);
                return;
            }

            _ultimoRfid = (rfid ?? "").Trim().Replace(" ", "");

            toolStripStatusLbl.Text = "RFID leído: " + _ultimoRfid;

            IntentarVincular();
        }

        private void IntentarVincular()
        {
            if (string.IsNullOrWhiteSpace(_ultimoCodigoBarra)) return;
            if (string.IsNullOrWhiteSpace(_ultimoRfid)) return;

            var request = new VinculacionRequest
            {
                CodigoBarras = _ultimoCodigoBarra,
                Rfid = _ultimoRfid,
                HojaMarcacion = nroHM.Text,
                CodTrabajador = mCodTrabajador,
                Empresa = mEmpresa
            };

            _vinculador.Enqueue(request);
        }

        private void Vinculador_OnInfo(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(Vinculador_OnInfo), msg);
                return;
            }

            toolStripStatusLbl.Text = msg;
        }

        private void Vinculador_OnError(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(Vinculador_OnError), msg);
                return;
            }

            toolStripStatusLbl.Text = msg;

            CodBarras.Clear();
            CodBarras.Focus();
        }

        private void Vinculador_OnInsertadoOk(Dictionary<string, object> data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Dictionary<string, object>>(Vinculador_OnInsertadoOk), data);
                return;
            }

            dgvTagList.Rows.Insert(0,
                data.ContainsKey("id_rfid") ? data["id_rfid"] : "",
                data.ContainsKey("op") ? data["op"] : "",
                data.ContainsKey("hoja_marcacion") ? data["hoja_marcacion"] : ""
            );

            CodBarras.Clear();
            _ultimoCodigoBarra = "";
            _ultimoRfid = "";

            if (data.ContainsKey("op")) nroOP.Text = Convert.ToString(data["op"]);
            if (data.ContainsKey("hoja_marcacion")) nroHM.Text = Convert.ToString(data["hoja_marcacion"]);

            toolStripStatusLbl.Text = "OK";
            CodBarras.Focus();
        }
    }
}
