using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder Pipeline: rubric_med.srp
    public class rubric_med
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

                throw new NotImplementedException("Completar mapeo de columnas del pipeline 'rubric_med' según .srp original.");
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
SOURCE(name="a024",COLUMN(type=double,name="capitulo",dbtype="Numeric",nulls_allowed=yes)
 COLUMN(type=varchar,name="cod_medica",dbtype="Char(255)",nulls_allowed=yes)
 COLUMN(type=double,name="cod_rubric",dbtype="Numeric",nulls_allowed=yes)
 COLUMN(type=double,name="valor",dbtype="Numeric",nulls_allowed=yes))
RETRIEVE(statement="SELECT  4 as capitulo, cod_medica, cod_rubric, valor FROM a024  UNION  SELECT  5 as capitulo, cod_medica, cod_rubric, valor FROM a025  UNION  SELECT  7 as capitulo, cod_medica, cod_rubric, valor FROM a027  UNION  SELECT  8 as capitulo, cod_medica, cod_rubric, valor FROM a028  UNION  SELECT  9 as capitulo, cod_medica, cod_rubric, valor FROM a029  UNION  SELECT 10 as capitulo, cod_medica, cod_rubric, valor FROM a0210  UNION  SELECT 11 as capitulo, cod_medica, cod_rubric, valor FROM a0211  UNION  SELECT 12 as capitulo, cod_medica, cod_rubric, valor FROM a0212  UNION  SELECT 13 as capitulo, cod_medica, cod_rubric, valor FROM a0213  UNION  SELECT 14 as capitulo, cod_medica, cod_rubric, valor FROM a0214  UNION  SELECT 15 as capitulo, cod_medica, cod_rubric, valor FROM a0215  UNION  SELECT 16 as capitulo, cod_medica, cod_rubric, valor FROM a0216  UNION  SELECT 17 as capitulo, cod_medica, cod_rubric, valor FROM a0217  UNION  SELECT 18 as capitulo, cod_medica, cod_rubric, valor FROM a0218  UNION  SELECT 19 as capitulo, cod_medica, cod_rubric, valor FROM a0219  UNION  SELECT 20 as capitulo, cod_medica, cod_rubric, valor FROM a0220  UNION  SELECT 21 as capitulo, cod_medica, cod_rubric, valor FROM a0221  UNION  SELECT 22 as capitulo, cod_medica, cod_rubric, valor FROM a0222  UNION  SELECT 23 as capitulo, cod_medica, cod_rubric, valor FROM a0223  UNION  SELECT 24 as capitulo, cod_medica, cod_rubric, valor FROM a0224  UNION  SELECT 25 as capitulo, cod_medica, cod_rubric, valor FROM a0225  UNION  SELECT 26 as capitulo, cod_medica, cod_rubric, valor FROM a0226  UNION  SELECT 27 as capitulo, cod_medica, cod_rubric, valor FROM a0227  UNION  SELECT 28 as capitulo, cod_medica, cod_rubric, valor FROM a0228  UNION  SELECT 29 as capitulo, cod_medica, cod_rubric, valor FROM a0229  UNION  SELECT 30 as capitulo, cod_medica, cod_rubric, valor FROM a0230  UNION  SELECT 31 as capitulo, cod_medica, cod_rubric, valor FROM a0231  UNION  SELECT 32 as capitulo, cod_medica, cod_rubric, valor FROM a0232  UNION  SELECT 33 as capitulo, cod_medica, cod_rubric, valor FROM a0233  UNION  SELECT 34 as capitulo, cod_medica, cod_rubric, valor FROM a0234  UNION  SELECT 35 as capitulo, cod_medica, cod_rubric, valor FROM a0235  UNION  SELECT 36 as capitulo, cod_medica, cod_rubric, valor FROM a0236  UNION  SELECT 37 as capitulo, cod_medica, cod_rubric, valor FROM a0237  UNION  SELECT 38 as capitulo, cod_medica, cod_rubric, valor FROM a0238  UNION  SELECT 39 as capitulo, cod_medica, cod_rubric, valor FROM a0239    ")
DESTINATION(name="mig_rubric_med",COLUMN(type=double,name="capitulo",dbtype="double",nulls_allowed=yes)
 COLUMN(type=varchar,name="cod_medica",dbtype="char(255)",nulls_allowed=yes)
 COLUMN(type=double,name="cod_rubric",dbtype="double",nulls_allowed=yes)
 COLUMN(type=double,name="valor",dbtype="double",nulls_allowed=yes))

        ================== FIN CONTENIDO ORIGINAL .SRP ==============
        */
    }
}