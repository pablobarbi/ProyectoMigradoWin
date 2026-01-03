using System;
using System.IO;
using System.Xml.Serialization;

namespace Minotti.Metadata
{
    /// <summary>
    /// Migración de: reportes.llat_dat
    /// Mantiene nombres de campos 1:1 con el XML LibraryLatestActionTracking.
    /// </summary>
    [XmlRoot("LibraryLatestActionTracking")]
    public class reportes_llat_dat
    {
        public int FileVersion { get; set; } = 1;

        public DateTime LayoutAdd { get; set; } = DateTime.Parse("2025-07-22T19:19:30.5878859Z");
        public DateTime LayoutModify { get; set; } = DateTime.Parse("2025-07-22T19:19:30.5878859Z");
        public DateTime LayoutDelete { get; set; } = DateTime.Parse("2025-07-22T19:19:30.5878859Z");

        public DateTime ScriptableAdd { get; set; } = DateTime.Parse("2025-07-22T19:19:30.5878859Z");
        public DateTime ScriptableModify { get; set; } = DateTime.Parse("2025-07-22T19:19:30.5878859Z");
        public DateTime ScriptableDelete { get; set; } = DateTime.Parse("2025-07-22T19:19:30.5878859Z" );

        public DateTime InternalResourceAdd { get; set; } = DateTime.Parse("2025-07-22T19:19:30.5878859Z");
        public DateTime InternalResourceModify { get; set; } = DateTime.Parse("2025-07-22T19:19:30.5878859Z");
        public DateTime InternalResourceDelete { get; set; } = DateTime.Parse("2025-07-22T19:19:30.5878859Z");

        /// <summary>Carga desde un archivo XML (misma estructura).</summary>
        public static reportes_llat_dat Load(string path)
        {
            var ser = new XmlSerializer(typeof(reportes_llat_dat));
            using var fs = File.OpenRead(path);
            return (reportes_llat_dat)ser.Deserialize(fs);
        }

        /// <summary>Guarda a un archivo XML (misma estructura y nombres).</summary>
        public void Save(string path)
        {
            var ser = new XmlSerializer(typeof(reportes_llat_dat));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty); // sin namespaces
            using var fs = File.Create(path);
            ser.Serialize(fs, this, ns);
        }
    }
}
