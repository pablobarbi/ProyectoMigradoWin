//using Minotti.Data; // SQLCA
//using Minotti.Functions;
//using Minotti.Structures;
//using Minotti.utils;
//using Minotti.Views.Menues.Controls;
//using Minotti.Views.Pbl.Views;
//using MinottiApp.utils;
//using System;
//using System.Windows.Forms;
//using PBApplication = Minotti.utils.application;
//using PBEnviroment = Minotti.utils.PBEnvironment;

 


//namespace Minotti

//    public class nonvisualobject
//    {
//        // PB: eventos típicos de NVO (stubs)
//        public  virtual void constructor() { }
//        public  virtual void destructor() { }

//        // PB: eventos del uo_app (stubs para override)
//        public  virtual void ue_open() { }
//        //public  virtual void ue_cargar_datos_app() { }
//        public  virtual int ue_coneccion() => 1;
//        public  virtual int ue_tres_capas() => 1;
//        public  virtual int ue_cargar_datos_iniciales() => 1;
//        public  virtual int ue_cargar_datos_usuarios() => 1;
//        public  virtual int ue_cargar_datos_invisibles() => 1;
//        public  virtual void ue_close() { }

//        // PB-style: TriggerEvent(this,"constructor")
//        public static int TriggerEvent(object target, string eventName)
//            => DynamicEventInvoker.TriggerEvent(target, eventName);

//        // PB-style: PostEvent (en NVO lo dejo síncrono; en windows lo vas a tener async)
//        public static int PostEvent(object target, string eventName)
//            => DynamicEventInvoker.TriggerEvent(target, eventName);
//    }

//    public partial class uo_app : nonvisualobject
//    {
//        // ===== Variables (PB: public /Public) =====

//        // public :
//        public  string ArcInicio = string.Empty;
//        public  string Version = string.Empty;
//        public  string Logo = string.Empty;
//        public  string Copyright = string.Empty;
//        public  w_mdi? wMdi;
//        public  cat_usuario at_usuario = new cat_usuario();
//        public  string ventana_coneccion = string.Empty;
//        // si lo usás en el código:
//        public bool gi_app_modo_debug = false;

//        // ==============================
//        // PB: cat_splash at_splash
//        // ==============================
//        public cat_splash at_splash { get; set; }

//        // Public:
//        public PBApplication? App;
//        public environment Env; // FIX: environment es un struct/clase interna, no PBEnvironment “estático”
//        public m_mdi? menu;
//        public bool FalloValidacion = false; /* Comunicación entre uo_dw y las funciones de validación */
//        public datastore? ds_valor_inicial;
//        public datastore? ds_campos_invisibles;
//        public string motor_db = string.Empty; /* Nombre del Motor de Base de Datos con el que se trabajara */
//        public cat_error_db? at_error_db;
//        public datastore? ds_param_sistema;   /* Parametros del Sistema */
//        public datastore? ds_datos_usuarios;  /* Datos adicionales del Usuario */


//        // Emula el "global uo_app uo_app" de PowerBuilder
//        public static uo_app? Instance { get; private set; }

//        // ===== PB events =====
//        public virtual string uof_getarchivoinicio()
//        {
//            return ArcInicio;
//        }
//        public  override void ue_open()
//        {
//            int iAux, rtn;

//            /* Indica cuál es la ventana MDI de la aplicación */
//            wMdi = new w_mdi(); // PB: wMdi = w_mdi

//            /* Define algunos atributos de la aplicación */
//            this.ue_cargar_datos_app();

//            /* Se conecta a la base de datos */
//            rtn = this.ue_coneccion();
//            if (rtn < 1)
//            {
//                this.ue_close();
//                return;
//            }

//            /* Recupera datos adicionales del Usuario */
//            rtn = this.ue_cargar_datos_usuarios();
//            if (rtn < 1)
//            {
//                this.ue_close();
//                return;
//            }

//            /* Recupera los nombres de los campos a los que se le seteara un valor inicial en las dw */
//            rtn = this.ue_cargar_datos_iniciales();
//            if (rtn < 1)
//            {
//                this.ue_close();
//                return;
//            }

//            /* Recupera los nombres de los campos que no seran mostrados en las dw */
//            rtn = this.ue_cargar_datos_invisibles();
//            if (rtn < 1)
//            {
//                this.ue_close();
//                return;
//            }

//            /* Si es una aplicación en tres capas, se conecta en este evento */
//            rtn = this.ue_tres_capas();
//            if (rtn < 1)
//            {
//                this.ue_close();
//                return;
//            }

//            /* Muestra una ventana splash */
//            uof_mostrar_splash(1);

//            /* Abre la ventana principal de la aplicación */
//            // PB: Open(wMdi)
//            // En tu migración seguro tenés OpenPB.Open(...) o algo equivalente.
//            OpenPB.Open(wMdi);

//            menu = new m_mdi(); // PB: menu = m_mdi

//            /* Abre el menú de operaciones */
//            // PB: OpenSheet(w_menu_arbol_lista, wMdi, 2, Original!)
//            OpenSheetWithParmPB.OpenSheet(
//                typeof(w_menu_arbol_lista),
//                wMdi,
//                2,
//                PBOpenMode.Original
//            );
//        }

//        public virtual void ue_cargar_datos_app()
//        {
//            // ==============================
//            // PB: Application siempre existe
//            // ==============================
//            if (App == null)
//                App = new PBApplication();

//            // ==============================
//            // PB: cat_splash at_splash
//            // SE CREA ACÁ (NO en uo_sepad)
//            // ==============================
//            at_splash = new cat_splash
//            {
//                Nombre = App.DisplayName ?? "Minotti",
//                Version = this.Version,
//                Logo = this.Logo,
//                Copyright = this.Copyright,
//                segundos = 2
//            };
//        }


//        public override int ue_coneccion()
//        {
//            /* Se conecta a la base de datos */
//            // PB: Open(w_coneccion, ventana_coneccion)
//            OpenWithParmPB.Open(typeof(w_coneccion), ventana_coneccion);

//            // PB: at_usuario = Message.PowerObjectParm
//            // Asumo que Message.PowerObjectParm es object
//            if (utils.Message.PowerObjectParm is cat_usuario cu)
//                at_usuario = cu;
//            else
//                at_usuario = new cat_usuario();

//            // PB: If isNull(at_usuario.usuario) Then Return (-1)
//            // No asumo propiedad nullable vs empty: lo dejo lo más PB posible:
//            if (at_usuario == null || at_usuario.Usuario == null)
//                return -1;

//            return 1;
//        }

//        public  override int ue_tres_capas()
//        {
//            return 1;
//        }

//        public  override int ue_cargar_datos_iniciales()
//        {
//            /* Carga los valores iniciales de la tabla PAR_VALOR_INICIAL */
//            ds_valor_inicial = new datastore();
//            ds_valor_inicial.DataObject = "d_valor_inicial";
//            ds_valor_inicial.SetTransObject(SQLCA.Instance);

//            ds_valor_inicial.Retrieve();

//            return 1;
//        }

//        public  override int ue_cargar_datos_usuarios()
//        {
//            /* Este Evento sera propio de Cada Aplicacion dependiendo de los datos adicionales que el usuario necesite */
//            return 1;
//        }

//        public  override int ue_cargar_datos_invisibles()
//        {
//            /* Carga los nombres de los campos que no se van a mostrar en las dw PAR_CAMPO_INVISIBLE */
//            ds_campos_invisibles = new datastore();
//            ds_campos_invisibles.DataObject = "d_campos_invisibles";
//            ds_campos_invisibles.SetTransObject(SQLCA.Instance);

//            ds_campos_invisibles.Retrieve();

//            return 1;
//        }

//        public  override void ue_close()
//        {
//            if (ds_campos_invisibles != null) ds_campos_invisibles = null;
//            if (ds_datos_usuarios != null) ds_datos_usuarios = null;
//            if (ds_param_sistema != null) ds_param_sistema = null;
//            if (ds_valor_inicial != null) ds_valor_inicial = null;
//        }

//        // ===== Prototypes → methods =====

//        //public  virtual string uof_getarchivoinicio()
//        //{
//        //    return ArcInicio;
//        //}

//        public  virtual string uof_getversion()
//        {
//            return Version;
//        }

//        public  virtual string uof_getlogo()
//        {
//            return Logo;
//        }

//        public  virtual string uof_getcopyright()
//        {
//            return Copyright;
//        }

//        public  virtual w_mdi? uof_getmdi()
//        {
//            return wMdi;
//        }

//        public virtual void uof_mostrar_splash(int segundos)
//        {
//            if (at_splash == null)
//                return;

//            at_splash.segundos = segundos;

//            OpenWithParmPB.OpenWithParm(
//                typeof(Minotti.Views.Basicos.w_splash),
//                at_splash
//            );
//        }

//        public  virtual void uof_mostrar_datos_sistema()
//        {
//            cat_app at_app = new cat_app();

//            uof_cargar_datos_sistema(at_app);

//            OpenWithParmPB.OpenWithParm(typeof(w_datos_sistema), at_app);
//        }

//        private void uof_cargar_datos_sistema(cat_app at_app)
//        {
//            // PB: at_app.Nombre = App.DisplayName
//            at_app.Nombre = App != null ? App.DisplayName : string.Empty;
//            at_app.Logo = Logo;
//            at_app.Version = Version;
//            at_app.Copyright = Copyright;
//        }

//        public  virtual cat_usuario uof_getusuario()
//        {
//            return at_usuario;
//        }

//        public  int uof_cargar_datos_usuario()
//        {
//            /* Los datos del usuario se cargan en una función externa... */
//            return f_cargar_datos_usuario.fcargar_datos_usuario(at_usuario, true);
//        }

//        // ===== PB constructor event =====

//        public  override void constructor()
//        {
//            /* Identifica la aplicación que lo llamó */
//            // PB: App = GetApplication()
//            // FIX: usar tu PBApplication
//            //App = PBApplication.GetApplication();

//            /* Toma los datos del entorno */
//            // PB: GetEnvironment(Env)
//            PBEnviroment.GetEnvironment(out Env);

//            Instance ??= this;
//            App ??= new PBApplication();
//        }


//        public virtual void Open()
//        {
//            // PB: Open → dispara ue_open
//            this.ue_open();
//        }
//        public virtual void Close()
//        {
//            // PB: Close → hook de cierre
//        }
//        public virtual void Destroy()
//        {
//            // PB: Destroy → liberar recursos
//            if (this is IDisposable d)
//                d.Dispose();
//        }

//        public virtual void SystemError()
//        {
//            // PB: abre w_system_error
//            try
//            {
//                var frm = new w_system_error();
//                frm.ShowDialog();
//            }
//            catch
//            {
//                MessageBox.Show(
//                    "Error inesperado en la aplicación.",
//                    "System Error",
//                    MessageBoxButtons.OK,
//                    MessageBoxIcon.Error
//                );
//            }
//        }


//    }

//}


