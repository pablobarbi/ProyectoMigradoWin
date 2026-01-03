using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// WinForms UserControl migrado desde DataWindow 'dsto_medicamentos_reperto_parc'.
    /// Mantiene nombres y SQL original. Conecta via ODBC (SQL Anywhere 9) usando DSN.
    /// </summary>
    public partial class dsto_medicamentos_reperto_parc : UserControl
    {
        public static readonly string OriginalSql = @"""
SELECT reperto_parcial_med.reperto_parcial,
       reperto_parcial_med.orden,
       reperto_parcial_med.medicamento,
       reperto_parcial_med.valor
  FROM reperto_parcial_med
 WHERE reperto_parcial_med.reperto_parcial = :reperto_parc
 ORDER BY reperto_parcial_med.orden
""".Trim();

        /// <summary>
        /// (PowerBuilder) arguments = (("reperto_parc", string)
        /// </summary>
        public static readonly string OriginalArguments = @"(""reperto_parc"", string";

        /// <summary>
        /// DSN ODBC de SQL Anywhere 9. Debe existir en el equipo.
        /// </summary>
        public string Dsn { get; set; } = string.Empty;

        public dsto_medicamentos_reperto_parc()
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
            var dt = new DataTable("dsto_medicamentos_reperto_parc");
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
            var dt = new DataTable("dsto_medicamentos_reperto_parc");
            da.Fill(dt);
            bindingSource.DataSource = dt;
        }
    }
}