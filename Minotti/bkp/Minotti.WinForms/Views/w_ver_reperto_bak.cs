using System;
using System.Data;
using System.Windows.Forms;
namespace Minotti
{
    public partial class w_ver_reperto_bak : Form
    {
        public DataTable ds_detalle_sintomas { get; set; } = new DataTable("ds_detalle_sintomas");
        public bool ib_grabar { get; set; } = true;
        public w_ver_reperto_bak(){ InitializeComponent(); }
        public void uo_limpiar_ds_detalle_sintomas()
        {
            if (ds_detalle_sintomas == null) return;
            while (ds_detalle_sintomas.Rows.Count > 0) ds_detalle_sintomas.Rows.RemoveAt(0);
        }
        public void uo_actualizar_si_graba()
        {
            if (!ib_grabar) return;
            if (UpdateDW(dw_medicamentos) != 1) ib_grabar = false;
            if (UpdateDW(dw_sintomas) != 1) ib_grabar = false;
            if (UpdateDW(dw_1) != 1) ib_grabar = false;
            if (UpdateDataTable(ds_detalle_sintomas) != 1) ib_grabar = false;
        }
        private int UpdateDW(DataGridView dw)
        {
            try
            {
                if (dw == null) return 0;
                if (dw.IsCurrentCellInEditMode) dw.EndEdit();
                var cm = dw.BindingContext[dw.DataSource] as CurrencyManager;
                cm?.EndCurrentEdit();
                return 1;
            } catch { return 0; }
        }
        private int UpdateDataTable(DataTable dt) { return dt != null ? 1 : 0; }
    }
}