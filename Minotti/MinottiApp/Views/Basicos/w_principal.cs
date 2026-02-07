using Minotti.Metadata.GeneratedSru;
using Minotti.Structures;
using Minotti.utils;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Minotti.Views.Basicos
{

    // Migración de PowerBuilder: w_principal.srw (window base)
    // Mantiene el nombre del tipo y estructura st_tamaño_minimo.


    public partial class w_principal : Form
    {

        protected void EnsureDw1()
        {
            if (dw_1 == null)
            {
                dw_1 = new uo_dw
                {
                    Name = "dw_1",
                    Location = new Point(12, 12),
                    Size = new Size(1000, 500)
                };
                this.Controls.Add(dw_1);
            }
        }



        // PB: st_espacios s_esp
        public st_espacios s_esp;  /* Medidas a agregar en alto, ancho y bordes de ventanas */

        // PB: st_tamaño_minimo s_min
        public  st_tamaño_minimo s_min; /* Tamaño mínimo con el que se puede abrir la ventana */

        // PB: Boolean ib_ajustar_posicion = TRUE
        public  bool ib_ajustar_posicion = true;

        // PB: Boolean ib_acomodar = FALSE
        public  bool ib_acomodar = false; /* Indica si la ventana debe o no reacomodar los objetos en el resize */

        public uo_dw dw_1;

        // === Helpers PB ===
        // PB: UpperBound(array)
        protected static int UpperBound<T>(T[]? array) => array?.Length ?? 0;

        /// <summary>
        /// Emula TriggerEvent("ue_xxx") de PowerBuilder llamando a un método con el mismo nombre.
        /// Se usa principalmente desde menús y lógica migrada.
        /// </summary>
        public void TriggerEvent(string eventName, params object?[] args)
        {
            if (string.IsNullOrWhiteSpace(eventName)) return;

            var flags = System.Reflection.BindingFlags.Instance |
                       System.Reflection.BindingFlags.Public |
                       System.Reflection.BindingFlags.NonPublic |
                       System.Reflection.BindingFlags.IgnoreCase;

            var mi = GetType().GetMethod(eventName, flags);
            if (mi == null) return;

            mi.Invoke(this, args);
        }

        /// <summary>
        /// Emula PostEvent("ue_xxx") de PB: ejecuta el evento en el message loop.
        /// </summary>
        public void PostEvent(string eventName, params object?[] args)
        {
            if (IsHandleCreated)
            {
                BeginInvoke(new Action(() => TriggerEvent(eventName, args)));
            }
            else
            {
                // si aún no hay handle, lo ejecuta directo
                TriggerEvent(eventName, args);
            }
        }

        private const int WM_SETREDRAW = 0x000B;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);


        public w_principal()
        {

            // PB: estructuras se inicializan al crear la ventana
            this.s_esp = new st_espacios();
            this.s_min = new st_tamaño_minimo();
            InitializeComponent();
        }

        // =================== Eventos ue_* (equivalentes PB) ===================

        // event ue_leer_parametros()
        protected  virtual void ue_leer_parametros()
        {
            // Implementación en las ventanas hijas
            //MessageBox.Show("ue_leer_parametros EN w_principal");
        }

        // event ue_optar()
        public  virtual void ue_optar()
        {
            if(this.s_esp == null)
                this.s_esp = new st_espacios();

            // PB:
            // This.s_esp.largo = 108
            // This.s_esp.ancho = 30
            // This.s_esp.borde = 20
            this.s_esp.largo = 108;
            this.s_esp.ancho = 30;
            this.s_esp.borde = 20;
        }

        // event ue_ajustar_tamaño()
        public  virtual void ue_ajustar_tamaño()
        {
            // Implementación en hijas
        }

        // event ue_llevar_al_minimo()
        public  virtual void ue_llevar_al_minimo()
        {
            // Implementación en hijas
        }

        // event ue_ajustar_posicion()
        public  virtual void ue_ajustar_posicion()
        {
            // Implementación en hijas
        }

        // event ue_acomodar_objetos()
        public  virtual void ue_acomodar_objetos()
        {
            // Implementación en hijas
        }

        // event ue_iniciar()
        protected  virtual void ue_iniciar()
        {
            // Implementación en hijas
        }

        // event ue_dw_detalle (uo_dw arg_objeto)
        public  virtual void ue_dw_detalle(uo_dw arg_objeto)
        {
            // Implementación en hijas
        }

        // event ue_dw_cambio_fila (uo_dw arg_objeto)
        public  virtual void ue_dw_cambio_fila(uo_dw arg_objeto)
        {
            // Implementación en hijas
        }

        // event type integer ue_dw_itemchanged (uo_dw arg_objeto,  long row,  dwobject dwo,  string data )
        public  virtual int ue_dw_itemchanged(uo_dw arg_objeto, long row, dwobject dwo, string data)
        {
            // PB: Return(0)
            return 0;
        }
        public virtual int ue_dw_itemchanged(uo_dw arg_objeto)
        {
            if (arg_objeto == null)
                return 0;

            long row = arg_objeto.GetRow();
            dwobject dwo = arg_objeto.GetDWObject();
            string data = arg_objeto.GetText() ?? string.Empty;

            return ue_dw_itemchanged(arg_objeto, row, dwo, data);
        }


        public virtual int ue_dw_itemchanged()
        {
            //// Reconstrucción PB-style
            //uo_dw arg_objeto = this.dw_1;   // o el DW que dispara el evento
            //long row = arg_objeto?.GetRow() ?? 0;
            //dwobject dwo = arg_objeto?.GetDWObject()!;
            //string data = arg_objeto?.GetText() ?? string.Empty;

            //return ue_dw_itemchanged(arg_objeto, row, dwo, data);
            return 0;
        }


        // event type integer ue_us_insertar_before ( uo_dw arg_obj )
        public virtual int ue_us_insertar_before(uo_dw arg_obj)
        {
            /* Retorno : 1     -- Bien
                         <= 0  -- Error */
            return 1;
        }

        // event type integer ue_us_insertar_end ( uo_dw arg_obj )
        public  virtual int ue_us_insertar_end(uo_dw arg_obj)
        {
            return 1;
        }

        // event type integer ue_us_insertar_fila ( uo_dw arg_obj,  long fila )
        public  virtual int ue_us_insertar_fila(uo_dw arg_obj, long fila)
        {
            return 1;
        }

        // event type integer ue_us_eliminar_before ( uo_dw arg_obj )
        public  virtual int ue_us_eliminar_before(uo_dw arg_obj)
        {
            return 1;
        }

        // event type integer ue_us_eliminar_end ( uo_dw arg_obj )
        public  virtual int ue_us_eliminar_end(uo_dw arg_obj)
        {
            return 1;
        }

        // event type integer ue_us_eliminar_fila ( uo_dw arg_obj,  long fila )
        public  virtual int ue_us_eliminar_fila(uo_dw arg_obj, long fila)
        {
            return 1;
        }

        // event ue_dw_button_clicked ( uo_dw dwo,  long row,  dwobject objeto )
        public  virtual void ue_dw_button_clicked(uo_dw dwo, long row, dwobject objeto)
        {
            // Implementación en hijas
        }

        // =================== wf_proxparam ===================

        // public function string wf_proxparam (ref string param)
        public  string wf_proxparamOld(string param)
        {
            /*
            Llama a esta misma función pidiendo el siguiente parámetro.
            Sirve para hacer opcional el segundo parámetro
            */
            return wf_proxparamOld(param, 1);
        }

        // public function string wf_proxparam (ref string param, integer orden_buscado)
        public  string wf_proxparamOld(string param, int orden_buscado)
        {
            /* Elimina los n primeros parametros del string que viene en param */
            int iFin;
            int contador;
            string retorno = string.Empty;

            /* Saltea los anteriores al buscado */
            for (contador = 1; contador <= orden_buscado - 1; contador++)
            {
                iFin = param.IndexOf(',');
                if (iFin > 0)
                {
                    param = param.Substring(iFin + 1).Trim();
                }
                else
                {
                    param = string.Empty;
                    break;
                }
            }

            iFin = param.IndexOf(',');
            if (iFin > 0)
            {
                retorno = param.Substring(0, iFin).Trim();
                param = param.Substring(iFin + 1).Trim();
            }
            else
            {
                retorno = param.Trim();
                param = string.Empty;
            }

            return retorno;
        }

        // =================== Eventos open / resize / close ===================

        // PB: event open
        //protected override void OnLoadOld(EventArgs e)
        //{
        //    base.OnLoad(e);

        //    // ============================
        //    // Inicializa dw_1 SOLO si es null
        //    // ============================
        //    if (this.dw_1 == null)
        //    {
        //        this.dw_1 = new uo_dw
        //        {
        //            Name = "dw_1",
        //            Location = new Point(12, 12),
        //            Size = new Size(1000, 500)
        //        };
        //        this.Controls.Add(dw_1);
        //    }

        //    // ============================
        //    // Título de la ventana
        //    // ============================
        //    if (string.IsNullOrEmpty(this.Text))
        //    {
        //        try
        //        {
        //            this.Text = guo_app.App?.DisplayName ?? "Minotti";
        //        }
        //        catch { }
        //    }

        //    Cursor.Current = Cursors.WaitCursor;
        //    this.SuspendLayout();

        //    // ============================
        //    // Inicialización PB-like
        //    // ============================
        //    this.ue_optar();

        //    this.ue_iniciar();          // inicializa lógica
        //    this.ue_ajustar_tamaño();   // ajusta tamaños con dw_1 ya creado
        //    this.ue_acomodar_objetos();

        //    this.ue_llevar_al_minimo();
        //    this.ue_leer_parametros();

        //    if (ib_ajustar_posicion)
        //    {
        //        this.BeginInvoke(new Action(() =>
        //        {
        //            if (!this.IsDisposed)
        //            {
        //                this.ue_ajustar_posicion();
        //            }
        //        }));
        //    }

        //    ib_acomodar = true;

        //    this.ResumeLayout(true);
        //    Cursor.Current = Cursors.Default;
        //}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // ============================
            // Ocultar MDI Client al inicio (PB-like)
            // ============================
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient mdi)
                {
                    mdi.Visible = false;     // 🔴 CLAVE
                    mdi.BackColor = this.BackColor;
                }
            }

            // ============================
            // Título de la ventana
            // ============================
            if (string.IsNullOrEmpty(this.Text))
            {
                try
                {
                    this.Text = guo_app.App?.DisplayName ?? "Minotti";
                }
                catch { }
            }

            Cursor.Current = Cursors.WaitCursor;
            this.SuspendLayout();

            // ============================
            // Inicialización PB-like
            // ============================
            this.ue_optar();
            this.ue_iniciar();
            this.ue_ajustar_tamaño();
            this.ue_acomodar_objetos();
            this.ue_llevar_al_minimo();
            this.ue_leer_parametros();

            if (ib_ajustar_posicion)
            {
                this.BeginInvoke(new Action(() =>
                {
                    if (!this.IsDisposed)
                    {
                        this.ue_ajustar_posicion();
                    }
                }));
            }

            this.ResumeLayout(true);
            Cursor.Current = Cursors.Default;
        }

        public void ShowMdiClient()
        {
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient mdi)
                {
                    mdi.Visible = true;
                    mdi.BringToFront();
                }
            }
        }

        // PB: event resize
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // If ib_acomodar Then This.TriggerEvent("ue_acomodar_objetos")
            if (ib_acomodar)
            {
                this.ue_acomodar_objetos();
            }
        }

        // PB: event close
        protected  override void OnFormClosing(FormClosingEventArgs e)
        {
            // This.ib_acomodar = False
            ib_acomodar = false;

            /* Habilita el redibujo de la ventana, por si al cerrarse quedó deshabilitado */
            this.ResumeLayout(true);

            // GarbageCollect() no aplica en .NET, lo dejamos comentado
            base.OnFormClosing(e);
        }


        public  virtual void ue_grabar()
        {
            // implementación default vacía
        }

        public  virtual int ue_validar_string()
        {
            return 1; // default PB-like: OK
        }

        public virtual void SetRedraw(bool enable)
        {
            if (!IsHandleCreated) return;

            SendMessage(this.Handle, WM_SETREDRAW, enable ? (IntPtr)1 : IntPtr.Zero, IntPtr.Zero);

            if (enable)
            {
                // fuerza refresh al reactivar
                this.Invalidate(true);
                this.Update();
            }
        }

        // =====================================================
        // PB: event ue_mandar_menu_fondo (window w_actual)
        // Evento base (no hace nada por defecto)
        // =====================================================
        public virtual void ue_mandar_menu_fondo(Form w_actual)
        {
            // En PB, el base puede estar vacío.
            // La lógica real vive en w_mdi.
        }
        public void SetMicroHelp(string texto)
        {
            // PB: SetMicroHelp()
            // WinForms: normalmente status bar / label inferior

            if (string.IsNullOrWhiteSpace(texto))
                texto = string.Empty;

            // Opción A: StatusStrip
            if (this.statusStrip1 != null && this.toolStripStatusLabelMicroHelp != null)
            {
                this.toolStripStatusLabelMicroHelp.Text = texto;
                return;
            }

            // Opción B: Label simple (fallback)
            if (this.lblMicroHelp != null)
            {
                this.lblMicroHelp.Text = texto;
                return;
            }

            // Opción C: fallback silencioso (no rompe ejecución)
            // Debug.WriteLine($"MicroHelp: {texto}");
        }

        // =====================================================
        // PB: GetContextService
        // =====================================================
        public virtual void GetContextService(
            string serviceName,
            out ContextInformation service)
        {
            // En PB devuelve servicios del runtime.
            // En .NET solo necesitamos ContextInformation.
            service = new ContextInformation();
        }

        // =====================================================
        // PB: TriggerEvent("ue_xxx")
        // =====================================================
        public virtual void TriggerEvent(string eventName)
        {
            if (string.IsNullOrWhiteSpace(eventName))
                return;

            // Busca un método con ese nombre (PB events)
            var method = this.GetType().GetMethod(
                eventName,
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic);

            if (method == null)
                return;

            // Invoca el evento/método
            method.Invoke(this, null);
        }
    }

}
