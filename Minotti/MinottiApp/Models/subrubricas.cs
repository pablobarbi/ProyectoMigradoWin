using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder Pipeline: subrubricas.srp
    public class subrubricas
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

                throw new NotImplementedException("Completar mapeo de columnas del pipeline 'subrubricas' según .srp original.");
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
SOURCE(name="a4",COLUMN(type=double,name="capitulo",dbtype="Numeric",nulls_allowed=yes)
 COLUMN(type=double,name="padre",dbtype="Numeric",nulls_allowed=yes)
 COLUMN(type=double,name="codigo",dbtype="Numeric",nulls_allowed=yes)
 COLUMN(type=varchar,name="descripcio",dbtype="Char(255)",nulls_allowed=yes))
RETRIEVE(statement="SELECT  4 as capitulo, padre, codigo, descripcio FROM a4  UNION  SELECT  5 as capitulo, padre, codigo, descripcio FROM a5  UNION  SELECT  7 as capitulo, padre, codigo, descripcio FROM a7  UNION  SELECT  8 as capitulo, padre, codigo, descripcio FROM a8  UNION  SELECT  9 as capitulo, padre, codigo, descripcio FROM a9  UNION  SELECT 10 as capitulo, padre, codigo, descripcio FROM a10  UNION  SELECT 11 as capitulo, padre, codigo, descripcio FROM a11  UNION  SELECT 12 as capitulo, padre, codigo, descripcio FROM a12  UNION  SELECT 13 as capitulo, padre, codigo, descripcio FROM a13  UNION  SELECT 14 as capitulo, padre, codigo, descripcio FROM a14  UNION  SELECT 15 as capitulo, padre, codigo, descripcio FROM a15  UNION  SELECT 16 as capitulo, padre, codigo, descripcio FROM a16  UNION  SELECT 17 as capitulo, padre, codigo, descripcio FROM a17  UNION  SELECT 18 as capitulo, padre, codigo, descripcio FROM a18  UNION  SELECT 19 as capitulo, padre, codigo, descripcio FROM a19  UNION  SELECT 20 as capitulo, padre, codigo, descripcio FROM a20  UNION  SELECT 21 as capitulo, padre, codigo, descripcio FROM a21  UNION  SELECT 22 as capitulo, padre, codigo, descripcio FROM a22  UNION  SELECT 23 as capitulo, padre, codigo, descripcio FROM a23  UNION  SELECT 24 as capitulo, padre, codigo, descripcio FROM a24  UNION  SELECT 25 as capitulo, padre, codigo, descripcio FROM a25  UNION  SELECT 26 as capitulo, padre, codigo, descripcio FROM a26  UNION  SELECT 27 as capitulo, padre, codigo, descripcio FROM a27  UNION  SELECT 28 as capitulo, padre, codigo, descripcio FROM a28  UNION  SELECT 29 as capitulo, padre, codigo, descripcio FROM a29  UNION  SELECT 30 as capitulo, padre, codigo, descripcio FROM a30  UNION  SELECT 31 as capitulo, padre, codigo, descripcio FROM a31  UNION  SELECT 32 as capitulo, padre, codigo, descripcio FROM a32  UNION  SELECT 33 as capitulo, padre, codigo, descripcio FROM a33  UNION  SELECT 34 as capitulo, padre, codigo, descripcio FROM a34  UNION  SELECT 35 as capitulo, padre, codigo, descripcio FROM a35  UNION  SELECT 36 as capitulo, padre, codigo, descripcio FROM a36  UNION  SELECT 37 as capitulo, padre, codigo, descripcio FROM a37  UNION  SELECT 38 as capitulo, padre, codigo, descripcio FROM a38  UNION  SELECT 39 as capitulo, padre, codigo, descripcio FROM a39    ")
DESTINATION(name="mig_subrubricas",COLUMN(type=double,name="capitulo",dbtype="double",nulls_allowed=yes)
 COLUMN(type=double,name="padre",dbtype="double",nulls_allowed=yes)
 COLUMN(type=double,name="codigo",dbtype="double",nulls_allowed=yes)
 COLUMN(type=varchar,name="descripcio",dbtype="char(255)",nulls_allowed=yes))

        ================== FIN CONTENIDO ORIGINAL .SRP ==============
        */
    }
}