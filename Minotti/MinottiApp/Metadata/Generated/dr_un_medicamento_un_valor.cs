using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_un_medicamento_un_valor : IDataWindowMetadata
    {
        public string DataObject => "dr_un_medicamento_un_valor";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "capitulo_nombre",
    DbName = "capitulaciones_matriz.capitulo_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "rubrica_nombre",
    DbName = "capitulaciones_matriz.rubrica_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica_nombre",
    DbName = "capitulaciones_matriz.subrubrica_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica01_nombre",
    DbName = "capitulaciones_matriz.subrubrica01_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica02_nombre",
    DbName = "capitulaciones_matriz.subrubrica02_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica03_nombre",
    DbName = "capitulaciones_matriz.subrubrica03_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica04_nombre",
    DbName = "capitulaciones_matriz.subrubrica04_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica05_nombre",
    DbName = "capitulaciones_matriz.subrubrica05_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica06_nombre",
    DbName = "capitulaciones_matriz.subrubrica06_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica07_nombre",
    DbName = "capitulaciones_matriz.subrubrica07_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica08_nombre",
    DbName = "capitulaciones_matriz.subrubrica08_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica09_nombre",
    DbName = "capitulaciones_matriz.subrubrica09_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica10_nombre",
    DbName = "capitulaciones_matriz.subrubrica10_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "valor",
    DbName = "capitulacion_med.valor",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , capitulacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.capitulo = cm.capitulo
     AND cap.rubrica = cm.rubrica
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , rubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.rubrica = cm.rubrica
     AND cap.subrubrica = cm.subrubrica
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica = cm.subrubrica_padre
     AND cap.subrubrica01 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica01 = cm.subrubrica_padre
     AND cap.subrubrica02 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica02 = cm.subrubrica_padre
     AND cap.subrubrica03 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica03 = cm.subrubrica_padre
     AND cap.subrubrica04 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica04 = cm.subrubrica_padre
     AND cap.subrubrica05 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica05 = cm.subrubrica_padre
     AND cap.subrubrica06 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica06 = cm.subrubrica_padre
     AND cap.subrubrica07 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica07 = cm.subrubrica_padre
     AND cap.subrubrica08 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica08 = cm.subrubrica_padre
     AND cap.subrubrica09 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica09 = cm.subrubrica_padre
     AND cap.subrubrica10 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
ORDER BY 1,2,3";

        // PB: table.update
        public string Update => @"";

        // PB: table.updatewhere (0/1)
        public int UpdateWhere => 1;

        // PB: table.updatekeyinplace (yes/no)
        public bool UpdateKeyInPlace => false;

        public string[] Estilos => Array.Empty<string>();
        public string[] SeleccionFila => Array.Empty<string>();
        public string Operaciones => string.Empty;

        // Inferidos (conservador) por presencia de columnas técnicas
        public bool UsaUsuario => false;
        public bool UsaFecha => false;

        // SRD completo (lossless) por si todavía no existe property en C#
        public string SrdRaw => @"$PBExportHeader$dr_un_medicamento_un_valor.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=136 color=""81324524"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=628 color=""536870912"" )
table(column=(type=char(255) updatewhereclause=yes name=capitulo_nombre dbname=""capitulaciones_matriz.capitulo_nombre"" dbalias=""cap.capitulo_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=rubrica_nombre dbname=""capitulaciones_matriz.rubrica_nombre"" dbalias=""cap.rubrica_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica_nombre dbname=""capitulaciones_matriz.subrubrica_nombre"" dbalias=""cap.subrubrica_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica01_nombre dbname=""capitulaciones_matriz.subrubrica01_nombre"" dbalias=""cap.subrubrica01_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica02_nombre dbname=""capitulaciones_matriz.subrubrica02_nombre"" dbalias=""cap.subrubrica02_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica03_nombre dbname=""capitulaciones_matriz.subrubrica03_nombre"" dbalias=""cap.subrubrica03_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica04_nombre dbname=""capitulaciones_matriz.subrubrica04_nombre"" dbalias=""cap.subrubrica04_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica05_nombre dbname=""capitulaciones_matriz.subrubrica05_nombre"" dbalias=""cap.subrubrica05_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica06_nombre dbname=""capitulaciones_matriz.subrubrica06_nombre"" dbalias=""cap.subrubrica06_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica07_nombre dbname=""capitulaciones_matriz.subrubrica07_nombre"" dbalias=""cap.subrubrica07_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica08_nombre dbname=""capitulaciones_matriz.subrubrica08_nombre"" dbalias=""cap.subrubrica08_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica09_nombre dbname=""capitulaciones_matriz.subrubrica09_nombre"" dbalias=""cap.subrubrica09_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica10_nombre dbname=""capitulaciones_matriz.subrubrica10_nombre"" dbalias=""cap.subrubrica10_nombre"" )
 column=(type=long updatewhereclause=yes name=valor dbname=""capitulacion_med.valor"" dbalias=""cm.valor"" )
 retrieve=""  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , capitulacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.capitulo = cm.capitulo
     AND cap.rubrica = cm.rubrica
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , rubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.rubrica = cm.rubrica
     AND cap.subrubrica = cm.subrubrica
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica = cm.subrubrica_padre
     AND cap.subrubrica01 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica01 = cm.subrubrica_padre
     AND cap.subrubrica02 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica02 = cm.subrubrica_padre
     AND cap.subrubrica03 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica03 = cm.subrubrica_padre
     AND cap.subrubrica04 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica04 = cm.subrubrica_padre
     AND cap.subrubrica05 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica05 = cm.subrubrica_padre
     AND cap.subrubrica06 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica06 = cm.subrubrica_padre
     AND cap.subrubrica07 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica07 = cm.subrubrica_padre
     AND cap.subrubrica08 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica08 = cm.subrubrica_padre
     AND cap.subrubrica09 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
UNION
  SELECT cap.capitulo_nombre,
         cap.rubrica_nombre,
         cap.subrubrica_nombre,
         cap.subrubrica01_nombre,
         cap.subrubrica02_nombre,
         cap.subrubrica03_nombre,
         cap.subrubrica04_nombre,
         cap.subrubrica05_nombre,
         cap.subrubrica06_nombre,
         cap.subrubrica07_nombre,
         cap.subrubrica08_nombre,
         cap.subrubrica09_nombre,
         cap.subrubrica10_nombre,
         cm.valor
    FROM capitulaciones_matriz cap
          , subrubricacion_med cm
   WHERE ((cap.capitulo = :capitulo) OR ( 99 = :capitulo))
     AND cap.subrubrica09 = cm.subrubrica_padre
     AND cap.subrubrica10 = cm.subrubrica_hija
     AND cm.medicamento = :medicamento
     AND cm.valor = :valor
ORDER BY 1,2,3
"" arguments=((""capitulo"", string),(""medicamento"", string),(""valor"", string)) )
text(band=header alignment=""2"" text=""REPORTE DE CAPÍTULO CON UN MEDICAMENTO CON UN VALOR"" border=""0"" color=""8388608"" x=""55"" y=""28"" height=""80"" width=""3506"" html.valueishtml=""0""  name=t_2 visible=""1""  font.face=""Arial"" font.height=""-12"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Capítulo:"" border=""0"" color=""0"" x=""151"" y=""12"" height=""64"" width=""261"" html.valueishtml=""0""  name=t_1 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Rubrica:"" border=""0"" color=""0"" x=""165"" y=""104"" height=""68"" width=""242"" html.valueishtml=""0""  name=t_3 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""430"" y=""12"" height=""68"" width=""1344"" format=""[general]"" html.valueishtml=""0""  name=capitulo_nombre visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
line(band=detail x1=""23"" y1=""616"" x2=""3575"" y2=""616""  name=l_1 visible=""1"" pen.style=""0"" pen.width=""5"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""430"" y=""364"" height=""68"" width=""1344"" format=""[general]"" html.valueishtml=""0""  name=subrubrica02_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=6 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""430"" y=""448"" height=""68"" width=""1344"" format=""[general]"" html.valueishtml=""0""  name=subrubrica03_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=7 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""430"" y=""528"" height=""68"" width=""1344"" format=""[general]"" html.valueishtml=""0""  name=subrubrica04_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""430"" y=""276"" height=""68"" width=""1344"" format=""[general]"" html.valueishtml=""0""  name=subrubrica01_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  1:"" border=""0"" color=""0"" x=""37"" y=""272"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_4 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  2:"" border=""0"" color=""0"" x=""37"" y=""356"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_5 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  3:"" border=""0"" color=""0"" x=""37"" y=""440"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_7 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  4:"" border=""0"" color=""0"" x=""37"" y=""524"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_6 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  0:"" border=""0"" color=""0"" x=""37"" y=""188"" height=""64"" width=""370"" html.valueishtml=""0""  name=t_14 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  6:"" border=""0"" color=""0"" x=""1824"" y=""104"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_10 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  7:"" border=""0"" color=""0"" x=""1824"" y=""188"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_9 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  8:"" border=""0"" color=""0"" x=""1824"" y=""272"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_12 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  9:"" border=""0"" color=""0"" x=""1824"" y=""356"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_11 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica 10:"" border=""0"" color=""0"" x=""1810"" y=""440"" height=""68"" width=""384"" html.valueishtml=""0""  name=t_13 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  5:"" border=""0"" color=""0"" x=""1829"" y=""20"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_8 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=9 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2217"" y=""104"" height=""68"" width=""1344"" format=""[general]"" html.valueishtml=""0""  name=subrubrica06_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=10 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2217"" y=""188"" height=""68"" width=""1344"" format=""[general]"" html.valueishtml=""0""  name=subrubrica07_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=11 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2217"" y=""272"" height=""68"" width=""1344"" format=""[general]"" html.valueishtml=""0""  name=subrubrica08_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=12 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2217"" y=""356"" height=""68"" width=""1344"" format=""[general]"" html.valueishtml=""0""  name=subrubrica09_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=13 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2217"" y=""440"" height=""68"" width=""1344"" format=""[general]"" html.valueishtml=""0""  name=subrubrica10_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=8 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2222"" y=""20"" height=""68"" width=""1344"" format=""[general]"" html.valueishtml=""0""  name=subrubrica05_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""430"" y=""100"" height=""68"" width=""1344"" format=""[general]"" html.valueishtml=""0""  name=rubrica_nombre visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""430"" y=""188"" height=""68"" width=""1344"" format=""[general]"" html.valueishtml=""0""  name=subrubrica_nombre visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Medicamento:"" border=""0"" color=""0"" x=""1810"" y=""528"" height=""64"" width=""384"" html.valueishtml=""0""  name=medicamento_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=detail alignment=""0"" expression="" medicamento ""border=""0"" color=""0"" x=""2213"" y=""528"" height=""68"" width=""585"" format=""[GENERAL]"" html.valueishtml=""0""  name=compute_1 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=14 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3200"" y=""532"" height=""60"" width=""192"" format=""[general]"" html.valueishtml=""0""  name=valor visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Valor:"" border=""0"" color=""0"" x=""2926"" y=""528"" height=""64"" width=""256"" html.valueishtml=""0""  name=t_15 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" encodeselflinkargs=""1"" netscapelayers=""0"" pagingmethod=0 generatedddwframes=""1"" )
xhtmlgen() cssgen(sessionspecific=""0"" )
xmlgen(inline=""0"" )
xsltgen()
jsgen()
export.xml(headgroups=""1"" includewhitespace=""0"" metadatatype=0 savemetadata=0 )
import.xml()
export.pdf(method=0 distill.custompostscript=""0"" xslfop.print=""0"" )
export.xhtml()
 ";
    }
}
