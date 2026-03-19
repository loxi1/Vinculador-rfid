using DS9908R_App;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Scanner_SDK_Sample_Application
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Validar la red
            int tipoRed = ObtenerTipoConexionRed();

            if(tipoRed !=2)
            {
                string mensaje = (tipoRed == 1)
                    ? "Está conectado por WiFi, debe usar una conexión por cable."
                    : "No se detectó una conexión activa.";

                MessageBox.Show(
                    mensaje,
                    "Validación de red",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 2. Mostrar login
            using (var formLogin = new FormTrabajador())
            {
                if (formLogin.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // 3. Obtener datos del trabajador
                string codTrabajador = formLogin.CodTrabajador;
                string usuario = formLogin.Usuario;
                string turno = formLogin.Turno;

                // 4. Validar datos
                if (string.IsNullOrWhiteSpace(codTrabajador) ||
                    string.IsNullOrWhiteSpace(usuario))
                {
                    MessageBox.Show(
                        "Por favor, complete todos los campos.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                // 5. Abrir formulario principal real
                Application.Run(new frmLector(codTrabajador, usuario, turno));
            }
        }

        /// <summary>
        /// Retorna:
        /// 0 = sin conexión
        /// 1 = WiFi
        /// 2 = Ethernet
        /// </summary>
        private static int ObtenerTipoConexionRed()
        {
            try
            {
                var interfaces = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(ni =>
                        ni.OperationalStatus == OperationalStatus.Up &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Tunnel);

                bool hayEthernet = interfaces.Any(ni =>
                    ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet);

                if (hayEthernet)
                    return 2;

                bool hayWifi = interfaces.Any(ni =>
                    ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211);

                if (hayWifi)
                    return 1;

                return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}