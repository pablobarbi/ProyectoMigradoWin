using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views
{
    partial class w_coneccion
    {
        private IContainer components = null;
        public GroupBox gb_base;
        public GroupBox gb_aplicacion;
        public TextBox sle_usuario_base;
        public TextBox sle_clave_base;
        public Label st_usuario_base;
        public Label st_clave_base;
        public Label st_usuario_aplicacion;
        public Label st_clave_aplicacion;
        public TextBox sle_usuario_aplicacion;
        public TextBox sle_clave_aplicacion;
        public PictureBox p_1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.gb_base = new GroupBox();
            this.gb_aplicacion = new GroupBox();
            this.sle_usuario_base = new TextBox();
            this.sle_clave_base = new TextBox();
            this.st_usuario_base = new Label();
            this.st_clave_base = new Label();
            this.st_usuario_aplicacion = new Label();
            this.st_clave_aplicacion = new Label();
            this.sle_usuario_aplicacion = new TextBox();
            this.sle_clave_aplicacion = new TextBox();
            this.p_1 = new PictureBox();

            this.SuspendLayout();

            // gb_base
            this.gb_base.Name = "gb_base";
            this.gb_base.Text = "Base de datos";
            this.gb_base.Location = new Point(12, 12);
            this.gb_base.Size = new Size(380, 120);
            this.gb_base.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // st_usuario_base
            this.st_usuario_base.Name = "st_usuario_base";
            this.st_usuario_base.Text = "Usuario (DB):";
            this.st_usuario_base.AutoSize = true;
            this.st_usuario_base.Location = new Point(16, 30);

            // sle_usuario_base
            this.sle_usuario_base.Name = "sle_usuario_base";
            this.sle_usuario_base.Location = new Point(140, 26);
            this.sle_usuario_base.Size = new Size(220, 23);

            // st_clave_base
            this.st_clave_base.Name = "st_clave_base";
            this.st_clave_base.Text = "Clave (DB):";
            this.st_clave_base.AutoSize = true;
            this.st_clave_base.Location = new Point(16, 64);

            // sle_clave_base
            this.sle_clave_base.Name = "sle_clave_base";
            this.sle_clave_base.Location = new Point(140, 60);
            this.sle_clave_base.Size = new Size(220, 23);
            this.sle_clave_base.UseSystemPasswordChar = true;

            // Agregar controles al gb_base
            this.gb_base.Controls.Add(this.st_usuario_base);
            this.gb_base.Controls.Add(this.sle_usuario_base);
            this.gb_base.Controls.Add(this.st_clave_base);
            this.gb_base.Controls.Add(this.sle_clave_base);

            // gb_aplicacion
            this.gb_aplicacion.Name = "gb_aplicacion";
            this.gb_aplicacion.Text = "Aplicación";
            this.gb_aplicacion.Location = new Point(12, 144);
            this.gb_aplicacion.Size = new Size(380, 120);
            this.gb_aplicacion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // st_usuario_aplicacion
            this.st_usuario_aplicacion.Name = "st_usuario_aplicacion";
            this.st_usuario_aplicacion.Text = "Usuario (App):";
            this.st_usuario_aplicacion.AutoSize = true;
            this.st_usuario_aplicacion.Location = new Point(16, 30);

            // sle_usuario_aplicacion
            this.sle_usuario_aplicacion.Name = "sle_usuario_aplicacion";
            this.sle_usuario_aplicacion.Location = new Point(140, 26);
            this.sle_usuario_aplicacion.Size = new Size(220, 23);

            // st_clave_aplicacion
            this.st_clave_aplicacion.Name = "st_clave_aplicacion";
            this.st_clave_aplicacion.Text = "Clave (App):";
            this.st_clave_aplicacion.AutoSize = true;
            this.st_clave_aplicacion.Location = new Point(16, 64);

            // sle_clave_aplicacion
            this.sle_clave_aplicacion.Name = "sle_clave_aplicacion";
            this.sle_clave_aplicacion.Location = new Point(140, 60);
            this.sle_clave_aplicacion.Size = new Size(220, 23);
            this.sle_clave_aplicacion.UseSystemPasswordChar = true;

            // Agregar controles al gb_aplicacion
            this.gb_aplicacion.Controls.Add(this.st_usuario_aplicacion);
            this.gb_aplicacion.Controls.Add(this.sle_usuario_aplicacion);
            this.gb_aplicacion.Controls.Add(this.st_clave_aplicacion);
            this.gb_aplicacion.Controls.Add(this.sle_clave_aplicacion);

            // p_1 (logo/imagen)
            this.p_1.Name = "p_1";
            this.p_1.SizeMode = PictureBoxSizeMode.Zoom;
            this.p_1.Location = new Point(408, 12);
            this.p_1.Size = new Size(164, 120);
            this.p_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // w_coneccion
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 281);
            this.Controls.Add(this.p_1);
            this.Controls.Add(this.gb_aplicacion);
            this.Controls.Add(this.gb_base);
            this.Name = "w_coneccion";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "w_coneccion";

            this.ResumeLayout(false);
        }
    }
}
