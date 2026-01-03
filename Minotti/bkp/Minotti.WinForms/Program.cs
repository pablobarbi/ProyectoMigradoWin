using System;
using System.Windows.Forms;

namespace Minotti
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            const string DSN_NAME = "MinottiDSN"; // <-- cambiá este nombre por tu DSN de 32-bits
            try
            {
                OdbcSqlAny9.PingDsn(DSN_NAME);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el DSN '{DSN_NAME}'.\n\n{ex.Message}", "SQL Anywhere 9 (32-bits)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frm = new w_ver_medicamentos();
            if (frm is { } f1)
            {
                var p = f1.GetType().GetProperty("Dsn");
                p?.SetValue(f1, DSN_NAME);
            }
            Application.Run(frm); // Cambiá 'frm' si querés iniciar con otra window
        }
    }
}