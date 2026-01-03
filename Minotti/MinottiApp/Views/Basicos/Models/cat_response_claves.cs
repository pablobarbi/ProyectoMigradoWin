using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente PowerBuilder: cat_response_claves from cat_response
    /// </summary>
    public class cat_response_claves : cat_response
    {
        // string claves[]
        public string[] claves { get; set; } = System.Array.Empty<string>();

        public cat_response_claves()
        {
        }
    }
}
