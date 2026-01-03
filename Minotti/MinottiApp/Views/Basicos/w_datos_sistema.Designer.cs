using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos 
{
    partial class w_datos_sistema
    {
        private System.ComponentModel.IContainer components = null;

        // Controles con los mismos nombres que en PB
        private GroupBox gb_borde;
        private Label st_nombre;
        private Label st_version;
        private Label st_copyright;
        private PictureBox p_logo;
        private Button cb_1;

        /// <summary>
        /// Limpieza de recursos.
        /// </summary>
        /// <param name="disposing"></param>
        protected  override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gb_borde = new System.Windows.Forms.GroupBox();
            this.st_nombre = new System.Windows.Forms.Label();
            this.st_version = new System.Windows.Forms.Label();
            this.st_copyright = new System.Windows.Forms.Label();
            this.p_logo = new System.Windows.Forms.PictureBox();
            this.cb_1 = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.p_logo)).BeginInit();
            this.SuspendLayout();

            // 
            // w_datos_sistema (form)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // PB: int Width=2369  -> adaptamos a algo similar en píxeles
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Datos del sistema";

            // 
            // gb_borde
            // 
            this.gb_borde.Location = new Point(20, 20);
            this.gb_borde.Size = new Size(760, 420);
            this.gb_borde.TabIndex = 0;
            this.gb_borde.TabStop = false;
            this.gb_borde.BackColor = Color.FromArgb(0xC0, 0xC0, 0xC0); // 12632256
            this.gb_borde.Font = new Font("Arial", 8.5F, FontStyle.Regular);

            // 
            // p_logo
            // 
            this.p_logo.Location = new Point(50, 60);
            this.p_logo.Size = new Size(160, 140);
            this.p_logo.TabIndex = 1;
            this.p_logo.TabStop = false;
            this.p_logo.BackColor = Color.Transparent;
            this.p_logo.SizeMode = PictureBoxSizeMode.Zoom;

            // 
            // st_nombre
            // 
            this.st_nombre.Location = new Point(50, 220);
            this.st_nombre.Size = new Size(700, 40);
            this.st_nombre.TextAlign = ContentAlignment.MiddleCenter;
            this.st_nombre.BackColor = Color.FromArgb(0xC0, 0xC0, 0xC0);
            this.st_nombre.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.st_nombre.Enabled = false;

            // 
            // st_version
            // 
            this.st_version.Location = new Point(50, 270);
            this.st_version.Size = new Size(700, 35);
            this.st_version.TextAlign = ContentAlignment.MiddleCenter;
            this.st_version.BackColor = Color.FromArgb(0xC0, 0xC0, 0xC0);
            this.st_version.Font = new Font("Arial", 10F, FontStyle.Regular);
            this.st_version.Enabled = false;

            // 
            // st_copyright
            // 
            this.st_copyright.Location = new Point(50, 320);
            this.st_copyright.Size = new Size(700, 30);
            this.st_copyright.TextAlign = ContentAlignment.MiddleRight;
            this.st_copyright.BackColor = Color.FromArgb(0xC0, 0xC0, 0xC0);
            this.st_copyright.Font = new Font("Arial", 8.5F, FontStyle.Regular);
            this.st_copyright.Enabled = false;

            // 
            // cb_1  ("&Cerrar")
            // 
            this.cb_1.Location = new Point(640, 450);
            this.cb_1.Size = new Size(120, 30);
            this.cb_1.TabIndex = 2;
            this.cb_1.Text = "&Cerrar";
            this.cb_1.Font = new Font("Arial", 8.5F, FontStyle.Regular);
            this.cb_1.UseVisualStyleBackColor = true;

            // 
            // agregar controles al form
            // 
            this.Controls.Add(this.gb_borde);
            this.Controls.Add(this.p_logo);
            this.Controls.Add(this.st_nombre);
            this.Controls.Add(this.st_version);
            this.Controls.Add(this.st_copyright);
            this.Controls.Add(this.cb_1);

            ((System.ComponentModel.ISupportInitialize)(this.p_logo)).EndInit();
            this.ResumeLayout(false);
        }
    }
}