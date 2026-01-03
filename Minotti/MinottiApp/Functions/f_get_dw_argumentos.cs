using Minotti.utils;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
 

namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_get_dw_argumentos.srf
    /// Firma original: global function integer f_get_dw_argumentos (DataWindow dw, ref string as_argnames[], ref string as_argdatatypes[])
    /// Mantengo nombre de archivo, clase y método.
    /// </summary>
    public static class f_get_dw_argumentos
    {
        /// <summary>
        /// Extrae los argumentos definidos en la sintaxis del DataWindow (dw.Syntax ó dw.Object.DataWindow.Syntax),
        /// buscando bloques tipo 'arg(name=..., type=...)'. Devuelve la cantidad encontrada.
        /// </summary>
        public static int fget_dw_argumentos(datawindow dw, ref string[] as_argnames, ref string[] as_argdatatypes)
        {
            if (dw == null) return -1;
            var syntax = dw.Syntax ?? dw.Object?.DataWindow?.Syntax ?? string.Empty;
            if (string.IsNullOrWhiteSpace(syntax))
            {
                as_argnames = Array.Empty<string>();
                as_argdatatypes = Array.Empty<string>();
                return 0;
            }

            var names = new List<string>();
            var types = new List<string>();

            // Buscar ocurrencias de arg( ... ) ignorando may/min y saltos de línea
            var rxArg = new Regex(@"arg\s*\((.*?)\)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var rxKV  = new Regex(@"(?<!\w)(name|argname|id|key|campo)\s*=\s*(""([^""]*)""|'([^']*)'|([^\s,)\r\n]+))|(?<!\w)(type)\s*=\s*(""([^""]*)""|'([^']*)'|([^\s,)\r\n]+))",
                                  RegexOptions.IgnoreCase);

            foreach (Match m in rxArg.Matches(syntax))
            {
                string? foundName = null;
                string? foundType = null;

                foreach (Match kv in rxKV.Matches(m.Groups[1].Value))
                {
                    var k = kv.Groups[1].Success ? kv.Groups[1].Value : (kv.Groups[6].Success ? kv.Groups[6].Value : null);
                    if (string.IsNullOrEmpty(k)) continue;
                    var v = kv.Groups[3].Success ? kv.Groups[3].Value :
                            kv.Groups[4].Success ? kv.Groups[4].Value :
                            kv.Groups[5].Success ? kv.Groups[5].Value :
                            kv.Groups[8].Success ? kv.Groups[8].Value :
                            kv.Groups[9].Success ? kv.Groups[9].Value :
                            kv.Groups[10].Success ? kv.Groups[10].Value : "";

                    if (k.Equals("name", StringComparison.OrdinalIgnoreCase) ||
                        k.Equals("argname", StringComparison.OrdinalIgnoreCase) ||
                        k.Equals("id", StringComparison.OrdinalIgnoreCase) ||
                        k.Equals("key", StringComparison.OrdinalIgnoreCase) ||
                        k.Equals("campo", StringComparison.OrdinalIgnoreCase))
                    {
                        foundName = v;
                    }
                    else if (k.Equals("type", StringComparison.OrdinalIgnoreCase))
                    {
                        foundType = v;
                    }
                }

                if (!string.IsNullOrWhiteSpace(foundName) || !string.IsNullOrWhiteSpace(foundType))
                {
                    names.Add(foundName ?? string.Empty);
                    types.Add(foundType ?? string.Empty);
                }
            }

            as_argnames = names.ToArray();
            as_argdatatypes = types.ToArray();
            return names.Count;
        }
    }
}
