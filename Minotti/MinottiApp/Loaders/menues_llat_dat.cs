using System.IO;
using System.Xml.Serialization;
using Minotti.Models;

namespace Minotti.Loaders
{
    /// <summary>
    /// Cargador para el archivo 'menues.llat_dat' (PowerBuilder) manteniendo el nombre base.
    /// </summary>
    public static class menues_llat_dat
    {
        /// <summary>Ruta por defecto dentro del proyecto.</summary>
        public const string DefaultPath = "PowerBuilderMeta/menues.llat_dat";

        /// <summary>Lee y deserializa el XML a LibraryLatestActionTracking desde la ruta por defecto.</summary>
        public static LibraryLatestActionTracking Load() => Load(DefaultPath);

        /// <summary>Lee y deserializa el XML a LibraryLatestActionTracking desde una ruta específica.</summary>
        public static LibraryLatestActionTracking Load(string path)
        {
            using var fs = File.OpenRead(path);
            var xs = new XmlSerializer(typeof(LibraryLatestActionTracking));
            return (LibraryLatestActionTracking)xs.Deserialize(fs)!;
        }
    }
}
