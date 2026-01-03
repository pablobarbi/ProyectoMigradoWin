using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Minotti.Controls;

namespace Minotti.Views
{
    partial class w_seleccion_fila_dddw
    {
        private IContainer components = null;

        // Controles con los mismos nombres que en PB
        public uo_dw dw_seleccion;
        public Button cb_cancelar;
        public Button cb_ok;
        public uo_dw dw_buscar;

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
            this.dw_seleccion = new uo_dw();
            this.cb_cancelar = new Button();
            this.cb_ok = new Button();
            this.dw_buscar = new uo_dw();

            this.SuspendLayout();

            // dw_buscar (arriba, una fila para filtrar/buscar)
            this.dw_buscar.Name = "dw_buscar";
            this.dw_buscar.Location = new Point(12, 12);
            this.dw_buscar.Size = new Size(560, 60);
            this.dw_buscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // dw_seleccion (listado principal)
            this.dw_seleccion.Name = "dw_seleccion";
            this.dw_seleccion.Location = new Point(12, 84);
            this.dw_seleccion.Size = new Size(560, 260);
            this.dw_seleccion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dw_seleccion.DoubleClick += new System.EventHandler(this.dw_seleccion_DoubleClick);

            // cb_ok
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Text = "OK";
            this.cb_ok.AutoSize = true;
            this.cb_ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.cb_ok.Location = new Point(396, 356);
            this.cb_ok.Click += new System.EventHandler(this.cb_ok_Click);

            // cb_cancelar
            this.cb_cancelar.Name = "cb_cancelar";
            this.cb_cancelar.Text = "Cancelar";
            this.cb_cancelar.AutoSize = true;
            this.cb_cancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.cb_cancelar.Location = new Point(492, 356);
            this.cb_cancelar.Click += new System.EventHandler(this.cb_cancelar_Click);

            // w_seleccion_fila_dddw
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 401);
            this.Controls.Add(this.dw_buscar);
            this.Controls.Add(this.dw_seleccion);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.cb_cancelar);
            this.Name = "w_seleccion_fila_dddw";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_seleccion_fila_dddw";

            this.ResumeLayout(false);
        }
    }
}
