using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views
{
    partial class w_coneccion_anywhere
    {
        private IContainer components = null;

        // Controles con los mismos nombres PB
        public Label st_titulo;
        public Label st_dsn;
        public TextBox sle_dsn;
        public Label st_usuario;
        public TextBox sle_usuario;
        public Label st_clave;
        public TextBox sle_clave;
        public Button cb_probar;
        public Button cb_aceptar;
        public Button cb_cancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.st_titulo = new Label();
            this.st_titulo.Name = "st_titulo";
            this.st_titulo.Text = "Conexión SQL Anywhere (DSN)";
            this.st_titulo.AutoSize = true;
            this.st_titulo.Location = new System.Drawing.Point(12, 12);
            this.st_dsn = new Label();
            this.st_dsn.Name = "st_dsn";
            this.st_dsn.Text = "DSN";
            this.st_dsn.AutoSize = true;
            this.st_dsn.Location = new System.Drawing.Point(12, 40);
            this.sle_dsn = new TextBox();
            this.sle_dsn.Name = "sle_dsn";
            this.sle_dsn.Location = new System.Drawing.Point(12, 60);
            this.sle_dsn.Size = new System.Drawing.Size(360, 23);
            this.st_usuario = new Label();
            this.st_usuario.Name = "st_usuario";
            this.st_usuario.Text = "Usuario";
            this.st_usuario.AutoSize = true;
            this.st_usuario.Location = new System.Drawing.Point(12, 92);
            this.sle_usuario = new TextBox();
            this.sle_usuario.Name = "sle_usuario";
            this.sle_usuario.Location = new System.Drawing.Point(12, 112);
            this.sle_usuario.Size = new System.Drawing.Size(360, 23);
            this.st_clave = new Label();
            this.st_clave.Name = "st_clave";
            this.st_clave.Text = "Clave";
            this.st_clave.AutoSize = true;
            this.st_clave.Location = new System.Drawing.Point(12, 144);
            this.sle_clave = new TextBox();
            this.sle_clave.Name = "sle_clave";
            this.sle_clave.Location = new System.Drawing.Point(12, 164);
            this.sle_clave.Size = new System.Drawing.Size(360, 23);
            this.sle_clave.UseSystemPasswordChar = true;
            this.cb_probar = new Button();
            this.cb_probar.Name = "cb_probar";
            this.cb_probar.Text = "Probar";
            this.cb_probar.AutoSize = true;
            this.cb_probar.Location = new System.Drawing.Point(12, 204);
            this.cb_probar.Click += new System.EventHandler(this.cb_probar_Click);
            this.cb_aceptar = new Button();
            this.cb_aceptar.Name = "cb_aceptar";
            this.cb_aceptar.Text = "Aceptar";
            this.cb_aceptar.AutoSize = true;
            this.cb_aceptar.Location = new System.Drawing.Point(206, 204);
            this.cb_aceptar.Click += new System.EventHandler(this.cb_aceptar_Click);
            this.cb_cancelar = new Button();
            this.cb_cancelar.Name = "cb_cancelar";
            this.cb_cancelar.Text = "Cancelar";
            this.cb_cancelar.AutoSize = true;
            this.cb_cancelar.Location = new System.Drawing.Point(292, 204);
            this.cb_cancelar.Click += new System.EventHandler(this.cb_cancelar_Click);

            this.SuspendLayout();

            this.Controls.Add(this.st_titulo);
            this.Controls.Add(this.st_dsn);
            this.Controls.Add(this.sle_dsn);
            this.Controls.Add(this.st_usuario);
            this.Controls.Add(this.sle_usuario);
            this.Controls.Add(this.st_clave);
            this.Controls.Add(this.sle_clave);
            this.Controls.Add(this.cb_probar);
            this.Controls.Add(this.cb_aceptar);
            this.Controls.Add(this.cb_cancelar);

            // w_coneccion_anywhere
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(384, 252);
            this.Name = "w_coneccion_anywhere";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_coneccion_anywhere";

            this.ResumeLayout(false);
        }
    }
}
