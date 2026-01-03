using Minotti.Data;
using Minotti.Functions;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using Minotti.Views.Menues.Controls;
using Minotti.Views.Pbl.Views;
using MinottiApp.utils;
using System;
using System.Windows.Forms;

namespace Minotti
{
    // =========================================================
    // PB: nonvisualobject
    // =========================================================
    public class nonvisualobject
    {
        public virtual void constructor() { }
        public virtual void destructor() { }

        public virtual void ue_open() { }
        public virtual int ue_coneccion() => 1;
        public virtual int ue_tres_capas() => 1;
        public virtual int ue_cargar_datos_iniciales() => 1;
        public virtual int ue_cargar_datos_usuarios() => 1;
        public virtual int ue_cargar_datos_invisibles() => 1;
        public virtual void ue_close() { }
    }

    // =========================================================
    // PB: APPLICATION OBJECT
    // =========================================================
    public class uo_app : nonvisualobject
    {
        // -----------------------------------------------------
        // PB: instancia global (guo_app)
        // -----------------------------------------------------
        public static uo_app? Instance { get; private set; }

        // -----------------------------------------------------
        // PB: variables públicas
        // -----------------------------------------------------
        public string ArcInicio = string.Empty;
        public string Version = string.Empty;
        public string Logo = string.Empty;
        public string Copyright = string.Empty;
        public string motor_db = string.Empty;
        public string ventana_coneccion = string.Empty;

        public bool gi_app_modo_debug = false;
        public bool FalloValidacion = false;

        public w_mdi? wMdi;
        public m_mdi? menu;

        public cat_usuario at_usuario = new cat_usuario();
        public cat_error_db? at_error_db;

        public datastore? ds_valor_inicial;
        public datastore? ds_campos_invisibles;
        public datastore? ds_param_sistema;
        public datastore? ds_datos_usuarios;

        // -----------------------------------------------------
        // PB: Application / Environment
        // -----------------------------------------------------
        public application? App;
        public environment Env;

        // -----------------------------------------------------
        // PB: SPLASH
        // -----------------------------------------------------
        public cat_splash at_splash { get; private set; } = new cat_splash();

        // -----------------------------------------------------
        // Constructor
        // -----------------------------------------------------
        public uo_app()
        {
            Instance = this;
            constructor();
        }

        public override void constructor()
        {
            PBEnvironment.GetEnvironment(out Env);
            App ??= new application();
        }

        // -----------------------------------------------------
        // PB: ue_cargar_datos_app
        // -----------------------------------------------------
        public virtual void ue_cargar_datos_app()
        {
            App ??= new application();

            App.DisplayName = "Minotti 2025";
            ArcInicio = "minotti.ini";
            Version = "Release 2025.12.27";
            Logo = FileUtils.GetAppFile("Pictures", "tapa1.bmp");
            Copyright =
                "El siguiente programa se encuentra protegido por las leyes de derecho de autor.";
            ventana_coneccion = "w_coneccion_sepad";
            motor_db = "SQL Anywhere";

            // === SPLASH (PB: CREATE cat_splash) ===
            at_splash = new cat_splash
            {
                Nombre = App.DisplayName,
                Version = Version,
                Logo = Logo,
                Copyright = Copyright,
                segundos = 2
            };
        }

        // -----------------------------------------------------
        // PB: ue_open
        // -----------------------------------------------------
        public override void ue_open()
        {
            int rtn;

            wMdi = new w_mdi();

            ue_cargar_datos_app();

            uof_mostrar_splash(at_splash.segundos);

            rtn = ue_coneccion();
            if (rtn < 1) return;

            rtn = ue_cargar_datos_usuarios();
            if (rtn < 1) return;

            rtn = ue_cargar_datos_iniciales();
            if (rtn < 1) return;

            rtn = ue_cargar_datos_invisibles();
            if (rtn < 1) return;

            rtn = ue_tres_capas();
            if (rtn < 1) return;

            OpenPB.Open(wMdi);

            menu = new m_mdi();

            OpenSheetWithParmPB.OpenSheet(
                typeof(w_menu_arbol_lista),
                wMdi,
                2,
                PBOpenMode.Original
            );
        }

        // -----------------------------------------------------
        // PB helpers
        // -----------------------------------------------------
        public virtual void uof_mostrar_splash(int segundos)
        {
            if (at_splash == null) return;

            at_splash.segundos = segundos;
            OpenWithParmPB.OpenWithParm(
                typeof(Minotti.Views.Basicos.w_splash),
                at_splash
            );
        }

        public virtual void Open() => ue_open();

        internal w_mdi uof_getmdi()
        {
            return wMdi!;
        }

        internal cat_usuario uof_getusuario()
        {
            return at_usuario;
        }

        internal string uof_getarchivoinicio()
        {
            throw new NotImplementedException();
        }

        internal void uof_mostrar_datos_sistema()
        {
            throw new NotImplementedException();
        }
    }
}
