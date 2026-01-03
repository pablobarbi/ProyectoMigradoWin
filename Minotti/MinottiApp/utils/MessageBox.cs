using System.Windows.Forms;

namespace Minotti.utils
{
    public static class MessageBoxPB
    {
        public static long MessageBox(string title, string text)
        {
            System.Windows.Forms.MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return 1;
        }

        public static long MessageBox(string title, string text, MessageBoxIcon icon, MessageBoxButtons buttons)
        {
            var dr = System.Windows.Forms.MessageBox.Show(text, title, buttons, icon);
            // En PB típicamente: 1=OK/Yes, 2=Cancel/No (depende botones)
            return dr == DialogResult.OK || dr == DialogResult.Yes ? 1 : 2;
        }

        public static long MessageBox(string title, string text, MessageBoxIcon icon)
        {
            var dr = System.Windows.Forms.MessageBox.Show(
                text,
                title,
                MessageBoxButtons.OK,
                icon);

            // PB-like: 1 = OK/Yes, 2 = Cancel/No
            return (dr == DialogResult.OK || dr == DialogResult.Yes) ? 1 : 2;
        }

        public static long MessageBox(string text,string title,MessageBoxButtons buttons,
                                      MessageBoxIcon icon,MessageBoxDefaultButton defaultButton)
        {
            var dr = System.Windows.Forms.MessageBox.Show(
                text,
                title,
                buttons,
                icon,
                defaultButton);

            // PB-like:
            // OK / Yes  -> 1
            // Cancel / No -> 2
            return (dr == DialogResult.OK || dr == DialogResult.Yes) ? 1 : 2;
        }

    }
}
