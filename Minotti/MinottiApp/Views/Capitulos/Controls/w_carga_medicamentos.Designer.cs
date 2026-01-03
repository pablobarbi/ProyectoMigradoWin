
using Minotti.Views.Basicos.Controls;

namespace Minotti.Views.Capitulos.Controls
{
    partial class w_carga_medicamentos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dw_buscar = new uo_dw();
            this.SuspendLayout();
            // 
            // dw_buscar
            // 
            this.dw_buscar.BringToFront();
            this.dw_buscar.Location = new System.Drawing.Point(165, 676);
            this.dw_buscar.Name = "dw_buscar";
            this.dw_buscar.Size = new System.Drawing.Size(1362, 164);
            this.dw_buscar.TabIndex = 10;
            // Si tu uo_dw tiene props para scrollbars:
            // this.dw_buscar.HScrollBar = false;
            // this.dw_buscar.VScrollBar = false;
            // 
            // w_carga_medicamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dw_buscar);
            this.Name = "w_carga_medicamentos";
            this.Text = "w_carga_medicamentos";
            this.ResumeLayout(false);
        }

        #endregion

        private uo_dw dw_buscar;
    }
}
