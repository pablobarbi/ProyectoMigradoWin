using System;
using System.Windows.Forms;
namespace Minotti
{
    public partial class w_ver_reperto : Form
    {
        public bool ib_grabar { get; set; } = true;
        public w_ver_reperto(){ InitializeComponent(); }
        public void ue_abrir_transaccion(){ }
        public void ue_cerrar_transaccion()
        {
            if (this.ib_grabar)
            {
                // Commit + chequeo SQLCode en PB
            }
            if (!this.ib_grabar)
            {
                // RollBack en PB
            }
        }
    }
}