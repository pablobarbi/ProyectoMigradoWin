using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Functions
{
    public static class f_cant_dias_mes
    {
        public static int fcant_dias_mes(int ai_mes, int ai_anio)
        {
            int li_Dias = 0;

            switch (ai_mes)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    li_Dias = 31;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    li_Dias = 30;
                    break;

                case 2:
                    if (f_es_anio_bisiesto(ai_anio))
                        li_Dias = 29;
                    else
                        li_Dias = 28;
                    break;
            }

            return li_Dias;
        }
        public static bool f_es_anio_bisiesto(int ai_anio)
        {
            // Traducción EXACTA del comportamiento PB
            if (ai_anio % 4 == 0)
            {
                if (ai_anio % 100 == 0)
                {
                    if (ai_anio % 1000 == 0)
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
            else
                return false;
        }
    }
}
