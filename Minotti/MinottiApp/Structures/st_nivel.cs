

using Minotti.utils;

namespace Minotti.Structures
{
    /// <summary>
    /// Migración de PowerBuilder (structure): st_nivel.srs
    /// Campos según el SRS:
    ///   - string  titulo
    ///   - datastore dw
    ///   - integer activo
    /// </summary>
    public class st_nivel
    {
        public string? titulo { get; set; }
        public datastore? dw { get; set; }
        public int activo { get; set; }
    }
}
