namespace Minotti.Views.Basicos.Controls
{
    /// <summary>
    /// Migración directa de:
    /// global type uo_dw_filtros from uo_dw
    /// </summary>
     // global type uo_dw_filtros from uo_dw
    public class uo_dw_filtros : uo_dw
    {
        public uo_dw_filtros() : base()
        {
        }

        // public function boolean uof_getargumentos (ref string parametros[], integer fila)
        // /* Pasa todo el registro como argumento */
        // Return(uof_GetRegistro(parametros[], fila))
        public override bool uof_getargumentos(string[] parametros, int fila)
        {
            return uof_getregistro(ref parametros, fila);
        }
    }
}
