using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
 

namespace Minotti.Views.Basicos
{
    public partial class w_seleccion
    {
        private System.ComponentModel.IContainer components = null;

        // PB: uo_dw dw_1  (lo termino de crear en EnsureDwCreated, pero lo declaro acá)
        // ya está declarado en el otro partial (campo private uo_dw dw_1;)

        /// <inheritdoc />
        protected  override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.SuspendLayout();

            // 
            // w_seleccion (form)
            // En PB no se declararon Width/Height, pero se calculan en ue_acomodar_objetos.
            // Acá ponemos un tamaño base razonable.
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 600);
            this.Name = "w_seleccion";
            this.Text = "w_seleccion";

            // Posiciones iniciales de los botones; luego ue_acomodar_objetos recalcula todo
            pb_continuar.Location = new Point(151, 500);
            pb_cancelar.Location = new Point(450, 500);

            this.ResumeLayout(false);
        }
    }
}
