using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DS9908R_App
{
    public static class AlertaManager
    {
        private static readonly List<FormAlerta> alertasActivas = new List<FormAlerta>();
        private static readonly object alertasLock = new object();

        public static void MostrarAlerta(string mensaje, Color color, int tipo = 3, int tiempo = 5)
        {
            var nuevaAlerta = new FormAlerta(mensaje, color, tipo, tiempo);

            if (Application.OpenForms.Count > 0)
            {
                Form form = Application.OpenForms[0];
                if (form.InvokeRequired)
                {
                    form.Invoke(new Action(() => MostrarAlertaInterno(nuevaAlerta)));
                }
                else
                {
                    MostrarAlertaInterno(nuevaAlerta);
                }
            }
            else
            {
                MostrarAlertaInterno(nuevaAlerta);
            }
        }

        private static void MostrarAlertaInterno(FormAlerta alerta)
        {
            lock (alertasLock)
            {
                alerta.StartPosition = FormStartPosition.Manual;
                alerta.Location = new Point(
                    Screen.PrimaryScreen.WorkingArea.Width - alerta.Width - 50,
                    ObtenerPosicion()
                );
                alertasActivas.Add(alerta);
            }

            alerta.Show();
        }

        public static int ObtenerPosicion()
        {
            int pantallaAlto = Screen.PrimaryScreen.WorkingArea.Height;
            int alertaAlto = 70;
            int margen = 10;

            return pantallaAlto - ((alertaAlto + margen) * (alertasActivas.Count + 1));
        }

        public static void RemoverAlerta(FormAlerta alerta)
        {
            lock (alertasLock)
            {
                alertasActivas.Remove(alerta);
                ReorganizarAlertas();
            }
        }

        private static void ReorganizarAlertas()
        {
            lock (alertasLock)
            {
                int alertaAlto = 70;
                int margen = 10;
                int pantallaAlto = Screen.PrimaryScreen.WorkingArea.Height;

                for (int i = 0; i < alertasActivas.Count; i++)
                {
                    alertasActivas[i].Location = new Point(
                        alertasActivas[i].Location.X,
                        pantallaAlto - ((alertaAlto + margen) * (i + 1))
                    );
                }
            }
        }
    }
}