namespace Minotti.Functions
{
    /// <summary>
    /// Utilidad equivalente a f_string_a_boolean de PB.
    /// Mantengo el nombre base y proveo método de ayuda.
    /// </summary>
    public static class f_string_a_boolean
    {
        public static bool fcargar_bool(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            s = s.Trim().ToUpperInvariant();
            return s is "S" or "Y" or "1" or "T" or "TRUE" or "SI";
        }
    }
}
