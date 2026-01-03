using System;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migración de PowerBuilder: w_another_window.srw
    /// Ventana simple con un StaticText (st_1) y un CommandButton (cb_1).
    /// </summary>
    public partial class w_another_window : Form
    {
        public w_another_window()
        {
            InitializeComponent();
        }

        // Si en PB había lógica al cerrar, puede agregarse aquí
        private void cb_1_Click(object? sender, EventArgs e)
        {
            // PB tenía Cancel="true" y Default="true" en el botón, y texto "Close".
            // En WinForms cerramos la ventana.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
