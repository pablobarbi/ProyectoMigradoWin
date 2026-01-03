using System;
using System.Windows.Forms;

namespace Minotti
{
    // Migrado desde PowerBuilder Window: w_reporte_mensaje.srw
    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.
    public partial class w_reporte_mensaje : Form
    {
        public w_reporte_mensaje()
        {
            InitializeComponent();
        }

        /*
        ================== CONTENIDO ORIGINAL .SRW ==================
﻿forward
global type w_reporte_mensaje from w_reporte
end type
end forward


global type w_reporte_mensaje from w_reporte 
end type

global w_reporte_mensaje w_reporte_mensaje

event ue_procesar;/* 
ATENCION!!! ANCESTOR SCRIPT OVERRIDE!!!
*/

string parametros[]
string filtro
long  rtn

SetPointer(HourGlass!)

If isValid(dw_param) Then
	If dw_param.AcceptText() <> 1 Then
		dw_param.SetFocus()
		Return
	End If

	/* Lee los valores clave de la línea seleccionada
	   en dw_param y los pasa como argumentos a dw_reporte */
	dw_param.uof_GetArgumentos(parametros[], dw_param.GetRow())
End If

rtn = MessageBox('Atención', 'Si actualizó capítulo, rúbrica o subrúbrica, invoque y procese primero Actualizar Matriz de Capítulos para que se incluyan en esta búsqueda esos cambios.', Exclamation!, OKCancel!, 2)
if rtn = 1 then
	dw_reporte.uof_Retrieve(parametros[])
	
	/* Si no encontró datos, envía un mensaje */
	If dw_reporte.RowCount() < 1 Then
		MessageBox('Atención', 'No hay registros')
		If isValid(dw_param) Then dw_param.SetFocus()
	Else
		dw_reporte.SetFocus()
	End If
End If

end event

on w_reporte_mensaje.create
call super::create
end on

on w_reporte_mensaje.destroy
call super::destroy
end on

        ================== FIN CONTENIDO ORIGINAL .SRW ==============

        ================== CONTENIDO ORIGINAL .SRW.XAML =============
﻿<pbwpf:Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="w_reporte_mensaje" x:ClassModifier="internal">
	<Canvas>
	</Canvas>
</pbwpf:Window>
        ================== FIN CONTENIDO ORIGINAL .SRW.XAML =========
        */
    }
}