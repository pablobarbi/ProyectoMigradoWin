using System;
using System.Text;

namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_string_suma_uno.srf
    /// Firma original: global function string f_string_suma_uno (string cadena)
    /// Comportamiento: incrementa una cadena alfabética al estilo columnas (A..Z, AA..AZ, BA..BZ, ..., ZZ, AAA...).
    /// </summary>
    public static class f_string_suma_uno
    {
        /// <summary>
        /// Incrementa alfabéticamente. Ejemplos:
        /// "" -> "A", "A" -> "B", ..., "Z" -> "AA", "AZ" -> "BA", "ZZ" -> "AAA".
        /// Sólo se consideran letras A-Z; otras letras se forzan a mayúscula y no alfabéticas se ignoran al final.
        /// </summary>
        public static string fstring_suma_uno(string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
                return "A";

            var sb = new StringBuilder(cadena.ToUpperInvariant());
            int i = sb.Length - 1;
            bool carry = true;

            while (i >= 0 && carry)
            {
                char c = sb[i];
                if (c < 'A' || c > 'Z')
                {
                    // Si hay caracteres no alfabéticos, los tratamos como 'A'-1 para avanzar a 'A'
                    sb[i] = 'A';
                    carry = false;
                    break;
                }

                if (c == 'Z')
                {
                    sb[i] = 'A';
                    i--;
                    carry = true;
                }
                else
                {
                    sb[i] = (char)(c + 1);
                    carry = false;
                }
            }

            if (carry)
            {
                // Todos eran 'Z' -> anteponemos 'A' (ZZ -> AAA)
                sb.Insert(0, 'A');
            }

            return sb.ToString();
        }
    }
}
