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
    public partial class FormAviso : Form
    {
        private int conteo;
        private int tiempo_ = 30;

        public FormAviso()
        {
            InitializeComponent();
        }

        public FormAviso(string PMensaje, Color PColor, int tiempo = 30)
        {
            InitializeComponent();
            DescripcionAviso.Text = PMensaje;
            //DescripcionAviso.ForeColor = PColor;
            FranjaAbajo.BackColor = PColor;
            icon_error.Visible = false;

            // Usar UtilidadesSVG para cargar el icono SVG
            UtilidadesSVG utilSVG = new UtilidadesSVG();
            utilSVG.CargarIconoSVG(this.icon_error, "icono_error_512.svg");

            // Asignar tiempo personalizado
            tiempo_ = tiempo;
        }

        private void FormAviso_FormClosed(object sender, FormClosedEventArgs e)
        {
            tiempo.Enabled = false;
        }

        private void FormAviso_Load(object sender, EventArgs e)
        {
            tiempo.Start();
            // Usar UtilidadesSVG para cargar el icono SVG
            var utilSVG = new UtilidadesSVG();
            utilSVG.CargarIconoSVG(this.icon_error, "icono_error_512.svg");
        }

        private void tiempo_Tick(object sender, EventArgs e)
        {
            conteo++;
            if (conteo == tiempo_)
            {
                this.Close();
            }
        }
    }
}
