using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using Minotti.Views.Pbl.Controls;
using System;
using System.Windows.Forms;

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

            // PB: create + constructor
            app.ue_open(); // ⬅️ ACÁ está TODO el flujo real

            // Si ue_open abre MDI, este Run queda bloqueado ahí
            Application.Run();
        }
    }
}
