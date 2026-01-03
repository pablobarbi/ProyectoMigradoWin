using System;
using System.Windows.Forms;
using Minotti.Models;

namespace Minotti.Controls
{
    // Migración de PowerBuilder: uo_tp.sru (userobject from userobject)
    public partial class uo_tp : TabPage
    {
        // ==== variables (mismos nombres que en PB) ====
        public st_espacios s_esp;
        public string is_Accion;
        public string[] is_parametros;
        public bool ib_grabar;

        // Propiedad para mapear This.PictureName
        public string PictureName { get; set; }

        public uo_tp()
        {
            InitializeComponent();

            s_esp = new st_espacios();
            is_Accion = string.Empty;
            is_parametros = Array.Empty<string>();
            ib_grabar = false;
            PictureName = string.Empty;
        }

        // =====================
        //  Eventos / métodos ue_*
        // =====================

        // event ue_leer_parametros (ref st_pagina_carpeta arg_s_pag)
        // /* Fija la separación entre los objetos */
        public void ue_leer_parametros(ref st_pagina_carpeta arg_s_pag)
        {
            s_esp.borde = 40;
            s_esp.largo = 100;

            this.Text = arg_s_pag.titulo;
            this.PictureName = arg_s_pag.bitmap;

            // //This.Text = f_ProxParam(arg_param)
            // //This.PictureName = f_ProxParam(arg_param)
        }

        // event ue_optar ()
        public void ue_optar()
        {
            // Sin implementación en el SRU original
        }

        // event ue_ajustar_tamaño ()
        public void ue_ajustar_tamaño()
        {
            // Sin implementación en el SRU original
        }

        // event ue_acomodar_objetos ()
        public void ue_acomodar_objetos()
        {
            // Sin implementación en el SRU original
        }

        // event ue_iniciar (string arg_accion,string arg_param[])
        // event ue_iniciar;is_accion = arg_accion
        // is_parametros = arg_param[]
        public void ue_iniciar(string arg_accion, string[] arg_param)
        {
            is_Accion = arg_accion;
            is_parametros = arg_param ?? Array.Empty<string>();
        }

        // event ue_dw_detalle (uo_dw arg_objeto)
        public void ue_dw_detalle(uo_dw arg_objeto)
        {
            // Sin implementación en el SRU original
        }

        // event ue_dw_cambio_fila (uo_dw arg_objeto)
        // event ue_dw_cambio_fila;Parent.Event Trigger Dynamic ue_dw_cambio_fila(arg_objeto)
        public void ue_dw_cambio_fila(uo_dw arg_objeto)
        {
            var tabControl = this.Parent as TabControl;
            var parentTab = tabControl?.Parent as uo_tab;
            parentTab?.ue_dw_cambio_fila(arg_objeto);
        }

        // event type integer ue_dw_itemchanged (uo_dw arg_objeto,long row,dwobject dwo,string data)
        // event ue_dw_itemchanged;Return(Parent.Event Trigger Dynamic ue_dw_itemchanged(arg_objeto, row, dwo, data))
        public int ue_dw_itemchanged(uo_dw arg_objeto, long row, object dwo, string data)
        {
            var tabControl = this.Parent as TabControl;
            var parentTab = tabControl?.Parent as uo_tab;
            if (parentTab != null)
            {
                return parentTab.ue_dw_itemchanged(arg_objeto, row, dwo, data);
            }
            return 0;
        }

        // event type boolean ue_completar_claves (string sarg_param[])
        // event ue_completar_claves;Return(TRUE)
        public bool ue_completar_claves(string[] sarg_param)
        {
            return true;
        }

        // event type boolean ue_leer_claves (ref string sarg_param[])
        // event ue_leer_claves;Return(TRUE)
        public bool ue_leer_claves(ref string[] sarg_param)
        {
            return true;
        }

        // event type boolean ue_validar_datos ()
        // event ue_validar_datos;Return(TRUE)
        public bool ue_validar_datos()
        {
            return true;
        }

        // event type boolean ue_preconfirmar ()
        // event ue_preconfirmar;Return(TRUE)
        public bool ue_preconfirmar()
        {
            return true;
        }

        // event type boolean ue_confirmar (boolean baux1,boolean baux2)
        // event ue_confirmar;Return(TRUE)
        public bool ue_confirmar(bool baux1, bool baux2)
        {
            return true;
        }

        // event ue_posconfirmar ()
        public void ue_posconfirmar()
        {
            // Sin implementación en el SRU original
        }

        // event ue_encender ()
        public void ue_encender()
        {
            // Sin implementación en el SRU original
        }

        // event type boolean ue_aceptar_datos ()
        // event ue_aceptar_datos;Return(TRUE)
        public bool ue_aceptar_datos()
        {
            return true;
        }

        // event ue_reset ()
        public void ue_reset()
        {
            // Sin implementación en el SRU original
        }

        // event ue_reiniciar ()
        // event ue_reiniciar;/* Reinicia la Pagina */
        public void ue_reiniciar()
        {
            // Reinicia la página (sin lógica específica en el SRU)
        }

        // event ue_procesar ()
        public void ue_procesar()
        {
            // Sin implementación en el SRU original
        }

        // =====================
        //  Funciones uof_*
        // =====================

        // public function integer uof_largo ();
        // Return(Int(guo_app.uof_GetMdi().WorkSpaceHeight() * 0.7))
        public int uof_largo()
        {
            int h = GetMdiWorkspaceHeight();
            return (int)(h * 0.7);
        }

        // public function boolean uof_cambios_pendientes ();Return False
        public bool uof_cambios_pendientes()
        {
            return false;
        }

        // public function integer uof_ancho_disponible ();Return(This.Width)
        public int uof_ancho_disponible()
        {
            return this.Width;
        }

        // public function integer uof_largo_disponible ();return (This.Height)
        public int uof_largo_disponible()
        {
            return this.Height;
        }

        // public function integer uof_ancho ();
        // Return(Int(guo_app.uof_GetMdi().WorkSpaceWidth() * 0.7))
        public int uof_ancho()
        {
            int w = GetMdiWorkspaceWidth();
            return (int)(w * 0.7);
        }

        // =====================
        //  Helpers para emular guo_app.uof_GetMdi().WorkSpace...
        // =====================

        private Form GetMdiForm()
        {
            var f = this.FindForm();
            if (f == null) return null;
            if (f.IsMdiContainer) return f;
            return f.MdiParent;
        }

        private int GetMdiWorkspaceHeight()
        {
            var mdi = GetMdiForm();
            return mdi?.ClientSize.Height ?? this.Height;
        }

        private int GetMdiWorkspaceWidth()
        {
            var mdi = GetMdiForm();
            return mdi?.ClientSize.Width ?? this.Width;
        }
    }
}
