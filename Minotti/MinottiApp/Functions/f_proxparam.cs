using System;

namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_proxparam.srf
    /// Firma típica en PB: global function string f_proxparam (ref string as_parametros {, string as_separador })
    /// Mantengo el nombre del archivo, clase y método. Por compatibilidad, doy dos overloads:
    ///  - f_proxparam(ref string parametro)                -> usa ';' como separador por defecto (como en tus SRW)
    ///  - f_proxparam(ref string parametro, string sep)    -> permite indicar separador
    ///
    /// Comportamiento: devuelve el PRÓXIMO parámetro (Trim) y acorta 'parametro' dejando el resto (Trim).
    /// Si no hay más, devuelve "" y deja 'parametro' = "".
    /// </summary>
    public static class f_proxparam
    {
        /// <summary>Usa ';' como separador por defecto (coincide con wf_ProxParam(param) de tus ventanas).</summary>
        public static string fproxparam(string parametro)
            => fproxparam(ref parametro, ";");

        /// <summary>Permite indicar otro separador (por ejemplo, coma, pipe, etc.).</summary>
        public static string fproxparam(ref string parametro, string as_separador)
        {
            // Reutilizamos la función migrada f_cortar_string para mantener el mismo comportamiento de PB.
            return f_cortar_string.fcortar_string(parametro, as_separador ?? string.Empty);
        }
    }
}
