
using System;
using System.Data;
using System.Windows.Forms;

namespace Minotti
{
    public partial class w_agregar_rubricas : Form
    {
        public w_agregar_rubricas()
        {
            InitializeComponent();
        }

        private void w_agregar_rubricas_Load(object sender, EventArgs e)
        {
            var dt = d_agregar_rubricas.Retrieve();
            this.dw_1.DataSource = dt;
            // Columnas detectadas desde el SELECT
            if (!this.dw_1.Columns.Contains("nombre")) this.dw_1.Columns.Add("nombre", "nombre");
        }
    }
}
