// -----------------------------------------------------------------------------
// AUTO-MIGRADO desde PowerBuilder (.sru)
// Origen: uo_dw_key
// -----------------------------------------------------------------------------

#nullable enable
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Minotti.Metadata.GeneratedSru
{
    /// <summary>
    /// PB: uo_dw_key
    /// Hereda de uo_dw.
    /// </summary>
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
