using System;
using System.Windows.Forms;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_response.srw (window) desde w_principal
    // Mantiene el nombre del tipo: w_response
    public partial class w_response : w_principal
    {
        public w_response()
        {
            InitializeComponent();
        }

        // Eventos PB expuestos como métodos virtuales con el MISMO nombre
        public virtual void ue_continuar() { /* lo sobreescriben las hijas */ }
        public virtual void ue_cancelar()  { this.Close(); }

        // En PB existe ue_acomodar_objetos(); lo exponemos para herencias
        public override void ue_acomodar_objetos()
        {
            // Con Anchor ya se reacomodan; dejamos stub para hijas que necesiten lógica extra
        }

        // Mapear clicks de los botones base hacia los eventos PB
        private void pb_continuar_Click(object? sender, EventArgs e) => ue_continuar();
        private void pb_cancelar_Click(object? sender, EventArgs e)  => ue_cancelar();
    }
}
