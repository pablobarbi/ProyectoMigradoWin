using System;

namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_cortar_string.srf
    /// Firma original: global function string f_cortar_string (ref string parametro, string separador)
    /// Mantengo el nombre del archivo, clase y método.
    /// </summary>
    public static class f_cortar_string
    {
        /// <summary>
        /// Corta 'parametro' por la primera aparición de 'separador'.
        /// Devuelve la porción izquierda (Trim) y en 'parametro' deja el resto (Trim).
        /// Si no se encuentra el separador, devuelve 'parametro' (Trim) y vacía 'parametro'.
        /// </summary>
        public static string fcortar_string(string parametro, string separador)
        {
            parametro ??= string.Empty;
            separador ??= string.Empty;

            if (separador.Length == 0)
            {
                // Comportamiento seguro: no hay separador; retornar todo y vaciar el resto
                var r = parametro.Trim();
                parametro = string.Empty;
                return r;
            }

            int idx = parametro.IndexOf(separador, StringComparison.Ordinal);
            if (idx >= 0)
            {
                var retorno = parametro.Substring(0, idx).Trim();
                var start = idx + separador.Length;
                parametro = (start < parametro.Length ? parametro.Substring(start) : string.Empty).Trim();
                return retorno;
            }
            else
            {
                var retorno = parametro.Trim();
                parametro = string.Empty;
                return retorno;
            }
        }
    }
}
