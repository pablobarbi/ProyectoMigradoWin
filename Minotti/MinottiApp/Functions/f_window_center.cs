using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PowerBuilder: f_window_center.srf
    /// Firma PB: global subroutine f_window_center (readonly window aw_wnd)
    /// Equivalente .NET: void f_window_center(Form aw_wnd)
    /// Lógica: centra la ventana respecto a la pantalla principal si entra; si no, deja 1px de margen.
    /// </summary>
    public static class f_window_center
    {
        /// <summary>
        /// Centra la ventana en la pantalla principal (similar a PixelsToUnits + Move de PB).
        /// Respeta el comportamiento: si pantalla <= tamaño ventana, deja posición (1,1).
        /// </summary>
        public static void fwindow_center(Form aw_wnd)
        {
            if (aw_wnd is null || aw_wnd.IsDisposed) return;

            // En PB usan Environment.ScreenHeight/Width (pantalla principal).
            Rectangle screen = Screen.PrimaryScreen?.Bounds ?? Screen.GetBounds(Point.Empty);

            int li_screenwidth  = screen.Width;
            int li_screenheight = screen.Height;
            if (!(li_screenwidth > 0) || !(li_screenheight > 0)) return;

            int li_x = 1, li_y = 1;

            if (li_screenwidth > aw_wnd.Width)
                li_x = (li_screenwidth / 2) - (aw_wnd.Width / 2);

            if (li_screenheight > aw_wnd.Height)
                li_y = (li_screenheight / 2) - (aw_wnd.Height / 2);

            // PB: aw_wnd.Move(li_x, li_y)
            try
            {
                // Asegurar estado "Normal" para que el Move tenga efecto
                if (aw_wnd.WindowState != FormWindowState.Normal)
                    aw_wnd.WindowState = FormWindowState.Normal;

                aw_wnd.StartPosition = FormStartPosition.Manual;
                aw_wnd.Location = new Point(li_x, li_y);
            }
            catch
            {
                // Silencioso como PB (RETURN simple)
            }
        }
    }
}
