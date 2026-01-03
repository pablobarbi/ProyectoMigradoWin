using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente PowerBuilder: cat_string (nonvisualobject autoinstantiate)
    /// </summary>
    public class cat_string
    {
        // String que contiene el campo en la dw
        public string @string { get; set; } = string.Empty;

        // Longitud del String
        public int longitud { get; set; }

        // Titulo del Campo en la Datawindow
        public string texto_titulo { get; set; } = string.Empty;

        // Codigo de Retorno de la Ventana
        public int retorno { get; set; }

        public cat_string()
        {
        }
    }
}
