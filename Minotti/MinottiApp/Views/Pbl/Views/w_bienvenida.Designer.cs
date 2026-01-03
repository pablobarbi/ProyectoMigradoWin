using Minotti.utils;
using System.Windows.Forms;

namespace Minotti.Views.Pbl.Views
{
    partial class w_bienvenida
    {
        private System.ComponentModel.IContainer components = null;

        private Label st_5;
        private Label st_4;
        private Label st_3;
        private Label st_2;
        private Label st_1;
        private PictureBox p_1;
        private GroupBox gb_1;
        private Button cb_1;

        protected  override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.st_5 = new System.Windows.Forms.Label();
            this.st_4 = new System.Windows.Forms.Label();
            this.st_3 = new System.Windows.Forms.Label();
            this.st_2 = new System.Windows.Forms.Label();
            this.st_1 = new System.Windows.Forms.Label();
            this.p_1 = new System.Windows.Forms.PictureBox();
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.cb_1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.p_1)).BeginInit();
            this.SuspendLayout();
            // 
            // w_bienvenida
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(3579, 1360);
            this.Name = "w_bienvenida";
            // 
            // st_5
            // 
            this.st_5.Location = new System.Drawing.Point(2642, 708);
            this.st_5.Name = "st_5";
            this.st_5.Size = new System.Drawing.Size(818, 64);
            this.st_5.TabIndex = 0;
            this.st_5.Text = "Prof. Dr. Angel Oscar Minotti";
            this.st_5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.st_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.st_5.BackColor = System.Drawing.SystemColors.Control;
            // 
            // st_4
            // 
            this.st_4.Location = new System.Drawing.Point(1536, 604);
            this.st_4.Name = "st_4";
            this.st_4.Size = new System.Drawing.Size(1925, 64);
            this.st_4.TabIndex = 1;
            this.st_4.Text = "Atentamente, ";
            this.st_4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.st_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.st_4.BackColor = System.Drawing.SystemColors.Control;
            // 
            // st_3
            // 
            this.st_3.Location = new System.Drawing.Point(1536, 500);
            this.st_3.Name = "st_3";
            this.st_3.Size = new System.Drawing.Size(1925, 64);
            this.st_3.TabIndex = 2;
            this.st_3.Text = "en su manejo. !Que le sea tan útil y exitoso como a mi!";
            this.st_3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.st_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.st_3.BackColor = System.Drawing.SystemColors.Control;
            // 
            // st_2
            // 
            this.st_2.Location = new System.Drawing.Point(1536, 396);
            this.st_2.Name = "st_2";
            this.st_2.Size = new System.Drawing.Size(1915, 64);
            this.st_2.TabIndex = 3;
            this.st_2.Text = "Encontrará un producto inigualable en su calidad científica y facilidad";
            this.st_2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.st_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.st_2.BackColor = System.Drawing.SystemColors.Control;
            // 
            // st_1
            // 
            this.st_1.Location = new System.Drawing.Point(1536, 292);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(1925, 64);
            this.st_1.TabIndex = 4;
            this.st_1.Text = "Felicitaciones por la adquisición de Minotti 2024 Plus para Windows.";
            this.st_1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.st_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.st_1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // p_1
            // 
            this.p_1.Location = new System.Drawing.Point(55, 72);
            this.p_1.Name = "p_1";
            this.p_1.Size = new System.Drawing.Size(1454, 1096);
            this.p_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p_1.TabIndex = 5;
            this.p_1.TabStop = false; 
            this.p_1.ImageLocation = FileUtils.GetAppFile("Pictures", "2_256.BMP");
            // PowerBuilder: picturename = "2_256.BMP"
            // (La carga del archivo de imagen queda a cargo del proyecto/recursos.)
            // 
            // gb_1
            // 
            this.gb_1.Location = new System.Drawing.Point(23, 24);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(3479, 1212);
            this.gb_1.TabIndex = 6;
            this.gb_1.TabStop = false;
            // 
            // cb_1
            // 
            this.cb_1.Location = new System.Drawing.Point(3136, 1036);
            this.cb_1.Name = "cb_1";
            this.cb_1.Size = new System.Drawing.Size(256, 108);
            this.cb_1.TabIndex = 7;
            this.cb_1.Text = "&Cerrar";
            this.cb_1.UseVisualStyleBackColor = true;
            this.cb_1.Click += new System.EventHandler(this.cb_1_Click);
            // 
            // Controls
            // 
            this.Controls.Add(this.cb_1);
            this.Controls.Add(this.gb_1);
            this.Controls.Add(this.p_1);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.st_2);
            this.Controls.Add(this.st_3);
            this.Controls.Add(this.st_4);
            this.Controls.Add(this.st_5);
            ((System.ComponentModel.ISupportInitialize)(this.p_1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}