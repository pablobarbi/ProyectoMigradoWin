using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class cat_columna : nonvisualobject
    {
        // === VARIABLES (type variables) ===
        // PB: Public:
        public string Nombre = "";
        public string Titulo = "";
        public string Tipo = "";
        public int TabOrder;
        public bool Filtro;
        public bool Requerido;
        public string Estilo = "";
        public string objeto_seleccion = "";
        public string Operacion = "";
        public string Nivel_operacion = "";

        // ==== PUBLIC SUBROUTINES ====

        // PB: public subroutine uof_copiaren (ref cat_operacion copia)
        public void uof_copiaren(ref cat_operacion copia)
        {
            // PB:
            // Copia.Operacion = This.Operacion
            // Copia.Objeto = This.Objeto
            // Copia.Parametro = This.Parametro
            // Copia.Titulo = This.Titulo
            // Copia.Alta = This.Alta
            // Copia.Modificacion = This.Modificacion
            // Copia.Baja = This.Baja
            //
            // (comentado en PB → comentado en C#)
        }

        // ==== CONSTRUCTOR (event constructor) ====
        public override void constructor()
        {
            // PB: TriggerEvent( this, "constructor" )
            // sin lógica
        }

        // ==== DESTRUCTOR (event destructor) ====
        public override void destructor()
        {
            // PB: sin lógica
        }
    }
}
