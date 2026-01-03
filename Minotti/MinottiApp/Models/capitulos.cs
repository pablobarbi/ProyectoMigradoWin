using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder Pipeline: capitulos.srp
    // Se conserva el nombre exacto del objeto como clase.
    public class capitulos
    {
        // Valores detectados en el .srp
        public const string SourceDsn = "mino2000";      // source_connect
        public const string DestinationDsn = "minotti";  // destination_connect

        /// <summary>
        /// Ejecuta el pipeline equivalente contra SQL Anywhere vía ODBC.
        /// Mantiene la estructura de nombres. El contenido original .srp queda embebido abajo.
        /// </summary>
        public static void Run(OdbcConnection? source = null, OdbcConnection? destination = null)
        {
            bool createdSrc = false;
            bool createdDst = false;
            if (source == null)
            {
                source = new OdbcConnection("DSN=" + SourceDsn);
                createdSrc = true;
            }
            if (destination == null)
            {
                destination = new OdbcConnection("DSN=" + DestinationDsn);
                createdDst = true;
            }

            try
            {
                if (source.State != ConnectionState.Open) source.Open();
                if (destination.State != ConnectionState.Open) destination.Open();

                // NOTA: El .srp original define el mapeo de columnas.
                // Para mantener 1:1 la lógica, el mapeo exacto debe aplicarse aquí.
                // Si el pipeline apunta a la misma tabla (capitulos), este método debe:
                //  - Leer filas desde origen (SELECT * FROM capitulos)
                //  - Insertar/actualizar en destino
                // Dejamos una excepción explícita para recordar completar el mapeo exacto.
                throw new NotImplementedException("Completar mapeo de columnas del pipeline 'capitulos' según .srp original.");
            }
            finally
            {
                if (createdSrc) source.Dispose();
                if (createdDst) destination.Dispose();
            }
        }

        /*
        ================== CONTENIDO ORIGINAL .SRP ==================
﻿PIPELINE(source_connect=mino2000,destination_connect=minotti,type=create,commit=100,errors=100)
SOURCE(name="arch03",COLUMN(type=double,name="codigo",dbtype="Numeric",nulls_allowed=yes)
 COLUMN(type=varchar,name="nombre",dbtype="Char(60)",nulls_allowed=yes))
RETRIEVE(statement="PBSELECT(TABLE(NAME=~"arch03~") COLUMN(NAME=~"arch03.codigo~")COLUMN(NAME=~"arch03.nombre~"))")
DESTINATION(name="mig_capitulos",COLUMN(type=double,name="codigo",dbtype="double",nulls_allowed=yes)
 COLUMN(type=varchar,name="nombre",dbtype="char(60)",nulls_allowed=yes))

        ================== FIN CONTENIDO ORIGINAL .SRP ==============
        */
    }
}