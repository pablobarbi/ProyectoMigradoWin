using System;
using System.Windows.Forms;

namespace Minotti.UserObjects
{
    /// <summary>
    /// Migración de PowerBuilder: c_class.sru (nonvisualobject autoinstantiate)
    /// - Mantengo el nombre de la clase: c_class
    /// - Evento/ método: one_event(string messageStringParm) -> muestra MessageBox("c_class.one_event()", messageStringParm)
    /// - "on create" -> TriggerEvent("constructor")
    /// - "on destroy" -> TriggerEvent("destructor")
    /// </summary>
    public class c_class : IDisposable
    {
        /// <summary>Eventos equivalentes a PB: constructor / destructor</summary>
        public event EventHandler? constructor;
        public event EventHandler? destructor;

        /// <summary>
        /// Emula TriggerEvent(this, "..."). Acepta "constructor", "destructor" y "one_event".
        /// Para "one_event" puede pasarse stringParm (texto del mensaje).
        /// </summary>
        public void TriggerEvent(string eventName, string? stringParm = null)
        {
            switch ((eventName ?? string.Empty).ToLowerInvariant())
            {
                case "constructor":
                    constructor?.Invoke(this, EventArgs.Empty);
                    break;
                case "destructor":
                    destructor?.Invoke(this, EventArgs.Empty);
                    break;
                case "one_event":
                    one_event(stringParm ?? string.Empty);
                    break;
            }
        }

        /// <summary>
        /// PB: event one_event(); MessageBox('c_class.one_event()', message.StringParm)
        /// En .NET recibimos el texto como parámetro y mostramos el mismo MessageBox.
        /// </summary>
        public void one_event(string messageStringParm)
        {
            MessageBox.Show(messageStringParm, "c_class.one_event()");
        }

        /// <summary>PB: on c_class.create -> TriggerEvent(this, "constructor")</summary>
        public c_class()
        {
            TriggerEvent("constructor");
        }

        /// <summary>PB: on c_class.destroy -> TriggerEvent(this, "destructor")</summary>
        public void Dispose()
        {
            TriggerEvent("destructor");
            GC.SuppressFinalize(this);
        }

        ~c_class()
        {
            // Respaldo por si no se llamó Dispose()
            TriggerEvent("destructor");
        }
    }
}
