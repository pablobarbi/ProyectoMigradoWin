using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Pbl.Views;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Minotti.Views.Reportes.Controls
{
    // global type w_reporte from w_operacion
    public partial class w_reporte : w_operacion
    {
        public w_reporte()
        {
            InitializeComponent();
        }

        // =========================
        // event activate
        // =========================
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (IsValid(dw_param))
            {
                PBGlobals.m_mdi.m_procesar.Enabled = true;
                PBGlobals.m_mdi.m_imprimir.Enabled = true;
                PBGlobals.m_mdi.m_preliminar.Enabled = true;
                PBGlobals.m_mdi.m_salvarcomo.Enabled = true;
            }
        }

        // =========================
        // event deactivate
        // =========================
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            PBGlobals.m_mdi.m_procesar.Enabled = false;
            PBGlobals.m_mdi.m_imprimir.Enabled = false;
            PBGlobals.m_mdi.m_preliminar.Enabled = false;
            PBGlobals.m_mdi.m_salvarcomo.Enabled = false;
        }

        // =========================
        // event ue_ajustar_tamaño
        // =========================
        public override void ue_ajustar_tamaño()
        {
            base.ue_ajustar_tamaño();

            if (IsValid(dw_param))
            {
                dw_param.Top = s_esp.borde;
                dw_param.Height = dw_param.uof_largo();

                this.Width =
                    Math.Max(dw_param.uof_ancho(), dw_reporte.uof_ancho())
                    + s_esp.ancho + 2 * s_esp.borde;

                this.Height =
                    dw_param.Height + dw_reporte.uof_largo()
                    + s_esp.largo + 3 * s_esp.borde;
            }
            else
            {
                this.Width = dw_reporte.uof_ancho() + s_esp.ancho + 2 * s_esp.borde;
                this.Height = dw_reporte.uof_largo() + s_esp.largo + 2 * s_esp.borde;
            }
        }

        // =========================
        // event ue_acomodar_objetos
        // =========================
        public override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            int ancho_para_dw =
                this.Width - s_esp.ancho - 2 * s_esp.borde;
            int largo_para_dw =
                this.Height - s_esp.largo - 2 * s_esp.borde;

            this.SetRedraw(false);

            if (IsValid(dw_param))
            {
                dw_param.Width = Math.Min(dw_param.uof_ancho(), ancho_para_dw);
                this.wf_centrarobjeto(dw_param);

                dw_reporte.Top =
                    dw_param.Top + dw_param.Height + s_esp.borde;
                dw_reporte.Height =
                    largo_para_dw - s_esp.borde - dw_param.Height;
            }
            else
            {
                dw_reporte.Top = s_esp.borde;
                dw_reporte.Height = largo_para_dw;
            }

            dw_reporte.Width =
                Math.Min(dw_reporte.uof_ancho(), ancho_para_dw);
            this.wf_centrarobjeto(dw_reporte);

            this.SetRedraw(true);
        }

        // =========================
        // event ue_dw_detalle
        // =========================
        public override void ue_dw_detalle(object arg_objeto)
        {
            base.ue_dw_detalle(arg_objeto);

            if (arg_objeto == dw_reporte)
                this.TriggerEvent("ue_abrir_siguiente");
        }

        // =========================
        // event ue_imprimir
        // =========================
        public override void ue_imprimir()
        {
            base.ue_imprimir();
            dw_reporte.uof_imprimir();
        }

        // =========================
        // event ue_iniciar
        // =========================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            this.SetPointer( Structures.Pointer.HourGlass);

            if (IsValid(dw_param))
            {
                dw_param.uof_edicion(0, "S");
                dw_param.InsertRow(0);
                dw_param.SetFocus();
            }
            else
            {
                dw_reporte.uof_retrieve();

                if (dw_reporte.RowCount() < 1)
                {
                    MessageBox.Show(
                        "No Existen Registros",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ib_pasar_por_closequery = false;
                    this.Close();
                }
            }
        }

        // =========================
        // event ue_leer_parametros
        // =========================
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            string param = at_op.uof_getparametros();

            if (wf_cantparam(param) > 4)
            {
                OpenUserObject(dw_param, wf_proxparam(param));
                dw_param.uof_setdataobject(wf_proxparam(param));
                dw_param.SetTransObject(SQLCA.Instance);
            }

            OpenUserObject(dw_reporte, wf_proxparam(param));
            dw_reporte.uof_setdataobject(wf_proxparam(param));
            dw_reporte.SetTransObject(SQLCA.Instance);
            dw_reporte.uof_setdwimpresion(wf_proxparam(param));

            dw_reporte.Border = true;
            dw_reporte.BorderStyle = BorderStyle.Fixed3D;

            if (at_op.at_nvl.Count > at_op.Orden)
                dw_reporte.uof_marcar_seleccion(1);
        }

        // =========================
        // event ue_optar
        // =========================
        public override void ue_optar()
        {
            base.ue_optar();

            if (IsValid(dw_param))
            {
                if (dw_param.cant_filas == null || dw_param.cant_filas == 0)
                    dw_param.cant_filas = 1;
            }

            if (dw_reporte.cant_filas == null || dw_reporte.cant_filas == 0)
                dw_reporte.cant_filas = 10;
        }

        // =========================
        // event ue_preview
        // =========================
        public override void ue_preview()
        {
            base.ue_preview();
            dw_reporte.TriggerEvent("ue_preview");
        }

        // =========================
        // event ue_procesar
        // =========================
        public override void ue_procesar()
        {
            base.ue_procesar();

            string[] parametros = Array.Empty<string>();

            this.SetPointer( Structures.Pointer.HourGlass);

            if (IsValid(dw_param))
            {
                if (dw_param.AcceptText() != 1)
                {
                    dw_param.SetFocus();
                    return;
                }

                dw_param.uof_getargumentos(parametros, dw_param.GetRow());
            }

            dw_reporte.uof_retrieve(parametros);

            if (dw_reporte.RowCount() < 1)
            {
                MessageBox.Show("No hay registros", "Atención");
                if (IsValid(dw_param)) dw_param.SetFocus();
            }
            else
            {
                dw_reporte.SetFocus();
            }
        }

        // =========================
        // event ue_salvar
        // =========================
        public override void ue_salvar()
        {
            base.ue_salvar();

            if (dw_reporte.RowCount() > 0)
                dw_reporte.SaveAs("", SaveAsFormat.Excel, true);
            else
                MessageBox.Show("No hay filas para salvar", "¡Atención!");
        }

        // =========================
        // event close
        // =========================
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (IsValid(dw_param)) CloseUserObject(dw_param);
            if (IsValid(dw_reporte)) CloseUserObject(dw_reporte);
        }

        public virtual void ue_preprocesar()
        {
            // PB default: no hace nada
        }

        // =========================
        // helpers
        // =========================
        protected bool IsValid(object? o) => o != null;
    }
}