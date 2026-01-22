using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dl_usuarios : IDataWindowMetadata
    {
        public string DataObject => "dl_usuarios";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "usuario",
    DbName = "acc_usuarios.usuario",
    Tipo = "char(5)",
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_usuarios.nombre",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "clave",
    DbName = "acc_usuarios.clave",
    Tipo = "char(40)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "perfil",
    DbName = "acc_usuarios.perfil",
    Tipo = "char(5)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "nombre_perfil",
    DbName = "acc_perfiles.nombre_perfil",
    Tipo = "char(20)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_usuarios.usuario,
       dba.acc_usuarios.nombre,
       dba.acc_usuarios.clave,
       dba.acc_usuarios.perfil,
       dba.acc_perfiles.nombre nombre_perfil
  FROM dba.acc_usuarios,
       dba.acc_perfiles
 WHERE dba.acc_usuarios.perfil = dba.acc_perfiles.perfil
 ORDER BY dba.acc_usuarios.nombre";

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
        public string SrdRaw => @"$PBExportHeader$dl_usuarios.srd
release 5;
datawindow(units=3 timer_interval=0 color=16777215 processing=0 print.documentname=""Listado de Usuarios"" print.orientation = 0 print.margin.left = 2000 print.margin.right = 1500 print.margin.top = 2500 print.margin.bottom = 2500 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=3201 color=""536870912"" )
summary(height=1190 color=""536870912"" )
footer(height=635 color=""536870912"" )
detail(height=582 color=""536870912""  height.autosize=yes)
table(column=(type=char(5) update=yes updatewhereclause=yes name=usuario dbname=""acc_usuarios.usuario"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=nombre dbname=""acc_usuarios.nombre"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=clave dbname=""acc_usuarios.clave"" )
 column=(type=char(5) update=yes updatewhereclause=yes name=perfil dbname=""acc_usuarios.perfil"" )
 column=(type=char(20) updatewhereclause=yes name=nombre_perfil dbname=""acc_perfiles.nombre_perfil"" )
 retrieve=""SELECT dba.acc_usuarios.usuario,
       dba.acc_usuarios.nombre,
       dba.acc_usuarios.clave,
       dba.acc_usuarios.perfil,
       dba.acc_perfiles.nombre nombre_perfil
  FROM dba.acc_usuarios,
       dba.acc_perfiles
 WHERE dba.acc_usuarios.perfil = dba.acc_perfiles.perfil
 ORDER BY dba.acc_usuarios.nombre"" )
text(band=header alignment=""2"" text=""Listado de Usuarios""border=""0"" color=""0"" x=""132"" y=""1375"" height=""661"" width=""11959""  font.face=""Arial"" font.height=""-16"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""2"" background.color=""16777215"" )
report(band=header dataobject=""r_header"" x=""12382"" y=""105"" height=""2222"" width=""5609"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  slideup=directlyabove )
line(band=header x1=""105"" y1=""3042"" x2=""16695"" y2=""3042"" pen.style=""0"" pen.width=""52"" pen.color=""0""  background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Usuario""border=""0"" color=""0"" x=""105"" y=""2619"" height=""476"" width=""1428""  name=usuario_t  font.face=""Arial"" font.height=""-11"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Nombre""border=""0"" color=""0"" x=""1719"" y=""2619"" height=""476"" width=""8096""  name=nombre_t  font.face=""Arial"" font.height=""-11"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Perfíl""border=""0"" color=""0"" x=""10001"" y=""2619"" height=""476"" width=""6720""  name=perfil_t  font.face=""Arial"" font.height=""-11"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""2"" tabsequence=10 border=""0"" color=""0"" x=""105"" y=""79"" height=""423"" width=""1428"" format=""[general]""  name=usuario edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=20 border=""0"" color=""0"" x=""1719"" y=""79"" height=""423"" width=""8096"" format=""[general]""  name=nombre edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""10001"" y=""79"" height=""423"" width=""6720"" format=""[general]""  name=nombre_perfil edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
report(band=summary dataobject=""r_summary"" x=""79"" y=""450"" height=""635"" width=""12223"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  slideup=directlyabove )
line(band=footer x1=""52"" y1=""27"" x2=""16615"" y2=""27"" pen.style=""0"" pen.width=""52"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
compute(band=footer alignment=""1"" expression=""'Página ' + Page() + ' de ' + PageCount()""border=""0"" color=""0"" x=""11403"" y=""159"" height=""396"" width=""5185"" format=""[general]""  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
";
    }
}
