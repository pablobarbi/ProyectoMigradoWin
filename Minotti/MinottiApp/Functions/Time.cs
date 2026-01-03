using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Functions
{
    public static class Time
    {
        // Emula PB: Time(string) -> time
        // Acepta "HH:mm", "HH:mm:ss" y variantes con espacios.
        public static TimeSpan TimeFn(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return TimeSpan.Zero;

            valor = valor.Trim();

            // Intento directo: "HH:mm" / "HH:mm:ss"
            if (TimeSpan.TryParse(valor, CultureInfo.InvariantCulture, out var ts))
                return ts;

            // Acepto "HHmm" (raro pero a veces aparece)
            if (valor.Length == 4 && int.TryParse(valor.Substring(0, 2), out var hh) && int.TryParse(valor.Substring(2, 2), out var mm))
                return new TimeSpan(hh, mm, 0);

            // Acepto formatos por DateTime ("HH:mm:ss", etc.)
            if (DateTime.TryParse(valor, CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out var dt))
                return dt.TimeOfDay;

            // Si no parsea, emulo comportamiento “tolerante”: 00:00:00
            return TimeSpan.Zero;
        }
    }
}
