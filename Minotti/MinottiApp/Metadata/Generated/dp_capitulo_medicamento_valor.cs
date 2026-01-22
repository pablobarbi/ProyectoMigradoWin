using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_capitulo_medicamento_valor : IDataWindowMetadata
    {
        public string DataObject => "dp_capitulo_medicamento_valor";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "capitulo",
    DbName = "capitulacion_med.capitulo",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "medicamento",
    DbName = "capitulacion_med.medicamento",
    Tipo = "char(10)",
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "valor",
    DbName = "capitulacion_med.valor",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 30,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT capitulacion_med.capitulo,
       capitulacion_med.medicamento,
       capitulacion_med.valor
  FROM capitulacion_med";

        // PB: table.update
        public string Update => @"";

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
        public string SrdRaw => @"$PBExportHeader$dp_capitulo_medicamento_valor.srd
release 7;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=224 color=""536870912"" )
table(column=(type=decimal(0) updatewhereclause=yes name=capitulo dbname=""capitulacion_med.capitulo"" )
 column=(type=char(10) updatewhereclause=yes name=medicamento dbname=""capitulacion_med.medicamento"" )
 column=(type=long updatewhereclause=yes name=valor dbname=""capitulacion_med.valor"" values=""1	1/2	2/3	3/"" )
 retrieve=""SELECT capitulacion_med.capitulo,
       capitulacion_med.medicamento,
       capitulacion_med.valor
  FROM capitulacion_med
"" )
text(band=detail alignment=""1"" text=""Capítulo:"" border=""0"" color=""8388608"" x=""69"" y=""32"" height=""68"" width=""375""  name=capitulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Medicamento:"" border=""0"" color=""8388608"" x=""32"" y=""128"" height=""68"" width=""411""  name=medicamento_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""1"" tabsequence=10 border=""5"" color=""0"" x=""471"" y=""32"" height=""68"" width=""1115"" format=""[general]""  name=capitulo dddw.name=dw_capitulos dddw.displaycolumn=nombre dddw.datacolumn=capitulo dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=yes dddw.case=any dddw.nilisnull=yes dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=2 alignment=""0"" tabsequence=20 border=""5"" color=""0"" x=""471"" y=""128"" height=""68"" width=""608"" format=""[general]""  name=medicamento dddw.name=dw_medicamentos dddw.displaycolumn=medicamento dddw.datacolumn=medicamento dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=yes dddw.case=any dddw.nilisnull=yes dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Valor:"" border=""0"" color=""8388608"" x=""1115"" y=""128"" height=""68"" width=""197""  name=valor_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""1"" tabsequence=30 border=""5"" color=""0"" x=""1339"" y=""128"" height=""68"" width=""242"" format=""[general]""  name=valor ddlb.limit=0 ddlb.allowedit=no ddlb.case=any ddlb.nilisnull=yes ddlb.useasborder=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
