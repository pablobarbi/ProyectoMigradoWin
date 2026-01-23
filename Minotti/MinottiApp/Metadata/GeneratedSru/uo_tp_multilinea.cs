// -----------------------------------------------------------------------------
// AUTO-MIGRADO DESDE PowerBuilder (.sru)
// Origen : uo_tp_multilinea.sru
// Tipo   : Tab Page multilínea con ABM
// Hereda : uo_tp
// -----------------------------------------------------------------------------

#nullable enable
using Minotti.Data;
using Minotti.UserObjects;
using Minotti.utils;
using Minotti.Views.Basicos.Models;
using MinottiApp.utils;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Minotti.Metadata.GeneratedSru
{
    public class uo_tp_multilinea : uo_tp
    {
        // ---------------------------------------------------------------------
        // Controles
        // ---------------------------------------------------------------------
        public dw_1 dw_1;
        public pb_insertar pb_insertar;
        public pb_borrar pb_borrar;

        // ---------------------------------------------------------------------
        // Eventos PB
        // ---------------------------------------------------------------------
        public virtual void ue_seleccionado()
        {
            base.ue_seleccionado();
            dw_1?.SetFocus();
        }

        public virtual void ue_insertar()
        {
            base.ue_insertar();
            dw_1.SetRow(dw_1.InsertRow(0));
            dw_1.SetFocus();
        }

        public virtual void ue_borrar()
        {
            base.ue_borrar();
            dw_1.DeleteRow(0);
        }

        // ---------------------------------------------------------------------
        // Funciones
        // ---------------------------------------------------------------------
        public override int uof_ancho()
        {
            return dw_1.uof_ancho() + s_esp.borde * 3 + pb_insertar.Width;
        }

        public override int uof_largo()
        {
            return dw_1.uof_largo() + s_esp.borde * 2;
        }

        public bool uof_getclaves(ref string[] parametros, int fila)
        {
            return dw_1.uof_GetClaves(ref parametros, fila);
        }

        public void uof_setclaves(string[] parametros)
        {
            long lAux;
            int iAux;

            for (lAux = 1; lAux <= dw_1.RowCount(); lAux++)
            {
                if (dw_1.GetItemStatus(lAux, 0, DwBuffer.Primary) == DwItemStatus.NewModified)
                {
                    for (iAux = 1; iAux <= parametros.Length; iAux++)
                    {
                        dw_1.SetItem(lAux, iAux, parametros[iAux - 1]);
                    }
                }
            }
        }

        public override bool uof_cambios_pendientes()
        {
            if (dw_1.AcceptText() == -1 || dw_1.ModifiedCount() > 0)
                return true;

            return false;
        }

        // ---------------------------------------------------------------------
        // CREATE / DESTROY
        // ---------------------------------------------------------------------
        public override void create()
        {
            base.create();

            dw_1 = new dw_1();
            pb_insertar = new pb_insertar();
            pb_borrar = new pb_borrar();

            int iCurrent = Control.Length;
            Array.Resize(ref Control, iCurrent + 3);

            Control[iCurrent] = dw_1;
            Control[iCurrent + 1] = pb_insertar;
            Control[iCurrent + 2] = pb_borrar;
        }

        public override void destroy()
        {
            base.destroy();

            dw_1?.Dispose();
            pb_insertar?.Dispose();
            pb_borrar?.Dispose();
        }

        // ---------------------------------------------------------------------
        // UE_LEER_PARAMETROS
        // ---------------------------------------------------------------------
        public override void ue_leer_parametros(st_pagina_carpeta arg_s_pag)
        {
            base.ue_leer_parametros(arg_s_pag);

            dw_1.uof_SetDataObject(f_ProxParam(arg_s_pag.Parametros));
            dw_1.SetTransObject(SQLCA);
            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.StyleBox;
            dw_1.uof_SetDwImpresion(f_ProxParam(arg_s_pag.Parametros));
            dw_1.cant_filas = int.Parse(f_ProxParam(arg_s_pag.Parametros));
        }

        // ---------------------------------------------------------------------
        // UE_INICIAR
        // ---------------------------------------------------------------------
        public override void ue_iniciar(string arg_accion, string[] arg_param)
        {
            base.ue_iniciar(arg_accion, arg_param);

            int cant_claves;
            int cant_param;
            int iAux;

            if (is_accion == "A")
            {
                dw_1.InsertRow(0);
            }
            else
            {
                if (dw_1.uof_Retrieve(is_parametros) < 1)
                    dw_1.InsertRow(0);
            }

            dw_1.uof_Edicion(0, "E");

            cant_claves = dw_1.ii_claves.Length;
            cant_param = is_parametros.Length;

            for (iAux = 1; iAux <= cant_param; iAux++)
            {
                if (cant_claves >= iAux)
                    dw_1.uof_Edicion(dw_1.ii_claves[iAux - 1], "N");
            }
        }

        // ---------------------------------------------------------------------
        // UE_ACOMODAR_OBJETOS
        // ---------------------------------------------------------------------
        public override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            int ancho;

            SetRedraw(false);

            dw_1.Width = Math.Min(
                dw_1.uof_ancho(),
                Width - s_esp.borde * 3 - pb_insertar.Width
            );

            ancho = dw_1.Width + pb_insertar.Width;
            dw_1.X = (Width - ancho) / 2 - 10;

            if (dw_1.cant_filas == 1)
                dw_1.Height = Math.Min(dw_1.uof_largo(), Height - s_esp.borde * 2);
            else
                dw_1.Height = Height - s_esp.borde * 2;

            dw_1.Y = s_esp.borde;

            pb_insertar.X = dw_1.X + dw_1.Width + s_esp.borde;
            pb_borrar.X = pb_insertar.X;

            SetRedraw(true);
        }

        // ---------------------------------------------------------------------
        // UE_CONFIRMAR
        // ---------------------------------------------------------------------
        public override bool ue_confirmar(bool baux1, bool baux2)
        {
            base.ue_confirmar(baux1, baux2);
            return dw_1.Update(baux1, baux2) == 1;
        }

        public override bool ue_completar_claves(string[] sarg_param)
        {
            base.ue_completar_claves(sarg_param);

            for (int iAux = 1; iAux <= dw_1.RowCount(); iAux++)
            {
                if (dw_1.GetItemStatus(iAux, 0, DwBuffer.Primary) == DwItemStatus.NewModified)
                {
                    if (dw_1.uof_SetClaves(sarg_param, iAux) != 1)
                        return false;
                }
            }

            return true;
        }

        public override bool ue_aceptar_datos()
        {
            base.ue_aceptar_datos();
            return dw_1.AcceptText() == 1;
        }

        public override void ue_reset()
        {
            base.ue_reset();
            dw_1.Reset();
        }

        // ---------------------------------------------------------------------
        // Clases internas (DW y Botones)
        // ---------------------------------------------------------------------
        public class dw_1 : uo_dw { }

        public class pb_insertar : PictureButton
        {
            public pb_insertar()
            {
                Text = "&Insertar";
            }

            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                Parent?.TriggerEvent("ue_insertar");
            }
        }

        public class pb_borrar : PictureButton
        {
            public pb_borrar()
            {
                Text = "&Borrar";
            }

            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                Parent?.TriggerEvent("ue_borrar");
            }
        }
    }
}
