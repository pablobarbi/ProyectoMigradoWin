using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_operaciones_x_modulo__ : IDataWindowMetadata
    {
        public string DataObject => "d_operaciones_x_modulo__";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "modulo",
    DbName = "acc_operaciones_x_modulo.modulo",
    Tipo = "char(5)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "operacion",
    DbName = "acc_operaciones_x_modulo.operacion",
    Tipo = "char(5)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "alta",
    DbName = "acc_operaciones_x_modulo.alta",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "baja",
    DbName = "acc_operaciones_x_modulo.baja",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "modificacion",
    DbName = "acc_operaciones_x_modulo.modificacion",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 30,
},

            new DataWindowColumn
{
    Nombre = "xx_descripcion",
    DbName = "acc_operaciones.nombre",
    Tipo = "char(30)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_operaciones_x_modulo.modulo,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones_x_modulo.alta,
       dba.acc_operaciones_x_modulo.baja,
       dba.acc_operaciones_x_modulo.modificacion,
       dba.acc_operaciones.nombre
  FROM dba.acc_operaciones_x_modulo,
       dba.acc_operaciones
 WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
   AND dba.acc_operaciones_x_modulo.modulo = :modulo";

        // PB: table.update
        public string Update => @"dba.acc_operaciones_x_modulo";

        // PB: table.updatewhere (0/1)
        public int UpdateWhere => 0;

        // PB: table.updatekeyinplace (yes/no)
        public bool UpdateKeyInPlace => false;

        public string[] Estilos => Array.Empty<string>();
        public string[] SeleccionFila => Array.Empty<string>();
        public string Operaciones => string.Empty;

        // Inferidos (conservador) por presencia de columnas técnicas
        public bool UsaUsuario => false;
        public bool UsaFecha => false;

        // SRD completo (lossless) por si todavía no existe property en C#
        public string SrdRaw => @"$PBExportHeader$d_operaciones_x_modulo__.srd
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=93 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=85 color=""536870912"" )
table(column=(type=char(5) update=yes updatewhereclause=yes key=yes name=modulo dbname=""acc_operaciones_x_modulo.modulo"" )
 column=(type=char(5) update=yes updatewhereclause=yes key=yes name=operacion dbname=""acc_operaciones_x_modulo.operacion"" )
 column=(type=char(1) update=yes updatewhereclause=yes name=alta dbname=""acc_operaciones_x_modulo.alta"" initial=""N"" values=""	S/	N"" )
 column=(type=char(1) update=yes updatewhereclause=yes name=baja dbname=""acc_operaciones_x_modulo.baja"" initial=""N"" values=""	S/	N"" )
 column=(type=char(1) update=yes updatewhereclause=yes name=modificacion dbname=""acc_operaciones_x_modulo.modificacion"" initial=""N"" values=""	S/	N"" )
 column=(type=char(30) updatewhereclause=yes name=xx_descripcion dbname=""acc_operaciones.nombre"" )
 retrieve=""SELECT dba.acc_operaciones_x_modulo.modulo,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones_x_modulo.alta,
       dba.acc_operaciones_x_modulo.baja,
       dba.acc_operaciones_x_modulo.modificacion,
       dba.acc_operaciones.nombre
  FROM dba.acc_operaciones_x_modulo,
       dba.acc_operaciones
 WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
   AND dba.acc_operaciones_x_modulo.modulo = :modulo
"" update=""dba.acc_operaciones_x_modulo"" updatewhere=0 updatekeyinplace=no arguments=((""modulo"", string)) )
text(band=header alignment=""2"" text=""Operación""border=""2"" color=""8388608"" x=""23"" y=""16"" height=""65"" width=""1194""  name=operacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""110"" y=""120"" height=""73"" width=""321"" format=""[general]""  name=modulo edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""2"" tabsequence=32766 border=""6"" color=""0"" x=""23"" y=""8"" height=""65"" width=""206"" format=""[general]""  name=operacion edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=6 alignment=""0"" tabsequence=32766 border=""6"" color=""0"" x=""252"" y=""8"" height=""65"" width=""961"" format=""[general]""  name=xx_descripcion edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Baja""border=""2"" color=""8388608"" x=""1422"" y=""16"" height=""65"" width=""179""  name=baja_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Modif.""border=""2"" color=""8388608"" x=""1614"" y=""16"" height=""65"" width=""179""  name=modificacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""0"" tabsequence=20 border=""0"" color=""0"" x=""1500"" y=""8"" height=""65"" width=""65"" format=""[general]""  name=baja checkbox.text="""" checkbox.on=""S"" checkbox.off=""N"" checkbox.scale=no checkbox.threed=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""0"" tabsequence=30 border=""0"" color=""0"" x=""1669"" y=""8"" height=""65"" width=""65"" format=""[general]""  name=modificacion checkbox.text="""" checkbox.on=""S"" checkbox.off=""N"" checkbox.scale=no checkbox.threed=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=10 border=""0"" color=""0"" x=""1299"" y=""8"" height=""65"" width=""65"" format=""[general]""  name=alta checkbox.text="""" checkbox.on=""S"" checkbox.off=""N"" checkbox.scale=no checkbox.threed=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Alta""border=""2"" color=""8388608"" x=""1230"" y=""16"" height=""65"" width=""179""  name=alta_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
