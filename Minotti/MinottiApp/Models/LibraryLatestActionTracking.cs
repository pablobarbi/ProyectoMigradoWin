using System;
using System.Xml.Serialization;

namespace Minotti.Models
{
    /// <summary>
    /// Modelo que respeta los nombres internos del XML funcion.llat_dat
    /// (root: LibraryLatestActionTracking).
    /// </summary>
    [XmlRoot("LibraryLatestActionTracking")]
    public class LibraryLatestActionTracking
    {
        [XmlElement("FileVersion")]
        public int FileVersion { get; set; }

        [XmlElement("LayoutAdd")]
        public DateTime LayoutAdd { get; set; }

        [XmlElement("LayoutModify")]
        public DateTime LayoutModify { get; set; }

        [XmlElement("LayoutDelete")]
        public DateTime LayoutDelete { get; set; }

        [XmlElement("ScriptableAdd")]
        public DateTime ScriptableAdd { get; set; }

        [XmlElement("ScriptableModify")]
        public DateTime ScriptableModify { get; set; }

        [XmlElement("ScriptableDelete")]
        public DateTime ScriptableDelete { get; set; }

        [XmlElement("InternalResourceAdd")]
        public DateTime InternalResourceAdd { get; set; }

        [XmlElement("InternalResourceModify")]
        public DateTime InternalResourceModify { get; set; }

        [XmlElement("InternalResourceDelete")]
        public DateTime InternalResourceDelete { get; set; }
    }
}
