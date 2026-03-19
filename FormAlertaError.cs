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
    public partial class FormAlertaError : Form
    {
        public static bool alertaAbierta = false; // 🔥 Variable de control
        private Action callback;

        public FormAlertaError(string Titulo, string Detalle, Color PColor, Action callback = null)
        {
            InitializeComponent();
            this.callback = callback; // Guardar la función de retorno

            icon_error.ForeColor = PColor;
            FranjaAbajo.BackColor = PColor;
            TituloAviso.Text = Titulo;
            DescripcionAviso.Text = Detalle;
        }

        private void FormAlertaError_Load(object sender, EventArgs e)
        {
            if (alertaAbierta)
            {
                this.Close();
                return;
            }
            alertaAbierta = true; // Marcamos que hay una alerta activa

            // Centrar la ventana en la pantalla
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2
            );
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            CerrarAlerta();
        }

        private void CerrarAlerta()
        {
            alertaAbierta = false; // 🔥 Asegurar que la variable se restablece
            this.Close();
            if (callback != null)
            {
                callback.Invoke();
            }
        }

        private void FormAlertaError_FormClosed(object sender, FormClosedEventArgs e)
        {
            alertaAbierta = false;
        }
    }
}
