using System;
using System.Windows.Forms;

namespace Minotti
{
    public partial class w_splash : Form
    {
        public w_splash() => InitializeComponent();

        /* SRW original
﻿forward
global type w_splash from w_principal
end type
type st_4 from statictext within w_splash
end type
type st_1 from statictext within w_splash
end type
type st_3 from statictext within w_splash
end type
type st_2 from statictext within w_splash
end type
type gb_borde from groupbox within w_splash
end type
type st_nombre from statictext within w_splash
end type
type st_version from statictext within w_splash
end type
type st_copyright from statictext within w_splash
end type
type p_logo from picture within w_splash
end type
end forward


global type w_splash from w_principal 

st_4 st_4 
st_1 st_1 
st_3 st_3 
st_2 st_2 
gb_borde gb_borde 
st_nombre st_nombre 
st_version st_version 
st_copyright st_copyright 
p_logo p_logo 
end type


global w_splash w_splash

type variables

end variables

event open;call super::open;cat_splash		at_splash


/* Centra la ventana de splah */
//environment env
//real Y_desviacion = 1 //0.6      // porcentaje desvianción de la pantalla en y
//real X_desviacion = 1      // porcentaje desvianción de la pantalla en X
//If GetEnvironment(env) = 1 Then
//	this.x = int ((PixelsToUnits(env.ScreenWidth, XPixelsToUnits!)	- this.Width) / 2 * X_desviacion)
//	this.y = int ((PixelsToUnits(env.ScreenHeight, YPixelsToUnits!)	- this.Height) / 2 * Y_desviacion)
//End If 

////this.wf_centrar()


///* Recibe los parámetros necesarios */
//at_splash = Message.PowerObjectParm

///* Carga el Nombre de la Aplicación, la Versión, el Logo, el Copyright */
//st_nombre.Text = at_splash.Nombre
//st_version.Text = "Versión: " + at_splash.Version
//p_logo.PictureName = at_splash.Logo
//st_copyright.Text = at_splash.Copyright

///* Fija el tiempo en el que se cerrará la ventana */
//Timer(4)// (at_splash.segundos)

///* Posiciona la ventana */
//this.SetPosition (TopMost!)
//gb_borde.SetPosition(ToBottom!)


///* Centra la ventana de splah */

//end event

//on w_splash.create
//int iCurrent
//call super::create
//this.st_4=create st_4
//this.st_1=create st_1
//this.st_3=create st_3
//this.st_2=create st_2
//this.gb_borde=create gb_borde
//this.st_nombre=create st_nombre
//this.st_version=create st_version
//this.st_copyright=create st_copyright
//this.p_logo=create p_logo
//iCurrent=UpperBound(this.Control)
//this.Control[iCurrent+1]=this.st_4
//this.Control[iCurrent+2]=this.st_1
//this.Control[iCurrent+3]=this.st_3
//this.Control[iCurrent+4]=this.st_2
//this.Control[iCurrent+5]=this.gb_borde
//this.Control[iCurrent+6]=this.st_nombre
//this.Control[iCurrent+7]=this.st_version
//this.Control[iCurrent+8]=this.st_copyright
//this.Control[iCurrent+9]=this.p_logo
//end on

//on w_splash.destroy
//call super::destroy
//destroy(this.st_4)
//destroy(this.st_1)
//destroy(this.st_3)
//destroy(this.st_2)
//destroy(this.gb_borde)
//destroy(this.st_nombre)
//destroy(this.st_version)
//destroy(this.st_copyright)
//destroy(this.p_logo)
//end on

//event timer;call super::timer;Timer (0)
//Close (this)

//end event

//type st_4 from statictext within w_splash 

//end type



//type st_1 from statictext within w_splash 

//end type



//type st_3 from statictext within w_splash 

//end type



//type st_2 from statictext within w_splash 

//end type



//type gb_borde from groupbox within w_splash 

//end type



//type st_nombre from statictext within w_splash 

//end type



//type st_version from statictext within w_splash 

//end type



//type st_copyright from statictext within w_splash 

//end type



//type p_logo from picture within w_splash 

//end type


      //  */

        /* SRW.XAML original
﻿<pbwpf:Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="w_splash" x:ClassModifier="internal" BackColor="15793151" Background="#fffffbf0" PBHeight="2364" PBWidth="2418" X="59" Y="48">
	<Canvas>
			<pbwpf:GroupBox Name="gb_borde" BackColor="81324524" FaceName="Arial" FontPitch="variable" PBFontFamily="swiss" PBHeight="2200" PBWidth="2345" TabOrder="1" TextSize="-10" Weight="400" X="5">
				<Canvas>
				</Canvas>
			</pbwpf:GroupBox>
			<pbwpf:StaticText Name="st_2" Alignment="center" BackColor="81324524" Border="true" FaceName="Arial" FocusRectangle="false" FontCharSet="ansi" FontPitch="variable" PBFontFamily="swiss" PBHeight="76" PBWidth="1312" Text="Copyright: Angel Oscar Minotti" TextColor="8388608" TextSize="-9" Weight="700" X="997" Y="1996">
			</pbwpf:StaticText>
			<pbwpf:StaticText Name="st_3" Alignment="center" BackColor="81324524" Border="true" FaceName="Arial" FocusRectangle="false" FontCharSet="ansi" FontPitch="variable" PBFontFamily="swiss" PBHeight="76" PBWidth="1312" Text="Diseño y programación: www.ilconsulting.com.ar" TextColor="8388608" TextSize="-9" Weight="700" X="997" Y="2088">
			</pbwpf:StaticText>
			<pbwpf:StaticText Name="st_1" Alignment="center" BackColor="81324524" Border="true" FaceName="Arial" FocusRectangle="false" FontCharSet="ansi" FontPitch="variable" PBFontFamily="swiss" PBHeight="76" PBWidth="933" Text="Visite: www.minottimaster.com" TextColor="8388608" TextSize="-9" Weight="700" X="50" Y="1996">
			</pbwpf:StaticText>
			<pbwpf:StaticText Name="st_4" Alignment="center" BackColor="81324524" Border="true" FaceName="Arial" FocusRectangle="false" FontCharSet="ansi" FontPitch="variable" PBFontFamily="swiss" PBHeight="76" PBWidth="933" Text="Programa Protegido" TextColor="8388608" TextSize="-9" Weight="700" X="50" Y="2088">
			</pbwpf:StaticText>
			<pbwpf:StaticText Name="st_nombre" Alignment="center" BackColor="12632256" BringToTop="true" Enabled="false" FaceName="Arial Narrow" FocusRectangle="false" FontPitch="variable" PBFontFamily="swiss" PBHeight="100" PBWidth="1079" TextSize="-14" Visible="false" Weight="700" X="64" Y="1992">
			</pbwpf:StaticText>
			<pbwpf:StaticText Name="st_version" Alignment="center" BackColor="12632256" BringToTop="true" Enabled="false" FaceName="Arial" FocusRectangle="false" FontPitch="variable" PBFontFamily="swiss" PBHeight="88" PBWidth="1106" TextSize="-12" Visible="false" Weight="400" X="1175" Y="1992">
			</pbwpf:StaticText>
			<pbwpf:StaticText Name="st_copyright" Alignment="right" BackColor="12632256" BringToTop="true" Enabled="false" FaceName="Arial" FocusRectangle="false" FontPitch="variable" PBFontFamily="swiss" PBHeight="72" PBWidth="1143" TextSize="-9" Visible="false" Weight="400" X="1161" Y="2124">
			</pbwpf:StaticText>
			<pbwpf:Picture Name="p_logo" BringToTop="true" FocusRectangle="false" PBHeight="1896" PBWidth="2290" PictureName="tapa1.bmp" X="27" Y="52">
			</pbwpf:Picture>
	</Canvas>
</pbwpf:Window>
        */
    }
}