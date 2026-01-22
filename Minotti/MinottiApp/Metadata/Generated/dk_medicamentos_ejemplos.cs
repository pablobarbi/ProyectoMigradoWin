using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_medicamentos_ejemplos : IDataWindowMetadata
    {
        public string DataObject => "dk_medicamentos_ejemplos";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "medicamento",
    DbName = "medicamentos.medicamento",
    Tipo = "char(10)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "descripcion",
    DbName = "medicamentos.descripcion",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "seleccionado",
    DbName = "seleccionado",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 10,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT medicamentos.medicamento,
       medicamentos.descripcion,
       ' ' seleccionado
  FROM medicamentos";

        // PB: table.update
        public string Update => @"medicamentos";

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
        public string SrdRaw => @"$PBExportHeader$dk_medicamentos_ejemplos.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=88 color=""82899184"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=88 color=""536870912""  height.autosize=yes)
table(column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento dbname=""medicamentos.medicamento"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=descripcion dbname=""medicamentos.descripcion"" )
 column=(type=char(1) updatewhereclause=yes name=seleccionado dbname=""seleccionado"" values=""1	1/2	2/3	3/"" )
 retrieve=""SELECT medicamentos.medicamento,
       medicamentos.descripcion,
       ' ' seleccionado
  FROM medicamentos
"" update=""medicamentos"" updatewhere=1 updatekeyinplace=no )
group(level=1 header.height=0 trailer.height=0 by=(""seleccionado"" ) header.color=""82899184"" trailer.color=""536870912"" )
text(band=header alignment=""2"" text=""Descripcion"" border=""6"" color=""8388608"" x=""457"" y=""12"" height=""64"" width=""1399""  name=descripcion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Medicamento"" border=""6"" color=""8388608"" x=""18"" y=""12"" height=""64"" width=""421""  name=medicamento_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""457"" y=""4"" height=""76"" width=""1399"" format=""[general]""  name=descripcion edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""23"" y=""4"" height=""76"" width=""421"" format=""[general]""  name=medicamento edit.limit=10 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Valor"" border=""6"" color=""8388608"" x=""1879"" y=""12"" height=""64"" width=""210""  name=t_1  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=3 alignment=""0"" tabsequence=10 border=""5"" color=""0"" x=""1879"" y=""8"" height=""68"" width=""210"" format=""[general]""  name=seleccionado ddlb.limit=0 ddlb.allowedit=no ddlb.case=any ddlb.nilisnull=yes ddlb.useasborder=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
