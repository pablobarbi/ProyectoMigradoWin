using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos 
{
    public partial class w_principal
    {
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelMicroHelp;
        private System.Windows.Forms.Label lblMicroHelp;


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



            this.statusStrip1 = new StatusStrip();
            this.toolStripStatusLabelMicroHelp = new ToolStripStatusLabel();

            this.statusStrip1.Items.Add(this.toolStripStatusLabelMicroHelp);
            this.toolStripStatusLabelMicroHelp.Text = "";

            this.Controls.Add(this.statusStrip1);


            this.lblMicroHelp = new System.Windows.Forms.Label();

            // 
            // lblMicroHelp
            // 
            this.lblMicroHelp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMicroHelp.Height = 22;
            this.lblMicroHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMicroHelp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblMicroHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMicroHelp.Padding = new Padding(6, 0, 0, 0);
            this.lblMicroHelp.Text = "";

            // 
            // w_principal
            // 
            this.Controls.Add(this.lblMicroHelp);



            this.ResumeLayout(false);
        }
    }
}