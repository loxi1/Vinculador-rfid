using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS9908R_App
{
    public partial class frmMain : Form
    {
        private int Tipo_de_red = 0;
        private Form _MainForm;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Obtener tipo de conexión de red
            ObtenerTipoConexionRed();

            if (Tipo_de_red == 2)
            {
                // Mostrar el formulario de login del trabajador
                var formResponse = new FormTrabajador();

                if (formResponse.ShowDialog() != DialogResult.OK)
                {
                    // Salir si el login no fue exitoso
                    this.Close();
                    return;
                }

                // Obtener los datos del trabajador
                string mCodTrabajador = formResponse.CodTrabajador;
                string dato_usuario = formResponse.Usuario;
                string dato_turno = formResponse.Turno;

                // Validar que los datos no estén vacíos
                if (string.IsNullOrWhiteSpace(mCodTrabajador) || string.IsNullOrWhiteSpace(dato_usuario))
                {
                    AlertaError("Por favor, complete todos los campos.", Color.FromArgb(238, 26, 36));
                    this.Close();
                    return;
                }

                AlertaOk($"¡Hola {dato_usuario}!", Color.FromArgb(16, 175, 76), 60);

                // Abrir el formulario principal si el login es válido
                _MainForm = new frmLector(mCodTrabajador, dato_usuario, dato_turno);
                _MainForm.FormClosed += _MainForm_Closed;
                _MainForm.Show();

                this.Hide();
            }
            else
            {
                // Mostrar alerta si la conexión no es por cable (Ethernet)
                string mensaje = (Tipo_de_red == 1)
                    ? "Está conectado por WiFi, debe usar una conexión por cable."
                    : "No se detectó una conexión activa.";

                AlertaError(mensaje, Color.FromArgb(238, 26, 36));
                this.Close();
            }
        }

        private void _MainForm_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ObtenerTipoConexionRed()
        {
            try
            {
                // Obtener todas las interfaces de red
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface ni in interfaces)
                {
                    if (ni.OperationalStatus == OperationalStatus.Up)
                    {
                        switch (ni.NetworkInterfaceType)
                        {
                            case NetworkInterfaceType.Ethernet:
                                Tipo_de_red = 2;
                                Console.WriteLine($"Detener el bucle si se detecta Ethernet Tipo_de_red-->{Tipo_de_red}");
                                return; // Detener el bucle si se detecta Ethernet
                            case NetworkInterfaceType.Wireless80211:
                                Tipo_de_red = 1;
                                Console.WriteLine($"Detener el bucle si se detecta Wi-Fi Tipo_de_red-->{Tipo_de_red}");
                                return; // Detener el bucle si se detecta Wi-Fi
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void AlertaError(string mensaje, Color color_)
        {
            using (var alerta = new FormAlertaError("Upss...", mensaje, color_))
            {
                alerta.ShowDialog();
            }
        }

        private void AlertaOk(string mensaje, Color color_, int tiempo = 30)
        {
            using (var alerta = new FormAlertaOk(mensaje, color_, tiempo))
            {
                alerta.ShowDialog();
            }
        }
    }
}
