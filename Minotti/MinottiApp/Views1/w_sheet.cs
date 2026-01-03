using System;
using System.Windows.Forms;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_sheet.srw (base window)
    // En PB: global type w_sheet from w_principal
    public partial class w_sheet : w_principal
    {
        public w_sheet()
        {
            InitializeComponent();
        }

        // ===== Eventos PB expuestos como métodos virtuales (mismos nombres) =====
        public virtual void ue_insertar() { }
        public virtual void ue_borrar() { }
        public virtual void ue_cancelar() { this.Close(); }
        public virtual void ue_primero() { }
        public virtual void ue_anterior() { }
        public virtual void ue_siguiente() { }
        public virtual void ue_ultimo() { }
        public virtual void ue_procesar() { }
        public virtual void ue_grabar() { }
        public virtual void ue_imprimir() { }
        public virtual void ue_buscar() { }
        public virtual void ue_terminar() { this.Close(); }
        public virtual void ue_optar() { }
        public virtual void ue_leer_parametros() { }

        // ===== Función auxiliar equivalente a PB =====
        // "Verifica que en la ventana no queden datos sin salvar"
        // En PB: wf_cambios_pendientes() -> boolean
        public virtual bool wf_cambios_pendientes() => false;

        // ===== Mapeo del fragmento de closequery visto en el SRW =====
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Si hay cambios pendientes, preguntamos
            if (wf_cambios_pendientes())
            {
                var respuesta = MessageBox.Show(
                    $"¿Desea guardar los cambios efectuados en {this.Text}?",
                    "Atención",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1
                );

                switch (respuesta)
                {
                    case DialogResult.Yes:
                        // En PB: This.PostEvent('ue_grabar') y retorna 1 (no cierra aún)
                        e.Cancel = true;
                        // Postear el evento de grabar después de cerrar el cuadro
                        this.BeginInvoke(new Action(() => ue_grabar()));
                        return;

                    case DialogResult.Cancel:
                        // En PB: Return 1 (no cierra)
                        e.Cancel = true;
                        return;

                    case DialogResult.No:
                        // Continúa el cierre
                        break;
                }
            }
        }
    }
}
