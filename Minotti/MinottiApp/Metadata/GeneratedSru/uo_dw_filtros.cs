// -----------------------------------------------------------------------------
// AUTO-MIGRADO desde PowerBuilder (.sru)
// Origen: uo_dw_filtros
// Descripción: Heredado de uo_dw, la función getArgumentos devuelve todo el registro
// -----------------------------------------------------------------------------

#nullable enable
using System;

namespace Minotti.Metadata.GeneratedSru
{
    /// <summary>
    /// PB: uo_dw_filtros
    /// Hereda de uo_dw.
    /// La función uof_getargumentos devuelve todo el registro (no solo claves).
    /// </summary>
    public class uo_dw_filtros : uo_dw
    {
        /// <summary>
        /// PB: uof_getargumentos
        /// Pasa todo el registro como argumento.
        /// </summary>
        public override bool uof_getargumentos(ref string[] parametros, int fila)
        {
            // PB: Return(uof_GetRegistro(parametros[], fila))
            return uof_getregistro(ref parametros, fila);
        }
    }
}
