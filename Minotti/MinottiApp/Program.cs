using Minotti.Views.Pbl.Controls;

namespace Minotti
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var app = new uo_sepad();
            guo_app.Attach(app);
            // PB: create + constructor
            app.ue_open(); // ⬅️ ACÁ está TODO el flujo real

            // Si ue_open abre MDI, este Run queda bloqueado ahí
            Application.Run();
        }
    }
}
