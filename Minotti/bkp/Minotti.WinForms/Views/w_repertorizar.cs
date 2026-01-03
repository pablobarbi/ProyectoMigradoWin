using System;
using System.Data;
using System.Windows.Forms;
namespace Minotti
{
    public partial class w_repertorizar : Form
    {
        public int il_Modo { get; set; } = 0;
        public string Dsn { get; set; } = string.Empty;
        public w_repertorizar()
        {
            InitializeComponent();
            this.cb_borrar.Click += (s, e) => cb_borrar_clicked();
        }
        public void cb_borrar_clicked()
        {
            long ll_Orden = 0;
            if (dw_1.CurrentRow >= 0) ll_Orden = dw_1.CurrentRow + 1;
            var dr = MessageBox.Show($"Esta seguro que desea borrar el síntoma de orden: {ll_Orden}",
                                     "Borrar Síntoma",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;
        }
        public void uo_redibujar_y_acomodar()
        {
            this.il_Modo = 2;
            if (dw_3.DataSource is not DataTable dt3)
            {
                dt3 = new DataTable();
                dt3.Columns.Add("col", typeof(string));
                dw_3.DataSource = dt3;
            }
            var r = dt3.NewRow();
            dt3.Rows.InsertAt(r, 0);
        }
    }
}