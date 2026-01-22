using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dsto_actualiza_rubricacion_med : IDataWindowMetadata
    {
        public string DataObject => "dsto_actualiza_rubricacion_med";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "rubrica",
    DbName = "rubricacion_med.rubrica",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "subrubrica",
    DbName = "rubricacion_med.subrubrica",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "medicamento",
    DbName = "rubricacion_med.medicamento",
    Tipo = "char(10)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 30,
},

            new DataWindowColumn
{
    Nombre = "valor",
    DbName = "rubricacion_med.valor",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 40,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT rubricacion_med.rubrica,
       rubricacion_med.subrubrica,
       rubricacion_med.medicamento,
       rubricacion_med.valor
  FROM rubricacion_med
WHERE rubricacion_med.rubrica = :rubrica
  AND  rubricacion_med.subrubrica = :subrubrica";

        // PB: table.update
        public string Update => @"rubricacion_med";

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
        public string SrdRaw => @"$PBExportHeader$dsto_actualiza_rubricacion_med.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=72 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912"" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=rubrica dbname=""rubricacion_med.rubrica"" dbalias="".rubrica"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=subrubrica dbname=""rubricacion_med.subrubrica"" dbalias="".subrubrica"" )
 column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento dbname=""rubricacion_med.medicamento"" dbalias="".medicamento"" )
 column=(type=long update=yes updatewhereclause=yes name=valor dbname=""rubricacion_med.valor"" dbalias="".valor"" )
 retrieve=""SELECT rubricacion_med.rubrica,
       rubricacion_med.subrubrica,
       rubricacion_med.medicamento,
       rubricacion_med.valor
  FROM rubricacion_med
WHERE rubricacion_med.rubrica = :rubrica
  AND  rubricacion_med.subrubrica = :subrubrica"" update=""rubricacion_med"" updatewhere=1 updatekeyinplace=no arguments=((""rubrica"", string),(""subrubrica"", string)) )
text(band=header alignment=""2"" text=""Rubrica"" border=""0"" color=""0"" x=""5"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=rubrica_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""0"" color=""0"" x=""338"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=subrubrica_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Medicamento"" border=""0"" color=""0"" x=""672"" y=""4"" height=""64"" width=""357"" html.valueishtml=""0""  name=medicamento_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Valor"" border=""0"" color=""0"" x=""1033"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=valor_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""1"" tabsequence=10 border=""0"" color=""0"" x=""5"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=rubrica visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""1"" tabsequence=20 border=""0"" color=""0"" x=""338"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=30 border=""0"" color=""0"" x=""672"" y=""4"" height=""76"" width=""302"" format=""[general]"" html.valueishtml=""0""  name=medicamento visible=""1"" edit.limit=10 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""1"" tabsequence=40 border=""0"" color=""0"" x=""1033"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=valor visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
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
