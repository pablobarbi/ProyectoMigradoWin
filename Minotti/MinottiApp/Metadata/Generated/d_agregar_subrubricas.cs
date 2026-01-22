using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_agregar_subrubricas : IDataWindowMetadata
    {
        public string DataObject => "d_agregar_subrubricas";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "subrubricas.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 10,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT subrubricas.nombre
  FROM subrubricas";

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
        public string SrdRaw => @"$PBExportHeader$d_agregar_subrubricas.srd
release 7;
datawindow(units=0 timer_interval=0 color=82899184 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=316 color=""536870912"" )
table(column=(type=char(255) updatewhereclause=yes name=nombre dbname=""subrubricas.nombre"" )
 retrieve=""SELECT subrubricas.nombre
  FROM subrubricas
"" )
text(band=detail alignment=""1"" text=""Subrubrica:"" border=""0"" color=""8388608"" x=""50"" y=""24"" height=""64"" width=""338""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=10 border=""5"" color=""0"" x=""50"" y=""112"" height=""184"" width=""2309"" format=""[general]""  name=nombre edit.limit=255 edit.case=upper edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autovscroll=yes edit.vscrollbar=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
