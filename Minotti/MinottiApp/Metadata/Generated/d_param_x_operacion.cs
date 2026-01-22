using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_param_x_operacion : IDataWindowMetadata
    {
        public string DataObject => "d_param_x_operacion";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "operacion",
    DbName = "acc_parametros.operacion",
    Tipo = "char(5)",
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "orden",
    DbName = "acc_parametros.orden",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "titulo",
    DbName = "acc_parametros.titulo",
    Tipo = "char(80)",
    UpdateWhereClause = true,
    TabOrder = 30,
},

            new DataWindowColumn
{
    Nombre = "objeto",
    DbName = "acc_parametros.objeto",
    Tipo = "char(40)",
    UpdateWhereClause = true,
    TabOrder = 40,
},

            new DataWindowColumn
{
    Nombre = "parametros",
    DbName = "acc_parametros.parametros",
    Tipo = "char(256)",
    UpdateWhereClause = true,
    TabOrder = 50,
},

            new DataWindowColumn
{
    Nombre = "cierra",
    DbName = "acc_parametros.cierra",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 60,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT DISTINCT 
		 dba.acc_parametros.operacion,
       dba.acc_parametros.orden,
       dba.acc_parametros.titulo,
       dba.acc_parametros.objeto,
       dba.acc_parametros.parametros,
       dba.acc_parametros.cierra
  FROM dba.acc_parametros,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil
 WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_parametros.operacion
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = :perfil
 ORDER BY dba.acc_parametros.operacion,
       dba.acc_parametros.orden";

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
        public string SrdRaw => @"$PBExportHeader$d_param_x_operacion.srd
$PBExportComments$Menúes. Muestra los parámetros de todas las operaciones.
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=101 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=113 color=""536870912"" )
table(column=(type=char(5) update=yes updatewhereclause=yes name=operacion dbname=""acc_parametros.operacion"" )
 column=(type=long update=yes updatewhereclause=yes name=orden dbname=""acc_parametros.orden"" )
 column=(type=char(80) update=yes updatewhereclause=yes name=titulo dbname=""acc_parametros.titulo"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=objeto dbname=""acc_parametros.objeto"" )
 column=(type=char(256) update=yes updatewhereclause=yes name=parametros dbname=""acc_parametros.parametros"" )
 column=(type=char(1) update=yes updatewhereclause=yes name=cierra dbname=""acc_parametros.cierra"" )
 retrieve=""SELECT DISTINCT 
		 dba.acc_parametros.operacion,
       dba.acc_parametros.orden,
       dba.acc_parametros.titulo,
       dba.acc_parametros.objeto,
       dba.acc_parametros.parametros,
       dba.acc_parametros.cierra
  FROM dba.acc_parametros,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil
 WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_parametros.operacion
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = :perfil
 ORDER BY dba.acc_parametros.operacion,
       dba.acc_parametros.orden"" arguments=((""perfil"", string))  sort=""operacion A orden A "" )
text(band=header alignment=""2"" text=""Operacion""border=""2"" color=""8388608"" x=""19"" y=""16"" height=""65"" width=""270""  name=operacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Orden""border=""2"" color=""8388608"" x=""307"" y=""16"" height=""65"" width=""330""  name=orden_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Titulo""border=""2"" color=""8388608"" x=""654"" y=""16"" height=""65"" width=""746""  name=titulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Objeto""border=""2"" color=""8388608"" x=""1431"" y=""16"" height=""65"" width=""682""  name=objeto_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Parametros""border=""2"" color=""8388608"" x=""2135"" y=""16"" height=""65"" width=""1313""  name=parametros_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Cierra""border=""2"" color=""8388608"" x=""3470"" y=""16"" height=""65"" width=""156""  name=cierra_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=10 border=""0"" color=""0"" x=""19"" y=""16"" height=""77"" width=""165"" format=""[general]""  name=operacion edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""1"" tabsequence=20 border=""0"" color=""0"" x=""307"" y=""16"" height=""77"" width=""330"" format=""[general]""  name=orden edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=30 border=""0"" color=""0"" x=""654"" y=""16"" height=""77"" width=""746"" format=""[general]""  name=titulo edit.limit=80 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""0"" tabsequence=40 border=""0"" color=""0"" x=""1431"" y=""16"" height=""77"" width=""682"" format=""[general]""  name=objeto edit.limit=40 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""0"" tabsequence=50 border=""0"" color=""0"" x=""2135"" y=""16"" height=""77"" width=""1313"" format=""[general]""  name=parametros edit.limit=256 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=6 alignment=""0"" tabsequence=60 border=""0"" color=""0"" x=""3470"" y=""16"" height=""77"" width=""55"" format=""[general]""  name=cierra edit.limit=1 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
