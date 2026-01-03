using Minotti.Data;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Minotti.Views.Reportes.Controls
{
    // global type w_tab_reporte_header from w_tab_reporte
    public partial class w_tab_reporte_header : w_tab_reporte
    {
        // long backcolor = 81324524
        public new long backcolor = 81324524;

        public w_tab_reporte_header()
        {
            InitializeComponent();

            // Mapeo PB close
            this.FormClosed += (_, __) => close();
        }

        // =========================
        // PB: event ue_iniciar
        // =========================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            // // cargo la DW de encabezado.
            // dw_1.uof_retrieve(at_op.s_det[])
            dw_1.uof_retrieve(at_op.s_det);
        }

        // =========================
        // PB: event ue_leer_parametros
        // =========================
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            /*
             Parametros de la Ventana:
             uo_dw, dw_cabecera
             */

            // param = at_op.uof_getparametros()
            string param = at_op.uof_getparametros();

            // OpenUserObject(dw_1, wf_ProxParam(param, 3))
            // OJO: acá PB usa wf_ProxParam(param, 3) para el nombre de clase/control.
            OpenUserObject(dw_1, wf_ProxParam(ref param, 3));

            // dw_1.uof_setdataobject(wf_ProxParam(param))
            dw_1.uof_setdataobject(wf_ProxParam(ref param));

            // dw_1.SetTransObject(SQLCA)
            dw_1.SetTransObject(SQLCA.Instance);

            // dw_1.cant_filas = 1
            dw_1.cant_filas = 1;

            // Los comentados en PB NO los ejecuto:
            // dw_1.uof_setdwimpresion(...)
            // dw_1.Border = TRUE
            // dw_1.BorderStyle = StyleLowered!
        }

        // =========================
        // PB: event ue_acomodar_objetos
        // (ANCESTOR SCRIPT OVERRIDE)
        // =========================
        public override void ue_acomodar_objetos()
        {
            // NO llamo base porque PB overridea total sin super

            int ancho_para_dw, largo_para_tab;

            this.SetRedraw(false);

            // ancho_para_dw = This.Width - s_esp.ancho - 2 * s_esp.borde
            ancho_para_dw = this.Width - s_esp.ancho - 2 * s_esp.borde;

            // dw_1.Width = min(dw_1.uof_ancho(), ancho_para_dw)
            dw_1.Width = Math.Min(dw_1.uof_ancho(), ancho_para_dw);

            // dw_1.Height = dw_1.uof_largo()
            dw_1.Height = dw_1.uof_largo();

            // dw_1.X = s_esp.borde ; dw_1.Y = s_esp.borde
            dw_1.Left = s_esp.borde;
            dw_1.Top = s_esp.borde;

            // largo_para_tab = This.Height - dw_1.Height - s_esp.largo - 2 * s_esp.borde
            largo_para_tab = this.Height - dw_1.Height - s_esp.largo - 2 * s_esp.borde;

            // tab_1.Event Trigger ue_resize(dw_1.Width, largo_para_tab)
            tab_1.TriggerEvent("ue_resize", dw_1.Width, largo_para_tab);

            // Tab_1.X = s_esp.borde
            // Tab_1.Y = dw_1.Y + dw_1.Height + s_esp.borde
            tab_1.Left = s_esp.borde;
            tab_1.Top = dw_1.Top + dw_1.Height + s_esp.borde;

            this.SetRedraw(true);
        }

        // =========================
        // PB: event close
        // =========================
        private void close()
        {
            // PB:
            // IF IsValid(dw_1) THEN DESTROY(dw_1)
            // En .NET: Dispose del control (si existe) y null
            if (IsValid(dw_1))
            {
                dw_1.Dispose();
            }
        }

        // =========================
        // Helpers mínimos
        // =========================
        protected static bool IsValid(object? o) => o != null;

        // IMPORTANTE:
        // Estos métodos deben existir en tu framework (w_tab / w_operacion).
        // No los implemento acá para no inventar.
        protected virtual void OpenUserObject(object target, string className) => throw new NotImplementedException();
        protected virtual string wf_ProxParam(ref string param, int skip) => throw new NotImplementedException();
        protected virtual string wf_ProxParam(ref string param) => throw new NotImplementedException();
    }
}