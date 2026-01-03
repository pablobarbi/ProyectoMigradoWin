using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Minotti.Controls
{
    partial class uo_seleccion
    {
        private IContainer components = null;
        public uo_dw dw_1;
        public uo_dw dw_2;
        public Button pb_agregar;
        public Button pb_eliminar;
        private FlowLayoutPanel panel_botones;

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
            dw_1 = new uo_dw();
            dw_2 = new uo_dw();
            pb_agregar = new Button();
            pb_eliminar = new Button();
            panel_botones = new FlowLayoutPanel();

            SuspendLayout();

            // dw_1
            dw_1.Name = "dw_1";
            dw_1.Size = new Size(350, 400);
            dw_1.Dock = DockStyle.Left;

            // dw_2
            dw_2.Name = "dw_2";
            dw_2.Size = new Size(350, 400);
            dw_2.Dock = DockStyle.Right;

            // panel_botones
            panel_botones.Name = "panel_botones";
            panel_botones.FlowDirection = FlowDirection.TopDown;
            panel_botones.Width = 80;
            panel_botones.Dock = DockStyle.Fill;
            panel_botones.Padding = new Padding(12, 12, 12, 12);

            // pb_agregar
            pb_agregar.Name = "pb_agregar";
            pb_agregar.Text = ">>";
            pb_agregar.AutoSize = true;
            pb_agregar.Margin = new Padding(12);
            pb_agregar.Click += (s, e) => ue_insertar();

            // pb_eliminar
            pb_eliminar.Name = "pb_eliminar";
            pb_eliminar.Text = "<<";
            pb_eliminar.AutoSize = true;
            pb_eliminar.Margin = new Padding(12);
            pb_eliminar.Click += (s, e) => ue_eliminar();

            panel_botones.Controls.Add(pb_agregar);
            panel_botones.Controls.Add(pb_eliminar);

            // uo_seleccion
            this.Name = "uo_seleccion";
            this.Size = new Size(800, 400);
            this.Controls.Add(panel_botones);
            this.Controls.Add(dw_2);
            this.Controls.Add(dw_1);

            ResumeLayout(false);
        }
    }
}
