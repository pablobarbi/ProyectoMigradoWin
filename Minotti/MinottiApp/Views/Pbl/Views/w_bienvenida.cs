using Minotti.Views.Basicos;
using System;

namespace Minotti.Views.Pbl.Views
{
    public partial class w_bienvenida : w_operacion
    {
        public w_bienvenida()
        {
            InitializeComponent();
        }

        // PB event: cb_1.clicked; Close(Parent)
        private void cb_1_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // PB event: ue_optar; s_min.ancho = 30 ; s_min.largo = 30
        // (La lógica de ue_optar vive en el ancestro w_operacion; acá no se agrega nada extra.)
    }
}