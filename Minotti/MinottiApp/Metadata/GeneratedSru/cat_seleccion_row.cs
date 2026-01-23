using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    /// <summary>
    /// PB:
    /// $PBExportComments$
    /// Clase con los atributos de Seleccion de una fila en una Lista
    /// </summary>
    public class cat_seleccion_row : nonvisualobject
    {
        // === VARIABLES (type variables) ===

        // PB:
        // String dataobject
        public string dataobject;

        // PB:
        // String valor_columna
        public string valor_columna;

        // PB:
        // String tipo_columna
        public string tipo_columna;

        // PB:
        // String descripcion
        public string descripcion;

        // PB:
        // Integer valor_retorno = -1
        public int valor_retorno = -1;

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
        public cat_seleccion_row()
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
