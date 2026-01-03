using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: cat_rw_seleccion.sru (nonvisualobject, autoinstantiate)
    // Se mantienen los nombres de tipo y miembros tal cual.
    public class cat_rw_seleccion : IDisposable
    {
        /* Var usada para setear la forma en que salió de la ventana
             1  -- Se cerró aceptando
            -1  -- Se canceló la selección */
        public int opcion { get; set; } = -1;

        /* Estructura que contiene las n filas seleccionadas en la dw */
        public cat_s_det[] atr { get; set; } = Array.Empty<cat_s_det>();

        // on cat_rw_seleccion.create -> TriggerEvent(this, "constructor")
        public cat_rw_seleccion()
        {
            constructor();
        }

        // on cat_rw_seleccion.destroy -> TriggerEvent(this, "destructor")
        ~cat_rw_seleccion()
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

        // Stub mínimo para respetar el tipo referenciado en el SRU
        public class cat_s_det
        {
        }

        public void Dispose()
        {
            destructor();
            GC.SuppressFinalize(this);
        }
    }
}
