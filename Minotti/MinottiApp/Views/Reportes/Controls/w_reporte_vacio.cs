using Minotti.Data;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos.Models;
using System;
 

namespace Minotti.Views.Reportes.Controls
{
    // global type w_reporte_vacio from w_reporte
    public partial class w_reporte_vacio : w_reporte
    {
        // type variables
        protected string? is_drsin;
        protected string? is_dlsin;
        protected string? is_drcon;
        protected string? is_dlcon;

        public w_reporte_vacio() : base()
        {
        }

        // =========================
        // PB: event ue_procesar (ANCESTOR SCRIPT OVERRIDE)
        // =========================
        public override void ue_procesar()
        {
            // NO llamo base.ue_procesar() porque PB overridea sin call super.
            string[] parametros = Array.Empty<string>();
            long rtn = 0;

           PBUtils.SetPointer(Pointer.HourGlass);

            if (IsValid(dw_param))
            {
                if (dw_param.AcceptText() != 1)
                {
                    dw_param.SetFocus();
                    return;
                }

                // dw_param.uof_getargumentos(parametros[], dw_param.GetRow())
                dw_param.uof_getargumentos(parametros, dw_param.GetRow());
            }

            // rtn = dw_reporte.uof_retrieve(parametros[])
            rtn = dw_reporte.uof_retrieve(parametros);

            // Si dio error no sigue procesando
            if (rtn < 0)
            {
                ib_grabar = false;
            }
            else
            {
                dw_reporte.SetFocus();
            }

            // Si da vacio, busco si tiene la dw de reporte vacio y la proceso
            if (rtn == 0)
            {
                if (is_drsin == null || is_dlsin == null)
                {
                    // EL REPORTE NO SOPORTA EL CASO DE DW - SIN REGISTROS, MENSAJE DEFAULT
                    // (PB no hace nada más acá)
                }
                else
                {
                    // EXISTEN LAS DW DE REPORTE VACIO
                    dw_reporte.uof_setdataobject(is_drsin);
                    dw_reporte.SetTransObject(SQLCA.Instance);
                    dw_reporte.uof_setdwimpresion(is_dlsin);

                    rtn = dw_reporte.uof_retrieve(parametros);

                    if (rtn < 0)
                    {
                        ib_grabar = false;
                    }
                    else
                    {
                        dw_reporte.SetFocus();
                    }
                }
            }
        }

        // =========================
        // PB: event ue_leer_parametros (ANCESTOR SCRIPT OVERRIDE)
        // =========================
        public override void ue_leer_parametros()
        {
            // NO llamo base.ue_leer_parametros() porque PB overridea y copia script para título.
            // --- Copiado de w_operacion para título ---
            at_op = (cat_operacion)utils.Message.PowerObjectParm;

            // Captura el título de la ventana
            this.Text = at_op.Nombre;

            int iAux = LenSafe(at_op.uof_gettitulo());
            if (iAux > 0)
                this.Text = this.Text + " - " + at_op.uof_gettitulo();

            // --- Override real ---
            string ls_Param, ls_Numerico;

            at_op = (cat_operacion)utils.Message.PowerObjectParm;
            ls_Param = at_op.uof_getparametros();

            // Si tiene parámetros, carga la datawindow correspondiente
            if (wf_cantparam(ls_Param) > 6)
            {
                OpenUserObject(dw_param, wf_proxparam(ls_Param));
                dw_param.uof_setdataobject(wf_proxparam(ls_Param));
                dw_param.SetTransObject(SQLCA.Instance);
            }

            // Carga la DataWindow de datos
            OpenUserObject(dw_reporte, wf_proxparam(ls_Param));

            // Asignar a vble de instancia el dataobject de la dw que aparece por pantalla caso positivo
            is_drcon = wf_proxparam(ls_Param);
            dw_reporte.uof_setdataobject(is_drcon);
            dw_reporte.SetTransObject(SQLCA.Instance);

            // Asignar a vble de instancia el dataobject de la dw de impresion caso positivo
            is_dlcon = wf_proxparam(ls_Param);
            dw_reporte.uof_setdwimpresion(is_dlcon);

            dw_reporte.Border = true;
            dw_reporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            // Lee la cantidad de líneas que va a mostrar
            ls_Numerico = wf_proxparam( ls_Param);

            if (PBUtils.IsNumber(ls_Numerico))
            {
                dw_reporte.cant_filas = ToInt(ls_Numerico);

                // luego vienen las DW opcionales sin registros
                is_drsin = wf_proxparam(ls_Param);
                is_dlsin = wf_proxparam(ls_Param);
            }
            else
            {
                // si no es número, ese param era la dw sin registros
                is_drsin = ls_Numerico;
                is_dlsin = wf_proxparam(ls_Param);
            }

            // Si se debe abrir otra ventana de detalles, resalta la fila seleccionada
            if (PBUtils.UpperBound(at_op.at_nvl) > at_op.Orden)
                dw_reporte.uof_marcar_seleccion(1);
        }

        // =========================
        // PB: event ue_preprocesar
        // =========================
        public override void ue_preprocesar()
        {
            base.ue_preprocesar();

            // Asignar las dw del caso positivo: hay datos para recuperar - segunda recuperacion en adelante...
            dw_reporte.uof_setdataobject(is_drcon);
            dw_reporte.SetTransObject(SQLCA.Instance);
            dw_reporte.uof_setdwimpresion(is_dlcon);
        }

        // =========================
        // Helpers mínimos (sin inventar lógica funcional)
        // =========================
        protected static bool IsValid(object? o) => o != null;

        protected static int LenSafe(string? s) => string.IsNullOrEmpty(s) ? 0 : s.Length;

        protected static int ToInt(string? s)
        {
            if (int.TryParse((s ?? "").Trim(), out var v)) return v;
            return 0;
        }

        //protected static bool IsNumber(string? s)
        //{
        //    if (string.IsNullOrWhiteSpace(s)) return false;
        //    return long.TryParse(s.Trim(), out _);
        //}

        //protected static int UpperBound<T>(T[]? arr) => arr == null ? 0 : arr.Length;

        // IMPORTANTE: estos métodos deben existir en tu base (w_operacion/w_reporte).
        // Los declaro como abstract “conceptual” con throw para que NO invente parseo.
        // Si ya existen en el ancestro, BORRAR estas declaraciones.
        //protected virtual int wf_CantParam(string param) => throw new NotImplementedException();
        //protected virtual string wf_ProxParam(ref string param) => throw new NotImplementedException();
        //protected virtual void OpenUserObject(object target, string className) => throw new NotImplementedException();
    }
}