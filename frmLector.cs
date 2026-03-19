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
        private string mEmpresa = "COFACO";
        private string mCodTrabajador;
        private string mUsuTrabajador;
        private string mTurnoTrabajador;

        private CCoreScannerClass m_pCoreScanner;
        private bool m_bSuccessOpen = false;

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
            SetEstado("Listo.");
            InicializarScannerSdk();
        }

        private void SetEstado(string mensaje)
        {
            if (lblEstadoConexion != null)
                lblEstadoConexion.Text = mensaje;

            if (toolStripStatusLbl != null)
                toolStripStatusLbl.Text = mensaje;
        }

        private void InicializarScannerSdk()
        {
            try
            {
                m_pCoreScanner = new CCoreScannerClass();
                SetEstado("SDK inicializado.");
            }
            catch (Exception ex)
            {
                SetEstado("Error al inicializar SDK: " + ex.Message);
            }
        }

        private void InicializarGridTags()
        {
            dgvTagList.AutoGenerateColumns = false;
            dgvTagList.Rows.Clear();
        }

        private void SetEstado(string mensaje)
        {
            if (toolStripStatusLbl != null)
                toolStripStatusLbl.Text = mensaje;
        }

        public void ProcesarCodigoBarras(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return;

            CodBarras.Text = codigo.Trim();
            SetEstado("Código de barras leído.");
        }

        public void ProcesarRfid(string epc)
        {
            if (string.IsNullOrWhiteSpace(epc))
                return;

            epc = epc.Trim();

            if (_rfidLeidos.Contains(epc))
            {
                SetEstado("RFID repetido.");
                return;
            }

            _rfidLeidos.Add(epc);
            dgvTagList.Rows.Add(dgvTagList.Rows.Count + 1, epc);

            SetEstado("RFID agregado.");
        }

        private void frmLector_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnLimpiarRFID_Click(object sender, EventArgs e)
        {
            _rfidLeidos.Clear();
            dgvTagList.Rows.Clear();
            SetEstado("Tags limpiados.");
        }

        private void btnBuscarScanners_Click(object sender, EventArgs e)
        {
            try
            {
                btnGetScanners.PerformClick(); // reutiliza lógica original
                SetEstado("Búsqueda ejecutada.");
            }
            catch (Exception ex)
            {
                SetEstado("Error: " + ex.Message);
            }
        }

        private void cmbScanners_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEstadoConexion.Items[cmbScanners.SelectedIndex].Selected = true;
            lblEstadoConexion_SelectedIndexChanged(sender, e);
        }

        private void tabMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool Connect()
        {
            try
            {
                if (m_pCoreScanner == null)
                {
                    SetEstado("CoreScanner no está inicializado.");
                    return false;
                }

                short[] scannerTypes = new short[1];
                scannerTypes[0] = 1; // all scanner types

                int numberOfScannerTypes = 1;
                int status;

                string inXml = "<inArgs><cmdArgs><arg-int>1</arg-int><arg-int>1</arg-int></cmdArgs></inArgs>";
                string outXml = "";

                m_pCoreScanner.Open(0, scannerTypes, numberOfScannerTypes, out status);

                if (status == 0)
                {
                    m_bSuccessOpen = true;
                    SetEstado("OPEN correcto.");
                    return true;
                }

                SetEstado("OPEN falló. Error: " + status);
                return false;
            }
            catch (Exception ex)
            {
                SetEstado("Error en OPEN: " + ex.Message);
                return false;
            }
        }

        private void Disconnect()
        {
            try
            {
                if (m_pCoreScanner != null && m_bSuccessOpen)
                {
                    int status;
                    m_pCoreScanner.Close(0, out status);
                    m_bSuccessOpen = false;
                    SetEstado("Scanner desconectado.");
                }
            }
            catch (Exception ex)
            {
                SetEstado("Error al cerrar conexión: " + ex.Message);
            }
        }

        private void BuscarScanners()
        {
            try
            {
                cmbScanners.Items.Clear();
                _scanners.Clear();

                if (!m_bSuccessOpen)
                {
                    if (!Connect())
                        return;
                }

                string inXml = "<inArgs><cmdArgs><arg-int>0</arg-int></cmdArgs></inArgs>";
                string outXml;
                int status;

                m_pCoreScanner.ExecCommand(5000, ref inXml, out outXml, out status); // GET_SCANNERS

                if (status != 0)
                {
                    SetEstado("GET_SCANNERS falló. Error: " + status);
                    return;
                }

                txtLogConexion.Text = outXml;

                var xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.LoadXml(outXml);

                var scannerNodes = xmlDoc.SelectNodes("//scanner");

                if (scannerNodes == null || scannerNodes.Count == 0)
                {
                    SetEstado("No se encontraron scanners.");
                    return;
                }

                foreach (System.Xml.XmlNode node in scannerNodes)
                {
                    string scannerId = node["scannerID"]?.InnerText ?? "";
                    string model = node["modelnumber"]?.InnerText ?? "";
                    string type = node.Attributes?["type"]?.Value ?? "";

                    var item = new ScannerInfoItem
                    {
                        ScannerId = scannerId,
                        DisplayText = $"{scannerId} - {model} - {type}"
                    };

                    _scanners.Add(item);
                    cmbScanners.Items.Add(item);
                }

                if (cmbScanners.Items.Count > 0)
                    cmbScanners.SelectedIndex = 0;

                SetEstado("Scanners encontrados correctamente.");
            }
            catch (Exception ex)
            {
                SetEstado("Error al buscar scanners: " + ex.Message);
            }
        }
    }
}
