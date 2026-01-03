using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: cat_response.sru (nonvisualobject, autoinstantiate)
    // Se mantienen los nombres de tipo y miembros tal cual.
    public class cat_response : IDisposable
    {
        // Variables públicas
        // valor de retorno a la ventana que la llamó (1 eligió algo, -1 si no eligió nada)
        public int retorno { get; set; }

        // on cat_response.create -> TriggerEvent(this, "constructor")
        public cat_response()
        {
            constructor();
        }

        // on cat_response.destroy -> TriggerEvent(this, "destructor")
        ~cat_response()
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
