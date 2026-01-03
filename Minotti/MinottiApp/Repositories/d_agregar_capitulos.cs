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
    public class d_agregar_capitulos
    {

        // SQL exacto del SRD, adaptado a ODBC posicional
        private const string SQL_SELECT_NOMBRE_POR_CAPITULO = @"
SELECT capitulos.nombre
  FROM capitulos
 WHERE capitulos.capitulo = ?
";

        public static DataTable uof_retrieve(string capitulo)
        {
            if (capitulo is null) throw new ArgumentNullException(nameof(capitulo));

            using OdbcCommand cmd = SQLCA.CreateCommand(SQL_SELECT_NOMBRE_POR_CAPITULO);
            SQLCA.AddParam(cmd, capitulo);

            return SQLCA.ExecuteDataTable(cmd);
        }

        public static string? uof_get_nombre(string capitulo)
        {
            if (capitulo is null) throw new ArgumentNullException(nameof(capitulo));

            using OdbcCommand cmd = SQLCA.CreateCommand(SQL_SELECT_NOMBRE_POR_CAPITULO);
            SQLCA.AddParam(cmd, capitulo);

            // Podés usar DataTable o Scalar; el SRD selecciona 1 columna, 1 fila esperable.
            var dt = SQLCA.ExecuteDataTable(cmd);
            if (dt.Rows.Count == 0) return null;

            object v = dt.Rows[0]["nombre"];
            return v == DBNull.Value ? null : Convert.ToString(v);
        }
    }
}
 
 
