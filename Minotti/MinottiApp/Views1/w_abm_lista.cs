using System;
using System.Windows.Forms;

namespace Minotti.Views
{
    public partial class w_abm_lista : Form
    {
        private dynamic dw_1; // uo_dw
        private dynamic s_esp;
        private bool flag_alta = false;

        public w_abm_lista()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            // La modificación es resuelta por la ventana de detalle
            // m_mdi.m_operaciones.m_confirmar.Enabled = false;
        }

        public void ue_ajustar_tamaño()
        {
            this.Width = dw_1.uof_ancho() + s_esp.ancho + 2 * s_esp.borde;
            this.Height = dw_1.uof_largo() + s_esp.largo + 2 * s_esp.borde;
        }

        public void ue_borrar()
        {
            // base.ue_borrar();
            if (dw_1.DeleteRow(0) != 1)
                this.ib_grabar = false;

            if (ib_grabar)
            {
                if (dw_1.Update(true, true) != 1)
                    ib_grabar = false;
            }
        }

        public void ue_confirmar()
        {
            // base.ue_confirmar();
            if (dw_1.Update(true, false) != 1)
            {
                // mensaje de error lo pone el dberror de la datawindow
                this.ib_grabar = false;
            }
        }

        public void ue_iniciar()
        {
            // base.ue_iniciar();
            dw_1.SetTransObject(SQLCA);
            dw_1.Retrieve();
        }

        public void ue_reiniciar()
        {
            // base.ue_reiniciar();
            dw_1.Reset();
            BeginInvoke((Action)(() => ue_iniciar()));
        }

        public void ue_validar_datos()
        {
            // base.ue_validar_datos();
            long fila = 0;
            int columna = 0;

            if (dw_1.uof_DatosCompletos(out fila, out columna))
                return;

            if (fila > 0)
            {
                dw_1.SetRow(fila);
                dw_1.SetColumn(columna);
            }

            this.ib_grabar = false;
        }

        public void ue_aceptar_datos()
        {
            // base.ue_aceptar_datos();
            if (dw_1.AcceptText() != 1)
                ib_grabar = false;
        }

        public void ue_doble_click()
        {
            // base.ue_doble_click();
            this.Close();
        }

        // Variables auxiliares (simuladas)
        private bool ib_grabar = true;
        private dynamic SQLCA;

        // Métodos auxiliares simulados
        private bool IsValid(dynamic ctrl) => ctrl != null;
    }
}
