using Minotti.Views.Basicos;
using System;
using System.Collections.Generic;
 

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente PowerBuilder: cat_operacion (nonvisualobject autoinstantiate)
    /// </summary>
    public class cat_operacion
    {
        // =========================
        // Datos generales de la operación
        // =========================
        public string Modulo { get; set; } = string.Empty;
        public string Operacion { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        // Datos para cada nivel  -> cat_nivel  at_nvl[]
        // En PB el array es 1-based. Acá usamos List y tratamos nivel como 1-based.
        public List<cat_nivel> at_nvl { get; set; } = new List<cat_nivel>();

        // =========================
        // Parámetros para cada ventana que se abre
        // =========================
        public bool Alta { get; set; }
        public bool Modificacion { get; set; }
        public bool Baja { get; set; }

        public int Orden { get; set; }

        // String s_det[]  (Parámetros que pasa la ventana: valores de los campos clave)
        public string[] s_det { get; set; } = Array.Empty<string>();

        // String Accion  (botón de barra de menú que abrió la ventana: Alta, Modificación, Baja, etc.)
        public string Accion { get; set; } = string.Empty;

        // w_sheet w_anterior
        public w_sheet? w_anterior { get; set; }

        public cat_operacion()
        {
        }

        // ======================================================
        //  Métodos uof_* (migrados 1:1 desde PowerBuilder)
        // ======================================================

        // public subroutine uof_copiaren (ref cat_operacion copia)
        public void uof_copiaren(cat_operacion copia)
        {
            if (copia == null)
                copia = new cat_operacion();

            copia.Modulo = this.Modulo;
            copia.Operacion = this.Operacion;
            copia.Nombre = this.Nombre;
            // En PB NO copia Descripcion, respetamos eso.
            copia.at_nvl = this.at_nvl;
            copia.w_anterior = this.w_anterior;
            copia.Orden = this.Orden;
            copia.Alta = this.Alta;
            copia.Modificacion = this.Modificacion;
            copia.Baja = this.Baja;
            copia.Accion = this.Accion;
            // No copia s_det (arreglo de argumentos), igual que en PB.
        }

        // Helper privado para respetar que nivel es 1-based
        private cat_nivel? GetNivel(int nivel)
        {
            int idx = nivel - 1;      // PB: 1-based  -> C#: 0-based
            if (idx < 0 || idx >= at_nvl.Count)
                return null;
            return at_nvl[idx];
        }

        // public function string uof_getparametros (integer nivel);
        public string uof_getparametros(int nivel)
        {
            return GetNivel(nivel)?.Parametros ?? string.Empty;
        }

        // public function string uof_getparametros ();
        public string uof_getparametros()
        {
            return uof_getparametros(this.Orden);
        }

        // public function string uof_gettitulo (integer nivel);
        public string uof_gettitulo(int nivel)
        {
            return GetNivel(nivel)?.Titulo ?? string.Empty;
        }

        // public function string uof_getobjeto (integer nivel);
        public string uof_getobjeto(int nivel)
        {
            return GetNivel(nivel)?.Objeto ?? string.Empty;
        }

        // public function string uof_gettitulo ();
        public string uof_gettitulo()
        {
            return uof_gettitulo(this.Orden);
        }

        // public function string uof_getobjeto ();
        public string uof_getobjeto()
        {
            return uof_getobjeto(this.Orden);
        }

        // public function string uof_getcierra (integer nivel);
        public string uof_getcierra(int nivel)
        {
            return GetNivel(nivel)?.Cierra ?? string.Empty;
        }

        // public function string uof_getcierra ();
        public string uof_getcierra()
        {
            return uof_getcierra(this.Orden);
        }

        // public function boolean uof_nivelvalido (integer arg_nivel);
        public bool uof_nivelvalido(int arg_nivel)
        {
            // PB: UpperBound(This.at_nvl[]) >= arg_nivel
            // Tratamos arg_nivel como 1-based
            return arg_nivel > 0 && at_nvl.Count >= arg_nivel;
        }
    }
}
