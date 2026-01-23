using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class cat_nivel : nonvisualobject
    {
        // === VARIABLES (type variables) ===

        // PB: Public:
        public string Titulo;
        public string Objeto;
        public string Parametros;
        public string Cierra; // PB: Indica si la ventana se cierra al abrir la siguiente ventana

        // ==== PUBLIC SUBROUTINE ====
        // PB: public subroutine uof_copiaren (ref cat_nivel copia)
        public void uof_copiaren(ref cat_nivel copia)
        {
            // PB:
            // Copia.Objeto = This.Objeto
            copia.Objeto = this.Objeto;

            // Copia.Parametros = This.Parametros
            copia.Parametros = this.Parametros;

            // Copia.Titulo = This.Titulo
            copia.Titulo = this.Titulo;
        }

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
        public cat_nivel()
        {
            // PB: TriggerEvent( this, "constructor" )
            constructor();
        }

        // ==== PB: on destroy ====
        public void destroy()
        {
            // PB: TriggerEvent( this, "destructor" )
            destructor();
        }
    }
}
