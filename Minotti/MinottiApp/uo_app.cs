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
            PBGlobals.w_mdi = wMdi;
            PBGlobals.m_mdi = new m_mdi(wMdi);

            // 1) Cargar datos de la app (crea at_splash)
            ue_cargar_datos_app();


            // 2️⃣ CONEXIÓN A LA BASE  ← ACÁ
            rtn = ue_coneccion();
            if (rtn < 1)
            {
                ue_close();
                return;
            }

            // 3️⃣ Datos dependientes de DB
            rtn = ue_cargar_datos_usuarios();
            if (rtn < 1)
            {
                ue_close();
                return;
            }

            rtn = ue_cargar_datos_iniciales();
            if (rtn < 1)
            {
                ue_close();
                return;
            }

            rtn = ue_cargar_datos_invisibles();
            if (rtn < 1)
            {
                ue_close();
                return;
            }

            rtn = ue_tres_capas();
            if (rtn < 1)
            {
                ue_close();
                return;
            }

            // 2) SPLASH (modal, temporal)
            using (var splash = new Views.Basicos.w_splash
            {
                at_splash = this.at_splash
            })
            {
                splash.ShowDialog();
            }



            // 3) LOGIN (modal)
            using (var login = new w_coneccion_sepad())
            {
                login.ShowDialog();

                // PB: si cancela, se sale
                if (login.Retorno != 1)
                    return;
            }

            // ==============================
            // 4. Abrir la ventana MDI
            // ==============================



            OpenPB.Open(wMdi);

            // ==============================
            // 5. Crear el menú MDI
            // ==============================            
            PBGlobals.m_mdi = new m_mdi(wMdi);


            // ==============================
            // 7. Abrir sheet del menú dinámico
            // ==============================
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

        public w_mdi uof_getmdi()
        {
            return wMdi!;
        }

        public cat_usuario uof_getusuario()
        {
            return at_usuario;
        }
        public void uof_setusuario(cat_usuario usuario)
        {
            at_usuario = usuario ?? new cat_usuario();
        }

        public string uof_getarchivoinicio()
        {
            return ArcInicio ?? string.Empty;
        }

        public void uof_mostrar_datos_sistema()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"App: {App?.DisplayName} | Version: {Version} | Usuario: {at_usuario?.Nombre}"
                );
            }
            catch
            {
                // PB: ignora errores
            }
        }

        public override int ue_coneccion()
        {
            string dsn = "Minotti";   // el DSN ODBC real
            SQLCA.UserID = "dba";// ed_usuario.Text;
            SQLCA.DBPass = "sql"; //ed_clave.Text;

            bool ok = SQLCA.Connect(dsn, SQLCA.UserID, SQLCA.DBPass);

            if (!ok)
            {
                MessageBox.Show(
                    SQLCA.SqlErrText,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return -1;
            }

            return 1;
        }


    }
}
