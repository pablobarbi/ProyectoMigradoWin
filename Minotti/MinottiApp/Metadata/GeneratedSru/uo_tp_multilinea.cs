// -----------------------------------------------------------------------------
// AUTO-MIGRADO DESDE PowerBuilder (.sru)
// Origen : uo_tp_multilinea.sru
// Tipo   : Tab Page multilínea con ABM
// Hereda : uo_tp
// -----------------------------------------------------------------------------

#nullable enable
using Minotti.Data;
using Minotti.Functions;
using Minotti.utils;
using static System.Net.Mime.MediaTypeNames;

namespace Minotti.Metadata.GeneratedSru
{
    public class uo_tp_multilinea : uo_tp
    {
        // ---------------------------------------------------------------------
        // Controles
        // ---------------------------------------------------------------------
        public dw_1 dw_1 { get; private set; }
        public pb_insertar pb_insertar { get; private set; }
        public pb_borrar pb_borrar { get; private set; }

        // ---------------------------------------------------------------------
        // Eventos PB
        // ---------------------------------------------------------------------
        public override void ue_seleccionado()
        {
            base.ue_seleccionado();
            dw_1?.SetFocus();
        }

        public override void ue_insertar()
        {
            base.ue_insertar();
            dw_1.SetRow(dw_1.InsertRow(0));
            dw_1.SetFocus();
        }

        public override void ue_borrar()
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
            return dw_1.uof_getclaves(ref parametros, fila);
        }

        public void uof_setclaves(string[] parametros)
        {
            for (int lAux = 1; lAux <= dw_1.RowCount(); lAux++)
            {
                if (dw_1.GetItemStatus(lAux, 0, dwbuffer.Primary) == dwitemstatus.NewModified)
                {
                    for (int iAux = 1; iAux <= parametros.Length; iAux++)
                    {
                        dw_1.SetItem(lAux, iAux, parametros[iAux - 1]);
                    }
                }
            }
        }

        public override bool uof_cambios_pendientes()
        {
            return dw_1.AcceptText() == -1 || dw_1.ModifiedCount() > 0;
        }

        // ---------------------------------------------------------------------
        // CREATE / DESTROY
        // ---------------------------------------------------------------------
        public override void create()
        {
            base.create();

            // 🔹 ESTE control lo debe pasar el contenedor (tab / form / host)
            // Ejemplo:
            // AttachControl(hostPanel);

            dw_1 = new dw_1();
            pb_insertar = new pb_insertar();
            pb_borrar = new pb_borrar();

            dw_1.LostFocus += (_, __) => dw_1.AcceptText();

            Controls.Add(dw_1);
            Controls.Add(pb_insertar);
            Controls.Add(pb_borrar);
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

            dw_1.uof_setdataobject(f_ProxParam(arg_s_pag.Parametros));
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

            if (is_accion == "A")
            {
                dw_1.InsertRow(0);
            }
            else if (dw_1.uof_retrieve(is_parametros) < 1)
            {
                dw_1.InsertRow(0);
            }

            dw_1.uof_edicion(0, "E");

            int cant_claves = dw_1.ii_claves.Length;
            int cant_param = is_parametros.Length;

            for (int iAux = 1; iAux <= cant_param; iAux++)
            {
                if (cant_claves >= iAux)
                    dw_1.uof_edicion(dw_1.ii_claves[iAux - 1], "N");
            }
        }

        // ---------------------------------------------------------------------
        // UE_ACOMODAR_OBJETOS
        // ---------------------------------------------------------------------
        public override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            SetRedraw(false);

            dw_1.Width = Math.Min(
                dw_1.uof_ancho(),
                Width - s_esp.borde * 3 - pb_insertar.Width
            );

            int ancho = dw_1.Width + pb_insertar.Width;
            dw_1.X = (Width - ancho) / 2 - 10;

            dw_1.Height = dw_1.cant_filas == 1
                ? Math.Min(dw_1.uof_largo(), Height - s_esp.borde * 2)
                : Height - s_esp.borde * 2;

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
                if (dw_1.GetItemStatus(iAux, 0, dwbuffer.Primary) == dwitemstatus.NewModified)
                {
                    if (dw_1.uof_setclaves(sarg_param, iAux) != 1)
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


      
    }

    public class dw_1 : uo_dw
    {
    }
}
