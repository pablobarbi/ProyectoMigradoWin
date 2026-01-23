using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class cat_response_abm : nonvisualobject
    {
        // === VARIABLES (type variables) ===
        // datawindow que va hacer sharedata
        public uo_dw dw_1;

        // parametros para habir la nueva datawindow
        public string param;

        // Claves por si se va a agregar un nuevo registro
        public string[] claves;

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
        public cat_response_abm()
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
