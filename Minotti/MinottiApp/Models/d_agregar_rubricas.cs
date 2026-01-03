
using Minotti.Data;
using Minotti.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class d_agregar_rubricas
    {
        public const string Sql = @"SELECT rubricas.nombre   FROM rubricas ";



        /// <summary>
        /// Versión simple: trae el primer nombre y lo muestra en el textbox 'nombre'.
        /// Equivalente a hacer un SELECT TOP 1.
        /// </summary>
        public string? RetrieveFirst()
        {
            string? valor = SQLCA.ExecuteScalar<string>(Sql, cmd =>
            {
                // sin parámetros
            });

            return valor ?? string.Empty;
        }

        /// <summary>
        /// Devuelve una lista con todos los nombres de rubricas.nombre.
        /// </summary>
        public List<string> RetrieveToList()
        {
            return SQLCA.ExecuteListString(Sql, cmd =>
            {
                // parámetros si hiciera falta (en este caso, nada)
            });
        }

        /// <summary>
        /// Devuelve un DataTable con una columna 'nombre' y todas las filas de rubricas.
        /// </summary>
        public DataTable RetrieveToDataTable()
        {
            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
                // sin parámetros
            });
        }
    }
}

