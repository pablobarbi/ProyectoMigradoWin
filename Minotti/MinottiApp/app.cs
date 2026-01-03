using System;
using System.Windows.Forms;
using Minotti.Views;
using MinottiApp;

namespace Minotti
{
    // Migración de WPF App.xaml -> WinForms (punto de entrada)
    // Mantengo el nombre base "app" en el archivo y clase.
    public class app
    {
        [STAThread]
        public void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Splash opcional (manteniendo nombre w_splash)
            try
            {
                using (var splash = new w_splash())
                {
                    splash.Show();
                    // deja que su propio Timer cierre el splash
                    Application.DoEvents();
                    var start = DateTime.UtcNow;
                    while (splash.Visible && (DateTime.UtcNow - start).TotalSeconds < 5)
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(10);
                    }
                }
            }
            catch { /* Si no existe w_splash, continuo */ }

            // Ventana principal (manteniendo nombre w_mdi si está disponible)
            Form mainForm;
            try
            {
                mainForm = new MainForm();
            }
            catch
            {
                // Fallback a w_principal si aún no migraste w_mdi
                mainForm = new w_principal();
            }

            Application.Run(mainForm);
        }
    }
}
