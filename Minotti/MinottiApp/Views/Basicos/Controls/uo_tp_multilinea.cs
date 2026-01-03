using System;
using System.Windows.Forms;
using System.Drawing;
using Minotti.Data;
using Minotti.Views.Basicos.Models;
using Minotti.utils;
using Minotti.Functions;


namespace Minotti.Views.Basicos.Controls
{
    /// <summary>
    /// Equivalente a: global type uo_tp_multilinea from uo_tp
    /// Página con una DW multilinea + botones Insertar/Borrar.
    /// </summary>
    public class uo_tp_multilinea : uo_tp
    {
        // =========================
        // Controles
        // =========================

        public uo_dw dw_1 { get; private set; }
        public Button pb_insertar { get; private set; }
        public Button pb_borrar { get; private set; }

        // =========================
        // Constructor
        // =========================

        public uo_tp_multilinea()
        {
            // Altura por defecto similar a PB
            this.Height = 977;

            // DW
            dw_1 = new uo_dw
            {
                Left = 83,
                Top = 29,
                TabIndex = 0
            };
            dw_1.Parent = this;

            // pb_insertar
            pb_insertar = new Button
            {
                Left = 1317,
                Top = 109,
                Width = 293,
                Height = 105,
                Text = "&Insertar",
                TabIndex = 1
            };
            pb_insertar.Click += (s, e) => ue_insertar();
            pb_insertar.Parent = this;

            // pb_borrar
            pb_borrar = new Button
            {
                Left = 1313,
                Top = 297,
                Width = 293,
                Height = 105,
                Text = "&Borrar",
                TabIndex = 2
            };
            pb_borrar.Click += (s, e) => ue_borrar();
            pb_borrar.Parent = this;

            // En PB: event losefocus; dw_1.AcceptText()
            dw_1.Leave += (s, e) =>
            {
                dw_1.AcceptText();
            };
        }

        // =========================
        // Eventos PB -> métodos
        // =========================

        /// <summary>
        /// PB: event ue_seleccionado; call super; dw_1.SetFocus()
        /// </summary>
        public virtual void ue_seleccionado()
        {
            // si en uo_tp definís algo, lo llamás acá
            // base.ue_seleccionado(); // si existe

            if (dw_1 != null && !dw_1.IsDisposed)
                dw_1.Focus();
        }

        /// <summary>
        /// PB: event ue_insertar; 
        /// call super::ue_insertar;
        /// dw_1.SetRow(dw_1.InsertRow(0)); dw_1.SetFocus()
        /// </summary>
        public virtual void ue_insertar()
        {
            base.ue_insertar();

            int row = dw_1.InsertRow(0);
            if (row > 0)
            {
                dw_1.SetRow(row);
                dw_1.Focus();
            }
        }

        /// <summary>
        /// PB: event ue_borrar; call super::ue_borrar; dw_1.DeleteRow(0)
        /// </summary>
        public virtual void ue_borrar()
        {
            base.ue_borrar();
            dw_1.DeleteRow(0);
        }

        // =========================
        // uof_* tamaños / claves / cambios
        // =========================

        /// <summary>
        /// PB: uof_ancho(): dw_1.uof_ancho() + s_esp.borde * 3 + pb_insertar.Width
        /// </summary>
        public override int uof_ancho()
        {
            return dw_1.uof_ancho() + s_esp.borde * 3 + pb_insertar.Width;
        }

        /// <summary>
        /// PB: uof_largo(): dw_1.uof_largo() + s_esp.borde * 2
        /// </summary>
        public override int uof_largo()
        {
            return dw_1.uof_largo() + s_esp.borde * 2;
        }

        /// <summary>
        /// PB: uof_getclaves(ref string parametros[], integer fila)
        /// Return(dw_1.uof_GetClaves(parametros[], fila))
        /// </summary>
        public virtual bool uof_getclaves(string[] parametros, int fila)
        {
            return dw_1.uof_getclaves(parametros, fila);
        }

        /// <summary>
        /// PB: uof_setclaves(string parametros[])
        /// Recorre filas NewModified y setea parámetros en las primeras columnas.
        /// </summary>
        public virtual void uof_setclaves(string[] parametros)
        {
            if (parametros == null || parametros.Length == 0)
                return;

            int rowCount = dw_1.RowCount();
            for (int row = 1; row <= rowCount; row++)
            {
                var status = dw_1.GetItemStatus(row, 0, dwbuffer.Primary);
                if (status == dwitemstatus.NewModified)
                {
                    for (int i = 1; i <= parametros.Length; i++)
                    {
                        string valor = parametros[i - 1]; // PB 1-based → C# 0-based
                        dw_1.SetItem(row, i, valor);
                    }
                }
            }
        }

        /// <summary>
        /// PB: uof_cambios_pendientes():
        /// If dw_1.AcceptText() = -1 or dw_1.ModifiedCount() > 0 Then True
        /// </summary>
        public override bool uof_cambios_pendientes()
        {
            int ret = dw_1.AcceptText();
            if (ret == -1 || dw_1.ModifiedCount() > 0)
                return true;

            return false;
        }

        // =========================
        // Eventos de ciclo de vida
        // =========================

        /// <summary>
        /// PB: ue_leer_parametros(st_pagina_carpeta arg_s_pag)
        /// - setdataobject
        /// - SetTransObject
        /// - BorderStyle
        /// - uof_setdwimpresion
        /// - cant_filas
        /// </summary>
        public override void ue_leer_parametros(st_pagina_carpeta arg_s_pag)
        {
            base.ue_leer_parametros(arg_s_pag);

            string dataObject = f_ProxParam(arg_s_pag.parametros);
            string dwImpresion = f_ProxParam(arg_s_pag.parametros);
            string cantFilasStr = f_ProxParam(arg_s_pag.parametros);

            dw_1.uof_setdataobject(dataObject);
            dw_1.SetTransObject(SQLCA.Instance);

            dw_1.BorderStyle = BorderStyle.FixedSingle;

            dw_1.uof_setdwimpresion(dwImpresion);

            if (!int.TryParse(cantFilasStr, out int cantFilas))
                cantFilas = 0;
            dw_1.cant_filas = cantFilas;

            dw_1.SetTransObject(SQLCA.Instance);
        }

        /// <summary>
        /// PB: ue_iniciar(string arg_accion, string arg_param[])
        /// - si Alta: InsertRow
        /// - si Mod: Retrieve o InsertRow si no trae nada
        /// - uof_Edicion(0,'E') y bloquea claves que vienen en parámetros
        /// </summary>
        public override void ue_iniciar(string arg_accion, string[] arg_param)
        {
            base.ue_iniciar(arg_accion, arg_param);

            int cant_claves, cant_param;

            if (is_Accion == "A")
            {
                dw_1.InsertRow(0);
            }
            else
            {
                int cant = (int)dw_1.uof_retrieve(is_parametros ?? Array.Empty<string>());
                if (cant < 1)
                    dw_1.InsertRow(0);
            }

            // Pone editables todos los campos
            dw_1.uof_edicion(0, "E");

            // Calcula cuántas claves y cuántos parámetros
            cant_claves = dw_1.ii_claves?.Length ?? 0;
            cant_param = is_parametros?.Length ?? 0;

            for (int iAux = 1; iAux <= cant_param; iAux++)
            {
                if (cant_claves >= iAux)
                {
                    int colIndex = dw_1.ii_claves[iAux - 1];
                    // 'N' → no editable
                    dw_1.uof_edicion(colIndex, "N");
                }
            }
        }

        /// <summary>
        /// PB: ue_acomodar_objetos
        /// - ajusta ancho de dw_1
        /// - centra dw_1 + ubica botones a la derecha
        /// </summary>
        public override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            this.SuspendLayout();

            // Ancho máximo para la DW: Width - bordes - ancho botón
            int anchoMaxDW = this.Width - s_esp.borde * 3 - pb_insertar.Width;
            dw_1.Width = Math.Min(dw_1.uof_ancho(), anchoMaxDW);

            // Acomoda a lo ancho: ancho = dw + botón
            int anchoTotal = dw_1.Width + pb_insertar.Width;
            dw_1.Left = (this.Width - anchoTotal) / 2 - 10;

            // Alto
            if (dw_1.cant_filas == 1)
            {
                dw_1.Height = Math.Min(dw_1.uof_largo(), this.Height - s_esp.borde * 2);
            }
            else
            {
                dw_1.Height = this.Height - s_esp.borde * 2;
            }

            dw_1.Top = s_esp.borde;

            // Botones a la derecha
            pb_insertar.Left = dw_1.Left + dw_1.Width + s_esp.borde;
            pb_insertar.Top = dw_1.Top + 80;  // aproximación; podés ajustar

            pb_borrar.Left = pb_insertar.Left;
            pb_borrar.Top = pb_insertar.Top + pb_insertar.Height + 80;

            this.ResumeLayout(true);
        }

        /// <summary>
        /// PB: ue_confirmar(baux1, baux2) returns boolean
        /// If dw_1.Update(baux1,baux2) = 1 Then TRUE Else FALSE
        /// </summary>
        public override bool ue_confirmar(bool baux1, bool baux2)
        {
            base.ue_confirmar(baux1, baux2);

            int ret = dw_1.Update(baux1, baux2);
            return ret == 1;
        }

        /// <summary>
        /// PB: ue_completar_claves(string sarg_param[]) returns boolean
        /// Completa clave en filas NewModified.
        /// </summary>
        public override bool ue_completar_claves(string[] sarg_param)
        {
            base.ue_completar_claves(sarg_param);

            int rowCount = dw_1.RowCount();
            for (int i = 1; i <= rowCount; i++)
            {
                var status = dw_1.GetItemStatus(i, 0, dwbuffer.Primary);
                if (status == dwitemstatus.NewModified)
                {
                    int ret = dw_1.uof_setclaves(sarg_param, i);
                    if (ret != 1)
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// PB: ue_aceptar_datos() returns boolean
        /// If dw_1.AcceptText() <> 1 Then FALSE Else TRUE
        /// </summary>
        public override bool ue_aceptar_datos()
        {
            base.ue_aceptar_datos();

            if (dw_1.AcceptText() != 1)
                return false;

            return true;
        }

        /// <summary>
        /// PB: ue_reset; call super; dw_1.Reset()
        /// </summary>
        public override void ue_reset()
        {
            base.ue_reset();
            dw_1.Reset();
        }

        // =========================
        // Helper de parámetros estilo PB
        // =========================

        private static string f_ProxParam(string parametros)
        {
            // Tenés que implementar este helper global según tu migración de f_ProxParam PB.
            return f_proxparam.fproxparam(parametros);
        }
    }
}
