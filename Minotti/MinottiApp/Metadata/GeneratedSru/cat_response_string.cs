using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class cat_response_string : cat_response
    {
        // === VARIABLES (type variables) ===
        // PB:
        // Public:
        // string cadena // cadena que devuelve la ventana response
        public string cadena;

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
        public cat_response_string()
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
