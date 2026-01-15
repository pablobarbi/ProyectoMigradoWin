using Minotti.utils;
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
            SuspendLayout();

            // =====================================================
            // FORM
            // =====================================================
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 600);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conexión";

            // =====================================================
            // LOGO (IZQUIERDA)
            // =====================================================
            p_1 = new PictureBox
            {
                Name = "p_1",
                Location = new Point(20, 20),
                Size = new Size(500, 520),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.None,
                TabStop = false,
                ImageLocation = FileUtils.GetAppFile("Pictures", "tapa1.BMP")
            };

            // =====================================================
            // BASE DE DATOS
            // =====================================================
            gb_base = new GroupBox
            {
                Name = "gb_base",
                Text = "Base de Datos",
                Location = new Point(550, 60),
                Size = new Size(500, 160)
            };

            st_usuario_base = new Label
            {
                Text = "Usuario:",
                Location = new Point(30, 45),
                Size = new Size(100, 23),
                TextAlign = ContentAlignment.MiddleRight
            };

            sle_usuario_base = new TextBox
            {
                Location = new Point(140, 45),
                Size = new Size(300, 23)
            };

            st_clave_base = new Label
            {
                Text = "Clave:",
                Location = new Point(30, 85),
                Size = new Size(100, 23),
                TextAlign = ContentAlignment.MiddleRight
            };

            sle_clave_base = new TextBox
            {
                Location = new Point(140, 85),
                Size = new Size(300, 23),
                UseSystemPasswordChar = true
            };

            gb_base.Controls.Add(st_usuario_base);
            gb_base.Controls.Add(sle_usuario_base);
            gb_base.Controls.Add(st_clave_base);
            gb_base.Controls.Add(sle_clave_base);

            // =====================================================
            // APLICACIÓN
            // =====================================================
            gb_aplicacion = new GroupBox
            {
                Name = "gb_aplicacion",
                Text = "Aplicación",
                Location = new Point(550, 240),
                Size = new Size(500, 160)
            };

            st_usuario_aplicacion = new Label
            {
                Text = "Usuario:",
                Location = new Point(30, 45),
                Size = new Size(100, 23),
                TextAlign = ContentAlignment.MiddleRight
            };

            sle_usuario_aplicacion = new TextBox
            {
                Location = new Point(140, 45),
                Size = new Size(300, 23)
            };

            st_clave_aplicacion = new Label
            {
                Text = "Clave:",
                Location = new Point(30, 85),
                Size = new Size(100, 23),
                TextAlign = ContentAlignment.MiddleRight
            };

            sle_clave_aplicacion = new TextBox
            {
                Location = new Point(140, 85),
                Size = new Size(300, 23),
                UseSystemPasswordChar = true
            };

            gb_aplicacion.Controls.Add(st_usuario_aplicacion);
            gb_aplicacion.Controls.Add(sle_usuario_aplicacion);
            gb_aplicacion.Controls.Add(st_clave_aplicacion);
            gb_aplicacion.Controls.Add(sle_clave_aplicacion);

            // =====================================================
            // BOTONES (LIBRES, NO DENTRO DE GROUPBOX)
            // =====================================================
            this.pb_continuar = new Button();
            this.pb_continuar.Location = new System.Drawing.Point(720, 160);
            this.pb_continuar.Name = "pb_continuar";
            this.pb_continuar.Size = new System.Drawing.Size(120, 32);
            this.pb_continuar.TabIndex = 20;
            this.pb_continuar.Text = "Continuar";
            this.pb_continuar.UseVisualStyleBackColor = true;
            this.pb_continuar.Anchor = AnchorStyles.Top;
            this.pb_continuar.Click += pb_continuar_Click;

            this.pb_cancelar = new Button();
            this.pb_cancelar.Location = new System.Drawing.Point(860, 160);
            this.pb_cancelar.Name = "pb_cancelar";
            this.pb_cancelar.Size = new System.Drawing.Size(120, 32);
            this.pb_cancelar.TabIndex = 21;
            this.pb_cancelar.Text = "Cancelar";
            this.pb_cancelar.UseVisualStyleBackColor = true;
            this.pb_cancelar.Anchor = AnchorStyles.Top;
            this.pb_cancelar.Click += pb_cancelar_Click;

            // =====================================================
            // ADD CONTROLS
            // =====================================================
            Controls.Add(p_1);
            Controls.Add(gb_base);
            Controls.Add(gb_aplicacion);
            Controls.Add(pb_continuar);
            Controls.Add(pb_cancelar);

            ResumeLayout(false);
        }
    }
}
