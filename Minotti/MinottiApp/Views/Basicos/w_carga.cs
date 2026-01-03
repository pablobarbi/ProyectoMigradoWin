using Minotti.Data;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Basicos.Models;
using MinottiApp.utils;
using System;
using System.Windows.Forms;


namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_carga.srw (window) desde w_response
    // Mantiene el nombre del tipo: w_carga
    // w_carga from w_response
    // global type w_carga from w_response
    // PB: global type w_carga from w_response
    public partial class w_carga : w_response
    {
        // PB variables
        public  uo_dw dw_1;                       // Datawindow que sirve para insertar la clave
        public  str_w_seleccion astr_w_seleccion; // retorno
        public  stp_w_seleccion astp_w_seleccion; // parámetros entrada

        public w_carga()
        {
            // PB: on w_carga.create -> call w_response::create
            // En WinForms, el constructor + InitializeComponent (si existe) cumple ese rol.
            // Si tu w_response tiene init propio, ya corre en base().
            astr_w_seleccion = new str_w_seleccion();
            astp_w_seleccion = new stp_w_seleccion();
        }

        // -----------------------------------------
        // PB event ue_acomodar_objetos
        // -----------------------------------------
        public virtual void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            int espacio_botones, borde_boton;

            /* Le doy tamaño a la datawindow y a la ventana */
            dw_1.Height = dw_1.uof_largo();
            //dw_1.Width = dw_1.uof_ancho() - 80  // le saco la barra de scroll
            dw_1.Width = dw_1.uof_ancho();
            dw_1.Y = s_esp.borde;
            dw_1.X = s_esp.borde;

            this.Height = dw_1.uof_largo() + 3 * s_esp.borde + pb_cancelar.Height + s_esp.largo;
            this.Width = Math.Max(dw_1.Width, pb_cancelar.Width * 2 + s_esp.borde) + 2 * s_esp.borde + s_esp.ancho;

            /* Acomodo los botones */
            pb_cancelar.Y = dw_1.Y + dw_1.Height + s_esp.borde;
            pb_continuar.Y = pb_cancelar.Y;

            espacio_botones = (int)((this.Width - pb_cancelar.Width * 2 - s_esp.borde) / 2.0);

            borde_boton = (int)(espacio_botones * 0.6);
            pb_continuar.X = borde_boton;
            pb_cancelar.X = this.Width - borde_boton - pb_cancelar.Width;

            this.wf_centrar_response();
        }

        // -----------------------------------------
        // PB event ue_cancelar
        // -----------------------------------------
        public virtual void ue_cancelar()
        {
            base.ue_cancelar();
            this.Close();
        }

        // -----------------------------------------
        // PB event ue_continuar
        // -----------------------------------------
        public virtual void ue_continuar()
        {
            base.ue_continuar();

            int cantidad, i; // (en PB están aunque no se usen)
            if (dw_1.AcceptText() < 0) return;

            astr_w_seleccion.opcion = 1;

            /*
              Obtengo los valores de:
                1) si es uo_dw devuelve claves
                2) si es uo_dw_filtro devuelve todo el registro
            */
            dw_1.uof_getargumentos(astr_w_seleccion.s_det, dw_1.GetRow());

            this.Close();
        }

        // -----------------------------------------
        // PB event close
        // -----------------------------------------
        protected  override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // if IsValid(dw_1) Then CloseUserObject(dw_1)
            if (dw_1 != null)
            {
                CloseUserObject(dw_1);
            }

            // Message.PowerObjectParm = astr_w_seleccion
            Minotti.utils.Message.PowerObjectParm = astr_w_seleccion;
        }

        // -----------------------------------------
        // PB event ue_iniciar
        // -----------------------------------------
        public virtual void ue_iniciar()
        {
            base.ue_iniciar();

            int campos, i, row;

            /* Inserto una Fila */
            row = dw_1.InsertRow(0);

            campos = UpperBoundPB(astp_w_seleccion.parametros);

            /* Inserto los valores de los campos en la Fila de la Dw */
            for (i = 1; i <= campos; i++)
            {
                // PB: If Not IsNull(astp_w_seleccion.parametros[i]) Then ...
                if (astp_w_seleccion.parametros != null &&
                    i >= 0 &&
                    i < astp_w_seleccion.parametros.Length &&
                    astp_w_seleccion.parametros[i] != null)
                {
                    dw_1.uof_setitem(row, i, astp_w_seleccion.parametros[i]);
                }
            }

            /* Datawindow toma foco */
            dw_1.SetFocus();
        }

        // -----------------------------------------
        // PB event ue_leer_parametros
        // -----------------------------------------
        public virtual void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            string param; // (en PB está aunque no se usa)

            /* Carga los parámetros en una variable auxiliar para no perder los originales */
            astp_w_seleccion = (stp_w_seleccion)Minotti.utils.Message.PowerObjectParm;

            /* Lee el nombre de la DataWindow de detalle */
            this.Text = astp_w_seleccion.titulo; // PB: This.Title

            // OpenUserObject(dw_1, astp_w_seleccion.objeto)
            dw_1 = (uo_dw)OpenUserObject(astp_w_seleccion.objeto);

            dw_1.uof_setdataobject(astp_w_seleccion.dataobject);
            dw_1.SetTransObject(SQLCA.Instance);

            if (astp_w_seleccion.cant_filas == null)
                dw_1.cant_filas = 1;
            else
                dw_1.cant_filas = astp_w_seleccion.cant_filas.Value;

            // Seteo el valor de retorno por defecto en falso
            astr_w_seleccion.opcion = -1;

            // Seteo el Borde de la dw
            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.Fixed3D; // PB: StyleLowered!
        }

        // -----------------------------------------
        // PB: pb_continuar::clicked => Parent.PostEvent('ue_continuar')
        // PB: pb_cancelar::clicked  => Parent.PostEvent('ue_cancelar')
        // -----------------------------------------
        protected  override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            pb_continuar.Click += (_, __) => DynamicEventInvoker.Post(this, "ue_continuar");
            pb_cancelar.Click += (_, __) => DynamicEventInvoker.Post(this, "ue_cancelar");
        }

        // PB UpperBound(array[]) típico 1-based (si tu migración usa 0-based, esto lo ajustamos en un minuto)
        private static int UpperBoundPB(string[]? arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            return arr.Length - 1;
        }

        // Estos 2 deben existir en tu infra (o en w_response / guo_app), no los invento:
        public  virtual object OpenUserObject(string objeto) => throw new NotImplementedException();
        public  virtual void CloseUserObject(object uo)
        {
            if (uo is IDisposable d) d.Dispose();
        }
    }
}
