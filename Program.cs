using DS9908R_App;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Scanner_SDK_Sample_Application
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int tipoRed = ObtenerTipoConexionRed();

            if (tipoRed != 2)
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

            using (var formLogin = new FormTrabajador())
            {
                if (formLogin.ShowDialog() != DialogResult.OK)
                    return;

                string codTrabajador = formLogin.CodTrabajador;
                string usuario = formLogin.Usuario;
                string turno = formLogin.Turno;

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

                Application.Run(new frmLector(codTrabajador, usuario, turno));
            }
        }

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