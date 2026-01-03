using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente PowerBuilder: cat_tamaño (nonvisualobject autoinstantiate)
    /// </summary>
    public class cat_tamaño
    {
        // integer largo
        public int largo { get; set; }

        // integer ancho
        public int ancho { get; set; }

        // integer borde
        public int borde { get; set; }

        public cat_tamaño()
        {
        }

        // public subroutine uof_copiaren (ref cat_tamaño copia)
        public void uof_copiaren(ref cat_tamaño copia)
        {
            if (copia == null)
            {
                copia = new cat_tamaño();
            }

            copia.largo = this.largo;
            copia.ancho = this.ancho;
            copia.borde = this.borde;
        }
    }
}
