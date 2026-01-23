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
        // ---------------------------------------------------------------------
        // PB: on uo_dw_key.create
        // ---------------------------------------------------------------------
        public override void create()
        {
            // PB: vacío
        }

        // ---------------------------------------------------------------------
        // PB: on uo_dw_key.destroy
        // ---------------------------------------------------------------------
        public override void destroy()
        {
            // PB: vacío
        }

        // ---------------------------------------------------------------------
        // PB: event downkey
        // ---------------------------------------------------------------------
        public override int downkey()
        {
            // PB: call super::downkey
            base.downkey();

            int rtn = 0;
            string estilo;

            /*
             * PB:
             * Si presione la tecla "+" o "ENTER" y tiene seteada la variable de ir al detalle
             *
             * keyflag = 0      No presiono ni SHIFT ni CTRL
             * keyflag = 1      Presiono SHIFT
             * keyflag = 2      Presiono CTRL
             * keyflag = 3      SHIFT + CTRL
             */

            // PB: If (key = KeyEnter!)
            if (key == KeyEnter)
            {
                // PB: Llama al evento detalle de la ventana que lo contiene
                if (GetRow() > 0)
                {
                    Parent?.EventDynamic("ue_dw_detalle", this);
                    return 0;
                }
            }

            return rtn;
        }
    }
}
