using System;

namespace Minotti.Models
{
    // Migración directa de PowerBuilder: cat_app.sru (nonvisualobject, autoinstantiate)
    // Se mantienen los nombres de tipo y miembros tal cual.
    public class cat_app : IDisposable
    {
        // Public: variables (en PB eran variables públicas)
        public string Nombre { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Copyright { get; set; } = string.Empty;

        // on cat_app.create -> TriggerEvent(this, "constructor")
        public cat_app()
        {
            constructor();
        }

        // on cat_app.destroy -> TriggerEvent(this, "destructor")
        ~cat_app()
        {
            // Llamamos al "destructor" para emular el evento de PB
            try { destructor(); } catch { /* swallow */ }
        }

        // Eventos preservados por nombre para compatibilidad
        public void constructor()
        {
            // (vacío en SRU)
        }

        public void destructor()
        {
            // (vacío en SRU)
        }

        public void Dispose()
        {
            destructor();
            GC.SuppressFinalize(this);
        }
    }
}
