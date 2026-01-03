 

using System;
using System.Windows.Forms;
using Minotti.Controls;

namespace Minotti
{
    /// <summary>
    /// Migración de PowerBuilder:
    /// global type uo_dw_cros from uo_dw
    /// public subroutine uof_imprimir(); This.Print() end subroutine
    /// </summary>
    public partial class uo_dw_cros : uo_dw
    {
        public uo_dw_cros()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Equivalente directo de uof_imprimir() en PowerBuilder.
        /// </summary>
        public void uof_imprimir()
        {
            // En PB: This.Print()
            // Aquí asumimos que uo_dw implementa Print() o que lo vas a agregar allí.

            //TODO: Descomentar cuando uo_dw tenga el método Print().
            //this.Print();
        }
    }
}











//namespace Minotti
//{
//    public class uo_dw_cros : UserControl
//    {
//        private bool _initialized;

//        public uo_dw_cros() => InitializeComponent();

//        private void InitializeComponent()
//        {
//            _initialized = true;
//        }

//        public void BindDataWindowLikeBehavior()
//        {
//            throw new NotImplementedException("Completar mapeo 1:1 del UserObject 'uo_dw_cros' desde el .sru (sin cambiar nombres).");
//        }

//        /* SRU original embebido
//﻿forward
//global type uo_dw_cros from uo_dw
//end type
//end forward


//global type uo_dw_cros from uo_dw 
//end type

//global uo_dw_cros uo_dw_cros

//forward prototypes
//public subroutine uof_imprimir ()
//end prototypes

//public subroutine uof_imprimir ();This.Print()
//end subroutine

//        */
//    }
//}