using Minotti.Data;
using Minotti.Functions;
using Minotti.Repositories;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Abm.Controls;
using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti.Views.Repertorizaciones.Controls
{
    /// <summary>
    /// Migrado desde PowerBuilder Window 'w_borra_reperto_parc' (extiende w_abm_lista_seleccion).
    /// Nombres y lógica preservados. Conexión ODBC (SQL Anywhere 9) por DSN para emular USING SQLCA.
    /// </summary>
    public partial class w_borra_reperto_parc : w_abm_lista_seleccion
    {
        public w_borra_reperto_parc()
        {
            InitializeComponent();
        }

        // PB: public subroutine wf_armar_sintomas ()
        public void wf_armar_sintomas()
        {
            long ll_Fila;
            decimal ldec_Capitulo, ldec_Rubrica, ldec_SubRubrica, ldec_SubRubrica2, ldec_SubRubrica3, ldec_SubRubrica4,
                    ldec_SubRubrica5, ldec_SubRubrica6, ldec_SubRubrica7, ldec_SubRubrica8, ldec_SubRubrica9;

            string ls_Capitulo, ls_Rubrica, ls_SubRubrica, ls_SubRubrica2, ls_SubRubrica3, ls_SubRubrica4,
                   ls_SubRubrica5, ls_SubRubrica6, ls_SubRubrica7, ls_SubRubrica8, ls_SubRubrica9;

            for (ll_Fila = 1; ll_Fila <= dw_1.RowCount(); ll_Fila++)
            {
                ldec_Capitulo = dw_1.GetItemDecimal(ll_Fila, "capitulo");
                if (ldec_Capitulo > 0)
                {
                    ls_Capitulo = f_capitulo_nombre.fcapitulo_nombre((int)ldec_Capitulo);
                    dw_1.SetItem(ll_Fila, "capitulo_nombre", ls_Capitulo);
                }
                else
                {
                    ls_Capitulo = "";
                    dw_1.SetItem(ll_Fila, "capitulo_nombre", ls_Capitulo);
                }

                ldec_Rubrica = dw_1.GetItemDecimal(ll_Fila, "rubrica");
                if (ldec_Rubrica > 0)
                {
                    ls_Rubrica = f_rubrica_nombre.frubrica_nombre((int)ldec_Rubrica);
                    dw_1.SetItem(ll_Fila, "rubrica_nombre", ls_Rubrica);
                }
                else
                {
                    ls_Rubrica = "";
                    dw_1.SetItem(ll_Fila, "rubrica_nombre", ls_Rubrica);
                }

                ldec_SubRubrica = dw_1.GetItemDecimal(ll_Fila, "subrubrica");
                if (ldec_SubRubrica > 0)
                {
                    ls_SubRubrica = f_subrubrica_nombre.fsubrubrica_nombre((long)ldec_SubRubrica);
                    dw_1.SetItem(ll_Fila, "subrubrica_nombre", ls_SubRubrica);
                }
                else
                {
                    ls_SubRubrica = "";
                    dw_1.SetItem(ll_Fila, "subrubrica_nombre", ls_SubRubrica);
                }

                ldec_SubRubrica2 = dw_1.GetItemDecimal(ll_Fila, "subrubrica2");
                if (ldec_SubRubrica2 > 0)
                {
                    ls_SubRubrica2 = f_subrubrica_nombre.fsubrubrica_nombre((long)ldec_SubRubrica2);
                    dw_1.SetItem(ll_Fila, "subrubrica2_nombre", ls_SubRubrica2);
                }
                else
                {
                    ls_SubRubrica2 = "";
                    dw_1.SetItem(ll_Fila, "subrubrica2_nombre", ls_SubRubrica2);
                }

                ldec_SubRubrica3 = dw_1.GetItemDecimal(ll_Fila, "subrubrica3");
                if (ldec_SubRubrica3 > 0)
                {
                    ls_SubRubrica3 = f_subrubrica_nombre.fsubrubrica_nombre((long)ldec_SubRubrica3);
                    dw_1.SetItem(ll_Fila, "subrubrica3_nombre", ls_SubRubrica3);
                }
                else
                {
                    ls_SubRubrica3 = "";
                    dw_1.SetItem(ll_Fila, "subrubrica3_nombre", ls_SubRubrica3);
                }

                ldec_SubRubrica4 = dw_1.GetItemDecimal(ll_Fila, "subrubrica4");
                if (ldec_SubRubrica4 > 0)
                {
                    ls_SubRubrica4 = f_subrubrica_nombre.fsubrubrica_nombre((long)ldec_SubRubrica4);
                    dw_1.SetItem(ll_Fila, "subrubrica4_nombre", ls_SubRubrica4);
                }
                else
                {
                    ls_SubRubrica4 = "";
                    dw_1.SetItem(ll_Fila, "subrubrica4_nombre", ls_SubRubrica4);
                }

                ldec_SubRubrica5 = dw_1.GetItemDecimal(ll_Fila, "subrubrica5");
                if (ldec_SubRubrica5 > 0)
                {
                    ls_SubRubrica5 = f_subrubrica_nombre.fsubrubrica_nombre((long)ldec_SubRubrica5);
                    dw_1.SetItem(ll_Fila, "subrubrica5_nombre", ls_SubRubrica5);
                }
                else
                {
                    ls_SubRubrica5 = "";
                    dw_1.SetItem(ll_Fila, "subrubrica5_nombre", ls_SubRubrica5);
                }

                ldec_SubRubrica6 = dw_1.GetItemDecimal(ll_Fila, "subrubrica6");
                if (ldec_SubRubrica6 > 0)
                {
                    ls_SubRubrica6 = f_subrubrica_nombre.fsubrubrica_nombre((long)ldec_SubRubrica6);
                    dw_1.SetItem(ll_Fila, "subrubrica6_nombre", ls_SubRubrica6);
                }
                else
                {
                    ls_SubRubrica6 = "";
                    dw_1.SetItem(ll_Fila, "subrubrica6_nombre", ls_SubRubrica6);
                }

                ldec_SubRubrica7 = dw_1.GetItemDecimal(ll_Fila, "subrubrica7");
                if (ldec_SubRubrica7 > 0)
                {
                    ls_SubRubrica7 = f_subrubrica_nombre.fsubrubrica_nombre((long)ldec_SubRubrica7);
                    dw_1.SetItem(ll_Fila, "subrubrica7_nombre", ls_SubRubrica7);
                }
                else
                {
                    ls_SubRubrica7 = "";
                    dw_1.SetItem(ll_Fila, "subrubrica7_nombre", ls_SubRubrica7);
                }

                ldec_SubRubrica8 = dw_1.GetItemDecimal(ll_Fila, "subrubrica8");
                if (ldec_SubRubrica8 > 0)
                {
                    ls_SubRubrica8 = f_subrubrica_nombre.fsubrubrica_nombre((long)ldec_SubRubrica8);
                    dw_1.SetItem(ll_Fila, "subrubrica8_nombre", ls_SubRubrica8);
                }
                else
                {
                    ls_SubRubrica8 = "";
                    dw_1.SetItem(ll_Fila, "subrubrica8_nombre", ls_SubRubrica8);
                }

                ldec_SubRubrica9 = dw_1.GetItemDecimal(ll_Fila, "subrubrica9");
                if (ldec_SubRubrica9 > 0)
                {
                    ls_SubRubrica9 = f_subrubrica_nombre.fsubrubrica_nombre((long)  ldec_SubRubrica9);
                    dw_1.SetItem(ll_Fila, "subrubrica9_nombre", ls_SubRubrica9);
                }
                else
                {
                    ls_SubRubrica9 = "";
                    dw_1.SetItem(ll_Fila, "subrubrica9_nombre", ls_SubRubrica9);
                }
            }
        }

        // PB: event ue_borrar (override)
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
                    if (this.ib_grabar)
                    {
                        if (dw_1.DeleteRow(iAux) != 1) this.ib_grabar = false;
                    }

                    if (this.ib_grabar)
                    {
                        if (dw_1.Update(true, true) != 1) this.ib_grabar = false;
                    }

                    if (this.ib_grabar)
                    {
                        // PB embedded SQL:
                        // DELETE FROM reperto_parcial_med WHERE reperto_parcial = :ll_reperto USING SQLCA;
                        w_borra_reperto_parc_dal.DeleteRepertoParcialMed(ll_reperto);

                        if (SQLCA.SqlCode != 0) this.ib_grabar = false;
                    }

                    if (this.ib_grabar)
                    {
                        /* No se cierra al borrar un registro de la lista */
                        this.ib_cerrar_al_grabar = false;
                    }
                    else
                    {
                        dw_1.RowsMove(1, dw_1.DeletedCount(), PBRowMoveMode.Delete, dw_1, (int)iAux, dwbuffer.Primary);
                        dw_1.SetRow((int)iAux);
                        // dw_1.Sort()
                    }
                }
            }
        }

        // PB: event ue_iniciar; call super::ue_iniciar; wf_armar_sintomas()
        public override void ue_iniciar()
        {
            base.ue_iniciar();
            wf_armar_sintomas();
        }

        // PB: event ue_dw_button_clicked; call super::ue_dw_button_clicked; ...
        public override void ue_dw_button_clicked(object objeto)
        {
            base.ue_dw_button_clicked(objeto);

            long ll_Row;
            string ls_Seleccionado = null;

            // PB: objeto.name
            string nombreObjeto;
            try
            {
                dynamic d = objeto;
                nombreObjeto = (string)(d?.name ?? d?.Name ?? "");
            }
            catch
            {
                nombreObjeto = "";
            }

            if (nombreObjeto == "cb_seleccionar")
                ls_Seleccionado = "S";

            if (nombreObjeto == "cb_deseleccionar")
                ls_Seleccionado = "N";

            for (ll_Row = 1; ll_Row <= dw_1.RowCount(); ll_Row++)
                dw_1.SetItem(ll_Row, "seleccionado", ls_Seleccionado);
        }

        // PB: nested type dw_buscar exists but no custom props in SRW -> nothing to add in WinForms
    }
}