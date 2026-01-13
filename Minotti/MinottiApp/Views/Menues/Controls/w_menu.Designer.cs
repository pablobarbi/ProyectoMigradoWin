using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Minotti.Views.Menues.Controls
    {
    partial class w_menu
    {
        private IContainer components = null;

        private void InitializeComponent()
        {
            this.components = new Container();

            // ================= FORM =================
            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(800, 600); // luego se ajusta dinámicamente
            this.Name = "w_menu";
            this.Text = "Menú General de Operaciones";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }
    }
}

 
