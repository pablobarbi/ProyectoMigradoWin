using System;
using System.Windows.Forms;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_seleccion_check.srw (window) desde w_seleccionar
    // Mantiene el nombre del tipo: w_seleccion_check
    public partial class w_seleccion_check : w_seleccionar
    {
        public w_seleccion_check()
        {
            InitializeComponent();
        }

        // Eventos PB definidos en el SRW (expuestos como métodos del mismo nombre)
        public virtual void ue_seleccionar() { /* implementa la selección */ }
        public virtual void ue_deseleccionar() { /* implementa la deselección */ }

        // Mapear clicks: en PB los picturebutton llaman Parent.Event Trigger ue_*()
        private void pb_seleccionar_Click(object? sender, EventArgs e) => ue_seleccionar();
        private void pb_deseleccionar_Click(object? sender, EventArgs e) => ue_deseleccionar();
    }
}
