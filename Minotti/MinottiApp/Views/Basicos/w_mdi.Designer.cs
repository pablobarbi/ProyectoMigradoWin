using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    partial class w_mdi
    {
        private System.ComponentModel.IContainer components = null;
        private MdiClient mdi_1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mdi_1 = new MdiClient();

            this.SuspendLayout();

            // 
            // mdi_1
            // 
            this.mdi_1.Dock = DockStyle.Fill;
            this.mdi_1.BackColor = SystemColors.AppWorkspace;

            // 
            // w_mdi
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = utils.PBColor.FromPB(1090519039);
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.mdi_1);
            this.IsMdiContainer = true;
            this.Name = "w_mdi";
            this.Text = "MDI";
            this.WindowState = FormWindowState.Maximized;

            this.ResumeLayout(false);
        }
    }
}