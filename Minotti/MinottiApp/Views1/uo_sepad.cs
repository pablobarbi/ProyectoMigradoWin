using System;
using System.Windows.Forms;

namespace Minotti
{
    public partial class uo_sepad : UserControl
    {
        public uo_sepad() => InitializeComponent();

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "uo_sepad";
            this.AutoScaleMode = AutoScaleMode.None;
            this.ResumeLayout(false);
        }

        /* SRU original
﻿forward
global type uo_sepad from uo_app
end type
end forward


global type uo_sepad from uo_app 
end type

global uo_sepad uo_sepad

type variables
String helpactivo
String directoriodelhelp
String ejecutabledelhelp


end variables

on uo_sepad.create
call super::create
end on

on uo_sepad.destroy
call super::destroy
end on

event ue_cargar_datos_app;call super::ue_cargar_datos_app;String ls_Hoy

ls_Hoy = "Release 2024.01.15"

/* Define algunos atributos de la aplicación */
//App.DisplayName = "Minotti 2024"
//This.ArcInicio  = "minotti.ini"
//This.Version    = ls_Hoy
//This.Logo       = "tapa1.bmp"//"2_256.bmp"
////This.Logo       = "Sepad.bmp"
//This.Copyright  = "El siguiente programa se encuentra protegido por las leyes de derecho de autor."
//This.ventana_coneccion = "w_coneccion_sepad"
//This.motor_db   = "SQL Anywhere"

//end event

        //*/
    }
}