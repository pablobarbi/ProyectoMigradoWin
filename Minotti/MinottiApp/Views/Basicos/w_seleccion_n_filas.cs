using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Basicos.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    // PB: global type w_seleccion_n_filas from w_response
    public partial class w_seleccion_n_filas : w_response
    {
        // PB: uo_dw dw_1
        //private uo_dw dw_1;

        // PB: cat_rw_seleccion atrw
        //private cat_rw_seleccion atrw;
        cat_rw_seleccion atrw = new();

        // PB: stp_w_seleccion stp
        private stp_w_seleccion stp;

        public w_seleccion_n_filas(stp_w_seleccion parametros) : this()
        {
            stp = parametros;
        }

        public w_seleccion_n_filas()
        {
            InitializeComponent();

            // dw_1 lo crea el designer
            // pb_continuar / pb_cancelar vienen de w_response

            // Eventos PB equivalentes
            pb_continuar.Click += pb_continuar_Click;
            pb_cancelar.Click += pb_cancelar_Click;

            this.Load += w_seleccion_n_filas_Load;
            this.FormClosed += w_seleccion_n_filas_FormClosed;
        }

        // ====================================================
        // Ciclo de vida / eventos "open/close" equivalentes
        // ====================================================

        private void w_seleccion_n_filas_Load(object? sender, EventArgs e)
        {
            // PB: ue_leer_parametros, ue_iniciar, ue_acomodar_objetos
            ue_leer_parametros();
            ue_iniciar();
            ue_acomodar_objetos();

            // Centrar como hace w_response
            wf_centrar_response();
        }

        private void w_seleccion_n_filas_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // PB: close; Message.PowerObjectParm = atrw
            this.Tag = atrw;
        }

        // ====================================================
        // Eventos "ue_*" migrados desde PB
        // ====================================================

        /// <summary>
        /// PB: event ue_leer_parametros
        /// </summary>
        public virtual void ue_leer_parametros()
        {
            // stp = Message.PowerObjectParm (aquí viene por constructor)

            // Título de la ventana
            this.Text = stp.titulo;

            // dw_1: dataobject / trans / modo selección / borde
            dw_1.uof_setdataobject(stp.dataobject);
            dw_1.SetTransObject(SQLCA.Connection);

            // PB: uof_marcar_seleccion(2)  -> selección múltiple
            dw_1.uof_marcar_seleccion(2);

            // Borde
            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.Fixed3D;

            // Cantidad de filas visibles
            dw_1.cant_filas = stp.cant_filas.Value;
        }

        /// <summary>
        /// PB: event ue_iniciar
        /// </summary>
        public virtual void ue_iniciar()
        {
            // PB: dw_1.uof_retrieve(stp.parametros[])
            dw_1.uof_retrieve(stp.parametros);

            if (dw_1.RowCount() <= 0)
            {
                pb_continuar.Enabled = false;

                if (string.IsNullOrWhiteSpace(stp.mensaje))
                {
                    MessageBox.Show("No existen datos!", "Atención!!!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(stp.mensaje, "Atención!!!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            dw_1.SetFocus();

            // Valor por defecto para retorno (PB: atrw.opcion = -1)
            if (atrw == null)
                atrw = new cat_rw_seleccion();

            atrw.opcion = -1;
        }

        /// <summary>
        /// PB: event ue_acomodar_objetos
        /// </summary>
        public override void ue_acomodar_objetos()
        {
            // integer espacio_botones, borde_boton
            int espacio_botones;
            int borde_boton;

            // Le doy tamaño a la datawindow y a la ventana
            dw_1.Height = dw_1.uof_largo();
            dw_1.Width = dw_1.uof_ancho();
            dw_1.Top = s_esp.borde;
            dw_1.Left = s_esp.borde;

            this.Height = dw_1.uof_largo() + 3 * s_esp.borde + pb_cancelar.Height + s_esp.largo;

            this.Width = Math.Max(
                dw_1.uof_ancho(),
                pb_cancelar.Width * 2 + s_esp.borde
            ) + 2 * s_esp.borde + s_esp.ancho;

            // Acomodo los botones
            pb_cancelar.Top = dw_1.Top + dw_1.Height + s_esp.borde;
            pb_continuar.Top = pb_cancelar.Top;

            espacio_botones = (int)((this.Width - pb_cancelar.Width * 2 - s_esp.borde) / 2.0);

            borde_boton = (int)(espacio_botones * 0.6);

            pb_continuar.Left = borde_boton;
            pb_cancelar.Left = this.Width - borde_boton - pb_cancelar.Width;
        }

        /// <summary>
        /// PB: event ue_dw_detalle
        /// </summary>
        public virtual void ue_dw_detalle()
        {
            int row;
            int i = 1;
            string[] param;

            // PB: atrw.opcion = 1
            atrw.opcion = 1;

            // PB: row = dw_1.GetSelectedRow(0)
            row = dw_1.GetSelectedRow(0);

            while (row > 0)
            {
                param = Array.Empty<string>();

                // PB: dw_1.uof_getargumentos(param[], row)
                dw_1.uof_getargumentos(param, row);

                // PB: atrw.atr[i].s_det[] = param[]
                atrw.atr.EnsureIndex(i - 1);
                atrw.atr[i - 1].s_det = param;

                row = dw_1.GetSelectedRow(row);
                i++;
            }

            // PB: Close(this)
            this.Close();
        }


        /// <summary>
        /// PB: event ue_cancelar
        /// </summary>
        public virtual void ue_cancelar()
        {
            atrw.opcion = -1;
            this.Close();
        }

        /// <summary>
        /// PB: event ue_continuar
        /// </summary>
        public virtual void ue_continuar()
        {
            ue_dw_detalle();
        }

        // ====================================================
        // Handlers de botones (equivalentes a clicked PB)
        // ====================================================

        private void pb_continuar_Click(object? sender, EventArgs e)
        {
            ue_continuar();
        }

        private void pb_cancelar_Click(object? sender, EventArgs e)
        {
            ue_cancelar();
        }
    }

    //// Helper para no romper el estilo PB (podés ajustarlo a tu struct real)
    //public class cat_rw_seleccion
    //{
    //    public int opcion;
    //    public cat_rw_item[] atr = Array.Empty<cat_rw_item>();

    //    public void EnsureIndex(int index1Based)
    //    {
    //        if (atr == null) atr = Array.Empty<cat_rw_item>();
    //        int needed = index1Based;
    //        if (atr.Length < needed)
    //        {
    //            Array.Resize(ref atr, needed);
    //            for (int i = 0; i < atr.Length; i++)
    //            {
    //                if (atr[i] == null) atr[i] = new cat_rw_item();
    //            }
    //        }
    //    }
    //}

    //public class cat_rw_item
    //{
    //    public string[] s_det = Array.Empty<string>();
    //} 
}
