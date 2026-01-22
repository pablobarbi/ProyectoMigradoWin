using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dsto_medicamentos_reperto_parc : IDataWindowMetadata
    {
        public string DataObject => "dsto_medicamentos_reperto_parc";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "reperto_parcial",
    DbName = "reperto_parcial_med.reperto_parcial",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "orden",
    DbName = "reperto_parcial_med.orden",
    Tipo = "long",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "medicamento",
    DbName = "reperto_parcial_med.medicamento",
    Tipo = "char(10)",
    UpdateWhereClause = true,
    TabOrder = 30,
},

            new DataWindowColumn
{
    Nombre = "valor",
    DbName = "reperto_parcial_med.valor",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 40,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT reperto_parcial_med.reperto_parcial,
       reperto_parcial_med.orden,
       reperto_parcial_med.medicamento,
       reperto_parcial_med.valor
  FROM reperto_parcial_med
 WHERE reperto_parcial_med.reperto_parcial = :reperto_parc
 ORDER BY reperto_parcial_med.orden";

        // PB: table.update
        public string Update => @"reperto_parcial_med";

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
        public string SrdRaw => @"$PBExportHeader$dsto_medicamentos_reperto_parc.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=72 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912"" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_parcial dbname=""reperto_parcial_med.reperto_parcial"" )
 column=(type=long update=yes updatewhereclause=yes key=yes name=orden dbname=""reperto_parcial_med.orden"" )
 column=(type=char(10) update=yes updatewhereclause=yes name=medicamento dbname=""reperto_parcial_med.medicamento"" )
 column=(type=long update=yes updatewhereclause=yes name=valor dbname=""reperto_parcial_med.valor"" )
 retrieve=""SELECT reperto_parcial_med.reperto_parcial,
       reperto_parcial_med.orden,
       reperto_parcial_med.medicamento,
       reperto_parcial_med.valor
  FROM reperto_parcial_med
 WHERE reperto_parcial_med.reperto_parcial = :reperto_parc
 ORDER BY reperto_parcial_med.orden
"" update=""reperto_parcial_med"" updatewhere=1 updatekeyinplace=no arguments=((""reperto_parc"", string)) )
text(band=header alignment=""2"" text=""Reperto Parcial"" border=""0"" color=""0"" x=""5"" y=""4"" height=""64"" width=""407""  name=reperto_parcial_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Orden"" border=""0"" color=""0"" x=""416"" y=""4"" height=""64"" width=""329""  name=orden_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Medicamento"" border=""0"" color=""0"" x=""750"" y=""4"" height=""64"" width=""357""  name=medicamento_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Valor"" border=""0"" color=""0"" x=""1111"" y=""4"" height=""64"" width=""329""  name=valor_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""1"" tabsequence=10 border=""0"" color=""0"" x=""5"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=reperto_parcial edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""1"" tabsequence=20 border=""0"" color=""0"" x=""416"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=orden edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=30 border=""0"" color=""0"" x=""750"" y=""4"" height=""76"" width=""302"" format=""[general]""  name=medicamento edit.limit=10 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""1"" tabsequence=40 border=""0"" color=""0"" x=""1111"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=valor edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
