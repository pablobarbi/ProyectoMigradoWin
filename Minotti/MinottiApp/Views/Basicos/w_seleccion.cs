
using Minotti.Data;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Basicos.Models;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_seleccion.srw (window) desde w_response
    // Mantiene el nombre del tipo: w_seleccion
    // PB: global type w_seleccion from w_response
    public partial class w_seleccion : w_response
    {
        // Controles / estructuras PB
        // uo_dw dw_1
        private uo_dw dw_1;

        // str_w_seleccion   s_w_sel
        private str_w_seleccion s_w_sel = new str_w_seleccion();

        // stp_w_seleccion  stp
        private stp_w_seleccion stp;

        public w_seleccion()
        {
            InitializeComponent();

            // Enlazo eventos de los botones base
            pb_continuar.Click += pb_continuar_Click;
            pb_cancelar.Click += pb_cancelar_Click;

            this.Load += w_seleccion_Load;
        }

        /// <summary>
        /// Equivalente al ue_leer_parametros + parte de ue_iniciar.
        /// Recibe la estructura STP_W_SELECCION.
        /// </summary>
        public void InitializeWithParam(stp_w_seleccion parametros)
        {
            // Carga los parámetros en una variable auxiliar
            stp = parametros;

            // this.title = stp.titulo
            this.Text = stp.titulo;

            // OpenUserObject(dw_1, stp.objeto)
            // En PB puede ser un userobject distinto, acá asumimos uo_dw único.
            // Si tenés diferentes tipos, acá podrías resolver por nombre.
            EnsureDwCreated();

            // dw_1.uof_setdataobject(stp.dataobject)
            dw_1.uof_setdataobject(stp.dataobject);
            dw_1.SetTransObject(SQLCA.Instance); // o tu wrapper de SQLCA

            dw_1.uof_marcar_seleccion(1);

            dw_1.BorderStyle = BorderStyle.FixedSingle; // Border = TRUE / StyleLowered!
            dw_1.cant_filas = stp.cant_filas.Value;

            // Valor por defecto de retorno
            s_w_sel.opcion = -1;
        }

        private void w_seleccion_Load(object? sender, EventArgs e)
        {
            // Emula ue_iniciar + acomodo + centrado
            ue_iniciar();
            ue_acomodar_objetos();
            wf_centrar_response();

            dw_1.Focus();
        }

        /// <summary>
        /// PB: event ue_iniciar
        /// </summary>
        public  virtual void ue_iniciar()
        {
            if (stp == null)
                return;

            // dw_1.uof_retrieve(stp.parametros[])
            int count = (int)dw_1.uof_retrieve(stp.parametros ?? Array.Empty<string>());

            if (count <= 0)
            {
                pb_continuar.Enabled = false;

                string msg = (stp.mensaje == null || string.IsNullOrWhiteSpace(stp.mensaje))
                    ? "No existen datos!"
                    : stp.mensaje;

                MessageBox.Show(this, msg, "Atención!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            s_w_sel.opcion = -1;
        }

        /// <summary>
        /// PB: event ue_dw_detalle; s_w_sel.opcion = 1; dw_1.uof_getargumentos(...); Close(This)
        /// </summary>
        public  virtual void ue_dw_detalle()
        {
            s_w_sel.opcion = 1;

            // En PB: dw_1.uof_getargumentos(s_w_sel.s_det[], dw_1.GetRow())
            // Asumo que uof_getargumentos devuelve un string[] o recibe ref.
            s_w_sel.s_det = dw_1.uof_getargumentos(dw_1.GetRow());

            // Emular CloseWithReturn(This, s_w_sel)
            this.Tag = s_w_sel;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// PB: ue_acomodar_objetos
        /// </summary>
        public  override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            if (dw_1 == null)
                return;

            int largo = dw_1.uof_largo();
            int ancho = dw_1.uof_ancho();

            // Le doy tamaño a la datawindow y a la ventana
            dw_1.Height = largo;
            dw_1.Width = ancho;
            dw_1.Top = s_esp.borde;
            dw_1.Left = s_esp.borde;

            this.Height = largo + 3 * s_esp.borde + pb_cancelar.Height + s_esp.largo;
            this.Width = Math.Max(ancho, pb_cancelar.Width * 2 + s_esp.borde) + 2 * s_esp.borde + s_esp.ancho;

            // Acomodo los botones
            pb_cancelar.Top = dw_1.Top + dw_1.Height + s_esp.borde;
            pb_continuar.Top = pb_cancelar.Top;

            int espacio_botones = (int)((this.Width - pb_cancelar.Width * 2 - s_esp.borde) / 2.0);

            int borde_boton = (int)(espacio_botones * 0.6);
            pb_continuar.Left = borde_boton;
            pb_cancelar.Left = this.Width - borde_boton - pb_cancelar.Width;
        }

        /// <summary>
        /// PB: ue_cancelar; s_w_sel.opcion = -1; Close(This)
        /// </summary>
        public  override void ue_cancelar()
        {
            base.ue_cancelar();

            s_w_sel.opcion = -1;
            this.Tag = s_w_sel;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// PB: ue_continuar; this.Event Trigger ue_dw_detalle(dw_1)
        /// </summary>
        public  override void ue_continuar()
        {
            base.ue_continuar();
            ue_dw_detalle();
        }

        // Emulación del event close; Message.PowerObjectParm = s_w_sel
        protected  override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (this.Tag == null)
                this.Tag = s_w_sel;
        }

        // ===================================
        // Handlers de botones (equivalente a PB)
        // ===================================

        private void pb_continuar_Click(object? sender, EventArgs e)
        {
            ue_continuar();
        }

        private void pb_cancelar_Click(object? sender, EventArgs e)
        {
            ue_cancelar();
        }

        // Crear dw_1 si no existe (reemplaza OpenUserObject)
        private void EnsureDwCreated()
        {
            if (dw_1 != null)
                return;

            dw_1 = new uo_dw
            {
                Name = "dw_1"
            };
            this.Controls.Add(dw_1);
            dw_1.BringToFront();
        }

        /// <summary>
        /// Helper para usarla igual que en PB (CloseWithReturn).
        /// </summary>
        public static str_w_seleccion ShowDialogSeleccion(IWin32Window owner, stp_w_seleccion parametros)
        {
            using (var frm = new w_seleccion())
            {
                frm.InitializeWithParam(parametros);
                frm.ShowDialog(owner);
                return (str_w_seleccion)frm.Tag!;
            }
        }
    }
}
