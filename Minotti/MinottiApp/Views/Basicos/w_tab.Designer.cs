using Minotti.Views.Basicos.Controls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Minotti.Views.Basicos
{
    public partial class w_tab
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tab_1 = new uo_tab();

            this.SuspendLayout();

            // 
            // w_tab
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 600);
            this.Name = "w_tab";
            this.Text = "w_tab";
            this.StartPosition = FormStartPosition.CenterParent;

            // PB: long backcolor = 12632256
            this.BackColor = ColorTranslator.FromWin32(12632256);

            // PB: string icon = "ventanas.ico"
            // (si usás Resources, cambialo por Properties.Resources.ventanas)
            // try { this.Icon = new Icon("ventanas.ico"); } catch { }

            // 
            // tab_1
            // 
            this.tab_1.Name = "tab_1";
            this.tab_1.Left = 20;
            this.tab_1.Top = 20;
            this.tab_1.Width = 760;
            this.tab_1.Height = 560;
            this.tab_1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // 
            // Controls
            // 
            this.Controls.Add(this.tab_1);

            this.ResumeLayout(false);
        }

        protected  override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
