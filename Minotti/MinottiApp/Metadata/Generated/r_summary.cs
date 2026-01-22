using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class r_summary : IDataWindowMetadata
    {
        public string DataObject => "r_summary";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "compute_0001",
    DbName = "compute_0001",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT count(*) FROM dba.acc_usuarios";

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
        public string SrdRaw => @"$PBExportHeader$r_summary.srd
release 5;
datawindow(units=3 timer_interval=0 color=16777215 processing=0 print.documentname="""" print.orientation = 2 print.margin.left = 2000 print.margin.right = 1000 print.margin.top = 2000 print.margin.bottom = 1000 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=582 color=""553648127"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=0 color=""536870912"" )
table(column=(type=decimal(0) updatewhereclause=yes name=compute_0001 dbname=""compute_0001"" )
 retrieve=""SELECT count(*) FROM dba.acc_usuarios"" )
line(band=header x1=""26"" y1=""26"" x2=""17462"" y2=""26"" pen.style=""0"" pen.width=""26"" pen.color=""0""  background.mode=""1"" background.color=""536870912"" )
compute(band=header alignment=""0"" expression=""today()""border=""0"" color=""33554432"" x=""158"" y=""132"" height=""423"" width=""1693"" format=""[general]""  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=header alignment=""1"" expression=""'Página ' + page() + ' de ' + pageCount()""border=""0"" color=""33554432"" x=""10953"" y=""158"" height=""423"" width=""6402"" format=""[general]""  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""4048"" y=""0"" height=""502"" width=""7963"" format=""[general]""  name=compute_0001 edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
line(band=footer x1=""238"" y1=""2884"" x2=""18176"" y2=""2884"" pen.style=""0"" pen.width=""26"" pen.color=""0""  background.mode=""1"" background.color=""536870912"" )
";
    }
}
