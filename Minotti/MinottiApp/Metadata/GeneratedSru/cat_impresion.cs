using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class cat_impresion : nonvisualobject
    {
        // === VARIABLES (type variables) ===

        // PB:
        // Usado para pasar los parametros a la ventana de Impresion de Actas, etc..
        public uo_ds ids_impresion;                 // PB: Datastore que contiene el reporte a imprimir.
        public int ii_cantidad_impresiones = 0;     // PB: Cantidad de copias

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
        public cat_impresion()
        {
            // PB: call super::create
            base.constructor();

            // PB: TriggerEvent(this, "constructor")
            constructor();
        }

        // ==== PB: on destroy ====
        public void destroy()
        {
            // PB: TriggerEvent(this, "destructor")
            destructor();

            // PB: call super::destroy
            base.destructor();
        }
    }
}
