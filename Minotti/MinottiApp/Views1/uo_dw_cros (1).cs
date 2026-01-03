using System;
using System.Windows.Forms;

namespace Minotti
{
    public partial class uo_dw_cros : UserControl
    {
        public uo_dw_cros() => InitializeComponent();

        public void BindDataWindowLikeBehavior()
        {
            // TODO: Mapear eventos/métodos del SRU 1:1 (sin cambiar nombres).
        }

        /* SRU original
﻿forward
global type uo_dw_cros from uo_dw
end type
end forward


global type uo_dw_cros from uo_dw 
end type

global uo_dw_cros uo_dw_cros

forward prototypes
public subroutine uof_imprimir ()
end prototypes

public subroutine uof_imprimir ();This.Print()
end subroutine

        */

        /* SRU.XAML original
﻿<pbwpf:DataWindow xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="uo_dw_cros" x:ClassModifier="internal">
</pbwpf:DataWindow>
        */
    }
}