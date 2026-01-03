using System;

namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_proxparam_n.srf
    /// Convención típica PB: devolver el N-ésimo parámetro de una cadena separada por un delimitador.
    /// Mantengo nombre de archivo, clase y método.
    /// </summary>
    public static class f_proxparam_n
    {
        /// <summary>
        /// Devuelve el N-ésimo parámetro (1-based) usando ';' como separador por defecto.
        /// </summary>
        public static string fproxparam_n(string parametros, int n)
            => fproxparam_n(parametros, ";", n);

        /// <summary>
        /// Devuelve el N-ésimo parámetro (1-based) usando 'separador' indicado.
        /// No modifica el string original (usa internamente f_cortar_string sobre una copia).
        /// Si N <= 0 o no existe ese parámetro, devuelve "" (como en PB).
        /// Aplica Trim() a cada token igual que f_cortar_string.
        /// </summary>
        public static string fproxparam_n(string parametros, string separador, int n)
        {
            if (n <= 0) return string.Empty;
            string s = parametros ?? string.Empty;
            separador ??= string.Empty;

            string token = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                token = Minotti.Functions.f_cortar_string.fcortar_string(s, separador);
                if (i < n && s.Length == 0)
                {
                    // Se agotaron los parámetros antes de llegar a N
                    return string.Empty;
                }
            }
            return token;
        }
    }
}
