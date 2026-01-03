using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views
{
    partial class w_carga_observaciones
    {
        private IContainer components = null;
        public TextBox mle_campo;
        public Button cb_aceptar;
        public Button cb_cancelar;

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
            this.mle_campo = new TextBox();
            this.cb_aceptar = new Button();
            this.cb_cancelar = new Button();

            this.SuspendLayout();

            // mle_campo (multilineedit)
            this.mle_campo.Name = "mle_campo";
            this.mle_campo.Multiline = true;
            this.mle_campo.ScrollBars = ScrollBars.Vertical;
            this.mle_campo.Location = new Point(12, 12);
            this.mle_campo.Size = new Size(560, 280);
            this.mle_campo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // cb_aceptar
            this.cb_aceptar.Name = "cb_aceptar";
            this.cb_aceptar.Text = "Aceptar";
            this.cb_aceptar.AutoSize = true;
            this.cb_aceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.cb_aceptar.Location = new Point(392, 300);
            this.cb_aceptar.Click += new System.EventHandler(this.cb_aceptar_Click);

            // cb_cancelar
            this.cb_cancelar.Name = "cb_cancelar";
            this.cb_cancelar.Text = "Cancelar";
            this.cb_cancelar.AutoSize = true;
            this.cb_cancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.cb_cancelar.Location = new Point(492, 300);
            this.cb_cancelar.Click += new System.EventHandler(this.cb_cancelar_Click);

            // w_carga_observaciones
            this.AcceptButton = this.cb_aceptar;
            this.CancelButton = this.cb_cancelar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 341);
            this.Controls.Add(this.cb_cancelar);
            this.Controls.Add(this.cb_aceptar);
            this.Controls.Add(this.mle_campo);
            this.Name = "w_carga_observaciones";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_carga_observaciones";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
