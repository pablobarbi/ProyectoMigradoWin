using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.utils
{
    /// <summary>
    /// Stub mínimo para emular el DataStore de PowerBuilder.
    /// Expone 'Syntax' (equivalente a dw.Object.DataWindow.Syntax).
    /// </summary>
    public class datastore
    {
        /// <summary>Contenido de la sintaxis del DataWindow.</summary>
        public string? Syntax { get; set; }

        public datastore() { }
        public datastore(string? syntax) { Syntax = syntax; }
    }
}
