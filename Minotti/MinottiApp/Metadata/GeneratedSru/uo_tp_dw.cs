// -----------------------------------------------------------------------------
// AUTO-MIGRADO DESDE PowerBuilder (.sru)
// Origen : uo_tp_dw.sru
// Tipo   : uo_tp (tabpage) que contiene una uo_dw
// NOTA   : Migración 1:1 exacta, sin refactor
// -----------------------------------------------------------------------------

#nullable enable
using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Basicos.Models;

namespace Minotti.Metadata.GeneratedSru
{
    public class uo_tp_dw : uo_tp
    {
        // ---------------------------------------------------------------------
        // PB: global type uo_tp_dw from uo_tp
        // long backcolor = 81324524
        // event ue_seleccionado ( )
        // dw_1 dw_1
        // ---------------------------------------------------------------------

        public long backcolor = 81324524;

        public uo_dw dw_1;

        // ---------------------------------------------------------------------
        // PB: type variables (vacío)
        // ---------------------------------------------------------------------

        // ---------------------------------------------------------------------
        // PB: forward prototypes
        // public function integer uof_ancho ()
        // public function integer uof_largo ()
        // public function boolean uof_getclaves (ref string parametros[], integer fila)
        // public subroutine uof_setclaves (string parametros[])
        // public function boolean uof_cambios_pendientes ()
        // ---------------------------------------------------------------------

        // ---------------------------------------------------------------------
        // EVENT: ue_seleccionado
        // PB: call super::ue_seleccionado; dw_1.SetFocus()
        // ---------------------------------------------------------------------
        public virtual void ue_seleccionado()
        {
            // en PB llama super::ue_seleccionado aunque uo_tp no lo declara explícito
            // lo dejamos igual por compatibilidad
            // (si tu runtime tiene método, lo ejecuta; si no, no pasa nada)
            // base.ue_seleccionado();

            dw_1.SetFocus();
        }

        // ---------------------------------------------------------------------
        // FUNCTION: uof_ancho
        // PB: Return(dw_1.uof_ancho() + s_esp.borde * 2)
        // ---------------------------------------------------------------------
        public override int uof_ancho()
        {
            return dw_1.uof_ancho() + s_esp.borde * 2;
        }

        // ---------------------------------------------------------------------
        // FUNCTION: uof_largo
        // PB: Return(dw_1.uof_largo() + s_esp.borde * 2)
        // ---------------------------------------------------------------------
        public override int uof_largo()
        {
            return dw_1.uof_largo() + s_esp.borde * 2;
        }

        // ---------------------------------------------------------------------
        // FUNCTION: uof_getclaves
        // PB: Return(dw_1.uof_GetClaves(parametros[], fila))
        // ---------------------------------------------------------------------
        public virtual bool uof_getclaves(ref string[] parametros, int fila)
        {
            return dw_1.uof_getclaves(ref parametros, fila);
        }

        // ---------------------------------------------------------------------
        // SUBROUTINE: uof_setclaves
        // PB:
        // FOR lAux = 1 TO dw_1.RowCount()
        //   If dw_1.GetItemStatus(lAux, 0, Primary!) = NewModified! Then
        //     FOR iAux = 1 TO UpperBound(parametros[])
        //       dw_1.SetItem(lAux, iAux, parametros[iAux])
        //     NEXT
        //   End If
        // NEXT
        // ---------------------------------------------------------------------
        public virtual void uof_setclaves(string[] parametros)
        {
            long lAux;
            int iAux;

            for (lAux = 1; lAux <= dw_1.RowCount(); lAux++)
            {
                if (dw_1.GetItemStatus(lAux, 0, dwbuffer.Primary) == dwitemstatus.NewModified)
                {
                    for (iAux = 1; iAux <= parametros.Length; iAux++)
                    {
                        // PB arrays 1-based -> acá iAux-1
                        dw_1.SetItem(lAux, iAux, parametros[iAux - 1]);
                    }
                }
            }
        }

        // ---------------------------------------------------------------------
        // FUNCTION: uof_cambios_pendientes
        // PB:
        // If dw_1.AcceptText() = -1 or dw_1.ModifiedCount() > 0 Then True else False
        // ---------------------------------------------------------------------
        public override bool uof_cambios_pendientes()
        {
            if (dw_1.AcceptText() == -1 || dw_1.ModifiedCount() > 0)
                return true;

            return false;
        }

        // ---------------------------------------------------------------------
        // PB: on uo_tp_dw.create
        // int iCurrent
        // call super::create
        // this.dw_1=create dw_1
        // iCurrent=UpperBound(this.Control)
        // this.Control[iCurrent+1]=this.dw_1
        // ---------------------------------------------------------------------
        public override void create()
        {
            int iCurrent;

            base.create();

            dw_1 = new dw_1();

            // emula el Control[] de PB (si tu runtime lo maneja como lista)
            iCurrent = this.ControlUpperBound();
            this.ControlSet(iCurrent + 1, dw_1);
        }

        // ---------------------------------------------------------------------
        // PB: on uo_tp_dw.destroy
        // call super::destroy
        // destroy(this.dw_1)
        // ---------------------------------------------------------------------
        public override void destroy()
        {
            base.destroy();

            if (dw_1 != null)
            {
                dw_1.Destroy();
            }
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_leer_parametros
        // PB:
        // call super::ue_leer_parametros;
        // dw_1.uof_SetDataObject(f_ProxParam(arg_s_pag.Parametros))
        // dw_1.SetTransObject(SQLCA)
        // dw_1.Border = TRUE
        // dw_1.BorderStyle=StyleBox!
        // dw_1.uof_SetDwImpresion(f_ProxParam(arg_s_pag.Parametros))
        // dw_1.cant_filas = Integer(f_ProxParam(arg_s_pag.Parametros))
        // If dw_1.cant_filas > 1 Then dw_1.uof_marcar_seleccion(1)
        // dw_1.SetTransObject(SQLCA)
        // ---------------------------------------------------------------------
        public override void ue_leer_parametros(ref st_pagina_carpeta arg_s_pag)
        {
            base.ue_leer_parametros(ref arg_s_pag);

            dw_1.uof_setdataobject(f_ProxParam(arg_s_pag.Parametros));
            dw_1.SetTransObject(SQLCA);

            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.StyleBox;

            dw_1.uof_setdwimpresion(f_ProxParam(arg_s_pag.Parametros));
            dw_1.cant_filas = int.Parse(f_ProxParam(arg_s_pag.Parametros));

            if (dw_1.cant_filas > 1)
                dw_1.uof_marcar_seleccion(1);

            dw_1.SetTransObject(SQLCA);
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_iniciar
        // PB: call super::ue_iniciar; Integer iAux, cant_claves
        // (mismo flujo Alta/Modificación)
        // ---------------------------------------------------------------------
        public override void ue_iniciar(string arg_accion, string[] arg_param)
        {
            base.ue_iniciar(arg_accion, arg_param);

            int iAux;
            int cant_claves;

            if (is_Accion == "A") // Alta
            {
                dw_1.InsertRow(0);

                cant_claves = dw_1.ii_claves.Length;

                for (iAux = 1; iAux <= is_parametros.Length; iAux++)
                {
                    if (cant_claves >= iAux)
                    {
                        // PB 1-based
                        dw_1.uof_setitem(1, dw_1.ii_claves[iAux - 1], is_parametros[iAux - 1]);
                    }
                }

                dw_1.SetColumn(iAux);
            }
            else // Modificación
            {
                if (dw_1.uof_retrieve(is_parametros) < 1)
                    dw_1.InsertRow(0);
            }
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_confirmar
        // PB: call super::ue_confirmar; If dw_1.Update(baux1, baux2) = 1 Then TRUE else FALSE
        // ---------------------------------------------------------------------
        public override bool ue_confirmar(bool baux1, bool baux2)
        {
            base.ue_confirmar(baux1, baux2);

            if (dw_1.Update(baux1, baux2) == 1)
                return true;

            return false;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_acomodar_objetos
        // PB: Ajusta tamaños/posiciones
        // ---------------------------------------------------------------------
        public override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            dw_1.Width = Min(dw_1.uof_ancho(), this.Width - s_esp.borde * 2);

            // dw_1.X = (This.Width - dw_1.Width) / 2 - 10
            dw_1.X = (this.Width - dw_1.Width) / 2 - 10;

            if (dw_1.cant_filas == 1)
            {
                dw_1.Height = Min(dw_1.uof_largo(), this.Height - s_esp.borde * 2);
            }
            else
            {
                dw_1.Height = this.Height - s_esp.borde * 2;
            }

            dw_1.Y = s_esp.borde;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_completar_claves
        // PB: Completa claves de filas nuevas (NewModified!)
        // ---------------------------------------------------------------------
        public override bool ue_completar_claves(string[] sarg_param)
        {
            base.ue_completar_claves(sarg_param);

            for (int iAux = 1; iAux <= dw_1.RowCount(); iAux++)
            {
                if (dw_1.GetItemStatus(iAux, 0, dwbuffer.Primary) == dwitemstatus.NewModified)
                {
                    if (dw_1.uof_setclaves(sarg_param, iAux) != 1)
                        return false;
                }
            }

            return true;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_validar_datos
        // PB: usa uof_DatosCompletos(fila, columna)
        // ---------------------------------------------------------------------
        public override bool ue_validar_datos()
        {
            base.ue_validar_datos();

            long fila = 0;
            int columna = 0;

            if (!dw_1.uof_datoscompletos(ref fila, ref columna))
            {
                if (fila > 0)
                {
                    dw_1.SetRow(fila);
                    dw_1.SetColumn(columna);
                }
                return false;
            }

            return true;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_leer_claves
        // PB: AcceptText + devuelve claves de fila 1
        // ---------------------------------------------------------------------
        public override bool ue_leer_claves(ref string[] sarg_param)
        {
            base.ue_leer_claves(ref sarg_param);

            if (dw_1.AcceptText() != 1)
                return false;

            return dw_1.uof_getclaves(ref sarg_param, 1);
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_aceptar_datos
        // ---------------------------------------------------------------------
        public override bool ue_aceptar_datos()
        {
            base.ue_aceptar_datos();

            if (dw_1.AcceptText() != 1)
                return false;

            return true;
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_reset
        // ---------------------------------------------------------------------
        public override void ue_reset()
        {
            base.ue_reset();
            dw_1.Reset();
        }

        // ---------------------------------------------------------------------
        // EVENT: ue_reiniciar
        // PB:
        // If is_accion = 'A' Then Reset + ue_iniciar
        // ElseIf is_accion = 'M' Then ResetUpdate
        // ---------------------------------------------------------------------
        public override void ue_reiniciar()
        {
            base.ue_reiniciar();

            if (is_Accion == "A")
            {
                dw_1.Reset();
                this.ue_iniciar(is_Accion!, is_parametros);
            }
            else if (is_Accion == "M")
            {
                dw_1.ResetUpdate();
            }
        }

        // ---------------------------------------------------------------------
        // NESTED TYPE: dw_1 from uo_dw within uo_tp_dw
        // PB: integer x=425 integer y=156
        // ---------------------------------------------------------------------
        //public class dw_1 : uo_dw
        //{
        //    public dw_1()
        //    {
        //        this.X = 425;
        //        this.Y = 156;
        //    }
        //}
    }
}
