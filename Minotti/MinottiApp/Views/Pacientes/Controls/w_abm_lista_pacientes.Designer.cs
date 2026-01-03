using Minotti.Views.Basicos.Controls;
using System.Windows.Forms;

namespace Minotti.Views.Pacientes.Controls
{
    partial class w_abm_lista_pacientes
    {
        private System.ComponentModel.IContainer components = null; 

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            //
            // w_abm_lista_pacientes
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "w_abm_lista_pacientes";
            this.Text = "w_abm_lista_pacientes";
            this.ResumeLayout(false);
        }
    }
}