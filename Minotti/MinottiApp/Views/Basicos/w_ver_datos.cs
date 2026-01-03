using Minotti.Data;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Basicos.Models;
using System;
using System.Windows.Forms;


namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_ver_datos.srw
    // En PB: global type w_ver_datos from w_response
    public partial class w_ver_datos : w_response
    {
        // Controles PB
        private uo_dw dw_1;
        private str_w_seleccion s_w_sel;
        private stp_w_seleccion stp;

        public w_ver_datos()
        {
            InitializeComponent();
        }

        // =====================================================
        // Equivalentes de eventos PB
        // =====================================================

        // ue_dw_detalle
        public virtual void ue_dw_detalle()
        {
            // PB:
            // s_w_sel.opcion = 1
            // CloseWithReturn(This, s_w_sel)

            s_w_sel.opcion = 1;

            // Acá deberías implementar el mecanismo equivalente
            // a CloseWithReturn (ej: una propiedad estática, diálogo, etc.)
            this.Tag = s_w_sel; // ejemplo simple
            this.Close();
        }

        // ue_acomodar_objetos
        public  override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            if (dw_1 == null || pb_continuar == null || pb_cancelar == null)
                return;

            // Le doy tamaño a la datawindow y a la ventana
            dw_1.Height = dw_1.uof_largo();
            dw_1.Width = dw_1.uof_ancho();
            dw_1.Top = s_esp.borde;
            dw_1.Left = s_esp.borde;

            this.Height = dw_1.uof_largo() + 3 * s_esp.borde + pb_cancelar.Height + s_esp.largo;
            this.Width = Math.Max(dw_1.uof_ancho(), pb_cancelar.Width * 2 + s_esp.borde)
                          + 2 * s_esp.borde + s_esp.ancho;

            // Acomodo los botones
            pb_cancelar.Top = dw_1.Top + dw_1.Height + s_esp.borde;
            pb_continuar.Top = pb_cancelar.Top;

            int espacio_botones = (int)((this.Width - pb_cancelar.Width * 2 - s_esp.borde) / 2.0);
            int borde_boton = (int)(espacio_botones * 0.6);

            pb_continuar.Left = borde_boton;
            pb_cancelar.Left = this.Width - borde_boton - pb_cancelar.Width;
        }

        // ue_cancelar
        public  override void ue_cancelar()
        {
            base.ue_cancelar();

            // PB: CloseWithReturn(This, s_w_sel)
            this.Tag = s_w_sel;
            this.Close();
        }

        // ue_continuar
        public  override void ue_continuar()
        {
            base.ue_continuar();
            // PB: this.Event Trigger ue_dw_detalle(dw_1)
            ue_dw_detalle();
        }

        // close
        protected  override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // PB:
            // If IsValid(dw_1) Then CloseUserObject(dw_1)  
            // CloseWithReturn(This, s_w_sel)

            // En WinForms la destrucción del control se maneja solo,
            // sólo replicamos el "return" del objeto.
            this.Tag = s_w_sel;
        }

        // ue_leer_parametros
        public  override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            // PB:
            // stp = Message.PowerObjectParm

            // En C# tenés que asignar stp antes de mostrar la ventana.
            // Ej: form.stp = ...; form.ShowDialog();
            // Aquí asumimos que ya viene cargado externamente.

            // this.title = stp.titulo
            this.Text = stp.titulo;

            // Lee el nombre de la lista
            // PB:
            // OpenUserObject(dw_1, stp.objeto)
            // dw_1.uof_setdataobject(stp.dataobject)
            // dw_1.SetTransObject(SQLCA)
            // dw_1.Border = TRUE
            // dw_1.BorderStyle=StyleLowered!
            // dw_1.cant_filas = stp.cant_filas

            // En C# asumimos que dw_1 ya es el user control creado en InitializeComponent
            dw_1.uof_setdataobject(stp.dataobject);
            dw_1.SetTransObject(SQLCA.Instance); // ajustá a tu implementación

            // Si tenés propiedades equivalentes de borde, se setean aquí.

            dw_1.cant_filas = stp.cant_filas.Value;
        }

        // ue_iniciar
        public  override void ue_iniciar()
        {
            base.ue_iniciar();

            // PB:
            // dw_1.uof_retrieve(stp.parametros[])
            // If dw_1.RowCount() <= 0 Then
            //   pb_continuar.Enabled = False
            //   If IsNull(stp.mensaje) or Trim(stp.mensaje) = '' Then
            //      MessageBox("Atención!!!","No existen datos!",Information!)
            //   Else
            //      MessageBox("Atención!!!",stp.mensaje,Information!)
            //   End If
            // End If
            //
            // s_w_sel.opcion = -1
            // dw_1.SetFocus()

            int rows = (int)dw_1.uof_retrieve(stp.parametros);

            if (rows <= 0)
            {
                pb_continuar.Enabled = false;

                string mensaje = string.IsNullOrWhiteSpace(stp.mensaje)
                    ? "No existen datos!"
                    : stp.mensaje;

                MessageBox.Show(mensaje, "Atención!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            s_w_sel.opcion = -1;
            dw_1.Focus();
        }

        // =====================================================
        // Helpers para inyectar parámetros / recoger retorno
        // (opcionales, pero prácticos)
        // =====================================================

        public void SetParametros(stp_w_seleccion parametros)
        {
            stp = parametros;
        }

        public str_w_seleccion GetResultado()
        {
            return s_w_sel;
        }
    }
}
