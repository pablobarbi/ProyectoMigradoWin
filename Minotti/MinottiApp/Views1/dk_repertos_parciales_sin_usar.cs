using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// WinForms UserControl migrado desde DataWindow 'dk_repertos_parciales_sin_usar'.
    /// Mantiene nombres y SQL original. Conecta via ODBC (SQL Anywhere 9) usando DSN.
    /// </summary>
    public partial class dk_repertos_parciales_sin_usar : UserControl
    {
        public static readonly string OriginalSql = @"""
SELECT reperto_parcial.reperto_parcial,
       reperto_parcial.capitulo,
       reperto_parcial.rubrica,
       reperto_parcial.subrubrica,
       reperto_parcial.subrubrica2,
       reperto_parcial.subrubrica3,
       reperto_parcial.subrubrica4,
       reperto_parcial.subrubrica5,
       reperto_parcial.subrubrica6,
       reperto_parcial.subrubrica7,
       reperto_parcial.subrubrica8,
       reperto_parcial.subrubrica9,
       reperto_parcial.subrubrica10,
       'S' seleccionado,
       ' ' capitulo_nombre,
       ' ' rubrica_nombre,
       ' ' subrubrica_nombre,
       ' ' subrubrica2_nombre,
       ' ' subrubrica3_nombre,
       ' ' subrubrica4_nombre,
       ' ' subrubrica5_nombre,
       ' ' subrubrica6_nombre,
       ' ' subrubrica7_nombre,
       ' ' subrubrica8_nombre,
       ' ' subrubrica9_nombre,
       ' ' subrubrica10_nombre
  FROM reperto_parcial
""".Trim();

        /// <summary>
        /// (PowerBuilder) arguments = ()
        /// </summary>
        public static readonly string OriginalArguments = @"";

        /// <summary>
        /// DSN ODBC de SQL Anywhere 9. Debe existir en el equipo.
        /// </summary>
        public string Dsn { get; set; } = string.Empty;

        public dk_repertos_parciales_sin_usar()
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
            var dt = new DataTable("dk_repertos_parciales_sin_usar");
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
            var dt = new DataTable("dk_repertos_parciales_sin_usar");
            da.Fill(dt);
            bindingSource.DataSource = dt;
        }
    }
}