using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_operaciones_por_usuario : IDataWindowMetadata
    {
        public string DataObject => "dr_operaciones_por_usuario";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "usuario",
    DbName = "acc_usuarios.usuario",
    Tipo = "char(5)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "nombre_usuario",
    DbName = "acc_usuarios.nombre_usuario",
    Tipo = "char(50)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "modulo",
    DbName = "acc_operaciones_x_modulo.modulo",
    Tipo = "char(5)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "nombre_modulo",
    DbName = "acc_modulos.nombre",
    Tipo = "char(20)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "bitmap_modulo",
    DbName = "acc_modulos.bitmap",
    Tipo = "char(40)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "operacion",
    DbName = "acc_operaciones_x_modulo.operacion",
    Tipo = "char(5)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "nombre_operacion",
    DbName = "acc_operaciones.nombre",
    Tipo = "char(30)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "bitmap_operacion",
    DbName = "acc_operaciones.bitmap",
    Tipo = "char(40)",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "alta",
    DbName = "alta",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "baja",
    DbName = "baja",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "modificacion",
    DbName = "modificacion",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_usuarios.usuario,
       dba.acc_usuarios.nombre nombre_usuario,
       dba.acc_operaciones_x_modulo.modulo,
       dba.acc_modulos.nombre,
       dba.acc_modulos.bitmap,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones.nombre,
       dba.acc_operaciones.bitmap,
       upper(dba.acc_operaciones_x_modulo.alta) alta,
       upper(dba.acc_operaciones_x_modulo.baja) baja,
       upper(dba.acc_operaciones_x_modulo.modificacion) modificacion
  FROM dba.acc_modulos,
       dba.acc_operaciones,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil,
       dba.acc_usuarios
 WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo
   AND dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = dba.acc_usuarios.perfil
   AND dba.acc_usuarios.usuario = :usuario
 ORDER BY dba.acc_modulos.nombre,
          dba.acc_operaciones.nombre";

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
        public string SrdRaw => @"$PBExportHeader$dr_operaciones_por_usuario.srd
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=205 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=81 color=""536870912"" )
table(column=(type=char(5) updatewhereclause=yes name=usuario dbname=""acc_usuarios.usuario"" )
 column=(type=char(50) updatewhereclause=yes name=nombre_usuario dbname=""acc_usuarios.nombre_usuario"" )
 column=(type=char(5) updatewhereclause=yes name=modulo dbname=""acc_operaciones_x_modulo.modulo"" )
 column=(type=char(20) updatewhereclause=yes name=nombre_modulo dbname=""acc_modulos.nombre"" )
 column=(type=char(40) updatewhereclause=yes name=bitmap_modulo dbname=""acc_modulos.bitmap"" )
 column=(type=char(5) updatewhereclause=yes name=operacion dbname=""acc_operaciones_x_modulo.operacion"" )
 column=(type=char(30) updatewhereclause=yes name=nombre_operacion dbname=""acc_operaciones.nombre"" )
 column=(type=char(40) updatewhereclause=yes name=bitmap_operacion dbname=""acc_operaciones.bitmap"" )
 column=(type=char(1) updatewhereclause=yes name=alta dbname=""alta"" values=""	S/	N"" )
 column=(type=char(1) updatewhereclause=yes name=baja dbname=""baja"" values=""	S/	N"" )
 column=(type=char(1) updatewhereclause=yes name=modificacion dbname=""modificacion"" values=""	S/	N"" )
 retrieve=""SELECT dba.acc_usuarios.usuario,
       dba.acc_usuarios.nombre nombre_usuario,
       dba.acc_operaciones_x_modulo.modulo,
       dba.acc_modulos.nombre,
       dba.acc_modulos.bitmap,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones.nombre,
       dba.acc_operaciones.bitmap,
       upper(dba.acc_operaciones_x_modulo.alta) alta,
       upper(dba.acc_operaciones_x_modulo.baja) baja,
       upper(dba.acc_operaciones_x_modulo.modificacion) modificacion
  FROM dba.acc_modulos,
       dba.acc_operaciones,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil,
       dba.acc_usuarios
 WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo
   AND dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = dba.acc_usuarios.perfil
   AND dba.acc_usuarios.usuario = :usuario
 ORDER BY dba.acc_modulos.nombre,
          dba.acc_operaciones.nombre
"" arguments=((""usuario"", string)) )
compute(band=header alignment=""2"" expression=""'Usuario: ' + nombre_usuario + ' - ( ' + usuario + ' )'""border=""0"" color=""0"" x=""28"" y=""12"" height=""85"" width=""2858"" format=""[general]""  font.face=""Arial"" font.height=""-12"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Alta""border=""0"" color=""8388608"" x=""1710"" y=""124"" height=""73"" width=""371""  name=alta_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
line(band=header x1=""23"" y1=""192"" x2=""2871"" y2=""192"" pen.style=""0"" pen.width=""5"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
text(band=header alignment=""2"" text=""Modificación""border=""0"" color=""8388608"" x=""2515"" y=""124"" height=""73"" width=""371""  name=modificacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Baja""border=""0"" color=""8388608"" x=""2113"" y=""124"" height=""73"" width=""371""  name=baja_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Operación""border=""0"" color=""8388608"" x=""28"" y=""124"" height=""73"" width=""330""  name=operacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Nombre""border=""0"" color=""8388608"" x=""385"" y=""124"" height=""73"" width=""1299""  name=nombre_operacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=9 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1861"" y=""8"" height=""65"" width=""65"" format=""[general]""  name=alta checkbox.text="""" checkbox.on=""S"" checkbox.off=""N"" checkbox.scale=no checkbox.threed=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=11 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2666"" y=""8"" height=""65"" width=""65"" format=""""  name=modificacion checkbox.text="""" checkbox.on=""S"" checkbox.off=""N"" checkbox.scale=no checkbox.threed=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=10 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2263"" y=""8"" height=""65"" width=""65"" format=""[general]""  name=baja checkbox.text="""" checkbox.on=""S"" checkbox.off=""N"" checkbox.scale=no checkbox.threed=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=7 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""385"" y=""8"" height=""65"" width=""1299"" format=""[general]""  name=nombre_operacion edit.limit=30 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=6 alignment=""2"" tabsequence=32766 border=""0"" color=""0"" x=""28"" y=""8"" height=""65"" width=""330"" format=""[general]""  name=operacion edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
