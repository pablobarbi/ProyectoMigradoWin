
using Minotti.Data;
using Minotti.Functions;
using Minotti.Repositories;
using Minotti.Views.Abm.Controls;
using Minotti.Views.Basicos.Models;
using MinottiApp.utils;
using System;
using System.Data.Odbc;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{
    public partial class w_abm_lista_subrubricas_ph : w_abm_lista_seleccion
    {
        // === variables PB ===
        protected long il_Nivel;
        protected decimal il_SubRubrica;
        protected string[] is_Subrubrica = Array.Empty<string>();

        public w_abm_lista_subrubricas_ph()
        {
            InitializeComponent();

            Load += (_, _) => ue_iniciar();
            Resize += (_, _) => ue_acomodar_objetos();
            FormClosed += (_, _) => close();

            cb_mas_subrubrica.Click += (_, _) => cb_mas_subrubrica_clicked();
            cb_menos_subrubrica.Click += (_, _) => cb_menos_subrubrica_clicked();
            cb_modif_subrubrica.Click += (_, _) => cb_modif_subrubrica_clicked();
            cb_medicamentos.Click += (_, _) => cb_medicamentos_clicked();

            dw_buscar.KeyDown += Dw_buscar_KeyDown;
        }

        // =====================================================
        // PB: dw_buscar::downkey
        // =====================================================
        private void Dw_buscar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DynamicEventInvoker.Trigger(this, "ue_dw_detalle", dw_1);
                e.Handled = true;
            }
        }

        // =====================================================
        // PB: event ue_optar
        // =====================================================
        public override void ue_optar()
        {
            base.ue_optar();
            ib_cerrar_al_grabar = false;
        }

        // =====================================================
        // PB: event ue_iniciar
        // =====================================================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            il_Nivel = at_op.Orden - 2;
            il_SubRubrica = Convert.ToDecimal(at_op.s_det[2]);

            string[] p = new string[2];
            p[1] = il_SubRubrica.ToString();

            dw_1.uof_retrieve(p);
            if (dw_1.RowCount() > 0)
                dw_1.SelectRow(1, true);

            st_capitulo.Text = string.IsNullOrEmpty(Globales.gs_Capitulo)
                ? "sin capitulo seleccionado"
                : Globales.gs_Capitulo;

            st_rubrica.Text = string.IsNullOrEmpty(Globales.gs_Rubrica)
                ? "sin rubrica seleccionada"
                : Globales.gs_Rubrica;

            is_Subrubrica = Globales.gs_Subrubrica ?? Array.Empty<string>();

            SetSubrubricaTexts();

            dw_1.SetFocus();
            if (dw_1.RowCount() > 1)
                dw_1.SetRow(1);

            dw_buscar.SetFocus();
        }

        private void SetSubrubricaTexts()
        {
            Label[] labels =
            {
                st_subrubrica1, st_subrubrica2, st_subrubrica3, st_subrubrica4,
                st_subrubrica5, st_subrubrica6, st_subrubrica7, st_subrubrica8
            };

            for (int i = 0; i < labels.Length; i++)
            {
                if (i + 1 < is_Subrubrica.Length)
                {
                    labels[i].Text = is_Subrubrica[i + 1];
                    labels[i].Visible = true;
                }
                else
                {
                    labels[i].Visible = false;
                }
            }
        }

        // =====================================================
        // PB: event ue_dw_detalle
        // =====================================================
        public override void ue_dw_detalle(object? sender = null)
        {
            long fila = dw_1.GetRow();
            if (fila < 1) return;

            string subrubrica = dw_1.GetItemString(fila, "subrubricas_nombre");

            if (Globales.gs_Subrubrica != null && il_Nivel < Globales.gs_Subrubrica.Length)
                Globales.gs_Subrubrica[il_Nivel] = subrubrica;

            is_Accion = "M";
            TriggerEvent("ue_abrir_siguiente");
        }

        // =====================================================
        // PB: event ue_cerrar_transaccion
        // =====================================================
        public override void ue_cerrar_transaccion()
        {
            if (ib_Grabar)
            {
                SQLCA.Commit();
                if (SQLCA.SqlCode != 0)
                {
                    ib_grabar = false;
                    guo_app.at_error_db.SqlDbCode = SQLCA.SqlDbCode;
                    guo_app.at_error_db.SqlErrText = SQLCA.SqlErrText;
                }
            }

            if (!ib_grabar)
            {
                SQLCA.Rollback();
                f_error_base_de_datos.ferror_base_de_datos();
            }

            SQLCA.AutoCommit = ib_AutoCommit;
        }

        // =====================================================
        // PB: event close
        // =====================================================
        public override void close()
        {
            base.close();

            if (Globales.gs_Subrubrica == null) return;

            string[] nuevo = new string[Globales.gs_Subrubrica.Length];
            for (int i = 1; i < Globales.gs_Subrubrica.Length; i++)
                nuevo[i] = Globales.gs_Subrubrica[i];

            Globales.gs_Subrubrica = nuevo;
        }

        // =====================================================
        // BOTONES
        // =====================================================

        private void cb_menos_subrubrica_clicked()
        {
            long fila = dw_1.GetRow();
            if (fila < 1) return;

            string nombre = dw_1.GetItemString(fila, "subrubricas_nombre");
            long id = (long)dw_1.GetItemNumber(fila, "subrubrica_hija");

            if (MessageBox.Show(
                    $"Esta seguro que desea eliminar la subrubrica: {nombre}",
                    "Borrar",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) != DialogResult.OK)
                return;

            dw_1.DeleteRow(fila);
            dw_1.AcceptText();
            dw_1.Update();

            using var cmd = new OdbcCommand(
                "DELETE FROM subrubricas WHERE subrubrica = ?",
                SQLCA.Connection);

            SQLCA.AddParam(cmd, id);
            SQLCA.ExecuteNonQuery(cmd);

            RefreshDW();
        }

        private void cb_mas_subrubrica_clicked()
        {
            stp_w_seleccion p = new()
            {
                titulo = "Ingrese la subrubrica:",
                objeto = "uo_dw_filtros",
                dataobject = "d_agregar_subrubricas",
                cant_filas = 1,
                mensaje = "No existen subrubricas para agregar"
            };

            PBWindow.OpenWithParm(typeof(w_carga_nombres), p);

            var r = (str_w_seleccion)utils.Message.PowerObjectParm;
            if (r.opcion != 1) return;

            using var ds = new uo_ds();
            ds.uof_setdataobject("dsto_actualiza_subrubricas");
            ds.SetTransObject(SQLCA.Instance);

            long f = ds.InsertRow(0);
            ds.SetItem(f, "nombre", r.s_det[1].Trim());
            ds.AcceptText();
            ds.Update();

            long sub = (long)ds.GetItemNumber(f, "subrubrica");

            long lugar = dw_1.GetRow();
            long nf = lugar < 0 ? dw_1.InsertRow(0) : dw_1.InsertRow(lugar);

            dw_1.SetItem(nf, "subrubrica_padre", il_SubRubrica);
            dw_1.SetItem(nf, "subrubrica_hija", sub);

            dw_1.AcceptText();
            dw_1.Update();

            RefreshDW();
        }

        private void cb_modif_subrubrica_clicked()
        {
            long fila = dw_1.GetRow();
            if (fila < 1)
            {
                MessageBox.Show(
                    "Tiene que tener una subrubrica seleccionada para poder modificarla.",
                    "Modificar Subrubricas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string actual = dw_1.GetItemString(fila, "subrubricas_nombre");
            long id = (long)dw_1.GetItemNumber(fila, "subrubrica_hija");

            stp_w_seleccion p = new()
            {
                titulo = "Ingrese la subrubrica:",
                objeto = "uo_dw_filtros",
                dataobject = "d_agregar_subrubricas",
                cant_filas = 1,
                parametros = new[] { "", actual },
                mensaje = "No existen subrubricas para agregar"
            };

             PBWindow.OpenWithParm(typeof(w_carga_nombres), p);

            var r = (str_w_seleccion)utils.Message.PowerObjectParm;
            if (r.opcion != 1) return;

            using var cmd = new OdbcCommand(
                "UPDATE subrubricas SET nombre = ? WHERE subrubrica = ?",
                SQLCA.Connection);

            SQLCA.AddParam(cmd, r.s_det[1].Trim());
            SQLCA.AddParam(cmd, id);
            SQLCA.ExecuteNonQuery(cmd);

            RefreshDW();
        }

        private void cb_medicamentos_clicked()
        {
            long fila = dw_1.GetRow();
            if (fila < 1)
            {
                MessageBox.Show(
                    "No existen subrubricas a las que se les pueda asignar el medicamento",
                    "Selección de medicamentos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string[] p = new string[4];
            p[1] = "SUBRUBRICACION";
            p[2] = dw_1.GetItemNumber(fila, "subrubrica_padre").ToString();
            p[3] = dw_1.GetItemNumber(fila, "subrubrica_hija").ToString();

            stp_w_seleccion sel = new()
            {
                titulo = "Seleccione el medicamento para la subrubrica:",
                objeto = "uo_dw",
                dataobject = "dk_medicamentos_de_la_subrubrica_ph",
                cant_filas = 10,
                parametros = p,
                mensaje = "No existen medicamentos"
            };

            PBWindow.OpenWithParm(typeof(w_carga_medicamentos), sel);

            var r = (str_w_seleccion)utils.Message.PowerObjectParm;
            MessageBox.Show(
                r.Opcion == 1
                    ? "Los medicamentos se guardaron correctamente."
                    : "Las modificaciones no se guardaron.",
                "Medicamentos");
        }

        private void RefreshDW()
        {
            string[] p = new string[2];
            p[1] = il_SubRubrica.ToString();
            dw_1.uof_retrieve(p);
            if (dw_1.RowCount() > 0)
            {
                dw_1.SetRow(1);
                dw_1.SelectRow(1, true);
            }
        }
    }
}
