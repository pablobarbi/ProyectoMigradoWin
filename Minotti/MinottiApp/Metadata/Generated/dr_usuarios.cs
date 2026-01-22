using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_usuarios : IDataWindowMetadata
    {
        public string DataObject => "dr_usuarios";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "usuario",
    DbName = "acc_usuarios.usuario",
    Tipo = "char(5)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_usuarios.nombre",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 32766,
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
        public string SrdRaw => @"$PBExportHeader$dr_usuarios.srd
release 5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=89 color=""12632256"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=93 color=""536870912"" )
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
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""298"" y=""12"" height=""65"" width=""1399"" format=""[general]""  name=nombre edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1729"" y=""12"" height=""65"" width=""1162"" format=""[general]""  name=nombre_perfil edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""19"" y=""12"" height=""65"" width=""247"" format=""[general]""  name=usuario edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Perfíl""border=""6"" color=""8388608"" x=""1729"" y=""16"" height=""65"" width=""1162""  name=perfil_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Nombre""border=""6"" color=""8388608"" x=""298"" y=""16"" height=""65"" width=""1399""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Usuario""border=""6"" color=""8388608"" x=""19"" y=""16"" height=""65"" width=""247""  name=usuario_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
