using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_operaciones_x_modulo : IDataWindowMetadata
    {
        public string DataObject => "d_operaciones_x_modulo";

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
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "submodulo",
    DbName = "acc_operaciones_x_modulo.submodulo",
    Tipo = "char(5)",
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "alta",
    DbName = "acc_operaciones_x_modulo.alta",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 30,
},

            new DataWindowColumn
{
    Nombre = "baja",
    DbName = "acc_operaciones_x_modulo.baja",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 40,
},

            new DataWindowColumn
{
    Nombre = "modificacion",
    DbName = "acc_operaciones_x_modulo.modificacion",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 50,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_operaciones_x_modulo.modulo,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones_x_modulo.submodulo,
       dba.acc_operaciones_x_modulo.alta,
       dba.acc_operaciones_x_modulo.baja,
       dba.acc_operaciones_x_modulo.modificacion
  FROM dba.acc_operaciones_x_modulo
 WHERE dba.acc_operaciones_x_modulo.modulo = :modulo";

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
        public string SrdRaw => @"$PBExportHeader$d_operaciones_x_modulo.srd
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=93 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=101 color=""536870912"" )
table(column=(type=char(5) update=yes updatewhereclause=yes key=yes name=modulo dbname=""acc_operaciones_x_modulo.modulo"" )
 column=(type=char(5) update=yes updatewhereclause=yes key=yes name=operacion dbname=""acc_operaciones_x_modulo.operacion"" )
 column=(type=char(5) update=yes updatewhereclause=yes name=submodulo dbname=""acc_operaciones_x_modulo.submodulo"" )
 column=(type=char(1) update=yes updatewhereclause=yes name=alta dbname=""acc_operaciones_x_modulo.alta"" initial=""N"" values=""	S/	N"" )
 column=(type=char(1) update=yes updatewhereclause=yes name=baja dbname=""acc_operaciones_x_modulo.baja"" initial=""N"" values=""	S/	N"" )
 column=(type=char(1) update=yes updatewhereclause=yes name=modificacion dbname=""acc_operaciones_x_modulo.modificacion"" initial=""N"" values=""	S/	N"" )
 retrieve=""SELECT dba.acc_operaciones_x_modulo.modulo,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones_x_modulo.submodulo,
       dba.acc_operaciones_x_modulo.alta,
       dba.acc_operaciones_x_modulo.baja,
       dba.acc_operaciones_x_modulo.modificacion
  FROM dba.acc_operaciones_x_modulo
 WHERE dba.acc_operaciones_x_modulo.modulo = :modulo
"" update=""dba.acc_operaciones_x_modulo"" updatewhere=0 updatekeyinplace=no arguments=((""modulo"", string)) )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""165"" y=""184"" height=""73"" width=""138"" format=""[general]""  name=modulo edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=10 border=""6"" color=""0"" x=""23"" y=""16"" height=""73"" width=""1463"" format=""[general]""  name=operacion dddw.name=dw_operaciones dddw.displaycolumn=display dddw.datacolumn=operacion dddw.percentwidth=100 dddw.lines=6 dddw.limit=0 dddw.allowedit=yes dddw.useasborder=yes dddw.case=any dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Operación""border=""2"" color=""8388608"" x=""23"" y=""16"" height=""65"" width=""1463""  name=operacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=6 alignment=""0"" tabsequence=50 border=""0"" color=""0"" x=""3082"" y=""20"" height=""65"" width=""65"" format=""[general]""  name=modificacion checkbox.text="""" checkbox.on=""S"" checkbox.off=""N"" checkbox.scale=no checkbox.threed=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""0"" tabsequence=40 border=""0"" color=""0"" x=""2757"" y=""20"" height=""65"" width=""65"" format=""[general]""  name=baja checkbox.text="""" checkbox.on=""S"" checkbox.off=""N"" checkbox.scale=no checkbox.threed=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""0"" tabsequence=30 border=""0"" color=""0"" x=""2510"" y=""20"" height=""65"" width=""65"" format=""[general]""  name=alta checkbox.text="""" checkbox.on=""S"" checkbox.off=""N"" checkbox.scale=no checkbox.threed=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Baja""border=""2"" color=""8388608"" x=""2679"" y=""16"" height=""65"" width=""220""  name=baja_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Alta""border=""2"" color=""8388608"" x=""2442"" y=""16"" height=""65"" width=""202""  name=alta_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Modificación""border=""2"" color=""8388608"" x=""2931"" y=""16"" height=""65"" width=""371""  name=modificacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=20 border=""6"" color=""0"" x=""1514"" y=""16"" height=""73"" width=""897""  name=submodulo dddw.name=dw_submodulos dddw.displaycolumn=display dddw.datacolumn=submodulo dddw.percentwidth=100 dddw.lines=6 dddw.limit=0 dddw.allowedit=yes dddw.useasborder=yes dddw.case=any dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Sub Módulo""border=""2"" color=""8388608"" x=""1514"" y=""16"" height=""65"" width=""897""  name=submodulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
