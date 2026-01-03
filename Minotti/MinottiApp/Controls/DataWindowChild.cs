using System.Data.Odbc;

namespace Minotti.Controls
{
    /// <summary>
    /// Stub para emular 'datawindowchild' de PowerBuilder.
    /// Incluye:
    ///  - SetTransObject / InsertRow (compatibilidad con funciones existentes)
    ///  - Syntax y Object.DataWindow.Syntax para análisis de argumentos
    /// </summary>
    public class DataWindowChild
    {
        public class DataWindowInner
        {
            public string? Syntax { get; set; }
        }

        public class DataWindowObject
        {
            public DataWindowInner DataWindow { get; } = new DataWindowInner();
        }

        /// <summary>Acceso estilo PB: dwc.Object.DataWindow.Syntax</summary>
        public DataWindowObject Object { get; } = new DataWindowObject();

        /// <summary>Atajo directo: dwc.Syntax (sin pasar por Object)</summary>
        public string? Syntax
        {
            get => Object.DataWindow.Syntax;
            set => Object.DataWindow.Syntax = value;
        }

        public OdbcConnection? Connection { get; private set; }

        /// <summary>Equivalente a SetTransObject(SQLCA) en PB.</summary>
        public void SetTransObject(OdbcConnection? cnn) => Connection = cnn;

        /// <summary>
        /// Inserta una fila (stub). Devuelve 1 como operación exitosa.
        /// </summary>
        public int InsertRow(int position) => 1;
    }
}
