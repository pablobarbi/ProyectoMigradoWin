using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Minotti.Controls;

namespace Minotti.Views
{
    partial class w_ayuda
    {
        private IContainer components = null;
        public uo_dw dw_1;
        public Button pb_continuar;
        public Button pb_cancelar;

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
            this.dw_1 = new uo_dw();
            this.pb_continuar = new Button();
            this.pb_cancelar = new Button();

            this.SuspendLayout();

            // dw_1
            this.dw_1.Name = "dw_1";
            this.dw_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dw_1.Location = new Point(12, 12);
            this.dw_1.Size = new Size(560, 300);

            // pb_continuar
            this.pb_continuar.Name = "pb_continuar";
            this.pb_continuar.Text = "Continuar";
            this.pb_continuar.AutoSize = true;
            this.pb_continuar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.pb_continuar.Location = new Point(392, 320);
            this.pb_continuar.Click += new System.EventHandler(this.pb_continuar_Click);

            // pb_cancelar
            this.pb_cancelar.Name = "pb_cancelar";
            this.pb_cancelar.Text = "Cancelar";
            this.pb_cancelar.AutoSize = true;
            this.pb_cancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.pb_cancelar.Location = new Point(492, 320);
            this.pb_cancelar.DialogResult = DialogResult.Cancel;

            // w_ayuda
            this.AcceptButton = this.pb_continuar;
            this.CancelButton = this.pb_cancelar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 361);
            this.Controls.Add(this.pb_cancelar);
            this.Controls.Add(this.pb_continuar);
            this.Controls.Add(this.dw_1);
            this.Name = "w_ayuda";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_ayuda";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
