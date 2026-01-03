using Minotti.Views.Basicos.Controls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
 

namespace Minotti.Views.Basicos
{
    partial class w_carga
    {
        private System.ComponentModel.IContainer components = null;

        // PB: uo_dw dw_1
        private uo_dw _dw_1;

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this._dw_1 = new uo_dw();
            this.SuspendLayout();
            // 
            // _dw_1
            // 
            this._dw_1.BorderStyle = BorderStyle.Fixed3D;
            this._dw_1.Location = new System.Drawing.Point(20, 20);
            this._dw_1.Name = "_dw_1";
            this._dw_1.Size = new System.Drawing.Size(400, 200);
            this._dw_1.TabIndex = 0;
            // 
            // w_carga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this._dw_1);
            this.Name = "w_carga";
            this.Text = "Carga";
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Limpieza de recursos.
        /// </summary>
        protected  override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
