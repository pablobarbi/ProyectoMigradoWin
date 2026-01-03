using System;
using System.Windows.Forms;

namespace Minotti
{
    // Migrado desde PowerBuilder Window: w_reporte_capitulo_2med_valor.srw
    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.
    public partial class w_reporte_capitulo_2med_valor : Form
    {
        public w_reporte_capitulo_2med_valor()
        {
            InitializeComponent();
        }

        /*
        ================== CONTENIDO ORIGINAL .SRW ==================
﻿forward
global type w_reporte_capitulo_2med_valor from w_reporte
end type
end forward


global type w_reporte_capitulo_2med_valor from w_reporte 
end type

global w_reporte_capitulo_2med_valor w_reporte_capitulo_2med_valor

type variables
uo_ds		ds_reporte

end variables

on w_reporte_capitulo_2med_valor.create
call super::create
end on

on w_reporte_capitulo_2med_valor.destroy
call super::destroy
end on

event ue_procesar;/*
	 ATENCION !!! ANCESTOR SCRIPT OVERRIDE
*/
uo_capitulos ls_capitulos
Long         ll_capitulo, ll_valor, ll_valor2
String       ls_medicamento, ls_medicamento2


SetPointer(HourGlass!)

If dw_param.AcceptText() <> 1 Then
	dw_param.SetFocus()
	Return
End If


ds_reporte = create uo_ds
ds_reporte.SetTransObject(SQLCA)
ds_reporte.uof_SetDataObject('dr_capitulo_completo')


ll_capitulo = dw_param.GetItemNumber( 1, "capitulo")
ls_medicamento = dw_param.GetItemString( 1, "medicamento")
ls_medicamento2 = dw_param.GetItemString( 1, "medicamento2")
ll_valor = dw_param.GetItemNumber( 1, "valor")
ll_valor2 = dw_param.GetItemNumber( 1, "valor2")

IF IsNull(ll_capitulo) OR IsNull(ls_medicamento) OR IsNull(ls_medicamento2) OR IsNull(ll_Valor) OR IsNull(ll_Valor2) THEN
	MessageBox('Atención', 'Es necesario completar todos los valores antes de procesar.')
	RETURN
END IF

IF ls_medicamento = ls_medicamento2 THEN
	MessageBox('Atención', 'Es necesario que los medicamentos sean distintos.')
	RETURN
END IF

ls_capitulos = CREATE uo_capitulos
ls_capitulos.capitulo_id = ll_Capitulo
ls_capitulos.uo_cargar_info()
ls_capitulos.uo_devolver_un_med_valor(ds_reporte, ls_medicamento, ll_Valor)
ls_capitulos.uo_devolver_un_med_valor(ds_reporte, ls_medicamento2, ll_Valor2)


// comparto el buffer.
ds_reporte.ShareData(dw_reporte)

/* Si no encontró datos, envía un mensaje */
If dw_reporte.RowCount() < 1 Then
	MessageBox('Atención', 'No hay registros')
	If isValid(dw_param) Then dw_param.SetFocus()
Else
	dw_reporte.SetFocus()
End If

end event

        ================== FIN CONTENIDO ORIGINAL .SRW ==============

        ================== CONTENIDO ORIGINAL .SRW.XAML =============
﻿<pbwpf:Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="w_reporte_capitulo_2med_valor" x:ClassModifier="internal">
	<Canvas>
	</Canvas>
</pbwpf:Window>
        ================== FIN CONTENIDO ORIGINAL .SRW.XAML =========
        */
    }
}