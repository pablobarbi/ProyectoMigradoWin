using System;
using System.Windows.Forms;
using Minotti.Controls;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_seleccion_n_filas.srw
    // Herencia original: from w_response
    public partial class w_seleccion_n_filas : w_response
    {
        // Variables PB (mismos nombres)
        public uo_dw dw_1;

        public w_seleccion_n_filas()
        {
            InitializeComponent();
        }

        // ===== Eventos PB detectados en el SRW =====
        // pb_continuar::clicked -> Parent.TriggerEvent("ue_continuar")
        // pb_cancelar::clicked  -> Parent.TriggerEvent("ue_cancelar")

        // En nuestra base w_response ya mapea los clicks a ue_*,
        // pero replicamos el enganche por si hay herencias que dependan de ello.
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.pb_continuar != null)
                this.pb_continuar.Click += (s, ev) => this.ue_continuar();
            if (this.pb_cancelar != null)
                this.pb_cancelar.Click += (s, ev) => this.ue_cancelar();
        }
    }
}
