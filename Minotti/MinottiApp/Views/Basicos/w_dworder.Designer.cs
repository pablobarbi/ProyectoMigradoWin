using Minotti.Views.Basicos.Controls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
 

namespace Minotti.Views.Basicos
{
    public partial class w_dworder
    {
        private System.ComponentModel.IContainer components = null;

        // Controles (mismos nombres PB)
        private Label st_5;
        private Label st_2;
        private Label st_1;
        private uo_dw dw_sorted;
        private uo_dw dw_sortcolumns;
        private Button cb_ok_;
        private Button cb_cancelar;

        protected  override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.st_5 = new System.Windows.Forms.Label();
            this.st_2 = new System.Windows.Forms.Label();
            this.st_1 = new System.Windows.Forms.Label();
            this.dw_sorted = new uo_dw();
            this.dw_sortcolumns = new uo_dw();
            this.cb_ok_ = new System.Windows.Forms.Button();
            this.cb_cancelar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // w_dworder (form)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Ordenar...";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(0x4C, 0x80, 0x00); // 79741120 aproximado

            // 
            // st_1  "Columnas a ordenar"
            // 
            this.st_1.AutoSize = false;
            this.st_1.Location = new Point(30, 15);
            this.st_1.Size = new Size(260, 25);
            this.st_1.Text = "Columnas a ordenar";
            this.st_1.TextAlign = ContentAlignment.MiddleLeft;
            this.st_1.BackColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.st_1.ForeColor = Color.FromArgb(0x80, 0x00, 0x00);
            this.st_1.Font = new Font("MS Sans Serif", 8F, FontStyle.Bold);

            // 
            // st_2  "Ordenar por"
            // 
            this.st_2.AutoSize = false;
            this.st_2.Location = new Point(320, 15);
            this.st_2.Size = new Size(180, 25);
            this.st_2.Text = "Ordenar por";
            this.st_2.TextAlign = ContentAlignment.MiddleLeft;
            this.st_2.BackColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.st_2.ForeColor = Color.FromArgb(0x80, 0x80, 0x80);
            this.st_2.Font = new Font("MS Sans Serif", 8F, FontStyle.Bold);

            // 
            // st_5  "Asc"
            // 
            this.st_5.AutoSize = false;
            this.st_5.Location = new Point(620, 15);
            this.st_5.Size = new Size(60, 25);
            this.st_5.Text = "Asc";
            this.st_5.TextAlign = ContentAlignment.MiddleRight;
            this.st_5.BackColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.st_5.ForeColor = Color.FromArgb(0x80, 0x80, 0x80);
            this.st_5.Font = new Font("MS Sans Serif", 8F, FontStyle.Bold);

            // 
            // dw_sortcolumns (izquierda)
            // 
            this.dw_sortcolumns.Location = new Point(30, 50);
            this.dw_sortcolumns.Size = new Size(300, 320);
            this.dw_sortcolumns.BorderStyle = BorderStyle.Fixed3D;
            this.dw_sortcolumns.Name = "dw_sortcolumns";
            this.dw_sortcolumns.TabIndex = 10;

            // 
            // dw_sorted (derecha)
            // 
            this.dw_sorted.Location = new Point(350, 50);
            this.dw_sorted.Size = new Size(400, 320);
            this.dw_sorted.BorderStyle = BorderStyle.Fixed3D;
            this.dw_sorted.Name = "dw_sorted";
            this.dw_sorted.TabIndex = 20;

            // 
            // cb_ok_
            // 
            this.cb_ok_.Location = new Point(380, 390);
            this.cb_ok_.Size = new Size(120, 30);
            this.cb_ok_.Text = "&OK";
            this.cb_ok_.TabIndex = 30;
            this.cb_ok_.Font = new Font("MS Sans Serif", 8F, FontStyle.Bold);
            this.cb_ok_.UseVisualStyleBackColor = true;

            // 
            // cb_cancelar
            // 
            this.cb_cancelar.Location = new Point(520, 390);
            this.cb_cancelar.Size = new Size(120, 30);
            this.cb_cancelar.Text = "&Cancelar";
            this.cb_cancelar.TabIndex = 40;
            this.cb_cancelar.Font = new Font("MS Sans Serif", 8F, FontStyle.Regular);
            this.cb_cancelar.UseVisualStyleBackColor = true;

            // 
            // add controls
            // 
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.st_2);
            this.Controls.Add(this.st_5);
            this.Controls.Add(this.dw_sortcolumns);
            this.Controls.Add(this.dw_sorted);
            this.Controls.Add(this.cb_ok_);
            this.Controls.Add(this.cb_cancelar);

            this.ResumeLayout(false);
        }
    }
}
