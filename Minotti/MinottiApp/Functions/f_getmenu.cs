namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_getmenu.srf
    /// Firma original: global function string f_getmenu()
    /// Devuelve la cadena de parámetros para armar el menú (Perfil -> Módulo -> Sub Módulo -> Operación).
    /// </summary>
    public static class f_getmenu
    {
        /// <summary>
        /// Retorno literal migrado desde PB (manteniendo acentos y espacios).
        /// </summary>
        public static string fgetmenu()
        {
            return "4, Perfiles, d_perfiles_x_usuario, " +
                   "Módulos, d_modulos_x_perfil, " +
                   "Sub Módulos, d_sub_modulos_x_perfil, " +
                   "Operaciones, d_operaciones_x_perfil_sub_modulo, " +
                   "d_param_x_operacion";
        }
    }
}
