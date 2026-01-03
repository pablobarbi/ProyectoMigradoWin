
using System;
using System.Data;
using System.Windows.Forms;

namespace Minotti
{
    public partial class w_agregar_capitulos : Form
    {
        public w_agregar_capitulos()
        {
            InitializeComponent();
        }

        private void w_agregar_capitulos_Load(object sender, EventArgs e)
        {
            var dt = d_agregar_capitulos.Retrieve();
            this.dw_1.DataSource = dt;
            // Columnas detectadas desde el SELECT
            if (!this.dw_1.Columns.Contains("nombre")) this.dw_1.Columns.Add("nombre", "nombre");
        }
    }
}
