using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DS9908R_App
{
    public partial class FormConfirmacion : Form
    {
        public FormConfirmacion()
        {
            InitializeComponent();
        }

        public FormConfirmacion(string titulo, Color PColor, string mensaje,
            string m_aceptar = "Sí, Editar", string m_cancelar = "No, Cancelar")
        {
            InitializeComponent();

            EstiloBoton(btnAceptar, "#3085d6", "#FFFFFF", "#2b77c0");
            EstiloBoton(btnCancelar, "#dd3333", "#FFFFFF", "#c72e2e");
            TituloAviso.Text = titulo;
            DescripcionAviso.Text = mensaje;
            btnAceptar.Text = m_aceptar;
            btnCancelar.Text = m_cancelar;

            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            this.Paint += (s, e) =>
            {
                using (var brush = new LinearGradientBrush(this.ClientRectangle,
                    Color.White, Color.FromArgb(230, 230, 230), LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
            };

            EstiloBoton(btnAceptar, "#3085d6", "#FFFFFF", "#1f6ac1");
            EstiloBoton(btnCancelar, "#dd3333", "#FFFFFF", "#b52b2b");

            TituloAviso.ForeColor = Color.Black;
            DescripcionAviso.ForeColor = Color.FromArgb(100, 100, 100);

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.Region = Region.FromHrgn(WinApiHelper.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void EstiloBoton(Button btn, string colorFondo, string colorTexto, string colorHover)
        {
            btn.BackColor = ColorTranslator.FromHtml(colorFondo);
            btn.ForeColor = ColorTranslator.FromHtml(colorTexto);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(colorHover);
            btn.Font = new Font("Microsoft Sans Serif", 12.0F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn.Cursor = Cursors.Hand;
        }

        private void FormConfirmacion_Load(object sender, EventArgs e)
        {
            var utilSVG = new UtilidadesSVG();
            string svgPath = utilSVG.ObtenerRutaSVG("icono_exclamation_512.svg");

            if (!string.IsNullOrEmpty(svgPath))
            {
                utilSVG.CargarIconoSVG(this.pictureBox1, svgPath);
            }
            else
            {
                Console.WriteLine("⚠️ No se pudo encontrar la imagen SVG.");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    public static class WinApiHelper
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(
            int left, int top, int right, int bottom, int width, int height);
    }
}
