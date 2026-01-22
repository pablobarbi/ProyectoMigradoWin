using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dl_operaciones_por_usuario : IDataWindowMetadata
    {
        public string DataObject => "dl_operaciones_por_usuario";

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
        public string SrdRaw => @"$PBExportHeader$dl_operaciones_por_usuario.srd
release 5;
datawindow(units=3 timer_interval=0 color=16777215 processing=0 print.documentname=""Listado de operac. por usuario"" print.orientation = 0 print.margin.left = 2000 print.margin.right = 1500 print.margin.top = 2500 print.margin.bottom = 2500 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=3862 color=""536870912"" )
summary(height=1137 color=""536870912"" )
footer(height=582 color=""536870912"" )
detail(height=529 color=""536870912"" )
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
column(band=detail id=9 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""10768"" y=""53"" height=""423"" width=""370"" format=""[general]""  name=alta checkbox.text="""" checkbox.on=""S"" checkbox.off=""N"" checkbox.scale=no checkbox.threed=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=11 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""15425"" y=""53"" height=""423"" width=""370"" format=""""  name=modificacion checkbox.text="""" checkbox.on=""S"" checkbox.off=""N"" checkbox.scale=no checkbox.threed=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=10 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""13096"" y=""53"" height=""423"" width=""370"" format=""[general]""  name=baja checkbox.text="""" checkbox.on=""S"" checkbox.off=""N"" checkbox.scale=no checkbox.threed=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
report(band=header dataobject=""r_header"" x=""11456"" y=""158"" height=""793"" width=""5609"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  slideup=directlyabove )
column(band=detail id=7 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2222"" y=""53"" height=""423"" width=""7514"" format=""[general]""  name=nombre_operacion edit.limit=30 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=6 alignment=""2"" tabsequence=32766 border=""0"" color=""0"" x=""158"" y=""53"" height=""423"" width=""1905"" format=""[general]""  name=operacion edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
line(band=header x1=""132"" y1=""3783"" x2=""16615"" y2=""3783"" pen.style=""0"" pen.width=""52"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
text(band=header alignment=""2"" text=""Modificación""border=""0"" color=""8388608"" x=""14552"" y=""3333"" height=""476"" width=""2143""  name=modificacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Baja""border=""0"" color=""8388608"" x=""12223"" y=""3333"" height=""476"" width=""2143""  name=baja_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Operación""border=""0"" color=""8388608"" x=""158"" y=""3333"" height=""476"" width=""1905""  name=operacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Nombre""border=""0"" color=""8388608"" x=""2222"" y=""3333"" height=""476"" width=""7514""  name=nombre_operacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Alta""border=""0"" color=""8388608"" x=""9895"" y=""3333"" height=""476"" width=""2143""  name=alta_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
report(band=summary dataobject=""r_summary"" x=""79"" y=""397"" height=""714"" width=""12223"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  slideup=directlyabove )
compute(band=footer alignment=""1"" expression=""'Página ' + Page() + ' de ' + PageCount()""border=""0"" color=""0"" x=""11377"" y=""106"" height=""396"" width=""5185"" format=""[general]""  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
line(band=footer x1=""132"" y1=""26"" x2=""16615"" y2=""26"" pen.style=""0"" pen.width=""52"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
text(band=header alignment=""2"" text=""Listado de Operaciones permitidas para el usuario""border=""0"" color=""0"" x=""238"" y=""952"" height=""661"" width=""11006""  font.face=""Arial"" font.height=""-16"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""553648127""  height.autosize=yes)
compute(band=header alignment=""2"" expression=""nombre_usuario + ' - ( ' + usuario + ' )'""border=""0"" color=""0"" x=""238"" y=""2592"" height=""555"" width=""11006"" format=""[general]""  font.face=""Arial"" font.height=""-12"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
