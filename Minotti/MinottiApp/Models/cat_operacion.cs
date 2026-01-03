using Minotti.Views.Basicos;
using System;
using System.Windows.Forms;

namespace Minotti.Models
{
    /// <summary>
    /// Equivalente a la nonvisualobject cat_operacion de PowerBuilder.
    /// </summary>
    public class cat_operacion
    {
        // =========================
        // Variables (datos PB)
        // =========================

        /* Datos generales de la operación */
        public string Modulo { get; set; } = string.Empty;
        public string Operacion { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        /* Datos para cada nivel */
        public cat_nivel[] at_nvl { get; set; } = System.Array.Empty<cat_nivel>();

        /* Parámetros para cada ventana que se abre */
        public bool Alta { get; set; }
        public bool Modificacion { get; set; }
        public bool Baja { get; set; }
        public int Orden { get; set; }

        /// <summary>
        /// Parámetros que pasa la ventana (valores de los campos que son clave en la dw).
        /// </summary>
        public string[] s_det { get; set; } = System.Array.Empty<string>();

        /// <summary>
        /// Indica con qué botón de la barra de menú se abrió la ventana (Alta, Modificación, Baja, etc.).
        /// </summary>
        public string Accion { get; set; } = string.Empty;

        /// <summary>
        /// Ventana anterior (sheet) que abrió la operación.
        /// </summary>
        public w_sheet? w_anterior { get; set; }

        // =========================
        // Métodos (uof_*)
        // =========================

        /// <summary>
        /// PB: public subroutine uof_copiaren (ref cat_operacion copia)
        /// Copia los datos relevantes a otra instancia.
        /// NOTA: igual que en PB, NO copia el arreglo de argumentos (s_det).
        /// </summary>
        public void uof_copiaren(ref cat_operacion copia)
        {
            if (copia == null) throw new System.ArgumentNullException(nameof(copia));

            copia.Modulo = this.Modulo;
            copia.Operacion = this.Operacion;
            copia.Nombre = this.Nombre;
            // PB NO copia Descripcion, así que acá tampoco lo hacemos.
            copia.at_nvl = this.at_nvl;
            copia.w_anterior = this.w_anterior;
            copia.Orden = this.Orden;
            copia.Alta = this.Alta;
            copia.Modificacion = this.Modificacion;
            copia.Baja = this.Baja;
            copia.Accion = this.Accion;
            // No copia s_det (arreglo de argumentos), igual que en PB.
        }

        // ========== helpers internos para respetar índice 1-based de PB ==========

        private cat_nivel GetNivel(int nivel)
        {
            // En PB los arrays son 1-based. En C# son 0-based, adaptamos.
            if (nivel <= 0)
                throw new System.ArgumentOutOfRangeException(nameof(nivel));

            if (at_nvl == null || at_nvl.Length < nivel)
                throw new System.IndexOutOfRangeException($"Nivel {nivel} no válido en at_nvl.");

            return at_nvl[nivel - 1];
        }

        // ========== uof_getparametros ==========

        /// <summary>
        /// PB: public function string uof_getparametros (integer nivel);
        /// Return(This.at_nvl[nivel].parametros)
        /// </summary>
        public string uof_getparametros(int nivel)
        {
            return GetNivel(nivel).Parametros;
        }

        /// <summary>
        /// PB: public function string uof_getparametros ();
        /// Return(uof_getParametros(This.Orden))
        /// </summary>
        public string uof_getparametros()
        {
            return uof_getparametros(this.Orden);
        }

        // ========== uof_gettitulo / uof_getobjeto ==========

        /// <summary>
        /// PB: public function string uof_gettitulo (integer nivel);
        /// Return(This.at_nvl[nivel].Titulo)
        /// </summary>
        public string uof_gettitulo(int nivel)
        {
            return GetNivel(nivel).Titulo;
        }

        /// <summary>
        /// PB: public function string uof_getobjeto (integer nivel);
        /// Return(This.at_nvl[nivel].Objeto)
        /// </summary>
        public string uof_getobjeto(int nivel)
        {
            return GetNivel(nivel).Objeto;
        }

        /// <summary>
        /// PB: public function string uof_gettitulo ();
        /// Return(uof_getTitulo(This.Orden))
        /// </summary>
        public string uof_gettitulo()
        {
            return uof_gettitulo(this.Orden);
        }

        /// <summary>
        /// PB: public function string uof_getobjeto ();
        /// Return(uof_getObjeto(This.Orden))
        /// </summary>
        public string uof_getobjeto()
        {
            return uof_getobjeto(this.Orden);
        }

        // ========== uof_getcierra ==========

        /// <summary>
        /// PB: public function string uof_getcierra (integer nivel);
        /// Return(This.at_nvl[nivel].Cierra)
        /// </summary>
        public string uof_getcierra(int nivel)
        {
            return GetNivel(nivel).Cierra;
        }

        /// <summary>
        /// PB: public function string uof_getcierra ();
        /// Return(uof_getCierra(This.Orden))
        /// </summary>
        public string uof_getcierra()
        {
            return uof_getcierra(this.Orden);
        }

        // ========== uof_nivelvalido ==========

        /// <summary>
        /// PB: public function boolean uof_nivelvalido (integer arg_nivel)
        /// 
        /// If UpperBound(This.at_nvl[]) >= arg_nivel Then
        ///     Return(TRUE)
        /// Else
        ///     Return(FALSE)
        /// End If
        /// </summary>
        public bool uof_nivelvalido(int arg_nivel)
        {
            if (arg_nivel <= 0)
                return false;

            if (at_nvl == null)
                return false;

            // UpperBound(PB) == Length en C#, pero PB es 1-based; adaptamos la comparación:
            return at_nvl.Length >= arg_nivel;
        }

        // =========================
        // constructor / destructor PB
        // =========================
        //
        // on cat_operacion.create
        //   call super::create
        //   TriggerEvent( this, "constructor" )
        //
        // on cat_operacion.destroy
        //   TriggerEvent( this, "destructor" )
        //   call super::destroy
        //
        // Si tenías código en los eventos constructor/destructor en PB,
        // podés mapearlos a métodos explícitos acá, por ejemplo:
        //
        // public virtual void constructor() { }
        // public virtual void destructor() { }
        //
        // Y llamarlos manualmente desde donde instancies cat_operacion.
    }

    // NOTA: cat_nivel debe existir en Minotti.Data con al menos:
    // public class cat_nivel
    // {
    //     public string parametros { get; set; } = string.Empty;
    //     public string Titulo { get; set; } = string.Empty;
    //     public string Objeto { get; set; } = string.Empty;
    //     public string Cierra { get; set; } = string.Empty;
    // }

}
