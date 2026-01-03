
using System;
using System.Data;
using System.Windows.Forms;

namespace Minotti
{
    public partial class w_agregar_subrubricas : Form
    {
        public w_agregar_subrubricas()
        {
            InitializeComponent();
        }

        private void w_agregar_subrubricas_Load(object sender, EventArgs e)
        {
            var dt = d_agregar_subrubricas.Retrieve();
            this.dw_1.DataSource = dt;
            // Columnas detectadas desde el SELECT
            if (!this.dw_1.Columns.Contains("nombre")) this.dw_1.Columns.Add("nombre", "nombre");
        }
    }
}
