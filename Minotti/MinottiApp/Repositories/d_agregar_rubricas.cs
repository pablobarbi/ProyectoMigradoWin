using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Repositories
{
    public static class d_agregar_rubricas
    {
        // SQL exacto del SRD (sin cambios)
        private const string SQL_SELECT_RUBRICAS = @"
SELECT rubricas.nombre
  FROM rubricas
";

        /// <summary>
        /// Retrieve de la DW rubricas (sin parámetros).
        /// </summary>
        public static DataTable uof_retrieve()
        {
            using OdbcCommand cmd = SQLCA.CreateCommand(SQL_SELECT_RUBRICAS);
            return SQLCA.ExecuteDataTable(cmd);
        }
    }
}

