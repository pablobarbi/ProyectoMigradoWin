using Minotti.Models;
using System;

namespace Minotti.Catalog
{
    /// <summary>
    /// Migración de PowerBuilder: cat_impresion.sru (nonvisualobject, autoinstantiate).
    /// Mantiene nombres de variables y expone eventos 'constructor' y 'destructor'
    /// para emular los TriggerEvent del ciclo de vida PB.
    /// </summary>
    public class cat_impresion : IDisposable
    {
        // === Variables PB (mismos nombres) ===
        // uo_ds ids_impresion  /* Datastore que contiene el reporte a imprimir. */
        public uo_ds? ids_impresion { get; set; }

        // integer ii_cantidad_impresiones = 0  /* Cantidad de copias */
        public int ii_cantidad_impresiones { get; set; } = 0;

        // === Eventos PB emulados ===
        public event EventHandler? constructor;
        public event EventHandler? destructor;

        public cat_impresion()
        {
            // TriggerEvent(this, "constructor")
            try { constructor?.Invoke(this, EventArgs.Empty); } catch { /* silencioso */ }
        }

        // Patrón Dispose para mapear 'destroy' y disparar 'destructor'
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // recursos administrados (si los hubiera)
                }
                try { destructor?.Invoke(this, EventArgs.Empty); } catch { }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~cat_impresion()
        {
            Dispose(false);
        }
    }
}
