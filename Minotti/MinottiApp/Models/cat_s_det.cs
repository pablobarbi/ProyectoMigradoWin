using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: cat_s_det.sru (nonvisualobject, autoinstantiate)
    // Se mantienen los nombres de tipo y miembros tal cual.
    public class cat_s_det : IDisposable
    {
        // Variables públicas
        public string[] s_det { get; set; } = Array.Empty<string>();

        // on cat_s_det.create -> TriggerEvent(this, "constructor")
        public cat_s_det()
        {
            constructor();
        }

        // on cat_s_det.destroy -> TriggerEvent(this, "destructor")
        ~cat_s_det()
        {
            try { destructor(); } catch { /* ignore */ }
        }

        // Eventos PB emulados por nombre
        public void constructor()
        {
            // (sin lógica en SRU)
        }

        public void destructor()
        {
            // (sin lógica en SRU)
        }

        public void Dispose()
        {
            destructor();
            GC.SuppressFinalize(this);
        }
    }
}
