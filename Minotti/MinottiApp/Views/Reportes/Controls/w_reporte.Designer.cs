using Minotti.Views.Basicos.Controls;
using System.ComponentModel;

namespace Minotti.Views.Reportes.Controls
{
    partial class w_reporte
    {
        private IContainer? components = null;

        // Controles (mismos nombres que PB)
        protected uo_dw dw_param = null!;
        protected uo_dw dw_reporte = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            dw_param = new uo_dw();
            dw_reporte = new uo_dw();

            // dw_param
            dw_param.Name = "dw_param";
            dw_param.TabIndex = 0;

            // dw_reporte
            dw_reporte.Name = "dw_reporte";
            dw_reporte.TabIndex = 1;

            // Form
            this.Name = "w_reporte";
            this.Text = "w_reporte";

            this.Controls.Add(dw_param);
            this.Controls.Add(dw_reporte);
        }
    }
}