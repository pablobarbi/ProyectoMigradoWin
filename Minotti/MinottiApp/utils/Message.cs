 

namespace Minotti.utils
{
    /// <summary>
    /// Emula el objeto global PB: Message
    /// Se usa para pasar parámetros a eventos/ventanas (StringParm, PowerObjectParm, etc.).
    /// </summary>
    public static class Message
    {
        public static string StringParm { get; set; } = string.Empty;
        public static int IntegerParm { get; set; }
        public static long LongParm { get; set; }
        public static double DoubleParm { get; set; }
        public static decimal DecimalParm { get; set; }
        public static object? PowerObjectParm { get; set; }
    }
}
