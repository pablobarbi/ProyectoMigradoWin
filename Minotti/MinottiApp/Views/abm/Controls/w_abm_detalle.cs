using Minotti.Data;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Pbl.Views;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Abm.Controls
{
    // global type w_abm_detalle from w_operacion
    public partial class w_abm_detalle : w_operacion
    {
        // PB: boolean ib_Grabar / ib_grabar
        protected bool ib_Grabar = false;
        protected bool ib_grabar = false;


        /* Controles */
        public uo_dw dw_1;
        public st_at_det at_det = new st_at_det();
        public w_abm_detalle()
        {
            InitializeComponent();
        }

        // public function boolean wf_cambios_pendientes()
        public bool wf_cambios_pendientes()
        {
            if (dw_1.AcceptText() == -1 || dw_1.ModifiedCount() > 0)
                return true;

            return false;
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

        // event ue_ajustar_tamaño
        public override void ue_ajustar_tamaño()
        {
            base.ue_ajustar_tamaño();

            /* Fija el tamaño inicial de la ventana */
            this.Width = dw_1.uof_ancho() + s_esp.ancho + 2 * s_esp.borde;
            this.Height = dw_1.uof_largo() + s_esp.largo + 2 * s_esp.borde;
        }

        // event ue_borrar
        public override void ue_borrar()
        {
            base.ue_borrar();

            if (dw_1.DeleteRow(0) != 1) this.ib_grabar = false;
            if (ib_grabar)
            {
                if (dw_1.Update(true, true) != 1) ib_grabar = false;
            }
        }

        // event ue_confirmar
        public override void ue_confirmar()
        {
            base.ue_confirmar();

            /* Graba la datawindow */
            if (dw_1.Update(true, false) != 1)
            {
                /* El mensaje de error lo pone el dberror de la datawindow */
                this.ib_grabar = false;
            }
        }

        // event ue_iniciar
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            int iAux;

            if (at_op.Accion == "A") /* Es un alta */
            {
                dw_1.InsertRow(0);
                dw_1.uof_edicion(0, "E"); /* Pone como editables todos los campos */

                /* Los campos que recibe, los deja como no editables */
                for (iAux = 1; iAux <= UpperBound(at_op.s_det); iAux++)
                {
                    dw_1.uof_edicion(dw_1.ii_claves[iAux], "N");
                }

                /* Se para en la primer clave que no recibe como parámetro */
                if (UpperBound(dw_1.ii_claves) >= iAux)
                    dw_1.SetColumn(dw_1.ii_claves[iAux]);
            }
            else
            {
                dw_1.uof_edicion("K", "E");
                dw_1.uof_edicion("D", "E");

                dw_1.uof_retrieve(at_op.s_det);
            }

            dw_1.SetFocus();
        }

        // event ue_leer_parametros
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            string param;

            /* Carga los parámetros en una variable auxiliar para no perder los originales */
            param = at_op.uof_getparametros();

            /******************************************************************************
             Parámetros:   dw_control, dw_detalle,
                           cantidad de lineas en lista
            ******************************************************************************/
            /* Lee el nombre de la DataWindow de detalle, descartando los 3 primeros parámetros */
            OpenUserObject(dw_1, wf_ProxParam(ref param));
            dw_1.uof_setdataobject(wf_ProxParam(ref param));
            dw_1.SetTransObject(SQLCA.Instance);
            dw_1.cant_filas = Convert.ToInt32(wf_ProxParam(ref param));
        }

        // event ue_optar
        public override void ue_optar()
        {
            base.ue_optar();

            if (IsNull(dw_1.cant_filas) || dw_1.cant_filas == 0) dw_1.cant_filas = 1;

            /* Si es un alta, se queda en la ventana después de grabar */
            if (at_op.Accion == "A")
                this.ib_cerrar_al_grabar = false;
            else
                this.ib_cerrar_al_grabar = true;
        }

        // event close
        public virtual void close()
        {
            base.close();

            if (IsValid(dw_1)) CloseUserObject(dw_1);
        }

        // event activate
        public void activate()
        {
            base.activate();
            PBGlobals.m_mdi.m_insertar.Enabled = false;
        }

        // event ue_validar_datos
        public override void ue_validar_datos()
        {
            base.ue_validar_datos();

            long fila;
            int columna;

            if (dw_1.uof_datoscompletos(out fila, out columna)) return;

            if (fila > 0)
            {
                dw_1.SetRow((int)fila);
                dw_1.SetColumn(columna);
            }

            this.ib_grabar = false;
        }

        // event ue_completar_claves
        public override void ue_completar_claves()
        {
            base.ue_completar_claves();

            int iAux;

            if (at_op.Accion == "A")
            {
                /* Completa la clave con los campos que recibió al abrirse */
                for (iAux = 1; iAux <= UpperBound(at_op.s_det); iAux++)
                {
                    dw_1.uof_setitem(1, dw_1.ii_claves[iAux], at_op.s_det[iAux]);
                }
            }
        }

        // event ue_aceptar_datos
        public override void ue_aceptar_datos()
        {
            base.ue_aceptar_datos();

            if (dw_1.AcceptText() != 1)
            {
                ib_Grabar = false;
                ib_grabar = false;
            }
            else
            {
                ib_Grabar = true;
                ib_grabar = true;
            }
        }

        // event ue_reiniciar
        public override void ue_reiniciar()
        {
            base.ue_reiniciar();

            /* Si es un alta y debe quedarse en la ventana, la reinicia */
            if (this.at_op.Accion == "A")
            {
                dw_1.Reset();
                this.PostEvent(nameof(ue_iniciar)); // equivalente a: This.Event Post ue_iniciar()
            }
            /* Esta parte no se usa en esta ventana, está prevista para las herencias */
            else if (this.at_op.Accion == "M")
            {
                dw_1.ResetUpdate();
            }
        }

        // Helpers PB compatibles (si ya los tenés en base, borrá estos)
        private static int UpperBound<T>(T[]? arr) => (arr == null) ? 0 : arr.Length;
        private static bool IsNull(object? o) => o == null;
        private static bool IsValid(object? o) => o != null;

        // PB event: ue_borrar_item()
        // PB permitía redefinirlo en cada ventana aunque no estuviera declarado en la base.
        // En C# lo declaramos virtual para mantener compatibilidad.
        public virtual void ue_borrar_item()
        {
            // Intentionally empty – PB base implementation does nothing.
        }
        // PB event: ue_insertar_item()
        // PB permitía redefinir este método sin declararlo en la base.
        // En la migración C#, debemos declararlo para que las ventanas hijas puedan overridearlo.
        public virtual void ue_insertar_item()
        {
            // Intentionally empty – PB base implementation does nothing.
        }

        // Estas 3 normalmente existen en w_operacion; acá las dejo como “llamado”:
        private string wf_ProxParam(ref string param) => base.wf_proxparam(param);
        private void OpenUserObject(object target, string name) => base.OpenUserObject(target, name);
        private void CloseUserObject(object target) => base.CloseUserObject(target);

        public virtual int ue_dw_itemchanged(uo_dw dwo, long row, int column, string data)
        {
            return 0;
        }

        public virtual void ue_dw_button_clicked() { }

        /// <summary>
        /// PB: SetFocus()
        /// </summary>
        public virtual void SetFocus()
        {
            // Trae la ventana al frente
            this.Activate();

            // Intenta dar foco
            this.Focus();
        }

    }
}
