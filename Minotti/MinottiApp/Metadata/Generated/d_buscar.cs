using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_buscar : IDataWindowMetadata
    {
        public string DataObject => "d_buscar";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "campo",
    DbName = "campo",
    Tipo = "char(60)",
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
        public bool UsaUsuario => false;
        public bool UsaFecha => false;

        // SRD completo (lossless) por si todavía no existe property en C#
        public string SrdRaw => @"$PBExportHeader$d_buscar.srd
$PBExportComments$Dw usada en la ventana w_seleccion_datos dddw.
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=1 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=81 color=""536870912"" )
table(column=(type=char(60) updatewhereclause=no name=campo dbname=""campo"" validation=""IsNumber(Gettext())"" validationmsg=""~""Error : ~"" + gettext()"" )
 )
column(band=detail id=1 alignment=""0"" tabsequence=10 border=""5"" color=""0"" x=""19"" y=""4"" height=""69"" width=""1299"" format=""[general]""  name=campo pointer=""IBeam!"" edit.limit=60 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
";
    }
}
