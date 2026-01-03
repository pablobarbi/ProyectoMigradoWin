using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Minotti.Controls;

namespace Minotti.Views
{
    partial class w_dworder
    {
        private IContainer components = null;

        // Controles con los mismos nombres que en PB
        public Label st_5;
        public Label st_2;
        public Label st_1;
        public uo_dw dw_sorted;
        public uo_dw dw_sortcolumns;
        public Button cb_ok_;
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
            this.st_5 = new Label();
            this.st_2 = new Label();
            this.st_1 = new Label();
            this.dw_sorted = new uo_dw();
            this.dw_sortcolumns = new uo_dw();
            this.cb_ok_ = new Button();
            this.cb_cancelar = new Button();

            this.SuspendLayout();

            // st_1 (label sobre columnas disponibles)
            this.st_1.Name = "st_1";
            this.st_1.AutoSize = true;
            this.st_1.Text = "Columnas disponibles";
            this.st_1.Location = new Point(12, 12);

            // st_2 (label sobre orden actual)
            this.st_2.Name = "st_2";
            this.st_2.AutoSize = true;
            this.st_2.Text = "Orden actual";
            this.st_2.Location = new Point(312, 12);

            // st_5 (instrucciones)
            this.st_5.Name = "st_5";
            this.st_5.AutoSize = true;
            this.st_5.Text = "Use OK para aplicar el orden";
            this.st_5.Location = new Point(12, 330);

            // dw_sortcolumns
            this.dw_sortcolumns.Name = "dw_sortcolumns";
            this.dw_sortcolumns.Location = new Point(12, 36);
            this.dw_sortcolumns.Size = new Size(280, 280);
            this.dw_sortcolumns.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;

            // dw_sorted
            this.dw_sorted.Name = "dw_sorted";
            this.dw_sorted.Location = new Point(312, 36);
            this.dw_sorted.Size = new Size(280, 280);
            this.dw_sorted.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // cb_ok_
            this.cb_ok_.Name = "cb_ok_";
            this.cb_ok_.Text = "OK";
            this.cb_ok_.AutoSize = true;
            this.cb_ok_.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.cb_ok_.Location = new Point(416, 326);
            this.cb_ok_.Click += (s, e) => this.ue_ok();

            // cb_cancelar
            this.cb_cancelar.Name = "cb_cancelar";
            this.cb_cancelar.Text = "Cancelar";
            this.cb_cancelar.AutoSize = true;
            this.cb_cancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.cb_cancelar.Location = new Point(504, 326);
            this.cb_cancelar.Click += (s, e) => this.ue_cancelar();

            // w_dworder
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(604, 361);
            this.Controls.Add(this.cb_cancelar);
            this.Controls.Add(this.cb_ok_);
            this.Controls.Add(this.dw_sorted);
            this.Controls.Add(this.dw_sortcolumns);
            this.Controls.Add(this.st_5);
            this.Controls.Add(this.st_2);
            this.Controls.Add(this.st_1);
            this.Name = "w_dworder";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_dworder";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
