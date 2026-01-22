using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dsto_reperto_total : IDataWindowMetadata
    {
        public string DataObject => "dsto_reperto_total";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "reperto_total",
    DbName = "reperto_total.reperto_total",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "reperto_sintoma",
    DbName = "reperto_total.reperto_sintoma",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 30,
},

            new DataWindowColumn
{
    Nombre = "orden",
    DbName = "reperto_total.orden",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 20,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT reperto_total.reperto_total,
       reperto_total.reperto_sintoma,
       reperto_total.orden
  FROM reperto_total";

        // PB: table.update
        public string Update => @"reperto_total";

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
        public string SrdRaw => @"$PBExportHeader$dsto_reperto_total.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=72 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912"" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_total dbname=""reperto_total.reperto_total"" dbalias="".reperto_total"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_sintoma dbname=""reperto_total.reperto_sintoma"" dbalias="".reperto_sintoma"" )
 column=(type=long update=yes updatewhereclause=yes name=orden dbname=""reperto_total.orden"" dbalias="".orden"" )
 retrieve=""SELECT reperto_total.reperto_total,
       reperto_total.reperto_sintoma,
       reperto_total.orden
  FROM reperto_total
"" update=""reperto_total"" updatewhere=1 updatekeyinplace=no )
text(band=header alignment=""2"" text=""Reperto Total"" border=""0"" color=""0"" x=""5"" y=""4"" height=""64"" width=""352"" html.valueishtml=""0""  name=reperto_total_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Orden"" border=""0"" color=""0"" x=""773"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=orden_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""5"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=reperto_total visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""1"" tabsequence=20 border=""0"" color=""0"" x=""773"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=orden visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Reperto Parcial"" border=""0"" color=""0"" x=""361"" y=""4"" height=""64"" width=""407"" html.valueishtml=""0""  name=reperto_parcial_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=30 border=""0"" color=""0"" x=""361"" y=""8"" height=""64"" width=""407"" html.valueishtml=""0""  name=reperto_sintoma visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
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
