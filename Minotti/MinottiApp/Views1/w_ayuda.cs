using System;
using System.Windows.Forms;
using Minotti.Controls;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_ayuda.srw (window) desde w_response
    // Mantiene el nombre del tipo: w_ayuda
    public partial class w_ayuda : Form
    {
        public w_ayuda()
        {
            InitializeComponent();
        }

        // ===== Eventos PB =====
        // event pb_continuar::clicked; call super::clicked; Close(Parent)
        private void pb_continuar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // Si existían otros eventos en w_response, se manejarán en esa clase cuando se migre.
    }
}
