using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class cat_return : nonvisualobject
    {
        // === VARIABLES (type variables) ===

        // PB:
        // /* Variables de Retorno de diferentes tipos */
        public bool rtn_boolean;
        public int rtn_integer;

        // PB:
        // /* Mensaje en el caso de que la funcion devuelva un error */
        public string mensaje_error;

        // PB:
        // /* Mensaje Warning */
        public string warning;

        // PB:
        // /* En el caso de que ocurra un error se devolverá en
        //    esta variable el codigo de error */
        public string codigo_error;

        // PB:
        // /* Variable para setear otros valores */
        public string rtn_string;

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
        public cat_return()
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
