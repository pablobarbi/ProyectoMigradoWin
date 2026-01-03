using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: cat_seleccion_row.sru (nonvisualobject, autoinstantiate)
    // Se mantienen los nombres de tipo y miembros tal cual.
    public class cat_seleccion_row : IDisposable
    {
        // Variables públicas
        public string dataobject { get; set; } = string.Empty;
        public string valor_columna { get; set; } = string.Empty;
        public string tipo_columna { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public int valor_retorno { get; set; } = -1;

        // on cat_seleccion_row.create -> TriggerEvent(this, "constructor")
        public cat_seleccion_row()
        {
            constructor();
        }

        // on cat_seleccion_row.destroy -> TriggerEvent(this, "destructor")
        ~cat_seleccion_row()
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
