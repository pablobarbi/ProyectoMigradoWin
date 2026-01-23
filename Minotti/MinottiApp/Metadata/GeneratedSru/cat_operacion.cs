using Minotti.Views.Basicos;
using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class cat_operacion : nonvisualobject
    {
        // === VARIABLES (type variables) ===

        /* Datos generales de la operación */
        public string Modulo;
        public string Operacion;
        public string Nombre;
        public string Descripcion;

        /* Datos para cada nivel */
        public cat_nivel[] at_nvl;

        /* Parámetros para cada ventana que se abre */
        public bool Alta;
        public bool Modificacion;
        public bool Baja;
        public int Orden;
        public string[] s_det;   /* Parametros que pasa la ventana (valores de los campos que son clave en la dw */
        public string Accion;    /* Indica con qué botón de la barra de menú se abrió la ventana */
        public w_sheet w_anterior;

        // ==== PUBLIC SUBROUTINES / FUNCTIONS ====

        // PB: public subroutine uof_copiaren (ref cat_operacion copia)
        public void uof_copiaren(ref cat_operacion copia)
        {
            // PB:
            // Copia.Modulo = This.Modulo
            copia.Modulo = this.Modulo;

            // Copia.Operacion = This.Operacion
            copia.Operacion = this.Operacion;

            // Copia.Nombre = This.Nombre
            copia.Nombre = this.Nombre;

            // Copia.at_nvl = This.at_nvl
            copia.at_nvl = this.at_nvl;

            // Copia.w_anterior = This.w_anterior
            copia.w_anterior = this.w_anterior;

            // Copia.Orden = This.Orden
            copia.Orden = this.Orden;

            // Copia.Alta = This.Alta
            copia.Alta = this.Alta;

            // Copia.Modificacion = This.Modificacion
            copia.Modificacion = this.Modificacion;

            // Copia.Baja = This.Baja
            copia.Baja = this.Baja;

            // Copia.Accion = This.Accion
            copia.Accion = this.Accion;

            /* PB: No copia el arreglo de argumentos */
        }

        // PB: public function string uof_getparametros (integer nivel)
        public string uof_getparametros(int nivel)
        {
            return this.at_nvl[nivel].Parametros;
        }

        // PB: public function string uof_getparametros ()
        public string uof_getparametros()
        {
            return uof_getparametros(this.Orden);
        }

        // PB: public function string uof_gettitulo (integer nivel)
        public string uof_gettitulo(int nivel)
        {
            return this.at_nvl[nivel].Titulo;
        }

        // PB: public function string uof_getobjeto (integer nivel)
        public string uof_getobjeto(int nivel)
        {
            return this.at_nvl[nivel].Objeto;
        }

        // PB: public function string uof_gettitulo ()
        public string uof_gettitulo()
        {
            return uof_gettitulo(this.Orden);
        }

        // PB: public function string uof_getobjeto ()
        public string uof_getobjeto()
        {
            return uof_getobjeto(this.Orden);
        }

        // PB: public function string uof_getcierra (integer nivel)
        public string uof_getcierra(int nivel)
        {
            return this.at_nvl[nivel].Cierra;
        }

        // PB: public function string uof_getcierra ()
        public string uof_getcierra()
        {
            return uof_getcierra(this.Orden);
        }

        // PB: public function boolean uof_nivelvalido (integer arg_nivel)
        public bool uof_nivelvalido(int arg_nivel)
        {
            /*
             PB:
             Como los parámetros se cargan en el arreglo consecutivamente (ordenados
             por el campo orden de la tabla de parámetros), alcanza con saber si en el
             arreglo hay un objeto en la posición buscada
            */

            if (this.at_nvl != null && this.at_nvl.Length >= arg_nivel)
                return true;
            else
                return false;

            /*
             NOTA PB:
             Si en algún momento se decide leer solo los parámetros que tengan un orden
             consecutivo y utilizar los no consecutivos para manejo interno de las
             ventanas, esta función debería ser modificada.
            */
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
        public cat_operacion()
        {
            // PB:
            // call super::create
            base.constructor();

            // TriggerEvent( this, "constructor" )
            constructor();
        }

        // ==== PB: on destroy ====
        public void destroy()
        {
            // PB:
            // TriggerEvent( this, "destructor" )
            destructor();

            // call super::destroy
            base.destructor();
        }
    }
}
