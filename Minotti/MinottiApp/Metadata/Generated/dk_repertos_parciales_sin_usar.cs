using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_repertos_parciales_sin_usar : IDataWindowMetadata
    {
        public string DataObject => "dk_repertos_parciales_sin_usar";

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
},

            new DataWindowColumn
{
    Nombre = "rubrica",
    DbName = "reperto_parcial.rubrica",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "subrubrica",
    DbName = "reperto_parcial.subrubrica",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "subrubrica2",
    DbName = "subrubrica2",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "subrubrica3",
    DbName = "subrubrica3",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "subrubrica4",
    DbName = "subrubrica4",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "subrubrica5",
    DbName = "subrubrica5",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "subrubrica6",
    DbName = "subrubrica6",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "subrubrica7",
    DbName = "subrubrica7",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "subrubrica8",
    DbName = "subrubrica8",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "subrubrica9",
    DbName = "subrubrica9",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
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
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "capitulo_nombre",
    DbName = "capitulo_nombre",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "rubrica_nombre",
    DbName = "rubrica_nombre",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica_nombre",
    DbName = "subrubrica_nombre",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica2_nombre",
    DbName = "subrubrica2_nombre",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica3_nombre",
    DbName = "subrubrica3_nombre",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica4_nombre",
    DbName = "subrubrica4_nombre",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica5_nombre",
    DbName = "subrubrica5_nombre",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica6_nombre",
    DbName = "subrubrica6_nombre",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica7_nombre",
    DbName = "subrubrica7_nombre",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica8_nombre",
    DbName = "subrubrica8_nombre",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica9_nombre",
    DbName = "subrubrica9_nombre",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica10_nombre",
    DbName = "subrubrica10_nombre",
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
       'S' seleccionado,
       ' ' capitulo_nombre,
       ' ' rubrica_nombre,
       ' ' subrubrica_nombre,
       ' ' subrubrica2_nombre,
       ' ' subrubrica3_nombre,
       ' ' subrubrica4_nombre,
       ' ' subrubrica5_nombre,
       ' ' subrubrica6_nombre,
       ' ' subrubrica7_nombre,
       ' ' subrubrica8_nombre,
       ' ' subrubrica9_nombre,
       ' ' subrubrica10_nombre
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
        public string SrdRaw => @"$PBExportHeader$dk_repertos_parciales_sin_usar.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=204 color=""81324524"" )
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
 column=(type=char(1) updatewhereclause=yes name=capitulo_nombre dbname=""capitulo_nombre"" )
 column=(type=char(1) updatewhereclause=yes name=rubrica_nombre dbname=""rubrica_nombre"" )
 column=(type=char(1) updatewhereclause=yes name=subrubrica_nombre dbname=""subrubrica_nombre"" )
 column=(type=char(1) updatewhereclause=yes name=subrubrica2_nombre dbname=""subrubrica2_nombre"" )
 column=(type=char(1) updatewhereclause=yes name=subrubrica3_nombre dbname=""subrubrica3_nombre"" )
 column=(type=char(1) updatewhereclause=yes name=subrubrica4_nombre dbname=""subrubrica4_nombre"" )
 column=(type=char(1) updatewhereclause=yes name=subrubrica5_nombre dbname=""subrubrica5_nombre"" )
 column=(type=char(1) updatewhereclause=yes name=subrubrica6_nombre dbname=""subrubrica6_nombre"" )
 column=(type=char(1) updatewhereclause=yes name=subrubrica7_nombre dbname=""subrubrica7_nombre"" )
 column=(type=char(1) updatewhereclause=yes name=subrubrica8_nombre dbname=""subrubrica8_nombre"" )
 column=(type=char(1) updatewhereclause=yes name=subrubrica9_nombre dbname=""subrubrica9_nombre"" )
 column=(type=char(1) updatewhereclause=yes name=subrubrica10_nombre dbname=""subrubrica10_nombre"" )
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
       'S' seleccionado,
       ' ' capitulo_nombre,
       ' ' rubrica_nombre,
       ' ' subrubrica_nombre,
       ' ' subrubrica2_nombre,
       ' ' subrubrica3_nombre,
       ' ' subrubrica4_nombre,
       ' ' subrubrica5_nombre,
       ' ' subrubrica6_nombre,
       ' ' subrubrica7_nombre,
       ' ' subrubrica8_nombre,
       ' ' subrubrica9_nombre,
       ' ' subrubrica10_nombre
  FROM reperto_parcial
"" update=""reperto_parcial"" updatewhere=1 updatekeyinplace=no )
text(band=header alignment=""2"" text=""Síntomas con los que se esta trabajando actualmente"" border=""0"" color=""8388608"" x=""1298"" y=""24"" height=""72"" width=""2030""  name=t_2  font.face=""Arial"" font.height=""-11"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=15 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""114"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=capitulo_nombre height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=23 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""8270"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica7_nombre height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=22 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""7250"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica6_nombre height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=21 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""6231"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica5_nombre height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=20 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""5211"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica4_nombre height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=19 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""4192"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica3_nombre height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=24 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""9294"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica8_nombre height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=25 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""10322"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica9_nombre height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=18 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3173"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica2_nombre height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=17 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2153"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=subrubrica_nombre height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=16 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1134"" y=""8"" height=""68"" width=""1001"" format=""[general]""  name=rubrica_nombre height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=14 alignment=""0"" tabsequence=10 border=""0"" color=""0"" x=""27"" y=""12"" height=""60"" width=""64""  name=seleccionado checkbox.text="""" checkbox.on=""S"" checkbox.off=""N"" checkbox.scale=no checkbox.threed=yes  font.face=""Arial"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=header alignment=""2"" text=""Capitulo"" border=""6"" color=""8388608"" x=""114"" y=""124"" height=""68"" width=""1001""  name=capitulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""2153"" y=""124"" height=""68"" width=""1001""  name=subrubrica_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Rubrica"" border=""6"" color=""8388608"" x=""1134"" y=""124"" height=""68"" width=""1001""  name=rubrica_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""4192"" y=""124"" height=""68"" width=""1001""  name=t_4  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""6231"" y=""124"" height=""68"" width=""1001""  name=t_6  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""7250"" y=""124"" height=""68"" width=""1001""  name=t_7  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""5211"" y=""124"" height=""68"" width=""1001""  name=t_5  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""6231"" y=""124"" height=""68"" width=""1001""  name=t_8  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""7250"" y=""124"" height=""68"" width=""1001""  name=t_9  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""5211"" y=""124"" height=""68"" width=""1001""  name=t_10  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""8270"" y=""124"" height=""68"" width=""1001""  name=t_16  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""3173"" y=""124"" height=""68"" width=""1001""  name=t_3  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""9289"" y=""124"" height=""68"" width=""1001""  name=t_14  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""10309"" y=""124"" height=""68"" width=""1001""  name=t_15  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
button(band=header text=""Seleccionar Todos""filename=""""action=""0"" border=""1"" color=""128"" x=""128"" y=""16"" height=""88"" width=""530"" vtextalign=""0"" htextalign=""0""  name=cb_seleccionar  font.face=""Arial"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.italic=""1"" background.mode=""2"" background.color=""67108864"" )
button(band=header text=""Deseleccionar Todos""filename=""""action=""0"" border=""1"" color=""128"" x=""672"" y=""16"" height=""88"" width=""599"" vtextalign=""0"" htextalign=""0""  name=cd_deseleccionar  font.face=""Arial"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.italic=""1"" background.mode=""2"" background.color=""67108864"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
