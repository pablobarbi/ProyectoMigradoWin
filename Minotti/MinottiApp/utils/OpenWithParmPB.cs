using System;
using System.Windows.Forms;

namespace Minotti.utils
{
    public static class OpenWithParmPB
    {
        // OpenWithParm(w_xxx, parm) -> crea y muestra el Form
        public static T OpenWithParm<T>(object? parm, bool modal = true) where T : Form, new()
        {
            // PB: si parm es string, también cae en Message.StringParm
            Message.PowerObjectParm = parm;
            Message.StringParm = parm as string;

            var frm = new T();

            if (modal)
                frm.ShowDialog();
            else
                frm.Show();

            return frm;
        }

        // Variante: pasar una instancia ya creada (por si tu "window" no tiene new())
        public static Form OpenWithParm(Form frm, object? parm, bool modal = true)
        {
            Message.PowerObjectParm = parm;
            Message.StringParm = parm as string;

            if (modal)
                frm.ShowDialog();
            else
                frm.Show();

            return frm;
        }

        public static Form OpenWithParm(Type formType, object? parm, bool modal = true)
        {
            Message.PowerObjectParm = parm;
            Message.StringParm = parm as string;

            if (!typeof(Form).IsAssignableFrom(formType))
                throw new ArgumentException("formType debe heredar de Form", nameof(formType));

            var frm = (Form)Activator.CreateInstance(formType)!;

            if (modal) frm.ShowDialog();
            else frm.Show();

            return frm;
        }

        public static Form Open(Type formType, object? parm)
        {
            // PB: Open(w_xxx, parm) ≈ OpenWithParm NO modal
            return OpenWithParm(formType, parm, modal: false);
        }

    }
}
