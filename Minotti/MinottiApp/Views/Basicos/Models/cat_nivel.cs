using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente PowerBuilder: cat_nivel (nonvisualobject autoinstantiate)
    /// </summary>
    public class cat_nivel
    {
        // Public:
        // string Titulo
        public string Titulo { get; set; } = string.Empty;

        // string Objeto
        public string Objeto { get; set; } = string.Empty;

        // string Parametros
        public string Parametros { get; set; } = string.Empty;

        // string Cierra  /* Indica si la ventana se cierra al abrir la siguiente ventana */
        public string Cierra { get; set; } = string.Empty;

        public cat_nivel()
        {
        }

        // public subroutine uof_copiaren (ref cat_nivel copia)
        public void uof_copiaren(ref cat_nivel copia)
        {
            if (copia == null)
                copia = new cat_nivel();

            copia.Objeto = this.Objeto;
            copia.Parametros = this.Parametros;
            copia.Titulo = this.Titulo;
            // En PB no copia Cierra, respetamos eso
        }
    }
}
