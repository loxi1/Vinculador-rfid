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
using Scanner_SDK_Sample_Application;
using STC;

namespace DS9908R_App
{
    public partial class frmLector : Form
    {
        private readonly HashSet<string> _rfidLeidos = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly List<string> _rfidPendientes = new List<string>();

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
        private Scanner[] m_arScanners;
        private int m_nTotalScanners = 0;
        private DiscoverScanner discoverScanner;
        private ScanToConnect scanToConnect;
        private bool[] m_arSelectedTypes;
        private List<string> claimlist = new List<string>();
        private bool m_bSuccessOpen;
        private readonly List<ScannerInfoItem> _scanners = new List<ScannerInfoItem>();
        private readonly HashSet<string> _rfidLeidosGrid = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        Color pinturaBlanca = Color.White; // #FFFFFF
        Color pinturaBlancoHumo = Color.WhiteSmoke;

        Color pinturaNegra = Color.Black; // #000000

        Color pinturaRoja = Color.Red;
        Color pinturaRojoIndio = Color.IndianRed; // #d9534f
        Color pinturaRojoLadrillo = Color.Firebrick; // #c9302c
        Color pinturaRojoCarmesi = Color.FromArgb(201, 48, 44); // #c9302c
        Color pinturaRojoCoral = Color.FromArgb(217, 83, 79); // #d9534f

        Color pinturaVerde = Color.Green;
        Color pinturaVerdeOscuro = Color.DarkGreen; // #0d5934 / #218838
        Color pinturaVerdeMarMedio = Color.MediumSeaGreen; // #3BA873 / #5cb85c
        Color pinturaVerdeBosque = Color.FromArgb(13, 89, 52);
        Color pinturaVerdeClaro = Color.LightGreen;
        Color pinturaVerdeAzulado = Color.Teal;
        Color pinturaVerdeTurquesa = Color.FromArgb(59, 168, 115); // #3BA873
        Color pinturaVerdeFuerte = Color.FromArgb(13, 89, 52); // #0d5934
        Color pinturaVerdeMedio = Color.FromArgb(92, 184, 92); // #5cb85c

        Color pinturaGris = Color.Gray;
        Color pinturaGrisClaro = Color.LightGray; // #E0E0E0
        Color pinturaGrisOscuro = Color.DimGray; // #303030

        Color pinturaNaranja = Color.Orange;
        Color pinturaPlata = Color.Silver; // #BDBDBD

        Color pinturaAzulClaro = Color.LightBlue;

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
            ConfigurarGridRfid();

            _vinculador = new VinculadorService();
            _vinculador.OnInfo += Vinculador_OnInfo;
            _vinculador.OnError += Vinculador_OnError;
            _vinculador.OnInsertadoOk += Vinculador_OnInsertadoOk;

            CodBarras.Focus();
        }

        private void performGetScannerFrmLector()
        {
            m_arSelectedTypes = scanToConnect.GetSelectedTypes();

            MakeConnectCtrlFrmLector();
            registerForEventsFrmLector();
            ShowScannersFrmLector();
        }

        private void MakeConnectCtrlFrmLector()
        {
            if (!m_bSuccessOpen)
            {
                ConnectFrmLector();
            }
            else
            {
                DisconnectFrmLector();
                ConnectFrmLector();
            }
        }

        private void ConnectFrmLector()
        {
            try
            {
                short[] scannerTypes = new short[1];
                scannerTypes[0] = 1;

                int status;
                m_pCoreScanner.Open(0, scannerTypes, 1, out status);

                if (status == 0)
                {
                    m_bSuccessOpen = true;
                    toolStripStatusLbl.Text = "OPEN correcto";
                }
                else
                {
                    m_bSuccessOpen = false;
                    toolStripStatusLbl.Text = "OPEN error: " + status;
                }
            }
            catch (Exception ex)
            {
                m_bSuccessOpen = false;
                toolStripStatusLbl.Text = "OPEN excepción: " + ex.Message;
            }
        }

        private void DisconnectFrmLector()
        {
            try
            {
                int status;
                m_pCoreScanner.Close(0, out status);
                m_bSuccessOpen = false;
            }
            catch
            {
                m_bSuccessOpen = false;
            }
        }

        private void registerForEventsFrmLector()
        {
            if (!m_bSuccessOpen) return;

            try
            {
                int nEvents = 0;
                string strEvtIDs = scanToConnect.GetRegUnRegisterIDs(out nEvents);
                string inXml = scanToConnect.GenerateInitXML(nEvents, strEvtIDs);

                int opCode = 1001; // REGISTER_FOR_EVENTS
                string outXml = "";
                int status = -1;

                m_pCoreScanner.ExecCommand(opCode, ref inXml, out outXml, out status);

                toolStripStatusLbl.Text = "REGISTER_FOR_EVENTS status: " + status;
            }
            catch (Exception ex)
            {
                toolStripStatusLbl.Text = "Error register events: " + ex.Message;
            }
        }

        private void ShowScannersFrmLector()
        {
            cmbScanners.Items.Clear();
            _scanners.Clear();

            if (!m_bSuccessOpen)
            {
                ActualizarEstadoConexion("NO ABIERTO", Color.Firebrick);
                return;
            }

            short numOfScanners = 0;
            string outXML = "";
            int status = -1;

            try
            {
                m_arScanners = discoverScanner.GetScanners(ref numOfScanners, ref outXML, ref status, claimlist);

                toolStripStatusLbl.Text = "GET_SCANNERS status: " + status + " total: " + numOfScanners;

                if (status == 0 && numOfScanners > 0)
                {
                    m_nTotalScanners = numOfScanners;

                    for (int i = 0; i < numOfScanners; i++)
                    {
                        Scanner scn = m_arScanners[i];
                        if (scn == null) continue;

                        var item = new ScannerInfoItem
                        {
                            ScannerId = scn.SCANNERID,
                            DisplayText = $"{scn.SCANNERID} - {scn.MODELNO} - {scn.SCANNERTYPE}"
                        };

                        _scanners.Add(item);
                        cmbScanners.Items.Add(item);
                    }

                    if (cmbScanners.Items.Count > 0)
                    {
                        cmbScanners.SelectedIndex = 0;
                        ActualizarEstadoConexion("SCANNER DETECTADO", Color.SeaGreen);
                    }
                    else
                    {
                        ActualizarEstadoConexion("SIN SCANNERS", Color.Firebrick);
                    }
                }
                else
                {
                    ActualizarEstadoConexion("SIN SCANNERS", Color.Firebrick);
                }
            }
            catch (Exception ex)
            {
                ActualizarEstadoConexion("ERROR GET_SCANNERS", Color.Firebrick);
                toolStripStatusLbl.Text = ex.Message;
            }
        }

        private void frmLector_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnLimpiarRFID_Click(object sender, EventArgs e)
        {
            LimpiarLecturaActual();
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
                    types[0] = 1;

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
                CargarScannersEnComboDesdeSDK();

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
                    SetRfid(valor);
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
                CodBarras.Text = (codigo ?? "").Trim();

                // Si el scanner de barras envía Enter físico, KeyDown hará el guardado.
                // Si no lo envía, descomenta estas dos líneas:
                // _ultimoCodigoBarra = CodBarras.Text.Trim();
                // IntentarVincular();
            }));
        }

        private void AgregarRfid(string epc)
        {
            BeginInvoke(new Action(() =>
            {
                epc = (epc ?? "").Trim().ToUpperInvariant();

                if (string.IsNullOrWhiteSpace(epc))
                    return;

                if (_rfidLeidos.Contains(epc))
                {
                    toolStripStatusLbl.Text = "RFID repetido: " + epc;
                    return;
                }

                _rfidLeidos.Add(epc);
                _ultimoRfid = epc;

                // Si el grid no tiene columnas, crea una sola
                if (dgvTagList.Columns.Count == 0)
                {
                    dgvTagList.Columns.Add("RFID", "RFID");
                }

                // Inserta arriba
                dgvTagList.Rows.Insert(0, epc);

                toolStripStatusLbl.Text = "RFID leído: " + epc;

                // Si luego ya tienes código de barras, intenta vincular
                IntentarVincular();
            }));
        }

        private void ConfigurarGridRfid()
        {
            dgvTagList.Columns.Clear();
            dgvTagList.Rows.Clear();

            dgvTagList.AllowUserToAddRows = false;
            dgvTagList.AllowUserToDeleteRows = false;
            dgvTagList.AllowUserToResizeRows = false;
            dgvTagList.MultiSelect = false;
            dgvTagList.ReadOnly = true;
            dgvTagList.RowHeadersVisible = false;
            dgvTagList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTagList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTagList.Columns.Add("RFID", "RFID");

            ActualizarCantidadRfid();
        }

        private void ActualizarCantidadRfid()
        {
            cantidadRFID.Text = _rfidPendientes.Count.ToString();
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
            if (e.KeyCode != Keys.Enter)
                return;

            string codigo = CodBarras.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
                return;

            _ultimoCodigoBarra = codigo;

            IntentarVincular();
        }

        private void SetRfid(string epc)
        {
            BeginInvoke(new Action(() =>
            {
                epc = (epc ?? "").Trim().ToUpperInvariant();

                if (string.IsNullOrWhiteSpace(epc))
                    return;

                if (_rfidPendientes.Contains(epc))
                {
                    toolStripStatusLbl.Text = "RFID repetido";
                    return;
                }

                _rfidPendientes.Add(epc);
                _ultimoRfid = epc;

                cantidadRFID.Text = _rfidPendientes.Count.ToString();

                dgvTagList.Rows.Insert(0, epc);

                if (_rfidPendientes.Count > 1)
                {
                    toolStripStatusLbl.Text = "ERROR: Más de un RFID detectado";
                }
                else
                {
                    toolStripStatusLbl.Text = "RFID OK";
                }
            }));
        }

        private void AgregarRfidAlGrid(string rfid)
        {
            if (string.IsNullOrWhiteSpace(rfid))
                return;

            rfid = rfid.Trim().ToUpperInvariant();
            dgvTagList.Rows.Insert(0, rfid);
        }

        private void IntentarVincular()
        {
            string codigo = (_ultimoCodigoBarra ?? "").Trim();
            string hojaMarcacion = (nroHM.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(codigo))
                return;

            // 🔴 VALIDACIÓN CRÍTICA
            if (_rfidPendientes.Count > 1)
            {
                toolStripStatusLbl.Text = "ERROR: múltiples RFID detectados. Limpie.";
                return;
            }

            string rfid = _rfidPendientes.Count == 1
                ? _rfidPendientes[0]
                : "";

            var request = new VinculacionRequest
            {
                CodigoBarras = codigo,
                Rfid = rfid,
                HojaMarcacion = hojaMarcacion,
                CodTrabajador = mCodTrabajador,
                Empresa = mEmpresa,
                UsarRfid = !string.IsNullOrWhiteSpace(rfid)
            };

            toolStripStatusLbl.Text = "Procesando...";

            _vinculador.Enqueue(request);
        }

        private void LimpiarLecturaActual()
        {
            dgvTagList.Rows.Clear();
            _rfidLeidos.Clear();
            _rfidPendientes.Clear();

            _ultimoRfid = "";
            _ultimoCodigoBarra = "";

            CodBarras.Clear();
            ActualizarCantidadRfid();

            toolStripStatusLbl.Text = "Lecturas limpiadas";
            CodBarras.Focus();
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
        }

        private void Vinculador_OnInsertadoOk(Dictionary<string, object> data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Dictionary<string, object>>(Vinculador_OnInsertadoOk), data);
                return;
            }

            toolStripStatusLbl.Text = "OK";

            // 🔥 LIMPIAR TODO
            CodBarras.Clear();
            _ultimoCodigoBarra = "";
            _ultimoRfid = "";
            _rfidPendientes.Clear();

            dgvTagList.Rows.Clear();
            cantidadRFID.Text = "0";

            if (data.ContainsKey("op"))
                nroOP.Text = Convert.ToString(data["op"]);

            if (data.ContainsKey("hoja_marcacion"))
                nroHM.Text = Convert.ToString(data["hoja_marcacion"]);

            CodBarras.Focus();
        }

        private void CargarScannersEnComboDesdeSDK()
        {
            cmbScanners.Items.Clear();
            _scanners.Clear();

            if (!m_bScannerOpen)
                return;

            int status = -1;
            short numOfScanners = 0;
            string outXML = "";

            try
            {
                m_arScanners = discoverScanner.GetScanners(
                    ref numOfScanners,
                    ref outXML,
                    ref status,
                    claimlist
                );

                toolStripStatusLbl.Text = "GET_SCANNERS status: " + status + " total: " + numOfScanners;

                if (status != 0 || numOfScanners <= 0 || m_arScanners == null)
                    return;

                m_nTotalScanners = numOfScanners;

                for (int i = 0; i < numOfScanners; i++)
                {
                    Scanner scn = m_arScanners[i];
                    if (scn == null) continue;

                    var item = new ScannerInfoItem
                    {
                        ScannerId = scn.SCANNERID,
                        DisplayText = $"{scn.SCANNERID} - {scn.MODELNO} - {scn.SCANNERTYPE}"
                    };

                    _scanners.Add(item);
                    cmbScanners.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLbl.Text = "Error GET_SCANNERS: " + ex.Message;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _rfidPendientes.Clear();
            dgvTagList.Rows.Clear();
            cantidadRFID.Text = "0";

            toolStripStatusLbl.Text = "RFID limpiados";
        }

        private void CodBarras_Leave(object sender, EventArgs e)
        {
            if (CodBarras.Text == "Codigo de Barras...")
            {
                CodBarras.Text = "";

            }
        }

        private void CodBarras_Enter(object sender, EventArgs e)
        {
            if (CodBarras.Text == "Codigo de Barras...")
            {
                CodBarras.Text = "";
                CodBarras.ForeColor = pinturaNegra;
            }
        }
    }
}
