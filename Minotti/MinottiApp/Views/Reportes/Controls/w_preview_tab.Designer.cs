// w_preview_tab.Designer.cs
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Minotti.Views.Reportes.Controls
{
    partial class w_preview_tab
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

            // Overrides de controles heredados (PB "within w_preview_tab")
            // pb_1: textsize=-9 weight=700 facename="Arial"
            this.pb_1.Font = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);

            // dw_1: width=1975 height=828
            this.dw_1.Size = new Size(1975, 828);

            // Window flag
            this.Name = "w_preview_tab";
        }
    }
}