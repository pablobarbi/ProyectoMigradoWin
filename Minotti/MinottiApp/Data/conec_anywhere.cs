using System;
using System.Data.Odbc;

namespace Minotti.Data
{
    /// <summary>
    /// Manejo de conexión por DSN a SQL Anywhere 9.
    /// Archivo migrado desde 'conec_anywhere.llat_dat' (metadatos PB). 
    /// Se conserva el nombre base del archivo: conec_anywhere.
    /// </summary>
    public static class conec_anywhere
    {
        /// <summary>
        /// Crea y abre una conexión ODBC usando DSN, usuario y contraseña.
        /// No guarda estado: devuelve una conexión abierta lista para usar.
        /// El caller es responsable de Dispose().
        /// </summary>
        /// <param name="dsn">Nombre del DSN (ODBC) que apunta a SQL Anywhere 9.</param>
        /// <param name="uid">Usuario.</param>
        /// <param name="pwd">Contraseña.</param>
        public static OdbcConnection Abrir(string dsn, string uid, string pwd)
        {
            if (string.IsNullOrWhiteSpace(dsn))
                throw new ArgumentException("El DSN no puede ser vacío.", nameof(dsn));

            // Cadena de conexión mínima basada en DSN (el DSN ya contiene Driver, ServerName, DBName, etc.)
            var cs = $"DSN={dsn};UID={uid};PWD={pwd};AutoStop=No;";
            var cnn = new OdbcConnection(cs);
            cnn.Open();
            return cnn;
        }

        /// <summary>
        /// Prueba la conexión y devuelve true/false.
        /// </summary>
        public static bool Probar(string dsn, string uid, string pwd, out string? error)
        {
            error = null;
            try
            {
                using var cnn = Abrir(dsn, uid, pwd);
                using var cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT 1";
                var scalar = cmd.ExecuteScalar();
                return Convert.ToInt32(scalar) == 1;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
