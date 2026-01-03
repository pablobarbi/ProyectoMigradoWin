using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Minotti.Controls;

namespace Minotti.Views
{
    partial class w_system_error
    {
        private IContainer components = null;

        // Controles con los mismos nombres que en PB
        public uo_dw dw_error;
        public Button cb_imprimir;
        public Button cb_salir;
        public Button cb_continuar;

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
            this.dw_error = new uo_dw();
            this.cb_imprimir = new Button();
            this.cb_salir = new Button();
            this.cb_continuar = new Button();

            this.SuspendLayout();

            // dw_error
            this.dw_error.Name = "dw_error";
            this.dw_error.Location = new Point(12, 12);
            this.dw_error.Size = new Size(560, 280);
            this.dw_error.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // cb_imprimir
            this.cb_imprimir.Name = "cb_imprimir";
            this.cb_imprimir.Text = "Imprimir";
            this.cb_imprimir.AutoSize = true;
            this.cb_imprimir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.cb_imprimir.Location = new Point(12, 304);
            this.cb_imprimir.Click += new System.EventHandler(this.cb_imprimir_Click);

            // cb_salir
            this.cb_salir.Name = "cb_salir";
            this.cb_salir.Text = "Salir";
            this.cb_salir.AutoSize = true;
            this.cb_salir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.cb_salir.Location = new Point(416, 304);
            this.cb_salir.Click += new System.EventHandler(this.cb_salir_Click);

            // cb_continuar
            this.cb_continuar.Name = "cb_continuar";
            this.cb_continuar.Text = "Continuar";
            this.cb_continuar.AutoSize = true;
            this.cb_continuar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.cb_continuar.Location = new Point(504, 304);
            this.cb_continuar.Click += new System.EventHandler(this.cb_continuar_Click);

            // w_system_error
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 341);
            this.Controls.Add(this.dw_error);
            this.Controls.Add(this.cb_imprimir);
            this.Controls.Add(this.cb_salir);
            this.Controls.Add(this.cb_continuar);
            this.Name = "w_system_error";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_system_error";

            this.ResumeLayout(false);
        }
    }
}
