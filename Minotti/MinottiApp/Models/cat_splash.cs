using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: cat_splash.sru (from cat_app)
    // Se mantienen los nombres de tipo y miembros tal cual.
    public class cat_splash : cat_app, IDisposable
    {
        // Variables públicas
        public int segundos { get; set; }

        // on cat_splash.create -> (hereda constructor de base y dispara constructor())
        public cat_splash() : base()
        {
        }

        // on cat_splash.destroy -> TriggerEvent(this, "destructor")
        ~cat_splash()
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
