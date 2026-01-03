
using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_agregar_subrubricas
    {
        public const string Sql = @"SELECT subrubricas.nombre FROM subrubricas ";

        public DataTable RetrieveToDataTable()
        {
            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
                // sin parámetros
            });
        }
    }
}
