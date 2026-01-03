using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: cat_return.sru (nonvisualobject, autoinstantiate)
    // Se mantienen los nombres de tipo y miembros tal cual.
    public class cat_return : IDisposable
    {
        /* Variables de Retorno de diferentes tipos */
        public bool rtn_boolean { get; set; }
        public int rtn_integer { get; set; }

        // ... (otras variables en SRU original)
        public string warning { get; set; } = string.Empty;

        /* En el caso de que ocurra un error se devolverá en 
           esta variable el codigo de error */
        public string codigo_error { get; set; } = string.Empty;

        /* Variable para setear otros valores */
        public string rtn_string { get; set; } = string.Empty;

        // on cat_return.create -> TriggerEvent(this, "constructor")
        public cat_return()
        {
            constructor();
        }

        // on cat_return.destroy -> TriggerEvent(this, "destructor")
        ~cat_return()
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
