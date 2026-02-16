namespace Minotti.Metadata.GeneratedSru
{
    /// <summary>
    /// PB: cat_error_db (nonvisualobject autoinstantiate)
    /// Contiene datos de error producidos en la Base de Datos
    /// </summary>
    public class cat_error_db : nonvisualobject
    {
        // =========================
        // PB: type variables
        // =========================

        /// <summary>
        /// PB: sqldbcode – Código de error de base de datos
        /// </summary>
        public int? SqlDbCode;

        /// <summary>
        /// PB: sqlerrtext – Texto del error de base
        /// </summary>
        public string? SqlErrText;

        /// <summary>
        /// PB: UserErrorCode – Código de error personalizado
        /// </summary>
        public int? UserErrorCode;

        /// <summary>
        /// PB: UserErrorText – Texto personalizado de error
        /// </summary>
        public string? UserErrorText;

        // =========================
        // PB: on create
        // =========================
        public override void create()
        {
            // PB: TriggerEvent( this, "constructor" )
            constructor();
        }

        // =========================
        // PB: on destroy
        // =========================
        public override void destroy()
        {
            // PB: TriggerEvent( this, "destructor" )
            destructor();
        }

        // =========================
        // PB: constructor / destructor
        // =========================
        public override void constructor()
        {
            // sin lógica en PB
        }

        public override void destructor()
        {
            // sin lógica en PB
        }
    }
}
