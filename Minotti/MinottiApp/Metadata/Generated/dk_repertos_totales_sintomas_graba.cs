using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_repertos_totales_sintomas_graba : IDataWindowMetadata
    {
        public string DataObject => "dk_repertos_totales_sintomas_graba";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "reperto_total",
    DbName = "reperto_total_sin.reperto_total",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 140,
},

            new DataWindowColumn
{
    Nombre = "reperto_sintoma",
    DbName = "reperto_total_sin.reperto_sintoma",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "capitulo",
    DbName = "reperto_total_sin.capitulo",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "rubrica",
    DbName = "reperto_total_sin.rubrica",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 30,
},

            new DataWindowColumn
{
    Nombre = "subrubrica",
    DbName = "reperto_total_sin.subrubrica",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 40,
},

            new DataWindowColumn
{
    Nombre = "subrubrica2",
    DbName = "reperto_total_sin.subrubrica2",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 50,
},

            new DataWindowColumn
{
    Nombre = "subrubrica3",
    DbName = "reperto_total_sin.subrubrica3",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 60,
},

            new DataWindowColumn
{
    Nombre = "subrubrica4",
    DbName = "reperto_total_sin.subrubrica4",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 70,
},

            new DataWindowColumn
{
    Nombre = "subrubrica5",
    DbName = "reperto_total_sin.subrubrica5",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 80,
},

            new DataWindowColumn
{
    Nombre = "subrubrica6",
    DbName = "reperto_total_sin.subrubrica6",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 90,
},

            new DataWindowColumn
{
    Nombre = "subrubrica7",
    DbName = "reperto_total_sin.subrubrica7",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 100,
},

            new DataWindowColumn
{
    Nombre = "subrubrica8",
    DbName = "reperto_total_sin.subrubrica8",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 110,
},

            new DataWindowColumn
{
    Nombre = "subrubrica9",
    DbName = "reperto_total_sin.subrubrica9",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 120,
},

            new DataWindowColumn
{
    Nombre = "subrubrica10",
    DbName = "reperto_total_sin.subrubrica10",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 130,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT ~";

        // PB: table.update
        public string Update => @"reperto_total_sin";

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
        public string SrdRaw => @"$PBExportHeader$dk_repertos_totales_sintomas_graba.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=1073741824 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=72 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912"" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_total dbname=""reperto_total_sin.reperto_total"" dbalias="".reperto_total"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_sintoma dbname=""reperto_total_sin.reperto_sintoma"" dbalias="".reperto_sintoma"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=capitulo dbname=""reperto_total_sin.capitulo"" dbalias="".capitulo"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=rubrica dbname=""reperto_total_sin.rubrica"" dbalias="".rubrica"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica dbname=""reperto_total_sin.subrubrica"" dbalias="".subrubrica"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica2 dbname=""reperto_total_sin.subrubrica2"" dbalias="".subrubrica2"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica3 dbname=""reperto_total_sin.subrubrica3"" dbalias="".subrubrica3"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica4 dbname=""reperto_total_sin.subrubrica4"" dbalias="".subrubrica4"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica5 dbname=""reperto_total_sin.subrubrica5"" dbalias="".subrubrica5"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica6 dbname=""reperto_total_sin.subrubrica6"" dbalias="".subrubrica6"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica7 dbname=""reperto_total_sin.subrubrica7"" dbalias="".subrubrica7"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica8 dbname=""reperto_total_sin.subrubrica8"" dbalias="".subrubrica8"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica9 dbname=""reperto_total_sin.subrubrica9"" dbalias="".subrubrica9"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica10 dbname=""reperto_total_sin.subrubrica10"" dbalias="".subrubrica10"" )
 retrieve=""  SELECT ~""reperto_total_sin~"".~""reperto_total~"",   
         ~""reperto_total_sin~"".~""reperto_sintoma~"",   
         ~""reperto_total_sin~"".~""capitulo~"",   
         ~""reperto_total_sin~"".~""rubrica~"",   
         ~""reperto_total_sin~"".~""subrubrica~"",   
         ~""reperto_total_sin~"".~""subrubrica2~"",   
         ~""reperto_total_sin~"".~""subrubrica3~"",   
         ~""reperto_total_sin~"".~""subrubrica4~"",   
         ~""reperto_total_sin~"".~""subrubrica5~"",   
         ~""reperto_total_sin~"".~""subrubrica6~"",   
         ~""reperto_total_sin~"".~""subrubrica7~"",   
         ~""reperto_total_sin~"".~""subrubrica8~"",   
         ~""reperto_total_sin~"".~""subrubrica9~"",   
         ~""reperto_total_sin~"".~""subrubrica10~""  
    FROM ~""reperto_total_sin~""   
"" update=""reperto_total_sin"" updatewhere=1 updatekeyinplace=no )
text(band=header alignment=""2"" text=""Reperto Sintoma"" border=""0"" color=""33554432"" x=""5"" y=""4"" height=""64"" width=""443"" html.valueishtml=""0""  name=reperto_sintoma_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Capitulo"" border=""0"" color=""33554432"" x=""453"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=capitulo_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Rubrica"" border=""0"" color=""33554432"" x=""786"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=rubrica_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""0"" color=""33554432"" x=""1120"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=subrubrica_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica2"" border=""0"" color=""33554432"" x=""1454"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=subrubrica2_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica3"" border=""0"" color=""33554432"" x=""1787"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=subrubrica3_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica4"" border=""0"" color=""33554432"" x=""2121"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=subrubrica4_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica5"" border=""0"" color=""33554432"" x=""2455"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=subrubrica5_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica6"" border=""0"" color=""33554432"" x=""2793"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=subrubrica6_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica7"" border=""0"" color=""33554432"" x=""3127"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=subrubrica7_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica8"" border=""0"" color=""33554432"" x=""3461"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=subrubrica8_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica9"" border=""0"" color=""33554432"" x=""3794"" y=""4"" height=""64"" width=""329"" html.valueishtml=""0""  name=subrubrica9_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica10"" border=""0"" color=""33554432"" x=""4128"" y=""4"" height=""64"" width=""347"" html.valueishtml=""0""  name=subrubrica10_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""1"" tabsequence=10 border=""0"" color=""33554432"" x=""5"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=reperto_sintoma visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""1"" tabsequence=20 border=""0"" color=""33554432"" x=""453"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=capitulo visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""1"" tabsequence=30 border=""0"" color=""33554432"" x=""786"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=rubrica visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""1"" tabsequence=40 border=""0"" color=""33554432"" x=""1120"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=6 alignment=""1"" tabsequence=50 border=""0"" color=""33554432"" x=""1454"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica2 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=7 alignment=""1"" tabsequence=60 border=""0"" color=""33554432"" x=""1787"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica3 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=8 alignment=""1"" tabsequence=70 border=""0"" color=""33554432"" x=""2121"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica4 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=9 alignment=""1"" tabsequence=80 border=""0"" color=""33554432"" x=""2455"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica5 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=10 alignment=""1"" tabsequence=90 border=""0"" color=""33554432"" x=""2793"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica6 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=11 alignment=""1"" tabsequence=100 border=""0"" color=""33554432"" x=""3127"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica7 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=12 alignment=""1"" tabsequence=110 border=""0"" color=""33554432"" x=""3461"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica8 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=13 alignment=""1"" tabsequence=120 border=""0"" color=""33554432"" x=""3794"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica9 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=14 alignment=""1"" tabsequence=130 border=""0"" color=""33554432"" x=""4128"" y=""4"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica10 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=140 border=""0"" color=""33554432"" x=""4517"" y=""8"" height=""64"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=reperto_total visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
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
