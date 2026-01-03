using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: cat_string.sru (nonvisualobject, autoinstantiate)
    // Se mantienen los nombres de tipo y miembros tal cual.
    public class cat_string : IDisposable
    {
        // String que contiene el campo en la dw
        public string @string { get; set; } = string.Empty;

        // Longitud del String
        public int longitud { get; set; }

        // Titulo del Campo en la Datawindow
        public string texto_titulo { get; set; } = string.Empty;

        // Codigo de Retorno de la Ventana
        public int retorno { get; set; }

        // on cat_string.create -> TriggerEvent(this, "constructor")
        public cat_string()
        {
            constructor();
        }

        // on cat_string.destroy -> TriggerEvent(this, "destructor")
        ~cat_string()
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
