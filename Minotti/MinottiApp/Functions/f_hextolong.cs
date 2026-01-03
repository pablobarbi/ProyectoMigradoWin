using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Functions
{
    public static class f_hextolong
    {
        // Equivalente a: global function long f_hextolong (string as_hexadecimal)
        public static long fhextolong(string as_hexadecimal)
        {
            if (string.IsNullOrWhiteSpace(as_hexadecimal))
                return 0;

            string ls_hex = as_hexadecimal.Trim().ToUpperInvariant();
            long result = 0;

            for (int i = 0; i < ls_hex.Length; i++)
            {
                char c = ls_hex[i];

                int digit;
                if (c >= '0' && c <= '9')
                    digit = c - '0';
                else if (c >= 'A' && c <= 'F')
                    digit = 10 + (c - 'A');
                else
                    throw new ArgumentException($"Valor hexadecimal inválido: '{c}'", nameof(as_hexadecimal));

                checked
                {
                    result = (result * 16) + digit;
                }
            }

            return result;
        }
    }

}
