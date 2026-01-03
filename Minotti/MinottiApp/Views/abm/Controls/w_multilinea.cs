using Minotti.Data;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Abm.Controls
{
    public partial class w_multilinea : w_abm_detalle
    {
        /* Controles */
        public uo_dw dw_2;
        public PictureBox pb_1;
        public PictureBox pb_2;

        public w_multilinea()
        {
            InitializeComponent();

            // PB create/destroy
            this.Load += (_, __) => OnCreatePB();
            this.FormClosing += (_, __) => close();
        }

        // -------------------------------------------------
        // PB: on w_multilinea.create
        // -------------------------------------------------
        private void OnCreatePB()
        {
            // call w_abm_detalle::create -> ya ejecutado por base

            if (pb_1 == null)
            {
                pb_1 = new PictureBox();
                pb_1.SizeMode = PictureBoxSizeMode.AutoSize;
                pb_1.ImageLocation = FileUtils.GetAppFile("Pictures", "insertar.bmp");
                pb_1.Click += (_, __) => ue_insertar_item();
                this.Controls.Add(pb_1);
            }

            if (pb_2 == null)
            {
                pb_2 = new PictureBox();
                pb_2.SizeMode = PictureBoxSizeMode.AutoSize;
                pb_2.ImageLocation = FileUtils.GetAppFile("Pictures", "borrar.bmp");
                pb_2.Click += (_, __) => ue_borrar_item();
                this.Controls.Add(pb_2);
            }
        }

        // -------------------------------------------------
        // prototypes
        // -------------------------------------------------
        public bool wf_datos_completos()
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

        public void ue_borrar_item()
        {
            base.ue_borrar_item();

            /* Si no hay filas en dw_2, no hace nada */
            if (dw_2.RowCount() <= 0)
                return;

            /* Borra la fila actual */
            dw_2.DeleteRow(0);
        }

        public void ue_insertar_item()
        {
            base.ue_insertar_item();

            int li_fila;

            /* Inserta una fila en el detalle */
            li_fila = dw_2.InsertRow(0);

            /* Deja el cursor en la fila insertada */
            dw_2.SetRow(li_fila);
            dw_2.ScrollToRow(li_fila);
            dw_2.SetFocus();
        }

        public override void ue_aceptar_datos()
        {
            base.ue_aceptar_datos();

            if (dw_2.AcceptText() != 1)
                this.ib_grabar = false;
        }

        public override void ue_ajustar_tamaño()
        {
            /* Fija el tamaño inicial de la ventana */
            this.Width =
                Math.Max(dw_1.uof_ancho(),
                         dw_2.uof_ancho() + s_esp.borde + pb_1.Width)
                + s_esp.ancho + 2 * s_esp.borde;

            this.Height =
                dw_1.Height
                + dw_2.uof_largo()
                + s_esp.largo
                + 3 * s_esp.borde;
        }

        public override void ue_completar_claves()
        {
            base.ue_completar_claves();

            int iAux, cantidad;
            string[] s_claves;
            dwitemstatus status;

            /* Toma la clave de la cabecera */
            dw_1.uof_getclaves(out s_claves, 1);

            /* Inserta las claves en dw_2 para las filas nuevas */
            cantidad = dw_2.RowCount();

            for (iAux = 1; iAux <= cantidad; iAux++)
            {
                /* No lo hace para las filas sin datos cargados */
                status = dw_2.GetItemStatus(iAux, 0, dwbuffer.Primary);
                if (status == dwitemstatus.NewModified)
                {
                    dw_2.uof_setclaves(s_claves, iAux);
                }
            }
        }

        public override void ue_confirmar()
        {
            base.ue_confirmar();

            /* Si grabó correctamente la dw_1 */
            if (ib_grabar)
            {
                if (dw_2.Update(true, false) != 1)
                    ib_grabar = false;
            }
        }

        public override void ue_reiniciar()
        {
            base.ue_reiniciar();

            /* Si es un alta y debe quedarse en la ventana, la reinicia */
            if (this.at_op.Accion == "A")
            {
                dw_2.Reset();
            }
            else if (this.at_op.Accion == "M")
            {
                dw_2.ResetUpdate();
            }
        }

        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            string param;
            int iAux, cantidad;

            param = at_op.uof_getparametros();

            /******************************************************************************
            Parámetros:   dw_control, dw_cabecera, cantidad de lineas en cabecera,
                          dw_control, dw_detalle, cantidad de lineas en detalle
            ******************************************************************************/

            /* Lee el detalle */
            OpenUserObject(dw_2, this.wf_proxparam( param, 4));
            dw_2.uof_setdataobject(this.wf_proxparam( param));
            dw_2.SetTransObject(SQLCA.Instance);

            /* Lee la cantidad de líneas del detalle */
            dw_2.cant_filas = Convert.ToInt32(this.wf_proxparam( param));

            dw_2.Border = true;
            dw_2.BorderStyle = BorderStyle.Fixed3D;
            dw_2.SetRowFocusIndicator(RowFocusIndicator.Hand);

            cantidad = dw_2.ii_claves.Length;
            for (iAux = 0; iAux < cantidad; iAux++)
            {
                if (dw_2.Describe("#" + dw_2.ii_claves[iAux] + ".Visible") == "1")
                {
                    dw_2.Modify(
                        "#" + dw_2.ii_claves[iAux] +
                        ".Protect='0~t If(IsRowNew(),0,1)'");
                }
            }
        }

        public override void ue_iniciar()
        {
            base.ue_iniciar();

            if (at_op.Accion == "A")
            {
                dw_2.InsertRow(0);
            }
            else
            {
                dw_2.uof_retrieve(at_op.s_det);
            }

            dw_1.SetFocus();
        }

        public override void ue_optar()
        {
            base.ue_optar();

            if (dw_2.cant_filas == 0)
                dw_2.cant_filas = 10;
        }

        public override void ue_validar_datos()
        {
            base.ue_validar_datos();

            long fila;
            int columna;

            if (dw_2.uof_datoscompletos(out fila, out columna))
                return;

            if (fila > 0)
            {
                dw_2.SetRow((int)fila);
                dw_2.SetColumn(columna);
                dw_2.SetFocus();
            }

            this.ib_grabar = false;
        }

        public override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            /* Ubica el detalle */
            dw_2.Width =
                Math.Min(dw_2.uof_ancho(),
                         this.wf_ancho_disponible() - s_esp.borde - pb_1.Width);

            dw_2.Height =
                this.wf_largo_disponible() - dw_1.Height - s_esp.borde;

            dw_2.Top = dw_1.Top + dw_1.Height + s_esp.borde;
            this.wf_centrarobjeto(dw_2);

            dw_2.Left =
                dw_2.Left - ((s_esp.borde + pb_1.Width) / 2);

            /* Ubicar los botones agregar - eliminar */
            pb_1.Left = dw_2.Left + dw_2.Width + s_esp.borde;
            pb_1.Top = dw_2.Top;

            pb_2.Left = pb_1.Left;
            pb_2.Top = pb_1.Top + pb_1.Height + s_esp.borde;
        }

        public override void close()
        {
            base.close();

            if (dw_2 != null && !dw_2.IsDisposed)
                CloseUserObject(dw_2);
        }
    }
}
