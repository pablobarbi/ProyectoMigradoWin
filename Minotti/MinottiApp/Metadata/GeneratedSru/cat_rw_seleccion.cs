using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class cat_rw_seleccion : nonvisualobject
    {
        // === VARIABLES (type variables) ===

        // PB:
        // /* Var usada para setear la forma en que salio de la ventana
        //     1  -- Se cerro aceptando
        //    -1  -- Se cancelo la seleccion */
        public int opcion = -1;

        // PB:
        // /* Estructura que contiene las n filas seleccionadas en la dw */
        public cat_s_det[] atr;

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
        public cat_rw_seleccion()
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
