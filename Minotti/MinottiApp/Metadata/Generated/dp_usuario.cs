using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_usuario : IDataWindowMetadata
    {
        public string DataObject => "dp_usuario";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "usuario",
    DbName = "usuario",
    Tipo = "char(5)",
    UpdateWhereClause = true,
    TabOrder = 10,
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
        public bool UsaUsuario => true;
        public bool UsaFecha => false;

        // SRD completo (lossless) por si todavía no existe property en C#
        public string SrdRaw => @"$PBExportHeader$dp_usuario.srd
$PBExportComments$Parámetros. Usuario.
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=1 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=97 color=""536870912"" )
table(column=(type=char(5) updatewhereclause=yes name=usuario dbname=""usuario"" )
 )
text(band=detail alignment=""1"" text=""Usuario:""border=""0"" color=""8388608"" x=""28"" y=""12"" height=""69"" width=""238""  name=usuario_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=10 border=""5"" color=""0"" x=""293"" y=""12"" height=""69"" width=""1185"" format=""[general]""  name=usuario dddw.name=dw_usuarios dddw.displaycolumn=display dddw.datacolumn=usuario dddw.percentwidth=100 dddw.lines=6 dddw.limit=0 dddw.allowedit=yes dddw.useasborder=yes dddw.case=any dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""15793151"" )
";
    }
}
