// Migrado desde PowerBuilder .srf: f_reperto_parc_codigo_nuevo.srf
// Se mantienen NOMBRES y lógica exacta.
namespace Minotti.Functions
{
    public static class f_reperto_parc_codigo_nuevo
    {
        /// <summary>
        /// f_reperto_parc_codigo_nuevo() : long
        /// Portado 1:1 desde PowerBuilder.
        /// </summary>
        public static long freperto_parc_codigo_nuevo()
        {
            // --- Código/Comentarios originales PB ---
            /*f_reperto_parc_codigo_nuevo
como el serial y la recuperacion es un quilombo, le hago el contador a mano.
USING SQLCA;
IF IsNull(ll_RepertoParcial) THEN
    ll_RepertoParcial = 1
ELSEIF ll_RepertoParcial = 0  THEN
    ll_RepertoParcial = 1
ELSE
    ll_RepertoParcial = ll_RepertoParcial + 1
END IF
RETURN ll_RepertoParcial
*/
            // ----------------------------------------

            // En PB: Long sin inicializar puede ser NULL => se modela como long? en C# para respetar la semántica de IsNull.
            long? ll_RepertoParcial = null;

            if (ll_RepertoParcial == null)
            {
                ll_RepertoParcial = 1;
            }
            else if (ll_RepertoParcial == 0)
            {
                ll_RepertoParcial = 1;
            }
            else
            {
                ll_RepertoParcial = ll_RepertoParcial + 1;
            }

            return ll_RepertoParcial.Value;
        }
    }
}