// Migrado desde PowerBuilder .srf: f_reperto_sintoma_codigo_nuevo.srf
// Se mantienen NOMBRES y lógica tal como figura en el archivo.
namespace Minotti.Functions
{
    public static class f_reperto_sintoma_codigo_nuevo
    {


        public static long freperto_sintoma_codigo_nuevo()
        {
            // Modelado del Long de PB que puede venir NULL del SELECT
            long? ll_RepertoTotal = null;

            // Acá va el SELECT MAX(reperto_sintoma) FROM reperto_total_sin
            // y se asigna el resultado a ll_RepertoTotal (puede ser null si no hay filas).
            //
            // Ejemplo (vos después lo implementás con tu capa de datos):
            //
            // ll_RepertoTotal = EjecutarScalarLongNullable(
            //     "SELECT MAX(reperto_sintoma) FROM reperto_total_sin"
            // );

            // Lógica PB tal cual:
            if (ll_RepertoTotal == null)
            {
                ll_RepertoTotal = 1;
            }
            else if (ll_RepertoTotal == 0)
            {
                ll_RepertoTotal = 1;
            }
            else
            {
                ll_RepertoTotal = ll_RepertoTotal + 1;
            }

            return ll_RepertoTotal.Value;
        }





        //        /// <summary>
        //        /// f_reperto_sintoma_codigo_nuevo() : long
        //        /// Portado 1:1 desde PowerBuilder.
        //        /// </summary>
        //        public static long f_reperto_sintoma_codigo_nuevo()
        //        {
        //            // --- Código/Comentarios originales PB (extracto) ---
        //            /*﻿
        //global type f_reperto_sintoma_codigo_nuevo from function_object 
        //end type


        //forward prototypes
        //global function long f_reperto_sintoma_codigo_nuevo ()
        //end prototypes

        //global function long f_reperto_sintoma_codigo_nuevo ();/*
        //f_reperto_parc_codigo_nuevo
        //como el serial y la recuperacion es un quilombo, le hago el contador a mano.
        //*/

        //Long ll_RepertoTotal

        //SELECT MAX(reperto_sintoma)
        //  INTO :ll_RepertoTotal
        //  FROM reperto_total_sin
        // USING SQLCA;

        //IF IsNull(ll_RepertoTotal) THEN
        //	ll_RepertoTotal = 1
        //ELSEIF ll_RepertoTotal = 0  THEN
        //	ll_RepertoTotal = 1
        //ELSE
        //	ll_RepertoTotal = ll_RepertoTotal + 1
        //END IF


        //RETURN ll_RepertoTotal

        //end function*/
        //            // ----------------------------------------------------

        //            // Modelado de PB 'Long' con posibilidad de NULL inicial => long? para respetar IsNull().
        //            long? ll_RepertoSintoma = null;

        //            if (ll_RepertoSintoma == null)
        //            {
        //                ll_RepertoSintoma = 1;
        //            }
        //            else if (ll_RepertoSintoma == 0)
        //            {
        //                ll_RepertoSintoma = 1;
        //            }
        //            else
        //            {
        //                ll_RepertoSintoma = ll_RepertoSintoma + 1;
        //            }

        //            return ll_RepertoSintoma.Value;
        //        }
    }
}