// -----------------------------------------------------------------------------
// AUTO-MIGRADO DESDE PowerBuilder (.sru)
// Origen : uo_tp.sru
// Tipo   : userobject
// NOTA   : Migración 1:1 exacta, sin refactor
// -----------------------------------------------------------------------------

#nullable enable
using Minotti.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class uo_tp : UserObject
    {
        // ---------------------------------------------------------------------
        // VARIABLES (PB: type variables)
        // ---------------------------------------------------------------------

        public st_espacios s_esp;            // Medidas a agregar
        public string? is_Accion;
        public string[] is_parametros = System.Array.Empty<string>();
        public bool ib_grabar;


        public uo_tp()
        {
            
        }


        // ---------------------------------------------------------------------
        // EVENTS
        // ---------------------------------------------------------------------

        public virtual void ue_optar() { }
        public virtual void ue_ajustar_tamaño() { }
        public virtual void ue_acomodar_objetos() { }
        public virtual void ue_posconfirmar() { }
        public virtual void ue_encender() { }
        public virtual void ue_reset() { }
        public virtual void ue_procesar() { }

        // ---------------------------------------------------------------------
        // EVENT: ue_leer_parametros
        // ---------------------------------------------------------------------
        public virtual void ue_leer_parametros(ref st_pagina_carpeta arg_s_pag)
        {
            // Fija la separación entre los objetos
            s_esp.borde = 40;
            s_esp.largo = 100;

            this.Text = arg_s_pag.titulo;
            //this.PictureName = arg_s_pag.bitmap;

            // PB comentado:
            // This.Text = f_ProxParam(arg_param)
            // This.PictureName = f_ProxParam(arg_param)
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_iniciar
        // ---------------------------------------------------------------------
        public virtual void ue_iniciar(string arg_accion, string[] arg_param)
        {
            is_Accion = arg_accion;
            is_parametros = arg_param;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_dw_detalle
        // ---------------------------------------------------------------------
        public virtual void ue_dw_detalle(uo_dw arg_objeto)
        {
            Parent.TriggerEvent("ue_dw_detalle", arg_objeto);
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_dw_cambio_fila
        // ---------------------------------------------------------------------
        public virtual void ue_dw_cambio_fila(uo_dw arg_objeto)
        {
            Parent.TriggerEvent("ue_dw_cambio_fila", arg_objeto);
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_dw_itemchanged
        // ---------------------------------------------------------------------
        public virtual int ue_dw_itemchanged(uo_dw arg_objeto, long row, dwobject dwo, string data)
        {
            return Parent.TriggerEventInt(
                "ue_dw_itemchanged",
                arg_objeto,
                row,
                dwo,
                data
            );
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_completar_claves
        // ---------------------------------------------------------------------
        public virtual bool ue_completar_claves(string[] sarg_param)
        {
            return true;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_leer_claves
        // ---------------------------------------------------------------------
        public virtual bool ue_leer_claves(ref string[] sarg_param)
        {
            return true;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_validar_datos
        // ---------------------------------------------------------------------
        public virtual bool ue_validar_datos()
        {
            return true;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_preconfirmar
        // ---------------------------------------------------------------------
        public virtual bool ue_preconfirmar()
        {
            return true;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_confirmar
        // ---------------------------------------------------------------------
        public virtual bool ue_confirmar(bool baux1, bool baux2)
        {
            return true;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_aceptar_datos
        // ---------------------------------------------------------------------
        public virtual bool ue_aceptar_datos()
        {
            return true;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_reiniciar
        // ---------------------------------------------------------------------
        public virtual void ue_reiniciar()
        {
            // PB: evento vacío
        }

        // ---------------------------------------------------------------------
        // FUNCTION: uof_largo
        // ---------------------------------------------------------------------
        public virtual int uof_largo()
        {
            return (int)(guo_app.uof_Getmdi().WorkSpaceHeight * 0.7);
        }

        // ---------------------------------------------------------------------
        // FUNCTION: uof_cambios_pendientes
        // ---------------------------------------------------------------------
        public virtual bool uof_cambios_pendientes()
        {
            return false;
        }

        // ---------------------------------------------------------------------
        // FUNCTION: uof_ancho_disponible
        // ---------------------------------------------------------------------
        public virtual int uof_ancho_disponible()
        {
            return this.Width;
        }

        // ---------------------------------------------------------------------
        // FUNCTION: uof_largo_disponible
        // ---------------------------------------------------------------------
        public virtual int uof_largo_disponible()
        {
            return this.Height;
        }

        // ---------------------------------------------------------------------
        // FUNCTION: uof_ancho
        // ---------------------------------------------------------------------
        public virtual int uof_ancho()
        {
            return (int)(guo_app.uof_Getmdi().WorkSpaceWidth * 0.7);
        }

        protected void SetRedraw(bool enable)
        {
            if (IsHandleCreated)
            {
                const int WM_SETREDRAW = 0x000B;
                NativeMethods.SendMessage(this.Handle, WM_SETREDRAW, enable ? 1 : 0, 0);

                if (enable)
                    this.Invalidate();
            }
        }


        // ---------------------------------------------------------------------
        // PB: on uo_tp.create
        // ---------------------------------------------------------------------
        public virtual void create()
        {
            // vacío en PB
        }

        // ---------------------------------------------------------------------
        // PB: on uo_tp.destroy
        // ---------------------------------------------------------------------
        public virtual void destroy()
        {
           // vacío en PB
        }
    }
}
