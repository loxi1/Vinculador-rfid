using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS9908R_App
{
    public partial class FormAlerta : Form
    {
        private int tiempo_ = 30; // Tiempo en segundos
        private int desplazamiento = 10; // Velocidad de desplazamiento en píxeles
        private int destinoY; // Coordenada final del formulario en Y
        private readonly UtilidadesSVG utilSVG = new UtilidadesSVG();

        public FormAlerta(PictureBox pictureBox, string svgPath)
        {
            InitializeComponent();
            utilSVG.CargarIconoSVG(pictureBox, svgPath);
        }

        public FormAlerta(string mensaje, Color color, int tipo, int tiempo = 30)
        {
            InitializeComponent();
            MSNAlerta.Text = mensaje;
            MSNAlerta.ForeColor = color;
            FranjaTop.BackColor = color;
            this.BackColor = ColorTranslator.FromHtml("#fff3cd");

            // Asegurar que la alerta siempre esté en primer plano
            this.TopMost = true;
            this.BringToFront();

            // Ocultar todos los iconos
            icon_error.Visible = false;
            icon_ok.Visible = false;
            icon_info.Visible = false;

            // Cargar el icono adecuado según el tipo de alerta
            CargarIcono(tipo);

            // Asignar tiempo personalizado
            tiempo_ = tiempo;
        }

        private void CargarIcono(int tipo)
        {
            string svgFileName;

            switch (tipo)
            {
                case 1:
                    icon_ok.Visible = true;
                    svgFileName = "icono_check_512.svg";
                    break;
                case 2:
                    icon_info.Visible = true;
                    svgFileName = "icono_info_512.svg";
                    break;
                default:
                    icon_error.Visible = true;
                    svgFileName = "icono_error_512.svg";
                    break;
            }

            PictureBox target = tipo == 1 ? icon_ok : (tipo == 2 ? icon_info : icon_error);
            utilSVG.CargarIconoSVG(target, svgFileName);
        }

        private async void FormAlerta_Load(object sender, EventArgs e)
        {
            // Posicionar la alerta fuera de la pantalla (abajo)
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 50;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height;

            // Obtener la posición correcta
            destinoY = AlertaManager.ObtenerPosicion();

            // Animación para desplazar la alerta hacia arriba
            while (this.Top > destinoY)
            {
                this.Top -= desplazamiento;
                await Task.Delay(10); // Delay para suavizar la animación
            }

            // Esperar el tiempo de visualización antes de cerrar
            await Task.Delay(tiempo_ * 1000);

            // Desvanecer y cerrar
            for (double i = 1.0; i >= 0; i -= 0.1)
            {
                this.Opacity = i;
                await Task.Delay(50);
            }

            // Remover la alerta y reorganizar
            this.Close();
            AlertaManager.RemoverAlerta(this);
        }

        private void FormAlerta_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
