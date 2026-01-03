using System;
using System.Globalization;

namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_datetime_a_string.srf
    /// Firma original: global function string f_datetime_a_string (datetime fecha)
    /// Mantengo el nombre del archivo, clase y método.
    /// </summary>
    public static class f_datetime_a_string
    {
        /// <summary>
        /// Devuelve la fecha/hora formateada como "dd-MM-yyyy HH:mm:ss",
        /// equivalente a String(fecha, "dd-mm-yyyy hh:mm:ss") en PB
        /// (en .NET, MM=mes y mm=minutos).
        /// </summary>
        public static string fdatetime_a_string(DateTime fecha)
        {
            return fecha.ToString("dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}
