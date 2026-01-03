
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;

namespace Minotti
{
    /// <summary>Equivalente del objeto global de PB: guo_app (mantengo el NOMBRE).</summary>
    public static class guo_app
    {
        public static uo_app Instance { get; set; } = new uo_app();

        // Atajos PB-like (si ya venías usando guo_app.motor_db directo)
        public static string? motor_db
        {
            get => Instance.motor_db;
            set => Instance.motor_db = value;
        }

        public static datastore? ds_valor_inicial => Instance.ds_valor_inicial;

        public static w_mdi uof_Getmdi() => Instance.uof_getmdi();

        public static cat_usuario uof_GetUsuario() => Instance.uof_getusuario();

        public static cat_error_db? at_error_db => Instance.at_error_db;

        public static dynamic? Menu => Instance.menu;
    }


}
