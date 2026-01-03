using System.ComponentModel;
using System.Windows.Forms;

namespace Minotti.Views.Abm.Controls
{
    partial class w_abm_detalle
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.SuspendLayout();

            // 
            // w_abm_detalle
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Name = "w_abm_detalle";
            this.Text = "w_abm_detalle"; // si en PB venía de w_operacion, podés quitarlo; no afecta lógica
            this.ResumeLayout(false);
        }
    }
}
