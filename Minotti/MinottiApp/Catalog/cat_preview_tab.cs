using System;

namespace Minotti.Catalog
{
    /// <summary>
    /// Migración de PowerBuilder: cat_preview_tab.sru (nonvisualobject, autoinstantiate).
    /// Mantiene nombres de variables y emula los TriggerEvent("constructor"/"destructor").
    /// </summary>
    public class cat_preview_tab : IDisposable
    {
        // === Variables PB (mismos nombres) ===
        // string is_impresion
        public string? is_impresion { get; set; }

        // string is_parametros[]
        public string[] is_parametros { get; set; } = Array.Empty<string>();

        // === Eventos PB emulados ===
        public event EventHandler? constructor;
        public event EventHandler? destructor;

        public cat_preview_tab()
        {
            try { constructor?.Invoke(this, EventArgs.Empty); } catch { }
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // liberar recursos administrados si aplica
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

        ~cat_preview_tab()
        {
            Dispose(false);
        }
    }
}
