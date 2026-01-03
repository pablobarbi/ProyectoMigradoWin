
using Minotti.Data;
using Minotti.Repositories;
using Minotti.Views.Abm.Controls;
using Minotti.Views.Basicos.Models;
using MinottiApp.utils;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{
    public partial class w_abm_lista_capitulos : w_abm_lista_seleccion
    {
        public w_abm_lista_capitulos()
        {
            InitializeComponent();

            cb_mas_capitulos.Click += cb_mas_capitulos_Click;
            cb_menos_capitulos.Click += cb_menos_capitulos_Click;
            cb_modif_capitulos.Click += cb_modif_capitulos_Click;
        }

        // =========================
        // PB: ue_acomodar_objetos
        // =========================
        public override void ue_acomodar_objetos()
        {
            int largo_dw1 = wf_largo_disponible()
                            - 5 * s_esp.borde
                            - dw_buscar.uof_largo()
                            - cb_mas_capitulos.Height;

            int ancho_dw1 = wf_ancho_disponible() - 2 * s_esp.borde;

            // dw_1
            dw_1.Width = Math.Min(dw_1.uof_ancho(), ancho_dw1);
            dw_1.Height = largo_dw1;
            dw_1.Top = 2 * s_esp.borde + cb_mas_capitulos.Height;
            wf_centrarobjeto(dw_1);

            // dw_buscar
            dw_buscar.Height = dw_buscar.uof_largo();
            dw_buscar.Width = dw_1.Width;
            dw_buscar.Left = dw_1.Left;
            dw_buscar.Top = dw_1.Top + dw_1.Height + s_esp.borde;

            // botones
            cb_mas_capitulos.Left = dw_1.Left;
            cb_mas_capitulos.Top = s_esp.borde;

            cb_menos_capitulos.Left = cb_mas_capitulos.Left + cb_mas_capitulos.Width + s_esp.borde;
            cb_menos_capitulos.Top = s_esp.borde;

            cb_modif_capitulos.Left = cb_menos_capitulos.Left + cb_menos_capitulos.Width + s_esp.borde;
            cb_modif_capitulos.Top = s_esp.borde;
        }

        // =========================
        // PB: ue_optar
        // =========================
        public override void ue_optar()
        {
            base.ue_optar();
            ib_cerrar_al_grabar = false;
        }

        // =========================
        // PB: ue_dw_detalle
        // =========================
        public void ue_dw_detalle(object? sender = null)
        {
            long fila = dw_1.GetRow();
            string capitulo = dw_1.GetItemString(fila, "nombre");

            Globales.gs_Capitulo = capitulo;

            is_Accion = "M";
            TriggerEvent("ue_abrir_siguiente");
        }

        // =========================
        // PB: close
        // =========================
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Globales.gs_Capitulo = null;
        }

        // =========================
        // PB: ue_iniciar
        // =========================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            dw_1.SetFocus();
            if (dw_1.RowCount() > 1)
                dw_1.SetRow(1);

            dw_buscar.SetFocus();
        }

        // =========================================================
        // BOTÓN: AGREGAR CAPITULOS
        // =========================================================
        private void cb_mas_capitulos_Click(object? sender, EventArgs e)
        {
            str_w_seleccion astr;
            stp_w_seleccion astp = new();

            astp.titulo = "Ingrese el capitulo:";
            astp.objeto = "uo_dw_filtros";
            astp.dataobject = "d_agregar_capitulos";
            astp.cant_filas = 1;
            astp.parametros = Array.Empty<string>();
            astp.mensaje = "No existen capitulos para agregar";

            PBWindow.OpenWithParm(typeof(w_carga_nombres), astp);

            astr = (str_w_seleccion)utils.Message.PowerObjectParm;
            if (astr.opcion != 1) return;

            string nombre = astr.s_det[0].Trim();

            long fila = dw_1.InsertRow(0);
            dw_1.SetItem(fila, "nombre", nombre);
            dw_1.SetRow((int)fila);

            // DataStore
            uo_ds ds = new();
            ds.uof_setdataobject("dk_capitulos");
            ds.SetTransObject(SQLCA.Instance);

            long f = ds.InsertRow(0);
            ds.SetItem(f, "nombre", nombre);
            ds.AcceptText();
            ds.Update();

            dw_1.Retrieve();
        }

        // =========================================================
        // BOTÓN: BORRAR CAPITULOS
        // =========================================================
        private void cb_menos_capitulos_Click(object? sender, EventArgs e)
        {
            long fila = dw_1.GetRow();
            if (fila < 1) return;

            string nombre = dw_1.GetItemString(fila, "nombre");
            var r = MessageBox.Show(
                $"Esta seguro que desea eliminar el capitulo: {nombre}",
                "Borrar",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (r != DialogResult.OK) return;

            dw_1.DeleteRow(fila);
            dw_1.AcceptText();
            dw_1.Update();

            dw_1.Retrieve();
        }

        // =========================================================
        // BOTÓN: MODIFICAR CAPITULOS
        // =========================================================
        private void cb_modif_capitulos_Click(object? sender, EventArgs e)
        {
            long fila = dw_1.GetRow();
            if (fila < 1)
            {
                MessageBox.Show(
                    "Tiene que tener un capítulo seleccionado para poder modificarlo.",
                    "Modificar Capítulos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            str_w_seleccion astr;
            stp_w_seleccion astp = new();

            astp.titulo = "Ingrese el capitulo:";
            astp.objeto = "uo_dw_filtros";
            astp.dataobject = "d_agregar_capitulos";
            astp.cant_filas = 1;
            astp.parametros = new[] { dw_1.GetItemString(fila, "nombre") };
            astp.mensaje = "No existen capitulos para agregar";

            PBWindow.OpenWithParm(typeof(w_carga_nombres), astp);

            astr = (str_w_seleccion)utils.Message.PowerObjectParm;
            if (astr.opcion != 1) return;

            string nombre = astr.s_det[0].Trim();
            dw_1.SetItem(fila, "nombre", nombre);
            dw_1.AcceptText();
            dw_1.Update();

            dw_1.Retrieve();
            dw_1.SetRow((int)fila);
            dw_1.SelectRow(fila, true);
        }
    }
}
