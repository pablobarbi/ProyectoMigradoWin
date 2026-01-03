// Migrado desde PowerBuilder .srf: f_diagnostico_codigo_nuevo.srf
// Se mantienen NOMBRES de clase y función. Lógica integrada tal como aparece en el .srf.
// El contenido original (incluyendo comentarios y 'USING SQLCA;'/'...') se conserva abajo.
namespace Minotti.Functions
{
    public static class f_diagnostico_codigo_nuevo
    {
        /// <summary>
        /// f_diagnostico_codigo_nuevo(integer al_paciente) : long
        /// </summary>
        public static long fdiagnostico_codigo_nuevo(int al_paciente)
        {
            // Comentarios originales PB:
            // f_reperto_parc_codigo_nuevo
            // como el serial y la recuperacion es un quilombo, le hago el contador a mano.
            //
            // USING SQLCA;
            // ...  (el .srf contiene literalmente '...'; no se inventa lógica faltante)

            long? ll_Diagnostico = null; // PB Long sin inicializar es NULL

            if (ll_Diagnostico == null)
            {
                ll_Diagnostico = 1;
            }
            else if (ll_Diagnostico == 0)
            {
                ll_Diagnostico = 1;
            }
            else
            {
                ll_Diagnostico = ll_Diagnostico + 1;
            }

            return ll_Diagnostico.Value;
        }
    }
}