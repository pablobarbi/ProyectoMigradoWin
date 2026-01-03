namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente PowerBuilder: cat_error_db (nonvisualobject autoinstantiate)
    /// </summary>
    public class cat_error_db
    {
        internal string sqlname;
        internal int coderror;
        internal string sqlerror;
        internal string mensaje;
        internal string servidor;
        internal int posicion;
        internal int renglon;

        // Integer sqldbcode    /* Nro de Error */
        public int? sqldbcode { get; set; }

        // String sqlerrtext   /* Descripcion del Error */
        public string sqlerrtext { get; set; } = string.Empty;

        // Integer UserErrorCode       /* Codigo de error personalizado */
        public int? UserErrorCode { get; set; }

        // String UserErrorText        /* Texto personalizado de error */
        public string UserErrorText { get; set; } = string.Empty;

       // === agregado solo para compatibilidad de uso en C# ===
        public int? linea { get; set; } 

        // ---- Alias en PascalCase para coincidir con el uso SqlDbCode / SqlErrText ----
        public int? SqlDbCode
        {
            get => (int)sqldbcode;
            set => sqldbcode = value;
        }

        public string SqlErrText
        {
            get => sqlerrtext;
            set => sqlerrtext = value;
        }

        public cat_error_db()
        {
        }
    }
}
