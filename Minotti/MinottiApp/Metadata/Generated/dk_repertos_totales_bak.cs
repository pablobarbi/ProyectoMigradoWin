using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_repertos_totales_bak : IDataWindowMetadata
    {
        public string DataObject => "dk_repertos_totales_bak";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "reperto_parcial",
    DbName = "reperto_parcial.reperto_parcial",
    Tipo = "decimal(0)",
    EsClave = true,
    EsIdentity = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "capitulo",
    DbName = "reperto_parcial.capitulo",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "rubrica",
    DbName = "reperto_parcial.rubrica",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica",
    DbName = "reperto_parcial.subrubrica",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica2",
    DbName = "subrubrica2",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica3",
    DbName = "subrubrica3",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica4",
    DbName = "subrubrica4",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica5",
    DbName = "subrubrica5",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica6",
    DbName = "subrubrica6",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica7",
    DbName = "subrubrica7",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica8",
    DbName = "subrubrica8",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica9",
    DbName = "subrubrica9",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica10",
    DbName = "subrubrica10",
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
        public string Sql => @"SELECT reperto_parcial.reperto_parcial,
       reperto_parcial.capitulo,
       reperto_parcial.rubrica,
       reperto_parcial.subrubrica,
       reperto_parcial.subrubrica2,
       reperto_parcial.subrubrica3,
       reperto_parcial.subrubrica4,
       reperto_parcial.subrubrica5,
       reperto_parcial.subrubrica6,
       reperto_parcial.subrubrica7,
       reperto_parcial.subrubrica8,
       reperto_parcial.subrubrica9,
       reperto_parcial.subrubrica10,
       'S' seleccionado
  FROM reperto_parcial";

        // PB: table.update
        public string Update => @"reperto_parcial";

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
        public string SrdRaw => @"$PBExportHeader$dk_repertos_totales_bak.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=168 color=""81324524"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""16777215""  height.autosize=yes)
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes identity=yes name=reperto_parcial dbname=""reperto_parcial.reperto_parcial"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=capitulo dbname=""reperto_parcial.capitulo"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=rubrica dbname=""reperto_parcial.rubrica"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica dbname=""reperto_parcial.subrubrica"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica2 dbname=""subrubrica2"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica3 dbname=""subrubrica3"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica4 dbname=""subrubrica4"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica5 dbname=""subrubrica5"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica6 dbname=""subrubrica6"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica7 dbname=""subrubrica7"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica8 dbname=""subrubrica8"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica9 dbname=""subrubrica9"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes name=subrubrica10 dbname=""subrubrica10"" )
 column=(type=char(1) updatewhereclause=yes name=seleccionado dbname=""seleccionado"" values=""	S/	N"" )
 retrieve=""SELECT reperto_parcial.reperto_parcial,
       reperto_parcial.capitulo,
       reperto_parcial.rubrica,
       reperto_parcial.subrubrica,
       reperto_parcial.subrubrica2,
       reperto_parcial.subrubrica3,
       reperto_parcial.subrubrica4,
       reperto_parcial.subrubrica5,
       reperto_parcial.subrubrica6,
       reperto_parcial.subrubrica7,
       reperto_parcial.subrubrica8,
       reperto_parcial.subrubrica9,
       reperto_parcial.subrubrica10,
       'S' seleccionado
  FROM reperto_parcial
"" update=""reperto_parcial"" updatewhere=1 updatekeyinplace=no )
text(band=header alignment=""2"" text=""Orden"" border=""6"" color=""8388608"" x=""23"" y=""92"" height=""68"" width=""178""  name=orden_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Síntomas"" border=""0"" color=""8388608"" x=""14"" y=""4"" height=""72"" width=""3483""  name=t_2  font.face=""Arial"" font.height=""-11"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Capitulo"" border=""6"" color=""8388608"" x=""219"" y=""92"" height=""68"" width=""1083""  name=capitulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Rubrica"" border=""6"" color=""8388608"" x=""1321"" y=""92"" height=""68"" width=""1083""  name=rubrica_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""2423"" y=""92"" height=""68"" width=""1070""  name=subrubrica_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""3511"" y=""92"" height=""68"" width=""1001""  name=t_3  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""4530"" y=""92"" height=""68"" width=""1001""  name=t_4  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""6569"" y=""92"" height=""68"" width=""1001""  name=t_6  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""7589"" y=""92"" height=""68"" width=""1001""  name=t_7  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""5550"" y=""92"" height=""68"" width=""1001""  name=t_5  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""6569"" y=""92"" height=""68"" width=""1001""  name=t_8  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""7589"" y=""92"" height=""68"" width=""1001""  name=t_9  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""5550"" y=""92"" height=""68"" width=""1001""  name=t_10  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""8608"" y=""92"" height=""68"" width=""1001""  name=t_16  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""9627"" y=""92"" height=""68"" width=""1001""  name=t_14  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""10647"" y=""92"" height=""68"" width=""1001""  name=t_15  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=detail alignment=""1"" expression=""cumulativeSum(  1  for all )""border=""0"" color=""0"" x=""23"" y=""8"" height=""68"" width=""178"" format=""[GENERAL]""  name=orden  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""219"" y=""8"" height=""68"" width=""1083"" format=""[general]""  name=capitulo height.autosize=yes dddw.name=dw_capitulos dddw.displaycolumn=nombre dddw.datacolumn=capitulo dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1321"" y=""8"" height=""68"" width=""1083"" format=""[general]""  name=rubrica height.autosize=yes dddw.name=dw_rubricas dddw.displaycolumn=nombre dddw.datacolumn=rubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2423"" y=""8"" height=""68"" width=""1070"" format=""[general]""  name=subrubrica dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3511"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica2 dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=6 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""4530"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica3 dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=7 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""5550"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica4 dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=8 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""6569"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica5 dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=9 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""7589"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica6 dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=10 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""8608"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica7 dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=11 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""9632"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica8 edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=12 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""10651"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica9 dddw.name=dw_subrubricas dddw.displaycolumn=nombre dddw.datacolumn=subrubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
