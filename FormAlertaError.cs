using System;
using System.Drawing;
using System.Windows.Forms;

namespace DS9908R_App
{
    public class FormAlertaError : Form
    {
        public static bool alertaAbierta = false;

        private readonly Action _callback;
        private Label lblTitulo;
        private Label lblDetalle;
        private Panel franjaAbajo;
        private Button btnAceptar;
        private PictureBox iconError;

        public FormAlertaError(string titulo, string detalle, Color color, Action callback = null)
        {
            _callback = callback;
            InitializeComponent();

            lblTitulo.Text = titulo;
            lblDetalle.Text = detalle;
            franjaAbajo.BackColor = color;
            iconError.Image = SystemIcons.Error.ToBitmap();
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.lblDetalle = new Label();
            this.franjaAbajo = new Panel();
            this.btnAceptar = new Button();
            this.iconError = new PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.iconError)).BeginInit();
            this.SuspendLayout();

            this.Text = "Error";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.Manual;
            this.ClientSize = new Size(460, 220);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.TopMost = true;
            this.ShowInTaskbar = false;

            iconError.Location = new Point(20, 20);
            iconError.Size = new Size(48, 48);
            iconError.SizeMode = PictureBoxSizeMode.StretchImage;

            lblTitulo.Location = new Point(85, 20);
            lblTitulo.Size = new Size(340, 28);
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);

            lblDetalle.Location = new Point(25, 80);
            lblDetalle.Size = new Size(400, 70);
            lblDetalle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            btnAceptar.Text = "Aceptar";
            btnAceptar.Location = new Point(170, 165);
            btnAceptar.Size = new Size(110, 32);
            btnAceptar.Click += BtnAceptar_Click;

            franjaAbajo.Dock = DockStyle.Bottom;
            franjaAbajo.Height = 10;

            this.Controls.Add(iconError);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblDetalle);
            this.Controls.Add(btnAceptar);
            this.Controls.Add(franjaAbajo);

            this.Load += FormAlertaError_Load;
            this.FormClosed += FormAlertaError_FormClosed;

            ((System.ComponentModel.ISupportInitialize)(this.iconError)).EndInit();
            this.ResumeLayout(false);
        }

        private void FormAlertaError_Load(object sender, EventArgs e)
        {
            if (alertaAbierta)
            {
                this.Close();
                return;
            }

            alertaAbierta = true;

            this.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2
            );
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            alertaAbierta = false;
            this.Close();

            _callback?.Invoke();
        }

        private void FormAlertaError_FormClosed(object sender, FormClosedEventArgs e)
        {
            alertaAbierta = false;
        }
    }
}