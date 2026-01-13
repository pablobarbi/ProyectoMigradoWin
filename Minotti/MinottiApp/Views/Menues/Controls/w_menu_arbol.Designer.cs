// w_menu_arbol.Designer.cs
// NET WinForms equivalente (sin custom controls). Mantengo nombres.
// OJO: asumo que w_menu ya existe como Form (o clase base WinForms equivalente).

using Minotti.utils;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;



namespace Minotti.Views.Menues.Controls
{
    partial class w_menu_arbol
    {
        private IContainer components = null;

        // PB: tv_1 tv_1
        public TreeView tv_1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();

            // ===== Form =====
            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(1792, 1664);
            this.Name = "w_menu_arbol";

            // ===== tv_1 (TreeView) =====
            this.tv_1 = new TreeView();
            this.tv_1.Name = "tv_1";
            this.tv_1.Location = new Point(32, 32);
            this.tv_1.Size = new Size(1682, 1496);
            this.tv_1.TabIndex = 1;

            // PB props aproximadas (sin inventar comportamiento)
            this.tv_1.HideSelection = false;
            // LinesAtRoot similar:
            this.tv_1.ShowLines = true;
            this.tv_1.ShowRootLines = true;
            this.tv_1.BorderStyle = BorderStyle.Fixed3D;
            this.tv_1.BackColor = utils.PBColor.FromPB(15793151);

            // ===== Add =====
            this.Controls.Add(this.tv_1);
        }
    }
}
