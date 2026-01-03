using System;
using System.Windows.Forms;
using Minotti.Controls;
using Minotti.Models;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_seleccion_fila_dddw.srw (window) desde w_sheet
    // Mantengo el nombre del tipo: w_seleccion_fila_dddw
    // Base: uso w_operacion para compatibilidad con tus otras ventanas (w_sheet aún no migrada).
    public partial class w_seleccion_fila_dddw : w_operacion
    {
        // ===== Variables PB (mismos nombres) =====
        public cat_seleccion_row at_seleccion_row;
        public string is_nombre_columna = string.Empty;
        public string is_nombre_col_desc = string.Empty;
        public long il_q_filas;

        // Emulación de Message.PowerObjectParm para pasar parámetros de apertura
        public object Message_PowerObjectParm { get; set; }

        public w_seleccion_fila_dddw()
        {
            InitializeComponent();
        }

        // ===== Eventos PB =====

        // event ue_leer_parametros;
        public override void ue_leer_parametros()
        {
            // at_seleccion_row = Message.PowerObjectParm
            at_seleccion_row = this.Message_PowerObjectParm as cat_seleccion_row;

            // dw_buscar.SetTransObject(SQLCA) // pendiente si necesitás ejecutar SQL
            // dw_buscar.InsertRow(0)
            try
            {
                dw_buscar.InsertRow(0);
            }
            catch { /* el control uo_dw implementará InsertRow; si no, ignorar */ }
        }

        // event closequery;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // En PB se suelen validar cambios aquí; dejamos el cierre simple.
        }

        // Handlers de botones (equivalentes a 'clicked')
        private void cb_ok_Click(object? sender, EventArgs e)
        {
            // En PB arma la selección y cierra. Aquí devolvemos OK.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cb_cancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ===== Funciones PB (mismo nombre y firma) =====
        // public function integer wf_buscar_fila ()
        public int wf_buscar_fila()
        {
            // Stub: aquí se buscaría la fila en dw_seleccion según dw_buscar.
            return 1;
        }

        // Mapear doble clic en la grilla a aceptar (en PB: doubleclicked)
        private void dw_seleccion_DoubleClick(object? sender, EventArgs e)
        {
            cb_ok_Click(sender, e);
        }

        // Convocar a 'ue_leer_parametros' al abrir
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ue_leer_parametros();
        }
    }
}
