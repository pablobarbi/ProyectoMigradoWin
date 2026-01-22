using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dl_modulos : IDataWindowMetadata
    {
        public string DataObject => "dl_modulos";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "modulo",
    DbName = "acc_modulos.modulo",
    Tipo = "char(5)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_modulos.nombre",
    Tipo = "char(20)",
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "bitmap",
    DbName = "acc_modulos.bitmap",
    Tipo = "char(40)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_modulos.modulo,
       dba.acc_modulos.nombre,
       dba.acc_modulos.bitmap
  FROM dba.acc_modulos
 ORDER BY dba.acc_modulos.nombre";

        // PB: table.update
        public string Update => @"acc_modulos";

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
        public string SrdRaw => @"$PBExportHeader$dl_modulos.srd
release 5;
datawindow(units=3 timer_interval=0 color=16777215 processing=0 print.documentname=""Listado de Módulos"" print.orientation = 0 print.margin.left = 2000 print.margin.right = 1500 print.margin.top = 2500 print.margin.bottom = 2500 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=3413 color=""536870912"" )
summary(height=767 color=""536870912"" )
footer(height=793 color=""536870912"" )
detail(height=608 color=""536870912"" )
table(column=(type=char(5) update=yes updatewhereclause=yes key=yes name=modulo dbname=""acc_modulos.modulo"" )
 column=(type=char(20) update=yes updatewhereclause=yes name=nombre dbname=""acc_modulos.nombre"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=bitmap dbname=""acc_modulos.bitmap"" )
 retrieve=""SELECT dba.acc_modulos.modulo,
       dba.acc_modulos.nombre,
       dba.acc_modulos.bitmap
  FROM dba.acc_modulos
 ORDER BY dba.acc_modulos.nombre"" update=""acc_modulos"" updatewhere=1 updatekeyinplace=no )
report(band=header dataobject=""r_header"" x=""11906"" y=""105"" height=""793"" width=""5609"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  slideup=directlyabove )
text(band=header alignment=""2"" text=""Listado de Módulos""border=""0"" color=""0"" x=""132"" y=""1587"" height=""661"" width=""11641""  font.face=""Arial"" font.height=""-16"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Módulo""border=""0"" color=""0"" x=""4630"" y=""2910"" height=""423"" width=""1455""  name=modulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Nombre""border=""0"" color=""0"" x=""6270"" y=""2910"" height=""423"" width=""7884""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
line(band=header x1=""4577"" y1=""3333"" x2=""14181"" y2=""3333"" pen.style=""0"" pen.width=""52"" pen.color=""0""  background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""2"" tabsequence=10 border=""0"" color=""0"" x=""4656"" y=""79"" height=""423"" width=""1455"" format=""[general]""  name=modulo edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
report(band=summary dataobject=""r_summary"" x=""4683"" y=""79"" height=""661"" width=""9233"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  slideup=directlyabove )
compute(band=footer alignment=""1"" expression=""'Página ' + Page() + ' de ' + PageCount()""border=""0"" color=""0"" x=""8890"" y=""344"" height=""396"" width=""5185"" format=""[general]""  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
line(band=footer x1=""4603"" y1=""53"" x2=""14208"" y2=""53"" pen.style=""0"" pen.width=""52"" pen.color=""0""  background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=20 border=""0"" color=""0"" x=""6297"" y=""79"" height=""423"" width=""7884"" format=""[general]""  name=nombre edit.limit=20 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
