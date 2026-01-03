using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: cat_response_string.sru (from cat_response)
    // Se mantienen los nombres de tipo y miembros tal cual.
    public class cat_response_string : cat_response, IDisposable
    {
        // Public: variables
        // cadena que devuelve la ventana response
        public string cadena { get; set; } = string.Empty;

        // on cat_response_string.create -> (hereda comportamiento; se llama constructor base)
        public cat_response_string() : base()
        {
        }

        // on cat_response_string.destroy -> TriggerEvent(this, "destructor")
        ~cat_response_string()
        {
            try { destructor(); } catch { /* ignore */ }
        }

        new public void Dispose()
        {
            destructor();
            GC.SuppressFinalize(this);
        }
    }
}
