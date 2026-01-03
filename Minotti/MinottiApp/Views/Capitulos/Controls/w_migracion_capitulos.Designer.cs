
using Minotti.Views.Basicos.Controls;

namespace Minotti.Views.Capitulos.Controls
{

    partial class w_migracion_capitulos
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
            this.dw_1 = new uo_dw();
            this.dw_2 = new uo_dw();
            this.dw_3 = new uo_dw();
            this.SuspendLayout();
            // 
            // dw_1
            // 
            this.dw_1.Location = new System.Drawing.Point(41, 44);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(1751, 508);
            this.dw_1.TabIndex = 10;
            // 
            // dw_2
            // 
            this.dw_2.Location = new System.Drawing.Point(59, 596);
            this.dw_2.Name = "dw_2";
            this.dw_2.Size = new System.Drawing.Size(1751, 508);
            this.dw_2.TabIndex = 11;
            // 
            // dw_3
            // 
            this.dw_3.Location = new System.Drawing.Point(453, 940);
            this.dw_3.Name = "dw_3";
            this.dw_3.Size = new System.Drawing.Size(1751, 508);
            this.dw_3.TabIndex = 12;
            // 
            // w_migracion_capitulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3291, 1824);
            this.Controls.Add(this.dw_3);
            this.Controls.Add(this.dw_2);
            this.Controls.Add(this.dw_1);
            this.Name = "w_migracion_capitulos";
            this.Text = "w_migracion_capitulos";
            this.ResumeLayout(false);
        }

        #endregion

        private uo_dw dw_1;
        private uo_dw dw_2;
        private uo_dw dw_3;
    }
}
