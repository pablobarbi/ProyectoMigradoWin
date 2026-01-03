using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views
{
    partial class w_response
    {
        private IContainer components = null;

        // Controles con los mismos nombres que en PB
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
            this.pb_continuar = new Button();
            this.pb_cancelar = new Button();

            this.SuspendLayout();

            // pb_continuar
            this.pb_continuar.Name = "pb_continuar";
            this.pb_continuar.Text = "Continuar";
            this.pb_continuar.AutoSize = true;
            this.pb_continuar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.pb_continuar.Location = new Point(this.ClientSize.Width - 180, this.ClientSize.Height - 44);
            this.pb_continuar.Click += new System.EventHandler(this.pb_continuar_Click);

            // pb_cancelar
            this.pb_cancelar.Name = "pb_cancelar";
            this.pb_cancelar.Text = "Cancelar";
            this.pb_cancelar.AutoSize = true;
            this.pb_cancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.pb_cancelar.Location = new Point(this.ClientSize.Width - 92, this.ClientSize.Height - 44);
            this.pb_cancelar.Click += new System.EventHandler(this.pb_cancelar_Click);

            // w_response
            this.AcceptButton = this.pb_continuar;
            this.CancelButton = this.pb_cancelar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 400);
            this.Controls.Add(this.pb_cancelar);
            this.Controls.Add(this.pb_continuar);
            this.Name = "w_response";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_response";

            this.ResumeLayout(false);
        }
    }
}
