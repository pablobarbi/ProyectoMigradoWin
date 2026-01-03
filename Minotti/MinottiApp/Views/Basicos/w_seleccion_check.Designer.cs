using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    public partial class w_seleccion_check
    {
        private System.ComponentModel.IContainer components = null;

        // PB: pb_seleccionar, pb_deseleccionar
        private PictureBox pb_seleccionar;
        private PictureBox pb_deseleccionar;

        /// <inheritdoc />
        public int MyProperty { get; set; }
       protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.pb_seleccionar = new PictureBox();
            this.pb_deseleccionar = new PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.pb_seleccionar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_deseleccionar)).BeginInit();
            this.SuspendLayout();

            // 
            // w_seleccion_check
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 600);
            this.Name = "w_seleccion_check";
            this.Text = "w_seleccion_check";

            // Posiciones iniciales, luego ue_acomodar_objetos recalcula todo
            pb_continuar.Location = new Point(100, 500);
            pb_cancelar.Location = new Point(300, 500);

            // 
            // pb_seleccionar
            // 
            this.pb_seleccionar.Name = "pb_seleccionar";
            this.pb_seleccionar.Size = new Size(120, 40);
            this.pb_seleccionar.Location = new Point(500, 500);
            this.pb_seleccionar.TabStop = false;
            // Podés asignar imagen si querés: this.pb_seleccionar.Image = ...

            // 
            // pb_deseleccionar
            // 
            this.pb_deseleccionar.Name = "pb_deseleccionar";
            this.pb_deseleccionar.Size = new Size(120, 40);
            this.pb_deseleccionar.Location = new Point(640, 500);
            this.pb_deseleccionar.TabStop = false;

            // 
            // Controls
            // 
            this.Controls.Add(this.pb_seleccionar);
            this.Controls.Add(this.pb_deseleccionar);

            ((System.ComponentModel.ISupportInitialize)(this.pb_seleccionar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_deseleccionar)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
