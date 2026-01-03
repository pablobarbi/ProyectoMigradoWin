using System.ComponentModel;
using System.Windows.Forms;

namespace Minotti.Controls
{
    partial class uo_dw_filtros
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            // No agrega controles adicionales; hereda UI de uo_dw
            this.Name = "uo_dw_filtros";
        }
    }
}
