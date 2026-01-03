using Minotti.Data;
using Minotti.Functions;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using System;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Minotti.Views.Repertorizaciones.Controls
{
    /// <summary>
    /// Migrado desde PB Window 'w_carga_reperto_total_multiple_bak' (deriva de w_carga).
    /// Se preservan nombres y se integra la lógica visible del SRW sin inventar.
    /// </summary>

    public partial class w_carga_reperto_total_multiple_bak : w_carga
    {
        // =========================
        // Variables PB
        // =========================
        private uo_ds? ds_reperto;

        public w_carga_reperto_total_multiple_bak()
        {
            InitializeComponent();

            pb_continuar.Click += pb_continuar_Click;
            pb_cancelar.Click += (_, __) => ue_cancelar();
        }

        // =========================
        // PB: ue_leer_parametros
        // =========================
        public override void ue_leer_parametros()
        {
            /*
                ATENCION !!!  ANCESTOR SCRIPT OVERRIDE
            */
            astr_w_seleccion = (str_w_seleccion)utils.Message.PowerObjectParm;
            this.Text = astr_w_seleccion.titulo;

            // DataWindow visible
            dw_1.uof_setdataobject("dk_reperto_total_multiple");
            dw_1.SetTransObject(SQLCA.Instance);
            dw_1.cant_filas = 5;
            dw_1.uof_marcar_seleccion(1);
            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.Fixed3D;

            // DataStore auxiliar
            ds_reperto = new uo_ds();
            ds_reperto.uof_setdataobject("d_reperto_total_multiple");
            ds_reperto.SetTransObject(SQLCA.Instance);

            astr_w_seleccion.opcion = -1;
        }

        // =========================
        // PB: ue_iniciar
        // =========================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            dw_1.uof_retrieve(astr_w_seleccion.parametros);

            if (dw_1.RowCount() > 0)
                dw_1.SelectRow(1, true);
        }

        // =========================
        // PB: ue_continuar
        // =========================
        private void pb_continuar_Click(object? sender, EventArgs e)
        {
            long fila;

            if (dw_1.AcceptText() < 0)
                return;

            fila = dw_1.GetRow();
            if (fila < 1)
            {
                MessageBoxPB.MessageBox(
                    "Atención",
                    "Debe seleccionar al menos un repertorio.",
                    MessageBoxIcon.Stop
                );
                return;
            }

            // Devuelve argumentos (igual que PB)
            dw_1.uof_getargumentos(
                astr_w_seleccion.s_det,
                (int)fila
            );

            astr_w_seleccion.opcion = 1;
            Close();
        }

        // =========================
        // PB: ue_cancelar
        // =========================
        public override void ue_cancelar()
        {
            astr_w_seleccion.opcion = -1;
            Close();
        }

        // =========================
        // PB: destroy
        // =========================
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            ds_reperto?.Dispose();
        }
    }
}