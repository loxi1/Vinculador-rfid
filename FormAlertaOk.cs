using System;
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
    public partial class FormAlertaOk : Form
    {
        private int conteo;
        private int tiempo_ = 30;

        public FormAlertaOk()
        {
            InitializeComponent();
        }

        public FormAlertaOk(string Titulo, Color PColor, int tiempo = 30, string Detalle = "Qué bueno verte nuevamente.")
        {
            InitializeComponent();
            TituloAviso.Text = Titulo;
            icon_ok.ForeColor = PColor;
            FranjaAbajo.BackColor = PColor;
            DescripcionAviso.Text = Detalle;
            // Asignar tiempo personalizado
            tiempo_ = tiempo;
        }

        private void FormAlertaOk_FormClosed(object sender, FormClosedEventArgs e)
        {
            Tiempo.Enabled = false;
        }

        private void FormAlertaOk_Load(object sender, EventArgs e)
        {
            Tiempo.Start();

            var utilSVG = new UtilidadesSVG();
            utilSVG.CargarIconoSVG(this.icon_ok, "icono_checking_512.svg");
        }

        private void Tiempo_Tick(object sender, EventArgs e)
        {
            conteo++;
            if (conteo == tiempo_)
            {
                this.Close();
            }
        }
    }
}
