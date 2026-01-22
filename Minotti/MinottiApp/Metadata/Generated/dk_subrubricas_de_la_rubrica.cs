using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_subrubricas_de_la_rubrica : IDataWindowMetadata
    {
        public string DataObject => "dk_subrubricas_de_la_rubrica";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "rubricaciones_rubrica",
    DbName = "rubricaciones.rubrica",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "rubricaciones_subrubrica",
    DbName = "rubricaciones.subrubrica",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "rubricaciones_posicion",
    DbName = "rubricaciones.posicion",
    Tipo = "long",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "subrubricas_nombre",
    DbName = "subrubricas.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubricas_nombre_orden",
    DbName = "subrubricas_nombre_orden",
    Tipo = "char(259)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT rubricaciones.rubrica,
       rubricaciones.subrubrica,
       rubricaciones.posicion,
       subrubricas.nombre,
CASE
WHEN substr(subrubricas.nombre,1,11)='-EN GENERAL' THEN 'A A' ||
subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1)='-' THEN 'A B' || subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1)='_' THEN 'A C' || subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1) between '0' and '9' and
substr(subrubricas.nombre,2,1) ='-' THEN 'A D' || '0' ||
subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1) between '0' and '9' THEN 'A D' ||
subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1) ='#' THEN 'ZZC' || subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1)='*' THEN 'ZZD' || subrubricas.nombre
ELSE subrubricas.nombre
END as subrubricas_nombre_orden
  FROM rubricaciones,
       subrubricas
 WHERE rubricaciones.subrubrica = subrubricas.subrubrica
   AND rubricaciones.rubrica = :rubrica
ORDER BY 5";

        // PB: table.update
        public string Update => @"rubricaciones";

        // PB: table.updatewhere (0/1)
        public int UpdateWhere => 0;

        // PB: table.updatekeyinplace (yes/no)
        public bool UpdateKeyInPlace => false;

        public string[] Estilos => Array.Empty<string>();
        public string[] SeleccionFila => Array.Empty<string>();
        public string Operaciones => string.Empty;

        // Inferidos (conservador) por presencia de columnas técnicas
        public bool UsaUsuario => false;
        public bool UsaFecha => false;

        // SRD completo (lossless) por si todavía no existe property en C#
        public string SrdRaw => @"$PBExportHeader$dk_subrubricas_de_la_rubrica.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=88 color=""81324524"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912"" height.autosize=yes )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=rubricaciones_rubrica dbname=""rubricaciones.rubrica"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=rubricaciones_subrubrica dbname=""rubricaciones.subrubrica"" )
 column=(type=long update=yes updatewhereclause=yes name=rubricaciones_posicion dbname=""rubricaciones.posicion"" )
 column=(type=char(255) updatewhereclause=yes name=subrubricas_nombre dbname=""subrubricas.nombre"" )
 column=(type=char(259) updatewhereclause=yes name=subrubricas_nombre_orden dbname=""subrubricas_nombre_orden"" )
 retrieve=""SELECT rubricaciones.rubrica,
       rubricaciones.subrubrica,
       rubricaciones.posicion,
       subrubricas.nombre,
CASE
WHEN substr(subrubricas.nombre,1,11)='-EN GENERAL' THEN 'A A' ||
subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1)='-' THEN 'A B' || subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1)='_' THEN 'A C' || subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1) between '0' and '9' and
substr(subrubricas.nombre,2,1) ='-' THEN 'A D' || '0' ||
subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1) between '0' and '9' THEN 'A D' ||
subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1) ='#' THEN 'ZZC' || subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1)='*' THEN 'ZZD' || subrubricas.nombre
ELSE subrubricas.nombre
END as subrubricas_nombre_orden
  FROM rubricaciones,
       subrubricas
 WHERE rubricaciones.subrubrica = subrubricas.subrubrica
   AND rubricaciones.rubrica = :rubrica
ORDER BY 5
"" update=""rubricaciones"" updatewhere=0 updatekeyinplace=no arguments=((""rubrica"", string)) )
text(band=header alignment=""2"" text=""Subrubricas"" border=""6"" color=""8388608"" x=""18"" y=""16"" height=""64"" width=""2770"" html.valueishtml=""0""  name=subrubricas_nombre_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""18"" y=""4"" height=""76"" width=""2770"" format=""[general]"" html.valueishtml=""0""  name=subrubricas_nombre visible=""1"" height.autosize=yes editmask.mask=""!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
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
