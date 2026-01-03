using System.ComponentModel;

namespace Minotti.Views.Reportes.Controls
{
    partial class w_reporte_vacio
    {
        private IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            // No hay controles nuevos: hereda dw_param y dw_reporte de w_reporte.
            this.Name = "w_reporte_vacio";
            this.Text = "w_reporte_vacio";
        }
    }
}