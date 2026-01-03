using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    public partial class w_operacion
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // w_operacion
            // 
            // PB: integer width = 1966, integer height = 1180, resizable = false
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1966, 1180);

            // resizable = false  -> borde fijo
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;    // para que realmente no se pueda redimensionar

            this.Name = "w_operacion";
            this.Text = "w_operacion";

            // Necesario para captar el evento de teclado (ESC)
            this.KeyPreview = true;

            this.ResumeLayout(false);
        }
    }
}
