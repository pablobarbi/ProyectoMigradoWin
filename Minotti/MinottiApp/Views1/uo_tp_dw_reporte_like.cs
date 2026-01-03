using System;
using System.Windows.Forms;

namespace Minotti
{
    // Migrado desde PowerBuilder UserObject: uo_tp_dw_reporte_like.sru
    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.
    public partial class uo_tp_dw_reporte_like : UserControl
    {
        public uo_tp_dw_reporte_like()
        {
            InitializeComponent();
        }

        /*
        ================== CONTENIDO ORIGINAL .SRU ==================
﻿forward
global type uo_tp_dw_reporte_like from uo_tp_dw_reporte
end type
end forward


global type uo_tp_dw_reporte_like from uo_tp_dw_reporte 
end type


global uo_tp_dw_reporte_like uo_tp_dw_reporte_like

on uo_tp_dw_reporte_like.create
call super::create
end on

on uo_tp_dw_reporte_like.destroy
call super::destroy
end on

event ue_iniciar;/*
ancestor script override
*/
//String ls_Param[]
//Long   ll_Fila

//is_accion = arg_accion
//is_parametros = arg_param[]

//FOR ll_Fila = 1 TO UpperBound(is_parametros)
//	ls_Param[ll_Fila] = '%' + is_parametros[ll_Fila] + '%'
	
//NEXT

//If dw_1.uof_Retrieve(ls_Param[]) < 1 Then dw_1.InsertRow(0)

//end event

//type dw_1 from uo_tp_dw_reporte`dw_1 within uo_tp_dw_reporte_like 
//end type


//        ================== FIN CONTENIDO ORIGINAL .SRU ==============

//        ================== CONTENIDO ORIGINAL .SRU.XAML =============
//﻿<pbwpf:UserObject xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="uo_tp_dw_reporte_like">
//	<Canvas>
//			<pbwpf:DataWindow Name="dw_1">
//			</pbwpf:DataWindow>
//	</Canvas>
//</pbwpf:UserObject>
//        ================== FIN CONTENIDO ORIGINAL .SRU.XAML =========
//        */
    }
}