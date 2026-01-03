using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_principal.srw (window base)
    // Mantiene el nombre del tipo y estructura st_tamaño_minimo.
    public partial class w_principal : Form
    {
        // ===== Estructuras/variables con los mismos nombres que en PB =====
        public struct st_tamaño_minimo
        {
            public int ancho;
            public int largo;
        }

        public bool ib_acomodar = true;           // Flag usado en comentarios PB
        public st_tamaño_minimo it_minimo;        // Tamaño mínimo (ancho/largo)

        public w_principal()
        {
            InitializeComponent();
        }

        // ===== Mapas de eventos PB =====

        // event open;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // En PB: This.ib_acomodar podría inicializarse según estado de la ventana.
            ib_acomodar = true;
        }

        // event resize; (en PB invoca ue_acomodar_objetos)
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (ib_acomodar)
            {
                ue_acomodar_objetos();
            }
        }

        // event close; (comentarios PB: deshabilita acomodar/SetRedraw y GC)
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // /* Pone el flag para que no acomode objetos durante el cierre */
            ib_acomodar = false;

            // /* Habilita el redibujo de la ventana, por si al cerrarse quedó deshabilitado */
            SetRedraw(true);

            base.OnFormClosed(e);
        }

        // ===== Eventos/métodos PB que heredan otras ventanas =====
        public virtual void ue_acomodar_objetos() { /* stub para herencias */ }
        public virtual void ue_ajustar_tamaño() { /* stub para herencias */ }

        // ===== Helper: emulación de This.SetRedraw(boolean) de PB =====
        public void SetRedraw(bool enable)
        {
            // WM_SETREDRAW
            const int WM_SETREDRAW = 0x000B;
            if (this.IsHandleCreated)
            {
                SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)(enable ? 1 : 0), IntPtr.Zero);
                if (enable) this.Invalidate(true);
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    }
}
