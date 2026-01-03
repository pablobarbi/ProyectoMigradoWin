using Minotti.Views.Basicos.Controls;
using System.ComponentModel;

namespace Minotti.Views.Reportes.Controls
{
    partial class w_reporte_detalle
    {
        private IContainer? components = null;

        protected uo_dw dw_1 = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            dw_1 = new uo_dw();
            dw_1.Name = "dw_1";
            dw_1.TabIndex = 0;

            this.Name = "w_reporte_detalle";
            this.Text = "w_reporte_detalle";

            this.Controls.Add(dw_1);
        }
    }
}