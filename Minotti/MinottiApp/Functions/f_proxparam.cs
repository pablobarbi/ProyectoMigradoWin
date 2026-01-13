using System;

namespace Minotti.Functions
{
    /// <summary>
    /// Migración fiel de PowerBuilder: f_proxparam.srf
    /// Firma original PB:
    ///   public function string wf_proxparam (ref string param)
    ///   public function string wf_proxparam (ref string param, integer orden_buscado)
    ///
    /// Comportamiento:
    /// - Devuelve el próximo parámetro (Trim)
    /// - Consume el string original (ref)
    /// - Separador fijo: ',' (como en PB)
    /// </summary>
    public static class f_proxparam
    {
        /// <summary>
        /// Equivalente a PB: wf_ProxParam(ref param)
        /// </summary>
        public static string fproxparam(ref string param)
        {
            return fproxparam(ref param, 1);
        }

        /// <summary>
        /// Equivalente a PB: wf_ProxParam(ref param, orden_buscado)
        /// </summary>
        public static string fproxparam(ref string param, int ordenBuscado)
        {
            if (string.IsNullOrWhiteSpace(param))
                return string.Empty;

            int iFin;
            string retorno = string.Empty;

            // Saltea los parámetros anteriores al buscado
            for (int contador = 1; contador <= ordenBuscado - 1; contador++)
            {
                iFin = param.IndexOf(',');
                if (iFin >= 0)
                {
                    param = param.Substring(iFin + 1).Trim();
                }
                else
                {
                    param = string.Empty;
                    return string.Empty;
                }
            }

            // Extrae el parámetro actual
            iFin = param.IndexOf(',');
            if (iFin >= 0)
            {
                retorno = param.Substring(0, iFin).Trim();
                param = param.Substring(iFin + 1).Trim();
            }
            else
            {
                retorno = param.Trim();
                param = string.Empty;
            }

            return retorno;
        }
    }

}
