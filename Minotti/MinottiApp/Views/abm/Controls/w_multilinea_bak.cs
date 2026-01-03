using Minotti.Data;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Pbl.Views;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Abm.Controls
{
    public partial class w_multilinea_bak : w_operacion
    {
        /* Controles */
        public uo_dw dw_1;
        public uo_dw dw_2;

        public Button pb_1;
        public Button pb_2;

        public w_multilinea_bak()
        {
            InitializeComponent();

            this.Load += (_, __) => OnCreatePB();
            this.FormClosing += (_, __) => close();
            this.Activated += (_, __) => activate();
        }

        // -------------------------------------------------
        // PB: on create
        // -------------------------------------------------
        private void OnCreatePB()
        {
            // call w_operacion::create -> ya ejecutado por la base

            if (pb_1 == null)
            {
                pb_1 = new Button
                {
                    Text = "&Agregar",
                    Width = 321,
                    Height = 117
                };
                pb_1.Click += (_, __) => ue_insertar_item();
                this.Controls.Add(pb_1);
            }

            if (pb_2 == null)
            {
                pb_2 = new Button
                {
                    Text = "&Eliminar",
                    Width = 321,
                    Height = 117
                };
                pb_2.Click += (_, __) => ue_borrar_item();
                this.Controls.Add(pb_2);
            }
        }

        // -------------------------------------------------
        // prototypes
        // -------------------------------------------------
        public bool wf_cambios_pendientes()
        {
            if (dw_1.AcceptText() == -1 || dw_1.ModifiedCount() > 0 ||
                dw_2.AcceptText() == -1 || dw_2.ModifiedCount() > 0 ||
                dw_2.DeletedCount() > 0)
                return true;

            return false;
        }

        // -------------------------------------------------
        // events
        // -------------------------------------------------

        public void ue_deshabilitar_clave()
        {
            base.ue_deshabilitar_clave();

            int cant_claves = dw_2.ii_claves.Length;

            for (int iAux = 0; iAux < cant_claves; iAux++)
            {
                if (dw_2.Describe("#" + dw_2.ii_claves[iAux] + ".Visible") == "1")
                {
                    dw_2.Modify(
                        "#" + dw_2.ii_claves[iAux] +
                        ".Protect='0~t If(IsRowNew(),0,1)'");
                }
            }
        }

        public void ue_insertar_item()
        {
            base.ue_insertar_item();

            int li_fila = dw_2.InsertRow(0);

            dw_2.SetRow(li_fila);
            dw_2.ScrollToRow(li_fila);
            dw_2.SetFocus();
        }

        public void ue_borrar_item()
        {
            base.ue_borrar_item();

            if (dw_2.RowCount() <= 0)
                return;

            dw_2.DeleteRow(0);
        }

        public void activate()
        {
            base.activate();

          PBGlobals.m_mdi.m_insertar.Enabled = false;
        }

        public void ue_ajustar_tamaño()
        {
            base.ue_ajustar_tamaño();

            dw_1.Top = s_esp.borde;
            dw_1.Height = dw_1.uof_largo();

            this.Width =
                Math.Max(dw_1.uof_ancho(), dw_2.uof_ancho())
                + s_esp.ancho + 2 * s_esp.borde;

            this.Height =
                dw_1.Height + dw_2.uof_largo()
                + s_esp.largo + 3 * s_esp.borde;
        }

        public void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            int ancho_para_dw =
                this.Width - s_esp.ancho - 3 * s_esp.borde - pb_1.Width;

            int largo_para_dw =
                (this.Height - s_esp.largo - 3 * s_esp.borde) / 2;

            /* Ajusta dw_1 */
            dw_1.Width = Math.Min(dw_1.uof_ancho(), ancho_para_dw);
            dw_1.Height = Math.Min(dw_1.uof_largo(), largo_para_dw);
            this.wf_centrarobjeto(dw_1);

            largo_para_dw = largo_para_dw * 2 - dw_1.Height;

            /* Ajusta dw_2 */
            dw_2.Height = Math.Min(dw_2.uof_largo(), largo_para_dw);
            dw_2.Width = Math.Min(dw_2.uof_ancho(), ancho_para_dw);
            dw_2.Top = dw_1.Top + dw_1.Height + s_esp.borde;
            this.wf_centrarobjeto(dw_2);

            /* Botones */
            pb_1.Left = dw_2.Left + dw_2.Width + s_esp.borde;
            pb_1.Top = dw_2.Top;

            pb_2.Left = pb_1.Left;
            pb_2.Top = pb_1.Top + pb_1.Height + s_esp.borde;
        }

        public void ue_confirmar()
        {
            base.ue_confirmar();

            if (dw_1.Update(true, false) != 1)
                ib_grabar = false;

            if (ib_grabar)
            {
                if (dw_2.Update(true, true) != 1)
                    ib_grabar = false;
            }

            if (ib_grabar)
                dw_1.ResetUpdate();
        }

        public void ue_iniciar()
        {
            base.ue_iniciar();

            if (at_op.Accion == "A")
            {
                dw_1.InsertRow(0);
                dw_1.uof_edicion(0, "E");
                dw_1.SetColumn(1);
                dw_2.InsertRow(0);
            }
            else
            {
                dw_1.uof_edicion("K", "N");
                dw_1.uof_edicion("D", "E");

                dw_1.uof_retrieve(at_op.s_det);
                dw_2.uof_retrieve(at_op.s_det);
            }

            ue_deshabilitar_clave();
            dw_1.SetFocus();
        }

        public void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            string param = at_op.uof_getparametros();

            /******************************************************************************
            Parámetros:   dw_control, dw_cabecera,
                          dw_control, dw_detalle,
                          cantidad de lineas en cabecera,
                          cantidad de lineas en detalle
            ******************************************************************************/

            OpenUserObject(dw_1, this.wf_proxparam(param));
            dw_1.uof_setdataobject(this.wf_proxparam( param));
            dw_1.SetTransObject(SQLCA.Instance);

            OpenUserObject( dw_2, this.wf_proxparam( param));
            dw_2.uof_setdataobject(this.wf_proxparam( param));
            dw_2.SetTransObject(SQLCA.Instance);

            dw_1.cant_filas = Convert.ToInt32(this.wf_proxparam(param));
            dw_2.cant_filas = Convert.ToInt32(this.wf_proxparam(param));

            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.Fixed3D;

            dw_2.Border = true;
            dw_2.BorderStyle = BorderStyle.Fixed3D;
            dw_2.SetRowFocusIndicator(RowFocusIndicator.Hand);
        }

        public void ue_optar()
        {
            base.ue_optar();

            if (dw_1.cant_filas == 0)
                dw_1.cant_filas = 1;

            if (dw_2.cant_filas == 0)
                dw_2.cant_filas = 10;
        }

        public void close()
        {
            base.close();

            if (dw_1 != null && !dw_1.IsDisposed)
                CloseUserObject(dw_1);

            if (dw_2 != null && !dw_2.IsDisposed)
                CloseUserObject(dw_2);
        }

        public int ue_dw_itemchanged()
        {
            base.ue_dw_itemchanged();
            return 0;
        }

        public void ue_validar_datos()
        {
            base.ue_validar_datos();

            long fila;
            int columna;

            if (dw_1.uof_datoscompletos(out fila, out columna))
            {
                if (dw_2.uof_datoscompletos(out fila, out columna))
                    return;

                if (fila > 0)
                {
                    dw_2.SetRow((int)fila);
                    dw_2.SetColumn(columna);
                    dw_2.SetFocus();
                }

                ib_grabar = false;
            }
            else
            {
                if (fila > 0)
                {
                    dw_1.SetRow((int)fila);
                    dw_1.SetColumn(columna);
                    dw_1.SetFocus();
                }

                ib_grabar = false;
            }
        }

        public void ue_completar_claves()
        {
            base.ue_completar_claves();

            string[] s_claves;
            dw_1.uof_getclaves(out s_claves, 1);

            int cantidad = dw_2.RowCount();

            for (int iAux = 1; iAux <= cantidad; iAux++)
            {
                var status = dw_2.GetItemStatus(iAux, 0, dwbuffer.Primary);
                if (status == dwitemstatus.NewModified)
                    dw_2.uof_setclaves(s_claves, iAux);
            }
        }

        public void ue_borrar()
        {
            base.ue_borrar();

            if (dw_1.DeleteRow(0) != 1)
                ib_grabar = false;

            if (ib_grabar)
            {
                if (dw_1.Update(true, true) != 1)
                {
                    ib_grabar = false;
                    dw_1.RowsMove(
                        1,
                        dw_1.DeletedCount(),
                        dwbuffer.Delete,
                        dw_1,
                        1,
                        dwbuffer.Primary);
                }
            }
        }

        public void ue_aceptar_datos()
        {
            base.ue_aceptar_datos();

            if (dw_1.AcceptText() != 1 || dw_2.AcceptText() != 1)
                ib_grabar = false;
        }
    }
}
