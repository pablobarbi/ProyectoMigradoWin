using System;
using System.Globalization;

namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_string_a_datetime.srf
    /// Firma PB típica: global function datetime f_string_a_datetime (string fecha_hora)
    /// En C# usamos DateTime? para representar NULL/SetNull de PB.
    /// </summary>
    public static class f_string_a_datetime
    {
        /// <summary>
        /// Convierte 'fecha_hora' a DateTime si reconoce el formato; en caso contrario devuelve null.
        /// Acepta formatos comunes a PB: "dd-MM-yyyy hh:mm:ss" (donde MM=mes), y variantes con '/', '.' y 'T'.
        /// </summary>
        public static DateTime? fstring_a_datetime(string? fecha_hora)
        {
            if (string.IsNullOrWhiteSpace(fecha_hora))
                return null;

            fecha_hora = fecha_hora.Trim();

            // Formatos explícitos (mes en MM, minutos en mm)
            string[] formatos = new[]
            {
                "dd-MM-yyyy HH:mm:ss",
                "dd-MM-yyyy HH:mm",
                "dd/MM/yyyy HH:mm:ss",
                "dd/MM/yyyy HH:mm",
                "dd.MM.yyyy HH:mm:ss",
                "dd.MM.yyyy HH:mm",
                "yyyy-MM-dd HH:mm:ss",
                "yyyy-MM-dd HH:mm",
                "yyyy/MM/dd HH:mm:ss",
                "yyyy/MM/dd HH:mm",
                "yyyy-MM-ddTHH:mm:ss",
                "yyyy-MM-ddTHH:mm",
                "dd-MM-yyyy",
                "dd/MM/yyyy",
                "yyyy-MM-dd",
                "yyyy/MM/dd"
            };

            if (DateTime.TryParseExact(fecha_hora, formatos, CultureInfo.InvariantCulture,
                                       DateTimeStyles.AllowWhiteSpaces, out var dt))
            {
                return dt;
            }

            // Fallback cultural (ej. "es-AR"): permite otros separadores/ordenes regionales
            if (DateTime.TryParse(fecha_hora, CultureInfo.GetCultureInfo("es-AR"),
                                  DateTimeStyles.AllowWhiteSpaces, out dt))
            {
                return dt;
            }

            // No reconocido -> NULL (equivalente a SetNull en PB)
            return null;
        }
    }
}
