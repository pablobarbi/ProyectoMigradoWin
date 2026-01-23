using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    /// <summary>
    /// PB:
    /// $PBExportComments$
    /// Clase con datos de la ventana
    /// </summary>
    public class cat_tamaño : nonvisualobject
    {
        // === VARIABLES (type variables) ===

        public int largo;
        public int ancho;
        public int borde;

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

        // ==== PB: public subroutine uof_copiaren (ref cat_tamaño copia) ====
        public void uof_copiaren(ref cat_tamaño copia)
        {
            // PB:
            // Copia.largo = This.largo
            // Copia.ancho = This.ancho
            // Copia.borde = This.borde

            copia.largo = this.largo;
            copia.ancho = this.ancho;
            copia.borde = this.borde;
        }

        // ==== PB: on create ====
        public cat_tamaño()
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
