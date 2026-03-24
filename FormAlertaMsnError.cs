using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Svg;
using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;


namespace DS9908R_App
{
    public partial class FormAlertaMsnError : Form
    {
        public FormAlertaMsnError(string Titulo, string Detalle, Color PColor)
        {
            InitializeComponent();

            icon_error.ForeColor = PColor;
            FranjaAbajo.BackColor = PColor;
            TituloAviso.Text = Titulo;
            DescripcionAviso.Text = Detalle;
        }

        private void FormAlertaMsnError_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FormAlertaMsnError_Load(object sender, EventArgs e)
        {
            // Usar UtilidadesSVG para cargar el icono SVG
            var utilSVG = new UtilidadesSVG();
            utilSVG.CargarIconoSVG(this.icon_error, "icono_error_512.svg");
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
