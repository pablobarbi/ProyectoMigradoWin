using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: cat_response_claves.sru (from cat_response)
    // Se mantienen los nombres de tipo y miembros tal cual.
    public class cat_response_claves : cat_response, IDisposable
    {
        // Public: variables
        public string[] claves { get; set; } = Array.Empty<string>();

        // on cat_response_claves.create -> (no hay lógica en SRU; se hereda constructor de base)
        public cat_response_claves() : base()
        {
            // Si en PB hubiera lógica de constructor específico, iría aquí.
        }

        // on cat_response_claves.destroy -> TriggerEvent(this, "destructor")
        ~cat_response_claves()
        {
            try { destructor(); } catch { /* ignore */ }
        }

        // El resto de la lógica se hereda de cat_response
        new public void Dispose()
        {
            destructor();
            GC.SuppressFinalize(this);
        }
    }
}
