using Minotti.Metadata;

namespace MinottiApp.Metadata
{
    /// <summary>
    /// Metadata vacío (PB-like).
    /// Se usa cuando el DataObject no existe para NO romper el circuito.
    /// </summary>
    internal sealed class EmptyMetadata : IDataWindowMetadata
    {
        public static readonly EmptyMetadata Instance = new EmptyMetadata();

        private EmptyMetadata() { }

        public string DataObject => string.Empty;

        public List<DataWindowColumn> Columns { get; }
            = new List<DataWindowColumn>();

        public string Sql => string.Empty;
        public string Update => string.Empty;
        public int UpdateWhere => 0;
        public bool UpdateKeyInPlace => false;

        public string[] Estilos => Array.Empty<string>();
        public string[] SeleccionFila => Array.Empty<string>();
        public string Operaciones => string.Empty;
        public bool UsaUsuario => false;
        public bool UsaFecha => false;
    }
}
