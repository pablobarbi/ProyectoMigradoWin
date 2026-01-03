using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PB Window 'w_repertorizar' (deriva de w_carga).
    /// Se preservan nombres y se integra la lógica visible del SRW sin inventar.
    /// </summary>
    public partial class w_repertorizar : Form
    {
        /// <summary>Flags PB</summary>
        public int il_Modo { get; set; } = 0;

        /// <summary>DSN ODBC (SQL Anywhere 9) para emular USING SQLCA</summary>
        public string Dsn { get; set; } = string.Empty;

        public w_repertorizar()
        {
            InitializeComponent();

            // Cableado del click de 'cb_borrar' al bloque visible con confirmación.
            this.cb_borrar.Click += (s, e) => cb_borrar_clicked();
        }

        /// <summary>
        /// Port literal del bloque visible en SRW:
        /// MessageBox("Borrar Síntoma", "Esta seguro que desea borrar el síntoma de orden: " + String(ll_Orden)
        /// </summary>
        public void cb_borrar_clicked()
        {
            long ll_Orden = 0;
            if (dw_1.CurrentRow >= 0) ll_Orden = dw_1.CurrentRow + 1;
            var dr = MessageBox.Show($"Esta seguro que desea borrar el síntoma de orden: {ll_Orden}",
                                     "Borrar Síntoma",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            // El SRW no muestra aquí los DELETE explícitos; si aparecen en otro bloque, los integro literal.
        }

        /// <summary>
        /// Port literal del bloque ELSE visible:
        /// ELSE
        ///   il_Modo = 2
        ///   dw_3.InsertRow(0)
        ///   Parent.TriggerEvent("ue_acomodar_objetos")
        /// END IF
        /// </summary>
        public void uo_redibujar_y_acomodar()
        {
            this.il_Modo = 2;
            if (dw_3.DataSource is not DataTable dt3)
            {
                dt3 = new DataTable();
                dt3.Columns.Add("fecha", typeof(DateTime));
                dw_3.DataSource = dt3;
            }
            var r = dt3.NewRow();
            // En el SRW no setean fecha aquí, sólo insertan fila. Agregamos fila al inicio para emular InsertRow(0).
            dt3.Rows.InsertAt(r, 0);

            // Parent.TriggerEvent("ue_acomodar_objetos"): sin equivalente directo; documentamos la intención.
        }
    }
}