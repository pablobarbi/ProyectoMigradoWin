using System;
using System.Windows.Forms;
using Minotti.Controls;
using Minotti.Models;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_carga.srw (window) desde w_response
    // Mantiene el nombre del tipo: w_carga
    public partial class w_carga : Form
    {
        // Variables del SRW (mismos nombres)
        public uo_dw dw_1; // Datawindow que sirve para insertar la clave
        public str_w_seleccion astr_w_seleccion;

        // Eventos equivalentes a los PostEvent del PB hacia el padre
        public event EventHandler? UeContinuar; // 'ue_continuar'
        public event EventHandler? UeCancelar;  // 'ue_cancelar'

        public w_carga()
        {
            InitializeComponent();
        }

        // ===== Eventos PB mapeados =====
        // event pb_continuar::clicked; call super::clicked; Parent.PostEvent('ue_continuar')
        private void pb_continuar_Click(object? sender, EventArgs e)
        {
            // Disparamos el evento equivalente
            UeContinuar?.Invoke(this, EventArgs.Empty);
        }

        // event pb_cancelar::clicked; call super::clicked; Parent.PostEvent('ue_cancelar')
        private void pb_cancelar_Click(object? sender, EventArgs e)
        {
            UeCancelar?.Invoke(this, EventArgs.Empty);
        }

        // Exponemos métodos con los mismos nombres por compatibilidad si otro código los llama
        public void ue_continuar() => UeContinuar?.Invoke(this, EventArgs.Empty);
        public void ue_cancelar()  => UeCancelar?.Invoke(this, EventArgs.Empty);
    }
}
