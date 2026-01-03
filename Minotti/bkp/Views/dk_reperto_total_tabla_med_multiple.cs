using System;
using System.Data;
using System.Data.Odbc;
using System.Text;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// WinForms UserControl que representa el DataWindow 'dk_reperto_total_tabla_med_multiple' migrado.
    /// Mantiene nombres y SQL original. Conecta via ODBC (SQL Anywhere 9) usando un DSN.
    /// </summary>
    public partial class dk_reperto_total_tabla_med_multiple : UserControl
    {
        /// <summary>
        /// SQL original extraído del SRD (sin modificaciones).
        /// </summary>
        public static readonly string OriginalSql = @"""
SELECT reperto_total_med.reperto_total,
       reperto_total_med.reperto_sintoma,
       reperto_total_med.medicamento,
       reperto_total_med.puntuacion,
       0 AS valor1,
       0 AS valor2,
       0 AS valor3,
       0 AS valor4,
       0 AS valor5,
       0 AS valor6,
       0 AS valor7,
       0 AS valor8,
       0 AS valor9,
       0 AS valor10,
       0 AS valor11,
       0 AS valor12,
       0 AS valor13,
       0 AS valor14,
       0 AS valor15,
       0 AS valor16,
       0 AS valor17,
       0 AS valor18,
       0 AS valor19,
       0 AS valor20,
       0 AS valor21,
       0 AS valor22,
       0 AS valor23,
       0 AS valor24,
       0 AS valor25,
       0 AS valor26,
       0 AS valor27,
       0 AS valor28,
       0 AS valor29,
       0 AS valor30,
       0 AS valor31,
       reperto_total_med.orden,
       reperto_total_med.valor
  FROM reperto_total_med
 WHERE reperto_total_med.reperto_total in ( :reperto )
""".Trim();

        /// <summary>
        /// (PowerBuilder) arguments = (("reperto", string)
        /// </summary>
        public static readonly string OriginalArguments = @"("reperto", string";

        /// <summary>
        /// Nombre del DSN (ODBC) para SQL Anywhere 9. Debe existir en el sistema.
        /// </summary>
        public string Dsn { get; set; } = string.Empty;

        public dk_reperto_total_tabla_med_multiple()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ejecuta el SELECT original utilizando ODBC.
        /// Equivalente al 'Retrieve' de DataWindow.
        /// </summary>
        /// <param name="reperto">Valor del argumento ':reperto' (string).</param>
        public void Retrieve(string reperto)
        {
            if (string.IsNullOrWhiteSpace(Dsn))
                throw new InvalidOperationException("Debe asignar el DSN antes de llamar a Retrieve (propiedad Dsn).");

            var connStr = $"DSN={Dsn};";
            using var cn = new OdbcConnection(connStr);
            cn.Open();
            using var cmd = cn.CreateCommand();

            // Adaptación mínima: ODBC usa '?' en lugar de ':param'.
            cmd.CommandText = OriginalSql.Replace(":reperto", "?");

            // Nota: DataWindow usaba IN (:reperto). Mantener literal significa enviar UN parámetro.
            // Si en PB se pasaba una lista ya formateada, se debe pasar exactamente la misma cadena acá.
            // Ejemplo reperto = "'A','B','C'".
            var p = cmd.Parameters.Add("reperto", OdbcType.VarChar);
            p.Value = reperto;

            using var da = new OdbcDataAdapter((OdbcCommand)cmd);
            var dt = new DataTable("dk_reperto_total_tabla_med_multiple");
            da.Fill(dt);
            bindingSource.DataSource = dt;
        }

        /// <summary>
        /// Permite usar una conexión existente (transaccional).
        /// </summary>
        public void Retrieve(string reperto, OdbcConnection externalConnection, OdbcTransaction? tx = null)
        {
            if (externalConnection is null) throw new ArgumentNullException(nameof(externalConnection));
            using var cmd = externalConnection.CreateCommand();
            cmd.Transaction = tx;
            cmd.CommandText = OriginalSql.Replace(":reperto", "?");
            var p = cmd.Parameters.Add("reperto", OdbcType.VarChar);
            p.Value = reperto;
            using var da = new OdbcDataAdapter((OdbcCommand)cmd);
            var dt = new DataTable("dk_reperto_total_tabla_med_multiple");
            da.Fill(dt);
            bindingSource.DataSource = dt;
        }
    }
}