using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Basicos.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Abm.Controls
{
    // global type w_abm_lista from w_operacion
    public partial class w_abm_lista : w_abm_detalle
    {
        /* Controles */
        public uo_dw dw_1;
        
        // Protected:
        protected bool flag_alta = false;

        public w_abm_lista()
        {
            InitializeComponent();
            
        }

        // event activate
        public virtual void activate()
        {
            base.activate();

            /* La modificación es resuelta por la ventana de detalle */
            //m_mdi.m_operaciones.m_confirmar.Enabled = false;
            PBGlobals.m_mdi.m_confirmar.Enabled = false;
        }

        //public virtual int ue_dw_itemchanged(uo_dw dwo, long row, int column, string data)
        //{
        //    // PB-migration base implementation (intentionally empty)
        //    return 0;
        //}
        // ===============================================================
        // PB Event: ue_dw_itemchanged
        // PB permitía que cualquier ventana ABM redefina este evento,
        // incluso si no existía en la base. En C# debemos declararlo.
        // ===============================================================
        public virtual int ue_dw_itemchanged(uo_dw dwo, long row, int column, string data)
        {
            // PB default: do nothing
            return 0;
        }

        // event ue_ajustar_tamaño
        public override void ue_ajustar_tamaño()
        {
            base.ue_ajustar_tamaño();

            /* Fija el tamaño inicial de la ventana */
            this.Width = dw_1.uof_ancho() + s_esp.ancho + 2 * s_esp.borde;
            this.Height = dw_1.uof_largo() + s_esp.largo + 2 * s_esp.borde;
        }

        // event ue_acomodar_objetos
        public override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            /* Podría ser una función para acomodar una sola datawindow */
            dw_1.Width = Math.Min(dw_1.uof_ancho(), this.wf_ancho_disponible());
            this.wf_centrarobjeto(dw_1);

            if (dw_1.cant_filas == 1)
                dw_1.Height = Math.Min(dw_1.uof_largo(), this.wf_largo_disponible());
            else
                dw_1.Height = this.wf_largo_disponible();

            dw_1.Top = s_esp.borde;
        }

        // event ue_optar
        public override void ue_optar()
        {
            base.ue_optar();

            if (IsNull(dw_1.cant_filas) || dw_1.cant_filas == 0) dw_1.cant_filas = 10;
        }

        // event ue_leer_parametros
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            string param;

            /* Carga los parámetros en una variable auxiliar para no perder los originales */
            param = at_op.uof_getparametros();

            /******************************************************************************
             Parámetros:   dw_control, dw_lista,
                           cantidad de lineas en lista
            ******************************************************************************/
            /* Lee el nombre de la lista */
            OpenUserObject(dw_1, wf_ProxParam(ref param));
            dw_1.uof_setdataobject(wf_ProxParam(ref param));
            dw_1.SetTransObject(SQLCA.Instance);
            dw_1.uof_marcar_seleccion(1);
            dw_1.Border = true;
            dw_1.BorderStyle = (BorderStyle)StyleLowered;
            // dw_1.uof_setdwimpresion(wf_ProxParam(param))

            /* Lee la cantidad de líneas que va a mostrar */
            dw_1.cant_filas = Convert.ToInt32(wf_ProxParam(ref param));

            /* Pone todos los campos con estilo "No Editable" */
            // If dw_1.uof_aplicar_estilos() Then 
            // dw_1.uof_edicion(0, "N")
        }

        // event ue_iniciar
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            if (at_op.Accion == "A")
            {
                // This.TriggerEvent("ue_insertar")
            }
            else
            {
                /* Carga los datos de dw_1 
                   Si no tiene datos, verifica si el usuario tiene permiso para insertar un registro
                   nuevo y en ese caso llama a la ventana siguiente */
                if (dw_1.uof_retrieve(at_op.s_det) < 1)
                {
                    // If m_mdi.m_operaciones.m_insertar.Enabled Then This.TriggerEvent("ue_insertar")
                }
                else
                {
                    dw_1.SetFocus();
                    // dw_1.SetRow(1)
                }
            }
        }

        // event ue_borrar
        public override void ue_borrar()
        {
            base.ue_borrar();

            int iAux;

            iAux = dw_1.GetRow();
            if (iAux < 1) this.ib_grabar = false;

            if (this.ib_grabar)
            {
                if (dw_1.DeleteRow(iAux) != 1) this.ib_grabar = false;
            }

            if (this.ib_grabar)
            {
                if (dw_1.Update(true, true) != 1) this.ib_grabar = false;
            }

            if (this.ib_grabar)
            {
                /* No se cierra al borrar un registro de la lista */
                this.ib_cerrar_al_grabar = false;
            }
            else
            {
                dw_1.RowsMove(1, dw_1.DeletedCount(), dwbuffer.Delete, dw_1, iAux, dwbuffer.Primary);
                dw_1.SetRow(iAux);
                // dw_1.Sort()
            }
        }

        // event ue_insertar
        public override void ue_insertar()
        {
            base.ue_insertar();

            /* La variable This.is_Accion es puesta en "A" por w_operacion */
            this.TriggerEvent("ue_abrir_siguiente");
        }

        // event ue_dw_detalle
        public override void ue_dw_detalle()
        {
            base.ue_dw_detalle();

            this.is_Accion = "M";
            this.TriggerEvent("ue_abrir_siguiente");
        }

        // event close
        public virtual void close()
        {
            base.close();

            if (IsValid(dw_1)) CloseUserObject(dw_1);
        }

        // event ue_primero
        public override void ue_primero()
        {
            base.ue_primero();
            dw_1.ScrollToRow(0);
        }

        // event ue_ultimo
        public override void ue_ultimo()
        {
            base.ue_ultimo();
            dw_1.ScrollToRow(dw_1.RowCount());
        }

        // event ue_anterior
        public override void ue_anterior()
        {
            base.ue_anterior();
            dw_1.ScrollPriorRow();
        }

        // event ue_siguiente
        public override void ue_siguiente()
        {
            base.ue_siguiente();
            dw_1.ScrollNextRow();
        }

        // event ue_preparar_siguiente
        public override void ue_preparar_siguiente()
        {
            base.ue_preparar_siguiente();

            /* Carga los datos necesarios en la estructura que pasará como argumento */
            at_det.Accion = this.is_Accion;

            /* Le avisa al detalle la operación que debe resolver */
            if (is_Accion == "A")
            {
                at_det.Alta = false;
                at_det.Modificacion = true;
                at_det.Baja = false;
            }
            else
            {
                dw_1.uof_getargumentos(at_det.s_det, dw_1.GetRow());
            }

            //return true;
        }

        private static int UpperBound<T>(T[]? arr) => (arr == null) ? 0 : arr.Length;
        private static bool IsNull(object? o) => o == null;
        private static bool IsValid(object? o) => o != null;

        private string wf_ProxParam(ref string param) => base.wf_proxparam(param);
        private void OpenUserObject(object target, string name) => base.OpenUserObject(target, name);
        private void CloseUserObject(object target) => base.CloseUserObject(target);



        // ===============================================================
        // PB Event: ue_dw_button_clicked
        // PB permite redefinir este evento en cualquier ventana ABM,
        // por lo tanto la base debe declararlo como virtual.
        // ===============================================================
        public virtual void ue_dw_button_clicked(object objeto)
        {
            // comportamiento PB por defecto: nada
        }




        // placeholders para “constantes PB”
        private const int StyleLowered = 1;
    }
}
