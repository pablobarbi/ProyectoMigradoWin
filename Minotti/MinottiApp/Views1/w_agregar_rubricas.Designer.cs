
namespace Minotti
{
    partial class w_agregar_rubricas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dw_1;

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
            this.dw_1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dw_1)).BeginInit();
            this.SuspendLayout();
            // 
            // dw_1
            // 
            this.dw_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dw_1.Location = new System.Drawing.Point(12, 12);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(760, 437);
            this.dw_1.TabIndex = 0;
            // 
            // w_agregar_rubricas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.dw_1);
            this.Name = "w_agregar_rubricas";
            this.Text = "w_agregar_rubricas";
            this.Load += new System.EventHandler(this.w_agregar_rubricas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dw_1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
