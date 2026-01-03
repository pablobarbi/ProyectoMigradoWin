using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti.Views.Repertorizaciones.Controls
{
    /// <summary>
    /// Migrado desde PowerBuilder Window 'w_carga_reperto_total' (deriva de w_carga).
    /// Se preservan nombres y se integra la lógica visible del SRW sin inventar.
    /// </summary>
    public partial class w_carga_reperto_total : w_carga
    {
        // ===== PB variables =====
        private uo_ds? ds_reperto_total;

        public w_carga_reperto_total()
        {
            InitializeComponent();

            if (pb_cancelar != null)
                pb_cancelar.Click += (_, __) => ue_cancelar();

            if (pb_continuar != null)
                pb_continuar.Click += pb_continuar_Click;
        }

        // =========================
        // PB: event ue_leer_parametros
        // =========================
        public override void ue_leer_parametros()
        {
            /*
                ATENCION !!!  ANCESTOR SCRIPT OVERRIDE
            */
            astp_w_seleccion = (stp_w_seleccion)utils.Message.PowerObjectParm;
            this.Text = astp_w_seleccion.titulo;

            // DW principal
            dw_1.uof_setdataobject("dk_reperto_total");
            dw_1.SetTransObject(SQLCA.Instance);
            dw_1.cant_filas = 5;
            dw_1.uof_marcar_seleccion(1);
            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.Fixed3D;

            // DataStore
            ds_reperto_total = new uo_ds();
            ds_reperto_total.uof_setdataobject("d_reperto_total");
            ds_reperto_total.SetTransObject(SQLCA.Instance);

            astr_w_seleccion.opcion = -1;
        }

        // =========================
        // PB: event ue_iniciar
        // =========================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            astp_w_seleccion = (stp_w_seleccion)utils.Message.PowerObjectParm;
            dw_1.uof_retrieve(astp_w_seleccion.parametros);

            if (dw_1.RowCount() > 0)
                dw_1.SelectRow(1, true);
        }

        // =========================
        // PB: event ue_continuar
        // =========================
        private void pb_continuar_Click(object? sender, EventArgs e)
        {
            long ll_Fila;

            if (dw_1.AcceptText() < 0)
                return;

            ll_Fila = dw_1.GetRow();
            if (ll_Fila < 1)
            {
                MessageBoxPB.MessageBox("Atención", "Debe seleccionar un repertorio.", MessageBoxIcon.Stop);
                return;
            }

            // Devuelvo el repertorio seleccionado
            dw_1.uof_getargumentos(
                astr_w_seleccion.s_det,
                (int)ll_Fila
            );

            astr_w_seleccion.opcion = 1;
            this.Close();
        }

        // =========================
        // PB: event ue_cancelar
        // =========================
        public override void ue_cancelar()
        {
            astr_w_seleccion.opcion = -1;
            this.Close();
        }

        // =========================
        // PB: close
        // =========================
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (ds_reperto_total != null)
                ds_reperto_total.Dispose();
        }
    }
}