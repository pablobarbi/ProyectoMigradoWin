using Minotti;
using System.Windows.Forms;

namespace Minotti.Functions
{
    public static class f_error_base_de_datos
    {
        public static int ferror_base_de_datos()
        {
            // Si sqldbcode es 0 o null -> error personalizado
            if (guo_app.at_error_db.sqldbcode == null || guo_app.at_error_db.sqldbcode == 0)
            {
                f_error_db_personalizado.ferror_db_personalizado();
            }
            else
            {
                // Error de la base
                var motor = (guo_app.motor_db ?? string.Empty).Trim().ToUpperInvariant();

                switch (motor)
                {
                    case "INFORMIX":
                        // f_error_db_informix.Execute();
                        break;

                    case "SQL ANYWHERE":
                        // En PB tenías: Case 'SQL Anywhere'
                        f_error_db_anywhere.ferror_db_anywhere();
                        break;

                    case "ORACLE":
                        // f_error_db_oracle.Execute();
                        break;

                    default:
                        MessageBox.Show(
                            "Se ha producido un error al Grabar datos en la Base de Datos!!!",
                            "Atencion!!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop
                        );
                        break;
                }
            }

            // Limpio las Variables (igual que SetNull en PB)
            guo_app.at_error_db.sqldbcode = null;
            guo_app.at_error_db.sqlerrtext = null;
            guo_app.at_error_db.UserErrorText = null;
            guo_app.at_error_db.UserErrorCode = null;

            return 1;
        }
    }
}
