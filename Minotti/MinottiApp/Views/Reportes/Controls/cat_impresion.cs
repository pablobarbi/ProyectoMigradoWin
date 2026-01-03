using Minotti.Views.Basicos.Models;
using MinottiApp.utils;

namespace Minotti.Views.Reportes.Controls
{
    // global type cat_impresion from nonvisualobject autoinstantiate
    public class cat_impresion : nonvisualobject
    {
        // type variables
        /* Usado para pasar los parametros a la ventana de Impresion de Actas, etc..*/
        public uo_ds? ids_impresion;                 /* Datastore que contiene el reporte a imprimir. */
        public int ii_cantidad_impresiones = 0;      /* Cantidad de copias */


        

        // on cat_impresion.create
        public cat_impresion()
            : base()
        {
            // PB: TriggerEvent( this, "constructor" )
            DynamicEventInvoker.Trigger(this, "constructor");
        }

        // on cat_impresion.destroy
        // En C# no hay "destroy" como PB; implemento Dispose para respetar destructor lógico.
        // OJO: esto NO es Designer, así que no duplica Dispose.
        public virtual void Dispose()
        {
            // PB: TriggerEvent( this, "destructor" )
            DynamicEventInvoker.Trigger(this, "destructor");
            //base.Dispose();
        }

        // PB destroy event emulation
        public virtual void OnDestroy()
        {
            DynamicEventInvoker.Trigger(this, "destructor");
        }

    }
}
