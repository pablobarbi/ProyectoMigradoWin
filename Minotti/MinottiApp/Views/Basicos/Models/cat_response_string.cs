using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente PowerBuilder: cat_response_string from cat_response
    /// </summary>
    public class cat_response_string : cat_response
    {
        // string cadena // cadena que devuelve la ventana response
        public string cadena { get; set; } = string.Empty;

        public cat_response_string()
        {
        }
    }
}
