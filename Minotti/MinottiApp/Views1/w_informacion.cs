using System;
using System.Windows.Forms;

namespace Minotti
{
    public partial class w_informacion : Form
    {
        public w_informacion() => InitializeComponent();

        /* SRW original
﻿forward
global type w_informacion from w_operacion
end type
type st_4 from statictext within w_informacion
end type
type st_1 from statictext within w_informacion
end type
type st_2 from statictext within w_informacion
end type
type st_3 from statictext within w_informacion
end type
type p_logo from picture within w_informacion
end type
type r_1 from rectangle within w_informacion
end type
type cb_1 from commandbutton within w_informacion
end type
end forward


global type w_informacion from w_operacion 

st_4 st_4 
st_1 st_1 
st_2 st_2 
st_3 st_3 
p_logo p_logo 
r_1 r_1 
cb_1 cb_1 
end type


global w_informacion w_informacion

on w_informacion.create
int iCurrent
call super::create
this.st_4=create st_4
this.st_1=create st_1
this.st_2=create st_2
this.st_3=create st_3
this.p_logo=create p_logo
this.r_1=create r_1
this.cb_1=create cb_1
iCurrent=UpperBound(this.Control)
this.Control[iCurrent+1]=this.st_4
this.Control[iCurrent+2]=this.st_1
this.Control[iCurrent+3]=this.st_2
this.Control[iCurrent+4]=this.st_3
this.Control[iCurrent+5]=this.p_logo
this.Control[iCurrent+6]=this.r_1
this.Control[iCurrent+7]=this.cb_1
end on

on w_informacion.destroy
call super::destroy
destroy(this.st_4)
destroy(this.st_1)
destroy(this.st_2)
destroy(this.st_3)
destroy(this.p_logo)
destroy(this.r_1)
destroy(this.cb_1)
end on

event ue_optar;call super::ue_optar;s_min.ancho = 30 // 80
s_min.largo = 30 // 80

end event

type st_4 from statictext within w_informacion 

end type



type st_1 from statictext within w_informacion 

end type



type st_2 from statictext within w_informacion 

end type



type st_3 from statictext within w_informacion 

end type



type p_logo from picture within w_informacion 

end type



type r_1 from rectangle within w_informacion 

end type



type cb_1 from commandbutton within w_informacion 

end type


event clicked;Close(Parent)

end event

        */

        /* SRW.XAML original
﻿<pbwpf:Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="w_informacion" x:ClassModifier="internal" PBHeight="2476" PBWidth="2496">
	<Canvas>
			<pbwpf:Rectangle Name="r_1" FillColor="81324524" LineThickness="1" PBHeight="2180" PBWidth="2363" X="55" Y="28">
			</pbwpf:Rectangle>
			<pbwpf:StaticText Name="st_3" Alignment="center" BackColor="81324524" Border="true" FaceName="Arial" FocusRectangle="false" FontCharSet="ansi" FontPitch="variable" PBFontFamily="swiss" PBHeight="76" PBWidth="1303" Text="Diseño y programación: www.ilconsulting.com.ar" TextColor="8388608" TextSize="-9" Weight="700" X="1079" Y="2088">
			</pbwpf:StaticText>
			<pbwpf:StaticText Name="st_2" Alignment="center" BackColor="81324524" Border="true" FaceName="Arial" FocusRectangle="false" FontCharSet="ansi" FontPitch="variable" PBFontFamily="swiss" PBHeight="76" PBWidth="1303" Text="Copyright: Angel Oscar Minotti" TextColor="8388608" TextSize="-9" Weight="700" X="1079" Y="1996">
			</pbwpf:StaticText>
			<pbwpf:StaticText Name="st_1" Alignment="center" BackColor="81324524" Border="true" FaceName="Arial" FocusRectangle="false" FontCharSet="ansi" FontPitch="variable" PBFontFamily="swiss" PBHeight="76" PBWidth="960" Text="Visite: www.minottimaster.com" TextColor="8388608" TextSize="-9" Weight="700" X="105" Y="1996">
			</pbwpf:StaticText>
			<pbwpf:StaticText Name="st_4" Alignment="center" BackColor="81324524" Border="true" FaceName="Arial" FocusRectangle="false" FontCharSet="ansi" FontPitch="variable" PBFontFamily="swiss" PBHeight="76" PBWidth="960" Text="Programa Protegido" TextColor="8388608" TextSize="-9" Weight="700" X="105" Y="2088">
			</pbwpf:StaticText>
			<pbwpf:Picture Name="p_logo" BringToTop="true" FocusRectangle="false" PBHeight="1940" PBWidth="2053" PictureName="tapa1.bmp" X="210" Y="36">
			</pbwpf:Picture>
			<pbwpf:CommandButton Name="cb_1" BringToTop="true" FaceName="Arial" FontPitch="variable" PBFontFamily="swiss" PBHeight="108" PBWidth="256" TabOrder="10" Text="_Cerrar" TextSize="-10" Weight="400" X="2153" Y="2220">
			</pbwpf:CommandButton>
	</Canvas>
</pbwpf:Window>
        */
    }
}