using Minotti.Views.Basicos.Controls;
using System.ComponentModel;

namespace Minotti.Views.Reportes.Controls
{
    partial class w_tab_reporte_header
    {
        private IContainer? components = null;

        // Controles PB
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

            this.Name = "w_tab_reporte_header";
            this.Text = "w_tab_reporte_header";

            this.Controls.Add(dw_1);
        }
    }
}