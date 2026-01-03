using Minotti.Controls;
using Minotti.Models;
using Minotti.Structures;
using System;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migración de PowerBuilder: w_menu.srw (hereda de w_sheet en PB).
    /// Mantiene nombres de variables y evento 'ue_ejecutar(string modulo, string operacion)'.
    /// </summary>
    public partial class w_menu : w_sheet
    {
        // === Variables PB ===
        public st_nivel[] s_nvl = Array.Empty<st_nivel>(); // st_nivel  s_nvl[]
        public int nivel_actual;                            // integer   nivel_actual
        public DataStore? dw_param;                         // DataStore dw_param

        // === Evento PB ===
        public event Action<string, string>? ue_ejecutar;

        public w_menu()
        {
            InitializeComponent();
            // Ajustes básicos equivalentes al script PB:
            try
            {
                this.Left = 1;
                this.Top = 1;

                // Si el formulario padre es MDI container, ajustar al cliente
                var parent = this.MdiParent ?? Form.ActiveForm;
                if (parent != null && parent.IsMdiContainer)
                {
                    var client = parent.ClientSize;
                    this.Width = client.Width;
                    this.Height = client.Height;
                }
            }
            catch
            {
                // silencioso para compatibilidad
            }
        }

        /// <summary>
        /// Dispara el evento PB 'ue_ejecutar' con (módulo, operación).
        /// Equivalente a un "post event" en PB.
        /// </summary>
        public void Post_ue_ejecutar(string modulo, string operacion)
        {
            BeginInvoke(new Action(() => ue_ejecutar?.Invoke(modulo, operacion)));
        }

        /// <summary>
        /// En PB había un 'event activate;'. Aquí nos enganchamos a Activated si se precisa.
        /// </summary>
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            // No-op: "/* No permite que se active el evento cancelar */" en PB no requiere código en WinForms
        }
    }
}
