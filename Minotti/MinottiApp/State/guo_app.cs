
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using Minotti.Views.Pbl.Views;

namespace Minotti
{
    /// <summary>Equivalente del objeto global de PB: guo_app (mantengo el NOMBRE).</summary>
    public static class guo_app
    {
        public static uo_app Instance { get; private set; } = null!;
        public static application? App => Instance?.App;


        public static void Attach(uo_app app)
        {
            Instance = app;
        }

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

        public static m_mdi? menu { get; set; }


        public static void uof_SetUsuario(cat_usuario usuario)
        {
            Instance.uof_setusuario(usuario);
        }

        public static void uof_mostrar_datos_sistema()
        {
            //// PB: muestra información del sistema / aplicación
            //MessageBox.Show(
            //    $"Aplicación: {App?.DisplayName}\n" +
            //    $"Versión: {Application.ProductVersion}\n" +
            //    $"Usuario: {Environment.UserName}\n" +
            //    $"Equipo: {Environment.MachineName}",
            //    "Acerca de",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Information
            //);

            //new w_about().ShowDialog()
        }




    }


}
