using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.utils
{
    public static class PBLog
    {
        private static readonly object _lock = new();
        private static readonly string _file =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pb_startup.log");

        public static void Write(string message)
        {
            lock (_lock)
            {
                File.AppendAllText(
                    _file,
                    $"{DateTime.Now:HH:mm:ss.fff} | {message}{Environment.NewLine}"
                );
            }
        }
    }
}
