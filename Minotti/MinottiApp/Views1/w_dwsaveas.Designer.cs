
namespace Minotti
{
    partial class w_dwsaveas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label st_1;
        private System.Windows.Forms.Label st_2;
        private Minotti.uo_dw dw_sorted;
        private Minotti.uo_dw dw_sortcolumns;
        private System.Windows.Forms.Button cb_ok_;
        private System.Windows.Forms.Button cb_cancelar;

        protected override void Dispose(bool disposing)
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
            this.dw_sorted = new Minotti.uo_dw();
            this.dw_sortcolumns = new Minotti.uo_dw();
            this.cb_ok_ = new System.Windows.Forms.Button();
            this.cb_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // st_1
            // 
            this.st_1.Name = "st_1";
            this.st_1.Text = "Datos sin exportar";
            this.st_1.AutoSize = false;
            this.st_1.Location = new System.Drawing.Point(46, 20);
            this.st_1.Size = new System.Drawing.Size(690, 64);
            // 
            // st_2
            // 
            this.st_2.Name = "st_2";
            this.st_2.Text = "Datos a Exportar";
            this.st_2.AutoSize = false;
            this.st_2.Location = new System.Drawing.Point(782, 20);
            this.st_2.Size = new System.Drawing.Size(553, 64);
            // 
            // dw_sortcolumns (izquierda)
            // 
            this.dw_sortcolumns.Name = "dw_sortcolumns";
            this.dw_sortcolumns.Location = new System.Drawing.Point(41, 96);
            this.dw_sortcolumns.Size = new System.Drawing.Size(699, 460);
            this.dw_sortcolumns.TabIndex = 40;
            // 
            // dw_sorted (derecha)
            // 
            this.dw_sorted.Name = "dw_sorted";
            this.dw_sorted.Location = new System.Drawing.Point(777, 96);
            this.dw_sorted.Size = new System.Drawing.Size(699, 460);
            this.dw_sorted.TabIndex = 30;
            // 
            // cb_ok_
            // 
            this.cb_ok_.Name = "cb_ok_";
            this.cb_ok_.Text = "_OK";
            this.cb_ok_.Location = new System.Drawing.Point(1120, 580);
            this.cb_ok_.Size = new System.Drawing.Size(352, 84);
            this.cb_ok_.TabIndex = 20;
            this.cb_ok_.UseVisualStyleBackColor = true;
            this.AcceptButton = this.cb_ok_;
            // 
            // cb_cancelar
            // 
            this.cb_cancelar.Name = "cb_cancelar";
            this.cb_cancelar.Text = "_Cancelar";
            this.cb_cancelar.Location = new System.Drawing.Point(818, 724);
            this.cb_cancelar.Size = new System.Drawing.Size(329, 84);
            this.cb_cancelar.TabIndex = 10;
            this.cb_cancelar.Visible = false;
            this.cb_cancelar.UseVisualStyleBackColor = true;
            // 
            // w_dwsaveas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1541, 768);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.st_2);
            this.Controls.Add(this.dw_sortcolumns);
            this.Controls.Add(this.dw_sorted);
            this.Controls.Add(this.cb_ok_);
            this.Controls.Add(this.cb_cancelar);
            this.Name = "w_dwsaveas";
            this.Text = "w_dwsaveas";
            this.ResumeLayout(false);
        }
    }
}
