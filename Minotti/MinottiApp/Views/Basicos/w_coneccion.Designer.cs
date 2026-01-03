using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    public partial class w_coneccion
    {
        private IContainer components = null!;

        public GroupBox gb_base = null!;
        public GroupBox gb_aplicacion = null!;

        public TextBox sle_usuario_base = null!;
        public TextBox sle_clave_base = null!;
        public Label st_usuario_base = null!;
        public Label st_clave_base = null!;

        public TextBox sle_usuario_aplicacion = null!;
        public TextBox sle_clave_aplicacion = null!;
        public Label st_usuario_aplicacion = null!;
        public Label st_clave_aplicacion = null!;

        public PictureBox p_1 = null!;

        private Button pb_continuar = null!;
        private Button pb_cancelar = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            this.SuspendLayout();

            // =====================================================
            // FORM
            // =====================================================
            this.Text = "Conexión";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 550);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // =====================================================
            // LOGO
            // =====================================================
            p_1 = new PictureBox
            {
                Name = "p_1",
                Location = new Point(20, 15),
                Size = new Size(860, 160),
                SizeMode = PictureBoxSizeMode.Zoom,
                TabStop = false
            };

            // =====================================================
            // GB BASE
            // =====================================================
            gb_base = new GroupBox
            {
                Name = "gb_base",
                Text = "Base de Datos",
                Location = new Point(40, 200),
                Size = new Size(360, 170)
            };

            st_usuario_base = new Label
            {
                Text = "Usuario:",
                Location = new Point(20, 40),
                Width = 80,
                TextAlign = ContentAlignment.MiddleRight
            };

            sle_usuario_base = new TextBox
            {
                Location = new Point(110, 40),
                Width = 210
            };

            st_clave_base = new Label
            {
                Text = "Clave:",
                Location = new Point(20, 85),
                Width = 80,
                TextAlign = ContentAlignment.MiddleRight
            };

            sle_clave_base = new TextBox
            {
                Location = new Point(110, 85),
                Width = 210,
                UseSystemPasswordChar = true
            };

            gb_base.Controls.Add(st_usuario_base);
            gb_base.Controls.Add(sle_usuario_base);
            gb_base.Controls.Add(st_clave_base);
            gb_base.Controls.Add(sle_clave_base);

            // =====================================================
            // GB APLICACIÓN
            // =====================================================
            gb_aplicacion = new GroupBox
            {
                Name = "gb_aplicacion",
                Text = "Aplicación",
                Location = new Point(460, 200),
                Size = new Size(360, 170)
            };

            st_usuario_aplicacion = new Label
            {
                Text = "Usuario:",
                Location = new Point(20, 40),
                Width = 80,
                TextAlign = ContentAlignment.MiddleRight
            };

            sle_usuario_aplicacion = new TextBox
            {
                Location = new Point(110, 40),
                Width = 210
            };

            st_clave_aplicacion = new Label
            {
                Text = "Clave:",
                Location = new Point(20, 85),
                Width = 80,
                TextAlign = ContentAlignment.MiddleRight
            };

            sle_clave_aplicacion = new TextBox
            {
                Location = new Point(110, 85),
                Width = 210,
                UseSystemPasswordChar = true
            };

            gb_aplicacion.Controls.Add(st_usuario_aplicacion);
            gb_aplicacion.Controls.Add(sle_usuario_aplicacion);
            gb_aplicacion.Controls.Add(st_clave_aplicacion);
            gb_aplicacion.Controls.Add(sle_clave_aplicacion);

            // =====================================================
            // BOTONES
            // =====================================================
            pb_continuar = new Button
            {
                Text = "Continuar",
                Location = new Point(260, 420),
                Size = new Size(120, 35)
            };
            pb_continuar.Click += pb_continuar_Click;

            pb_cancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(520, 420),
                Size = new Size(120, 35)
            };
            pb_cancelar.Click += pb_cancelar_Click;

            // =====================================================
            // ADD CONTROLS
            // =====================================================
            this.Controls.Add(p_1);
            this.Controls.Add(gb_base);
            this.Controls.Add(gb_aplicacion);
            this.Controls.Add(pb_continuar);
            this.Controls.Add(pb_cancelar);

            this.ResumeLayout(false);
        }
    }
}
