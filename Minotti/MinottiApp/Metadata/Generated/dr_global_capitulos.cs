using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_global_capitulos : IDataWindowMetadata
    {
        public string DataObject => "dr_global_capitulos";

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
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "capitulos.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT capitulos.capitulo,
       capitulos.nombre
  FROM capitulos
 WHERE capitulos.nombre like :campo";

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
        public string SrdRaw => @"$PBExportHeader$dr_global_capitulos.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=80 color=""81324524"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912""  height.autosize=yes)
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes identity=yes name=capitulo dbname=""capitulos.capitulo"" )
 column=(type=char(255) update=yes updatewhereclause=yes name=nombre dbname=""capitulos.nombre"" )
 retrieve=""SELECT capitulos.capitulo,
       capitulos.nombre
  FROM capitulos
 WHERE capitulos.nombre like :campo
"" update=""capitulos"" updatewhere=1 updatekeyinplace=no arguments=((""campo"", string)) )
text(band=header alignment=""2"" text=""Capítulo"" border=""6"" color=""8388608"" x=""18"" y=""8"" height=""64"" width=""2359""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""18"" y=""8"" height=""68"" width=""2359"" format=""[general]""  name=nombre height.autosize=yes edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
