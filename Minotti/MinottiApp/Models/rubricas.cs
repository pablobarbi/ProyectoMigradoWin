using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Models
{
    public class Rubrica
    {
        public double? capitulo { get; set; }
        public double? codigo { get; set; }
        public string descripcio { get; set; } = string.Empty;
    }
}

/*
        ================== CONTENIDO ORIGINAL .SRP ==================
﻿PIPELINE(source_connect=mino2000,destination_connect=minotti,type=create,commit=100,errors=100)
SOURCE(name="c4",COLUMN(type=double,name="capitulo",dbtype="Numeric",nulls_allowed=yes)
 COLUMN(type=double,name="codigo",dbtype="Numeric",nulls_allowed=yes)
 COLUMN(type=varchar,name="descripcio",dbtype="Char(255)",nulls_allowed=yes))
RETRIEVE(statement="SELECT  4 as capitulo, codigo, descripcio FROM c4  UNION  SELECT  5 as capitulo, codigo, descripcio FROM c5  UNION  SELECT  7 as capitulo, codigo, descripcio FROM c7  UNION  SELECT  8 as capitulo, codigo, descripcio FROM c8  UNION  SELECT  9 as capitulo, codigo, descripcio FROM c9  UNION  SELECT 10 as capitulo, codigo, descripcio FROM c10  UNION  SELECT 11 as capitulo, codigo, descripcio FROM c11  UNION  SELECT 12 as capitulo, codigo, descripcio FROM c12  UNION  SELECT 13 as capitulo, codigo, descripcio FROM c13  UNION  SELECT 14 as capitulo, codigo, descripcio FROM c14  UNION  SELECT 15 as capitulo, codigo, descripcio FROM c15  UNION  SELECT 16 as capitulo, codigo, descripcio FROM c16  UNION  SELECT 17 as capitulo, codigo, descripcio FROM c17  UNION  SELECT 18 as capitulo, codigo, descripcio FROM c18  UNION  SELECT 19 as capitulo, codigo, descripcio FROM c19  UNION  SELECT 20 as capitulo, codigo, descripcio FROM c20  UNION  SELECT 21 as capitulo, codigo, descripcio FROM c21  UNION  SELECT 22 as capitulo, codigo, descripcio FROM c22  UNION  SELECT 23 as capitulo, codigo, descripcio FROM c23  UNION  SELECT 24 as capitulo, codigo, descripcio FROM c24  UNION  SELECT 25 as capitulo, codigo, descripcio FROM c25  UNION  SELECT 26 as capitulo, codigo, descripcio FROM c26  UNION  SELECT 27 as capitulo, codigo, descripcio FROM c27  UNION  SELECT 28 as capitulo, codigo, descripcio FROM c28  UNION  SELECT 29 as capitulo, codigo, descripcio FROM c29  UNION  SELECT 30 as capitulo, codigo, descripcio FROM c30  UNION  SELECT 31 as capitulo, codigo, descripcio FROM c31  UNION  SELECT 32 as capitulo, codigo, descripcio FROM c32  UNION  SELECT 33 as capitulo, codigo, descripcio FROM c33  UNION  SELECT 34 as capitulo, codigo, descripcio FROM c34  UNION  SELECT 35 as capitulo, codigo, descripcio FROM c35  UNION  SELECT 36 as capitulo, codigo, descripcio FROM c36  UNION  SELECT 37 as capitulo, codigo, descripcio FROM c37  UNION  SELECT 38 as capitulo, codigo, descripcio FROM c38  UNION  SELECT 39 as capitulo, codigo, descripcio FROM c39  ")
DESTINATION(name="mig_rubricas",COLUMN(type=double,name="capitulo",dbtype="double",nulls_allowed=yes)
 COLUMN(type=double,name="codigo",dbtype="double",nulls_allowed=yes)
 COLUMN(type=varchar,name="descripcio",dbtype="char(255)",nulls_allowed=yes))

        ================== FIN CONTENIDO ORIGINAL .SRP ==============
        */