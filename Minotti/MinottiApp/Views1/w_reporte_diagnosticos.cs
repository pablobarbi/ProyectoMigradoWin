using System;
using System.Windows.Forms;

namespace Minotti
{
    // Migrado desde PowerBuilder Window: w_reporte_diagnosticos.srw
    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.
    public partial class w_reporte_diagnosticos : Form
    {
        public w_reporte_diagnosticos()
        {
            InitializeComponent();
        }

        /*
        ================== CONTENIDO ORIGINAL .SRW ==================
﻿forward
global type w_reporte_diagnosticos from w_reporte
end type
end forward


global type w_reporte_diagnosticos from w_reporte 
end type

global w_reporte_diagnosticos w_reporte_diagnosticos

on w_reporte_diagnosticos.create
call super::create
end on

on w_reporte_diagnosticos.destroy
call super::destroy
end on

event ue_procesar;String ls_datos, parametros[]

If dw_param.AcceptText() <> 1 Then
	dw_param.SetFocus()
	Return
End If

/* Lee los valores clave de la línea seleccionada
	en dw_param y los pasa como argumentos a dw_reporte */
dw_param.uof_GetArgumentos(parametros[], dw_param.GetRow())
parametros[3] = '%' + parametros[3] + '%'


ls_datos = dw_param.GetItemString( 1, 'tipo_diagnostico')
IF IsNull(ls_datos) OR Trim(ls_datos)='' THEN
	MessageBox('Atención', 'Es necesario completar el tipo de diagnóstico antes de procesar.')
	RETURN
END IF

ls_datos = dw_param.GetItemString( 1, 'diag_nosologico')
IF IsNull(ls_datos) OR Trim(ls_datos)='' THEN
	MessageBox('Atención', 'Es necesario completar el diagnóstico antes de procesar.')
	RETURN
END IF


SetPointer(HourGlass!)


dw_reporte.uof_Retrieve(parametros[])

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
﻿<pbwpf:Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="w_reporte_diagnosticos" x:ClassModifier="internal">
	<Canvas>
	</Canvas>
</pbwpf:Window>
        ================== FIN CONTENIDO ORIGINAL .SRW.XAML =========
        */
    }
}