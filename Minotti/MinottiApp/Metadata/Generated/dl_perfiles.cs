using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dl_perfiles : IDataWindowMetadata
    {
        public string DataObject => "dl_perfiles";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "perfil",
    DbName = "acc_perfiles.perfil",
    Tipo = "char(5)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_perfiles.nombre",
    Tipo = "char(20)",
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "bitmap",
    DbName = "acc_perfiles.bitmap",
    Tipo = "char(40)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_perfiles.perfil,
       dba.acc_perfiles.nombre,
       dba.acc_perfiles.bitmap
  FROM dba.acc_perfiles
 ORDER BY dba.acc_perfiles.nombre";

        // PB: table.update
        public string Update => @"acc_perfiles";

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
        public string SrdRaw => @"$PBExportHeader$dl_perfiles.srd
release 5;
datawindow(units=3 timer_interval=0 color=16777215 processing=0 print.documentname=""Listado de Perfiles de Usuario"" print.orientation = 0 print.margin.left = 2000 print.margin.right = 1500 print.margin.top = 2500 print.margin.bottom = 2500 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=3307 color=""536870912"" )
summary(height=1164 color=""536870912"" )
footer(height=635 color=""536870912"" )
detail(height=582 color=""536870912""  height.autosize=yes)
table(column=(type=char(5) update=yes updatewhereclause=yes key=yes name=perfil dbname=""acc_perfiles.perfil"" )
 column=(type=char(20) update=yes updatewhereclause=yes name=nombre dbname=""acc_perfiles.nombre"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=bitmap dbname=""acc_perfiles.bitmap"" )
 retrieve=""SELECT dba.acc_perfiles.perfil,
       dba.acc_perfiles.nombre,
       dba.acc_perfiles.bitmap
  FROM dba.acc_perfiles
 ORDER BY dba.acc_perfiles.nombre
"" update=""acc_perfiles"" updatewhere=1 updatekeyinplace=no )
text(band=header alignment=""2"" text=""Listado de Perfiles de Usuario""border=""0"" color=""0"" x=""105"" y=""1375"" height=""661"" width=""11694""  font.face=""Arial"" font.height=""-16"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""2"" background.color=""16777215"" )
report(band=header dataobject=""r_header"" x=""11932"" y=""79"" height=""793"" width=""5609"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  slideup=directlyabove )
column(band=detail id=1 alignment=""2"" tabsequence=10 border=""0"" color=""0"" x=""3651"" y=""79"" height=""423"" width=""1243"" format=""[general]""  name=perfil edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=20 border=""0"" color=""0"" x=""5080"" y=""79"" height=""423"" width=""7884"" format=""[general]""  name=nombre edit.limit=20 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
report(band=summary dataobject=""r_summary"" x=""3545"" y=""476"" height=""661"" width=""9233"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  slideup=directlyabove )
line(band=footer x1=""3624"" y1=""53"" x2=""12991"" y2=""53"" pen.style=""0"" pen.width=""52"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
compute(band=footer alignment=""1"" expression=""'Página ' + Page() + ' de ' + PageCount()""border=""0"" color=""0"" x=""7911"" y=""185"" height=""396"" width=""5185"" format=""[general]""  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=header alignment=""2"" text=""Perfíl""border=""0"" color=""0"" x=""3651"" y=""2804"" height=""423"" width=""1243""  name=perfil_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
line(band=header x1=""3624"" y1=""3227"" x2=""12991"" y2=""3227"" pen.style=""0"" pen.width=""52"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
text(band=header alignment=""2"" text=""Nombre""border=""0"" color=""0"" x=""5080"" y=""2804"" height=""423"" width=""7884""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
