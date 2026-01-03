using System;
using System.Globalization;

namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_date_a_string.srf
    /// Firma original: global function string f_date_a_string (date fecha)
    /// Mantengo el nombre del archivo, clase y método.
    /// </summary>
    public static class f_date_a_string
    {
        /// <summary>
        /// Devuelve la fecha formateada como "dd-MM-yyyy", igual que String(fecha, "dd-mm-yyyy") en PB.
        /// Nota: En .NET usamos "MM" para mes (en PB es "mm").
        /// </summary>
        public static string fdate_a_string(DateTime fecha)
        {
            return fecha.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
        }
    }
}
