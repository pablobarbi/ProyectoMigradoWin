using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// WinForms UserControl migrado desde DataWindow 'dp_reperto_multiples'.
    /// Mantiene nombres y SQL original. Conecta via ODBC (SQL Anywhere 9) usando DSN.
    /// </summary>
    public partial class dp_reperto_multiples : UserControl
    {
        public static readonly string OriginalSql = @"""
SELECT reperto_total_diag.reperto_total AS reperto_desde,
       reperto_total_diag.reperto_total AS reperto_hasta,
       reperto_total_diag.fecha AS fecha_desde,
       reperto_total_diag.fecha AS fecha_hasta,
       reperto_total_diag.paciente
  FROM reperto_total_diag
""".Trim();

        /// <summary>
        /// (PowerBuilder) arguments = ()
        /// </summary>
        public static readonly string OriginalArguments = @"";

        /// <summary>
        /// DSN ODBC de SQL Anywhere 9. Debe existir en el equipo.
        /// </summary>
        public string Dsn { get; set; } = string.Empty;

        public dp_reperto_multiples()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Retrieve con soporte para 0..N argumentos según el SRD.
        /// Reemplazo mínimo de :param/@param -> '?' para ODBC sin cambiar la lógica original.
        /// Para listas usadas en IN (:param), pasar la cadena ya formateada como en PB.
        /// </summary>
        public void Retrieve(params object[] args)
        {
            if (string.IsNullOrWhiteSpace(Dsn))
                throw new InvalidOperationException("Debe asignar el DSN (propiedad Dsn) antes de Retrieve.");

            using var cn = new OdbcConnection($"DSN={Dsn};");
            cn.Open();
            using var cmd = cn.CreateCommand();

            string sql = OriginalSql;
            sql = System.Text.RegularExpressions.Regex.Replace(sql, @"([:@])([A-Za-z0-9_]+)", "?");
            cmd.CommandText = sql;

            foreach (var a in args)
            {
                var p = cmd.Parameters.Add("p", OdbcType.VarChar);
                p.Value = a ?? DBNull.Value;
            }

            using var da = new OdbcDataAdapter((OdbcCommand)cmd);
            var dt = new DataTable("dp_reperto_multiples");
            da.Fill(dt);
            bindingSource.DataSource = dt;
        }

        public void Retrieve(OdbcConnection externalConnection, OdbcTransaction? tx = null, params object[] args)
        {
            if (externalConnection is null) throw new ArgumentNullException(nameof(externalConnection));

            using var cmd = externalConnection.CreateCommand();
            cmd.Transaction = tx;

            string sql = OriginalSql;
            sql = System.Text.RegularExpressions.Regex.Replace(sql, @"([:@])([A-Za-z0-9_]+)", "?");
            cmd.CommandText = sql;

            foreach (var a in args)
            {
                var p = cmd.Parameters.Add("p", OdbcType.VarChar);
                p.Value = a ?? DBNull.Value;
            }

            using var da = new OdbcDataAdapter((OdbcCommand)cmd);
            var dt = new DataTable("dp_reperto_multiples");
            da.Fill(dt);
            bindingSource.DataSource = dt;
        }
    }
}