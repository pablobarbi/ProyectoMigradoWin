using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Minotti.Controls
{
    partial class uo_tp_multilinea
    {
        private IContainer components = null;

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
            components = new Container();
            this.dw_1 = new uo_dw();
            this.pb_insertar = new Button();
            this.pb_borrar = new Button();

            // dw_1
            this.dw_1.Name = "dw_1";
            this.dw_1.Dock = DockStyle.Fill;

            // pb_insertar
            this.pb_insertar.Name = "pb_insertar";
            this.pb_insertar.Text = "Insertar";
            this.pb_insertar.AutoSize = true;
            this.pb_insertar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.pb_insertar.Location = new Point(this.Width - 180, 8);

            // pb_borrar
            this.pb_borrar.Name = "pb_borrar";
            this.pb_borrar.Text = "Borrar";
            this.pb_borrar.AutoSize = true;
            this.pb_borrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.pb_borrar.Location = new Point(this.Width - 90, 8);

            // uo_tp_multilinea (TabPage heredado)
            this.Name = "uo_tp_multilinea";
            this.Padding = new Padding(6);

            // Agregar controles (botones sobre la página, delante del dw)
            this.Controls.Add(this.pb_insertar);
            this.Controls.Add(this.pb_borrar);
            this.Controls.Add(this.dw_1);
        }
    }
}
