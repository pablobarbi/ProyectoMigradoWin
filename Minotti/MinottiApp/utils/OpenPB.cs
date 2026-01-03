using System;
using System.Windows.Forms;

namespace Minotti.utils
{
    public static class OpenPB
    {
        /// <summary>
        /// PB: Open(window)
        /// </summary>
        public static int Open(Form? frm)
        {
            try
            {
                if (frm == null) return -1;

                frm.Show();
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// PB: Open(DataWindow child / object) - overload por tipo
        /// </summary>
        public static int Open(Type? formType)
        {
            try
            {
                if (formType == null) return -1;
                if (!typeof(Form).IsAssignableFrom(formType)) return -1;

                var frm = (Form?)Activator.CreateInstance(formType);
                if (frm == null) return -1;

                frm.Show();
                return 1;
            }
            catch
            {
                return -1;
            }
        }
    }
}
