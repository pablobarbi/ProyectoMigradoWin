using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti
{
    partial class uo_dw_cros
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary> 
        /// Método requerido para soporte del Diseñador.
        /// No modifiques el contenido con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // uo_dw_cros
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Name = "uo_dw_cros";
            // PBWidth = 690 en el XAML; uso eso como ancho aproximado.
            this.Size = new Size(690, 400);
            this.TabIndex = 0;
            this.ResumeLayout(false);
        }

        #endregion
    }
}
