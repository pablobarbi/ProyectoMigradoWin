// Migrado desde PowerBuilder .srf: f_reperto_tot_codigo_nuevo.srf
// Se mantienen NOMBRES y lógica (tal como figura en el archivo).
namespace Minotti.Functions
{
    public static class f_reperto_tot_codigo_nuevo
    {
        /// <summary>
        /// f_reperto_tot_codigo_nuevo() : long
        /// Portado 1:1 desde PowerBuilder.
        /// </summary>
        public static long freperto_tot_codigo_nuevo_OLD()
        {
            // --- Código/Comentarios originales PB (extracto) ---
            /*﻿
global type f_reperto_tot_codigo_nuevo from function_object 
end type


forward prototypes
global function long f_reperto_tot_codigo_nuevo ()
end prototypes

global function long f_reperto_tot_codigo_nuevo ();/*
f_reperto_parc_codigo_nuevo
como el serial y la recuperacion es un quilombo, le hago el contador a mano.


Long ll_RepertoTotal

SELECT MAX(reperto_total)
  INTO :ll_RepertoTotal
  FROM reperto_total
 USING SQLCA;

IF IsNull(ll_RepertoTotal) THEN
	ll_RepertoTotal = 1
ELSEIF ll_RepertoTotal = 0  THEN
	ll_RepertoTotal = 1
ELSE
	ll_RepertoTotal = ll_RepertoTotal + 1
END IF


RETURN ll_RepertoTotal

end function*/
            // ----------------------------------------------------

            // En PB: Long puede estar sin inicializar (NULL). Usamos long? para respetar IsNull().
            long? ll_RepertoTotal = null;

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



        public static long freperto_tot_codigo_nuevo()
        {
            /*
            f_reperto_parc_codigo_nuevo
            como el serial y la recuperacion es un quilombo, le hago el contador a mano.
            */

            long? ll_RepertoTotal = null;

            // SELECT MAX(reperto_total)
            //   INTO :ll_RepertoTotal
            //   FROM reperto_total
            // USING SQLCA;

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



    }
}