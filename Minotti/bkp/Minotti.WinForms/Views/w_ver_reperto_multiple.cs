using System;
using System.Windows.Forms;
namespace Minotti
{
    public partial class w_ver_reperto_multiple : Form
    {
        public bool ib_grabar { get; set; } = true;
        public w_ver_reperto_multiple(){ InitializeComponent(); }
        public void ue_abrir_transaccion(){ }
        public void ue_cerrar_transaccion()
        {
            if (this.ib_grabar)
            {
                MessageBox.Show("Los datos se grabaron correctamente.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (!this.ib_grabar)
            {
                // RollBack en PB
            }
        }
    }
}