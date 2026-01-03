using Minotti.Views.Basicos.Models;
using MinottiApp.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Reportes.Controls
{
    // global type cat_preview_tab from nonvisualobject autoinstantiate
    public class cat_preview_tab : nonvisualobject
    {
        // type variables
        /* La ventana recibe el DS y los parametros 
            para hacerle el retrieve */
        public string? is_impresion;
        public string[] is_parametros = Array.Empty<string>();

        // on cat_preview_tab.create
        public cat_preview_tab()
            : base()
        {
            // PB: TriggerEvent( this, "constructor" )
            DynamicEventInvoker.Trigger(this, "constructor");
        }

        // on cat_preview_tab.destroy
        public  virtual void Dispose()
        {
            // PB: TriggerEvent( this, "destructor" )
            DynamicEventInvoker.Trigger(this, "destructor");
            //ase.Dispose();
        }
    }
}
