
using Minotti.Views.Basicos;
using System;

namespace Minotti.Views.Pbl.Views
{
    public partial class w_informacion : w_operacion
    {
        public w_informacion()
        {
            InitializeComponent();
        }

        // event clicked; Close(Parent)
        private void cb_1_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // event ue_optar; s_min.ancho = 30 ; s_min.largo = 30
        // (si en tu base w_operacion existe ue_optar, lo dejás ahí;
        //  acá no invento estructura s_min porque no la pasaste en C#)
    }
}