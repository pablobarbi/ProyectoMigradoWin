using System;
using System.Windows.Forms;
using Minotti.Controls;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_system_error.srw
    // Herencia en PB: w_system_error from w_response
    public partial class w_system_error : w_response
    {
        public w_system_error()
        {
            InitializeComponent();
        }

        // ==== Eventos PB migrados ====
        // cb_continuar::clicked => Close(parent)
        private void cb_continuar_Click(object? sender, EventArgs e)
        {
            // En PB: Close(parent). Aquí cierra la ventana actual.
            this.Close();
        }

        // cb_salir::clicked => Halt Close (cierra aplicación)
        private void cb_salir_Click(object? sender, EventArgs e)
        {
            // Equivalente a HALT CLOSE: finalizar la aplicación.
            try { Application.Exit(); } catch { /* ignore */ }
        }

        // cb_imprimir::clicked => (stub) imprimir contenido de dw_error
        private void cb_imprimir_Click(object? sender, EventArgs e)
        {
            // Si tu control uo_dw implementa impresión, llamalo aquí.
            // dw_error.Print();
        }
    }
}
