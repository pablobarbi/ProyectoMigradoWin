using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: cat_response_abm.sru (nonvisualobject, autoinstantiate)
    // Se mantienen los nombres de tipo y miembros tal cual.
    public class cat_response_abm : IDisposable
    {
        // Public: variables
        // uo_dw dw_1  // datawindow que va hacer sharedata
        public uo_dw dw_1 { get; set; } = new uo_dw();

        // string param  // parametros para abrir la nueva datawindow
        public string param { get; set; } = string.Empty;

        // string claves[]   // Claves por si se va a agregar un nuevo registro
        public string[] claves { get; set; } = Array.Empty<string>();

        // on cat_response_abm.create -> TriggerEvent(this, "constructor")
        public cat_response_abm()
        {
            constructor();
        }

        // on cat_response_abm.destroy -> TriggerEvent(this, "destructor")
        ~cat_response_abm()
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

        // Stub mínimo del tipo uo_dw para permitir compilar manteniendo el nombre de tipo
        public class uo_dw
        {
        }

        public void Dispose()
        {
            destructor();
            GC.SuppressFinalize(this);
        }
    }
}
