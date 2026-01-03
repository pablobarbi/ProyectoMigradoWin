using System;

namespace Minotti.Functions
{
    public static class f_longtohex
    {
        // Equivalente a: global function string f_longtohex (long as_number, integer as_digitos)
        public static string flongtohex(long as_number, int? as_digitos)
        {
            int digitos = as_digitos ?? 2;

            if (digitos > 0)
            {
                // ll_temp0 = abs(as_number / (16 ^ (as_digitos - 1)))
                long pow = Pow16(digitos - 1);

                long ll_temp0 = Math.Abs(as_number / pow);

                // ll_temp1 = ll_temp0 * (16 ^ (as_digitos - 1))
                long ll_temp1 = ll_temp0 * pow;

                char lc_ret;
                if (ll_temp0 > 9)
                {
                    // char(ll_temp0 + 55) -> 10->'A' (65)
                    lc_ret = (char)(ll_temp0 + 55);
                }
                else
                {
                    // char(ll_temp0 + 48) -> 0->'0' (48)
                    lc_ret = (char)(ll_temp0 + 48);
                }

                // RETURN lc_ret + f_longtohex(as_number - ll_temp1 , as_digitos - 1)
                return lc_ret + flongtohex(as_number - ll_temp1, digitos - 1);
            }

            return "";
        }

        private static long Pow16(int exp)
        {
            // (16 ^ exp) en PowerBuilder (entero)
            if (exp <= 0) return 1;

            long result = 1;
            checked
            {
                for (int i = 0; i < exp; i++)
                    result *= 16;
            }
            return result;
        }
    }

}
