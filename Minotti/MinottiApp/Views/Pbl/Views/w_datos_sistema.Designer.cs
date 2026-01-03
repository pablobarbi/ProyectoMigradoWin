using System.Windows.Forms;

namespace Minotti.Views.Pbl.Views
{
    partial class w_datos_sistema
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox gb_borde;
        private Label st_nombre;
        private Label st_version;
        private Label st_copyright;
        private PictureBox p_logo;
        private Button cb_1;

        // Método que inicializa los componentes
        private void InitializeComponent()
        {
            this.gb_borde = new System.Windows.Forms.GroupBox();
            this.st_nombre = new System.Windows.Forms.Label();
            this.st_version = new System.Windows.Forms.Label();
            this.st_copyright = new System.Windows.Forms.Label();
            this.p_logo = new System.Windows.Forms.PictureBox();
            this.cb_1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.p_logo)).BeginInit();
            this.SuspendLayout();

            // 
            // gb_borde
            // 
            this.gb_borde.BackColor = System.Drawing.Color.FromArgb(81324524);
            this.gb_borde.Location = new System.Drawing.Point(37, 32);
            this.gb_borde.Size = new System.Drawing.Size(2254, 928);
            this.gb_borde.TabIndex = 0;
            this.gb_borde.TabStop = false;

            // 
            // st_nombre
            // 
            this.st_nombre.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.st_nombre.ForeColor = System.Drawing.Color.FromArgb(8388608);
            this.st_nombre.BackColor = System.Drawing.Color.FromArgb(81324524);
            this.st_nombre.Location = new System.Drawing.Point(155, 456);
            this.st_nombre.Size = new System.Drawing.Size(2016, 104);
            this.st_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.st_nombre.Text = "Nombre de la Aplicación";
            this.st_nombre.Enabled = false;

            // 
            // st_version
            // 
            this.st_version.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.st_version.ForeColor = System.Drawing.Color.FromArgb(8388608);
            this.st_version.BackColor = System.Drawing.Color.FromArgb(81324524);
            this.st_version.Location = new System.Drawing.Point(155, 564);
            this.st_version.Size = new System.Drawing.Size(2016, 88);
            this.st_version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.st_version.Text = "Versión";
            this.st_version.Enabled = false;

            // 
            // st_copyright
            // 
            this.st_copyright.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.st_copyright.ForeColor = System.Drawing.Color.FromArgb(8388608);
            this.st_copyright.BackColor = System.Drawing.Color.FromArgb(81324524);
            this.st_copyright.Location = new System.Drawing.Point(155, 868);
            this.st_copyright.Size = new System.Drawing.Size(2016, 72);
            this.st_copyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.st_copyright.Text = "Copyright";
            this.st_copyright.Enabled = false;

            // 
            // p_logo
            // 
            this.p_logo.Location = new System.Drawing.Point(87, 128);
            this.p_logo.Size = new System.Drawing.Size(576, 452);
            this.p_logo.SizeMode = PictureBoxSizeMode.StretchImage;

            // 
            // cb_1
            // 
            this.cb_1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.cb_1.Location = new System.Drawing.Point(2011, 980);
            this.cb_1.Size = new System.Drawing.Size(256, 108);
            this.cb_1.Text = "&Cerrar";
            this.cb_1.Click += new System.EventHandler(this.cb_1_Click);

            // 
            // w_datos_sistema
            // 
            this.ClientSize = new System.Drawing.Size(2368, 1232);
            this.Controls.Add(this.gb_borde);
            this.Controls.Add(this.st_nombre);
            this.Controls.Add(this.st_version);
            this.Controls.Add(this.st_copyright);
            this.Controls.Add(this.p_logo);
            this.Controls.Add(this.cb_1);
            this.Name = "w_datos_sistema";
            this.Text = "Datos del Sistema";
            this.Load += new System.EventHandler(this.w_datos_sistema_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_logo)).EndInit();
            this.ResumeLayout(false);
        }
    }
}