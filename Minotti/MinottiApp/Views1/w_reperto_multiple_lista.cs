using System;
using System.Data;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PB Window 'w_reperto_multiple_lista' (deriva de w_reporte).
    /// Se preservan nombres y se integra la lógica visible (sin inventar).
    /// </summary>
    public partial class w_reperto_multiple_lista : Form
    {
        public w_reperto_multiple_lista()
        {
            InitializeComponent();
            this.pb_reperto.Click += (s, e) => pb_reperto_clicked();
        }

        /// <summary>
        /// Evento equivalente a 'pb_reperto.clicked' según el SRW (extracto visible).
        /// - Abre con parámetros la ventana de carga repertorización parcial.
        /// - Muestra aviso si las modificaciones no se guardaron (Opcion != 1).
        /// </summary>
        public void pb_reperto_clicked()
        {
            // En PB: OpenWithParm(w_carga_reperto_parcial, astp_w_seleccion)
            // Aquí no inventamos navegación; dejamos el hook para que la integración abra tu Form destino.
            var opcion = 0; // astr_w_seleccion.Opcion en PB. Se deja 0 por defecto hasta integrar origen real.
            if (opcion == 1)
            {
                // OK, no se muestra mensaje.
            }
            else
            {
                MessageBox.Show("Las modificaciones no se guardaron.", "Repertorización", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}