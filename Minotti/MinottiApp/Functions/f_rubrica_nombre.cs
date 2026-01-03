// Migrado desde PowerBuilder .srf: f_rubrica_nombre.srf
// Se mantienen NOMBRES y lógica exacta.
using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Functions
{
    public static class f_rubrica_nombre
    {
        /// <summary>
        /// f_rubrica_nombre(integer ai_rubrica) : string
        /// Portado 1:1 desde PowerBuilder, usando ODBC (SQL Anywhere 9) vía DSN.
        /// </summary>
        public static string? frubrica_nombre(int ai_rubrica)
        {
            const string sql = "SELECT nombre FROM rubricas WHERE rubrica = ?";

            try
            {
                // PB: SELECT nombre INTO :ls_nombre USING SQLCA
                string? nombre = SQLCA.ExecuteScalar<string>(
                    sql,
                    cmd =>
                    {
                        SQLCA.AddParam(cmd, ai_rubrica);
                    }
                );

                // PB semantics: si no hay fila → SqlCode = 100
                if (nombre == null)
                {
                    SQLCA.SqlCode = 100;
                    return null; // o string.Empty si querés PB estricto
                }

                // OK
                SQLCA.SqlCode = 0;
                return nombre;
            }
            catch
            {
                // SqlCode y SqlErrText ya los setea SQLCA
                return null;
            }
        }


    }
}