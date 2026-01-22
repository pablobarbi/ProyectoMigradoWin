using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_capitulos : IDataWindowMetadata
    {
        public string DataObject => "dp_capitulos";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "capitulo",
    DbName = "capitulos.capitulo",
    Tipo = "decimal(0)",
    EsClave = true,
    EsIdentity = true,
    UpdateWhereClause = true,
    EsRequerido = true,
    TabOrder = 10,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT capitulos.capitulo
  FROM capitulos";

        // PB: table.update
        public string Update => @"capitulos";

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
        public string SrdRaw => @"$PBExportHeader$dp_capitulos.srd
release 7;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=144 color=""536870912"" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes identity=yes name=capitulo dbname=""capitulos.capitulo"" )
 retrieve=""SELECT capitulos.capitulo
  FROM capitulos
"" update=""capitulos"" updatewhere=1 updatekeyinplace=no )
text(band=detail alignment=""1"" text=""Capítulo:"" border=""0"" color=""8388608"" x=""37"" y=""44"" height=""64"" width=""261""  name=capitulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""1"" tabsequence=10 border=""5"" color=""0"" x=""320"" y=""36"" height=""76"" width=""1115"" format=""[general]""  name=capitulo dddw.name=dw_capitulos dddw.displaycolumn=nombre dddw.datacolumn=capitulo dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=yes dddw.case=any dddw.required=yes dddw.nilisnull=yes dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
