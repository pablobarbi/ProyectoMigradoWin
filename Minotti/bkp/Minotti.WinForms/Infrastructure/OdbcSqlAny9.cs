using System;
using System.Data.Odbc;

namespace Minotti
{
    public static class OdbcSqlAny9
    {
        /// <summary>
        /// Hace un ping a SQL Anywhere usando un DSN del sistema (32-bits).
        /// Lanza excepción con el detalle si falla.
        /// </summary>
        public static void PingDsn(string dsn)
        {
            if (string.IsNullOrWhiteSpace(dsn))
                throw new ArgumentException("El DSN no puede ser vacío.", nameof(dsn));

            using var cn = new OdbcConnection($"DSN={dsn};");
            cn.Open();
            using var cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT 1";
            var result = cmd.ExecuteScalar();
            if (Convert.ToInt32(result) != 1)
                throw new InvalidOperationException("Ping inesperado: SELECT 1 no devolvió 1.");
        }
    }
}