using Minotti.Views.Basicos.Models;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_response_string.srw (window) desde w_response
    // Mantiene el nombre del tipo: w_response_string
    // PB: global type w_response_string from w_response
    public partial class w_response_string : w_response
    {
        // PB: cat_response_string    at_response_string
        public cat_response_string at_response_string { get; set; } = new cat_response_string();

        public w_response_string()
        {
            InitializeComponent();

            // Valor por defecto como en PB
            at_response_string.retorno = -1;

            // Enlazo los botones base al comportamiento de esta ventana
            pb_continuar.Click += pb_continuar_Click;
            pb_cancelar.Click += pb_cancelar_Click;

            this.Load += w_response_string_Load;
        }

        /// <summary>
        /// Equivalente al evento PB open, pero con el parámetro string.
        /// En PB: Message.StringParm, acá lo pasás explícito.
        /// </summary>
        /// <param name="param">Parámetros: título de la ventana (primer token).</param>
        public void InitializeWithParam(string param)
        {
            // En PB:
            // param = Message.StringParm
            // this.Title = f_ProxParam(param)
            // Como solo usan el título, podés simplificar a usar todo el string,
            // o si tenés un helper f_ProxParam, usarlo. Lo dejo directo:
            this.Text = param;

            // Setea retorno por defecto
            at_response_string.retorno = -1;

            // Centra la ventana response
            wf_centrar_response();
        }

        private void w_response_string_Load(object? sender, EventArgs e)
        {
            // Si querés, podés darle foco al editor acá
            editor.Focus();
        }

        // =========================
        //  Eventos PB convertidos
        // =========================

        // event ue_continuar; this.TriggerEvent ("ue_dw_detalle")
        public  override void ue_continuar()
        {
            base.ue_continuar();
            ue_dw_detalle();
        }

        // event ue_cancelar; This.TriggerEvent ("close")
        public  override void ue_cancelar()
        {
            base.ue_cancelar();
            this.Close();
        }

        // event ue_dw_detalle; at_response_string.retorno = 1; at_response_string.cadena = editor.Text; CloseWithReturn(...)
        public  virtual void ue_dw_detalle()
        {
            at_response_string.retorno = 1;
            at_response_string.cadena = editor.Text;

            // Emulación de CloseWithReturn(This, at_response_string)
            this.DialogResult = DialogResult.OK;
            this.Tag = at_response_string;
            this.Close();
        }

        // event close; CloseWithReturn(This,at_response_string)
        protected  override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // Si se cerró por cancelar y nadie tocó retorno, garantizo el valor actual
            if (this.Tag == null)
                this.Tag = at_response_string;
        }

        // =========================
        //  Handlers de los botones
        // =========================

        private void pb_continuar_Click(object? sender, EventArgs e)
        {
            ue_continuar();
        }

        private void pb_cancelar_Click(object? sender, EventArgs e)
        {
            // En PB: ue_cancelar → TriggerEvent("close") → CloseWithReturn
            // Acá simplemente llamamos ue_cancelar(), que hace Close().
            // El retorno queda en -1 (cancelado).
            at_response_string.retorno = -1;
            this.DialogResult = DialogResult.Cancel;
            ue_cancelar();
        }
    }
}
