using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views
{
    partial class w_mdi
    {
        private IContainer components = null;

        // Controles con los mismos nombres que en PB
        public MdiClient mdi_1;    // mdiclient dentro de w_mdi
        public MenuStrip m_mdi;    // menú principal cuyo nombre coincide con 'menuname'

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
            this.components = new Container();
            this.m_mdi = new MenuStrip();
            this.mdi_1 = new MdiClient();

            this.SuspendLayout();

            // m_mdi (MenuStrip principal)
            this.m_mdi.Name = "m_mdi";
            this.m_mdi.Location = new Point(0, 0);
            this.m_mdi.Size = new Size(800, 24);

            // mdi_1 (área cliente MDI)
            this.mdi_1.Name = "mdi_1";
            this.mdi_1.BackColor = SystemColors.AppWorkspace;
            this.mdi_1.Dock = DockStyle.Fill;
            this.mdi_1.Location = new Point(0, 24);
            this.mdi_1.TabIndex = 0;

            // w_mdi
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 600);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.m_mdi;
            this.Controls.Add(this.mdi_1);
            this.Controls.Add(this.m_mdi);
            this.Name = "w_mdi";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "w_mdi";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
