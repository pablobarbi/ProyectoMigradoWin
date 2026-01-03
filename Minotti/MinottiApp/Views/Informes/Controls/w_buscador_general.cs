using Minotti.utils;
using Minotti.Views.Pbl.Views;
using Minotti.Views.Reportes.Controls;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Minotti.Views.Informes.Controls
{
    // Migrado desde PowerBuilder Window: w_buscador_general.srw
    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.
    public partial class w_buscador_general : w_tab_reporte_header
    {
        public w_buscador_general()
        {
            InitializeComponent();
        }

        // =====================================================
        // PB: event ue_iniciar (ANCESTOR SCRIPT OVERRIDE)
        // "dejo a la datawindow de cabecera como parametro"
        // =====================================================
        public override void ue_iniciar()
        {
            // NO llama a super (en PB no hay call super en este ue_iniciar)
            // cargo la DW de encabezado.
            dw_1.InsertRow(0);
        }

        // =====================================================
        // PB: event activate
        // =====================================================
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            // m_mdi.m_operaciones.m_procesar.Enabled = True
            PBGlobals.m_mdi.m_procesar.Enabled = true;
        }

        // =====================================================
        // PB: event ue_procesar
        // =====================================================
        public override void ue_procesar()
        {
            base.ue_procesar();

            string campo;
            string[] param;

            dw_1.AcceptText();
            campo = dw_1.GetItemString(1, "campo");

            if (campo == null || campo.Trim().Length < 1)
            {
                MessageBox.Show(
                    "Es necesario ingresar una o mas palabras para la busqueda.",
                    "Buscador General",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // PB: param[1] = campo  (arrays 1-based)
            param = new string[2];
            param[1] = campo;

            // PB: tab_1.Event Trigger ue_iniciar('M', param[])
            tab_1.TriggerEvent("ue_iniciar", "M", param);
        }

        // =====================================================
        // PB: event ue_acomodar_objetos (ANCESTOR SCRIPT OVERRIDE)
        // =====================================================
        public override void ue_acomodar_objetos()
        {
            // PB no llama super
            int ancho_para_dw;
            int largo_para_tab;

            this.SuspendLayout();

            // Ajusta tamaño de dw_1
            ancho_para_dw = this.Width - s_esp.ancho - 2 * s_esp.borde;

            dw_1.Width = Math.Min(dw_1.uof_ancho(), ancho_para_dw);
            dw_1.Height = dw_1.uof_largo();
            dw_1.Left = s_esp.borde;
            dw_1.Top = s_esp.borde;

            // Ajusta tamaño de tab_1
            largo_para_tab = this.Height - dw_1.Height - s_esp.largo - 4 * s_esp.borde;

            tab_1.TriggerEvent("ue_resize", dw_1.Width, largo_para_tab);
            tab_1.Left = s_esp.borde;
            tab_1.Top = dw_1.Top + dw_1.Height + s_esp.borde;

            this.ResumeLayout(true);
        }

        // =====================================================
        // PB: event ue_ajustar_tamaño
        // =====================================================
        public override void ue_ajustar_tamaño()
        {
            // PB comenta el width por tab y usa dw_1
            this.Height = tab_1.uof_largo() + s_esp.largo + 4 * s_esp.borde;
            this.Width = dw_1.uof_ancho() + 4 * s_esp.borde;
        }
    }
}