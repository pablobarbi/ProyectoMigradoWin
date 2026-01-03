using Minotti.Data;
using Minotti.Functions;
using Minotti.Repositories;
using Minotti.Views.Abm.Controls;
using Minotti.Views.Basicos.Models;
using MinottiApp.utils;
using System;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{
    // PB: global type w_abm_lista_subrubricas from w_abm_lista_seleccion
    public partial class w_abm_lista_subrubricas : w_abm_lista_seleccion
    {
        // PB: Decimal il_Rubrica
        private decimal il_Rubrica;

        // PB flag: ib_grabar (NO confundir con Button ib_Grabar)
        public bool ib_grabar { get; set; } = false;

        public w_abm_lista_subrubricas()
        {
            InitializeComponent();

            this.Load += (_, _) => ue_iniciar();
            this.FormClosed += (_, _) => close();

            cb_mas_subrubrica.Click += (_, _) => cb_mas_subrubrica_clicked();
            cb_menos_subrubrica.Click += (_, _) => cb_menos_subrubrica_clicked();
            cb_modif_subrubrica.Click += (_, _) => cb_modif_subrubrica_clicked();
            cb_medicamentos.Click += (_, _) => cb_medicamentos_clicked();

            dw_buscar.KeyDown += (_, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BeginInvoke(new Action(() => ue_dw_detalle(dw_1)));
                    e.Handled = true;
                }
            };

            this.Resize += (_, _) => ue_acomodar_objetos();
        }

        // ======================================================
        // PB events migrados
        // ======================================================

        public override void ue_acomodar_objetos()
        {
            int largo_dw1, ancho_dw1;

            largo_dw1 = this.wf_largo_disponible()
                        - 6 * s_esp.borde
                        - cb_mas_subrubrica.Height
                        - dw_buscar.uof_largo()
                        - st_capitulo.Height
                        - st_rubrica.Height;

            ancho_dw1 = this.wf_ancho_disponible() - 2 * s_esp.borde;

            dw_1.Width = Math.Min(dw_1.uof_ancho(), ancho_dw1);
            dw_1.Height = largo_dw1;
            dw_1.Top = cb_mas_subrubrica.Top + cb_mas_subrubrica.Height + s_esp.borde;
            this.wf_centrarobjeto(dw_1);

            st_capitulo.Left = dw_1.Left;
            st_capitulo.Top = s_esp.borde;

            st_rubrica.Left = dw_1.Left;
            st_rubrica.Top = st_capitulo.Top + st_capitulo.Height + s_esp.borde;

            dw_buscar.Height = dw_buscar.uof_largo();
            dw_buscar.Width = dw_1.Width;
            dw_buscar.Left = dw_1.Left;
            dw_buscar.Top = dw_1.Top + dw_1.Height + s_esp.borde;

            cb_mas_subrubrica.Left = dw_1.Left;
            cb_mas_subrubrica.Top = st_rubrica.Top + st_rubrica.Height + s_esp.borde;

            cb_menos_subrubrica.Left = cb_mas_subrubrica.Left + cb_mas_subrubrica.Width + s_esp.borde;
            cb_menos_subrubrica.Top = cb_mas_subrubrica.Top;

            cb_modif_subrubrica.Left = cb_menos_subrubrica.Left + cb_menos_subrubrica.Width + s_esp.borde;
            cb_modif_subrubrica.Top = cb_mas_subrubrica.Top;

            cb_medicamentos.Left = cb_modif_subrubrica.Left + cb_modif_subrubrica.Width + s_esp.borde;
            cb_medicamentos.Top = cb_mas_subrubrica.Top;
        }

        public override void ue_optar()
        {
            base.ue_optar();
            ib_cerrar_al_grabar = false;
        }

        public override void ue_iniciar()
        {
            base.ue_iniciar();

            il_Rubrica = Convert.ToDecimal(at_op.s_det[2]);

            string[] ls_Parametros = new string[2];
            ls_Parametros[1] = il_Rubrica.ToString();

            dw_1.uof_retrieve(ls_Parametros);

            if (dw_1.RowCount() > 0)
                dw_1.SelectRow(1, true);

            st_capitulo.Text = IsNull(gs_Capitulo) || gs_Capitulo == ""
                                 ? "sin capitulo seleccionado"
                                 : gs_Capitulo;

            st_rubrica.Text = IsNull(gs_Rubrica) || gs_Rubrica == ""
                                 ? "sin rubrica seleccionada"
                                 : gs_Rubrica;

            dw_1.SetFocus();
            if (dw_1.RowCount() > 1)
                dw_1.SetRow(1);

            dw_buscar.SetFocus();
        }

        public override void ue_dw_detalle(object? sender = null)
        {
            long ll_Fila = dw_1.GetRow();
            string ls_SubRubrica = dw_1.GetItemString(ll_Fila, "subrubricas_nombre");

            gs_SubRubrica ??= Array.Empty<string>();
            if (gs_SubRubrica.Length < 2)
                Array.Resize(ref gs_SubRubrica, 2);

            gs_SubRubrica[1] = ls_SubRubrica;

            this.is_Accion = "M";
            this.TriggerEvent("ue_abrir_siguiente");
        }

        // ======================================================
        // FIX QUIRÚRGICO: use boolean flag ib_grabar instead of button ib_Grabar
        // ======================================================
        public override void ue_cerrar_transaccion()
        {
            if (this.ib_grabar)   // <-- CORRECTO
            {
                SQLCA.Commit();
                if (SQLCA.SqlCode != 0)
                {
                    this.ib_grabar = false;
                    guo_app.at_error_db.SqlDbCode = SQLCA.SqlCode;
                    guo_app.at_error_db.SqlErrText = SQLCA.SqlErrText;
                }
            }

            if (!ib_grabar)
            {
                SQLCA.Rollback();
                f_error_base_de_datos.ferror_base_de_datos();
            }

            SQLCA.AutoCommit = this.ib_AutoCommit;
        }

        // ======================================================
        // Botones
        // ======================================================

        private void cb_menos_subrubrica_clicked()
        {
            long ll_Fila = dw_1.GetRow();
            if (ll_Fila <= 0) return;

            string ls_SubRubrica = dw_1.GetItemString(ll_Fila, "subrubricas_nombre");
            long ll_SubRubrica = (long)dw_1.GetItemNumber(ll_Fila, "rubricaciones_subrubrica");

            var rtn = MessageBox.Show(
                "Esta seguro que desea eliminar la subrubrica: " + ls_SubRubrica,
                "Borrar",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (rtn == DialogResult.OK)
            {
                dw_1.DeleteRow(ll_Fila);
                dw_1.AcceptText();
                dw_1.Update();
                SubrubricasData.DeleteSubrubrica(ll_SubRubrica);
            }

            string[] p = new string[2];
            p[1] = il_Rubrica.ToString();
            dw_1.uof_retrieve(p);
            dw_1.SetFocus();
            if (dw_1.RowCount() > 0) dw_1.SetRow(1);
        }

        private void cb_modif_subrubrica_clicked()
        {
            long ll_Fila = dw_1.GetRow();
            if (ll_Fila < 1)
            {
                MessageBox.Show(
                    "Tiene que tener una subrubrica seleccionada para poder modificarla.",
                    "Modificar Subrubricas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string[] ls_Parametros = new string[2];
            ls_Parametros[1] = dw_1.GetItemString(ll_Fila, "subrubricas_nombre");
            long ll_Subrubrica = (long)dw_1.GetItemNumber(ll_Fila, "rubricaciones_subrubrica");

            stp_w_seleccion astp_w_seleccion = new stp_w_seleccion
            {
                titulo = "Ingrese la subrubrica:",
                objeto = "uo_dw_filtros",
                dataobject = "d_agregar_subrubricas",
                cant_filas = 1,
                parametros = ls_Parametros,
                mensaje = "No existen subrubricas para agregar"
            };

            PBWindow.OpenWithParm(typeof(w_carga_nombres), astp_w_seleccion);

            str_w_seleccion astr_w_seleccion = (str_w_seleccion)utils.Message.PowerObjectParm;

            if (astr_w_seleccion.opcion == 1)
            {
                string ls_Nombre = Trim(astr_w_seleccion.s_det[1]);
                SubrubricasData.UpdateNombreSubrubrica(ll_Subrubrica, ls_Nombre);
            }

            string[] p = new string[2];
            p[1] = il_Rubrica.ToString();
            dw_1.uof_retrieve(p);
            dw_1.SetFocus();
            if (dw_1.RowCount() > 0)
            {
                dw_1.SetRow((int)ll_Fila);
                dw_1.SelectRow(ll_Fila, true);
            }
        }

        private void cb_mas_subrubrica_clicked()
        {
            str_w_seleccion astr_w_seleccion;
            stp_w_seleccion astp_w_seleccion;

            long ll_Fila;
            long ll_Lugar;
            string[] ls_Parametros = Array.Empty<string>();
            bool lb_Agregado = false;

            astp_w_seleccion = new stp_w_seleccion
            {
                titulo = "Ingrese la subrubrica:",
                objeto = "uo_dw_filtros",
                dataobject = "d_agregar_subrubricas",
                cant_filas = 1,
                parametros = ls_Parametros,
                mensaje = "No existen subrubricas para agregar"
            };

            PBWindow.OpenWithParm(typeof(w_carga_nombres), astp_w_seleccion);

            astr_w_seleccion = (str_w_seleccion)utils.Message.PowerObjectParm;

            if (astr_w_seleccion.opcion == 1)
            {
                uo_ds ds_subrubricas = new uo_ds();
                ds_subrubricas.uof_setdataobject("dsto_actualiza_subrubricas");
                ds_subrubricas.SetTransObject(SQLCA.Instance);

                ll_Fila = ds_subrubricas.InsertRow(0);
                ds_subrubricas.SetItem(ll_Fila, "nombre", Trim(astr_w_seleccion.s_det[1]));
                ds_subrubricas.AcceptText();
                ds_subrubricas.Update();

                long ll_Subrubrica = (long)ds_subrubricas.GetItemNumber(ll_Fila, "subrubrica");

                ll_Lugar = dw_1.GetRow();
                ll_Fila = (ll_Lugar < 0)
                            ? dw_1.InsertRow(0)
                            : dw_1.InsertRow(ll_Lugar);

                dw_1.SetItem(ll_Fila, "rubricaciones_rubrica", (long)il_Rubrica);
                dw_1.SetItem(ll_Fila, "rubricaciones_subrubrica", ll_Subrubrica);

                dw_1.AcceptText();
                dw_1.Update();
                lb_Agregado = true;

                ds_subrubricas.Destroy();
            }

            string[] p = new string[2];
            p[1] = il_Rubrica.ToString();
            dw_1.uof_retrieve(p);

            if (dw_1.RowCount() > 0)
            {
                ll_Lugar = lb_Agregado ? dw_1.GetRow() : 1;
                if (ll_Lugar <= 0) ll_Lugar = 1;

                dw_1.SetFocus();
                dw_1.SetRow((int)ll_Lugar);
                dw_1.SelectRow(ll_Lugar, true);
                dw_1.ScrollToRow(ll_Lugar);
            }
        }

        private void cb_medicamentos_clicked()
        {
            long ll_Fila = dw_1.GetRow();
            if (ll_Fila <= 0)
            {
                MessageBox.Show(
                    "No existen subrubricas a las que se les pueda asignar el medicamento",
                    "Selección de medicamentos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string[] ls_Parametros = new string[4];
            ls_Parametros[1] = "RUBRICACION";
            ls_Parametros[2] = dw_1.GetItemNumber(ll_Fila, "rubricaciones_rubrica").ToString();
            ls_Parametros[3] = dw_1.GetItemNumber(ll_Fila, "rubricaciones_subrubrica").ToString();

            stp_w_seleccion astp_w_seleccion = new stp_w_seleccion
            {
                titulo = "Seleccione el medicamento para la subrubrica:",
                objeto = "uo_dw",
                dataobject = "dk_medicamentos_de_la_subrubrica",
                cant_filas = 10,
                parametros = ls_Parametros,
                mensaje = "No existen medicamentos"
            };

            PBWindow.OpenWithParm(typeof(w_carga_medicamentos), astp_w_seleccion);

            str_w_seleccion astr_w_seleccion = (str_w_seleccion)utils.Message.PowerObjectParm;

            if (astr_w_seleccion.Opcion == 1)
                MessageBox.Show("Los medicamentos se guardaron correctamente.", "Medicamentos");
            else
                MessageBox.Show("Las modificaciones no se guardaron.", "Medicamentos");
        }

        // Helpers PB-like
        private static bool IsNull(object? o) => o is null || o == DBNull.Value;
        private static string Trim(string? s) => (s ?? string.Empty).Trim();

        // PB globals
        public static string? gs_Capitulo;
        public static string? gs_Rubrica;
        public static string[]? gs_SubRubrica;
    }
}
