using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    /// <summary>
    /// PB:
    /// $PBExportComments$
    /// Clase usada para pasar el string de un campo y el texto del titulo del campo
    /// a la ventana w_carga_observaciones.
    /// </summary>
    public class cat_string : nonvisualobject
    {
        // === VARIABLES (type variables) ===

        // PB:
        // String que contiene el campo en la dw
        public string @string;

        // PB:
        // Longitud del String
        public int longitud;

        // PB:
        // Titulo del Campo en la Datawindow
        public string texto_titulo;

        // PB:
        // Codigo de Retorno de la Ventana
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
        public cat_string()
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
