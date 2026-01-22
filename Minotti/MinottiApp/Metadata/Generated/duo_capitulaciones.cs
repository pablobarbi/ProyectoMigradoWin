using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class duo_capitulaciones : IDataWindowMetadata
    {
        public string DataObject => "duo_capitulaciones";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "capitulo",
    DbName = "capitulaciones.capitulo",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "rubrica",
    DbName = "capitulaciones.rubrica",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "capitulo_nombre",
    DbName = "capitulos.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "rubrica_nombre",
    DbName = "rubricas.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT capitulaciones.capitulo,
       capitulaciones.rubrica,
       capitulos.nombre,
       rubricas.nombre
  FROM capitulaciones,
       rubricas,
       capitulos
 WHERE capitulaciones.rubrica = rubricas.rubrica
   AND capitulaciones.capitulo = capitulos.capitulo
   AND ((capitulaciones.capitulo = :capitulo) OR (:capitulo = 0))";

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
        public string SrdRaw => @"$PBExportHeader$duo_capitulaciones.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=0 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912"" )
table(column=(type=decimal(0) updatewhereclause=yes name=capitulo dbname=""capitulaciones.capitulo"" dbalias="".capitulo"" )
 column=(type=decimal(0) updatewhereclause=yes name=rubrica dbname=""capitulaciones.rubrica"" dbalias="".rubrica"" )
 column=(type=char(255) updatewhereclause=yes name=capitulo_nombre dbname=""capitulos.nombre"" dbalias="".nombre"" )
 column=(type=char(255) updatewhereclause=yes name=rubrica_nombre dbname=""rubricas.nombre"" dbalias="".nombre"" )
 retrieve=""SELECT capitulaciones.capitulo,
       capitulaciones.rubrica,
       capitulos.nombre,
       rubricas.nombre
  FROM capitulaciones,
       rubricas,
       capitulos
 WHERE capitulaciones.rubrica = rubricas.rubrica
   AND capitulaciones.capitulo = capitulos.capitulo
   AND ((capitulaciones.capitulo = :capitulo) OR (:capitulo = 0))
"" arguments=((""capitulo"", string)) )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""23"" y=""8"" height=""64"" width=""535"" format=""[general]"" html.valueishtml=""0""  name=capitulo visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""571"" y=""8"" height=""64"" width=""535"" format=""[general]"" html.valueishtml=""0""  name=rubrica visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1125"" y=""8"" height=""68"" width=""535"" format=""[general]"" html.valueishtml=""0""  name=rubrica_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1682"" y=""8"" height=""64"" width=""535"" format=""[general]"" html.valueishtml=""0""  name=capitulo_nombre visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
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
