using System;
using System.Data;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PB Window 'w_ver_reperto_bak' (deriva de w_abm_detalle).
    /// Se preservan nombres y se integra la lógica visible del SRW sin inventar.
    /// </summary>
    public partial class w_ver_reperto_bak : Form
    {
        /// <summary>
        /// Dataset equivalente a 'ds_detalle_sintomas' referenciado en el SRW.
        /// En PB se hacen operaciones RowCount/DeleteRow; aquí lo modelamos como DataTable.
        /// </summary>
        public DataTable ds_detalle_sintomas { get; set; } = new DataTable("ds_detalle_sintomas");

        /// <summary>Flag PB para commit/rollback</summary>
        public bool ib_grabar { get; set; } = true;

        public w_ver_reperto_bak()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Port literal del bucle PB:
        /// FOR ll_Fila = ds_detalle_sintomas.RowCount() TO 1
        ///     ds_detalle_sintomas.DeleteRow(0)
        /// NEXT
        /// </summary>
        public void uo_limpiar_ds_detalle_sintomas()
        {
            if (ds_detalle_sintomas == null) return;
            // Emula "borrar siempre el primer registro hasta vaciar"
            while (ds_detalle_sintomas.Rows.Count > 0)
            {
                ds_detalle_sintomas.Rows.RemoveAt(0);
            }
        }

        /// <summary>
        /// Port literal del bloque:
        /// If ib_grabar Then
        ///     If dw_medicamentos.Update(TRUE, TRUE) <> 1 Then ib_grabar = FALSE
        ///     If dw_sintomas.Update(TRUE, TRUE) <> 1 Then ib_grabar = FALSE
        ///     If dw_1.Update(TRUE, TRUE) <> 1 Then ib_grabar = FALSE
        ///     If ds_detalle_sintomas.Update(TRUE, TRUE) <> 1 Then ib_grabar = FALSE
        /// End If
        /// En WinForms no hay DataWindow.Update; modelamos 'Update==1' como éxito de EndEdit sin excepción.
        /// </summary>
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
                // Finaliza edición en curso para emular persistencia local; no se inventa I/O a BD aquí.
                if (dw.IsCurrentCellInEditMode) dw.EndEdit();
                var cm = dw.BindingContext[dw.DataSource] as CurrencyManager;
                cm?.EndCurrentEdit();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        private int UpdateDataTable(DataTable dt)
        {
            try
            {
                if (dt == null) return 0;
                // No hay operación I/O aquí; se asume '1' como éxito de finalización de cambios en memoria.
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}