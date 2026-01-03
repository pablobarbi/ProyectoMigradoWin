using Minotti.Views.Basicos.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    // <summary>
    /// Equivalente PowerBuilder: cat_response_abm (nonvisualobject autoinstantiate)
    /// </summary>
    public class cat_response_abm
    {
        // uo_dw dw_1   // datawindow que va a hacer sharedata
        public uo_dw? dw_1 { get; set; }

        // string param  // parámetros para abrir la nueva datawindow
        public string param { get; set; } = string.Empty;

        // string claves[]   // Claves por si se va a agregar un nuevo registro
        public string[] claves { get; set; } = System.Array.Empty<string>();

        public cat_response_abm()
        {
        }
    }
}
