using System;
using System.Windows.Forms;

namespace Minotti
{
    public partial class w_medicamentos : Form
    {
        public w_medicamentos() => InitializeComponent();

        /* SRW original
﻿forward
global type w_medicamentos from w_abm_detalle
end type
end forward


global type w_medicamentos from w_abm_detalle 

end type

global w_medicamentos w_medicamentos

on w_medicamentos.create
call super::create
end on

on w_medicamentos.destroy
call super::destroy
end on

event ue_dw_button_clicked;call super::ue_dw_button_clicked;// abro la ventana para que se seleccione la imagen.
string docname, named

integer value

value = GetFileOpenName("Seleccionar la imagen asociada al medicamento", &
		+ docname, named, "JPG", &
		+ "Archivos de Imagenes (*.JPG),*.JPG," &
		+ "Archivos de Imagenes (*.BMP),*.BMP," )
//		+ "Doc Files (*.DOC),*.DOC")

if value = 1 then
	dw_1.SetItem( 1, "imagen_asociada", docname)
	dw_1.object.p_1.Filename = docname
	This.SetFocus()
else 
	This.SetFocus()
end if

// recupero el foco en la ventana.
This.SetFocus()



end event

event ue_iniciar;call super::ue_iniciar;String imagen

imagen = dw_1.GetItemString( 1, "imagen_asociada")
dw_1.object.p_1.Filename = imagen

dw_1.SetFocus()

end event

event ue_validar_datos;/*
	ATENCION !!!     ANCESTOR SCRIPT OVERRIDE !!!
*/

String ls_Datos

ls_Datos = dw_1.GetItemString( 1, 'medicamento')
IF IsNull(ls_Datos) OR ls_Datos = '' THEN
	MessageBox('Validar', 'El campo medicamento no puede estar vacio.', StopSign!, Ok!)
	ib_grabar = FALSE
	RETURN
END IF

ls_Datos = dw_1.GetItemString( 1, 'descripcion')
IF IsNull(ls_Datos) OR ls_Datos = '' THEN
	MessageBox('Validar', 'El campo descripcion no puede estar vacio.', StopSign!, Ok!)
	ib_grabar = FALSE
	RETURN
END IF




end event

        */

        /* SRW.XAML original
﻿<pbwpf:Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="w_medicamentos" x:ClassModifier="internal" PBHeight="1232" PBWidth="2299">
	<Canvas>
	</Canvas>
</pbwpf:Window>
        */
    }
}