using System.IO;
using System.Xml.Serialization;
using Minotti.Models;

namespace Minotti.Loaders
{
    /// <summary>
    /// Cargador para el archivo PowerBuilder 'funcion.llat_dat' manteniendo el nombre base.
    /// </summary>
    public static class funcion_llat_dat
    {
        /// <summary>Ruta relativa por defecto dentro del proyecto.</summary>
        public const string DefaultPath = "PowerBuilderMeta/funcion.llat_dat";

        /// <summary>
        /// Deserializa el XML a LibraryLatestActionTracking desde la ruta por defecto.
        /// </summary>
        public static LibraryLatestActionTracking Load() => Load(DefaultPath);

        /// <summary>
        /// Deserializa el XML a LibraryLatestActionTracking desde una ruta específica.
        /// </summary>
        public static LibraryLatestActionTracking Load(string path)
        {
            using var fs = File.OpenRead(path);
            var xs = new XmlSerializer(typeof(LibraryLatestActionTracking));
            return (LibraryLatestActionTracking)xs.Deserialize(fs)!;
        }
    }
}
