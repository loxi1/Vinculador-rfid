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
        private List<string> claimlist = new List<string>();
        private readonly List<ScannerInfoItem> _scanners = new List<ScannerInfoItem>();

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

            mCodTrabajador = codTrabajador;
            mUsuTrabajador = datoUsuario;
            mTurnoTrabajador = turno;

            this.Text = $"Vincular - Usuario: {mUsuTrabajador} - Trabajador: {mCodTrabajador}";
        }

        private void frmLector_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarGridRfid();

                _vinculador = new VinculadorService();
                _vinculador.OnInfo += Vinculador_OnInfo;
                _vinculador.OnError += Vinculador_OnError;
                _vinculador.OnInsertadoOk += Vinculador_OnInsertadoOk;

                m_pCoreScanner = new CCoreScannerClass();
                discoverScanner = DiscoverScanner.GetInstance(m_pCoreScanner);
                scanToConnect = ScanToConnect.GetInstance();

                m_pCoreScanner.BarcodeEvent += new _ICoreScannerEvents_BarcodeEventEventHandler(OnBarcodeEventLector);
                m_pCoreScanner.PNPEvent += new _ICoreScannerEvents_PNPEventEventHandler(OnPnpEventLector);

                m_arScanners = new Scanner[255];
                for (int i = 0; i < m_arScanners.Length; i++)
                    m_arScanners[i] = new Scanner();

                m_bScannerOpen = false;

                ActualizarEstadoConexion("LISTO PARA CONECTAR", Color.DarkOrange);
                HabilitarTabsTrabajo(false);

                CodBarras.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error inicializando CoreScanner: " + ex.Message,
                    "CoreScanner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                ActualizarEstadoConexion("ERROR INICIALIZANDO", Color.Firebrick);
            }
        }

        private void frmLector_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnLimpiarRFID_Click(object sender, EventArgs e)
        {
            LimpiarSoloRfid();
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
                if (m_pCoreScanner == null)
                {
                    ActualizarEstadoConexion("CORESCANNER NULO", Color.Firebrick);
                    MessageBox.Show("m_pCoreScanner está nulo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
                    HabilitarTabsTrabajo(false);
                    ActualizarEstadoConexion("SIN SCANNERS", Color.Firebrick);
                }
            }
            catch (Exception ex)
            {
                HabilitarTabsTrabajo(false);
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

            return valor.Length >= 24 && Regex.IsMatch(valor, "^[0-9A-Fa-f]+$");
        }

        private void SetCodigoBarras(string codigo)
        {
            BeginInvoke(new Action(() =>
            {
                CodBarras.Text = (codigo ?? "").Trim();
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
                bytes.Add(Convert.ToByte(m.Groups[1].Value, 16));

            return Encoding.ASCII.GetString(bytes.ToArray()).Trim('\r', '\n', '\0').Trim();
        }

        private void RegistrarEventos()
        {
            if (m_pCoreScanner == null || !m_bScannerOpen)
                return;

            int status;
            string outXml = "";

            string inXml =
                "<inArgs>" +
                "<cmdArgs>" +
                "<arg-int>2</arg-int>" +
                "<arg-int>1,2</arg-int>" +
                "</cmdArgs>" +
                "</inArgs>";

            m_pCoreScanner.ExecCommand(1001, ref inXml, out outXml, out status);

            toolStripStatusLbl.Text = "REGISTER_FOR_EVENTS status: " + status;
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
                        CargarScannersEnComboDesdeSDK();

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

            e.SuppressKeyPress = true;
            e.Handled = true;

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
                    SetEstado("RFID repetido", Color.LightCoral);
                    ReproducirError();
                    return;
                }

                _rfidPendientes.Add(epc);
                _ultimoRfid = epc;

                if (dgvTagList.Columns.Count == 0)
                    ConfigurarGridRfid();

                dgvTagList.Rows.Insert(0, epc);
                cantidadRFID.Text = _rfidPendientes.Count.ToString();

                if (_rfidPendientes.Count > 1)
                {
                    SetEstado("ERROR: Más de un RFID detectado", Color.LightCoral);
                    ReproducirError();
                }
                else
                {
                    SetEstado("RFID OK", Color.LightGreen);
                    ReproducirOk();
                }
            }));
        }

        private void IntentarVincular()
        {
            string codigo = (_ultimoCodigoBarra ?? "").Trim();
            string hojaMarcacion = (nroHM.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(codigo))
                return;

            if (_rfidPendientes.Count > 1)
            {
                SetEstado("ERROR: múltiples RFID detectados. Limpie.", Color.LightCoral);
                ReproducirError();
                return;
            }

            string rfid = _rfidPendientes.Count == 1 ? _rfidPendientes[0] : "";

            var request = new VinculacionRequest
            {
                CodigoBarras = codigo,
                Rfid = rfid,
                HojaMarcacion = hojaMarcacion,
                CodTrabajador = mCodTrabajador,
                Empresa = mEmpresa,
                UsarRfid = !string.IsNullOrWhiteSpace(rfid)
            };

            SetEstado("Procesando...", Color.Khaki);
            _vinculador.Enqueue(request);
        }

        private void LimpiarLecturaActual()
        {
            _rfidPendientes.Clear();
            _ultimoRfid = "";
            _ultimoCodigoBarra = "";

            dgvTagList.Rows.Clear();
            cantidadRFID.Text = "0";
            CodBarras.Clear();

            SetEstado("Listo para nueva lectura", Color.LightGreen);
            CodBarras.Focus();
        }

        private void Vinculador_OnInfo(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(Vinculador_OnInfo), msg);
                return;
            }

            SetEstado(msg, Color.Khaki);
        }

        private void Vinculador_OnError(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(Vinculador_OnError), msg);
                return;
            }

            SetEstado(msg, Color.LightCoral);
            ReproducirError();

            CodBarras.Clear();
            CodBarras.Focus();

            MostrarAlerta(msg);
        }

        private void Vinculador_OnInsertadoOk(Dictionary<string, object> data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Dictionary<string, object>>(Vinculador_OnInsertadoOk), data);
                return;
            }

            if (data.ContainsKey("op"))
                nroOP.Text = Convert.ToString(data["op"]);

            if (data.ContainsKey("hoja_marcacion"))
                nroHM.Text = Convert.ToString(data["hoja_marcacion"]);

            ReproducirOk();
            AlertaManager.MostrarAlerta("Registrado Ok", pinturaVerdeMedio, 1, 5);

            LimpiarTodo();
            SetEstado("OK", Color.LightGreen);
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
            LimpiarTodo();
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
        private void SetEstado(string mensaje, Color color)
        {
            toolStripStatusLbl.Text = mensaje;
            toolStripStatusLbl.BackColor = color;
        }

        private void ReproducirOk()
        {
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void ReproducirError()
        {
            System.Media.SystemSounds.Hand.Play();
        }

        private void LimpiarSoloRfid()
        {
            dgvTagList.Rows.Clear();
            _rfidPendientes.Clear();
            _rfidLeidos.Clear();
            _ultimoRfid = "";

            cantidadRFID.Text = "0";
            CodBarras.Clear();
            CodBarras.Focus();

            SetEstado("RFID limpiados", Color.Khaki);
        }

        private void LimpiarTodo()
        {
            LimpiarSoloRfid();

            _ultimoCodigoBarra = "";
            nroOP.Text = "";
            nroHM.Text = "";
            _hojaMarcacionActual = "";

            toolStripStatusLbl.Text = "Formulario limpiado";
            CodBarras.Focus();

            // Aquí luego puedes agregar:
            // LimpiarGridConsolidado();
            // NuevoTimbrado();
        }

        private void AlertaErrorMsn(string mensaje, Color color)
        {
            toolStripStatusLbl.Text = mensaje;
            using (var alerta = new FormAlertaError("Error", mensaje, color))
            {
                alerta.ShowDialog();
            }
        }

        private void MostrarAlerta(string mensaje, Action callback = null)
        {
            toolStripStatusLbl.Text = mensaje;

            if (FormAlertaError.alertaAbierta)
                return;

            using (var alerta = new FormAlertaError("Error", mensaje, pinturaRojoLadrillo, callback))
            {
                alerta.ShowDialog();
            }
        }

        private void Alerta(string mensaje, Color color, int tipo, int tiempo = 10)
        {
            using (var alerta = new FormAlerta(mensaje, color, tipo, tiempo))
            {
                alerta.ShowDialog();
            }
        }

        private void AlertaOk(string titulo, Color color, int tiempo, string descripcion)
        {
            using (var alerta = new FormAlertaOk(titulo, color, tiempo, descripcion))
            {
                alerta.ShowDialog();
            }
        }
    }
}
