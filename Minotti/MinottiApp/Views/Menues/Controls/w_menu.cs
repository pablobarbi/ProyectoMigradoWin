using Minotti.Functions;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;

namespace Minotti.Views.Menues.Controls
{
    // ==========================
    // PB:
    // global type w_menu from w_sheet
    // ==========================
    public partial class w_menu : w_sheet
    {
        // =========================
        // PB: structure st_nivel
        // =========================
        protected struct st_nivel
        {
            public string titulo;
            //public datastore dw;
            public IDataWindow dw;
            public int activo;

            // ✅ Agregalo si no existe
            public string objectparam;
        }

        // =========================
        // PB: variables
        // =========================
        protected st_nivel[] s_nvl;
        protected int nivel_actual;
        protected IDataWindow dw_param;

        public w_menu()
        {
            InitializeComponent();
        }

        // =========================================================
        // PB event: ue_ejecutar ( string modulo, string operacion )
        // =========================================================
        public virtual void ue_ejecutar(string modulo, string operacion)
        {
            cat_operacion at_op = new cat_operacion();
            int iAux;

            // Lee los datos de la operación que va a ejecutar
            at_op.Modulo = modulo;
            at_op.Operacion = operacion;

            if (f_cargar_datos_operacion.fcargar_datos_operacion(ref at_op) != 1)
            {
                MessageBox.Show(
                    $"No se encontró la operación.\r\nMódulo: {modulo}\r\nOperación: {operacion}",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Carga el arreglo con los parámetros
            dw_param.SetFilter($"operacion = '{operacion}'");
            dw_param.Filter();

            if (dw_param.RowCount() < 1)
            {
                MessageBox.Show(
                    $"No se encontraron los parámetros de la operación.\r\nOperación: {operacion}",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            for (iAux = 1; iAux <= dw_param.RowCount(); iAux++)
            {
                var nivel = new cat_operacion_nivel
                {
                    Objeto = dw_param.GetItemString(iAux, "objeto"),
                    Titulo = dw_param.GetItemString(iAux, "titulo"),
                    Parametros = dw_param.GetItemString(iAux, "parametros"),
                    Cierra = dw_param.GetItemString(iAux, "cierra")
                };

                at_op.at_nvl.Add(nivel);
            }


            at_op.Orden = 1;
            at_op.w_anterior = this;

            // Agrega la descripcion de las operaciones en el microhelp.
            ParentWindow().SetMicroHelp(at_op.Descripcion);

            // Abre la operación
            wf_abrir_detalle(at_op);
        }

        // =========================
        // PB: create
        // =========================
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }



        // =========================
        // PB event: ue_leer_parametros
        // =========================
        protected override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            cat_usuario at_usuario;
            int iAux;
            int niveles;
            string param;

            // Lee los parámetros para cargar los niveles necesarios
            param = f_getmenu.fgetmenu();

            // Crea los niveles de menú requeridos
            niveles = Convert.ToInt32(f_proxparam.fproxparam(ref param));
            s_nvl = new st_nivel[niveles + 1];

            for (iAux = 1; iAux <= niveles; iAux++)
            {
                s_nvl[iAux].titulo = f_proxparam.fproxparam(ref param);

                // 👇 acá estaba la magia PB → ahora es reflexión
                string dwName = f_proxparam.fproxparam(ref param);

                s_nvl[iAux].dw = DwFactory.Create(dwName);
                s_nvl[iAux].activo = 1;
                s_nvl[iAux].objectparam = dwName;
            }

            // ===== DataWindow de parámetros de operaciones =====
            string dwParamName = f_proxparam.fproxparam(ref param);
            dw_param = DwFactory.Create(dwParamName);

            // ===== Usuario conectado =====
            at_usuario = guo_app.uof_GetUsuario();

            // ===== NIVEL 1 =====
            s_nvl[1].dw.Retrieve(at_usuario.Usuario);

            // ===== NIVELES 2..N =====
            // ⚠️ OJO: esto todavía es genérico, el parámetro real
            // lo va a definir el nodo padre seleccionado
            for (iAux = 2; iAux < s_nvl.Length; iAux++)
            {
                s_nvl[iAux].dw.Retrieve(at_usuario.Perfil);
            }

            // ===== Operaciones =====
            dw_param.Retrieve(at_usuario.Perfil);
        }


        // =========================
        // PB event: ue_ajustar_posicion
        // =========================
        public override void ue_ajustar_posicion()
        {
            base.ue_ajustar_posicion();

            int ancho_mdi;
            int largo_mdi;

            this.Left = 1;
            this.Top = 1;

            guo_app.uof_Getmdi().wf_getareatrabajo(out ancho_mdi, out largo_mdi);

            this.Width = ancho_mdi;
            this.Height = largo_mdi;
        }

        // =========================
        // PB event: activate (vacío)
        // =========================
        protected override void OnActivated(EventArgs e)
        {
            // No permite que se active el evento cancelar
            base.OnActivated(e);
        }

        // =========================
        // Helper PB: UpperBound
        // =========================
        protected int UpperBound(Array arr)
        {
            return arr.Length - 1;
        }
        protected void PostEvent_ue_ejecutar(string modulo, string operacion)
        {
            // PB: Event Post ue_ejecutar(...)
            // WinForms equivalente: BeginInvoke (asíncrono)
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    this.ue_ejecutar(modulo, operacion);
                }));
            }
            else
            {
                // fallback síncrono (muy raro)
                this.ue_ejecutar(modulo, operacion);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // PB event: close
            if (s_nvl != null)
            {
                for (int i = 1; i <= UpperBound(s_nvl); i++)
                {
                    if (s_nvl[i].dw != null)
                        s_nvl[i].dw.Destroy();
                }
            }

            if (dw_param != null)
                dw_param.Destroy();

            base.OnFormClosed(e);
        }

    }


}
