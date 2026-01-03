using System;
using System.Globalization;

namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_fecha_a_string.srf
    /// Firma original: global function string f_fecha_a_string (datetime fecha)
    /// Mantengo el nombre del archivo, clase y método.
    /// </summary>
    public static class f_fecha_a_string
    {
        /// <summary>
        /// Equivalente a: Return String(fecha, "dd-mm-yyyy") en PB.
        /// En .NET: "MM" = mes, "mm" = minutos.
        /// </summary>
        public static string ffecha_a_string(DateTime fecha)
        {
            return fecha.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
        }
    }
}
