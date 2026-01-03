using System;
using System.Windows.Forms;

namespace Minotti
{
    public partial class w_migracion_capitulos2
    {
        private void WirePowerBuilderEvents()
        {
            this.Load += (s,e) => ue_iniciar();
        }

        // PB original:
        /*
call super::ue_leer_parametros;cat_usuario at_usuario
integer iAux, niveles
string param

/* Crea los niveles de menú requeridos */
niveles = 4
s_nvl[1].Dw = Create DataStore
s_nvl[1].Titulo = 'Capitulos'
s_nvl[1].Dw.DataObject = 'dk_capitulos_treeview'
s_nvl[1].Dw.SetTransObject(SQLCA)
s_nvl[1].Activo = 1
s_nvl[1].Dw.Retrieve()

s_nvl[2].Dw = Create DataStore
s_nvl[2].Titulo = 'Capitulos'
s_nvl[2].Dw.DataObject = 'dk_capitulaciones_treeview'
s_nvl[2].Dw.SetTransObject(SQLCA)
s_nvl[2].Activo = 1
s_nvl[2].Dw.Retrieve()

s_nvl[3].Dw = Create DataStore
s_nvl[3].Titulo = 'Capitulos'
s_nvl[3].Dw.DataObject = 'dk_rubricaciones'
s_nvl[3].Dw.SetTransObject(SQLCA)
s_nvl[3].Activo = 1
s_nvl[3].Dw.Retrieve()
        */
        public void ue_leer_parametros()
        {
            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
        }

        // PB original:
        /*
call super::close;Integer iAux
/* Destruye los Data Stores creados en el Open */
For iAux = 1 To UpperBound(s_nvl[])
	Destroy s_nvl[iAux].Dw
Next
If isValid(dw_param) Then Destroy dw_param
        */
        public void close()
        {
            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
        }

        // PB original:
        /*
call super::ue_ajustar_posicion;integer ancho_mdi, largo_mdi

This.X = 1
This.Y = 1

guo_app.uof_GetMdi().wf_GetAreaTrabajo(ancho_mdi, largo_mdi)

This.Width = ancho_mdi
This.Height = largo_mdi
        */
        public void ue_ajustar_posicion()
        {
            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
        }

        // PB original:
        /*
call super::ue_iniciar;This.Event Trigger ue_cargar_nivel(0)
        */
        public void ue_iniciar()
        {
            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
        }

        // PB original:
        /*
SetPointer(HourGlass!)
Parent.Event Trigger ue_cargar_nivel(handle)
        */
        public void itempopulate()
        {
            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
        }
    }
}
