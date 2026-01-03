using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Functions
{
    public static class f_real
    {
        /// <summary>
        /// Equivalente a la función PB:
        /// global function decimal f_real (string sarg_valor)
        ///
        /// - Quita ciertos ceros a la izquierda (como en PB).
        /// - Intenta convertir el string a número con decimales,
        ///   tolerando '.' o ',' como separador.
        /// </summary>
        public static decimal freal(string sarg_valor)
        {
            if (sarg_valor == null)
                throw new ArgumentNullException(nameof(sarg_valor));

            sarg_valor = sarg_valor.Trim();

            if (sarg_valor.Length == 0)
                return 0m;

            // =====================================================
            //  Bloque "Saca los ceros a la izquierda" (igual que PB)
            // =====================================================
            int iAux = 0;
            while (iAux == 0)
            {
                if (sarg_valor.Length <= 1)
                {
                    iAux = 1;
                }
                else if (sarg_valor[0] == '0')
                {
                    // sAux = mid(sarg_valor, 2, 1)
                    char sAux = sarg_valor[1];

                    if (sAux >= '1' && sAux <= '9')
                    {
                        // sarg_valor = mid(sarg_valor, 2)
                        sarg_valor = sarg_valor.Substring(1);
                    }
                    else
                    {
                        iAux = 1;
                    }
                }
                else
                {
                    iAux = 1;
                }
            }

            // ==========================================
            // Intento de parseo, respetando punto/coma
            // (equivalente al juego String(Double()) /
            //  reemplazo de '.' por ',' en PB)
            // ==========================================

            decimal result;

            // 1) Intento con cultura invariante (punto como separador)
            if (decimal.TryParse(
                    sarg_valor,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out result))
            {
                return result;
            }

            // 2) Intento con cultura "es-AR" (coma como separador)
            var esAr = new CultureInfo("es-AR");
            if (decimal.TryParse(
                    sarg_valor,
                    NumberStyles.Float,
                    esAr,
                    out result))
            {
                return result;
            }

            // 3) Emulo el "If sAux <> sarg_valor Then ... Replace('.', ',')"
            //    Si contiene '.', pruebo reemplazar por ',' con cultura es-AR
            if (sarg_valor.Contains(".") && !sarg_valor.Contains(","))
            {
                string cambiado = sarg_valor.Replace('.', ',');

                if (decimal.TryParse(
                        cambiado,
                        NumberStyles.Float,
                        esAr,
                        out result))
                {
                    return result;
                }
            }

            // 4) Al revés: si contiene ',' y no '.', pruebo con '.'
            if (sarg_valor.Contains(",") && !sarg_valor.Contains("."))
            {
                string cambiado = sarg_valor.Replace(',', '.');

                if (decimal.TryParse(
                        cambiado,
                        NumberStyles.Float,
                        CultureInfo.InvariantCulture,
                        out result))
                {
                    return result;
                }
            }

            // Si llega acá, en PB tiraría error en Double(sarg_valor).
            // Preferimos avisar claramente.
            throw new FormatException($"f_real: no se pudo convertir '{sarg_valor}' a número decimal.");
        }
    }
}
