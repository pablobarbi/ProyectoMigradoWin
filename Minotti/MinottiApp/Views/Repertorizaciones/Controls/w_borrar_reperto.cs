using Minotti.Data;
using Minotti.Repositories;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Abm.Controls;
using System.Windows.Forms;

namespace Minotti.Views.Repertorizaciones.Controls
{
    /// <summary>
    /// Migrado desde PowerBuilder Window 'w_borrar_reperto' (derivada de w_abm_lista_seleccion).
    /// No hay eventos/SQL en el SRW provisto; se porta el control 'dw_buscar' con el mismo nombre.
    /// </summary>
    public partial class w_borrar_reperto : w_abm_lista_seleccion
    {
        public w_borrar_reperto()
        {
            InitializeComponent();
        }

        // PB: event ue_borrar
        public override void ue_borrar()
        {
            /*
                ATENCION !!! ANCESTOR SCRIPT OVERRIDE !!!
            */

            long iAux;
            decimal ll_reperto;
            string ls_Seleccionado;

            is_Accion = "B";

            if (dw_1.RowCount() == 0)
                return;

            for (iAux = dw_1.RowCount(); iAux >= 1; iAux--)
            {
                ls_Seleccionado = dw_1.GetItemString(iAux, "seleccionado");
                ll_reperto = dw_1.GetItemDecimal(iAux, "reperto_parcial");

                if (ls_Seleccionado == "S")
                {
                    if (ib_grabar)
                    {
                        if (dw_1.DeleteRow(iAux) != 1)
                            ib_grabar = false;
                    }

                    if (ib_grabar)
                    {
                        if (dw_1.Update(true, true) != 1)
                            ib_grabar = false;
                    }

                    if (ib_grabar)
                    {
                        w_borrar_reperto_dal.DeleteRepertoParcial(ll_reperto);

                        if (SQLCA.SqlCode < 0)
                            ib_grabar = false;
                    }

                    if (ib_grabar)
                    {
                        // No se cierra al borrar
                        ib_cerrar_al_grabar = false;
                    }
                    else
                    {
                        dw_1.RowsMove(
                            1,
                            dw_1.DeletedCount(),
                            PBRowMoveMode.Delete,
                            dw_1,
                            (int)iAux,
                            dwbuffer.Primary);

                        dw_1.SetRow((int)iAux);
                    }
                }
            }
        }

        // PB: event ue_dw_button_clicked
        public override void ue_dw_button_clicked(object objeto)
        {
            base.ue_dw_button_clicked(objeto);

            long ll_Row;
            string ls_Seleccionado = null;

            string nombreObjeto = objeto?.GetType().GetProperty("name")?.GetValue(objeto)?.ToString();

            if (nombreObjeto == "cb_seleccionar")
                ls_Seleccionado = "S";

            if (nombreObjeto == "cb_deseleccionar")
                ls_Seleccionado = "N";

            for (ll_Row = 1; ll_Row <= dw_1.RowCount(); ll_Row++)
                dw_1.SetItem(ll_Row, "seleccionado", ls_Seleccionado);
        }
    }
}