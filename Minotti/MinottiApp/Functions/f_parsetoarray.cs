using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Functions
{
    public static class f_parsetoarray
    {
        /// <summary>
        /// Equivalente a la función PB:
        /// f_parsetoarray (string as_origen, string as_delimitador, ref string as_arreglo[])
        /// 
        /// - Parsea as_origen en un arreglo usando as_delimitador como separador.
        /// - Devuelve la cantidad de elementos (UpperBound).
        /// - Devuelve null si as_origen o as_delimitador son null (IsNull en PB).
        /// </summary>
        public static long? Execute(string? as_origen, string? as_delimitador, out string[] as_arreglo)
        {
            // Inicializamos el out
            as_arreglo = System.Array.Empty<string>();

            // Chequea nulos (IsNull en PB)
            if (as_origen is null || as_delimitador is null)
            {
                // En PB: SetNull(ll_null); Return ll_null
                return null;
            }

            // Al menos un campo: si está vacío (solo espacios), devuelve 0
            if (string.IsNullOrWhiteSpace(as_origen))
            {
                return 0;
            }

            // Largo del delimitador
            int ll_DelLen = as_delimitador.Length;

            if (ll_DelLen == 0)
            {
                // Evitamos loop infinito si el delimitador está vacío.
                // PB no contempla este caso explícitamente; acá devolvemos 1 con el string entero.
                as_arreglo = new[] { as_origen };
                return 1;
            }

            string origenUpper = as_origen.ToUpper();
            string delimUpper = as_delimitador.ToUpper();

            // Pos inicial (Pos en PB, 1-based; IndexOf en C#, 0-based)
            int ll_Pos = origenUpper.IndexOf(delimUpper, 0, System.StringComparison.Ordinal);

            // Solo un campo (no se encuentra el delimitador)
            if (ll_Pos < 0)
            {
                as_arreglo = new[] { as_origen };
                return 1;
            }

            // Más de un campo
            var lista = new System.Collections.Generic.List<string>();
            int ll_Start = 0; // en C# es 0-based (PB usaba 1)

            while (ll_Pos >= 0)
            {
                int ll_Length = ll_Pos - ll_Start;
                string ls_holder = as_origen.Substring(ll_Start, ll_Length);

                lista.Add(ls_holder.Trim());

                // Siguiente inicio después del delimitador
                ll_Start = ll_Pos + ll_DelLen;

                // Buscar próximo (PB: Pos(Upper(as_origen), Upper(as_Delimitador), ll_Start))
                if (ll_Start >= origenUpper.Length)
                {
                    ll_Pos = -1;
                }
                else
                {
                    ll_Pos = origenUpper.IndexOf(delimUpper, ll_Start, System.StringComparison.Ordinal);
                }
            }

            // Último campo (desde ll_Start hasta el final)
            if (ll_Start < as_origen.Length)
            {
                string ls_holder = as_origen.Substring(ll_Start);
                if (ls_holder.Length > 0)
                {
                    lista.Add(ls_holder.Trim());
                }
            }

            as_arreglo = lista.ToArray();
            return lista.Count;
        }
    }
}
