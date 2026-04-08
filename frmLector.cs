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
        private const int MAX_CACHE_SIZE = 500;

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
                BloquearColumnas(DataGridView1);

                // tabMenu
                tabMenu.DrawItem += tabMenu_DrawItem;

                _vinculador = new VinculadorService();
                _vinculador.OnInfo += Vinculador_OnInfo;
                _vinculador.OnError += Vinculador_OnError;
                _vinculador.OnInsertadoOk += Vinculador_OnInsertadoOk;

                ListarTimbrados();

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

                // 🔹 PRIMERO te suscribes
                _vinculador.OnConsolidadoGenerado += (total, detalle) =>
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                            GenerarConsolidadoDinamico(total, detalle)
                        ));
                    }
                    else
                    {
                        GenerarConsolidadoDinamico(total, detalle);
                    }
                };

                // 🔹 DESPUÉS ejecutas
                _vinculador.GenerarConsolidado(mCodTrabajador);

                _vinculador.OnHistorialPrenda += Vinculador_OnHistorialPrenda;

                _vinculador.OnHMGenerado += (cabecera, total, detalle) =>
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() =>
                        {
                            CargarValoresEnLabels(cabecera);
                            MostrarEnDataGridView3(total, detalle);
                        }));
                    }
                    else
                    {
                        CargarValoresEnLabels(cabecera);
                        MostrarEnDataGridView3(total, detalle);
                    }
                };
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

            SetEstado(texto, color); // 🔥 sincroniza con MsnVincular
        }

        private void HabilitarTabsTrabajo(bool habilitar)
        {
            if (tabVinculador != null) tabVinculador.Enabled = habilitar;
            if (tablaBuscarPrenda != null) tablaBuscarPrenda.Enabled = habilitar;
            if (tabHojaMarcacion != null) tabHojaMarcacion.Enabled = habilitar;
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
                    SetMensajeVincular("Error lectura: " + ex.Message);
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

            dgvTagList.Columns.Add("RFID", "RFID LEÍDO");
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

            SetMensajeVincular("REGISTER_FOR_EVENTS status: " + status);
        }

        private void OnPnpEventLector(short eventType, ref string pnpData)
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    SetMensajeVincular("Evento PNP: " + eventType);

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
                        SetMensajeVincular("Error refrescando scanners: " + ex2.Message);
                    }
                }));
            }
            catch (Exception ex)
            {
                BeginInvoke(new Action(() =>
                {
                    SetMensajeVincular("Error PNP: " + ex.Message);
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
            string hojaMarcacion = "";

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

            SetEstado(msg, Color.DarkOrange);
        }

        private void Vinculador_OnError(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(Vinculador_OnError), msg);
                return;
            }

            SetEstado(msg, Color.Firebrick);
            ReproducirError();

            AlertaManager.MostrarAlerta(msg, pinturaRoja, 3, 5);

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

            if (data != null)
            {
                if (data.ContainsKey("op"))
                    TextBoxOP.Text = Convert.ToString(data["op"]);

                if (data.ContainsKey("hoja_marcacion"))
                    TextBoxHM.Text = Convert.ToString(data["hoja_marcacion"]);
            }

            SetEstado("Prenda registrada exitosamente.", Color.Green);
            LlenarPrimeraFilaDataGridView1(data);
            ActualizarTotalCount();

            ReproducirOk();
            AlertaManager.MostrarAlerta("Registrado Ok", pinturaVerde, 1, 5);

            CodBarras.Clear();
            _ultimoCodigoBarra = "";
            _ultimoRfid = "";
            _rfidPendientes.Clear();
            dgvTagList.Rows.Clear();
            cantidadRFID.Text = "0";
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

                SetMensajeVincular("GET_SCANNERS status: " + status + " total: " + numOfScanners);

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
                SetMensajeVincular("Error GET_SCANNERS: " + ex.Message);
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
            if (MsnVincular == null)
                return;

            if (MsnVincular.InvokeRequired)
            {
                MsnVincular.Invoke(new Action<string, Color>(SetEstado), mensaje, color);
                return;
            }

            MsnVincular.Text = mensaje ?? "";
            MsnVincular.ForeColor = Color.White;
            MsnVincular.BackColor = color;
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

            CodBarras.Focus();
        }

        private void AlertaErrorMsn(string mensaje, Color color)
        {
            SetMensajeVincular(mensaje);
            using (var alerta = new FormAlertaError("Error", mensaje, color))
            {
                alerta.ShowDialog();
            }
        }

        private void MostrarAlerta(string mensaje, Action callback = null)
        {
            SetMensajeVincular(mensaje);

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

        private void AlertaError(string mensaje, Color color, Action callback = null)
        {
            // 🔥 Evitar que se abran múltiples alertas al mismo tiempo
            if (FormAlertaError.alertaAbierta)
                return;

            using (var alertaError = new FormAlertaError("Error", mensaje, color, callback))
            {
                alertaError.ShowDialog();
            }
        }

        private void BloquearColumnas(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Name != "hoja_marcacion")
                {
                    column.ReadOnly = true;
                }
            }
        }

        private void ResaltarUltimaFila(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0) return;

            int last = dgv.Rows.Count - 1;

            dgv.Rows[last].DefaultCellStyle.BackColor = Color.LightGreen;
            dgv.FirstDisplayedScrollingRowIndex = last;
        }

        private void dgvTagList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void BloquearColumnasDataGridView1()
        {
            foreach (DataGridViewColumn column in DataGridView1.Columns)
            {
                if (column.Name != "hoja_marcacion")
                {
                    column.ReadOnly = true;
                }
            }
        }

        private void SetMensajeVincular(string mensaje)
        {
            if (MsnVincular == null)
                return;

            if (MsnVincular.InvokeRequired)
            {
                MsnVincular.Invoke(new Action<string>(SetMensajeVincular), mensaje);
                return;
            }

            MsnVincular.Text = mensaje ?? "";
        }

        private void ActualizarTotalCount()
        {
            int totalRegistros = DataGridView1.AllowUserToAddRows ? DataGridView1.Rows.Count - 1 : DataGridView1.Rows.Count;

            if (totalRegistros < 0)
                totalRegistros = 0;

            lblTotalCount.Text = totalRegistros.ToString();

            if (totalRegistros >= MAX_CACHE_SIZE)
            {
                LimpiarTodo();
            }
        }

        private void CheckAndClearCache()
        {
            if (_rfidLeidos.Count > MAX_CACHE_SIZE)
            {
                Console.WriteLine("⚠️ Caché superó 500 elementos, limpiando...");
                _rfidLeidos.Clear();
                Console.WriteLine("✅ Caché vaciada.");
            }
        }

        private void LlenarPrimeraFilaDataGridView1(Dictionary<string, object> data)
        {
            if (DataGridView1 == null || data == null)
                return;

            if (DataGridView1.InvokeRequired)
            {
                DataGridView1.Invoke(new Action<Dictionary<string, object>>(LlenarPrimeraFilaDataGridView1), data);
                return;
            }

            DataGridView1.Rows.Insert(0);
            int rowIndex = 0;

            SetCellValueIfExists(DataGridView1, rowIndex, "id_rfid", data);
            SetCellValueIfExists(DataGridView1, rowIndex, "op", data);
            SetCellValueIfExists(DataGridView1, rowIndex, "corte", data);
            SetCellValueIfExists(DataGridView1, rowIndex, "subcorte", data);
            SetCellValueIfExists(DataGridView1, rowIndex, "cod_talla", data);
            SetCellValueIfExists(DataGridView1, rowIndex, "id_talla", data);
            SetCellValueIfExists(DataGridView1, rowIndex, "talla", data);
            SetCellValueIfExists(DataGridView1, rowIndex, "color", data);
            SetCellValueIfExists(DataGridView1, rowIndex, "hoja_marcacion", data);
            SetCellValueIfExists(DataGridView1, rowIndex, "fecha", data);
            SetCellValueIfExists(DataGridView1, rowIndex, "linea", data);

            BloquearColumnasDataGridView1();
            ResaltarFilaInsertada(rowIndex);
        }

        private void ResaltarFilaInsertada(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= DataGridView1.Rows.Count)
                return;

            var row = DataGridView1.Rows[rowIndex];

            row.DefaultCellStyle.BackColor = Color.LightGreen;

            Timer t = new Timer();
            t.Interval = 800;

            t.Tick += (s, e) =>
            {
                row.DefaultCellStyle.BackColor = Color.White;
                t.Stop();
                t.Dispose();
            };

            t.Start();
        }

        private void SetCellValueIfExists(DataGridView dgv, int rowIndex, string columnName, Dictionary<string, object> data)
        {
            if (dgv == null || data == null)
                return;

            if (!dgv.Columns.Contains(columnName))
                return;

            object value = data.ContainsKey(columnName) ? data[columnName] : "";
            dgv.Rows[rowIndex].Cells[columnName].Value = value ?? "";
        }

        private void tabMenu_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = sender as TabControl;
            if (tab == null) return;

            TabPage page = tab.TabPages[e.Index];
            Rectangle rect = e.Bounds;
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color backColor = selected ? Color.FromArgb(0, 120, 215) : Color.FromArgb(235, 235, 235);
            Color textColor = selected ? Color.White : Color.FromArgb(45, 45, 48);

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            TextRenderer.DrawText(
                e.Graphics,
                page.Text,
                new Font("Segoe UI", 10F, FontStyle.Bold),
                rect,
                textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private bool ExisteRFIDEnGrid(string rfid)
        {
            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                if (row.Cells["id_rfid"].Value?.ToString() == rfid)
                    return true;
            }
            return false;
        }

        private void tablaContenedora_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SetEstadoGeneral(string mensaje, Color color)
        {
            SetMensajeVincular(mensaje);

            if (MsnVincular != null)
            {
                MsnVincular.ForeColor = color;
            }
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

        private void ResaltarPrimerRfid()
        {
            if (dgvTagList.Rows.Count == 0) return;

            dgvTagList.ClearSelection();
            dgvTagList.Rows[0].Selected = true;
            dgvTagList.FirstDisplayedScrollingRowIndex = 0;
        }

        private void btnVerConsolidado_Click(object sender, EventArgs e)
        {
            LimpiarGridConsolidado();
            _vinculador.GenerarConsolidado(mCodTrabajador);
        }

        private void ListarTimbrados()
        {
            try
            {
                Dictionary<string, object> where = new Dictionary<string, object>();

                if (!string.IsNullOrWhiteSpace(mCodTrabajador))
                    where["fotocheck"] = mCodTrabajador;

                if (_vinculador == null)
                {
                    SetEstado("El servicio de vinculación no está inicializado.", Color.Firebrick);
                    return;
                }

                var resultado = _vinculador.ListarTimbradas(where);

                if (resultado.Item1 >= 0)
                {
                    LlenarDataGridViewDesdeDataTable(resultado.Item3);
                    ActualizarTotalCount();
                    SetEstado(resultado.Item2, Color.SeaGreen);
                }
                else
                {
                    SetEstado("Error al listar timbrados: " + resultado.Item2, Color.Firebrick);
                }
            }
            catch (Exception ex)
            {
                SetEstado("Error al listar timbrados: " + ex.Message, Color.Firebrick);
            }
        }

        private void LlenarDataGridViewDesdeDataTable(DataTable dataTimbrado)
        {
            try
            {
                DataGridView1.Rows.Clear();

                if (dataTimbrado == null || dataTimbrado.Rows.Count == 0)
                    return;

                foreach (DataRow dr in dataTimbrado.Rows)
                {
                    int rowIndex = DataGridView1.Rows.Add();

                    DataGridView1.Rows[rowIndex].Cells["linea"].Value = dr["linea"]?.ToString() ?? "";
                    DataGridView1.Rows[rowIndex].Cells["op"].Value = dr["op"]?.ToString() ?? "";
                    DataGridView1.Rows[rowIndex].Cells["hoja_marcacion"].Value = dr["hoja_marcacion"]?.ToString() ?? "";
                    DataGridView1.Rows[rowIndex].Cells["corte"].Value = dr["corte"]?.ToString() ?? "";
                    DataGridView1.Rows[rowIndex].Cells["subcorte"].Value = dr["subcorte"]?.ToString() ?? "";
                    DataGridView1.Rows[rowIndex].Cells["color"].Value = dr["color"]?.ToString() ?? "";
                    DataGridView1.Rows[rowIndex].Cells["talla"].Value = dr["talla"]?.ToString() ?? "";
                    DataGridView1.Rows[rowIndex].Cells["cod_talla"].Value = dr["cod_talla"]?.ToString() ?? "";
                    DataGridView1.Rows[rowIndex].Cells["id_talla"].Value = dr["id_talla"]?.ToString() ?? "";
                    DataGridView1.Rows[rowIndex].Cells["fecha"].Value = dr["fecha"]?.ToString() ?? "";
                    DataGridView1.Rows[rowIndex].Cells["id_rfid"].Value = dr["id_rfid"]?.ToString() ?? "";
                }

                BloquearColumnas(DataGridView1);
            }
            catch (Exception ex)
            {
                SetEstado("Error al llenar grid: " + ex.Message, Color.Firebrick);
            }
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                string nombreColumna = DataGridView1.Columns[e.ColumnIndex].Name;

                if (nombreColumna != "hoja_marcacion")
                    return;

                DataGridViewRow fila = DataGridView1.Rows[e.RowIndex];

                string nuevoValor = Convert.ToString(fila.Cells["hoja_marcacion"].Value)?.Trim() ?? "";
                string idRfid = Convert.ToString(fila.Cells["id_rfid"].Value)?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(idRfid))
                {
                    SetEstado("No se puede actualizar: id_rfid vacío.", Color.Firebrick);
                    return;
                }

                var where = new Dictionary<string, object>
        {
            { "rfid", idRfid }
        };

                if (!string.IsNullOrWhiteSpace(mCodTrabajador))
                    where["fotocheck"] = mCodTrabajador;

                var update = new Dictionary<string, object>
        {
            { "nhoja", nuevoValor }
        };

                if (_vinculador == null)
                {
                    SetEstado("El servicio de vinculación no está inicializado.", Color.Firebrick);
                    return;
                }

                int resultado = _vinculador.UpdateTimbrado(where, update);

                if (resultado > 0)
                {
                    fila.Cells["fecha"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    SetEstado("Hoja de marcación actualizada correctamente.", Color.SeaGreen);
                }
                else
                {
                    SetEstado("No se actualizó el timbrado.", Color.DarkOrange);
                }
            }
            catch (Exception ex)
            {
                SetEstado("Error al editar: " + ex.Message, Color.Firebrick);
            }
        }

        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (DataGridView1.Columns[e.ColumnIndex].Name == "hoja_marcacion")
                {
                    e.CellStyle.BackColor = Color.LightYellow;
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.SelectionBackColor = Color.Gold;
                    e.CellStyle.SelectionForeColor = Color.Black;
                }
            }
            catch
            {
            }
        }

        private void lblTotalDetalle_Click(object sender, EventArgs e)
        {

        }

        private void GenerarConsolidadoDinamico(
    List<Dictionary<string, object>> totalTalla,
    Dictionary<string, List<Dictionary<string, object>>> detalleTalla)
        {
            if (totalTalla == null || totalTalla.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar.");
                return;
            }

            tbDetalleTimbrado.SuspendLayout();
            tbDetalleTimbrado.Controls.Clear();
            tbDetalleTimbrado.RowStyles.Clear();
            tbDetalleTimbrado.RowCount = 0;
            tbDetalleTimbrado.ColumnCount = 1;
            tbDetalleTimbrado.AutoSize = true;
            tbDetalleTimbrado.Dock = DockStyle.Top;

            panelScroll.Controls.Clear();
            panelScroll.AutoScroll = true;
            panelScroll.Controls.Add(tbDetalleTimbrado);

            int totalGeneral = 0;

            foreach (var total in totalTalla)
            {
                string linea = total["linea"].ToString();
                int totalCantidad = Convert.ToInt32(total["total"]);
                totalGeneral += totalCantidad;

                // 🔹 LABEL
                Label lblLinea = new Label
                {
                    Text = $"LINEA: {linea}",
                    Font = new Font("Arial", 11, FontStyle.Bold),
                    BackColor = Color.Silver,
                    ForeColor = Color.Black,
                    Dock = DockStyle.Top,
                    Height = 25,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                tbDetalleTimbrado.RowCount++;
                tbDetalleTimbrado.Controls.Add(lblLinea, 0, tbDetalleTimbrado.RowCount - 1);

                // 🔹 GRID
                DataGridView dgv = new DataGridView
                {
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    ReadOnly = true,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    Dock = DockStyle.Top,
                    Height = 150
                };

                dgv.Columns.Add("Op", "OP");
                dgv.Columns.Add("Color", "Color");
                dgv.Columns.Add("Talla", "Talla");
                dgv.Columns.Add("Cant", "Cant");

                // 🔹 DATA
                if (detalleTalla.ContainsKey(linea))
                {
                    foreach (var detalle in detalleTalla[linea])
                    {
                        dgv.Rows.Add(
                            detalle["op"],
                            detalle["color"],
                            detalle["talla"],
                            detalle["cantidad"]
                        );
                    }
                }

                // 🔹 TOTAL
                int rowIndex = dgv.Rows.Add();
                dgv.Rows[rowIndex].Cells["Talla"].Value = "TOTAL";
                dgv.Rows[rowIndex].Cells["Cant"].Value = totalCantidad;
                dgv.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                dgv.Rows[rowIndex].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);

                tbDetalleTimbrado.RowCount++;
                tbDetalleTimbrado.Controls.Add(dgv, 0, tbDetalleTimbrado.RowCount - 1);
            }

            lblTotalDetalle.Text = $"TOTAL TIMBRADO: {totalGeneral}";

            tbDetalleTimbrado.ResumeLayout();
        }

        private void LimpiarGridConsolidado()
        {
            // 🔹 Limpiar el contenedor antes de agregar nuevos elementos
            tbDetalleTimbrado.Controls.Clear();
            tbDetalleTimbrado.RowStyles.Clear();
            tbDetalleTimbrado.RowCount = 0;
            lblTotalDetalle.Text = "";
        }

        private void BuscarCodBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                EjecutarBusqueda();
            }
        }

        private void BuscarCodBarras_Enter(object sender, EventArgs e)
        {
            if (BuscarCodBarras.Text == "Codigo de Barras...")
            {
                BuscarCodBarras.Text = "";
                BuscarCodBarras.ForeColor = pinturaNegra;
            }
        }

        private void EjecutarBusqueda()
        {
            string codigo = BuscarCodBarras.Text;

            MsnBusquedaPrenda.Text = "";
            BuscarCodBarras.Text = "";

            _vinculador.BuscarPrenda(codigo);
        }

        private void Vinculador_OnHistorialPrenda(DataTable tabla, string mensaje)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                    PintarHistorial(tabla, mensaje)
                ));
            }
            else
            {
                PintarHistorial(tabla, mensaje);
            }
        }

        private void PintarHistorial(DataTable tabla, string mensaje)
        {
            MsnBusquedaPrenda.Text = mensaje;

            DataGridView2.AutoGenerateColumns = true;
            DataGridView2.DataSource = tabla;

            foreach (DataGridViewColumn column in DataGridView2.Columns)
            {
                column.HeaderText = System.Globalization.CultureInfo.CurrentCulture.TextInfo
                    .ToTitleCase(column.HeaderText.ToLower());
            }

            DataGridView2.ColumnHeadersDefaultCellStyle.Font =
                new Font("Arial", 15, FontStyle.Bold);
        }

        private void CargarValoresEnLabels(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
                return;

            DataRow row = dataTable.Rows[0];

            foreach (DataColumn column in dataTable.Columns)
            {
                string columnName = column.ColumnName;
                string controlName = "text_" + columnName;

                Control control = this.Controls.Find(controlName, true).FirstOrDefault();

                if (control is Label lbl)
                {
                    lbl.Text = row[columnName]?.ToString();
                }
            }
        }

        private void BuscarCabeceraHM()
        {
            string pOp = TextBoxOP.Text;
            string pHm = TextBoxHM.Text;

            var where = new Dictionary<string, object>
    {
        { "norpd", pOp },
        { "nhjmr", pHm }
    };

            DataTable dt = _bdPrenda.BuscarHMCabecera(where);

            if (dt == null || dt.Rows.Count == 0)
            {
                AlertaError($"No se encontraron registros para la OP: {pOp} {pHm}", pinturaRojoLadrillo);
                return;
            }

            CargarValoresEnLabels(dt);
        }


        private void BtnBuscarHM_Click(object sender, EventArgs e)
        {
            _vinculador.GenerarHM(TextBoxOP.Text, TextBoxHM.Text);
        }

        private void MostrarEnDataGridView3(
    List<Dictionary<string, object>> totalTalla,
    Dictionary<string, List<Dictionary<string, object>>> detalleTalla)
        {
            // Limpiar DataGridView
            DataGridView3.DataSource = null;
            DataGridView3.Rows.Clear();
            DataGridView3.Columns.Clear();

            // Configurar columnas
            DataGridView3.Columns.Add("Color", "Color");
            DataGridView3.Columns.Add("Descripcion", "Descripción");
            DataGridView3.Columns.Add("Talla", "Talla");
            DataGridView3.Columns.Add("Cantidad", "Cantidad");
            DataGridView3.Columns.Add("Total", "Total");

            // Iterar sobre los totales
            foreach (var total in totalTalla)
            {
                string color = total["cclrcl"].ToString();
                string desc = total["tclrcl"].ToString();
                int totalCantidad = Convert.ToInt32(total["total"]);

                // Fila resumen (color + total)
                int resumenIndex = DataGridView3.Rows.Add();
                var resumenRow = DataGridView3.Rows[resumenIndex];

                resumenRow.Cells["Color"].Value = color;
                resumenRow.Cells["Descripcion"].Value = desc;
                resumenRow.Cells["Total"].Value = totalCantidad.ToString("N0");

                // Estilos fila resumen
                resumenRow.DefaultCellStyle.BackColor = pinturaGrisClaro;
                resumenRow.DefaultCellStyle.Font = new Font(DataGridView3.Font, FontStyle.Bold);

                if (totalCantidad > 500)
                    resumenRow.DefaultCellStyle.ForeColor = pinturaVerdeOscuro;

                // Agregar filas de detalle
                if (detalleTalla.ContainsKey(color))
                {
                    foreach (var detalle in detalleTalla[color])
                    {
                        int detalleIndex = DataGridView3.Rows.Add();
                        var detalleRow = DataGridView3.Rows[detalleIndex];

                        detalleRow.Cells["Talla"].Value = detalle["talla"];
                        detalleRow.Cells["Cantidad"].Value = Convert.ToInt32(detalle["cantidad"]).ToString("N0");

                        // Celdas de resumen vacías para detalle
                        detalleRow.Cells["Color"].Value = "";
                        detalleRow.Cells["Descripcion"].Value = "";
                        detalleRow.Cells["Total"].Value = "";

                        // Alternar color de detalle
                        detalleRow.DefaultCellStyle.BackColor = (detalleIndex % 2 == 0) ? pinturaBlanca : pinturaAzulClaro;
                    }
                }
            }

            // Ajustar tamaño de columnas automáticamente
            DataGridView3.AutoResizeColumns();
        }

        private void TextBoxOP_Enter(object sender, EventArgs e)
        {
            if (TextBoxOP.Text == "Nro OP...")
            {
                TextBoxOP.Text = "";
                TextBoxOP.ForeColor = pinturaNegra;
            }
        }

        private void TextBoxOP_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxOP.Text))
            {
                TextBoxOP.Text = "Nro OP...";
                TextBoxOP.ForeColor = pinturaGris;
            }
        }

        private void TextBoxOP_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxOP.TextLength == 5)
            {
                string pOp = "10000" + TextBoxOP.Text;
                string valor = _vinculador.ValidarOP(pOp);

                if (string.IsNullOrWhiteSpace(valor))
                {
                    TextBoxOP.Text = "";
                    TextBoxOP.Focus();
                    AlertaError($"Verificar la OP: {pOp}.", pinturaRojoLadrillo);
                }
                else
                {
                    TextBoxOP.Text = valor;
                    TextBoxOP.Enabled = false;
                    TextBoxHM.Enabled = true;
                    TextBoxHM.Text = "";
                    TextBoxHM.Focus();
                }
            }
        }

        private void TextBoxHM_Enter(object sender, EventArgs e)
        {
            if (TextBoxHM.Text == "H. M....")
            {
                TextBoxHM.Text = "";
                TextBoxHM.ForeColor = pinturaNegra;
            }
        }

        private void TextBoxHM_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxHM.Text))
            {
                TextBoxHM.Text = "H. M....";
                TextBoxHM.ForeColor = pinturaGris;
            }
        }

        private void TextBoxHM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ValidarHM();
            }
        }

        private void TextBoxHM_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, punto decimal y teclas de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Asegurarse de que solo haya un punto decimal
            if (e.KeyChar == '.' && TextBoxHM.Text.Contains("."))
            {
                e.Handled = true;
            }

            // Limitar a 3 caracteres
            if (TextBoxHM.Text.Length >= 3 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Manejar el carácter Tab si AcceptsTab es True
            if (e.KeyChar == (char)Keys.Tab)
            {
                e.Handled = true; // Opcional: evitar la inserción si no deseas un carácter Tab
            }
        }

        private void TextBoxHM_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                ValidarHM();
                e.IsInputKey = true;
            }
        }

        private void ValidarHM()
        {
            string valor = _vinculador.ValidarHM(TextBoxOP.Text, TextBoxHM.Text);

            if (string.IsNullOrWhiteSpace(valor))
            {
                TextBoxHM.Text = "";
                TextBoxHM.Focus();
                AlertaError($"Verificar la Hoja Marcación: {TextBoxHM.Text}.", pinturaRojoLadrillo);
            }
            else
            {
                TextBoxHM.Text = valor;
                TextBoxHM.Enabled = false;
                BtnBuscarHM.Focus();
            }
        }

        private void BtnLimpiarHM_Click(object sender, EventArgs e)
        {

        }
    }
}
