using System.Data.Odbc;

namespace MinottiApp.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString = "DSN=NombreDeTuDSN;";

        public OdbcConnection GetConnection()
        {
            var connection = new OdbcConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
