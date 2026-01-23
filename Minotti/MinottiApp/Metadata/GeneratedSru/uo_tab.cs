// -----------------------------------------------------------------------------
// AUTO-MIGRADO DESDE PowerBuilder (.sru)
// Origen: uo_tab.sru
// Tipo  : tab
// Migración 1:1 EXACTA – NO refactor
// -----------------------------------------------------------------------------

#nullable enable
using Minotti.Data;
using Minotti.Functions;
using Minotti.utils;
using Minotti.Views.Basicos.Models;
using MinottiApp.utils;
using System.Diagnostics.PerformanceData;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Minotti.Metadata.GeneratedSru
{
    // -------------------------------------------------------------------------
    // STRUCTURE: uost_tab_info
    // -------------------------------------------------------------------------
    public struct uost_tab_info
    {
        public string? titulo;
        public string? dw;
        public string? bitmap;
    }

    // -------------------------------------------------------------------------
    // CLASS: uo_tab
    // -------------------------------------------------------------------------
    public class uo_tab : tab
    {
        // ---------------------------------------------------------------------
        // VARIABLES (PB: type variables)
        // ---------------------------------------------------------------------

        public st_espacios s_esp;                 // Medidas a agregar
        public uo_tp[] tp = System.Array.Empty<uo_tp>();
        public string[] is_parametros = System.Array.Empty<string>();

        public int i_borde = 40;
        public int i_Cabecera = 250;

        // boolean continuar_grabando = True
        public bool continuar_grabando = true;

        // ---------------------------------------------------------------------
        // EVENTS
        // ---------------------------------------------------------------------

        public virtual void ue_activate() { }
        public virtual void ue_deactivate() { }
        public virtual void ue_optar() { }
        public virtual void ue_borrar() { }
        public virtual void ue_cancelar() { }
        public virtual void ue_imprimir() { }
        public virtual void ue_insertar() { }
        public virtual void ue_preview() { }
        public virtual void ue_refresh() { }
        public virtual void ue_primero() { }
        public virtual void ue_anterior() { }
        public virtual void ue_siguiente() { }
        public virtual void ue_ultimo() { }
        public virtual void ue_dw_cambio_fila(uo_dw arg_objeto) { }
        public virtual void ue_dw_detalle(uo_dw arg_objeto) { }
        public virtual void ue_posconfirmar() { }
        public virtual void ue_reset() { }
        public virtual void ue_reiniciar() { }

        // ---------------------------------------------------------------------
        // EVENT: ue_leer_parametros
        // ---------------------------------------------------------------------
        public virtual void ue_leer_parametros(ref string[] parametros)
        {
            int pagina;
            st_pagina_carpeta s_pag;

            SetPointer(PointerType.HourGlass);
            this.BoldSelectedText = true;

            datastore ds_carpetas = new datastore();
            ds_carpetas.DataObject = "d_carpetas";
            ds_carpetas.SetTransObject(SQLCA.Instance);
            ds_carpetas.Retrieve(f_proxparam.fproxparam(ref parametros));

            for (pagina = 1; pagina <= ds_carpetas.RowCount(); pagina++)
            {
                OpenTab(tp[pagina], ds_carpetas.GetItemString(pagina, "Objeto"), 0);

                s_pag.Titulo = ds_carpetas.GetItemString(pagina, "Titulo");
                s_pag.Bitmap = ds_carpetas.GetItemString(pagina, "Bitmap");
                s_pag.Parametros = ds_carpetas.GetItemString(pagina, "Parametros");

                tp[pagina].TriggerEvent("ue_leer_parametros", s_pag);
            }

            ds_carpetas.Destroy();
            SetPointer(PointerType.Arrow);
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_acomodar_objetos
        // ---------------------------------------------------------------------
        public virtual void ue_acomodar_objetos()
        {
            int cantidad = tp.Length - 1;

            for (int i = 1; i <= cantidad; i++)
            {
                tp[i].TriggerEvent("ue_acomodar_objetos");
            }
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_iniciar
        // ---------------------------------------------------------------------
        public virtual void ue_iniciar(string arg_accion, string[] arg_param)
        {
            is_parametros = arg_param;

            int cantidad = tp.Length - 1;
            if (cantidad > 0)
            {
                for (int i = 1; i <= cantidad; i++)
                {
                    tp[i].TriggerEvent("ue_iniciar", arg_accion, is_parametros);
                }

                this.SelectTab(1);
            }
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_procesar
        // ---------------------------------------------------------------------
        public virtual void ue_procesar()
        {
            int cantidad = tp.Length - 1;

            for (int i = 1; i <= cantidad; i++)
            {
                tp[i].TriggerEvent("ue_procesar");
            }
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_resize
        // ---------------------------------------------------------------------
        public virtual void ue_resize(int ancho_total, int largo_total)
        {
            this.Width = ancho_total;
            this.Height = largo_total;
            this.TriggerEvent("ue_acomodar_objetos");
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_completar_claves
        // ---------------------------------------------------------------------
        public virtual bool ue_completar_claves(ref string[] sarg_param)
        {
            string[] sAux = is_parametros;
            int cantidad = tp.Length - 1;

            if (cantidad < 1) return false;

            if (!tp[1].TriggerEventBool("ue_completar_claves", ref sAux))
                return false;

            if (!tp[1].TriggerEventBool("ue_leer_claves", ref sAux))
                return false;

            for (int i = 2; i <= cantidad; i++)
            {
                if (!tp[i].TriggerEventBool("ue_completar_claves", ref sAux))
                    return false;
            }

            return true;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_validar_datos
        // ---------------------------------------------------------------------
        public virtual bool ue_validar_datos()
        {
            int cantidad = tp.Length - 1;

            for (int i = 1; i <= cantidad; i++)
            {
                if (!tp[i].TriggerEventBool("ue_validar_datos"))
                {
                    this.SelectTab(i);
                    return false;
                }
            }

            return true;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_preconfirmar
        // ---------------------------------------------------------------------
        public virtual bool ue_preconfirmar()
        {
            int cantidad = tp.Length - 1;

            for (int i = 1; i <= cantidad; i++)
            {
                if (!tp[i].TriggerEventBool("ue_preconfirmar"))
                    return false;
            }

            return true;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_confirmar
        // ---------------------------------------------------------------------
        public virtual bool ue_confirmar(bool barg_accept, bool barg_limpiar)
        {
            int cantidad = tp.Length - 1;

            for (int i = 1; i <= cantidad - 1; i++)
            {
                if (!tp[i].TriggerEventBool("ue_confirmar", barg_accept, false))
                    return false;
            }

            return tp[cantidad].TriggerEventBool("ue_confirmar", barg_accept, barg_limpiar);
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_dw_itemchanged
        // ---------------------------------------------------------------------
        public virtual int ue_dw_itemchanged(uo_dw arg_objeto, long row, dwobject dwo, string data)
        {
            return Parent.TriggerEventInt("ue_dw_itemchanged", arg_objeto, row, dwo, data);
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_aceptar_datos
        // ---------------------------------------------------------------------
        public virtual bool ue_aceptar_datos()
        {
            int cantidad = tp.Length - 1;

            for (int i = 1; i <= cantidad; i++)
            {
                if (!tp[i].TriggerEventBool("ue_aceptar_datos"))
                {
                    this.SelectTab(i);
                    return false;
                }
            }

            return true;
        }

        // ---------------------------------------------------------------------
        // FUNCTION: uof_largo
        // ---------------------------------------------------------------------
        public virtual int uof_largo()
        {
            int max = 0;
            int cantidad = tp.Length - 1;

            for (int i = 1; i <= cantidad; i++)
            {
                max = System.Math.Max(max, tp[i].uof_largo());
            }

            return max + i_Cabecera;
        }

        // ---------------------------------------------------------------------
        // FUNCTION: uof_cambios_pendientes
        // ---------------------------------------------------------------------
        public virtual bool uof_cambios_pendientes()
        {
            int cantidad = tp.Length - 1;

            for (int i = 1; i <= cantidad; i++)
            {
                if (tp[i].uof_cambios_pendientes())
                    return true;
            }

            return false;
        }

        // ---------------------------------------------------------------------
        // FUNCTION: uof_ancho
        // ---------------------------------------------------------------------
        public virtual int uof_ancho()
        {
            int max = 0;
            int cantidad = tp.Length - 1;

            for (int i = 1; i <= cantidad; i++)
            {
                max = System.Math.Max(max, tp[i].uof_ancho());
            }

            return max;
        }

        // ---------------------------------------------------------------------
        // EVENT: destructor
        // ---------------------------------------------------------------------
        public override void destructor()
        {
            // PB: destructor vacío (comentado)
        }
    }
}
