using System;
using System.Windows.Forms;

namespace Minotti.Views.Menues.Controls
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

            // PB: event open; F_Window_Center(This)
            this.Load += (_, __) => F_Window_Center(this);
        }

        // PB: F_Window_Center(This)
        // No asumo implementación: dejo el llamado como PB-style.
        // Si ya la tenés en otro lado, borrá este stub.
        private static void F_Window_Center(Form form)
        {
            // Centrado WinForms estándar
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        // PB: event clicked; Close(Parent)
        private void cb_1_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
