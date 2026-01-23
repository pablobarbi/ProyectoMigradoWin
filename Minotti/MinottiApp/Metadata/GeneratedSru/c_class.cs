using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    // PB: $PBExportComments$ Auxiliar class.
    public class c_class : nonvisualobject
    {
        // ==== CONSTRUCTOR (event constructor) ====
        public c_class()
        {
            // PB: TriggerEvent( this, "constructor" )
            constructor();
        }

        // ==== DESTRUCTOR (event destructor) ====
        public void destructor()
        {
            // PB: vacío
        }

        // ==== EVENT one_event ====
        // PB: event one_event ()
        protected void one_event()
        {
            // === VARIABLES (event variables) ===
            // PB: string ls_pointer
            string ls_pointer;

            // PB:
            // //ls_pointer = String( message.LongParm, "address" )
            // Comentado en PB → comentado en C#
            // ls_pointer = message.LongParm.ToString();

            // PB:
            // MessageBox( 'c_class.one_event()', message.StringParm )
            MessageBox.Show(
                MessagePB.StringParm,
                "c_class.one_event()",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==== PB EVENTS DISPATCH ====
        // PB: on c_class.create
        protected void constructor()
        {
            // PB: vacío
        }
    }
}