namespace Minotti
{
    partial class uo_tp_dw_reporte
    {
        private System.ComponentModel.IContainer components = null;

        // 'dw_1' según PB/WPF (DataWindow). En WinForms lo mapeamos a tu wrapper 'uo_dw'.
        private Minotti.uo_dw dw_1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dw_1 = new Minotti.uo_dw();
            this.SuspendLayout();
            // 
            // dw_1
            // 
            this.dw_1.Name = "dw_1";
            this.dw_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_1.TabIndex = 0;
            // 
            // uo_tp_dw_reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dw_1);
            this.Name = "uo_tp_dw_reporte";
            this.Size = new System.Drawing.Size(600, 400);
            this.ResumeLayout(false);
        }
    }
}
