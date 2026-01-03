using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder Pipeline: medicamentos.srp
    public class medicamentos
    {
        public const string SourceDsn = "mino2000";
        public const string DestinationDsn = "minotti";

        public static void Run(OdbcConnection? source = null, OdbcConnection? destination = null)
        {
            bool createdSrc = false;
            bool createdDst = false;
            if (source == null) { source = new OdbcConnection("DSN=" + SourceDsn); createdSrc = true; }
            if (destination == null) { destination = new OdbcConnection("DSN=" + DestinationDsn); createdDst = true; }

            try
            {
                if (source.State != ConnectionState.Open) source.Open();
                if (destination.State != ConnectionState.Open) destination.Open();

                throw new NotImplementedException("Completar mapeo de columnas del pipeline 'medicamentos' según .srp original.");
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
SOURCE(name="arch01",COLUMN(type=varchar,name="codigo",dbtype="Char(10)",nulls_allowed=yes)
 COLUMN(type=varchar,name="descripcio",dbtype="Char(50)",nulls_allowed=yes)
 COLUMN(type=string,name="obs",dbtype="Memo",nulls_allowed=yes))
RETRIEVE(statement="PBSELECT( VERSION(400) TABLE(NAME=~"arch01~" ) COLUMN(NAME=~"arch01.codigo~") COLUMN(NAME=~"arch01.descripcio~") COLUMN(NAME=~"arch01.obs~")) ")
DESTINATION(name="mig_medicamentos",COLUMN(type=varchar,name="codigo",dbtype="char(10)",nulls_allowed=yes)
 COLUMN(type=varchar,name="descripcio",dbtype="char(50)",nulls_allowed=yes)
 COLUMN(type=string,name="obs",dbtype="long varchar",nulls_allowed=yes))

        ================== FIN CONTENIDO ORIGINAL .SRP ==============
        */
    }
}