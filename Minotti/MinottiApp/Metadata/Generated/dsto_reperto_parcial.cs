using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dsto_reperto_parcial : IDataWindowMetadata
    {
        public string DataObject => "dsto_reperto_parcial";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "reperto_parcial",
    DbName = "reperto_parcial.reperto_parcial",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "capitulo",
    DbName = "reperto_parcial.capitulo",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "rubrica",
    DbName = "reperto_parcial.rubrica",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "subrubrica",
    DbName = "reperto_parcial.subrubrica",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 30,
},

            new DataWindowColumn
{
    Nombre = "subrubrica2",
    DbName = "subrubrica2",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 40,
},

            new DataWindowColumn
{
    Nombre = "subrubrica3",
    DbName = "subrubrica3",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 50,
},

            new DataWindowColumn
{
    Nombre = "subrubrica4",
    DbName = "subrubrica4",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 60,
},

            new DataWindowColumn
{
    Nombre = "subrubrica5",
    DbName = "subrubrica5",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 70,
},

            new DataWindowColumn
{
    Nombre = "subrubrica6",
    DbName = "subrubrica6",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 80,
},

            new DataWindowColumn
{
    Nombre = "subrubrica7",
    DbName = "subrubrica7",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 90,
},

            new DataWindowColumn
{
    Nombre = "subrubrica8",
    DbName = "subrubrica8",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 100,
},

            new DataWindowColumn
{
    Nombre = "subrubrica9",
    DbName = "subrubrica9",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 110,
},

            new DataWindowColumn
{
    Nombre = "subrubrica10",
    DbName = "subrubrica10",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 120,
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
         reperto_parcial.subrubrica10
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
        public string SrdRaw => @"$PBExportHeader$dsto_reperto_parcial.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=72 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912"" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_parcial dbname=""reperto_parcial.reperto_parcial"" )
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
 retrieve=""  SELECT reperto_parcial.reperto_parcial,
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
         reperto_parcial.subrubrica10
    FROM reperto_parcial
"" update=""reperto_parcial"" updatewhere=1 updatekeyinplace=no )
text(band=header alignment=""2"" text=""Reperto Parcial"" border=""0"" color=""0"" x=""5"" y=""4"" height=""64"" width=""407""  name=reperto_parcial_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Capitulo"" border=""0"" color=""0"" x=""416"" y=""4"" height=""64"" width=""329""  name=capitulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Rubrica"" border=""0"" color=""0"" x=""750"" y=""4"" height=""64"" width=""329""  name=rubrica_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""0"" color=""0"" x=""1083"" y=""4"" height=""64"" width=""329""  name=subrubrica_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica2"" border=""0"" color=""0"" x=""1417"" y=""4"" height=""64"" width=""329""  name=subrubrica2_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica3"" border=""0"" color=""0"" x=""1751"" y=""4"" height=""64"" width=""329""  name=subrubrica3_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica4"" border=""0"" color=""0"" x=""2089"" y=""4"" height=""64"" width=""329""  name=subrubrica4_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica5"" border=""0"" color=""0"" x=""2423"" y=""4"" height=""64"" width=""329""  name=subrubrica5_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica6"" border=""0"" color=""0"" x=""2757"" y=""4"" height=""64"" width=""329""  name=subrubrica6_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica7"" border=""0"" color=""0"" x=""3090"" y=""4"" height=""64"" width=""329""  name=subrubrica7_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica8"" border=""0"" color=""0"" x=""3424"" y=""4"" height=""64"" width=""329""  name=subrubrica8_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica9"" border=""0"" color=""0"" x=""3758"" y=""4"" height=""64"" width=""329""  name=subrubrica9_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica10"" border=""0"" color=""0"" x=""4091"" y=""4"" height=""64"" width=""347""  name=subrubrica10_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""5"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=reperto_parcial edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""1"" tabsequence=10 border=""0"" color=""0"" x=""416"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=capitulo edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""1"" tabsequence=20 border=""0"" color=""0"" x=""750"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=rubrica edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""1"" tabsequence=30 border=""0"" color=""0"" x=""1083"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=subrubrica edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""1"" tabsequence=40 border=""0"" color=""0"" x=""1417"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=subrubrica2 edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=6 alignment=""1"" tabsequence=50 border=""0"" color=""0"" x=""1751"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=subrubrica3 edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=7 alignment=""1"" tabsequence=60 border=""0"" color=""0"" x=""2089"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=subrubrica4 edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=8 alignment=""1"" tabsequence=70 border=""0"" color=""0"" x=""2423"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=subrubrica5 edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=9 alignment=""1"" tabsequence=80 border=""0"" color=""0"" x=""2757"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=subrubrica6 edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=10 alignment=""1"" tabsequence=90 border=""0"" color=""0"" x=""3090"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=subrubrica7 edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=11 alignment=""1"" tabsequence=100 border=""0"" color=""0"" x=""3424"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=subrubrica8 edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=12 alignment=""1"" tabsequence=110 border=""0"" color=""0"" x=""3758"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=subrubrica9 edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=13 alignment=""1"" tabsequence=120 border=""0"" color=""0"" x=""4091"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=subrubrica10 edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
