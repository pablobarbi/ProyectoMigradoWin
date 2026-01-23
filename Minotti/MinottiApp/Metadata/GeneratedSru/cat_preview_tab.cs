using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class cat_preview_tab : nonvisualobject
    {
        // === VARIABLES (type variables) ===

        /* 
           La ventana recibe el DS y los parametros 
           para hacerle el retrieve 
        */
        public string is_impresion;
        public string[] is_parametros;

        // ==== CONSTRUCTOR (event constructor) ====
        public override void constructor()
        {
            // PB: sin lógica
        }

        // ==== DESTRUCTOR (event destructor) ====
        public override void destructor()
        {
            // PB: sin lógica
        }

        // ==== PB: on create ====
        public cat_preview_tab()
        {
            // PB:
            // TriggerEvent( this, "constructor" )
            constructor();
        }

        // ==== PB: on destroy ====
        public void destroy()
        {
            // PB:
            // TriggerEvent( this, "destructor" )
            destructor();
        }
    }
}
