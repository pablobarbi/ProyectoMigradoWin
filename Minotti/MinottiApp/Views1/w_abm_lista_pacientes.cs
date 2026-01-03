using System;
using System.Data;
using System.Windows.Forms;

namespace Minotti
{
    //	public partial class w_abm_lista_pacientes : Form
    //	{
    //		public w_abm_lista_pacientes() => InitializeComponent();

    //		/* SRW original
    //﻿forward
    //global type w_abm_lista_pacientes from w_abm_lista
    //end type
    //type dw_buscar from uo_dw within w_abm_lista_pacientes
    //end type
    //end forward


    //global type w_abm_lista_pacientes from w_abm_lista 
    //dw_buscar dw_buscar 
    //end type


    //global w_abm_lista_pacientes w_abm_lista_pacientes

    //type variables
    ///* Controles */
    //		String is_nombre_columna, idata
    //Integer il_q_filas
    //String is_back_color = '15794175'
    //Boolean ib_modificar_dw_busqueda = FALSE




    //end variables

    //on w_abm_lista_pacientes.create
    //int iCurrent
    //call super::create
    //this.dw_buscar= create dw_buscar
    //iCurrent = UpperBound(this.Control)
    //this.Control[iCurrent + 1]= this.dw_buscar
    //end on

    //on w_abm_lista_pacientes.destroy
    //call super::destroy
    //destroy(this.dw_buscar)
    //end on

    //event activate; call super::activate;/* La modificación es resuelta por la ventana de detalle */
    //		m_mdi.m_operaciones.m_confirmar.Enabled = FALSE

    //end event

    //event ue_acomodar_objetos; integer largo_dw1

    //largo_dw1 = This.wf_largo_Disponible() - s_esp.borde - dw_buscar.uof_largo()

    ///* Acomodo el objeto dw_1 */
    //dw_1.Width = Min(dw_1.uof_ancho(), This.wf_Ancho_Disponible())
    //dw_1.Height = largo_dw1
    //dw_1.Y = s_esp.borde
    //This.wf_CentrarObjeto(dw_1)

    ///* Acomodo la dw busqueda */
    //dw_buscar.Height = dw_buscar.uof_largo()
    //dw_buscar.Width  = dw_1.Width
    //dw_buscar.X = dw_1.X
    //dw_buscar.Y = dw_1.Y + dw_1.Height + s_esp.borde

    //end event

    //event ue_ajustar_tamaño;/* Fija el tamaño inicial de la ventana */
    //		This.Width = dw_1.uof_ancho() + s_esp.ancho + 2 * s_esp.borde
    //		This.Height = dw_1.uof_largo() + s_esp.largo + 2 * s_esp.borde + dw_buscar.uof_largo() + 80


    //		end event

    //event ue_leer_parametros; call super::ue_leer_parametros;// ------------------------------------------------------------------------------------
    //														 // Inserto un fila en blanco a la dw de busqueda de la descripcion
    //														 // ------------------------------------------------------------------------------------
    //		dw_buscar.uof_SetDataObject(dw_1.DataObject)
    //		dw_buscar.SetTransObject(SQLCA)
    //dw_buscar.cant_filas = 1
    ///* Solo dejo ver el Detalle, y doy el color a la DataWindow */
    //dw_buscar.Modify("Datawindow.Header.Height=0")
    //dw_buscar.Modify("Datawindow.Footer.Height=0")
    //dw_buscar.Modify("Datawindow.Summary.Height=0")
    //dw_buscar.Modify("Datawindow.Color=" + String(This.BackColor))

    //end event

    //event ue_dw_itemchanged; call super::ue_dw_itemchanged; integer size, resp
    //string item, condicion
    //long ll_row

    //If arg_objeto<> dw_buscar Then Return 0

    ///* Si esta en una DropDownDatawindow */
    //IF Upper(dw_buscar.Describe("#" + String(dw_buscar.GetColumn()) + ".Edit.Style")) = 'DDDW' or &
    //   Upper(dw_buscar.Describe("#" + String(dw_buscar.GetColumn()) + ".Edit.Style")) = 'DDLB' Then

    // item = dw_buscar.gettext()
    // size = len(item)

    // if size > 0 then
    //	CHOOSE CASE dw_buscar.at_col[dw_buscar.GetColumn()].Tipo
    //		CASE 'char('

    //		  condicion = "Left(" + dwo.name + "," + string(size) + ")= '" + item + "'"
    //		CASE 'long', 'numbe','real','decim'
    //			if Not IsNumber(item) Then Return 0

    //		  condicion = dwo.name + "= " + item

    //		CASE 'date','datet','time'

    //			 condicion = dwo.name + "= " + item

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
    //	ll_row     = dw_1.Find(condicion, 1, il_q_filas)
    //	if ll_row<> 0 then
    //		resp = dw_1.selectrow(0, false)
    //		resp = dw_1.selectrow(ll_row,true)	
    //		resp = dw_1.scrolltorow(ll_row)
    //	End if
    //   Setpointer(Arrow!)
    //  End if
    //End If

    //Return 0

    //end event

    //event ue_iniciar; call super::ue_iniciar; Integer tope, iAux,tamaño, scroll, current_col
    //String col, ult_campo, nombre

    //If at_op.Accion = "A" Then
    //Else
    //	/* Inserto una Fila en la dw */
    //	If dw_buscar.RowCount() <= 0 Then dw_buscar.InsertRow(0)

    //		If NOT ib_modificar_dw_busqueda Then
    //			Tope = Integer(dw_buscar.Describe('DataWindow.Column.Count'))
    //			FOR iAux = 1 To Tope
    //				col = "#" + string (iAux)

    //				/* solo dejo visibles los campos que son del detalle */
    //				nombre = dw_buscar.Describe(col + ".Name")
    //				IF dw_buscar.Describe(nombre + ".Band") = "detail" THEN
    //					dw_buscar.Modify(col + ".Visible = 1")
    //				ELSE
    //					dw_buscar.Modify(col + ".Visible = 0")
    //				END IF

    //				IF dw_buscar.Describe(col + ".Visible") = '1' THEN
    //					/* Le saco la propiedad de Rectangulo en el foco */
    //					Choose Case Upper(dw_buscar.Describe(col + ".Edit.Style"))
    //						Case 'EDIT'
    //							dw_buscar.Modify(col + ".Edit.FocusRectangle=no")
    //						CASE 'DDDW'
    //							dw_buscar.Modify(col + ".dddw.FocusRectangle=no")
    //						CASE 'DDLB'
    //							dw_buscar.Modify(col + ".ddlb.FocusRectangle=no")
    //						CASE 'EDITMASK'
    //							dw_buscar.Modify(col + ".EditMask.FocusRectangle=no")
    //					End Choose
    //					/* Le Aplico un Borde a los Campos*/
    //		//			dw_buscar.Modify(col + ".Border='6'")  // Raised
    //					dw_buscar.Modify(col + ".Border='2'")  // Box
    //					dw_buscar.Modify(col + ".Protect='0'")
    //					dw_buscar.Modify(col + ".Background.Mode='0'")
    //					dw_buscar.Modify(col + ".Background.Color='" + is_back_color + "'")  // RGB(255,255,240)
    //					dw_buscar.Modify(col + ".Height.AutoSize=No")

    //			//		dw_buscar.Modify(col + ".Background.Color = '16777215'")  // RGB(255,255,255) Blanco
    //			//		dw_buscar.Modify(col + ".TabSequence=" )
    //			//		dw_buscar.Modify(col + ".Font.Weight = '400'")
    //			//		dw_buscar.Modify(col + ".Font.Height = '-9'")

    //			End If
    //		Next
    //	End If

    //	If Not ib_modificar_dw_busqueda Then
    //		/* Modifico el tamaño del ultimo campo */
    //		ult_campo = dw_buscar.uof_ultimo_campo_visible()
    //		tamaño = integer(dw_buscar.Describe(ult_campo + ".Width ") )
    //		scroll = dw_1.width - integer(dw_buscar.Describe(ult_campo + ".X ") ) - &
    //					tamaño
    //		tamaño = tamaño + scroll - 5
    //		dw_buscar.Modify(ult_campo + ".Width= " + string (tamaño) )

    //		/* Setea el orden de los Campos en el orden en que aparecen los campos en la dw */
    //		current_col = dw_buscar.wf_settaborder_campos_visibles()
    //	   if current_col > 0 Then dw_buscar.SetColumn(current_col)

    //		ib_modificar_dw_busqueda = TRUE
    //	End If

    //End If

    ///* Recupero la cantidad de Filas */
    //il_q_filas = dw_1.RowCount()

    ///* Seteo el foco el la dw de busqueda */
    //dw_buscar.SetFocus()

    //end event

    //event ue_borrar;/*
    //ATENCION !!!        ANCESTOR SCRIPT OVERRIDE
    //*/

    //		Long iAux, ll_Paciente

    //is_Accion = "B"

    //iAux = dw_1.GetRow()
    //If iAux< 1 Then This.ib_grabar = FALSE

    //ll_Paciente = dw_1.GetItemNumber(iAux, 'paciente')

    //If This.ib_grabar Then
    //	If dw_1.DeleteRow(iAux) <> 1 Then This.ib_grabar = FALSE
    //End If

    //If This.ib_grabar Then
    //	If dw_1.Update(TRUE, TRUE) <> 1 Then This.ib_grabar = FALSE
    //End If

    //If This.ib_grabar Then
    //	/* No se cierra al borrar un registro de la lista */
    //	This.ib_cerrar_al_grabar = FALSE
    //Else
    //	dw_1.RowsMove(1, dw_1.DeletedCount(), Delete!, dw_1, iAux, Primary!)
    //	dw_1.SetRow(iAux)
    ////	dw_1.Sort()
    //End If


    //IF ib_grabar THEN


    //	DELETE FROM pacientes_historias WHERE paciente =  :ll_Paciente
    //		  USING SQLCA;

    //	IF SQLCA.SQLCode< 0 THEN
    //		MessageBox('Guardando','Error Borrando Historia del Paciente', StopSign!)
    //		This.ib_grabar = FALSE
    //		RETURN
    //	END IF



    //	DELETE FROM diagnosticos WHERE  paciente =  :ll_Paciente
    //		  USING SQLCA;

    //	IF SQLCA.SQLCode< 0 THEN
    //		MessageBox('Guardando','Error Borrando Diagnóstico del Paciente', StopSign!)
    //		This.ib_grabar = FALSE
    //		RETURN
    //	END IF

    //END IF

    //end event

    //type dw_buscar from uo_dw within w_abm_lista_pacientes

    //end type


    //event editchanged; call super::editchanged; integer size, resp
    //string item, condicion, mascara
    //long ll_row

    //item = data
    //size = len(item)

    //SetNull(condicion)
    //if size > 0 then

    //	il_q_filas = dw_1.RowCount()

    ////	CHOOSE CASE Upper(This.Describe("#" + String(This.GetColumn()) + ".Style"))
    ////		Case "DDLB","EDITMASK"
    ////MESSAGEBOX("FORMATO",This.Describe("#" + String(This.GetColumn()) + ".EditMask.Mask"))


    //	CHOOSE CASE This.at_col[This.GetColumn()].Tipo
    //		CASE 'char('

    //		  condicion = "Left("+ dwo.name +"," + string (size) + ")= '" + item + "'"
    //		CASE 'long', 'numbe','real','decim'
    //			if Not IsNumber(item) Then Return

    //		  condicion = dwo.name + "= " + item
    //		CASE ELSE
    //			Return
    //	END CHOOSE

    //If IsNull(condicion) Then Return
    //	Setpointer(hourglass!)
    //	ll_row     = dw_1.Find(condicion, 1, il_q_filas)
    //	if ll_row<> 0 then
    //		resp = dw_1.selectrow(0, false)
    //		resp = dw_1.selectrow(ll_row,true)	
    //		resp = dw_1.scrolltorow(ll_row)
    //	end if
    //end if

    //Setpointer(Arrow!)

    //end event

    //event itemchanged; call super::itemchanged; integer size, resp
    //string item, condicion, tipo
    //long ll_row

    //item = data
    //size = len(item)

    //if size > 0 then

    //	tipo = This.at_col[This.GetColumn()].Tipo
    //	If tipo = 'date' or tipo = 'datet' or tipo = 'time' Then
    //	   Setpointer(hourglass!)
    //  		condicion = dwo.name + " >= " + item

    //		ll_row = dw_1.Find(condicion, 1, il_q_filas)
    //		if ll_row<> 0 then
    //			resp = dw_1.selectrow(0, false)
    //			resp = dw_1.selectrow(ll_row,true)	
    //			resp = dw_1.scrolltorow(ll_row)
    //		end if
    //		Setpointer(Arrow!)
    //	end if
    //end If

    //end event

    //event itemfocuschanged; call super::itemfocuschanged; integer iAux
    //String nulo

    //SetNull(nulo)
    //FOR iAux=1 TO Integer(This.Describe("DataWindow.Column.Count"))
    //	This.uof_SetItem(row, iAux, nulo)
    //NEXT




    //end event


    //		*/

    //        /* SRW.XAML original
    //﻿<pbwpf:Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="w_abm_lista_pacientes" x:ClassModifier="internal">
    //	<Canvas>
    //			<pbwpf:DataWindow Name="dw_buscar" PBHScrollBar="false" PBHeight="164" Height="41" PBVScrollBar="false" PBWidth="1362" Width="298" X="155" Y="820">
    //			</pbwpf:DataWindow>
    //	</Canvas>
    //</pbwpf:Window>
    //        */
    //    }
    //	}





 

    // Traducción directa del SRW provisto (incluye queries). Sin reinterpretar nombres ni lógica.

    public partial class w_abm_lista_pacientes : w_abm_lista
    {
        /* Controles / variables del script */
        private string is_nombre_columna, idata;
        private int il_q_filas;
        private string is_back_color = "15794175";
        private bool ib_modificar_dw_busqueda = false;

        // Controles referenciados
        private readonly DataWindow dw_1 = new DataWindow();
        private readonly dw_buscar dw_buscar;

        public w_abm_lista_pacientes()
        {
            InitializeComponent();

            // on w_abm_lista_pacientes.create
            // call super::create  (no-op en este stub)
            this.dw_buscar = new dw_buscar();
            // this.Control[iCurrent+1]=this.dw_buscar   (no hay colección de controles PB aquí)
        }

        ~w_abm_lista_pacientes()
        {
            // on w_abm_lista_pacientes.destroy
            // call super::destroy (no-op)
            // destroy(this.dw_buscar) (GC)
        }

        // event activate
        public void activate()
        {
            // call super::activate (no-op)
            // m_mdi.m_operaciones.m_confirmar.Enabled = FALSE
            // (stub sin UI MDI real)
        }

        // event ue_acomodar_objetos
        public void ue_acomodar_objetos()
        {
            int largo_dw1 = this.wf_largo_Disponible() - s_esp.borde - dw_buscar.uof_largo();

            // Acomodo dw_1
            dw_1.Width = Math.Min(dw_1.uof_ancho(), this.wf_Ancho_Disponible());
            dw_1.Height = largo_dw1;
            dw_1.Y = s_esp.borde;
            this.wf_CentrarObjeto(dw_1);

            // Acomodo dw_buscar
            dw_buscar.Height = dw_buscar.uof_largo();
            dw_buscar.Width = dw_1.Width;
            dw_buscar.X = dw_1.X;
            dw_buscar.Y = dw_1.Y + dw_1.Height + s_esp.borde;
        }

        // event ue_ajustar_tamaño
        public void ue_ajustar_tamaño()
        {
            this.Width = dw_1.uof_ancho() + s_esp.ancho + 2 * s_esp.borde;
            this.Height = dw_1.uof_largo() + s_esp.largo + 2 * s_esp.borde + dw_buscar.uof_largo() + 80;
        }

        // event ue_leer_parametros
        public void ue_leer_parametros()
        {
            // call super::ue_leer_parametros (no-op)

            // Inserto fila en blanco en búsqueda
            dw_buscar.uof_SetDataObject(dw_1.DataObject);
            dw_buscar.SetTransObject(SQLCA);
            dw_buscar.cant_filas = 1;
            // Solo dejo ver el Detalle, y color
            dw_buscar.Modify("Datawindow.Header.Height=0");
            dw_buscar.Modify("Datawindow.Footer.Height=0");
            dw_buscar.Modify("Datawindow.Summary.Height=0");
            dw_buscar.Modify("Datawindow.Color=" + Convert.ToString(this.BackColor));
        }

        // event ue_dw_itemchanged
        public int ue_dw_itemchanged(object arg_objeto, Dwo dwo)
        {
            // call super::ue_dw_itemchanged (no-op)

            int size, resp;
            string item, condicion;
            long ll_row;

            if (arg_objeto != dw_buscar) return 0;

            // Si está en DDDW o DDLB
            var editStyle = dw_buscar.Describe("#" + Convert.ToString(dw_buscar.GetColumn()) + ".Edit.Style");
            if (string.Equals(editStyle, "DDDW", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(editStyle, "DDLB", StringComparison.OrdinalIgnoreCase))
            {
                item = dw_buscar.gettext();
                size = (item ?? string.Empty).Length;

                if (size > 0)
                {
                    switch (dw_buscar.at_col[dw_buscar.GetColumn()].Tipo)
                    {
                        case "char(":
                            condicion = "Left(" + dwo.name + "," + size + ")= '" + item + "'";
                            break;
                        case "long":
                        case "numbe":
                        case "real":
                        case "decim":
                            if (!IsNumber(item)) return 0;
                            condicion = dwo.name + "= " + item;
                            break;
                        case "date":
                        case "datet":
                        case "time":
                            condicion = dwo.name + "= " + item;
                            break;
                        default:
                            return 0;
                    }

                    Setpointer("hourglass");
                    ll_row = dw_1.Find(condicion, 1, il_q_filas);
                    if (ll_row != 0)
                    {
                        resp = dw_1.selectrow(0, false);
                        resp = dw_1.selectrow(ll_row, true);
                        resp = dw_1.scrolltorow(ll_row);
                    }
                    Setpointer("arrow");
                }
            }

            return 0;
        }

        // event ue_iniciar
        public void ue_iniciar()
        {
            // call super::ue_iniciar (no-op)
            int tope, iAux, tamaño, scroll, current_col;
            string col, ult_campo, nombre;

            if (at_op.Accion == "A")
            {
                // nada
            }
            else
            {
                // Inserto fila en dw_buscar
                if (dw_buscar.RowCount() <= 0) dw_buscar.InsertRow(0);

                if (!ib_modificar_dw_busqueda)
                {
                    tope = Convert.ToInt32(dw_buscar.Describe("DataWindow.Column.Count"));
                    for (iAux = 1; iAux <= tope; iAux++)
                    {
                        col = "#" + Convert.ToString(iAux);

                        // solo campos del detail
                        nombre = dw_buscar.Describe(col + ".Name");
                        if (dw_buscar.Describe(nombre + ".Band") == "detail")
                            dw_buscar.Modify(col + ".Visible = 1");
                        else
                            dw_buscar.Modify(col + ".Visible = 0");

                        if (dw_buscar.Describe(col + ".Visible") == "1")
                        {
                            var style = dw_buscar.Describe(col + ".Edit.Style").ToUpperInvariant();
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
                            dw_buscar.Modify(col + ".Border='2'"); // Box
                            dw_buscar.Modify(col + ".Protect='0'");
                            dw_buscar.Modify(col + ".Background.Mode='0'");
                            dw_buscar.Modify(col + ".Background.Color='" + is_back_color + "'");
                            dw_buscar.Modify(col + ".Height.AutoSize=No");
                        }
                    }
                }

                if (!ib_modificar_dw_busqueda)
                {
                    // Modifico tamaño del último campo
                    ult_campo = dw_buscar.uof_ultimo_campo_visible();
                    tamaño = Convert.ToInt32(dw_buscar.Describe(ult_campo + ".Width"));
                    scroll = dw_1.Width - Convert.ToInt32(dw_buscar.Describe(ult_campo + ".X")) - tamaño;
                    tamaño = tamaño + scroll - 5;
                    dw_buscar.Modify(ult_campo + ".Width= " + tamaño.ToString());

                    // Setea orden de tab en el orden de campos visibles
                    current_col = dw_buscar.wf_settaborder_campos_visibles();
                    if (current_col > 0) dw_buscar.SetColumn(current_col);

                    ib_modificar_dw_busqueda = true;
                }
            }

            // Recupero cantidad de filas
            il_q_filas = dw_1.RowCount();

            // Foco
            dw_buscar.SetFocus();
        }

        // event ue_borrar
        public void ue_borrar()
        {
            /*
            ATENCION !!!        ANCESTOR SCRIPT OVERRIDE
            */

            long iAux, ll_Paciente;

            is_Accion = "B";

            iAux = dw_1.GetRow();
            if (iAux < 1) this.ib_grabar = false;

            ll_Paciente = dw_1.GetItemNumber(iAux, "paciente");

            if (this.ib_grabar)
            {
                if (dw_1.DeleteRow(iAux) != 1) this.ib_grabar = false;
            }

            if (this.ib_grabar)
            {
                if (dw_1.Update(true, true) != 1) this.ib_grabar = false;
            }

            if (this.ib_grabar)
            {
                // No se cierra al borrar un registro de la lista
                this.ib_cerrar_al_grabar = false;
            }
            else
            {
                dw_1.RowsMove(1, dw_1.DeletedCount(), "Delete!", dw_1, iAux, "Primary!");
                dw_1.SetRow(iAux);
                // dw_1.Sort()
            }

            if (ib_grabar)
            {
                // DELETE FROM pacientes_historias WHERE paciente = :ll_Paciente USING SQLCA;
                {
                    var sql = "DELETE FROM pacientes_historias WHERE paciente = @ll_Paciente;";
                    SQLCA.ExecuteNonQuery(sql, cmd =>
                    {
                        var p = cmd.CreateParameter();
                        p.ParameterName = "@ll_Paciente";
                        p.Value = ll_Paciente;
                        cmd.Parameters.Add(p);
                    });

                    if (SQLCA.SQLCode < 0)
                    {
                        MessageBox.Show("Error Borrando Historia del Paciente", "Guardando", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.ib_grabar = false;
                        return;
                    }
                }

                // DELETE FROM diagnosticos WHERE paciente = :ll_Paciente USING SQLCA;
                {
                    var sql = "DELETE FROM diagnosticos WHERE paciente = @ll_Paciente;";
                    SQLCA.ExecuteNonQuery(sql, cmd =>
                    {
                        var p = cmd.CreateParameter();
                        p.ParameterName = "@ll_Paciente";
                        p.Value = ll_Paciente;
                        cmd.Parameters.Add(p);
                    });

                    if (SQLCA.SQLCode < 0)
                    {
                        MessageBox.Show("Error Borrando Diagnóstico del Paciente", "Guardando", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.ib_grabar = false;
                        return;
                    }
                }
            }
        }

        // ======== Tipos y stubs mínimos para reflejar PB ========

        // dw_buscar dentro de w_abm_lista_pacientes
        public sealed class dw_buscar : uo_dw
        {
            public int cant_filas;

            // SRW.XAML: Name="dw_buscar"
            public string Name => "dw_buscar";

            // events from nested type:

            // editchanged
            public void editchanged(string data)
            {
                // call super::editchanged (no-op)
                int size, resp;
                string item, condicion, mascara;
                long ll_row;

                item = data;
                size = (item ?? string.Empty).Length;

                SetNull(out condicion);
                if (size > 0)
                {
                    // il_q_filas = dw_1.RowCount() => en PB es externo; aquí no se referencia.

                    switch (this.at_col[this.GetColumn()].Tipo)
                    {
                        case "char(":
                            condicion = "Left(" + dwo.name + "," + size + ")= '" + item + "'";
                            break;
                        case "long":
                        case "numbe":
                        case "real":
                        case "decim":
                            if (!IsNumber(item)) return;
                            condicion = dwo.name + "= " + item;
                            break;
                        default:
                            return;
                    }

                    if (condicion == null) return;
                    Setpointer("hourglass");
                    // ll_row = dw_1.Find(condicion, 1, il_q_filas)  // externo aquí
                    Setpointer("arrow");
                }
            }

            // itemchanged
            public void itemchanged(string data)
            {
                // call super::itemchanged (no-op)
                int size, resp;
                string item, condicion, tipo;
                long ll_row;

                item = data;
                size = (item ?? string.Empty).Length;

                if (size > 0)
                {
                    tipo = this.at_col[this.GetColumn()].Tipo;
                    if (tipo == "date" || tipo == "datet" || tipo == "time")
                    {
                        Setpointer("hourglass");
                        condicion = dwo.name + " >= " + item;

                        // ll_row = dw_1.Find(condicion, 1, il_q_filas) // externo
                        Setpointer("arrow");
                    }
                }
            }

            // itemfocuschanged
            public void itemfocuschanged(int row)
            {
                // call super::itemfocuschanged (no-op)
                int iAux;
                string nulo = null;
                for (iAux = 1; iAux <= Convert.ToInt32(this.Describe("DataWindow.Column.Count")); iAux++)
                    this.uof_SetItem(row, iAux, nulo);
            }
        }

        // --------- Utilidades/Helpers PB-style ---------
        private static bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            double _;
            return double.TryParse(s, out _);
        }

        private static void Setpointer(string _) { /* PB: SetPointer(...) */ }

        private static void SetNull(out string s) { s = null; }

        // ----- Stubs de objetos/funciones referidos -----
        private sealed class DataWindow
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public string DataObject { get; set; }

            public int uof_ancho() => 800;
            public int uof_largo() => 400;

            public string Describe(string expr) => "0"; // devolver valores necesarios textual
            public void Modify(string expr) { }
            public int RowCount() => 0;
            public long Find(string condicion, int from, int to) => 0;
            public int selectrow(long row, bool onoff) => 1;
            public int scrolltorow(long row) => 1;
            public long GetRow() => 1;
            public long GetItemNumber(long row, string col) => 0;
            public int DeleteRow(long row) => 1;
            public int Update(bool a, bool b) => 1;
            public int DeletedCount() => 0;
            public void RowsMove(int a, int b, string c, DataWindow d1, long e, string f) { }
            public void SetRow(long r) { }
        }

        public class uo_dw
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public Dwo dwo = new Dwo();
            public ColInfo[] at_col = new ColInfo[256];
            public uo_dw()
            {
                for (int i = 0; i < at_col.Length; i++) at_col[i] = new ColInfo();
            }

            public virtual void SetTransObject(transaction t) { }
            public virtual void uof_SetDataObject(string name) { }
            public virtual int uof_largo() => 41;
            public virtual string Describe(string expr) => "0";
            public virtual void Modify(string expr) { }
            public virtual int RowCount() => 0;
            public virtual int InsertRow(int pos) => 1;
            public virtual void SetFocus() { }
            public virtual int GetColumn() => 1;
            public virtual string gettext() => null;
            public virtual string uof_ultimo_campo_visible() => "#1";
            public virtual int wf_settaborder_campos_visibles() => 1;
            public virtual void SetColumn(int c) { }
            public virtual void uof_SetItem(int row, int col, string value) { }
        }

        public class Dwo { public string name = "col"; }
        public class ColInfo { public string Tipo = "char("; }

        // Espaciado y helpers de layout invocados por el script
        private static class s_esp
        {
            public static int borde = 8;
            public static int ancho = 50;
            public static int largo = 50;
        }

        private int wf_largo_Disponible() => 600;
        private int wf_Ancho_Disponible() => 800;
        private void wf_CentrarObjeto(object _) { }

        // Estado de operación (referenciado)
        private readonly at_op_t at_op = new at_op_t();
        private string is_Accion;
        private bool ib_cerrar_al_grabar;

        public class at_op_t { public string Accion; }

        // SQLCA
        public static readonly transaction SQLCA = new transaction();
    }

    // Base “from w_abm_lista”
    public class w_abm_lista : Form { }

    // Transacción mínima con ADO.NET para ejecutar queries
    public sealed class transaction
    {
        public IDbConnection Connection { get; private set; }
        public IDbTransaction Tx { get; private set; }
        public int SQLCode { get; set; }

        public void SetConnection(IDbConnection conn) => Connection = conn;

        public int ExecuteNonQuery(string sql, Action<IDbCommand> bind = null)
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.Transaction = Tx;
                    cmd.CommandText = sql;
                    bind?.Invoke(cmd);
                    var n = cmd.ExecuteNonQuery();
                    SQLCode = 0;
                    return n;
                }
            }
            catch
            {
                SQLCode = -1;
                return 0;
            }
        }

        public T ExecuteScalar<T>(string sql, Action<IDbCommand> bind = null)
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.Transaction = Tx;
                    cmd.CommandText = sql;
                    bind?.Invoke(cmd);
                    object o = cmd.ExecuteScalar();
                    SQLCode = 0;
                    if (o == null || o == DBNull.Value) return default;
                    return (T)Convert.ChangeType(o, typeof(T));
                }
            }
            catch
            {
                SQLCode = -1;
                return default;
            }
        }
    }

}