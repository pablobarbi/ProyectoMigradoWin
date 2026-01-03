using System;

namespace Minotti.Controls
{
    /// <summary>
    /// Stub mínimo para emular el DataStore de PowerBuilder.
    /// Expone 'Syntax' (equivalente a dw.Object.DataWindow.Syntax).
    /// </summary>
    public class DataStore
    {
        /// <summary>Contenido de la sintaxis del DataWindow.</summary>
        public string? Syntax { get; set; }

        public DataStore() {}
        public DataStore(string? syntax) { Syntax = syntax; }
    }
}
