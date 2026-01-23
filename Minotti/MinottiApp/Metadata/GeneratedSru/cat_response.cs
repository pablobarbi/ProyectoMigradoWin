using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class cat_response : nonvisualobject
    {
        // === VARIABLES (type variables) ===
        // valor de retorno a la ventana que la llamo (1 eligio algo, -1 si no eligio nada)
        public int retorno;

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
        public cat_response()
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
