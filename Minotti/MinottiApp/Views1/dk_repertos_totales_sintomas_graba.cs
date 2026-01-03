using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// WinForms UserControl migrado desde DataWindow 'dk_repertos_totales_sintomas_graba'.
    /// Mantiene nombres y SQL original. Conecta via ODBC (SQL Anywhere 9) usando DSN.
    /// Incluye SaveChanges() para persistir ediciones si el DW original grababa.
    /// </summary>
    public partial class dk_repertos_totales_sintomas_graba : UserControl
    {
        //        public static readonly string OriginalSql = @"
        //SELECT reperto_total_sin~".~"reperto_total~",   
        //         ~"reperto_total_sin~".~"reperto_sintoma~",   
        //         ~"reperto_total_sin~".~"capitulo~",   
        //         ~"reperto_total_sin~".~"rubrica~",   
        //         ~"reperto_total_sin~".~"subrubrica~",   
        //         ~"reperto_total_sin~".~"subrubrica2~",   
        //         ~"reperto_total_sin~".~"subrubrica3~",   
        //         ~"reperto_total_sin~".~"subrubrica4~",   
        //         ~"reperto_total_sin~".~"subrubrica5~",   
        //         ~"reperto_total_sin~".~"subrubrica6~",   
        //         ~"reperto_total_sin~".~"subrubrica7~",   
        //         ~"reperto_total_sin~".~"subrubrica8~",   
        //         ~"reperto_total_sin~".~"subrubrica9~",   
        //         ~"reperto_total_sin~".~"subrubrica10~"  
        //    FROM ~"reperto_total_sin~"
        //""".Trim();


        public static readonly string OriginalSql = @"
SELECT  ""reperto_total_sin"".""reperto_total"",
        ""reperto_total_sin"".""reperto_sintoma"",
        ""reperto_total_sin"".""capitulo"",
        ""reperto_total_sin"".""rubrica"",
        ""reperto_total_sin"".""subrubrica"",
        ""reperto_total_sin"".""subrubrica2"",
        ""reperto_total_sin"".""subrubrica3"",
        ""reperto_total_sin"".""subrubrica4"",
        ""reperto_total_sin"".""subrubrica5"",
        ""reperto_total_sin"".""subrubrica6"",
        ""reperto_total_sin"".""subrubrica7"",
        ""reperto_total_sin"".""subrubrica8"",
        ""reperto_total_sin"".""subrubrica9"",
        ""reperto_total_sin"".""subrubrica10""
FROM    ""reperto_total_sin""
".Trim();


        /// <summary>
        /// (PowerBuilder) arguments = ()
        /// </summary>
        public static readonly string OriginalArguments = @"";

        /// <summary>
        /// DSN ODBC de SQL Anywhere 9. Debe existir en el equipo.
        /// </summary>
        public string Dsn { get; set; } = string.Empty;

        private DataTable? _table;
        private OdbcDataAdapter? _adapter;
        private OdbcCommandBuilder? _cb;

        public dk_repertos_totales_sintomas_graba()
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

            string sql = OriginalSql;
            sql = System.Text.RegularExpressions.Regex.Replace(sql, @"([:@])([A-Za-z0-9_]+)", "?");
            var cmd = new OdbcCommand(sql, cn);

            foreach (var a in args)
            {
                var p = cmd.Parameters.Add("p", OdbcType.VarChar);
                p.Value = a ?? DBNull.Value;
            }

            _adapter = new OdbcDataAdapter(cmd);
            _cb = new OdbcCommandBuilder(_adapter);
            _adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            _table = new DataTable("dk_repertos_totales_sintomas_graba");
            _adapter.Fill(_table);

            bindingSource.DataSource = _table;
        }

        /// <summary>
        /// Persiste cambios al origen de datos usando comandos generados por OdbcCommandBuilder.
        /// </summary>
        public void SaveChanges()
        {
            if (_adapter == null || _table == null)
                throw new InvalidOperationException("Debe hacer Retrieve antes de guardar.");

            _adapter.UpdateCommand = _cb?.GetUpdateCommand();
            _adapter.InsertCommand = _cb?.GetInsertCommand();
            _adapter.DeleteCommand = _cb?.GetDeleteCommand();
            _adapter.Update(_table);
        }
    }
}