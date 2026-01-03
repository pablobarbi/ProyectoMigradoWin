// Minotti/Functions/f_global_replace.cs
using System;
using System.Text;

namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_global_replace.srf
    /// Firma esperada en PB: global function string f_global_replace (string as_source, string as_old, string as_new)
    /// Mantengo el nombre del archivo, clase y método.
    /// </summary>
    public static class f_global_replace
    {
        /// <summary>
        /// Reemplaza TODAS las apariciones de 'as_old' por 'as_new' en 'as_source' (búsqueda ordinal, sensible a mayúsculas).
        /// Si 'as_old' es vacío, devuelve 'as_source' sin cambios (evita bucle infinito).
        /// </summary>
        public static string fglobal_replace(string as_source, string as_old, string as_new)
        {
            as_source ??= string.Empty;
            as_old    ??= string.Empty;
            as_new    ??= string.Empty;

            if (as_old.Length == 0)
                return as_source;

            var src = as_source;
            var oldVal = as_old;
            var newVal = as_new;

            var sb = new StringBuilder(src.Length + Math.Max(0, newVal.Length - oldVal.Length) * 4);
            int idx = 0;
            while (true)
            {
                int pos = src.IndexOf(oldVal, idx, StringComparison.Ordinal);
                if (pos < 0)
                {
                    sb.Append(src, idx, src.Length - idx);
                    break;
                }
                sb.Append(src, idx, pos - idx);
                sb.Append(newVal);
                idx = pos + oldVal.Length;
            }
            return sb.ToString();
        }
    }
}
