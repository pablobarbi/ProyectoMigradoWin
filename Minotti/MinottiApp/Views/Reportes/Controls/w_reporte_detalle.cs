using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Pbl.Views;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Reportes.Controls
{
    // global type w_reporte_detalle from w_operacion
    public partial class w_reporte_detalle : w_operacion
    {
        public w_reporte_detalle()
        {
            InitializeComponent();

            // Mapeo de eventos PB ? WinForms / métodos overridables
            this.Activated += (_, __) => w_reporte_detalle_activate();
            this.Deactivate += (_, __) => w_reporte_detalle_deactivate();
            this.FormClosed += (_, __) => w_reporte_detalle_close();
        }

        // =========================
        // PB: event ue_optar
        // =========================
        public override void ue_optar()
        {
            base.ue_optar();

            if (dw_1.cant_filas == null || dw_1.cant_filas == 0)
                dw_1.cant_filas = 1;
        }

        // =========================
        // PB: event activate
        // =========================
        private void w_reporte_detalle_activate()
        {
            // call super::activate;
            // Menú: habilita imprimir/preview/salvar
            PBGlobals.m_mdi.m_imprimir.Enabled = true;
            PBGlobals.m_mdi.m_preliminar.Enabled = true;
            PBGlobals.m_mdi.m_salvarcomo.Enabled = true;
        }

        // =========================
        // PB: event deactivate
        // =========================
        private void w_reporte_detalle_deactivate()
        {
            PBGlobals.m_mdi.m_imprimir.Enabled = false;
            PBGlobals.m_mdi.m_preliminar.Enabled = false;
            PBGlobals.m_mdi.m_salvarcomo.Enabled = false;
        }

        // =========================
        // PB: event close
        // =========================
        private void w_reporte_detalle_close()
        {
            if (IsValid(dw_1))
                CloseUserObject(dw_1);
        }

        // =========================
        // PB: event ue_ajustar_tamaño
        // =========================
        public override void ue_ajustar_tamaño()
        {
            base.ue_ajustar_tamaño();

            // This.Width = dw_1.uof_ancho() + s_esp.ancho + 2 * s_esp.borde
            // This.Height = dw_1.uof_largo() + s_esp.largo + 2 * s_esp.borde
            this.Width = dw_1.uof_ancho() + s_esp.ancho + 2 * s_esp.borde;
            this.Height = dw_1.uof_largo() + s_esp.largo + 2 * s_esp.borde;
        }

        // =========================
        // PB: event ue_acomodar_objetos
        // =========================
        public override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            // dw_1.Width = Min(dw_1.uof_ancho(), This.wf_ancho_disponible())
            dw_1.Width = Math.Min(dw_1.uof_ancho(), this.wf_ancho_disponible());

            // This.wf_centrarobjeto(dw_1)
            this.wf_centrarobjeto(dw_1);

            // Height según cant_filas
            if (dw_1.cant_filas == 1)
                dw_1.Height = Math.Min(dw_1.uof_largo(), this.wf_largo_disponible());
            else
                dw_1.Height = this.wf_largo_disponible();

            // dw_1.Y = s_esp.borde
            dw_1.Top = s_esp.borde;
        }

        // =========================
        // PB: event ue_iniciar
        // =========================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            // /* Deja los campos del detalle como No Editables */
            // dw_1.uof_edicion(0, 'N')
            dw_1.uof_edicion(0, "N");

            // dw_1.uof_retrieve(at_op.s_det[])
            dw_1.uof_retrieve(at_op.s_det);
        }

        // =========================
        // PB: event ue_preview
        // =========================
        public override void ue_preview()
        {
            base.ue_preview();

            // dw_1.Event Trigger ue_preview()
            dw_1.TriggerEvent("ue_preview");
        }

        // =========================
        // PB: event ue_imprimir
        // =========================
        public override void ue_imprimir()
        {
            base.ue_imprimir();
            dw_1.uof_imprimir();
        }

        // =========================
        // PB: event ue_leer_parametros
        // =========================
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            string param = at_op.uof_getparametros();

            /******************************************************************************
             Parámetros:
               dw_control, dw_detalle, dw_impresion_detalle
             ******************************************************************************/


            // OpenUserObject(dw_1, wf_ProxParam(param))
            OpenUserObject(dw_1, wf_ProxParam(ref param));

            // dw_1.uof_setdataobject(wf_ProxParam(param))
            dw_1.uof_setdataobject(wf_ProxParam(ref param));

            // dw_1.SetTransObject(SQLCA)
            dw_1.SetTransObject(SQLCA.Instance);

            // dw_1.uof_setdwimpresion(wf_ProxParam(param))
            dw_1.uof_setdwimpresion(wf_ProxParam(ref param));

            // dw_1.cant_filas = Integer(wf_ProxParam(param))
            dw_1.cant_filas = ToInt(wf_ProxParam(ref param));

            // dw_1.hsplitScroll = TRUE
            dw_1.hsplitScroll = true;
        }

        // =========================
        // PB: event ue_salvar
        // =========================
        public override void ue_salvar()
        {
            base.ue_salvar();

            if (dw_1.RowCount() > 0)
                dw_1.SaveAs("", SaveAsFormat.Excel, true);
            else
                MessageBox.Show("No hay filas para salvar", "¡Atención!");
        }

        // =========================
        // Helpers mínimos
        // =========================
        private static bool IsValid(object? o) => o != null;

        private static int ToInt(string? s)
        {
            if (int.TryParse((s ?? "").Trim(), out var v)) return v;
            return 0;
        }

        // IMPORTANTE:
        // wf_ProxParam en PB consume el string "param".
        // Yo lo expreso con ref para no inventar comportamiento.
        // Si tu base ya lo tiene con otra firma, adaptalo a tu implementación real.
        private static string wf_ProxParam(ref string param)
        {
            // NO invento el parser acá porque ya lo tenés en w_operacion/base.
            // Si ya existe en tu base: BORRAR este método y usar el real.
            throw new NotImplementedException("Usar wf_ProxParam real de tu base (w_operacion).");
        }
    }

    // Si ya tenés estos enums en tu migración, usá los tuyos.
    public enum SaveAsFormat
    {
        Excel = 0,
        CSV = 1,
        Text = 2
    }
}