using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views
{
    partial class w_reconectar
    {
        private IContainer components = null;

        // Controles con los mismos nombres que en el SRW
        public Label st_1;
        public Label st_2;
        public Label st_3;
        public TextBox sle_usuario;
        public TextBox sle_password;
        public GroupBox gb_1;
        public Button cb_aceptar;
        public Button cb_cancelar;

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
            this.st_1 = new Label();
            this.st_2 = new Label();
            this.st_3 = new Label();
            this.sle_usuario = new TextBox();
            this.sle_password = new TextBox();
            this.gb_1 = new GroupBox();
            this.cb_aceptar = new Button();
            this.cb_cancelar = new Button();

            this.SuspendLayout();

            // gb_1
            this.gb_1.Name = "gb_1";
            this.gb_1.Text = "Reconectar";
            this.gb_1.Location = new Point(12, 12);
            this.gb_1.Size = new Size(360, 140);
            this.gb_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // st_1 (Usuario)
            this.st_1.Name = "st_1";
            this.st_1.Text = "Usuario:";
            this.st_1.AutoSize = true;
            this.st_1.Location = new Point(24, 36);

            // sle_usuario
            this.sle_usuario.Name = "sle_usuario";
            this.sle_usuario.Location = new Point(120, 32);
            this.sle_usuario.Size = new Size(220, 23);

            // st_2 (Password)
            this.st_2.Name = "st_2";
            this.st_2.Text = "Password:";
            this.st_2.AutoSize = true;
            this.st_2.Location = new Point(24, 68);

            // sle_password
            this.sle_password.Name = "sle_password";
            this.sle_password.Location = new Point(120, 64);
            this.sle_password.Size = new Size(220, 23);
            this.sle_password.UseSystemPasswordChar = true;

            // st_3 (mensaje/ayuda)
            this.st_3.Name = "st_3";
            this.st_3.Text = "Ingrese credenciales para reconectar.";
            this.st_3.AutoSize = true;
            this.st_3.Location = new Point(24, 100);

            // agregar a groupbox
            this.gb_1.Controls.Add(this.st_1);
            this.gb_1.Controls.Add(this.sle_usuario);
            this.gb_1.Controls.Add(this.st_2);
            this.gb_1.Controls.Add(this.sle_password);
            this.gb_1.Controls.Add(this.st_3);

            // cb_aceptar
            this.cb_aceptar.Name = "cb_aceptar";
            this.cb_aceptar.Text = "Aceptar";
            this.cb_aceptar.AutoSize = true;
            this.cb_aceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.cb_aceptar.Location = new Point(196, 164);

            // cb_cancelar
            this.cb_cancelar.Name = "cb_cancelar";
            this.cb_cancelar.Text = "Cancelar";
            this.cb_cancelar.AutoSize = true;
            this.cb_cancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.cb_cancelar.Location = new Point(292, 164);
            this.cb_cancelar.DialogResult = DialogResult.Cancel;

            // w_reconectar
            this.AcceptButton = this.cb_aceptar;
            this.CancelButton = this.cb_cancelar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(384, 201);
            this.Controls.Add(this.cb_cancelar);
            this.Controls.Add(this.cb_aceptar);
            this.Controls.Add(this.gb_1);
            this.Name = "w_reconectar";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_reconectar";

            this.ResumeLayout(false);
        }
    }
}
