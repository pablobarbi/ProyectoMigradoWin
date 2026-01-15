using Minotti.Data;
using System.Data;
using System.Data.Odbc;

using Minotti.utils;
namespace Minotti.Repositories
{
    public class d_carpeta : datastore{
        
        public string Nombre { get; set; }
        public int? Pagina { get; set; }
        public string Titulo { get; set; }
        public string Objeto { get; set; }
        public string Parametros { get; set; }
        public string Bitmap { get; set; }



        // Query del SRD (misma lgica). Solo cambio :carpeta -> ? por ODBC.
        private const string SQL =
    @"SELECT dba.acc_carpetas.nombre,
         dba.acc_carpetas.pagina,
         dba.acc_carpetas.titulo,
         dba.acc_carpetas.objeto,
         dba.acc_carpetas.parametros,
         dba.acc_carpetas.bitmap
    FROM dba.acc_carpetas
   WHERE dba.acc_carpetas.nombre = ?
ORDER BY dba.acc_carpetas.pagina ASC";

        


public override int Retrieve(params object?[] args)
{
    if (SQLCA.Connection == null)
        throw new InvalidOperationException("SQLCA.Connection es null");

    try
    {
        using var cmd = SQLCA.Connection.CreateCommand();
        cmd.CommandText = SQL;

var prm0 = cmd.CreateParameter();
prm0.Value = args[0];
cmd.Parameters.Add(prm0);

        using var da = new OdbcDataAdapter((OdbcCommand)cmd);
        var dt = new DataTable();
        da.Fill(dt);

        this.SetData(dt);
        return this.RowCount();
    }
    catch (Exception ex)
    {
        SQLCA.SqlCode = -1;
        SQLCA.SqlErrText = ex.Message;
        throw;
    }
}

}
}