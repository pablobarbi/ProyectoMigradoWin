using Minotti.UserObjects;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    partial class w_response
    {
        // pb_continuar pb_continuar
        // pb_cancelar pb_cancelar
        public  picturebutton pb_continuar;
        public picturebutton pb_cancelar;

        private void InitializeComponent()
        {
            // ==== pb_continuar ====
            pb_continuar = new picturebutton();
            pb_continuar.Name = "pb_continuar";
            pb_continuar.Location = new Point(284, 901);
            pb_continuar.Size = new Size(398, 105);
            pb_continuar.TabIndex = 20; // TabOrder=20
            pb_continuar.Text = "Continuar";
            pb_continuar.Font = new Font("Arial", 10f, FontStyle.Regular); // TextSize=-10 Weight=400
            pb_continuar.UseVisualStyleBackColor = true;
            pb_continuar.Click += pb_continuar_Clicked;

            // Default=true
            this.AcceptButton = pb_continuar;

            // ==== pb_cancelar ====
            pb_cancelar = new picturebutton();
            pb_cancelar.Name = "pb_cancelar";
            pb_cancelar.Location = new Point(1079, 901);
            pb_cancelar.Size = new Size(380, 105);
            pb_cancelar.TabIndex = 10; // TabOrder=10
            pb_cancelar.Text = "Cancelar";
            pb_cancelar.Font = new Font("Arial", 10f, FontStyle.Regular);
            pb_cancelar.UseVisualStyleBackColor = true;
            pb_cancelar.Click += pb_cancelar_Clicked;

            // Cancel=true
            this.CancelButton = pb_cancelar;

            // Form basics (PB response window)
            this.Controls.Add(pb_continuar);
            this.Controls.Add(pb_cancelar);
            this.Name = "w_response";
        }
    }
}
