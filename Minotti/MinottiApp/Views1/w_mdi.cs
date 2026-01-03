using System;
using System.Windows.Forms;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_mdi.srw (MDI Frame) desde w_principal
    // Mantiene el nombre del tipo: w_mdi
    public partial class w_mdi : Form
    {
        // ===== Variables PB (mismos nombres) =====
        public string menuname = "m_mdi";

        // Emulación PB: seteo de mensaje en closequery
        public string Message_StringParm { get; private set; } = string.Empty;

        public w_mdi()
        {
            InitializeComponent();
            // WinForms: marcaremos el formulario como contenedor MDI
            this.IsMdiContainer = true;
        }

        // ===== Evento PB: closequery =====
        // En PB sólo setea Message.StringParm; aquí exponemos propiedad equivalente y dejamos que el caller cancele si quiere.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Message_StringParm = "Aplicación esta cerrando";
            // Si necesitás cancelar, podés setear e.Cancel = true desde afuera.
        }

        // ===== Evento/función PB: ue_mandar_menu_fondo(window w_actual) =====
        // Mantengo el nombre y la "firma" (mapear 'window' a Form).
        public void ue_mandar_menu_fondo(Form w_actual)
        {
            // En PB típicamente ajusta el menú de fondo con el actual.
            // En WinForms dejamos el MenuStrip principal (m_mdi) y, si hay MDI child, se asocia.
            if (w_actual != null)
            {
                w_actual.MdiParent = this;
            }
        }
    }
}
