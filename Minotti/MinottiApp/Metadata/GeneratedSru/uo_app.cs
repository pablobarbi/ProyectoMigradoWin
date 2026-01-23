using Minotti.Data;
using Minotti.Funciones;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Menues.Controls;
using MinottiApp.utils;
using System;

namespace Minotti.Metadata.GeneratedSru
{
    /// <summary>
    /// PB:
    /// $PBExportComments$
    /// Objeto para el manejo de utilidades de una aplicación.
    /// Sus eventos constructor y ue_open deben ser modificados en cada aplicación.
    /// </summary>
    public class uo_app : nonvisualobject
    {
        // =====================================================
        // VARIABLES (type variables)
        // =====================================================

        // Protected:
        protected string ArcInicio;
        protected string Version;
        protected string Logo;
        protected string Copyright;
        protected w_mdi wMdi;
        protected cat_usuario at_usuario;
        protected string ventana_coneccion;

        // Public:
        public application App;
        public environment Env;
        public m_mdi menu;
        public bool FalloValidacion = false;
        public datastore ds_valor_inicial;
        public datastore ds_campos_invisibles;
        public string motor_db;
        public cat_error_db at_error_db;
        public datastore ds_param_sistema;
        public datastore ds_datos_usuarios;

        // =====================================================
        // CONSTRUCTOR / DESTRUCTOR PB
        // =====================================================

        public override void constructor()
        {
            // PB:
            // App = GetApplication()
            App = GetApplication();

            // PB:
            // GetEnvironment (Env)
            GetEnvironment(out Env);
        }

        public override void destructor()
        {
            // PB: sin lógica adicional
        }

        public uo_app()
        {
            // PB:
            // call super::create
            // TriggerEvent( this, "constructor" )
            constructor();
        }

        public void destroy()
        {
            // PB:
            // TriggerEvent( this, "destructor" )
            destructor();
        }

        // =====================================================
        // EVENTS
        // =====================================================

        public virtual void ue_open()
        {
            int iAux;
            int rtn;

            // Indica cuál es la ventana MDI de la aplicación
            wMdi = new w_mdi();

            // Define algunos atributos de la aplicación
            ue_cargar_datos_app();

            // Se conecta a la base de datos
            rtn = ue_coneccion();
            if (rtn < 1)
            {
                ue_close();
                return;
            }

            // Recupera datos adicionales del Usuario
            rtn = ue_cargar_datos_usuarios();
            if (rtn < 1)
            {
                ue_close();
                return;
            }

            // Recupera valores iniciales
            rtn = ue_cargar_datos_iniciales();
            if (rtn < 1)
            {
                ue_close();
                return;
            }

            // Recupera campos invisibles
            rtn = ue_cargar_datos_invisibles();
            if (rtn < 1)
            {
                ue_close();
                return;
            }

            // Tres capas
            rtn = ue_tres_capas();
            if (rtn < 1)
            {
                ue_close();
                return;
            }

            // Muestra splash
            uof_mostrar_splash(1);

            // Abre ventana principal
            Open(wMdi);
            menu = new m_mdi();

            // Abre menú de operaciones
            OpenSheet(w_menu_arbol_lista, wMdi, 2, PBOpenMode.Original);
        }

        public virtual void ue_cargar_datos_app()
        {
            // PB:
            // This.ventana_coneccion = "w_coneccion"
            ventana_coneccion = "w_coneccion";
        }

        public override int ue_coneccion()
        {
            Open(w_coneccion, ventana_coneccion);

            at_usuario = utils.Message.PowerObjectParm as cat_usuario;
            if (at_usuario == null || at_usuario.Usuario == null)
                return -1;

            return 1;
        }

        public override int ue_tres_capas()
        {
            return 1;
        }

        public override int ue_cargar_datos_iniciales()
        {
            ds_valor_inicial = new datastore();
            ds_valor_inicial.DataObject = "d_valor_inicial";
            ds_valor_inicial.SetTransObject(SQLCA.Instance);

            ds_valor_inicial.Retrieve();

            return 1;
        }

        public override int ue_cargar_datos_usuarios()
        {
            return 1;
        }

        public override int ue_cargar_datos_invisibles()
        {
            ds_campos_invisibles = new datastore();
            ds_campos_invisibles.DataObject = "d_campos_invisibles";
            ds_campos_invisibles.SetTransObject(SQLCA.Instance);

            ds_campos_invisibles.Retrieve();

            return 1;
        }

        public override void ue_close()
        {
            if (IsValid(ds_campos_invisibles)) ds_campos_invisibles.Destroy();
            if (IsValid(ds_datos_usuarios)) ds_datos_usuarios.Destroy();
            if (IsValid(ds_param_sistema)) ds_param_sistema.Destroy();
            if (IsValid(ds_valor_inicial)) ds_valor_inicial.Destroy();
        }

        // =====================================================
        // PUBLIC FUNCTIONS / SUBROUTINES
        // =====================================================

        public string uof_getarchivoinicio() => ArcInicio;
        public string uof_getversion() => Version;
        public string uof_getlogo() => Logo;
        public string uof_getcopyright() => Copyright;
        public w_mdi uof_getmdi() => wMdi;

        public void uof_mostrar_splash(int segundos)
        {
            cat_splash at_splash = new cat_splash();

            uof_cargar_datos_sistema(at_splash);
            at_splash.segundos = segundos;

            PBWindow.OpenWithParm(w_splash, at_splash);
        }

        public void uof_mostrar_datos_sistema()
        {
            cat_app at_app = new cat_app();

            uof_cargar_datos_sistema(at_app);
            PBWindow.OpenWithParm(w_datos_sistema, at_app);
        }

        private void uof_cargar_datos_sistema(cat_app at_app)
        {
            at_app.Nombre = App.DisplayName;
            at_app.Logo = Logo;
            at_app.Version = Version;
            at_app.Copyright = Copyright;
        }

        public cat_usuario uof_getusuario()
        {
            return at_usuario;
        }

        private int uof_cargar_datos_usuario()
        {
            return f_cargar_datos_usuario.fcargar_datos_usuario(at_usuario, true);
        }


        // PB: IsValid()
        private static bool IsValid(object? o) => o != null;
    }
}
