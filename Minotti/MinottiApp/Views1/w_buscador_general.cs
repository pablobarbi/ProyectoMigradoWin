using System;
using System.Windows.Forms;

namespace Minotti
{
    // Migrado desde PowerBuilder Window: w_buscador_general.srw
    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.
    public partial class w_buscador_general : Form
    {
        public w_buscador_general()
        {
            InitializeComponent();
        }

        /*
        ================== CONTENIDO ORIGINAL .SRW ==================
﻿forward
global type w_buscador_general from w_tab_reporte_header
end type
end forward


global type w_buscador_general from w_tab_reporte_header 
end type

global w_buscador_general w_buscador_general

on w_buscador_general.create
call super::create
end on

on w_buscador_general.destroy
call super::destroy
end on

event ue_iniciar;/*
				!!!!  ATENCION  !!!!   ANCESTOR SCRIPT OVERRIDE

dejo a la datawindow de cabecera como parametro

*/


// cargo la DW de encabezado.
//dw_1.InsertRow(0)

//end event

//event activate;call super::activate;m_mdi.m_operaciones.m_procesar.Enabled = True


//end event

//event ue_procesar;call super::ue_procesar;String campo, param[]

//dw_1.AcceptText()
//campo = dw_1.GetItemString(1,"campo")

//IF (len(trim(campo)) < 1) OR (IsNull(campo)) THEN
//	MessageBox("Buscador General", "Es necesario ingresar una o mas palabras para la busqueda.")
//	RETURN
//END IF

//param[1] = campo
///* llamo al evento del tab */
//tab_1.Event Trigger ue_iniciar('M', param[])

//end event

//event ue_acomodar_objetos;/*
//¡¡¡ ATENCION !!!  -  ANCESTOR SCRIPT OVERRIDE !!!
//*/

//Integer ancho_para_dw, largo_para_tab


//This.SetRedraw(FALSE)

///* Ajusta el tamaño de dw_1 */
//ancho_para_dw = This.Width - s_esp.ancho - 2 * s_esp.borde

//dw_1.Width = min(dw_1.uof_ancho(), ancho_para_dw)
//dw_1.Height = dw_1.uof_largo()
//dw_1.X = s_esp.borde
//dw_1.Y = s_esp.borde 


///* Ajusta el tamaño de tab_1 */
//largo_para_tab = This.Height - dw_1.Height - s_esp.largo - 4 * s_esp.borde

//tab_1.Event Trigger ue_resize( dw_1.Width, largo_para_tab)
//Tab_1.X = s_esp.borde
//Tab_1.Y = dw_1.Y + dw_1.Height + s_esp.borde  //2 * s_esp.borde 

//This.SetRedraw(TRUE)
//end event

//event ue_ajustar_tamaño;/* Fija el tamaño inicial de la ventana.
//   Considera que el tab control será el objeto más grande */
//// This.Width = tab_1.uof_ancho() + s_esp.ancho + 3 * s_esp.borde
//This.Height = tab_1.uof_largo() + s_esp.largo + 4 * s_esp.borde

//This.Width = dw_1.uof_ancho() + 4 * s_esp.borde

//end event

//        ================== FIN CONTENIDO ORIGINAL .SRW ==============

//        ================== CONTENIDO ORIGINAL .SRW.XAML =============
//﻿<pbwpf:Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="w_buscador_general" x:ClassModifier="internal">
//	<Canvas>
//	</Canvas>
//</pbwpf:Window>
//        ================== FIN CONTENIDO ORIGINAL .SRW.XAML =========
//        */
    }
}