using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: cat_tamaño - copia.sru (nonvisualobject, autoinstantiate)
    // Se mantienen los nombres internos y miembros tal cual (incluye "ñ").
    public class cat_tamaño : IDisposable
    {
        public int largo { get; set; }
        public int ancho { get; set; }
        public int borde { get; set; }

        // on cat_tamaño.create -> TriggerEvent(this, "constructor")
        public cat_tamaño()
        {
            constructor();
        }

        // on cat_tamaño.destroy -> TriggerEvent(this, "destructor")
        ~cat_tamaño()
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

        // Subrutina pública preservando firma: public subroutine uof_copiaren (ref cat_tamaño copia)
        public void uof_copiaren(ref cat_tamaño copia)
        {
            if (copia == null) copia = new cat_tamaño();
            copia.largo = this.largo;
            copia.ancho = this.ancho;
            copia.borde = this.borde;
        }

        public void Dispose()
        {
            destructor();
            GC.SuppressFinalize(this);
        }
    }
}
