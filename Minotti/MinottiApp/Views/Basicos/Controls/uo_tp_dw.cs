
using Minotti.Data;
using Minotti.Functions;
using Minotti.utils;
using Minotti.Views.Basicos.Models;
using System;
using System.Linq;
using System.Windows.Forms;


namespace Minotti.Views.Basicos.Controls
{
    /// <summary>
    /// Equivalente a: global type uo_tp_dw from uo_tp
    /// Página de carpeta que contiene una sola uo_dw (dw_1).
    /// </summary>
    public class uo_tp_dw : uo_tp
    {
        // =========================
        // Controles
        // =========================

        public uo_dw dw_1 { get; private set; }

        // =========================
        // Constructor
        // =========================

        public uo_tp_dw()
        {
            // BackColor = 81324524 (aprox)
            this.BackColor = System.Drawing.Color.FromArgb(0x04, 0xD0, 0xEC); // ajustá si querés

            // Crear la DW principal
            dw_1 = new uo_dw
            {
                Left = 425,
                Top = 156
            };

            dw_1.Parent = this;
        }

        // =========================
        // Eventos PB -> métodos
        // =========================

        /// <summary>
        /// PB: event ue_seleccionado; call super::ue_seleccionado; dw_1.SetFocus()
        /// </summary>
        public virtual void ue_seleccionado()
        {
            // base vacío por defecto; si querés algo en uo_tp, lo agregás ahí
            // base.ue_seleccionado();  // si lo definís en uo_tp

            if (dw_1 != null && !dw_1.IsDisposed)
            {
                dw_1.Focus();
            }
        }

        // =========================
        // Overrides uof_* (tamaño / cambios / claves)
        // =========================

        /// <summary>
        /// PB: public function integer uof_ancho ();
        /// Return(dw_1.uof_ancho() + s_esp.borde * 2)
        /// </summary>
        public override int uof_ancho()
        {
            return dw_1.uof_ancho() + s_esp.borde * 2;
        }

        /// <summary>
        /// PB: public function integer uof_largo ();
        /// Return(dw_1.uof_largo() + s_esp.borde * 2)
        /// </summary>
        public override int uof_largo()
        {
            return dw_1.uof_largo() + s_esp.borde * 2;
        }

        /// <summary>
        /// PB: public function boolean uof_getclaves (ref string parametros[], integer fila)
        /// Return(dw_1.uof_GetClaves(parametros[], fila))
        /// </summary>
        public virtual bool uof_getclaves(string[] parametros, int fila)
        {
            return dw_1.uof_getclaves(parametros, fila);
        }

        /// <summary>
        /// PB: public subroutine uof_setclaves (string parametros[])
        /// Recorre filas NewModified y setea los valores de los parámetros en las primeras columnas.
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
                        // En PB: SetItem(lAux, iAux, parametros[iAux])
                        string valor = parametros[i - 1]; // ojo: C# 0-based
                        dw_1.uof_setitem(row, i, valor);
                    }
                }
            }
        }

        /// <summary>
        /// PB: public function boolean uof_cambios_pendientes ();
        /// If dw_1.AcceptText() = -1 or dw_1.ModifiedCount() > 0 Then True...
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
        /// PB: event ue_leer_parametros; 
        /// call super::ue_leer_parametros;
        /// dw_1.uof_setdataobject(f_ProxParam(arg_s_pag.Parametros))
        /// ...
        /// </summary>
        public virtual void ue_leer_parametros(st_pagina_carpeta arg_s_pag)
        {
            base.ue_leer_parametros(arg_s_pag);

            // 1) DataObject de la DW
            string dataObject = f_ProxParam(arg_s_pag.parametros);
            dw_1.uof_setdataobject(dataObject);
            dw_1.SetTransObject(SQLCA.Instance);

            // 2) Estilo visual (border / box)
            dw_1.BorderStyle = BorderStyle.FixedSingle;

            // 3) DataWindow de impresión
            string dwImpresion = f_ProxParam(arg_s_pag.parametros);
            dw_1.uof_setdwimpresion(dwImpresion);

            // 4) Cantidad de filas
            string cantStr = f_ProxParam(arg_s_pag.parametros);
            if (!int.TryParse(cantStr, out int cantFilas))
                cantFilas = 0;

            dw_1.cant_filas = cantFilas;
            if (dw_1.cant_filas > 1)
            {
                // En PB: uof_marcar_seleccion(1)
                dw_1.uof_marcar_seleccion(1);
            }

            dw_1.SetTransObject(SQLCA.Instance);
        }

        /// <summary>
        /// PB: event ue_iniciar;
        /// call super::ue_iniciar;
        /// lógica de alta / modificación
        /// </summary>
        public override void ue_iniciar(string arg_accion, string[] arg_param)
        {
            base.ue_iniciar(arg_accion, arg_param);

            int cant_claves;
            // is_Accion e is_parametros están en la base uo_tp
            if (is_Accion == "A")   // Alta
            {
                // Inserta una fila
                int row = dw_1.InsertRow(0);

                // cant_claves = UpperBound(dw_1.ii_claves[])
                cant_claves = dw_1.ii_claves?.Length ?? 0;

                // Pone en la fila nueva las claves que vienen en parámetros
                if (is_parametros != null && is_parametros.Length > 0)
                {
                    for (int iAux = 1; iAux <= is_parametros.Length; iAux++)
                    {
                        if (cant_claves >= iAux)
                        {
                            int colIndex = dw_1.ii_claves[iAux - 1];  // ojo 0-based
                            dw_1.uof_setitem(row, colIndex, is_parametros[iAux - 1]);
                        }
                    }
                }

                // Setea foco en la "siguiente" columna
                dw_1.SetColumn(is_parametros?.Length + 1 ?? 1);
            }
            else // Modificación (M)
            {
                int cant = (int)dw_1.uof_retrieve(is_parametros ?? Array.Empty<string>());
                if (cant < 1)
                {
                    dw_1.InsertRow(0);
                }
            }
        }

        /// <summary>
        /// PB: event ue_confirmar(baux1, baux2) returns boolean
        /// call super::ue_confirmar;
        /// If dw_1.Update(baux1, baux2) = 1 Then True Else False
        /// </summary>
        public override bool ue_confirmar(bool baux1, bool baux2)
        {
            // base hace lo suyo (en tu uo_tp lo dejé como true)
            base.ue_confirmar(baux1, baux2);

            int ret = dw_1.Update(baux1, baux2);
            return ret == 1;
        }

        /// <summary>
        /// PB: event ue_acomodar_objetos;
        /// call super::ue_acomodar_objetos;
        /// centrar dw_1 según ancho/largo disponible + s_esp.borde
        /// </summary>
        public override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            // Ancho
            int anchoDisponible = this.Width - s_esp.borde * 2;
            dw_1.Width = Math.Min(dw_1.uof_ancho(), anchoDisponible);

            // Centrado horizontal (PB restaba 10)
            dw_1.Left = (this.Width - dw_1.Width) / 2 - 10;

            // Alto
            if (dw_1.cant_filas == 1)
            {
                int altoDisp = this.Height - s_esp.borde * 2;
                dw_1.Height = Math.Min(dw_1.uof_largo(), altoDisp);
            }
            else
            {
                dw_1.Height = this.Height - s_esp.borde * 2;
            }

            // Y
            dw_1.Top = s_esp.borde;
        }

        /// <summary>
        /// PB: event ue_completar_claves (string sarg_param[]) returns boolean
        /// Completa la clave en filas nuevas.
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
                    // PB: If dw_1.uof_SetClaves(sarg_param[], iAux) <> 1 Then Return(FALSE)
                    int ret = dw_1.uof_setclaves(sarg_param, i);
                    if (ret != 1)
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// PB: event ue_validar_datos returns boolean
        /// Usa dw_1.uof_datoscompletos(fila, columna)
        /// </summary>
        public override bool ue_validar_datos()
        {
            base.ue_validar_datos();

            long fila;
            int columna;

            // Asumo firma: bool uof_datoscompletos(out long fila, out int columna)
            if (!dw_1.uof_datoscompletos(out fila, out columna))
            {
                if (fila > 0)
                {
                    dw_1.SetRow((int)fila);
                    dw_1.SetColumn(columna);
                }
                return false;
            }

            return true;
        }

        /// <summary>
        /// PB: event ue_leer_claves (ref string sarg_param[]) returns boolean
        /// Si AcceptText() <> 1 => FALSE
        /// Devuelve claves de la primer fila.
        /// </summary>
        public override bool ue_leer_claves(string[] sarg_param)
        {
            base.ue_leer_claves(sarg_param);

            if (dw_1.AcceptText() != 1)
                return false;

            return dw_1.uof_getclaves(sarg_param, 1);
        }

        /// <summary>
        /// PB: event ue_aceptar_datos returns boolean
        /// If dw_1.AcceptText() <> 1 Then FALSE
        /// </summary>
        public override bool ue_aceptar_datos()
        {
            base.ue_aceptar_datos();

            if (dw_1.AcceptText() != 1)
                return false;

            return true;
        }

        /// <summary>
        /// PB: event ue_reset;
        /// call super::ue_reset; dw_1.Reset()
        /// </summary>
        public override void ue_reset()
        {
            base.ue_reset();
            dw_1.Reset();
        }

        /// <summary>
        /// PB: event ue_reiniciar;
        /// If is_accion = 'A' Then dw_1.Reset(); ue_iniciar(...)
        /// ElseIf is_accion = 'M' Then dw_1.ResetUpdate()
        /// </summary>
        public override void ue_reiniciar()
        {
            base.ue_reiniciar();

            if (is_Accion == "A")  // Alta
            {
                dw_1.Reset();
                ue_iniciar(is_Accion, is_parametros);
            }
            else if (is_Accion == "M") // Modificación
            {
                dw_1.ResetUpdate();
            }
        }

        // =========================
        // Helper esperado por PB
        // =========================
        //
        // En PB f_ProxParam va consumiendo parámetros dentro de un string.
        // Acá lo dejamos como llamada a una función global estática que
        // tenés que implementar según tu migración de f_ProxParam.
        //
        private static string f_ProxParam(string parametros)
        {
            // TODO: reemplazar por tu implementación real.
            return f_proxparam.fproxparam(parametros);
        }



        public virtual void ue_leer_parametros()
        {
            // PB default: no hace nada
        }

        // ===============================================================
        // PB Event: ue_imprimir
        // PB permite redefinir este evento en cualquier UserObject.
        // En C# debemos declararlo virtual para que las subclases lo overrideen.
        // ===============================================================
        public virtual void ue_imprimir()
        {
            // PB default: no hace nada
        }


    }
}
