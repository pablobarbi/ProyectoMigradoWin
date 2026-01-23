using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class cat_error_db : nonvisualobject
    {
        // === VARIABLES (type variables) ===

        // PB:
        // Utilizado cuando ocurre un error al grabar en la Base de Datos
        public int sqldbcode;        // PB: Nro de Error
        public string sqlerrtext;    // PB: Descripcion del Error
        public int UserErrorCode;    // PB: Codigo de error personalizado
        public string UserErrorText; // PB: Texto personalizado de error

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
    }
}
