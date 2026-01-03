using System;
using System.Windows.Forms;

namespace Minotti
{
    public partial class w_abm_diagnosticos : Form
    {
        public w_abm_diagnosticos() => InitializeComponent();

        /* SRW original
﻿forward
global type w_abm_diagnosticos from w_abm_detalle
end type
end forward


global type w_abm_diagnosticos from w_abm_detalle 
end type

global w_abm_diagnosticos w_abm_diagnosticos

on w_abm_diagnosticos.create
call super::create
end on

on w_abm_diagnosticos.destroy
call super::destroy
end on

event ue_validar_datos;/*
	ATENCION !!!     ANCESTOR SCRIPT OVERRIDE !!!
*/

//Long ll_Datos

//ll_Datos = dw_1.GetItemNumber( 1, 'paciente')
//IF IsNull(ll_Datos) THEN
//	MessageBox('Validar', 'Debe ingresar un paciente para el diagnóstico.', StopSign!, Ok!)
//	ib_grabar = FALSE
//	RETURN
//END IF


////ls_Datos = dw_1.GetItemString( 1, 'descripcion')
////IF IsNull(ls_Datos) OR ls_Datos = '' THEN
////	MessageBox('Validar', 'El campo descripcion no puede estar vacio.', StopSign!, Ok!)
////	ib_grabar = FALSE
////	RETURN
////END IF




//end event

//event ue_dw_itemchanged;call super::ue_dw_itemchanged;Long cnt, paciente

//IF dwo.name = 'paciente' THEN
	
//	paciente = Long(data)
//	SELECT count(*)
//	  INTO :cnt
//	  FROM diagnosticos
//	 WHERE paciente = :paciente
//	 USING SQLCA;
	
//	IF cnt = 0 THEN
//		cnt = 1
//	ELSE
//		cnt++
//	END IF
	
//	dw_1.SetItem( 1, 'diagnostico', cnt)
	
//END IF

//RETURN 0

//end event

//event ue_iniciar;call super::ue_iniciar;Date ld_hoy

//IF at_op.Accion = "A" THEN /* Es un alta */
//	ld_hoy = Today()
//	dw_1.SetItem(1, 'fecha_visita', ld_Hoy)
//END IF
//end event

//        */

//        /* SRW.XAML original
//﻿<pbwpf:Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="w_abm_diagnosticos" x:ClassModifier="internal">
//	<Canvas>
//	</Canvas>
//</pbwpf:Window>
//        */
    }
}