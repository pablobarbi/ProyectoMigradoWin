using Minotti;
using Minotti.Views.Basicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minotti.Views.Basicos.Controls
{
    /// <summary>
    /// Equivalente a: global type uo_tp from userobject
    /// Esto representa una página de carpeta (tabpage lógica).
    /// </summary>
    public class uo_tp : UserControl
    {
        // =========================
        // Variables PB -> C#
        // =========================

        // st_espacios s_esp
        public st_espacios s_esp { get; set; } = new st_espacios();

        // String is_Accion
        public  string is_Accion = string.Empty;

        // String is_parametros[]
        public  string[] is_parametros = Array.Empty<string>();

        // boolean ib_grabar
        public  bool ib_grabar;

        /// <summary>
        /// Nombre del bitmap asociado (no es propio de WinForms, lo guardamos como dato).
        /// </summary>
        public string PictureName { get; set; } = string.Empty;

        // =========================
        // Constructor
        // =========================

        public uo_tp()
        {
            // Mapeo básico de propiedades visuales PB:
            this.Width = 1961;
            this.Height = 1108;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.FromArgb(0xC0, 0xC0, 0xC0); // aproximado 12632256
        }

        // =========================
        // Eventos PB -> métodos C#
        // =========================

        /// <summary>
        /// PB: event ue_leer_parametros (ref st_pagina_carpeta arg_s_pag)
        /// Fija separaciones y título/bitmap.
        /// </summary>
        public virtual void ue_leer_parametros(st_pagina_carpeta arg_s_pag)
        {
            // /* Fija la separación entre los objetos */
            s_esp.borde = 40;
            s_esp.largo = 100;

            this.Text = arg_s_pag.titulo;
            this.PictureName = arg_s_pag.bitmap;

            // En PB: This.PictureName = arg_s_pag.Bitmap
            // La carga real de imagen la harías en el TabControl (TabPage.ImageKey, etc.).
        }



        public virtual void ue_optar()
        {
            // PB no tenía implementación por defecto
        }

        public virtual void ue_ajustar_tamaño()
        {
            // PB: hook para ajustar tamaño de controles internos
        }

        public virtual void ue_acomodar_objetos()
        {
            // PB: reubicar controles internos usando s_esp, etc.
        }

        /// <summary>
        /// PB: event ue_iniciar (string arg_accion, string arg_param[])
        /// </summary>
        public virtual void ue_iniciar(string arg_accion, string[] arg_param)
        {
            is_Accion = arg_accion;
            is_parametros = arg_param ?? Array.Empty<string>();
        }

        /// <summary>
        /// PB: event ue_dw_detalle (uo_dw arg_objeto)
        /// (sin implementación base)
        /// </summary>
        public virtual void ue_dw_detalle(uo_dw arg_objeto)
        {
            // Normalmente la página concreta overridea esto.
        }

        /// <summary>
        /// PB: event ue_dw_cambio_fila (uo_dw arg_objeto);
        /// Parent.Event Trigger Dynamic ue_dw_cambio_fila(arg_objeto)
        /// </summary>
        public virtual void ue_dw_cambio_fila(uo_dw arg_objeto)
        {
            if (this.Parent != null)
            {
                try
                {
                    dynamic dynParent = this.Parent;
                    dynParent.ue_dw_cambio_fila(arg_objeto);
                }
                catch
                {
                    // Si el padre no tiene ese método, simplemente ignoramos.
                }
            }
        }

        /// <summary>
        /// PB: event ue_dw_itemchanged (uo_dw arg_objeto, long row, dwobject dwo, string data) returns integer
        /// Return(Parent.Event Trigger Dynamic ue_dw_itemchanged(...))
        /// 
        /// En C# no tenemos dwobject, usamos object para placeholder.
        /// </summary>
        public virtual int ue_dw_itemchanged(uo_dw arg_objeto, long row, object dwo, string data)
        {
            if (this.Parent != null)
            {
                try
                {
                    dynamic dynParent = this.Parent;
                    int ret = dynParent.ue_dw_itemchanged(arg_objeto, row, dwo, data);
                    return ret;
                }
                catch
                {
                    // si no lo implementa, devolvemos 0
                }
            }

            return 0;
        }

        /// <summary>
        /// PB: event ue_completar_claves (string sarg_param[]) returns boolean
        /// Return(TRUE)
        /// </summary>
        public virtual bool ue_completar_claves(string[] sarg_param)
        {
            return true;
        }

        /// <summary>
        /// PB: event ue_leer_claves (ref string sarg_param[]) returns boolean
        /// Return(TRUE)
        /// </summary>
        public virtual bool ue_leer_claves(string[] sarg_param)
        {
            // Por ahora no modifica nada; las páginas concretas pueden rellenar claves.
            return true;
        }

        /// <summary>
        /// PB: event ue_validar_datos() returns boolean
        /// Return(TRUE)
        /// </summary>
        public virtual bool ue_validar_datos()
        {
            return true;
        }

        /// <summary>
        /// PB: event ue_preconfirmar() returns boolean
        /// Return(TRUE)
        /// </summary>
        public virtual bool ue_preconfirmar()
        {
            return true;
        }

        /// <summary>
        /// PB: event ue_confirmar(boolean baux1, boolean baux2) returns boolean
        /// Return(TRUE)
        /// </summary>
        public virtual bool ue_confirmar(bool baux1, bool baux2)
        {
            return true;
        }

        /// <summary>
        /// PB: event ue_posconfirmar()
        /// </summary>
        public virtual void ue_posconfirmar()
        {
        }

        /// <summary>
        /// PB: event ue_encender()
        /// </summary>
        public virtual void ue_encender()
        {
        }

        /// <summary>
        /// PB: event ue_aceptar_datos() returns boolean
        /// Return(TRUE)
        /// </summary>
        public virtual bool ue_aceptar_datos()
        {
            return true;
        }

        /// <summary>
        /// PB: event ue_reset()
        /// </summary>
        public virtual void ue_reset()
        {
        }

        /// <summary>
        /// PB: event ue_reiniciar()
        /// /* Reinicia la Pagina */
        /// </summary>
        public virtual void ue_reiniciar()
        {
        }

        /// <summary>
        /// PB: event ue_procesar()
        /// </summary>
        public virtual void ue_procesar()
        {
        }

        /// <summary>
        /// PB: event ue_insertar()
        /// </summary>
        public virtual void ue_insertar()
        {
        }

        /// <summary>
        /// PB: event ue_borrar()
        /// </summary>
        public virtual void ue_borrar()
        {
        }
        // =========================
        // Funciones uof_* (tamaños / cambios)
        // =========================

        /// <summary>
        /// PB: public function integer uof_largo ();
        /// Return(Int(guo_app.uof_GetMdi().WorkSpaceHeight() * 0.7))
        /// </summary>
        public virtual int uof_largo()
        {
            var mdi = guo_app.Instance.uof_getmdi();
            if (mdi != null)
            {
                try
                {
                    return (int)(mdi.WorkSpaceHeight() * 0.7);
                }
                catch
                {
                    // por si WorkSpaceHeight no está todavía implementado
                }
            }

            // fallback: 70% del alto actual
            return (int)(this.Height * 0.7);
        }

        /// <summary>
        /// PB: public function boolean uof_cambios_pendientes ();
        /// Return False
        /// </summary>
        public virtual bool uof_cambios_pendientes()
        {
            return false;
        }

        /// <summary>
        /// PB: public function integer uof_ancho_disponible ();
        /// Return(This.Width)
        /// </summary>
        public virtual int uof_ancho_disponible()
        {
            return this.Width;
        }

        /// <summary>
        /// PB: public function integer uof_largo_disponible ();
        /// return (This.Height)
        /// </summary>
        public virtual int uof_largo_disponible()
        {
            return this.Height;
        }

        /// <summary>
        /// PB: public function integer uof_ancho ();
        /// Return(Int(guo_app.uof_GetMdi().WorkSpaceWidth() * 0.7))
        /// </summary>
        public virtual int uof_ancho()
        {
            var mdi = guo_app.Instance.uof_getmdi();
            if (mdi != null)
            {
                try
                {
                    return (int)(mdi.WorkSpaceWidth() * 0.7);
                }
                catch
                {
                }
            }

            // fallback: 70% del ancho actual
            return (int)(this.Width * 0.7);
        }
    }
}
