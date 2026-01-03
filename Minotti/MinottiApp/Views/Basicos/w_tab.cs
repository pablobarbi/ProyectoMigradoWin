using Minotti.Data;
using Minotti.Functions;
using Minotti.utils;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Pbl.Views;
using MinottiApp.utils;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Minotti.utils.PBGlobals;

namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_tab.srw
    // En PB: global type w_tab from w_operacion
    // PB: global type w_tab from w_operacion
    public partial class w_tab : w_operacion
    {
        // PB: uo_tab tab_1
        public uo_tab tab_1;

        public w_tab()
        {
            InitializeComponent();

            // PB: long backcolor = 12632256  (Silver)
            this.BackColor = ColorTranslator.FromWin32(12632256);

            // PB: string icon = "ventanas.ico"
            // Ajustá esto a cómo cargás íconos en tu proyecto (Resources, etc.)
            try
            {
                // Ejemplo básico si tenés el ico en el ejecutable:
                // this.Icon = new Icon("ventanas.ico");
            }
            catch
            {
                // ignorar si falla
            }
        }

        // =====================================================
        // f_pagina_o_tab (función en desuso en PB)
        // =====================================================
        public int f_pagina_o_tab(string evento)
        {
            /*
            
            ¡¡¡¡¡ESTA FUNCION ESTA EN DESUSO!!!!!

            Funcion:     f_pagina_o_tab()
            Argumentos:  String - evento que lo llama;
            Retorno:     Entero - 1: si es pagina;
                                  2: si es todo el tab;
            Descripcion: Verifica si el usuario necesita toda la información 
                         o solo la de la pagina activa.
            
            En PB actualmente devuelve fijo 1.
            */

            return 1;
        }

        // =====================================================
        // Eventos PB → métodos públicos en C#
        // Se llaman desde el menú / framework igual que el resto
        // =====================================================

        // ue_leer_parametros
        //public  override void ue_leer_parametrosOld()
        //{
        //    base.ue_leer_parametros();

        //    /*
        //     Parámetros de la ventana (según comentario PB):
        //     uo_tab (o herencia),
        //     CARPETA (código de carpeta para cargar las páginas del tab)
        //    */

        //    string param = at_op.uof_getparametros();

        //    Cursor.Current = Cursors.WaitCursor;

        //    // PB:
        //    // OpenUserObject(tab_1, wf_ProxParam(param))
        //    // ls_siguiente = wf_ProxParam(param)
        //    // tab_1.Event Trigger ue_leer_parametros(ls_siguiente)

        //    // En C#: asumimos que tab_1 ya es la instancia correcta (creada en InitializeComponent)
        //    // Consumimos dos parámetros del string:
        //    string dummy =   GlobalHelpers.wf_proxparam(param);    // nombre del objeto tab en PB (no usado aquí)
        //    string ls_siguiente = GlobalHelpers.wf_proxparam( param);  // CARPETA

        //    if (tab_1 != null)
        //    {
        //        tab_1.ue_leer_parametros(ls_siguiente);
        //    }
        //}

        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            string param = at_op.uof_getparametros();
            Cursor.Current = Cursors.WaitCursor;

            // consumir el userobject (no usado)
            string _ = f_proxparam.fproxparam(param);  // GlobalHelpers.wf_proxparam(param);

            // obtener CARPETA
            string ls_siguiente = f_proxparam.fproxparam(param);// GlobalHelpers.wf_proxparam(param);

            if (tab_1 != null)
            {
                // PB equivalencia: tab_1.TriggerEvent("ue_leer_parametros", ls_siguiente)
                DynamicEventInvoker.Trigger(tab_1, "ue_leer_parametros", ls_siguiente);
            }
        }


        // ue_iniciar
        public override void ue_iniciar()
        {
            // PB:
            // tab_1.Event Trigger ue_iniciar(is_Accion, at_op.s_det[])
            tab_1?.ue_iniciar(this.is_Accion, at_op.s_det);
        }

        // ue_acomodar_objetos
        public  override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            if (tab_1 == null)
                return;

            // PB:
            // tab_1.Event Trigger ue_resize(This.wf_ancho_disponible(),This.wf_largo_disponible())
            // This.wf_centrarobjeto(tab_1)
            // Tab_1.x = s_esp.borde
            // Tab_1.y = s_esp.borde 

            tab_1.ue_resize(this.wf_ancho_disponible(), this.wf_largo_disponible());

            // Centrado horizontal (como wf_centrarobjeto)
            wf_centrarobjeto(tab_1);

            // Ajuste de borde
            tab_1.Left = s_esp.borde;
            tab_1.Top = s_esp.borde;
        }

        // ue_confirmar
        public  override void ue_confirmar()
        {
            bool AutoCom = SQLCA.AutoCommit;
            SQLCA.AutoCommit = false;

            // PB:
            // ib_grabar = tab_1.Event Trigger ue_confirmar(TRUE, TRUE)
            ib_grabar = tab_1 != null && tab_1.ue_confirmar(true, true);

            if (ib_grabar)
            {
                SQLCA.Commit();
                SQLCA.AutoCommit = AutoCom;
            }
            else
            {
                SQLCA.Rollback();
                SQLCA.AutoCommit = AutoCom;
            }
        }

        // ue_ajustar_tamaño
        public  override void ue_ajustar_tamaño()
        {
            if (tab_1 == null)
                return;

            // PB:
            // This.Width = tab_1.uof_ancho() + s_esp.ancho + 3 * s_esp.borde
            // This.Height = tab_1.uof_largo() + s_esp.largo + 3 * s_esp.borde

            this.Width = tab_1.uof_ancho() + s_esp.ancho + 3 * s_esp.borde;
            this.Height = tab_1.uof_largo() + s_esp.largo + 3 * s_esp.borde;
        }

        // ue_posconfirmar
        public  override void ue_posconfirmar()
        {
            // PB:
            // tab_1.Event Trigger ue_posconfirmar()
            tab_1?.ue_posconfirmar();

            // Ejecuto el script del ancestro
            base.ue_posconfirmar();
        }

        // ue_preconfirmar
        public  override void ue_preconfirmar()
        {
            base.ue_preconfirmar();
            // PB:
            // ib_grabar = tab_1.Event Trigger ue_preconfirmar()
            ib_grabar = tab_1 != null && tab_1.ue_preconfirmar();
        }

        // ue_completar_claves
        public  override void ue_completar_claves()
        {
            base.ue_completar_claves();
            // PB:
            // ib_grabar = tab_1.Event Trigger ue_completar_claves(at_op.s_det[])
            ib_grabar = tab_1 != null && tab_1.ue_completar_claves(at_op.s_det);
        }

        // ue_aceptar_datos
        public  override void ue_aceptar_datos()
        {
            base.ue_aceptar_datos();
            // PB:
            // ib_grabar = tab_1.Event Trigger ue_aceptar_datos()
            ib_grabar = tab_1 != null && tab_1.ue_aceptar_datos();
        }

        // ue_validar_datos
        public  override void ue_validar_datos()
        {
            // PB:
            // ib_grabar = tab_1.Event Trigger ue_validar_datos()
            ib_grabar = tab_1 != null && tab_1.ue_validar_datos();
        }

        // activate
        protected  override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            // PB:
            // m_mdi.m_operaciones.m_borrar.Enabled = False
            // m_mdi.m_operaciones.m_insertar.Enabled = False
            // //m_mdi.m_operaciones.m_imprimir.Enabled = at_op.uof_puede('I')

            try
            {

                PBGlobals.m_mdi.m_operaciones.Enabled = false;
                PBGlobals.m_mdi.m_insertar.Enabled = false;
                // m_mdi.m_operaciones.m_imprimir.Enabled = at_op.uof_puede("I");
            }
            catch
            {
                // si el menú no está disponible, ignoramos
            }
        }

        // deactivate
        protected  override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            // PB:
            // m_mdi.m_operaciones.m_imprimir.Enabled = FALSE
            try
            {
               PBGlobals.m_mdi.m_imprimir.Enabled = false;
            }
            catch
            {
                // ignorar
            }
        }

        // ue_imprimir
        public  override void ue_imprimir()
        {
            tab_1?.ue_imprimir();
        }

        // ue_preview
        public  override void ue_preview()
        {
            tab_1?.ue_preview();
        }
    }
}
