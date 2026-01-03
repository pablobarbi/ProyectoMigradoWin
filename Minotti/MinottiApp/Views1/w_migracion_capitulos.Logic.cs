using System;
using System.Windows.Forms;

namespace Minotti
{
    public partial class w_migracion_capitulos
    {
        private void WirePowerBuilderEvents()
        {
            this.Load += (s,e) => ue_iniciar();
        }

        // PB original:
        /*
call super::ue_leer_parametros;/* CAPITULOS */
dw_1.uof_SetDataObject('dk_capitulos')
dw_1.SetTransObject(SQLCA)
dw_1.uof_marcar_seleccion(1)
dw_1.Border = TRUE
dw_1.BorderStyle=StyleLowered!
dw_1.cant_filas = 5

/* CAPITULACIONES */
dw_2.uof_SetDataObject('dk_rubricas_del_capitulo')
dw_2.SetTransObject(SQLCA)
dw_2.uof_marcar_seleccion(1)
dw_2.Border = TRUE
dw_2.BorderStyle=StyleLowered!
dw_2.cant_filas = 5

/* RUBRICACIONES */
dw_3.uof_SetDataObject('dk_subrubricas_de_la_rubrica')
dw_3.SetTransObject(SQLCA)
dw_3.uof_marcar_seleccion(1)
dw_3.Border = TRUE
dw_3.BorderStyle=StyleLowered!
dw_3.cant_filas = 3
        */
        public void ue_leer_parametros()
        {
            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
        }

        // PB original:
        /*
call super::ue_iniciar;String ls_Param[]

// recupero capitulos.
dw_1.uof_Retrieve(ls_Param)
        */
        public void ue_iniciar()
        {
            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
        }
    }
}
