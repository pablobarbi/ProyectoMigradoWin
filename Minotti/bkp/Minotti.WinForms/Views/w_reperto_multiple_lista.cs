using System;
using System.Windows.Forms;
namespace Minotti
{
    public partial class w_reperto_multiple_lista : Form
    {
        public w_reperto_multiple_lista()
        {
            InitializeComponent();
            this.pb_reperto.Click += (s, e) => pb_reperto_clicked();
        }
        public void pb_reperto_clicked()
        {
            var opcion = 0;
            if (opcion != 1)
                MessageBox.Show("Las modificaciones no se guardaron.", "Repertorización", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}