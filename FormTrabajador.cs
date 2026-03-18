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
    public partial class FormTrabajador : Form
    {
        public string CodTrabajador { get; set; }
        public string Usuario { get; set; }
        public string Turno { get; set; }

        public FormTrabajador()
        {
            InitializeComponent();
        }

        // === Métodos Auxiliares ===
        private bool ValidarEntradas()
        {
            return !string.IsNullOrWhiteSpace(txtCodTrabajador.Text) &&
                   !string.IsNullOrWhiteSpace(ClaveTrabajador.Text);
        }

        private void LimpiarEntradas()
        {
            txtCodTrabajador.Text = "";
            ClaveTrabajador.Text = "";
            txtCodTrabajador.Focus();
        }

        private void AlertaError(string mensaje, Color color_)
        {
            using (var alerta = new FormAlertaError("Upss...", mensaje, color_))
            {
                alerta.ShowDialog();
            }
        }

        private void EstiloBoton(Button btnViste, string bkcolor = "#28A745", string txtcolor = "#FFFFFF", string bkcolorHover = "#218838")
        {
            btnViste.Anchor = AnchorStyles.Left;
            btnViste.BackColor = ColorTranslator.FromHtml(bkcolor);
            btnViste.ForeColor = ColorTranslator.FromHtml(txtcolor);
            btnViste.FlatStyle = FlatStyle.Flat;
            btnViste.FlatAppearance.BorderSize = 1;
            btnViste.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(bkcolorHover);
            btnViste.Font = new Font("Arial", 12, FontStyle.Bold);
            btnViste.Size = new Size(150, 40);
            btnViste.TextAlign = ContentAlignment.MiddleCenter;
            btnViste.Cursor = Cursors.Hand;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodTrabajador.Text) || string.IsNullOrWhiteSpace(ClaveTrabajador.Text))
                {
                    AlertaError("Por favor, Complete todos los campos.", Color.Red);
                    return;
                }

                string lsCodTrabajador = txtCodTrabajador.Text.Trim();
                string lsPassword = ClaveTrabajador.Text.Trim();

                var helper = new DBConsultas();
                string textoEncriptado = helper.Encrypt(lsPassword);

                Console.WriteLine($"lsPassword->{lsPassword} clave->{textoEncriptado}");

                var usuario = new SybaseHelper();
                var whereParameters = new Dictionary<string, object>
            {
                { "codigo", lsCodTrabajador },
                { "clave", textoEncriptado }
            };

                DataTable ldtTrabajador = usuario.ValidateUser(whereParameters);

                if (ldtTrabajador == null || ldtTrabajador.Rows.Count == 0)
                {
                    AlertaError("Código o password incorrecto, Verificar.", Color.Red);
                    return;
                }

                DataRow row = ldtTrabajador.Rows[0];

                Usuario = row["datos"].ToString();
                CodTrabajador = lsCodTrabajador;
                Turno = row["turno"].ToString();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                AlertaError("Ocurrió un error al validar el trabajador: ", Color.Red);
            }
        }

        private void txtCodTrabajador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                ButtonOk.Focus();
            }
        }

        private void FormTrabajador_Shown(object sender, EventArgs e)
        {
            txtCodTrabajador.Focus();
        }

        private void FormTrabajador_Load(object sender, EventArgs e)
        {
            //EstiloBoton(ButtonOk);
            //EstiloBoton(buttonCancelar, "#E0E0E0", "#000000", "#BDBDBD");
        }

        private void buttonCancelar_MouseLeave(object sender, EventArgs e)
        {
            buttonCancelar.BackColor = Color.FromArgb(59, 168, 115);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            txtCodTrabajador.Text = "";
            ClaveTrabajador.Text = "";
        }

        private void txtCodTrabajador_Enter(object sender, EventArgs e)
        {
            if (txtCodTrabajador.Text == "Ingrese su usuario...")
            {
                txtCodTrabajador.Text = "";
            }
        }

        private void txtCodTrabajador_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodTrabajador.Text))
            {
                txtCodTrabajador.Text = "Ingrese su usuario...";
            }
        }
    }
}
