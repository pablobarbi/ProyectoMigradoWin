using System;
using System.Data;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PB Window 'w_ver_medicamentos' (deriva de w_response).
    /// Se preservan nombres y se integra la lógica visible del SRW sin inventar.
    /// </summary>
    public partial class w_ver_medicamentos : Form
    {
        public w_ver_medicamentos()
        {
            InitializeComponent();

            // Hooks con los mismos nombres si luego querés pegar la lógica PB exacta.
            this.pb_continuar.Click += (s, e) => pb_continuar_clicked();
            this.pb_cancelar.Click += (s, e) => pb_cancelar_clicked();

            // Del SRW: "/* Seteo el valor de cerrado por defecto */ s_w_sel.opcion = -1"
            // y "dw_1.SetFocus()". En WinForms ponemos el foco en dw_1 al cargar.
            this.Load += (s, e) => this.dw_1.Focus();
        }

        // Hooks con mismos nombres para portar lógica exacta si la compartís.
        public void pb_continuar_clicked()
        {
            // El SRW muestra MessageBox en ciertos flujos:
            // MessageBox("Atención!!!","No existen datos!",Information!)
            // MessageBox("Atención!!!", stp.mensaje, Information!)
            // Los dejo documentados; cuando compartas la condición, los incrusto literal.
        }

        public void pb_cancelar_clicked()
        {
            // Cierre/cancelación según PB; sin inventar comportamiento adicional.
            this.Close();
        }

        /// <summary>
        /// Helper para mostrar las notificaciones literales detectadas en SRW.
        /// </summary>
        public void uo_informar_no_existen_datos()
        {
            MessageBox.Show("No existen datos!", "Atención!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void uo_informar_mensaje(string mensaje)
        {
            MessageBox.Show(mensaje ?? string.Empty, "Atención!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}