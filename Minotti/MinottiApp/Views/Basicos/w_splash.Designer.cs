 
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    // Mismo partial de arriba
    partial class w_splash
    {
        private GroupBox gb_borde;
        private Label st_nombre;
        private Label st_version;
        private Label st_copyright;
        private PictureBox p_logo;
        private System.Windows.Forms.Timer timer1;

        private void InitializeComponent()
        {
            this.gb_borde = new GroupBox();
            this.st_nombre = new Label();
            this.st_version = new Label();
            this.st_copyright = new Label();
            this.p_logo = new PictureBox();
            this.timer1 = new System.Windows.Forms.Timer();

            ((System.ComponentModel.ISupportInitialize)(this.p_logo)).BeginInit();
            this.SuspendLayout();

            // ===== FORM =====
            this.BackColor = ColorTranslator.FromWin32(15793151);
            this.ClientSize = new Size(520, 320);
            this.Name = "w_splash";
            this.Text = "w_splash";

            // ===== BORDE =====
            this.gb_borde.BackColor = ColorTranslator.FromWin32(12632256);
            this.gb_borde.Location = new Point(10, 10);
            this.gb_borde.Size = new Size(500, 300);
            this.gb_borde.TabStop = false;

            // ===== LOGO =====
            this.p_logo.Location = new Point(20, 20);
            this.p_logo.Size = new Size(120, 90);
            this.p_logo.SizeMode = PictureBoxSizeMode.StretchImage;

            // ===== NOMBRE =====
            this.st_nombre.Location = new Point(160, 40);
            this.st_nombre.Size = new Size(330, 40);
            this.st_nombre.TextAlign = ContentAlignment.MiddleCenter;
            this.st_nombre.Font = new Font("Arial Narrow", 14F, FontStyle.Bold);
            this.st_nombre.BackColor = ColorTranslator.FromWin32(12632256);

            // ===== VERSION =====
            this.st_version.Location = new Point(160, 85);
            this.st_version.Size = new Size(330, 30);
            this.st_version.TextAlign = ContentAlignment.MiddleCenter;
            this.st_version.Font = new Font("Arial", 10F);
            this.st_version.BackColor = ColorTranslator.FromWin32(12632256);

            // ===== COPYRIGHT =====
            this.st_copyright.Location = new Point(20, 260);
            this.st_copyright.Size = new Size(470, 20);
            this.st_copyright.TextAlign = ContentAlignment.MiddleRight;
            this.st_copyright.Font = new Font("Arial", 8F);
            this.st_copyright.BackColor = ColorTranslator.FromWin32(12632256);

            // ===== TIMER =====
            this.timer1.Enabled = false;

            // ===== CONTROLES =====
            this.Controls.Add(this.p_logo);
            this.Controls.Add(this.st_nombre);
            this.Controls.Add(this.st_version);
            this.Controls.Add(this.st_copyright);
            this.Controls.Add(this.gb_borde);

            ((System.ComponentModel.ISupportInitialize)(this.p_logo)).EndInit();
            this.ResumeLayout(false);
        }
    }
}