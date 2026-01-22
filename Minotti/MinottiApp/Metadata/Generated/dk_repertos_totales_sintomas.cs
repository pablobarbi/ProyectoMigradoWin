using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_repertos_totales_sintomas : IDataWindowMetadata
    {
        public string DataObject => "dk_repertos_totales_sintomas";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "reperto_total",
    DbName = "reperto_total_sin.reperto_total",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "reperto_sintoma",
    DbName = "reperto_total_sin.reperto_sintoma",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "capitulo",
    DbName = "reperto_total_sin.capitulo",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "rubrica",
    DbName = "reperto_total_sin.rubrica",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica",
    DbName = "reperto_total_sin.subrubrica",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica2",
    DbName = "reperto_total_sin.subrubrica2",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica3",
    DbName = "reperto_total_sin.subrubrica3",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica4",
    DbName = "reperto_total_sin.subrubrica4",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica5",
    DbName = "reperto_total_sin.subrubrica5",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica6",
    DbName = "reperto_total_sin.subrubrica6",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica7",
    DbName = "reperto_total_sin.subrubrica7",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica8",
    DbName = "reperto_total_sin.subrubrica8",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica9",
    DbName = "reperto_total_sin.subrubrica9",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica10",
    DbName = "reperto_total_sin.subrubrica10",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "seleccionado",
    DbName = "seleccionado",
    Tipo = "char(1)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT reperto_total_sin.reperto_total,
       reperto_total_sin.reperto_sintoma,
       reperto_total_sin.capitulo,
       reperto_total_sin.rubrica,
       reperto_total_sin.subrubrica,
       reperto_total_sin.subrubrica2,
       reperto_total_sin.subrubrica3,
       reperto_total_sin.subrubrica4,
       reperto_total_sin.subrubrica5,
       reperto_total_sin.subrubrica6,
       reperto_total_sin.subrubrica7,
       reperto_total_sin.subrubrica8,
       reperto_total_sin.subrubrica9,
       reperto_total_sin.subrubrica10,
       'S' seleccionado
  FROM reperto_total_sin";

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
        public string SrdRaw => @"$PBExportHeader$dk_repertos_totales_sintomas.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=168 color=""81324524"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""16777215"" height.autosize=yes )
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
 column=(type=char(1) updatewhereclause=yes name=seleccionado dbname=""seleccionado"" values=""	S/	N"" )
 retrieve=""SELECT reperto_total_sin.reperto_total,
       reperto_total_sin.reperto_sintoma,
       reperto_total_sin.capitulo,
       reperto_total_sin.rubrica,
       reperto_total_sin.subrubrica,
       reperto_total_sin.subrubrica2,
       reperto_total_sin.subrubrica3,
       reperto_total_sin.subrubrica4,
       reperto_total_sin.subrubrica5,
       reperto_total_sin.subrubrica6,
       reperto_total_sin.subrubrica7,
       reperto_total_sin.subrubrica8,
       reperto_total_sin.subrubrica9,
       reperto_total_sin.subrubrica10,
       'S' seleccionado
  FROM reperto_total_sin
"" update=""reperto_total_sin"" updatewhere=1 updatekeyinplace=no )
text(band=header alignment=""2"" text=""Orden"" border=""6"" color=""8388608"" x=""23"" y=""92"" height=""68"" width=""178"" html.valueishtml=""0""  name=orden_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Síntomas"" border=""0"" color=""8388608"" x=""14"" y=""4"" height=""72"" width=""3483"" html.valueishtml=""0""  name=t_2 visible=""1""  font.face=""Arial"" font.height=""-11"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Capitulo"" border=""6"" color=""8388608"" x=""219"" y=""92"" height=""68"" width=""1083"" html.valueishtml=""0""  name=capitulo_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Rubrica"" border=""6"" color=""8388608"" x=""1321"" y=""92"" height=""68"" width=""1083"" html.valueishtml=""0""  name=rubrica_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""2423"" y=""92"" height=""68"" width=""1070"" html.valueishtml=""0""  name=subrubrica_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""3511"" y=""92"" height=""68"" width=""1001"" html.valueishtml=""0""  name=t_3 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""4530"" y=""92"" height=""68"" width=""1001"" html.valueishtml=""0""  name=t_4 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""6569"" y=""92"" height=""68"" width=""1001"" html.valueishtml=""0""  name=t_6 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""7589"" y=""92"" height=""68"" width=""1001"" html.valueishtml=""0""  name=t_7 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""5550"" y=""92"" height=""68"" width=""1001"" html.valueishtml=""0""  name=t_5 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""6569"" y=""92"" height=""68"" width=""1001"" html.valueishtml=""0""  name=t_8 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""7589"" y=""92"" height=""68"" width=""1001"" html.valueishtml=""0""  name=t_9 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""5550"" y=""92"" height=""68"" width=""1001"" html.valueishtml=""0""  name=t_10 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""8608"" y=""92"" height=""68"" width=""1001"" html.valueishtml=""0""  name=t_16 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""9627"" y=""92"" height=""68"" width=""1001"" html.valueishtml=""0""  name=t_14 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""10647"" y=""92"" height=""68"" width=""1001"" html.valueishtml=""0""  name=t_15 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=detail alignment=""1"" expression=""cumulativeSum(  1  for all )""border=""0"" color=""0"" x=""23"" y=""8"" height=""68"" width=""178"" format=""[GENERAL]"" html.valueishtml=""0""  name=orden visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""219"" y=""8"" height=""68"" width=""1083"" format=""[general]"" html.valueishtml=""0""  name=capitulo visible=""1"" height.autosize=yes dddw.name=dw_capitulos dddw.displaycolumn=nombre dddw.datacolumn=capitulo dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1321"" y=""8"" height=""68"" width=""1083"" format=""[general]"" html.valueishtml=""0""  name=rubrica visible=""1"" height.autosize=yes dddw.name=dw_rubricas dddw.displaycolumn=nombre dddw.datacolumn=rubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2423"" y=""8"" height=""68"" width=""1070"" format=""[general]"" html.valueishtml=""0""  name=subrubrica visible=""1"" dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=6 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3511"" y=""8"" height=""68"" width=""1001"" format=""[general]"" html.valueishtml=""0""  name=subrubrica2 visible=""1"" dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=7 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""4530"" y=""8"" height=""68"" width=""1001"" format=""[general]"" html.valueishtml=""0""  name=subrubrica3 visible=""1"" dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=8 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""5550"" y=""8"" height=""68"" width=""1001"" format=""[general]"" html.valueishtml=""0""  name=subrubrica4 visible=""1"" dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=9 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""6569"" y=""8"" height=""68"" width=""1001"" format=""[general]"" html.valueishtml=""0""  name=subrubrica5 visible=""1"" dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=10 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""7589"" y=""8"" height=""68"" width=""1001"" format=""[general]"" html.valueishtml=""0""  name=subrubrica6 visible=""1"" dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=11 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""8608"" y=""8"" height=""68"" width=""1001"" format=""[general]"" html.valueishtml=""0""  name=subrubrica7 visible=""1"" dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=12 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""9632"" y=""8"" height=""68"" width=""1001"" format=""[general]"" html.valueishtml=""0""  name=subrubrica8 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=13 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""10651"" y=""8"" height=""68"" width=""1001"" format=""[general]"" html.valueishtml=""0""  name=subrubrica9 visible=""1"" dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
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
