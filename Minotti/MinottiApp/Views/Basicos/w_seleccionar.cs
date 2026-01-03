using Minotti.Data;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Basicos.Models;
using System;
using System.Windows.Forms;
 
 

namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_seleccionar.srw
    // Hereda de w_response; ajusto si me pasás la base exacta.
    // PB: global type w_seleccionar from w_response
    public partial class w_seleccionar : w_response
    {
        // Controles PB
        // uo_dw dw_1
        public uo_dw dw_1;

        // str_w_seleccion s_w_sel
        public str_w_seleccion s_w_sel;

        // stp_w_seleccion stp
        public stp_w_seleccion stp;

        //public w_seleccionar(stp_w_seleccion parametros) : this()
        //{
        //    stp = parametros;
        //}

        public w_seleccionar()
        {
            InitializeComponent();

            // dw_1 lo crea el Designer
            // pb_continuar / pb_cancelar vienen de w_response

            pb_continuar.Click += pb_continuar_Click;
            pb_cancelar.Click += pb_cancelar_Click;

            this.Load += w_seleccionar_Load;
            this.FormClosed += w_seleccionar_FormClosed;
        }

        // =====================================================
        // Ciclo de vida
        // =====================================================

        private void w_seleccionar_Load(object? sender, EventArgs e)
        {
            // PB: ue_leer_parametros + ue_iniciar + ue_acomodar_objetos + wf_centrar_response
            ue_leer_parametros();
            ue_iniciar();
            ue_acomodar_objetos();
            wf_centrar_response();
        }

        private void w_seleccionar_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // PB: close; Message.PowerObjectParm = s_w_sel
            this.Tag = s_w_sel;
        }

        // =====================================================
        // Eventos "ue_*" migrados
        // =====================================================

        /// <summary>
        /// PB: event ue_dw_detalle (en PB está comentado; lo dejamos vacío)
        /// </summary>
        public  virtual void ue_dw_detalle()
        {
            // s_w_sel.opcion = 1;
            // dw_1.uof_getargumentos(s_w_sel.s_det[], dw_1.GetRow());
            // Close(This);
        }

        /// <summary>
        /// PB: event ue_acomodar_objetos
        /// </summary>
        public  virtual void ue_acomodar_objetos()
        {
            int espacio_botones;
            int borde_boton;

            // Para que no se vuelva a ejecutar cuando cambia el tamaño
            ib_acomodar = false;

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

            // Centro la ventana response
            wf_centrar_response();
        }

        /// <summary>
        /// PB: event ue_cancelar
        /// </summary>
        public  virtual void ue_cancelar()
        {
            if (s_w_sel == null)
                s_w_sel = new str_w_seleccion();

            s_w_sel.opcion = -1;
            this.Close();
        }

        /// <summary>
        /// PB: event ue_continuar
        /// </summary>
        public  virtual void ue_continuar()
        {
            if (s_w_sel == null)
                s_w_sel = new str_w_seleccion();

            // s_w_sel.opcion = 1
            s_w_sel.opcion = 1;

            // dw_1.uof_getargumentos(s_w_sel.s_det[], dw_1.GetRow())
            int currentRow = dw_1.GetRow();
            string[] det = Array.Empty<string>();
            dw_1.uof_getargumentos(det, currentRow);
            s_w_sel.s_det = det;

            this.Close();
        }

        /// <summary>
        /// PB: event ue_leer_parametros
        /// </summary>
        public  virtual void ue_leer_parametros()
        {
            // stp = Message.PowerObjectParm (viene por ctor)

            // Título de la ventana
            this.Text = stp.titulo;

            // Lee el nombre de la lista
            // PB: OpenUserObject(dw_1, stp.objeto)
            // En WinForms: dw_1 ya es un control, sólo setea DataObject
            dw_1.uof_setdataobject(stp.dataobject);
            dw_1.SetTransObject(SQLCA.Connection);

            // Selección simple
            dw_1.uof_marcar_seleccion(1);

            // Borde
            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.Fixed3D;

            // Cantidad de líneas
            if (stp.cant_filas <= 0)
                dw_1.cant_filas = 1;
            else
                dw_1.cant_filas = stp.cant_filas.Value;

            // Seteo valor de cerrado por defecto
            if (s_w_sel == null)
                s_w_sel = new str_w_seleccion();

            s_w_sel.opcion = -1;
            dw_1.SetFocus();
        }

        /// <summary>
        /// PB: event ue_iniciar()
        /// </summary>
        public  virtual void ue_iniciar()
        {
            // Seteo valor de cerrado por defecto
            if (s_w_sel == null)
                s_w_sel = new str_w_seleccion();

            s_w_sel.opcion = -1;

            // dw_1.uof_retrieve(stp.parametros[])
            dw_1.uof_retrieve(stp.parametros);

            if (dw_1.RowCount() <= 0)
            {
                pb_continuar.Enabled = false;

                if (string.IsNullOrWhiteSpace(stp.mensaje))
                {
                    MessageBox.Show("No existen datos!", "¡Atención!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(stp.mensaje, "¡Atención!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Salgo de la ventana
                s_w_sel.opcion = -1;
                this.Close();
                return;
            }

            dw_1.SetFocus();
        }

        // =====================================================
        // Handlers botones (equiv. clicked PB)
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

    // ============================================================
    // STUBS de tipos usados (si ya los tenés, no los dupliques)
    // ============================================================

   

  

    //public class uo_dw : Control
    //{
    //    public int cant_filas;

    //    public bool Border { get; set; }
    //    public BorderStyle BorderStyle { get; set; }

    //    public void uof_setdataobject(string dataObject) { /* TODO */ }
    //    public void SetTransObject(object? conn) { /* TODO */ }
    //    public void uof_marcar_seleccion(int modo) { /* TODO */ }
    //    public int uof_largo() => Height;
    //    public int uof_ancho() => Width;
    //    public int RowCount => 0;
    //    public int GetRow() => 0;
    //    public void uof_getargumentos(ref string[] s_det, int row) { /* TODO */ }
    //    public void uof_retrieve(string[] parametros) { /* TODO */ }
    //}


}
