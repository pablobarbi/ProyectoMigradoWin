using Minotti.utils;
using Minotti.Views.Basicos.Models;
using MinottiApp.utils;

namespace Minotti.Views.Menues.Controls
{
    // forward/global type c_class from nonvisualobject
    public partial class c_class : nonvisualobject
    {
        // PB: autoinstantiate
        // En PB se autoinstancia a nivel runtime.
        // En C# lo emulamos con Instance (si no lo necesitás, podés ignorarlo).
        private static c_class? _instance;
        public static c_class Instance => _instance ??= new c_class();

        // PB: event one_event ( )
        public virtual void one_event()
        {
            string ls_pointer;

            // ls_pointer = String( message.LongParm, "address" )
            // (comentado en PB, lo dejamos comentado igual)

            MessageBoxPB.MessageBox("c_class.one_event()", utils.Message.StringParm ?? string.Empty);
        }

        // on c_class.create -> TriggerEvent(this, "constructor")
        public c_class()
        {
            DynamicEventInvoker.Trigger(this, "constructor");
        }

        // on c_class.destroy -> TriggerEvent(this, "destructor")
        ~c_class()
        {
            DynamicEventInvoker.Trigger(this, "destructor");
        }

        // PB: constructor/destructor (no estaban en el source, pero PB los dispara igual)
        // Los dejamos como "hooks" para que si existen en tu base, puedan resolverse.
        public virtual void constructor() { }
        public virtual void destructor() { }
    }
}
