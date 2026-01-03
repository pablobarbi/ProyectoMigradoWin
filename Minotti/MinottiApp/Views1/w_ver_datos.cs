using System;
using System.Windows.Forms;
using Minotti.Controls;
using Minotti.Models;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_ver_datos.srw
    // En PB: global type w_ver_datos from w_response
    public partial class w_ver_datos : w_response
    {
        // Variables PB con los mismos nombres
        public uo_dw dw_1;
        public str_w_seleccion s_w_sel;
        public stp_w_seleccion stp;

        // Se referencia también 'dw_lista' en el SRW; lo declaramos para compilar
        public uo_dw dw_lista;

        public w_ver_datos()
        {
            InitializeComponent();
        }

        // ===== Eventos PB detectados (mismos nombres) =====
        public virtual void ue_dw_detalle() { /* stub */ }

        public override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();
            // Con Anchor/Dock ya se acomodan; si hay lógica exacta la agrego aquí.
        }

        public override void ue_cancelar()
        {
            base.ue_cancelar(); // cierra
        }

        public override void ue_continuar()
        {
            // En PB probablemente cierra con OK o devuelve selección
            this.DialogResult = DialogResult.OK;
            base.ue_continuar();
        }

        // event close;
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // Si el SRW tiene limpieza, la agrego aquí manteniendo nombres.
        }

        public override void ue_leer_parametros()
        {
            // Stub: cargar parámetros en s_w_sel/stp si el SRW lo hacía.
        }

        public override void ue_iniciar()
        {
            // Stub: inicialización equivalente a PB (ej. InsertRow en dw_1, retrieve, etc.)
        }
    }
}
