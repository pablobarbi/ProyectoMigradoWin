using Minotti.Data;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Basicos.Models;
using System;
using System.Windows.Forms;
namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_seleccion_share.srw
    // Herencia: from w_response (ajustable si me pasás la base exacta)
    // PB: global type w_seleccion_share from w_response
    public partial class w_seleccion_share : w_response
    {
        // Controles PB
        // uo_dw dw_1
        private uo_dw dw_1;

        // str_w_seleccion s_w_sel
        private str_w_seleccion s_w_sel;

        // stp_w_seleccion_share stp
        private stp_w_seleccion_share stp;

        // uo_dw dwAux
        private uo_dw dwAux;

        // uo_ds dsAux
        private uo_ds dsAux;

        public w_seleccion_share(stp_w_seleccion_share parametros) : this()
        {
            stp = parametros;
        }

        public w_seleccion_share()
        {
            InitializeComponent();

            // dw_1 lo instancia el Designer
            // pb_continuar / pb_cancelar vienen de w_response

            pb_continuar.Click += pb_continuar_Click;
            pb_cancelar.Click += pb_cancelar_Click;

            this.Load += w_seleccion_share_Load;
            this.FormClosed += w_seleccion_share_FormClosed;
        }

        // =====================================================
        // Ciclo de vida (equiv. open/close PB)
        // =====================================================

        private void w_seleccion_share_Load(object? sender, EventArgs e)
        {
            // En PB: ue_leer_parametros, ue_iniciar, ue_acomodar_objetos, wf_centrar_response
            ue_leer_parametros();
            ue_iniciar();
            ue_acomodar_objetos();
            wf_centrar_response();
        }

        private void w_seleccion_share_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // PB: close; CloseWithReturn(This, s_w_sel)
            this.Tag = s_w_sel;
        }

        // =====================================================
        // Eventos "ue_*" migrados
        // =====================================================

        /// <summary>
        /// PB: event ue_dw_detalle
        /// </summary>
        public  virtual void ue_dw_detalle()
        {
            // s_w_sel.opcion = 1
            if (s_w_sel == null)
                s_w_sel = new str_w_seleccion();

            s_w_sel.opcion = 1;

            // dw_1.uof_getargumentos(s_w_sel.s_det[], dw_1.GetRow())
            int currentRow = dw_1.GetRow();
            string[] det = Array.Empty<string>();
            dw_1.uof_getargumentos(det, currentRow);
            s_w_sel.s_det = det;

            // CloseWithReturn(This, s_w_sel)
            this.Tag = s_w_sel;
            this.Close();
        }

        /// <summary>
        /// PB: event ue_acomodar_objetos
        /// </summary>
        public  virtual void ue_acomodar_objetos()
        {
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
        /// PB: event ue_cancelar
        /// </summary>
        public  virtual void ue_cancelar()
        {
            // CloseWithReturn(This, s_w_sel)
            this.Tag = s_w_sel;
            this.Close();
        }

        /// <summary>
        /// PB: event ue_continuar
        /// </summary>
        public  virtual void ue_continuar()
        {
            // this.Event Trigger ue_dw_detalle(dw_1)
            ue_dw_detalle();
        }

        /// <summary>
        /// PB: event ue_leer_parametros
        /// </summary>
        public  virtual void ue_leer_parametros()
        {
            // stp = Message.PowerObjectParm (viene por ctor)

            // Título de la ventana
            this.Text = stp.titulo;

            // Lee la lista (objeto/dw)
            // En PB: OpenUserObject(dw_1, stp.objeto)
            // En WinForms: dw_1 ya es un control, sólo seteamos DataObject.
            dw_1.uof_setdataobject(stp.dataobject);
            dw_1.SetTransObject(SQLCA.Connection);

            // Modo selección simple
            dw_1.uof_marcar_seleccion(1);

            // Borde
            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.Fixed3D;

            // Cantidad de líneas que va a mostrar
            dw_1.cant_filas = stp.cant_filas;
        }

        /// <summary>
        /// PB: event ue_iniciar
        /// </summary>
        public  virtual void ue_iniciar()
        {
            // PB:
            // stp.dw_share.function dynamic sharedata(dw_1)

            if (stp != null && stp.dw_share != null)
            {
                // Asumo que uo_dw expone un método ShareData análogo al PB sharedata()
                stp.dw_share?.share_data(dw_1);
            }

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

            // Seteo valor de cerrado por defecto
            if (s_w_sel == null)
                s_w_sel = new str_w_seleccion();

            s_w_sel.opcion = -1;
            dw_1.SetFocus();
        }

        // =====================================================
        // Handlers de botones (equivalente a clicked PB)
        // =====================================================

        private void pb_continuar_Click(object? sender, EventArgs e)
        {
            ue_continuar();
        }

        private void pb_cancelar_Click(object? sender, EventArgs e)
        {
            ue_cancelar();
        }
    }
}

