using System;
using System.Globalization;

namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_string_a_fecha.srf
    /// Firma PB típica: global function date f_string_a_fecha (string fecha)
    /// En C# devolvemos DateTime? para poder representar NULL (SetNull) de PB.
    /// </summary>
    public static class f_string_a_fecha
    {
        /// <summary>
        /// Intenta convertir 'fecha' a un DateTime (solo fecha). Acepta formatos comunes de PB:
        /// "dd-MM-yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "yyyy/MM/dd", "dd.MM.yyyy".
        /// Si no puede convertir, devuelve null (equivalente a NULL en PB).
        /// </summary>
        public static DateTime? fstring_a_fecha(string? fecha)
        {
            if (string.IsNullOrWhiteSpace(fecha))
                return null;

            fecha = fecha.Trim();

            string[] formatos =
            {
                "dd-MM-yyyy",
                "dd/MM/yyyy",
                "yyyy-MM-dd",
                "yyyy/MM/dd",
                "dd.MM.yyyy"
            };

            if (DateTime.TryParseExact(fecha, formatos, CultureInfo.InvariantCulture,
                                       DateTimeStyles.None, out var dt))
            {
                return dt.Date;
            }

            // Fallback: intentar parseo cultural por si llegan otros separadores según configuración
            if (DateTime.TryParse(fecha, CultureInfo.GetCultureInfo("es-AR"),
                                  DateTimeStyles.None, out dt))
            {
                return dt.Date;
            }

            // No se pudo convertir -> NULL de PB
            return null;
        }
    }
}
