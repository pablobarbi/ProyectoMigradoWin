using System;
using System.Windows.Forms;

namespace Minotti
{
    //    public partial class w_carga_medicamentos
    //    {
    //        private void WirePowerBuilderEvents()
    //        {
    //            this.Load += (s,e) => ue_iniciar();
    //        }

    //        // PB original:

    //call super::ue_iniciar;Integer campos, i, row
    //Integer tope, iAux,tamaño, scroll, current_col, total_med
    //String	col, ult_campo, nombre, argumentos[]


    //is_TipoUpdate = astp_w_seleccion.parametros[1]
    //argumentos[1] = astp_w_seleccion.parametros[2]
    //argumentos[2] = astp_w_seleccion.parametros[3]
    //dw_1.uof_Retrieve(argumentos)


    //campos = UpperBound(astp_w_seleccion.parametros[])

    ///* Inserto los valores de los campos en la Fila de la Dw */
    //For i = 1 to campos
    //	If Not IsNull(astp_w_seleccion.parametros[i]) Then dw_1.uof_SetItem(row,i,astp_w_seleccion.parametros[i])
    //Next



    ////Integer	tope, iAux,tamaño, scroll, current_col
    ////String	col, ult_campo, nombre


    ///* Inserto una Fila en la dw */
    //If dw_buscar.RowCount() <= 0 Then dw_buscar.InsertRow(0)

    //	If NOT ib_modificar_dw_busqueda Then
    //		Tope = Integer(dw_buscar.Describe('DataWindow.Column.Count'))
    //		FOR iAux = 1 To Tope
    //			col = "#" + string(iAux)

    //			/* solo dejo visibles los campos que son del detalle */
    //			nombre = dw_buscar.Describe(col + ".Name")
    //			IF dw_buscar.Describe(nombre + ".Band") = "detail" THEN
    //				dw_buscar.Modify(col + ".Visible = 1")
    //			ELSE
    //				dw_buscar.Modify(col + ".Visible = 0")
    //			END IF

    //			IF dw_buscar.Describe(col + ".Visible") = '1' THEN
    //				/* Le saco la propiedad de Rectangulo en el foco */
    //				Choose Case Upper(dw_buscar.Describe(col + ".Edit.Style"))
    //					Case 'EDIT'
    //						dw_buscar.Modify(col + ".Edit.FocusRectangle=no")
    //					CASE 'DDDW'
    //						dw_buscar.Modify(col + ".dddw.FocusRectangle=no")
    //					CASE 'DDLB'
    //						dw_buscar.Modify(col + ".ddlb.FocusRectangle=no")
    //					CASE 'EDITMASK'
    //						dw_buscar.Modify(col + ".EditMask.FocusRectangle=no")
    //				End Choose
    //				/* Le Aplico un Borde a los Campos*/
    //	//			dw_buscar.Modify(col + ".Border='6'")  // Raised
    //				dw_buscar.Modify(col + ".Border='2'")  // Box
    //				dw_buscar.Modify(col + ".Protect='0'")
    //				dw_buscar.Modify(col + ".Background.Mode='0'")
    //				dw_buscar.Modify(col + ".Background.Color='" + is_back_color + "'")  // RGB(255,255,240)
    //				dw_buscar.Modify(col + ".Height.AutoSize=No")

    //		//		dw_buscar.Modify(col + ".Background.Color = '16777215'")  // RGB(255,255,255) Blanco
    //		//		dw_buscar.Modify(col + ".TabSequence=" )
    //		//		dw_buscar.Modify(col + ".Font.Weight = '400'")
    //		//		dw_buscar.Modify(col + ".Font.Height = '-9'")

    //		End If
    //	Next
    //End If

    //If Not ib_modificar_dw_busqueda Then
    //	/* Modifico el tamaño del ultimo campo */
    //	ult_campo = dw_buscar.uof_ultimo_campo_visible()
    //	tamaño = integer ( dw_buscar.Describe( ult_campo + ".Width ") )
    //	scroll = dw_1.width - integer ( dw_buscar.Describe( ult_campo + ".X ") ) - &
    //				tamaño 
    //	tamaño = tamaño + scroll - 5
    //	dw_buscar.Modify( ult_campo + ".Width= " + string(tamaño) )

    //	/* Setea el orden de los Campos en el orden en que aparecen los campos en la dw */
    //	current_col = dw_buscar.wf_settaborder_campos_visibles()
    //	if current_col > 0 Then dw_buscar.SetColumn(current_col)

    //	ib_modificar_dw_busqueda = TRUE
    //End If

    ///* Recupero la cantidad de Filas */
    //il_q_filas = dw_1.RowCount()

    //// MODIFICO EL TITULO DE LA VENTANA PARA QUE MUESTRE LA CANTIDAD DE MEDICAMENTOS SELECCIONADOS.
    //total_med = wf_medicamentos_seleccionados()
    //This.Title = "Seleccione los medicamentos para la rubrica - Seleccionados: " + String(total_med)

    ///* Seteo el foco el la dw de busqueda */
    //dw_buscar.SetFocus()
    //        */
    //        public void ue_iniciar()
    //        {
    //            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
    //        }

    //        // PB original:
    //        /*
    //call super::ue_leer_parametros;// ------------------------------------------------------------------------------------
    //// Inserto un fila en blanco a la dw de busqueda de la descripcion
    //// ------------------------------------------------------------------------------------
    //dw_buscar.uof_SetDataObject(dw_1.DataObject)
    //dw_buscar.SetTransObject(SQLCA)
    //dw_buscar.cant_filas = 1
    ///* Solo dejo ver el Detalle, y doy el color a la DataWindow */
    //dw_buscar.Modify("Datawindow.Header.Height=0")
    //dw_buscar.Modify("Datawindow.Footer.Height=0")
    //dw_buscar.Modify("Datawindow.Summary.Height=0")
    //dw_buscar.Modify("Datawindow.Color=" + String(This.BackColor))
    //        */
    //        public void ue_leer_parametros()
    //        {
    //            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
    //        }

    //        // PB original:
    //        /*
    //call super::ue_dw_itemchanged;integer size, resp
    //string item, condicion
    //long	 ll_row

    //If arg_objeto <> dw_buscar Then Return 0

    ///* Si esta en una DropDownDatawindow */
    //IF Upper(dw_buscar.Describe("#" + String(dw_buscar.GetColumn()) + ".Edit.Style")) = 'DDDW' or &
    //   Upper(dw_buscar.Describe("#" + String(dw_buscar.GetColumn()) + ".Edit.Style")) = 'DDLB' Then

    // item = dw_buscar.gettext()
    // size = len (item)

    // if size > 0 then 
    //	CHOOSE CASE dw_buscar.at_col[dw_buscar.GetColumn()].Tipo
    //		CASE 'char('
    //      	condicion = "Left("+ dwo.name +"," + string(size) + ")= '" + item + "'"
    //		CASE 'long', 'numbe','real','decim'
    //			if Not IsNumber(item) Then Return 0
    //      	condicion = dwo.name + "= " + item 

    //		CASE 'date','datet','time'
    //	     	condicion = dwo.name + "= " + item

    ////		CASE 'date'
    ////			if Not IsDate(item) Then Return 0
    ////	     	condicion = dwo.name + "= " + item
    ////		CASE 'datet'
    ////			if Not IsDate(item) and not IsTime(item) Then Return 0
    ////      	condicion = dwo.name + "= " + item
    ////		CASE 'time'
    ////			if Not IsTime(item) Then Return 0
    ////      	condicion = dwo.name + "= " + item
    //		CASE ELSE
    //			Return 0
    //	END CHOOSE

    //   Setpointer(hourglass!)
    //	ll_row     = dw_1.Find (condicion, 1, il_q_filas)
    //	if ll_row <> 0 then 
    //		resp = dw_1.selectrow(0,false)		
    //		resp = dw_1.selectrow(ll_row,true)	
    //		resp = dw_1.scrolltorow(ll_row)		
    //	End if
    //   Setpointer(Arrow!)
    //  End if
    //End If

    //Return 0
    //        */
    //        public void ue_dw_itemchanged()
    //        {
    //            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
    //        }

    //        // PB original:
    //        /*
    //integer espacio_botones, borde_boton

    ///* Le doy tamaño a la datawindow */
    //dw_1.Height = dw_1.uof_largo()
    //dw_1.Width = dw_1.uof_ancho()
    //dw_1.Y = s_esp.borde
    //dw_1.X = s_esp.borde

    ///* Acomodo la dw busqueda */
    //dw_buscar.Height = dw_buscar.uof_largo()
    //dw_buscar.Width  = dw_1.Width
    //dw_buscar.X = dw_1.X
    //dw_buscar.Y = dw_1.Y + dw_1.Height + s_esp.borde

    ///* Le doy tamaño a la ventana */
    //This.Height = dw_1.uof_largo() + dw_buscar.uof_largo() + 4 * s_esp.borde + pb_cancelar.Height + s_esp.largo
    //This.Width = Max( dw_1.Width ,pb_cancelar.Width * 2 + s_esp.borde ) + 2 * s_esp.borde + s_esp.ancho

    ///* Acomodo los botones */
    //pb_cancelar.Y = dw_buscar.Y + dw_buscar.Height + s_esp.borde
    //pb_continuar.Y = pb_cancelar.Y

    //espacio_botones = Int( (This.Width - pb_cancelar.Width * 2 - s_esp.borde) / 2)


    //borde_boton = Int ( espacio_botones * 0.6) 
    //pb_continuar.X = borde_boton
    //pb_cancelar.X = this.Width - borde_boton - pb_cancelar.width


    //This.wf_centrar_response()
    //        */
    //        public void ue_acomodar_objetos()
    //        {
    //            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
    //        }

    //        // PB original:
    //        /*
    //Integer  cantidad, i
    //uo_ds    ds_medicacion
    //Long     ll_Rtn, ll_Capitulo, ll_Rubrica, ll_Fila, ll_SubRubrica
    //Long     ll_Medicamentos, ll_Valor, ll_FilaMod, ll_SubRubricaPadre, ll_SubRubricaHija
    //String   ls_Argumentos[], ls_Medicamento, ls_Filtro


    //if dw_1.AcceptText() < 0 Then Return

    //astr_w_seleccion.opcion = 1

    ///* Obtengo los valores de:
    //   1) si es un objeto uo_dw devuelve los valores de los campos clave
    //	2) si es un objeto uo_dw_filtro devuelve los valores de todos los campos
    //*/
    //dw_1.uof_GetArgumentos(astr_w_seleccion.s_det[],dw_1.GetRow())

    //IF is_TipoUpdate = "CAPITULACION" THEN

    //	ll_Capitulo = Long(astp_w_seleccion.parametros[2])
    //	ll_Rubrica  = Long(astp_w_seleccion.parametros[3])
    //	ls_Argumentos[1] = astp_w_seleccion.parametros[2]
    //	ls_Argumentos[2] = astp_w_seleccion.parametros[3]

    //	// Cargo el DSTO de la rubrica.
    //	ds_medicacion = CREATE USING 'uo_ds'
    //	ds_medicacion.uof_SetDataObject('dsto_actualiza_capitulacion_med')
    //	ds_medicacion.SetTransObject(SQLCA)
    //	ds_medicacion.uof_Retrieve(ls_Argumentos)

    //	FOR ll_Medicamentos = 1 TO dw_1.RowCount()

    //		ls_Medicamento = dw_1.GetItemString( ll_Medicamentos, "medicamento")
    //		ll_Valor = dw_1.GetItemNumber( ll_Medicamentos, "valor")
    //		IF (ll_Valor = 1) OR (ll_Valor = 2) OR (ll_Valor = 3) THEN
    //			ls_Filtro = 'medicamento = "' + ls_Medicamento + '"' 
    //			ll_FilaMod = ds_medicacion.Find(ls_Filtro, 1, ds_medicacion.RowCount())
    //			IF ll_FilaMod > 0 THEN
    //				ds_medicacion.SetItem( ll_FilaMod, 'valor', ll_Valor)
    //			ELSE
    //				ll_Fila = ds_medicacion.InsertRow(0)
    //				ds_medicacion.SetItem( ll_Fila, 'capitulo', ll_Capitulo)
    //				ds_medicacion.SetItem( ll_Fila, 'rubrica', ll_Rubrica)
    //				ds_medicacion.SetItem( ll_Fila, 'medicamento', ls_Medicamento)
    //				ds_medicacion.SetItem( ll_Fila, 'valor', ll_Valor)
    //			END IF
    //		END IF
    //		IF (ll_Valor = 0) THEN
    //			ls_Filtro = 'medicamento = "' + ls_Medicamento + '"' 
    //			ll_FilaMod = ds_medicacion.Find(ls_Filtro, 1, ds_medicacion.RowCount())
    //			IF ll_FilaMod > 0 THEN
    //				ds_medicacion.DeleteRow(ll_FilaMod)
    //			END IF			
    //		END IF
    //	NEXT

    //	/* grabo los medicamentos */
    //	ds_medicacion.AcceptText()
    //	ds_medicacion.Update()

    //ELSEIF is_TipoUpdate = "RUBRICACION" THEN

    //	ll_Rubrica    = Long(astp_w_seleccion.parametros[2])
    //	ll_SubRubrica = Long(astp_w_seleccion.parametros[3])
    //	ls_Argumentos[1] = astp_w_seleccion.parametros[2]
    //	ls_Argumentos[2] = astp_w_seleccion.parametros[3]

    //	// Cargo el DSTO de la rubrica.
    //	ds_medicacion = CREATE USING 'uo_ds'
    //	ds_medicacion.uof_SetDataObject('dsto_actualiza_rubricacion_med')
    //	ds_medicacion.SetTransObject(SQLCA)
    //	ds_medicacion.uof_Retrieve(ls_Argumentos)


    //	FOR ll_Medicamentos = 1 TO dw_1.RowCount()

    //		ls_Medicamento = dw_1.GetItemString( ll_Medicamentos, "medicamento")
    //		ll_Valor = dw_1.GetItemNumber( ll_Medicamentos, "valor")
    //		IF (ll_Valor = 1) OR (ll_Valor = 2) OR (ll_Valor = 3) THEN
    //			ls_Filtro = 'medicamento = "' + ls_Medicamento + '"' 
    //			ll_FilaMod = ds_medicacion.Find(ls_Filtro, 1, ds_medicacion.RowCount())
    //			IF ll_FilaMod > 0 THEN
    //				ds_medicacion.SetItem( ll_FilaMod, 'valor', ll_Valor)
    //			ELSE
    //				ll_Fila = ds_medicacion.InsertRow(0)
    //				ds_medicacion.SetItem( ll_Fila, 'rubrica', ll_Rubrica)
    //				ds_medicacion.SetItem( ll_Fila, 'subrubrica', ll_SubRubrica)
    //				ds_medicacion.SetItem( ll_Fila, 'medicamento', ls_Medicamento)
    //				ds_medicacion.SetItem( ll_Fila, 'valor', ll_Valor)
    //			END IF
    //		END IF
    //		IF (ll_Valor = 0) THEN
    //			ls_Filtro = 'medicamento = "' + ls_Medicamento + '"' 
    //			ll_FilaMod = ds_medicacion.Find(ls_Filtro, 1, ds_medicacion.RowCount())
    //			IF ll_FilaMod > 0 THEN
    //				ds_medicacion.DeleteRow(ll_FilaMod)
    //			END IF			
    //		END IF
    //	NEXT

    //	/* grabo los medicamentos */
    //	ds_medicacion.AcceptText()
    //	ds_medicacion.Update()

    //ELSEIF is_TipoUpdate = "SUBRUBRICACION" THEN

    //	ll_SubRubricaPadre = Long(astp_w_seleccion.parametros[2])
    //	ll_SubRubricaHija  = Long(astp_w_seleccion.parametros[3])
    //	ls_Argumentos[1] = astp_w_seleccion.parametros[2]
    //	ls_Argumentos[2] = astp_w_seleccion.parametros[3]

    //	// Cargo el DSTO de la rubrica.
    //	ds_medicacion = CREATE USING 'uo_ds'
    //	ds_medicacion.uof_SetDataObject('dsto_actualiza_subrubricacion_med')
    //	ds_medicacion.SetTransObject(SQLCA)
    //	ds_medicacion.uof_Retrieve(ls_Argumentos)


    //	FOR ll_Medicamentos = 1 TO dw_1.RowCount()

    //		ls_Medicamento = dw_1.GetItemString( ll_Medicamentos, "medicamento")
    //		ll_Valor = dw_1.GetItemNumber( ll_Medicamentos, "valor")
    //		IF (ll_Valor = 1) OR (ll_Valor = 2) OR (ll_Valor = 3) THEN
    //			ls_Filtro = 'medicamento = "' + ls_Medicamento + '"' 
    //			ll_FilaMod = ds_medicacion.Find(ls_Filtro, 1, ds_medicacion.RowCount())
    //			IF ll_FilaMod > 0 THEN
    //				ds_medicacion.SetItem( ll_FilaMod, 'valor', ll_Valor)
    //			ELSE
    //				ll_Fila = ds_medicacion.InsertRow(0)
    //				ds_medicacion.SetItem( ll_Fila, 'subrubrica_padre', ll_SubRubricaPadre)
    //				ds_medicacion.SetItem( ll_Fila, 'subrubrica_hija', ll_SubRubricaHija)
    //				ds_medicacion.SetItem( ll_Fila, 'medicamento', ls_Medicamento)
    //				ds_medicacion.SetItem( ll_Fila, 'valor', ll_Valor)
    //			END IF
    //		END IF
    //		IF (ll_Valor = 0) THEN
    //			ls_Filtro = 'medicamento = "' + ls_Medicamento + '"' 
    //			ll_FilaMod = ds_medicacion.Find(ls_Filtro, 1, ds_medicacion.RowCount())
    //			IF ll_FilaMod > 0 THEN
    //				ds_medicacion.DeleteRow(ll_FilaMod)
    //			END IF			
    //		END IF
    //	NEXT

    //	/* grabo los medicamentos */
    //	ds_medicacion.AcceptText()
    //	ds_medicacion.Update()


    //ELSE
    //	/* HAY QUE VER ESTE ESPACIO PARA LA OPCION DE SUBRUBRICAS DEL 4 AL 10 */

    //END IF


    //// cierro la ventana.
    //Close(This)
    //        */
    //        public void ue_continuar()
    //        {
    //            // Traducción directa conocida: cierre de la ventana
    //            this.Close();
    //        }

    //        // PB original:
    //        /*
    //call super::editchanged;integer size, resp
    //string item, condicion, mascara
    //long	 ll_row

    //item = data
    //size = len (item)

    //SetNull(condicion)
    //if size > 0 then 

    ////	CHOOSE CASE Upper(This.Describe("#" + String(This.GetColumn()) + ".Style"))
    ////		Case "DDLB","EDITMASK"
    ////MESSAGEBOX("FORMATO",This.Describe("#" + String(This.GetColumn()) + ".EditMask.Mask"))


    //	CHOOSE CASE This.at_col[This.GetColumn()].Tipo
    //		CASE 'char('
    //      	condicion = "Left("+ dwo.name +"," + string(size) + ")= '" + item + "'"
    //		CASE 'long', 'numbe','real','decim'
    //			if Not IsNumber(item) Then Return
    //      	condicion = dwo.name + "= " + item 
    //		CASE ELSE
    //			Return
    //	END CHOOSE


    //If IsNull(condicion) Then Return
    //	Setpointer(hourglass!)
    //	ll_row     = dw_1.Find (condicion, 1, il_q_filas)
    //	if ll_row <> 0 then 
    //		resp = dw_1.selectrow(0,false)		
    //		resp = dw_1.selectrow(ll_row,true)	
    //		resp = dw_1.scrolltorow(ll_row)		
    //	end if
    //end if

    //Setpointer(Arrow!)
    //        */
    //        public void editchanged()
    //        {
    //            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
    //        }

    //        // PB original:
    //        /*
    //call super::itemchanged;integer size, resp
    //string item, condicion, tipo
    //long	 ll_row

    //item = data
    //size = len (item)

    //if size > 0 then 

    //	tipo = This.at_col[This.GetColumn()].Tipo
    //	If tipo = 'date' or tipo = 'datet' or tipo = 'time' Then
    //	   Setpointer(hourglass!)
    //  		condicion = dwo.name + " >= " + item

    //		ll_row     = dw_1.Find (condicion, 1, il_q_filas)
    //		if ll_row <> 0 then 
    //			resp = dw_1.selectrow(0,false)		
    //			resp = dw_1.selectrow(ll_row,true)	
    //			resp = dw_1.scrolltorow(ll_row)		
    //		end if
    //		Setpointer(Arrow!)
    //	end if
    //end If
    //        */
    //        public void itemchanged()
    //        {
    //            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
    //        }

    //        // PB original:
    //        /*
    //call super::itemfocuschanged;integer iAux
    //String  nulo

    //SetNull(nulo)
    //FOR iAux=1 TO Integer(This.Describe("DataWindow.Column.Count"))
    //	This.uof_SetItem(row,iAux,nulo)
    //NEXT
    //        */
    //        public void itemfocuschanged()
    //        {
    //            // TODO: trasladar cuerpo desde el comentario PB sin alterar nombres
    //        }
    //    }

















    // Traducción directa del bloque PB provisto (sin interpretar ni cambiar nombres).
    // Se incluyen stubs mínimos para que compile con los mismos nombres llamados en PB.


    public partial class w_abm_lista_pacientes : Form
    {
        // ====== CAMPOS/CONTROLES Y STUBS MINIMOS USADOS POR EL SCRIPT ======
        private string is_TipoUpdate;
        private int il_q_filas;
        private bool ib_modificar_dw_busqueda = false;
        private string is_back_color = "15794175";

        private readonly DataWindow dw_1 = new DataWindow();
        private readonly dw_buscar dw_buscar = new dw_buscar();

        private readonly PBButton pb_cancelar = new PBButton { Width = 120, Height = 32 };
        private readonly PBButton pb_continuar = new PBButton { Width = 120, Height = 32 };

        private static class s_esp { public static int borde = 8, ancho = 50, largo = 50; }

        // “globals” referenciados por PB
        private static readonly transaction SQLCA = new transaction();
        private static readonly astp_w_seleccion_t astp_w_seleccion = new astp_w_seleccion_t();
        private static readonly astr_w_seleccion_t astr_w_seleccion = new astr_w_seleccion_t();

        // DataWindow base (stub)
        private sealed class DataWindow
        {
            public int Width, Height, X, Y;
            public string DataObject { get; set; }

            public int uof_ancho() => 800;
            public int uof_largo() => 400;

            public string Describe(string expr) => "0";
            public void Modify(string expr) { }

            public int RowCount() => 0;
            public int InsertRow(int pos) => 1;

            public void SetColumn(int c) { }
            public void SetFocus() { }

            public long Find(string condicion, int from, int to) => 0;
            public int selectrow(long row, bool onoff) => 1;
            public int scrolltorow(long row) => 1;

            public void uof_Retrieve(string[] args) { }
            public void uof_SetItem(int row, int col, string value) { }
        }

        // dw_buscar (stub con las APIs usadas)
        private sealed class dw_buscar : uo_dw
        {
            public int cant_filas;
        }
        private class uo_dw
        {
            public int Width, Height, X, Y;
            public Dwo dwo = new Dwo();
            public ColInfo[] at_col = InitCols();

            private static ColInfo[] InitCols()
            {
                var a = new ColInfo[256];
                for (int i = 0; i < a.Length; i++) a[i] = new ColInfo();
                return a;
            }

            public virtual string Describe(string expr) => "0";
            public virtual void Modify(string expr) { }
            public virtual int RowCount() => 0;
            public virtual int InsertRow(int pos) => 1;
            public virtual int uof_largo() => 41;
            public virtual int GetColumn() => 1;
            public virtual string gettext() => null;

            public virtual void uof_SetDataObject(string name) { }
            public virtual void SetTransObject(transaction t) { }
            public virtual string uof_ultimo_campo_visible() => "#1";
            public virtual int wf_settaborder_campos_visibles() => 1;
            public virtual void SetColumn(int c) { }
            public virtual void SetFocus() { }
            public virtual void uof_SetItem(int row, int col, string value) { }
        }
        private sealed class Dwo { public string name = "col"; }
        private sealed class ColInfo { public string Tipo = "char("; }

        // Transacción mínima
        private sealed class transaction { }

        // Parametrización usada en el script
        private sealed class astp_w_seleccion_t
        {
            public PBParams parametros { get; } = new PBParams();
        }
        private sealed class astr_w_seleccion_t
        {
            public int opcion;
            public string[] s_det = Array.Empty<string>();
        }

        // Estructura de params 1-based
        private sealed class PBParams
        {
            private readonly string[] _arr = new string[16]; // espacio arbitrario
            public string this[int i] { get => _arr[i]; set => _arr[i] = value; }
            public int UpperBound() => _arr.Length - 1;
        }

        // Botón con coordenadas (para el layout PB)
        private sealed class PBButton
        {
            public int Width, Height, X, Y;
        }

        // Helpers PB-like
        private static void Setpointer(string _) { }
        private static bool IsNumber(string s) => double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        private static string String(int v) => v.ToString(CultureInfo.InvariantCulture);

        private int wf_medicamentos_seleccionados() => 0; // stub
        private void wf_centrar_response() { }           // stub
        private void wf_CentrarObjeto(object _) { }      // stub

        // =====================================================================
        // =============== MÉTODOS TRADUCIDOS DESDE EL PB ORIGINAL ==============
        // =====================================================================

        // Traducción directa del bloque “ue_iniciar” provisto
        public void ue_iniciar()
        {
            // call super::ue_iniciar; Integer campos, i, row
            int campos, i, row;
            int tope, iAux, tamaño, scroll, current_col, total_med;
            string col, ult_campo, nombre;
            string[] argumentos = new string[4]; // 1-based -> usamos [1..2]

            is_TipoUpdate = astp_w_seleccion.parametros[1];
            argumentos[1] = astp_w_seleccion.parametros[2];
            argumentos[2] = astp_w_seleccion.parametros[3];
            dw_1.uof_Retrieve(argumentos);

            campos = astp_w_seleccion.parametros.UpperBound();

            /* Inserto los valores de los campos en la Fila de la Dw */
            for (i = 1; i <= campos; i++)
            {
                var v = astp_w_seleccion.parametros[i];
                if (v != null) dw_1.uof_SetItem(row, i, v);
            }

            /* Inserto una Fila en la dw */
            if (dw_buscar.RowCount() <= 0) dw_buscar.InsertRow(0);

            if (!ib_modificar_dw_busqueda)
            {
                tope = Convert.ToInt32(dw_buscar.Describe("DataWindow.Column.Count"));
                for (iAux = 1; iAux <= tope; iAux++)
                {
                    col = "#" + iAux.ToString(CultureInfo.InvariantCulture);

                    /* solo dejo visibles los campos que son del detalle */
                    nombre = dw_buscar.Describe(col + ".Name");
                    if (dw_buscar.Describe(nombre + ".Band") == "detail")
                        dw_buscar.Modify(col + ".Visible = 1");
                    else
                        dw_buscar.Modify(col + ".Visible = 0");

                    if (dw_buscar.Describe(col + ".Visible") == "1")
                    {
                        /* Le saco la propiedad de Rectangulo en el foco */
                        var style = (dw_buscar.Describe(col + ".Edit.Style") ?? "").ToUpperInvariant();
                        switch (style)
                        {
                            case "EDIT":
                                dw_buscar.Modify(col + ".Edit.FocusRectangle=no");
                                break;
                            case "DDDW":
                                dw_buscar.Modify(col + ".dddw.FocusRectangle=no");
                                break;
                            case "DDLB":
                                dw_buscar.Modify(col + ".ddlb.FocusRectangle=no");
                                break;
                            case "EDITMASK":
                                dw_buscar.Modify(col + ".EditMask.FocusRectangle=no");
                                break;
                        }
                        /* Le Aplico un Borde a los Campos */
                        dw_buscar.Modify(col + ".Border='2'");  // Box
                        dw_buscar.Modify(col + ".Protect='0'");
                        dw_buscar.Modify(col + ".Background.Mode='0'");
                        dw_buscar.Modify(col + ".Background.Color='" + is_back_color + "'");
                        dw_buscar.Modify(col + ".Height.AutoSize=No");
                    }
                }
            }

            if (!ib_modificar_dw_busqueda)
            {
                /* Modifico el tamaño del ultimo campo */
                ult_campo = dw_buscar.uof_ultimo_campo_visible();
                tamaño = Convert.ToInt32(dw_buscar.Describe(ult_campo + ".Width "));
                scroll = dw_1.Width - Convert.ToInt32(dw_buscar.Describe(ult_campo + ".X ")) - tamaño;
                tamaño = tamaño + scroll - 5;
                dw_buscar.Modify(ult_campo + ".Width= " + tamaño.ToString(CultureInfo.InvariantCulture));

                /* Setea el orden de los Campos en el orden en que aparecen los campos en la dw */
                current_col = dw_buscar.wf_settaborder_campos_visibles();
                if (current_col > 0) dw_buscar.SetColumn(current_col);

                ib_modificar_dw_busqueda = true;
            }

            /* Recupero la cantidad de Filas */
            il_q_filas = dw_1.RowCount();

            // MODIFICO EL TITULO...
            total_med = wf_medicamentos_seleccionados();
            this.Text = "Seleccione los medicamentos para la rubrica - Seleccionados: " + String(total_med);

            /* Seteo el foco el la dw de busqueda */
            dw_buscar.SetFocus();
        }

        // Traducción directa del bloque “ue_leer_parametros”
        public void ue_leer_parametros()
        {
            // call super::ue_leer_parametros;
            // Inserto un fila en blanco a la dw de busqueda de la descripcion
            dw_buscar.uof_SetDataObject(dw_1.DataObject);
            dw_buscar.SetTransObject(null);
            dw_buscar.cant_filas = 1;
            /* Solo dejo ver el Detalle, y doy el color a la DataWindow */
            dw_buscar.Modify("Datawindow.Header.Height=0");
            dw_buscar.Modify("Datawindow.Footer.Height=0");
            dw_buscar.Modify("Datawindow.Summary.Height=0");
            dw_buscar.Modify("Datawindow.Color=" + Convert.ToString(this.BackColor, CultureInfo.InvariantCulture));
        }

        // Traducción directa del bloque “ue_dw_itemchanged”
        public int ue_dw_itemchanged(object arg_objeto, Dwo dwo)
        {
            // call super::ue_dw_itemchanged;
            int size, resp;
            string item, condicion;
            long ll_row;

            if (arg_objeto != dw_buscar) return 0;

            /* Si esta en una DropDownDatawindow */
            var style = (dw_buscar.Describe("#" + dw_buscar.GetColumn().ToString(CultureInfo.InvariantCulture) + ".Edit.Style") ?? "").ToUpperInvariant();
            if (style == "DDDW"


}

    }

}
