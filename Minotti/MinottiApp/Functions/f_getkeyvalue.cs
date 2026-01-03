 // Minotti/Functions/f_getkeyvalue.cs
using System;

namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_getkeyvalue.srf
    /// Firma original: global function string f_getkeyvalue (string as_source, string as_keyword, string as_separator)
    /// Mantengo el nombre del archivo, clase y método.
    /// </summary>
    public static class f_getkeyvalue
    {
        /// <summary>
        /// Devuelve el valor asociado a 'as_keyword' dentro de 'as_source',
        /// donde los pares están separados por 'as_separator' y el key/value por '='.
        /// - Si 'as_keyword' es vacío: devuelve el PRIMER token (sin analizar '=').
        /// - Si no encuentra el keyword: devuelve string.Empty.
        /// Los trims se aplican como en PB.
        /// </summary>
        public static string fgetkeyvalue(string as_source, string as_keyword, string as_separator)
        {
            as_source   ??= string.Empty;
            as_keyword  ??= string.Empty;
            as_separator??= string.Empty;

            string s = as_source;
            bool noSep = string.IsNullOrEmpty(as_separator);

            // Caso especial: si keyword vacío, devolver primer token (equivalente al uso en varios SRF)
            if (string.IsNullOrWhiteSpace(as_keyword))
            {
                if (noSep) return s.Trim();
                int cut = s.IndexOf(as_separator, StringComparison.Ordinal);
                return (cut >= 0 ? s[..cut] : s).Trim();
            }

            while (true)
            {
                string segment;
                int sepPos = noSep ? -1 : s.IndexOf(as_separator, StringComparison.Ordinal);

                if (sepPos >= 0)
                {
                    segment = s[..sepPos];
                }
                else
                {
                    segment = s; // último segmento
                }

                var t = segment.Trim();
                if (t.Length > 0)
                {
                    // Buscar key=value
                    int eq = t.IndexOf('=');
                    if (eq >= 0)
                    {
                        var key = t[..eq].Trim();
                        var val = (eq + 1 < t.Length ? t[(eq + 1)..] : string.Empty).Trim();

                        if (key.Equals(as_keyword, StringComparison.OrdinalIgnoreCase))
                            return val;
                    }
                    else
                    {
                        // Si no hay '=', permitir coincidencia exacta por keyword y devolver vacío
                        if (t.Equals(as_keyword, StringComparison.OrdinalIgnoreCase))
                            return string.Empty;
                    }
                }

                if (sepPos < 0) break;
                // Avanzar al próximo segmento
                s = sepPos + as_separator.Length < s.Length ? s[(sepPos + as_separator.Length)..] : string.Empty;
                if (s.Length == 0) break;
            }

            return string.Empty;
        }
    }
}
