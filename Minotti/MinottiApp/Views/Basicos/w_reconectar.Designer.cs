using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    public partial class w_reconectar
    {
        private System.ComponentModel.IContainer components = null;

        // Controles PB
        private Label st_1;
        private Label st_2;
        private TextBox sle_usuario;
        private TextBox sle_password;
        private Label st_3;
        private GroupBox gb_1;

        /// <inheritdoc />
        protected  override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.st_1 = new System.Windows.Forms.Label();
            this.st_2 = new System.Windows.Forms.Label();
            this.sle_usuario = new System.Windows.Forms.TextBox();
            this.sle_password = new System.Windows.Forms.TextBox();
            this.st_3 = new System.Windows.Forms.Label();
            this.gb_1 = new System.Windows.Forms.GroupBox();

            this.SuspendLayout();

            // 
            // w_reconectar (form)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 320);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Coneccion SIU-Guarani";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(0xC0, 0xC0, 0xC0); // 12632256 aprox

            // === st_3: "Ingrese Usuario y Password" (borde superior) ===
            this.st_3.Location = new Point(15, 10);
            this.st_3.Size = new Size(560, 35);
            this.st_3.Text = "Ingrese Usuario y Password";
            this.st_3.TextAlign = ContentAlignment.MiddleCenter;
            this.st_3.BorderStyle = BorderStyle.FixedSingle;
            this.st_3.BackColor = Color.FromArgb(0xC0, 0xC0, 0xC0);
            this.st_3.ForeColor = Color.Red;
            this.st_3.Font = new Font("Arial", 9F, FontStyle.Regular);

            // === gb_1 (grupo central) ===
            this.gb_1.Location = new Point(15, 55);
            this.gb_1.Size = new Size(560, 150);
            this.gb_1.BackColor = Color.FromArgb(0xC0, 0xC0, 0xC0);
            this.gb_1.Text = string.Empty;

            // === st_1: "Usuario:" ===
            this.st_1.AutoSize = false;
            this.st_1.Location = new Point(40, 80);
            this.st_1.Size = new Size(130, 22);
            this.st_1.Text = "Usuario:";
            this.st_1.TextAlign = ContentAlignment.MiddleRight;
            this.st_1.BackColor = Color.FromArgb(0xC0, 0xC0, 0xC0);
            this.st_1.Font = new Font("MS Sans Serif", 8F, FontStyle.Bold);

            // === st_2: "Password:" ===
            this.st_2.AutoSize = false;
            this.st_2.Location = new Point(40, 120);
            this.st_2.Size = new Size(130, 22);
            this.st_2.Text = "Password:";
            this.st_2.TextAlign = ContentAlignment.MiddleRight;
            this.st_2.BackColor = Color.FromArgb(0xC0, 0xC0, 0xC0);
            this.st_2.Font = new Font("MS Sans Serif", 8F, FontStyle.Bold);

            // === sle_usuario ===
            this.sle_usuario.Location = new Point(190, 78);
            this.sle_usuario.Size = new Size(260, 23);
            this.sle_usuario.Name = "sle_usuario";
            this.sle_usuario.TabIndex = 10;
            this.sle_usuario.BackColor = Color.White;
            this.sle_usuario.ForeColor = Color.FromArgb(0x80, 0x80, 0x80);
            this.sle_usuario.Font = new Font("Arial", 9F, FontStyle.Regular);

            // === sle_password ===
            this.sle_password.Location = new Point(190, 118);
            this.sle_password.Size = new Size(260, 23);
            this.sle_password.Name = "sle_password";
            this.sle_password.TabIndex = 20;
            this.sle_password.BackColor = Color.White;
            this.sle_password.ForeColor = Color.FromArgb(0x80, 0x80, 0x80);
            this.sle_password.Font = new Font("Arial", 9F, FontStyle.Regular);
            this.sle_password.PasswordChar = '●';

            // === pb_continuar (heredado de w_response) ===
            // PB: X=37 Y=477, texto "&Volver"
            this.pb_continuar.Location = new Point(30, 230);
            this.pb_continuar.Size = new Size(120, 30);
            this.pb_continuar.Text = "&Volver";
            this.pb_continuar.Font = new Font(this.pb_continuar.Font, FontStyle.Bold);
            this.pb_continuar.TabIndex = 30;

            // === pb_cancelar (heredado de w_response) ===
            // PB: X=1061 Y=477, texto "&Salir"
            this.pb_cancelar.Location = new Point(455, 230);
            this.pb_cancelar.Size = new Size(120, 30);
            this.pb_cancelar.Text = "&Salir";
            this.pb_cancelar.Font = new Font(this.pb_cancelar.Font, FontStyle.Bold);
            this.pb_cancelar.TabIndex = 40;

            // === add controls ===
            this.Controls.Add(this.st_3);
            this.Controls.Add(this.gb_1);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.st_2);
            this.Controls.Add(this.sle_usuario);
            this.Controls.Add(this.sle_password);
            // pb_continuar / pb_cancelar ya están en Controls desde w_response

            this.ResumeLayout(false);
        }
    }
}
