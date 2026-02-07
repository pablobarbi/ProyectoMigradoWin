using Minotti.Metadata.GeneratedSru;
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
            // PB: downkey → WinForms: KeyDown
            this.KeyDown += uo_dw_key_KeyDown;
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

        // =========================================================
        // PB: event downkey; call super::downkey;
        // =========================================================
        private void uo_dw_key_KeyDown(object? sender, KeyEventArgs e)
        {
            // PB: If (key = KeyEnter!)
            if (e.KeyCode != Keys.Enter)
                return;

            // PB: If GetRow() > 0 Then Parent.Event Dynamic ue_dw_detalle (This)
            if (GetRow() > 0)
            {
                Parent?.TriggerEvent("ue_dw_detalle", this);

                // PB: Return 0 → consumir tecla
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
