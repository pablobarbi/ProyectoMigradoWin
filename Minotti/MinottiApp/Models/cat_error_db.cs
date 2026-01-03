namespace Minotti
{
    /// <summary>
    /// Estructura que contiene datos sobre el error producido en la Base de Datos.
    /// Migración de PowerBuilder: cat_error_db (nonvisualobject).
    /// </summary>
    public class cat_error_db
    {
        internal string sqlname;
        internal int coderror;
        internal string sqlerror;
        internal int linea;
        internal int renglon;
        internal int posicion;
        internal string mensaje;
        internal string servidor;

        // Utilizado cuando ocurre un error al grabar en la Base de Datos

        /// <summary>
        /// Nro de Error (SQLCA.SqlCode / sqldbcode)
        /// </summary>
        public int? sqldbcode { get; set; }

        /// <summary>
        /// Descripción del error (SQLCA.SqlErrText / sqlerrtext)
        /// </summary>
        public string sqlerrtext { get; set; } = string.Empty;

        /// <summary>
        /// Código de error personalizado
        /// </summary>
        public int? UserErrorCode { get; set; }

        /// <summary>
        /// Texto personalizado de error
        /// </summary>
        public string UserErrorText { get; set; } = string.Empty;
    }
}
