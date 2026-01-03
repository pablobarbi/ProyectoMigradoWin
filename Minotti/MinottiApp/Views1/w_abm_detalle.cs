using System;
using System.Windows.Forms;

namespace Minotti.Views
{
    public partial class w_abm_detalle : Form
    {
        private dynamic dw_1; // uo_dw
        private dynamic at_op;
        private dynamic s_esp;
        private dynamic SQLCA;
        private bool ib_grabar;
        private bool ib_cerrar_al_grabar;

        public w_abm_detalle()
        {
            InitializeComponent();
        }

        public bool wf_cambios_pendientes()
        {
            if (dw_1.AcceptText() == -1 || dw_1.ModifiedCount() > 0)
                return true;
            else
                return false;
        }

        public void ue_acomodar_objetos()
        {
            dw_1.Width = Math.Min(dw_1.uof_ancho(), wf_Ancho_Disponible());
            wf_CentrarObjeto(dw_1);

            if (dw_1.cant_filas == 1)
                dw_1.Height = Math.Min(dw_1.uof_largo(), wf_Largo_Disponible());
            else
                dw_1.Height = wf_Largo_Disponible();

            dw_1.Y = s_esp.borde;
        }

        public void ue_ajustar_tamaño()
        {
            this.Width = dw_1.uof_ancho() + s_esp.ancho + 2 * s_esp.borde;
            this.Height = dw_1.uof_largo() + s_esp.largo + 2 * s_esp.borde;
        }

        public void ue_borrar()
        {
            if (dw_1.DeleteRow(0) != 1)
                ib_grabar = false;

            if (ib_grabar)
            {
                if (dw_1.Update(true, true) != 1)
                    ib_grabar = false;
            }
        }

        public void ue_confirmar()
        {
            if (dw_1.Update(true, false) != 1)
                ib_grabar = false;
        }

        public void ue_iniciar()
        {
            int iAux;

            if (at_op.Accion == "A")
            {
                dw_1.InsertRow(0);
                dw_1.uof_Edicion(0, "E");

                for (iAux = 1; iAux <= at_op.s_det.Length; iAux++)
                {
                    dw_1.uof_Edicion(dw_1.ii_claves[iAux], "N");
                }

                if (dw_1.ii_claves.Length >= iAux)
                    dw_1.SetColumn(dw_1.ii_claves[iAux]);
            }
            else
            {
                dw_1.uof_Edicion("K", "N");
                dw_1.uof_Edicion("D", "E");
                dw_1.uof_Retrieve(at_op.s_det);
            }

            dw_1.SetFocus();
        }

        public void ue_leer_parametros()
        {
            string param = at_op.uof_GetParametros();

            string dataWindowName = wf_ProxParam(param);
            OpenUserObject(dw_1, dataWindowName);
            dw_1.uof_SetDataObject(dataWindowName);
            dw_1.SetTransObject(SQLCA);
            dw_1.cant_filas = Convert.ToInt32(wf_ProxParam(param));
        }

        public void ue_optar()
        {
            if (dw_1.cant_filas == null || dw_1.cant_filas == 0)
                dw_1.cant_filas = 1;

            ib_cerrar_al_grabar = at_op.Accion != "A";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // call w_operacion::create
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            // call w_operacion::destroy
        }

        public void close()
        {
            if (IsValid(dw_1))
                CloseUserObject(dw_1);
        }

        public void activate()
        {
            // m_mdi.m_operaciones.m_insertar.Enabled = false;
        }

        public void ue_validar_datos()
        {
            long fila = 0;
            int columna = 0;

            if (dw_1.uof_DatosCompletos(out fila, out columna))
                return;

            if (fila > 0)
            {
                dw_1.SetRow(fila);
                dw_1.SetColumn(columna);
            }

            ib_grabar = false;
        }

        public void ue_completar_claves()
        {
            int iAux;

            if (at_op.Accion == "A")
            {
                for (iAux = 1; iAux <= at_op.s_det.Length; iAux++)
                {
                    dw_1.uof_SetItem(1, dw_1.ii_claves[iAux], at_op.s_det[iAux]);
                }
            }
        }

        public void ue_aceptar_datos()
        {
            if (dw_1.AcceptText() != 1)
                ib_grabar = false;
        }

        public void ue_reiniciar()
        {
            if (at_op.Accion == "A")
            {
                dw_1.Reset();
                BeginInvoke((Action)(() => ue_iniciar()));
            }
            else if (at_op.Accion == "M")
            {
                dw_1.ResetUpdate();
            }
        }

        // Métodos simulados que deberías implementar o reemplazar
        private int wf_Ancho_Disponible() => 600;
        private int wf_Largo_Disponible() => 400;
        private void wf_CentrarObjeto(dynamic obj) { }
        private string wf_ProxParam(string p) => p;
        private void OpenUserObject(dynamic control, string name) { }
        private void CloseUserObject(dynamic control) { }
        private bool IsValid(dynamic control) => control != null;
    }
}
