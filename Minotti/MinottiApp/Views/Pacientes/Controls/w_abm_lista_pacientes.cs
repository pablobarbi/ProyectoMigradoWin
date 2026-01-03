using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Abm.Controls;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Pbl.Views;
using System;
using System.Data;
using System.Windows.Forms;

namespace Minotti.Views.Pacientes.Controls
{
    public partial class w_abm_lista_pacientes : w_abm_lista
    {
        // ========================
        // Variables PB
        // ========================
        private string is_nombre_columna;
        private string idata;
        private int il_q_filas;
        private string is_back_color = "15794175";
        private bool ib_modificar_dw_busqueda = false;

        // Control
        protected uo_dw dw_buscar;

        public w_abm_lista_pacientes()
        {
            InitializeComponent();
        }

        // ========================
        // create / destroy
        // ========================
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dw_buscar = new uo_dw();
            this.Controls.Add(dw_buscar);
        } 

        // ========================
        // activate
        // ========================
        public override void activate()
        {
            base.activate();
           PBGlobals.m_mdi.m_confirmar.Enabled = false;
        }

        // ========================
        // ue_leer_parametros
        // ========================
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            dw_buscar.uof_setdataobject(dw_1.DataObject);
            dw_buscar.SetTransObject(SQLCA.Instance);
            dw_buscar.cant_filas = 1;

            dw_buscar.Modify("Datawindow.Header.Height=0");
            dw_buscar.Modify("Datawindow.Footer.Height=0");
            dw_buscar.Modify("Datawindow.Summary.Height=0");
            dw_buscar.Modify("Datawindow.Color=" + this.BackColor);
        }

        // ========================
        // ue_ajustar_tamaño
        // ========================
        public override void ue_ajustar_tamaño()
        {
            this.Width = dw_1.uof_ancho() + s_esp.ancho + 2 * s_esp.borde;
            this.Height = dw_1.uof_largo() + s_esp.largo + 2 * s_esp.borde
                          + dw_buscar.uof_largo() + 80;
        }

        // ========================
        // ue_acomodar_objetos
        // ========================
        public override void ue_acomodar_objetos()
        {
            int largo_dw1 = this.wf_largo_disponible()
                            - s_esp.borde
                            - dw_buscar.uof_largo();

            dw_1.Width = Math.Min(dw_1.uof_ancho(), this.wf_ancho_disponible());
            dw_1.Height = largo_dw1;
            dw_1.Y = s_esp.borde;
            this.wf_centrarobjeto(dw_1);

            dw_buscar.Height = dw_buscar.uof_largo();
            dw_buscar.Width = dw_1.Width;
            dw_buscar.X = dw_1.X;
            dw_buscar.Y = dw_1.Y + dw_1.Height + s_esp.borde;
        }

        // ========================
        // ue_borrar (override)
        // ========================
        public override void ue_borrar()
        {
            long ll_Paciente;
            long row = dw_1.GetRow();

            is_Accion = "B";

            if (row < 1)
            {
                ib_grabar = false;
                return;
            }

            ll_Paciente = (long)dw_1.GetItemNumber(row, "paciente");

            if (dw_1.DeleteRow(row) != 1)
                ib_grabar = false;

            if (ib_grabar && dw_1.Update(true, true) != 1)
                ib_grabar = false;

            if (!ib_grabar)
            {
                dw_1.RowsMove(1, dw_1.DeletedCount(), RowMoveType.Delete, dw_1, row);
                dw_1.SetRow((int)row);
                return;
            }

            // ===== SQL PB =====
            SQLCA.ExecuteNonQuery(
                "DELETE FROM pacientes_historias WHERE paciente = ?",
                cmd => SQLCA.AddParam(cmd, ll_Paciente)
            );

            if (SQLCA.SqlCode < 0)
            {
                MessageBox.Show(
                    "Error Borrando Historia del Paciente",
                    "Guardando",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                ib_grabar = false;
                return;
            }

            SQLCA.ExecuteNonQuery(
                "DELETE FROM diagnosticos WHERE paciente = ?",
                cmd => SQLCA.AddParam(cmd, ll_Paciente)
            );

            if (SQLCA.SqlCode < 0)
            {
                MessageBox.Show(
                    "Error Borrando Diagnóstico del Paciente",
                    "Guardando",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                ib_grabar = false;
            }
        }
    }

}