using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Functions
{
    public static class f_globalreplace
    {
        /// <summary>
        /// Equivalente a la función PB:
        /// f_globalreplace (string as_origen, string as_viejo, string as_reemplazar, boolean ab_igncase)
        /// </summary>
        public static string Execute(string as_origen, string as_viejo, string as_reemplazar, bool ab_igncase)
        {
            // Chekea parámetros (IsNull en PB → null en C#)
            if (as_origen == null || as_viejo == null || as_reemplazar == null)
            {
                // En PB hacía SetNull(ls_null) y devolvía NULL
                return null!;
            }

            // Si la cadena a buscar está vacía, evitamos loop infinito
            if (as_viejo.Length == 0)
                return as_origen;

            int ll_OldLen = as_viejo.Length;
            int ll_NewLen = as_reemplazar.Length;

            string ls_Source;

            // Se fija si debe respetar el CASE.
            if (ab_igncase)
            {
                as_viejo = as_viejo.ToLower();   // Lower(as_viejo)
                ls_Source = as_origen.ToLower(); // ls_source = Lower(as_origen)
            }
            else
            {
                ls_Source = as_origen;
            }

            int ll_Start = ls_Source.IndexOf(as_viejo, 0, System.StringComparison.Ordinal);

            while (ll_Start >= 0)
            {
                // Reemplaza en la cadena original (igual que Replace(as_origen, ll_Start, ll_OldLen, as_reemplazar))
                as_origen = as_origen.Substring(0, ll_Start)
                           + as_reemplazar
                           + as_origen.Substring(ll_Start + ll_OldLen);

                // Recalcula ls_Source según CASE
                if (ab_igncase)
                {
                    ls_Source = as_origen.ToLower();
                }
                else
                {
                    ls_Source = as_origen;
                }

                // Busca próximo (ll_Start + ll_NewLen)
                int nextStart = ll_Start + ll_NewLen;
                if (nextStart > ls_Source.Length)
                    break;

                ll_Start = ls_Source.IndexOf(as_viejo, nextStart, System.StringComparison.Ordinal);
            }

            return as_origen;
        }
    }
}
