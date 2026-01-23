using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    /// <summary>
    /// PB:
    /// $PBExportComments$
    /// Clase con los atributos que requiere una ventana splash para desplegarse.
    /// </summary>
    public class cat_splash : cat_app
    {
        // === VARIABLES (type variables) ===

        // PB:
        // integer segundos
        public int segundos;

        // ==== CONSTRUCTOR (event constructor) ====
        public override void constructor()
        {
            // PB: sin lógica adicional
        }

        // ==== DESTRUCTOR (event destructor) ====
        public override void destructor()
        {
            // PB: sin lógica adicional
        }

        // ==== PB: on create ====
        public cat_splash()
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
