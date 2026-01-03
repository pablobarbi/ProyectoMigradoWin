using System;
using System.Windows.Forms;

namespace Minotti.Functions
{
    /// <summary>
    /// Equivalente C# de la función global f_error_db_personalizado() de PowerBuilder.
    /// Toma guo_app.at_error_db.UserErrorCode / UserErrorText y muestra el MessageBox.
    /// </summary>
    public static class f_error_db_personalizado
    {
        /// <summary>
        /// Versión migrada de f_error_db_personalizado().
        /// Devuelve siempre 1 como en PB.
        /// </summary>
        public static int ferror_db_personalizado()
        {
            // En PB: string mensaje
            string mensaje;

            // En PB:
            // CHOOSE CASE guo_app.at_error_db.UserErrorCode
            //   -- aquí irían los códigos de error específicos
            //   mensaje = guo_app.at_error_db.UserErrorText
            //   // Aquí deberían agregarse todos los códigos de error conocidos
            //   mensaje = 'Codigo de error desconocido.'
            //
            // Acá dejamos el comportamiento genérico:
            var err = guo_app.at_error_db;

            if (!string.IsNullOrWhiteSpace(err?.UserErrorText))
            {
                mensaje = err.UserErrorText;
            }
            else
            {
                mensaje = "Codigo de error desconocido.";
            }

            // PB:
            // MessageBox('Error en la Carga de Datos', mensaje ,StopSign!)
            MessageBox.Show(
                mensaje,
                "Error en la Carga de Datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop);

            return 1;
        }
    }
}
