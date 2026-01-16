using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Minotti.Views.Pbl.Views
{
    partial class w_operacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controles visibles
        private Minotti.utils.datastore dw_param;

        /// <summary>
        /// Limpiar recursos
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        /// <summary>
        /// Método requerido para soporte del Diseñador.
        /// </summary>
        private void InitializeComponent()
        {
            this.dw_param = new Minotti.utils.datastore();
            this.SuspendLayout();






            // 
            // dw_param
            // 
            this.dw_param.Location = new System.Drawing.Point(12, 12);
            this.dw_param.Name = "dw_param";
            this.dw_param.Size = new System.Drawing.Size(940, 560);
            this.dw_param.TabIndex = 0;

            // 
            // w_operacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 584);
            this.Controls.Add(this.dw_param);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "w_operacion";
            this.Text = "w_operacion";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
