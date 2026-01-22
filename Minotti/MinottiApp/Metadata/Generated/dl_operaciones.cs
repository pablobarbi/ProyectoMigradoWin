using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dl_operaciones : IDataWindowMetadata
    {
        public string DataObject => "dl_operaciones";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "operacion",
    DbName = "acc_operaciones.operacion",
    Tipo = "char(8)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_operaciones.nombre",
    Tipo = "char(40)",
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "bitmap",
    DbName = "acc_operaciones.bitmap",
    Tipo = "char(40)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_operaciones.operacion,
       dba.acc_operaciones.nombre,
       dba.acc_operaciones.bitmap
  FROM dba.acc_operaciones
 ORDER BY dba.acc_operaciones.nombre";

        // PB: table.update
        public string Update => @"dba.acc_operaciones";

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
        public string SrdRaw => @"$PBExportHeader$dl_operaciones.srd
release 5;
datawindow(units=3 timer_interval=0 color=16777215 processing=0 print.documentname=""Listado de Operaciones"" print.orientation = 0 print.margin.left = 2000 print.margin.right = 1500 print.margin.top = 2500 print.margin.bottom = 2500 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=3466 color=""536870912"" )
summary(height=1190 color=""536870912"" )
footer(height=635 color=""536870912"" )
detail(height=767 color=""553648127""  height.autosize=yes)
table(column=(type=char(8) update=yes updatewhereclause=yes key=yes name=operacion dbname=""acc_operaciones.operacion"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=nombre dbname=""acc_operaciones.nombre"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=bitmap dbname=""acc_operaciones.bitmap"" )
 retrieve=""SELECT dba.acc_operaciones.operacion,
       dba.acc_operaciones.nombre,
       dba.acc_operaciones.bitmap
  FROM dba.acc_operaciones
 ORDER BY dba.acc_operaciones.nombre"" update=""dba.acc_operaciones"" updatewhere=1 updatekeyinplace=no )
report(band=header dataobject=""r_header"" x=""12726"" y=""79"" height=""2222"" width=""5609"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  slideup=directlyabove )
text(band=header alignment=""2"" text=""Listado de Operaciones""border=""0"" color=""0"" x=""2434"" y=""1243"" height=""661"" width=""9710""  font.face=""Arial"" font.height=""-16"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""536870912"" )
report(band=summary dataobject=""r_summary"" x=""2487"" y=""396"" height=""635"" width=""10027"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  slideup=directlyabove )
compute(band=footer alignment=""1"" expression=""'Página ' + Page() + ' de ' + PageCount()""border=""0"" color=""0"" x=""8387"" y=""106"" height=""396"" width=""5185"" format=""[general]""  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Nombre""border=""0"" color=""0"" x=""4683"" y=""2936"" height=""476"" width=""8757""  name=nombre_t  font.face=""Arial"" font.height=""-11"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Operación""border=""0"" color=""0"" x=""2513"" y=""2936"" height=""476"" width=""2037""  name=operacion_t  font.face=""Arial"" font.height=""-11"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""2"" tabsequence=10 border=""0"" color=""0"" x=""2513"" y=""159"" height=""423"" width=""2037"" format=""[general]""  name=operacion edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=20 border=""0"" color=""0"" x=""4683"" y=""159"" height=""423"" width=""8757"" format=""[general]""  name=nombre height.autosize=yes edit.limit=30 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
line(band=header x1=""2487"" y1=""3360"" x2=""13493"" y2=""3360"" pen.style=""0"" pen.width=""52"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
line(band=footer x1=""2487"" y1=""27"" x2=""13493"" y2=""27"" pen.style=""0"" pen.width=""52"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
";
    }
}
