using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente PowerBuilder: cat_seleccion_row (nonvisualobject autoinstantiate)
    /// </summary>
    public class cat_seleccion_row
    {
        // String dataobject
        public string dataobject { get; set; } = string.Empty;

        // String valor_columna
        public string valor_columna { get; set; } = string.Empty;

        // String tipo_columna
        public string tipo_columna { get; set; } = string.Empty;

        // String descripcion
        public string descripcion { get; set; } = string.Empty;

        // Integer valor_retorno = -1
        public int valor_retorno { get; set; } = -1;

        public cat_seleccion_row()
        {
        }
    }
}
