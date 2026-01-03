using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_sortdragdrop
    {
        public string columnname { get; set; }
        public string sort_order { get; set; }
        public string displayname { get; set; }
        public string use_display { get; set; }



        public static List<d_sortdragdrop> GetAll()
        {
            const string sql = @"SELECT * FROM dba.<sortdragdrop>";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_sortdragdrop
                {
                    columnname = reader["columnname"]?.ToString() ?? string.Empty,
                    sort_order = reader["sort_order"]?.ToString() ?? string.Empty,
                    displayname = reader["displayname"]?.ToString() ?? string.Empty,
                    use_display = reader["use_display"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                }
            );

            return lista;
        }








        //        public static List<d_sortdragdrop> GetAll()
        //        {
        //            var lista = new List<d_sortdragdrop>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT * FROM dba.<sortdragdrop>
        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new d_sortdragdrop
        //                        {
        //                            columnname = reader["columnname"]?.ToString(),
        //                            sort_order = reader["sort_order"]?.ToString(),
        //                            displayname = reader["displayname"]?.ToString(),
        //                            use_display = reader["use_display"]?.ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
