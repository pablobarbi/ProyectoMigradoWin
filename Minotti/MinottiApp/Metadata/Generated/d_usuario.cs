using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_usuario : IDataWindowMetadata
    {
        public string DataObject => "d_usuario";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "usuario",
    DbName = "acc_usuarios.usuario",
    Tipo = "char(8)",
    EsClave = true,
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
    TabOrder = 30,
},

            new DataWindowColumn
{
    Nombre = "perfil",
    DbName = "acc_usuarios.perfil",
    Tipo = "char(8)",
    UpdateWhereClause = true,
    TabOrder = 40,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_usuarios.usuario,
       dba.acc_usuarios.nombre,
       dba.acc_usuarios.clave,
       dba.acc_usuarios.perfil  
  FROM dba.acc_usuarios
 WHERE dba.acc_usuarios.usuario = :usuario";

        // PB: table.update
        public string Update => @"dba.acc_usuarios";

        // PB: table.updatewhere (0/1)
        public int UpdateWhere => 0;

        // PB: table.updatekeyinplace (yes/no)
        public bool UpdateKeyInPlace => false;

        public string[] Estilos => Array.Empty<string>();
        public string[] SeleccionFila => Array.Empty<string>();
        public string Operaciones => string.Empty;

        // Inferidos (conservador) por presencia de columnas técnicas
        public bool UsaUsuario => true;
        public bool UsaFecha => false;

        // SRD completo (lossless) por si todavía no existe property en C#
        public string SrdRaw => @"$PBExportHeader$d_usuario.srd
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=1 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=481 color=""536870912"" )
table(column=(type=char(8) update=yes updatewhereclause=yes key=yes name=usuario dbname=""acc_usuarios.usuario"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=nombre dbname=""acc_usuarios.nombre"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=clave dbname=""acc_usuarios.clave"" )
 column=(type=char(8) update=yes updatewhereclause=yes name=perfil dbname=""acc_usuarios.perfil"" )
 retrieve=""SELECT dba.acc_usuarios.usuario,
       dba.acc_usuarios.nombre,
       dba.acc_usuarios.clave,
       dba.acc_usuarios.perfil  
  FROM dba.acc_usuarios
 WHERE dba.acc_usuarios.usuario = :usuario
"" update=""dba.acc_usuarios"" updatewhere=0 updatekeyinplace=no arguments=((""usuario"", string)) )
column(band=detail id=2 alignment=""0"" tabsequence=20 border=""5"" color=""0"" x=""321"" y=""152"" height=""73"" width=""1399"" format=""[general]""  name=nombre edit.limit=50 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""1086902488"" )
text(band=detail alignment=""1"" text=""Nombre:""border=""0"" color=""8388608"" x=""46"" y=""152"" height=""73"" width=""247""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Clave:""border=""0"" color=""8388608"" x=""110"" y=""268"" height=""73"" width=""183""  name=clave_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""0"" tabsequence=40 border=""5"" color=""0"" x=""321"" y=""384"" height=""73"" width=""810"" format=""[general]""  name=perfil dddw.name=dw_perfiles dddw.displaycolumn=nombre dddw.datacolumn=perfil dddw.percentwidth=100 dddw.lines=6 dddw.limit=0 dddw.allowedit=yes dddw.useasborder=yes dddw.case=any dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""1086902488"" )
text(band=detail alignment=""1"" text=""Perfíl:""border=""0"" color=""8388608"" x=""119"" y=""384"" height=""73"" width=""174""  name=perfil_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Usuario:""border=""0"" color=""8388608"" x=""55"" y=""32"" height=""73"" width=""238""  name=usuario_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=10 border=""5"" color=""0"" x=""321"" y=""32"" height=""73"" width=""343"" format=""[general]""  name=usuario edit.limit=5 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=3 alignment=""0"" tabsequence=30 border=""5"" color=""0"" x=""321"" y=""268"" height=""73"" width=""343"" format=""[general]""  name=clave edit.limit=40 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""1086902488"" )
";
    }
}
