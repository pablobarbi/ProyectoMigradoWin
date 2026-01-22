using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_sortdragdrop : IDataWindowMetadata
    {
        public string DataObject => "d_sortdragdrop";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "columnname",
    DbName = "columnname",
    Tipo = "char(50)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "sort_order",
    DbName = "sort_order",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "displayname",
    DbName = "displayname",
    Tipo = "char(10)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "use_display",
    DbName = "use_display",
    Tipo = "char(1)",
    UpdateWhereClause = true,
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
        public string SrdRaw => @"$PBExportHeader$d_sortdragdrop.srd
$PBExportComments$DataWindow usada en w_sortdw
release 6;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=4 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=68 color=""553648127"" )
table(column=(type=char(50) updatewhereclause=yes name=columnname dbname=""columnname"" )
 column=(type=char(1) updatewhereclause=yes name=sort_order dbname=""sort_order"" initial=""A"" values=""Asc	A/Asc	D"" )
 column=(type=char(10) updatewhereclause=yes name=displayname dbname=""displayname"" )
 column=(type=char(1) updatewhereclause=yes name=use_display dbname=""use_display"" )
 )
compute(band=detail alignment=""0"" expression=""~"" ~"" + displayname ""border=""6"" color=""33554687"" x=""9"" y=""4"" height=""56"" width=""663"" format=""[general]""  name=display_column  font.face=""MS Sans Serif"" font.height=""-8"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=2 alignment=""0"" tabsequence=10 border=""0"" color=""33554687"" x=""704"" y=""4"" height=""56"" width=""64"" format=""[general]""  name=sort_order checkbox.text=""Asc"" checkbox.on=""A"" checkbox.off=""D"" checkbox.scale=no checkbox.threed=yes  font.face=""MS Sans Serif"" font.height=""-8"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""1090519039"" )
htmltable(border=""1"" cellpadding=""0"" cellspacing=""0"" generatecss=""no"" nowrap=""yes"")";
    }
}
