using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_global_busqueda : IDataWindowMetadata
    {
        public string DataObject => "dp_global_busqueda";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "campo",
    DbName = "campo",
    Tipo = "char(255)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 10,
}
        };

        // PB: table.retrieve
        public string Sql => @"";

        // PB: table.update
        public string Update => @"x";

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
        public string SrdRaw => @"$PBExportHeader$dp_global_busqueda.srd
release 7;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=380 color=""536870912"" )
table(column=(type=char(255) update=yes updatewhereclause=yes key=yes name=campo dbname=""campo"" )
 update=""x"" updatewhere=0 updatekeyinplace=no )
text(band=detail alignment=""1"" text=""Ingrese el texto a buscar:"" border=""0"" color=""8388608"" x=""27"" y=""12"" height=""64"" width=""736""  name=campo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=10 border=""5"" color=""0"" x=""18"" y=""96"" height=""256"" width=""2693"" format=""[general]""  name=campo edit.limit=0 edit.case=upper edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
