using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente PowerBuilder: cat_return (nonvisualobject autoinstantiate)
    /// </summary>
    public class cat_return
    {
        // Boolean  rtn_boolean
        public bool rtn_boolean { get; set; }

        // Integer rtn_integer
        public int rtn_integer { get; set; }

        // String mensaje_error
        public string mensaje_error { get; set; } = string.Empty;

        // String warning
        public string warning { get; set; } = string.Empty;

        // String codigo_error
        public string codigo_error { get; set; } = string.Empty;

        // String rtn_string
        public string rtn_string { get; set; } = string.Empty;

        public cat_return()
        {
        }
    }
}
