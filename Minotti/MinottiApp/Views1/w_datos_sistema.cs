using System;
using System.Windows.Forms;

namespace Minotti
{
    public partial class w_datos_sistema : Form
    {
        public w_datos_sistema() => InitializeComponent();

        /* SRW original
﻿forward
global type w_datos_sistema from w_principal
end type
type gb_borde from groupbox within w_datos_sistema
end type
type st_nombre from statictext within w_datos_sistema
end type
type st_version from statictext within w_datos_sistema
end type
type st_copyright from statictext within w_datos_sistema
end type
type p_logo from picture within w_datos_sistema
end type
type cb_1 from commandbutton within w_datos_sistema
end type
end forward


global type w_datos_sistema from w_principal 

gb_borde gb_borde 
st_nombre st_nombre 
st_version st_version 
st_copyright st_copyright 
p_logo p_logo 
cb_1 cb_1 
end type


global w_datos_sistema w_datos_sistema

type variables

end variables

event open;call super::open;cat_app		at_app

/* Recibe los parámetros necesarios */
at_app = Message.PowerObjectParm

/* Carga el Nombre de la Aplicación, la Versión, el Logo, el Copyright */
st_nombre.Text = at_app.Nombre
st_version.Text = "Versión " + at_app.Version
p_logo.PictureName = at_app.Logo
st_copyright.Text = at_app.Copyright

/* Posiciona la ventana el borde atrás de todos los objetos de la ventrana */
//this.SetPosition (TopMost!)
gb_borde.SetPosition(ToBottom!)
end event

on w_datos_sistema.create
int iCurrent
call super::create
this.gb_borde=create gb_borde
this.st_nombre=create st_nombre
this.st_version=create st_version
this.st_copyright=create st_copyright
this.p_logo=create p_logo
this.cb_1=create cb_1
iCurrent=UpperBound(this.Control)
this.Control[iCurrent+1]=this.gb_borde
this.Control[iCurrent+2]=this.st_nombre
this.Control[iCurrent+3]=this.st_version
this.Control[iCurrent+4]=this.st_copyright
this.Control[iCurrent+5]=this.p_logo
this.Control[iCurrent+6]=this.cb_1
end on

on w_datos_sistema.destroy
call super::destroy
destroy(this.gb_borde)
destroy(this.st_nombre)
destroy(this.st_version)
destroy(this.st_copyright)
destroy(this.p_logo)
destroy(this.cb_1)
end on

type gb_borde from groupbox within w_datos_sistema 

end type



type st_nombre from statictext within w_datos_sistema 

end type



type st_version from statictext within w_datos_sistema 

end type



type st_copyright from statictext within w_datos_sistema 

end type



type p_logo from picture within w_datos_sistema 

end type



type cb_1 from commandbutton within w_datos_sistema 

end type


event clicked;Close(Parent)
end event

        */

        /* SRW.XAML original
﻿<pbwpf:Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="w_datos_sistema" x:ClassModifier="internal" PBHeight="1232" PBWidth="2368">
	<Canvas>
			<pbwpf:GroupBox Name="gb_borde" BackColor="81324524" FaceName="Arial" FontPitch="variable" PBFontFamily="swiss" PBHeight="928" PBWidth="2254" TabOrder="1" TextSize="-10" Weight="400" X="37" Y="32">
				<Canvas>
				</Canvas>
			</pbwpf:GroupBox>
			<pbwpf:StaticText Name="st_nombre" Alignment="center" BackColor="81324524" BringToTop="true" Enabled="false" FaceName="Arial" FocusRectangle="false" FontPitch="variable" PBFontFamily="swiss" PBHeight="104" PBWidth="2016" TextSize="-14" Weight="700" X="155" Y="456">
			</pbwpf:StaticText>
			<pbwpf:StaticText Name="st_version" Alignment="center" BackColor="81324524" BringToTop="true" Enabled="false" FaceName="Arial" FocusRectangle="false" FontPitch="variable" PBFontFamily="swiss" PBHeight="88" PBWidth="2016" TextSize="-12" Weight="400" X="155" Y="564">
			</pbwpf:StaticText>
			<pbwpf:StaticText Name="st_copyright" Alignment="right" BackColor="81324524" BringToTop="true" Enabled="false" FaceName="Arial" FocusRectangle="false" FontPitch="variable" PBFontFamily="swiss" PBHeight="72" PBWidth="2016" TextSize="-9" Weight="400" X="155" Y="868">
			</pbwpf:StaticText>
			<pbwpf:Picture Name="p_logo" BringToTop="true" FocusRectangle="false" PBHeight="452" PBWidth="576" X="87" Y="128">
			</pbwpf:Picture>
			<pbwpf:CommandButton Name="cb_1" BringToTop="true" FaceName="Arial" FontPitch="variable" PBFontFamily="swiss" PBHeight="108" PBWidth="256" TabOrder="2" Text="_Cerrar" TextSize="-10" Weight="400" X="2011" Y="980">
			</pbwpf:CommandButton>
	</Canvas>
</pbwpf:Window>
        */
    }
}