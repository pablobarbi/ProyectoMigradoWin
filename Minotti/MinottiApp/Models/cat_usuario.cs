using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: cat_usuario.sru
    // $PBExportComments$Clase con los datos de un usuario.
    // Se mantienen los nombres de tipo y miembros tal cual.

    public class cat_usuario : IDisposable
    {
        // ------------------------------------------------------------
        // Variables públicas (type variables / Public:)
        // ------------------------------------------------------------
        public string Usuario { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Perfil { get; set; } = string.Empty;

        // En PB: datetime Fecha_Coneccion
        public DateTime? Fecha_Coneccion { get; set; }

        // ------------------------------------------------------------
        // Emulación de create/destroy de PB
        // on cat_usuario.create  -> TriggerEvent( this, "constructor" )
        // on cat_usuario.destroy -> TriggerEvent( this, "destructor" )
        // ------------------------------------------------------------
        public cat_usuario()
        {
            constructor();
        }

        ~cat_usuario()
        {
            try { destructor(); } catch { /* ignore */ }
        }

        // Eventos PB emulados por nombre (vacíos porque el SRU no define lógica)
        public void constructor()
        {
            // (sin lógica definida en el SRU original)
        }

        public void destructor()
        {
            // (sin lógica definida en el SRU original)
        }

        // ------------------------------------------------------------
        // Soporte IDisposable
        // ------------------------------------------------------------
        public void Dispose()
        {
            destructor();
            GC.SuppressFinalize(this);
        }
    }
}
