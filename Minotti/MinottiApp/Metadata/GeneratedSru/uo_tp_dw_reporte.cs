// -----------------------------------------------------------------------------
// AUTO-MIGRADO DESDE PowerBuilder (.sru)
// Origen : uo_tp_dw_reporte_like.sru
// Tipo   : Página de reporte con búsqueda LIKE
// Hereda : uo_tp_dw_reporte
// NOTA   : Migración 1:1 exacta, sin refactor
// -----------------------------------------------------------------------------

#nullable enable
using Minotti.Metadata.Generated;
using Minotti.Views.Reportes.Controls;
using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    // -------------------------------------------------------------------------
    // PB:
    // global type uo_tp_dw_reporte_like from uo_tp_dw_reporte
    // -------------------------------------------------------------------------
    public class uo_tp_dw_reporte_like : uo_tp_dw_reporte
    {
        // ---------------------------------------------------------------------
        // PB: on uo_tp_dw_reporte_like.create
        // call super::create
        // ---------------------------------------------------------------------
        public override void create()
        {
            base.create();
        }

        // ---------------------------------------------------------------------
        // PB: on uo_tp_dw_reporte_like.destroy
        // call super::destroy
        // ---------------------------------------------------------------------
        public override void destroy()
        {
            base.destroy();
        }

        // ---------------------------------------------------------------------
        // PB: event ue_iniciar
        //
        // String ls_Param[]
        // Long   ll_Fila
        //
        // is_accion = arg_accion
        // is_parametros = arg_param[]
        //
        // FOR ll_Fila = 1 TO UpperBound(is_parametros)
        //     ls_Param[ll_Fila] = '%' + is_parametros[ll_Fila] + '%'
        // NEXT
        //
        // If dw_1.uof_Retrieve(ls_Param[]) < 1 Then dw_1.InsertRow(0)
        // ---------------------------------------------------------------------
        public override void ue_iniciar(string arg_accion, string[] arg_param)
        {
            string[] ls_Param;
            long ll_Fila;

            is_accion = arg_accion;
            is_parametros = arg_param;

            // PowerBuilder arrays son 1-based → respetamos semántica
            ls_Param = new string[is_parametros.Length];

            for (ll_Fila = 0; ll_Fila < is_parametros.Length; ll_Fila++)
            {
                ls_Param[ll_Fila] = "%" + is_parametros[ll_Fila] + "%";
            }

            if (dw_1.uof_Retrieve(ls_Param) < 1)
            {
                dw_1.InsertRow(0);
            }
        }

        // ---------------------------------------------------------------------
        // PB:
        // type dw_1 from uo_tp_dw_reporte`dw_1 within uo_tp_dw_reporte_like
        // (hereda sin cambios)
        // ---------------------------------------------------------------------
        public new class dw_1 : uo_tp_dw_reporte.dw_1
        {
            // Sin modificaciones
        }
    }
}
