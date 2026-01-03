using Minotti.Views.Basicos.Controls;
using MinottiApp.utils;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{
    // global type uo_dw_key from uo_dw
    public class uo_dw_key : uo_dw
    {
        public uo_dw_key() : base()
        {
            // PB: event downkey
            // En WinForms lo más cercano es KeyDown en el control (o en el grid interno).
            // Enganchamos el KeyDown del UserControl; si tu uo_dw tiene un grid interno,
            // idealmente uo_dw expone un evento o método para engancharlo allí.
            this.KeyDown += uo_dw_key_KeyDown;

            // Para que reciba teclas cuando está dentro (si aplica)
            this.TabStop = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.KeyDown -= uo_dw_key_KeyDown;
            }
            base.Dispose(disposing);
        }

        // =========================
        // PB: event downkey; call super::downkey;
        // =========================
        private void uo_dw_key_KeyDown(object? sender, KeyEventArgs e)
        {
            // call super::downkey;
            // Si tu uo_dw tiene override/handler propio, ya corre por su lado.
            // Acá implemento solo la parte extra del hijo.

            // PB:
            // If (key = KeyEnter!) Then
            if (e.KeyCode == Keys.Enter)
            {
                // If GetRow() > 0 Then Parent.Event Dynamic ue_dw_detalle (This)
                if (this.GetRow() > 0)
                {
                    var parent = this.Parent;
                    if (parent != null)
                    {
                        // PB: Parent.Event Dynamic ue_dw_detalle (This)
                        // Usamos tu helper existente
                        DynamicEventInvoker.Trigger(parent, "ue_dw_detalle", this);

                        // Return 0 (consume)
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        return;
                    }
                }
            }

            // en PB había variables rtn/estilo pero no se usan
        }
    }
}
