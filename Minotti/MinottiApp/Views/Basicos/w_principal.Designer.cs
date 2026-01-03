using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos 
{
    public partial class w_principal
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // w_principal
            // 
            // PB: integer x = 832, y = 356, width = 1993, height = 1204
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(832, 356);
            this.ClientSize = new Size(1993, 1204);

            // PB: boolean titlebar = true
            //     boolean controlmenu = true
            //     boolean minbox = true
            //     boolean maxbox = true
            //     boolean resizable = true
            this.FormBorderStyle = FormBorderStyle.Sizable; // resizable=true
            this.ControlBox = true;                         // controlmenu=true
            this.MinimizeBox = true;                        // minbox=true
            this.MaximizeBox = true;                        // maxbox=true

            // PB: long backcolor = 80269524
            this.BackColor = ColorTranslator.FromWin32(unchecked((int)80269524));

            this.Name = "w_principal";
            this.Text = string.Empty;   // en open se setea desde guo_app.App.DisplayName

            this.ResumeLayout(false);
        }
    }
}