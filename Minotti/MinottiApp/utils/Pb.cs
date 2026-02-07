using System.Globalization;

namespace Minotti.utils
{
    /// <summary>
    /// Helpers mínimos para emular patrones de PB usados en estos objetos.
    /// </summary>
    internal static class Pb
    {
        public static string Cut(ref string source, string sep)
        {
            source ??= string.Empty;
            sep ??= string.Empty;
            if (source.Length == 0) return string.Empty;

            int idx = source.IndexOf(sep, StringComparison.Ordinal);
            if (idx < 0)
            {
                string all = source;
                source = string.Empty;
                return all;
            }

            string left = source.Substring(0, idx);
            source = source.Substring(idx + sep.Length);
            return left;
        }

        public static string PBString(object? value)
        {
            if (value == null) return string.Empty;
            if (value is DateTime dt) return dt.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            if (value is IFormattable f) return f.ToString(null, CultureInfo.InvariantCulture);
            return Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty;
        }

        public static int PBInt(object? value)
        {
            if (value == null) return 0;
            if (value is int i) return i;
            if (value is long l) return (int)l;
            if (value is decimal d) return (int)d;
            if (value is double db) return (int)db;
            if (int.TryParse(PBString(value), NumberStyles.Any, CultureInfo.InvariantCulture, out int r)) return r;
            return 0;
        }

        public static long PBLong(object? value)
        {
            if (value == null) return 0L;
            if (value is long l) return l;
            if (value is int i) return i;
            if (value is decimal d) return (long)d;
            if (value is double db) return (long)db;
            if (long.TryParse(PBString(value), NumberStyles.Any, CultureInfo.InvariantCulture, out long r)) return r;
            return 0L;
        }

        public static bool IsNullOrEmpty(string? s) => string.IsNullOrWhiteSpace(s);

        public static DateTime Today() => DateTime.Today;
        public static DateTime Now() => DateTime.Now;
        public static DateTime DateTimeFrom(DateTime date, DateTime time) => date.Date + time.TimeOfDay;

        public static bool IsValid(object? obj)
        {
            if (obj == null)
                return false;

            if (obj is datawindow dw)
                return !dw.IsDestroyed;

            return true;
        }
    }
}
