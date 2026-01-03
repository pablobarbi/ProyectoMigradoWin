using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views
{
    partial class w_seleccion_check
    {
        private IContainer components = null;

        // Controles con los mismos nombres que en PB
        public Button pb_seleccionar;   // picturebutton en PB
        public Button pb_deseleccionar; // picturebutton en PB

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
            this.pb_seleccionar = new Button();
            this.pb_deseleccionar = new Button();

            this.SuspendLayout();

            // pb_seleccionar
            this.pb_seleccionar.Name = "pb_seleccionar";
            this.pb_seleccionar.Text = "Seleccionar";
            this.pb_seleccionar.AutoSize = true;
            this.pb_seleccionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.pb_seleccionar.Location = new Point(this.ClientSize.Width - 200, this.ClientSize.Height - 44);
            this.pb_seleccionar.Click += new System.EventHandler(this.pb_seleccionar_Click);

            // pb_deseleccionar
            this.pb_deseleccionar.Name = "pb_deseleccionar";
            this.pb_deseleccionar.Text = "Deseleccionar";
            this.pb_deseleccionar.AutoSize = true;
            this.pb_deseleccionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.pb_deseleccionar.Location = new Point(this.ClientSize.Width - 100, this.ClientSize.Height - 44);
            this.pb_deseleccionar.Click += new System.EventHandler(this.pb_deseleccionar_Click);

            // w_seleccion_check
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(640, 400);
            this.Controls.Add(this.pb_deseleccionar);
            this.Controls.Add(this.pb_seleccionar);
            this.Name = "w_seleccion_check";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_seleccion_check";

            this.ResumeLayout(false);
        }
    }
}
