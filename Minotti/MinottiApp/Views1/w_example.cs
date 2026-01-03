using System;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migración de PowerBuilder: w_example.srw
    /// Controles portados 1:1 (nombres PB): lnk_1..lnk_7, lnk_mail, st_3, st_4, st_5, st_7, gb_2..gb_6, cb_1, cb_2.
    /// </summary>
    public partial class w_example : Form
    {
        public w_example()
        {
            InitializeComponent();
        }

        // Cerrar (equiv. a _Close en PB)
        private void cb_1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Botón auxiliar (_?)
        private void cb_2_Click(object? sender, EventArgs e)
        {
            // Lugar para lógica adicional si hace falta
        }
    }
}
