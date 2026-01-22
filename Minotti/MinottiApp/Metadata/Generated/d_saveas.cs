using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_saveas : IDataWindowMetadata
    {
        public string DataObject => "d_saveas";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "columnname",
    DbName = "columnname",
    Tipo = "char(50)",
},

            new DataWindowColumn
{
    Nombre = "displayname",
    DbName = "displayname",
    Tipo = "char(10)",
},

            new DataWindowColumn
{
    Nombre = "use_display",
    DbName = "use_display",
    Tipo = "char(1)",
}
        };

        // PB: table.retrieve
        public string Sql => @"";

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
        public string SrdRaw => @"$PBExportHeader$d_saveas.srd
$PBExportComments$DataWindow usada en w_sortdw
release 7;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=4 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=68 color=""553648127"" )
table(column=(type=char(50) updatewhereclause=no name=columnname dbname=""columnname"" )
 column=(type=char(10) updatewhereclause=no name=displayname dbname=""displayname"" )
 column=(type=char(1) updatewhereclause=no name=use_display dbname=""use_display"" )
 )
compute(band=detail alignment=""0"" expression=""~"" ~"" + displayname ""border=""6"" color=""33554687"" x=""9"" y=""4"" height=""56"" width=""663"" format=""[general]""  name=display_column  font.face=""MS Sans Serif"" font.height=""-8"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
