using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    partial class w_carga_observaciones
    {
        private System.ComponentModel.IContainer components = null;

        // PB controls
        private TextBox mle_campo;
        private Button cb_aceptar;
        private Button cb_cancelar;

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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mle_campo = new System.Windows.Forms.TextBox();
            this.cb_aceptar = new System.Windows.Forms.Button();
            this.cb_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mle_campo
            // 
            this.mle_campo.Multiline = true;
            this.mle_campo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mle_campo.Location = new System.Drawing.Point(20, 20);
            this.mle_campo.Name = "mle_campo";
            this.mle_campo.Size = new System.Drawing.Size(600, 250);
            this.mle_campo.TabIndex = 0;
            this.mle_campo.BackColor = System.Drawing.Color.White;
            this.mle_campo.Font = new System.Drawing.Font("Arial", 9F);
            // 
            // cb_aceptar
            // 
            this.cb_aceptar.Location = new System.Drawing.Point(20, 290);
            this.cb_aceptar.Name = "cb_aceptar";
            this.cb_aceptar.Size = new System.Drawing.Size(120, 35);
            this.cb_aceptar.TabIndex = 1;
            this.cb_aceptar.Text = "&Aceptar";
            this.cb_aceptar.UseVisualStyleBackColor = true;
            // 
            // cb_cancelar
            // 
            this.cb_cancelar.Location = new System.Drawing.Point(500, 290);
            this.cb_cancelar.Name = "cb_cancelar";
            this.cb_cancelar.Size = new System.Drawing.Size(120, 35);
            this.cb_cancelar.TabIndex = 2;
            this.cb_cancelar.Text = "&Cancelar";
            this.cb_cancelar.UseVisualStyleBackColor = true;
            this.cb_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // w_carga_observaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.cb_cancelar);
            this.Controls.Add(this.cb_aceptar);
            this.Controls.Add(this.mle_campo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.Name = "w_carga_observaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "w_carga_observaciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
