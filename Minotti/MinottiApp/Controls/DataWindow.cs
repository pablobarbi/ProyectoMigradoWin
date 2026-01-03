namespace Minotti.Controls
{
    /// <summary>
    /// Stub mínimo para emular el DataWindow de PowerBuilder.
    /// Expone 'Syntax' y el acceso 'Object.DataWindow.Syntax' para compatibilidad.
    /// </summary>
    public class DataWindow
    {
        public class DataWindowInner
        {
            public string? Syntax { get; set; }
        }

        public class DataWindowObject
        {
            public DataWindowInner DataWindow { get; } = new DataWindowInner();
        }

        /// <summary>Acceso estilo PB: dw.Object.DataWindow.Syntax</summary>
        public DataWindowObject Object { get; } = new DataWindowObject();

        /// <summary>Atajo directo: dw.Syntax (sin pasar por Object)</summary>
        public string? Syntax
        {
            get => Object.DataWindow.Syntax;
            set => Object.DataWindow.Syntax = value;
        }

        public DataWindow() { }
        public DataWindow(string? syntax) { Syntax = syntax; }
    }
}
