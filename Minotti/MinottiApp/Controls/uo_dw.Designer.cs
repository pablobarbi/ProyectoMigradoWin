using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Minotti.Controls
{
    partial class uo_dw
    {
        private IContainer components = null;
        public DataGridView grid;

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
            grid = new DataGridView();

            SuspendLayout();
            // grid
            grid.Name = "grid";
            grid.Dock = DockStyle.Fill;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // uo_dw
            this.Name = "uo_dw";
            this.Size = new Size(600, 400);
            this.Controls.Add(grid);
            ResumeLayout(false);
        }
    }
}
