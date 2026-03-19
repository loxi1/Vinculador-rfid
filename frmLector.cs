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

        private void btnBuscarScanners_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarEstadoConexion("BUSCANDO...", Color.DarkOrange);
                cmbScanners.Items.Clear();
                _scanners.Clear();

                // Simulación inicial
                var scanner = new ScannerInfoItem
                {
                    ScannerId = "1",
                    DisplayText = "1 - DS9908-SRR0004ZZUS - SNAPI"
                };

                _scanners.Add(scanner);
                cmbScanners.Items.Add(scanner);

                if (cmbScanners.Items.Count > 0)
                    cmbScanners.SelectedIndex = 0;

                ActualizarEstadoConexion("SCANNER DETECTADO", Color.SeaGreen);
            }
            catch (Exception ex)
            {
                ActualizarEstadoConexion("ERROR AL BUSCAR", Color.Firebrick);
                MessageBox.Show("Error al buscar scanners: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnBuscarScanners_Click_1(object sender, EventArgs e)
        {
            try
            {
                ActualizarEstadoConexion("BUSCANDO...", Color.DarkOrange);
                _scanners.Clear();

                // Simulación inicial
                var scanner = new ScannerInfoItem
                {
                    ScannerId = "1",
                    DisplayText = "1 - DS9908-SRR0004ZZUS - SNAPI"
                };

                _scanners.Add(scanner);

                ActualizarEstadoConexion("SCANNER DETECTADO", Color.SeaGreen);
            }
            catch (Exception ex)
            {
                ActualizarEstadoConexion("ERROR AL BUSCAR", Color.Firebrick);
                MessageBox.Show("Error al buscar scanners: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbScanners_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {

                
            }
            catch (Exception ex)
            {
                HabilitarTabsTrabajo(false);
                ActualizarEstadoConexion("ERROR DE SELECCIÓN", Color.Firebrick);

                MessageBox.Show("Error al seleccionar scanner: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
