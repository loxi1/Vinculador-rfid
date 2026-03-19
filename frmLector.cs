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

namespace DS9908R_App
{
    public partial class frmLector : Form
    {
        private string mEmpresa = "COFACO";
        private string mCodTrabajador;
        private string mUsuTrabajador;
        private string mTurnoTrabajador;

        private readonly HashSet<string> _rfidLeidos = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public frmLector()
        {
            InitializeComponent();
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
            dgvTagList.AutoGenerateColumns = false;
            dgvTagList.Rows.Clear();

            tabMenu.SelectedIndexChanged -= tabMenu_SelectedIndexChanged;
            // tabMenu.TabPages.Add(tabXml);

            if (tabMenu.TabPages.Count > 0)
                tabMenu.SelectedIndex = 0;

            tabMenu.SelectedIndexChanged += tabMenu_SelectedIndexChanged;
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

        private void btnGetScanners_Click(object sender, EventArgs e)
        {
            performGetScanner();
        }

        private void cmbSlcrScnr_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstvScanners.Items[cmbSlcrScnr.SelectedIndex].Selected = true;
            lstvScanners_SelectedIndexChanged(sender, e);
        }

        private void tabMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
