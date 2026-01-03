using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Data
{
    public static class SQLCA
    {
        public static OdbcConnection? Connection { get; set; }
        [ThreadStatic]
        private static OdbcCommand? _currentCommand;

        // Exponer transacción actual (si ya la tenés, no dupliques)
        public static OdbcTransaction? CurrentTransaction => _currentTx;

        public static int SqlCode { get; set; }
        public static string? SqlErrText { get; set; }

        public static string? UserID { get; set; }
        public static string? DBPass { get; set; }
        public static object DBMS { get; internal set; }
        public static object DBParm { get; internal set; }

        // === PB aliases ===
        // PB: SQLCA.LogID
        public static string? LogID
        {
            get => UserID;
            set => UserID = value;
        }

        // PB: SQLCA.LogPass
        public static string? LogPass
        {
            get => DBPass;
            set => DBPass = value;
        }
        // PB: SQLCA.SqlDbCode
        public static int SqlDbCode
        {
            get => SqlCode;
            set => SqlCode = value;
        }


        // === Emulación de AutoCommit y transacción ===
        public static bool AutoCommit { get; set; } = true;

        private static OdbcTransaction? _currentTx;



        private static bool EnsureConfigured()
        {
            if (Connection is null)
            {
                SqlCode = -1;
                SqlErrText = "SQLCA.Connection no está configurada.";
                return false;
            }

            if (string.IsNullOrEmpty(UserID))
            {
                SqlCode = -1;
                SqlErrText = "SQLCA.UserID no está configurado.";
                return false;
            }

            return true;
        }


        public static object Instance { get; } = new object();
        public static string Database { get; internal set; }
        public static object ServerName { get; internal set; }


        // ===================== TRANSACCIÓN =====================

        /// <summary>
        /// Inicia una transacción si AutoCommit = false.
        /// La idea es que se llame desde ue_abrir_transaccion().
        /// </summary>
        public static void BeginTransactionIfNeeded()
        {
            if (!EnsureConfigured())
                throw new InvalidOperationException("SQLCA no configurado.");

            if (AutoCommit)
                return; // si está en autocommit, no hacemos nada

            if (Connection!.State != ConnectionState.Open)
                Connection.Open();

            if (_currentTx == null)
            {
                _currentTx = Connection.BeginTransaction();
            }
        }

        public static void BeginTransaction()
        {
            if (Connection == null) { SqlCode = -1; SqlErrText = "SQLCA.Connection no configurada"; return; }
            if (_currentTx == null) _currentTx = Connection.BeginTransaction();
            SqlCode = 0; SqlErrText = null;
        }

        public static void Commit()
        {
            try
            {
                if (_currentTx != null)
                {
                    _currentTx.Commit();
                    _currentTx.Dispose();
                    _currentTx = null;
                }

                SqlCode = 0;
                SqlErrText = null;
            }
            catch (OdbcException ex)
            {
                SqlCode = ex.ErrorCode;
                SqlErrText = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                SqlCode = -1;
                SqlErrText = ex.Message;
                throw;
            }
        }

        public static void Rollback()
        {
            try
            {
                if (_currentTx != null)
                {
                    _currentTx.Rollback();
                    _currentTx.Dispose();
                    _currentTx = null;
                }

                SqlCode = 0;
                SqlErrText = null;
            }
            catch (OdbcException ex)
            {
                SqlCode = ex.ErrorCode;
                SqlErrText = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                SqlCode = -1;
                SqlErrText = ex.Message;
                throw;
            }
        }

        public static void EndTransaction()
        {
            _currentTx?.Dispose();
            _currentTx = null;
        }

        // ===================== SELECT escalar =====================

        public static T? ExecuteScalar<T>(string sql, Action<OdbcCommand>? configure = null)
        {
            if (!EnsureConfigured())
                return default;

            using var cmd = Connection!.CreateCommand();
            cmd.CommandText = sql;

            // si hay transacción abierta la usamos
            if (_currentTx != null)
                cmd.Transaction = _currentTx;

            configure?.Invoke(cmd);

            try
            {
                if (Connection!.State != ConnectionState.Open)
                    Connection.Open();

                SqlCode = 0;
                SqlErrText = null;

                object? result = cmd.ExecuteScalar();

                if (result == null || result is DBNull)
                    return default;

                return (T)Convert.ChangeType(result, typeof(T));
            }
            catch (OdbcException ex)
            {
                SqlCode = ex.ErrorCode;
                SqlErrText = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                SqlCode = -1;
                SqlErrText = ex.Message;
                throw;
            }
        }

        public static object? ExecuteScalar(OdbcCommand cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            return cmd.ExecuteScalar();
        }
        // ===================== SELECT DataTable =====================

        public static DataTable ExecuteDataTable(string sql, Action<OdbcCommand>? configure = null)
        {
            if (!EnsureConfigured())
                return new DataTable();

            using var cmd = Connection!.CreateCommand();
            cmd.CommandText = sql;

            if (_currentTx != null)
                cmd.Transaction = _currentTx;

            configure?.Invoke(cmd);

            try
            {
                if (Connection!.State != ConnectionState.Open)
                    Connection.Open();

                SqlCode = 0;
                SqlErrText = null;

                var dt = new DataTable();
                using (var adapter = new OdbcDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                return dt;
            }
            catch (OdbcException ex)
            {
                SqlCode = ex.ErrorCode;
                SqlErrText = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                SqlCode = -1;
                SqlErrText = ex.Message;
                throw;
            }
        }

        public static DataTable ExecuteDataTable(string sql, params OdbcParameter[] parameters)
        {
            return ExecuteDataTable(sql, cmd =>
            {
                if (parameters == null || parameters.Length == 0)
                    return;

                foreach (var p in parameters)
                {
                    if (p == null) continue;
                    cmd.Parameters.Add(p);
                }
            });
        }


        public static DataTable ExecuteDataTable(OdbcCommand cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));

            using var da = new OdbcDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Atajo para queries sin params
        public static DataTable ExecuteDataTable(string sql)
        {
            using var cmd = CreateCommand(sql);
            return ExecuteDataTable(cmd);
        }

        // Atajo para queries con params posicionales
        public static DataTable ExecuteDataTable(string sql, params object?[] values)
        {
            using var cmd = CreateCommand(sql);
            foreach (var v in values)
                AddParam(cmd, v);
            return ExecuteDataTable(cmd);
        }

        // ===================== NON QUERY (Insert/Update/Delete) =====================

        /// <summary>
        /// Helper base para I/U/D.
        /// </summary>
        public static int ExecuteNonQuery(string sql, Action<OdbcCommand>? configure = null)
        {
            if (!EnsureConfigured())
                return -1;

            using var cmd = Connection!.CreateCommand();
            cmd.CommandText = sql;

            if (_currentTx != null)
                cmd.Transaction = _currentTx;

            configure?.Invoke(cmd);

            try
            {
                if (Connection!.State != ConnectionState.Open)
                    Connection.Open();

                SqlCode = 0;
                SqlErrText = null;

                int rows = cmd.ExecuteNonQuery();

                // Si estamos en AutoCommit y no hay transacción manual,
                // el propio driver hace commit por statement.
                return rows;
            }
            catch (OdbcException ex)
            {
                SqlCode = ex.ErrorCode;
                SqlErrText = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                SqlCode = -1;
                SqlErrText = ex.Message;
                throw;
            }
        }

        public static int ExecuteNonQuery(OdbcCommand cmd)
        {
            try
            {
                if (Connection == null) { SqlCode = -1; SqlErrText = "SQLCA.Connection no configurada"; return -1; }
                cmd.Connection = Connection;
                if (_currentTx != null) cmd.Transaction = _currentTx;
                var rows = cmd.ExecuteNonQuery();
                SqlCode = 0; SqlErrText = null;
                return rows;
            }
            catch (OdbcException ex)
            {
                SqlCode = ex.ErrorCode;
                SqlErrText = ex.Message;
                return -1;
            }
        }

        public static int ExecuteNonQuery(string sql, params object?[] parameters)
        {
            return ExecuteNonQuery(sql, cmd =>
            {
                if (parameters == null) return;

                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.AddWithValue($"@p{i + 1}", parameters[i] ?? DBNull.Value);
                }
            });
        }


        /// <summary>
        /// Ejecuta un SELECT scalar y devuelve long (para COUNT(*), etc).
        /// Si falla retorna -1 y setea SqlCode/SqlErrText.
        /// </summary>
        public static long ExecuteScalarLong(string sql, Action<OdbcCommand>? bind = null)
        {
            if (Connection is null)
            {
                SqlCode = -1;
                SqlErrText = "SQLCA.Connection no configurada";
                return -1;
            }

            try
            {
                using var cmd = Connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                bind?.Invoke(cmd);

                object? obj = cmd.ExecuteScalar();
                SqlCode = 0;
                SqlErrText = null;

                if (obj is null || obj == DBNull.Value) return 0;
                return Convert.ToInt64(obj);
            }
            catch (Exception ex)
            {
                SqlCode = -1;
                SqlErrText = ex.Message;
                return -1;
            }
        }


        /// <summary>
        /// Helper semántico para INSERT.
        /// </summary>
        public static int Insert(string sql, Action<OdbcCommand>? configure = null)
            => ExecuteNonQuery(sql, configure);

        /// <summary>
        /// Helper semántico para UPDATE.
        /// </summary>
        public static int Update(string sql, Action<OdbcCommand>? configure = null)
            => ExecuteNonQuery(sql, configure);

        /// <summary>
        /// Helper semántico para DELETE.
        /// </summary>
        public static int Delete(string sql, Action<OdbcCommand>? configure = null)
            => ExecuteNonQuery(sql, configure);

        // ===================== READER → LISTA =====================

        /// <summary>
        /// Ejecuta un SELECT y mapea cada fila con el delegate map.
        /// </summary>
        public static List<T> ExecuteReaderList<T>(
            string sql,
            Func<OdbcDataReader, T> map,
            Action<OdbcCommand>? configure = null)
        {
            if (map == null) throw new ArgumentNullException(nameof(map));
            var list = new List<T>();

            if (!EnsureConfigured())
                return list;

            using var cmd = Connection!.CreateCommand();
            cmd.CommandText = sql;

            if (_currentTx != null)
                cmd.Transaction = _currentTx;

            configure?.Invoke(cmd);

            try
            {
                if (Connection!.State != ConnectionState.Open)
                    Connection.Open();

                SqlCode = 0;
                SqlErrText = null;

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(map(reader));
                }

                return list;
            }
            catch (OdbcException ex)
            {
                SqlCode = ex.ErrorCode;
                SqlErrText = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                SqlCode = -1;
                SqlErrText = ex.Message;
                throw;
            }
        }

        /// <summary>
        /// Alias de ExecuteReaderList, por compatibilidad de nombre.
        /// </summary>
        public static List<T> ExecuteList<T>(
            string sql,
            Func<OdbcDataReader, T> map,
            Action<OdbcCommand>? configure = null)
            => ExecuteReaderList(sql, map, configure);



        /// <summary>
        /// Agrega un parámetro a un OdbcCommand.
        /// Emula el USING de PowerBuilder (parámetros posicionales).
        /// </summary>
        public static void AddParam(OdbcCommand cmd, object? value)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            var p = cmd.CreateParameter();
            p.Value = value ?? DBNull.Value;
            cmd.Parameters.Add(p);
        }

        /// <summary>
        /// Sobrecarga que permite configurar tipo y tamaño (si hace falta).
        /// </summary>
        public static void AddParam(
            OdbcCommand cmd,
            object? value,
            OdbcType dbType,
            int size = 0)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            var p = cmd.CreateParameter();
            p.OdbcType = dbType;

            if (size > 0)
                p.Size = size;

            p.Value = value ?? DBNull.Value;

            cmd.Parameters.Add(p);
        }
        // === ESTO EMULA :param de PowerBuilder ===
        public static void AddParam(object? value)
        {
            if (_currentCommand == null)
                throw new InvalidOperationException("No hay comando activo en SQLCA");

            var p = _currentCommand.CreateParameter();
            p.Value = value ?? DBNull.Value;
            _currentCommand.Parameters.Add(p);
        }
        public static OdbcCommand CreateCommand(string sql)
        {
            if (Connection == null)
                throw new InvalidOperationException("SQLCA.Connection no está configurada.");

            var cmd = Connection.CreateCommand();
            cmd.CommandText = sql;
            if (_currentTx != null)
                cmd.Transaction = _currentTx;

            return cmd;
        }
        public static OdbcCommand GetCommand()
        {
            if (_currentCommand == null)
                throw new InvalidOperationException("No hay comando activo en SQLCA");

            return _currentCommand;
        }

        public static void Connect()
        {
            if (Connection == null)
            {
                SqlCode = -1;
                SqlErrText = "SQLCA.Connection no está configurada.";
                return;
            }

            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                SqlCode = 0;
                SqlErrText = null;
            }
            catch (OdbcException ex)
            {
                SqlCode = ex.ErrorCode;
                SqlErrText = ex.Message;
            }
            catch (Exception ex)
            {
                SqlCode = -1;
                SqlErrText = ex.Message;
            }
        }

        public static void Disconnect()
        {
            try
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                    Connection.Close();

                SqlCode = 0;
                SqlErrText = null;
            }
            catch (OdbcException ex)
            {
                SqlCode = ex.ErrorCode;
                SqlErrText = ex.Message;
            }
            catch (Exception ex)
            {
                SqlCode = -1;
                SqlErrText = ex.Message;
            }
        }

        public static long GetLastIdentity()
        {
            const string sql = "SELECT @@IDENTITY";

            using var cmd = Connection!.CreateCommand();
            cmd.CommandText = sql;
            cmd.Transaction = _currentTx;

            object? result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt64(result);
        }

    }

    public sealed class SQLCAProxy
    {
        
        public static SQLCAProxy SQLCA { get; internal set; } = new();

        public OdbcConnection? Connection { get => SQLCA.Connection; set => Minotti.Data.SQLCA.Connection = value; }
        public int SqlCode { get => Minotti.Data.SQLCA.SqlCode; set => Minotti.Data.SQLCA.SqlCode = value; }
        public string? SqlErrText { get => Minotti.Data.SQLCA.SqlErrText; set => Minotti.Data.SQLCA.SqlErrText = value; }
        public string? UserID { get => Minotti.Data.SQLCA.UserID; set => Minotti.Data.SQLCA.UserID = value; }
        public string? DBPass { get => Minotti.Data.SQLCA.DBPass; set => Minotti.Data.SQLCA.DBPass = value; }
        public bool AutoCommit { get => Minotti.Data.SQLCA.AutoCommit; set => Minotti.Data.SQLCA.AutoCommit = value; }
    }

}
