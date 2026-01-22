using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_reperto_multiples : IDataWindowMetadata
    {
        public string DataObject => "dp_reperto_multiples";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "reperto_desde",
    DbName = "reperto_total_diag.reperto_desde",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "reperto_hasta",
    DbName = "reperto_total_diag.reperto_hasta",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "fecha_desde",
    DbName = "reperto_total_diag.fecha_desde",
    Tipo = "date",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 30,
},

            new DataWindowColumn
{
    Nombre = "fecha_hasta",
    DbName = "reperto_total_diag.fecha_hasta",
    Tipo = "date",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 40,
},

            new DataWindowColumn
{
    Nombre = "paciente",
    DbName = "reperto_total_diag.paciente",
    Tipo = "long",
    EsClave = true,
    UpdateWhereClause = true,
    EsRequerido = true,
    TabOrder = 50,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT reperto_total_diag.reperto_total AS reperto_desde,
       reperto_total_diag.reperto_total AS reperto_hasta,
       reperto_total_diag.fecha AS fecha_desde,
       reperto_total_diag.fecha AS fecha_hasta,
       reperto_total_diag.paciente
  FROM reperto_total_diag";

        // PB: table.update
        public string Update => @"xxx";

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
        public string SrdRaw => @"$PBExportHeader$dp_reperto_multiples.srd
release 7;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=336 color=""536870912"" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_desde dbname=""reperto_total_diag.reperto_desde"" initial=""1"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_hasta dbname=""reperto_total_diag.reperto_hasta"" initial=""99999"" )
 column=(type=date update=yes updatewhereclause=yes key=yes name=fecha_desde dbname=""reperto_total_diag.fecha_desde"" initial=""01/01/1950"" )
 column=(type=date update=yes updatewhereclause=yes key=yes name=fecha_hasta dbname=""reperto_total_diag.fecha_hasta"" initial=""31/12/2050"" )
 column=(type=long update=yes updatewhereclause=yes key=yes name=paciente dbname=""reperto_total_diag.paciente"" initial=""0"" )
 retrieve=""SELECT reperto_total_diag.reperto_total AS reperto_desde,
       reperto_total_diag.reperto_total AS reperto_hasta,
       reperto_total_diag.fecha AS fecha_desde,
       reperto_total_diag.fecha AS fecha_hasta,
       reperto_total_diag.paciente
  FROM reperto_total_diag
"" update=""xxx"" updatewhere=0 updatekeyinplace=no )
column(band=detail id=1 alignment=""1"" tabsequence=10 border=""5"" color=""0"" x=""347"" y=""84"" height=""68"" width=""206"" format=""[general]""  name=reperto_desde edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Desde:"" border=""0"" color=""8388608"" x=""82"" y=""84"" height=""64"" width=""247""  name=reperto_desde_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Desde:"" border=""0"" color=""8388608"" x=""1157"" y=""84"" height=""64"" width=""233""  name=fecha_desde_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=30 border=""5"" color=""0"" x=""1408"" y=""84"" height=""68"" width=""379"" format=""dd/mm/yyyy""  name=fecha_desde editmask.mask=""dd/mm/yyyy"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Hasta:"" border=""0"" color=""8388608"" x=""1838"" y=""84"" height=""64"" width=""238""  name=fecha_hasta_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""0"" tabsequence=40 border=""5"" color=""0"" x=""2094"" y=""84"" height=""68"" width=""379"" format=""dd/mm/yyyy""  name=fecha_hasta editmask.mask=""dd/mm/yyyy"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=2 alignment=""1"" tabsequence=20 border=""5"" color=""0"" x=""850"" y=""84"" height=""68"" width=""206"" format=""[general]""  name=reperto_hasta edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Hasta:"" border=""0"" color=""8388608"" x=""599"" y=""84"" height=""64"" width=""233""  name=reperto_hasta_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
groupbox(band=detail text=""Números""border=""5"" color=""128"" x=""46"" y=""16"" height=""164"" width=""1042""  name=gb_1  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.italic=""1"" background.mode=""1"" background.color=""553648127"" )
groupbox(band=detail text=""Fechas""border=""5"" color=""128"" x=""1120"" y=""16"" height=""164"" width=""1399""  name=gb_2  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.italic=""1"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=5 alignment=""1"" tabsequence=50 border=""5"" color=""0"" x=""649"" y=""224"" height=""68"" width=""1522"" format=""[general]""  name=paciente dddw.name=dw_pacientes_mas_todos dddw.displaycolumn=nombre dddw.datacolumn=paciente dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=yes dddw.case=any dddw.required=yes dddw.nilisnull=yes dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Paciente:"" border=""0"" color=""8388608"" x=""338"" y=""224"" height=""68"" width=""293""  name=paciente_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
