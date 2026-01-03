using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: cat_valor_inicial.sru (nonvisualobject, autoinstantiate)
    // Se mantienen los nombres de tipo y miembros tal cual.
    public class cat_valor_inicial : IDisposable
    {
        public string campo { get; set; } = string.Empty;
        public string valor_inicial { get; set; } = string.Empty;

        // on cat_valor_inicial.create -> TriggerEvent(this, "constructor")
        public cat_valor_inicial()
        {
            constructor();
        }

        // on cat_valor_inicial.destroy -> TriggerEvent(this, "destructor")
        ~cat_valor_inicial()
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
