namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_getmenu_sin_submodulo.srf
    /// Firma original: global function string f_getmenu_sin_submodulo()
    /// Devuelve la cadena de parámetros para armar el menú (sin nivel de Sub Módulo).
    /// </summary>
    public static class f_getmenu_sin_submodulo
    {
        /// <summary>Retorno literal migrado desde PB.</summary>
        public static string fgetmenu_sin_submodulo()
        {
            return "3, Perfiles, d_perfiles_x_usuario, Módulos, d_modulos_x_perfil, Operaciones, d_operaciones_x_perfil, d_param_x_operacion";
        }
    }
}
