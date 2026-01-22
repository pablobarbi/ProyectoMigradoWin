using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_system_error_impresion : IDataWindowMetadata
    {
        public string DataObject => "d_system_error_impresion";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "nro_error",
    DbName = "errores_sistema.nro_error",
    Tipo = "long",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "fecha_hora",
    DbName = "errores_sistema.fecha_hora",
    Tipo = "datetime",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "lugar",
    DbName = "errores_sistema.lugar",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "evento",
    DbName = "errores_sistema.evento",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "objeto",
    DbName = "errores_sistema.objeto",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "linea_script",
    DbName = "errores_sistema.linea_script",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "mensaje_error",
    DbName = "errores_sistema.mensaje_error",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.errores_sistema.nro_error,   
			dba.errores_sistema.fecha_hora,   
         dba.errores_sistema.lugar,   
         dba.errores_sistema.evento,   
         dba.errores_sistema.objeto,   
         dba.errores_sistema.linea_script,   
			dba.errores_sistema.mensaje_error  
    FROM dba.errores_sistema";

        // PB: table.update
        public string Update => @"dba.errores_sistema";

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
        public string SrdRaw => @"$PBExportHeader$d_system_error_impresion.srd
$PBExportComments$dw de impresion de errores del Sistema
release 5;
datawindow(units=3 timer_interval=0 color=16777215 processing=0 print.documentname="""" print.orientation = 2 print.margin.left = 2000 print.margin.right = 2000 print.margin.top = 2000 print.margin.bottom = 1000 print.paper.source = 0 print.paper.size = 9 print.prompt=no )
header(height=1508 color=""536870912"" )
summary(height=396 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=4603 color=""553648127""  height.autosize=yes)
table(column=(type=long update=yes updatewhereclause=yes key=yes name=nro_error dbname=""errores_sistema.nro_error"" )
 column=(type=datetime update=yes updatewhereclause=yes key=yes name=fecha_hora dbname=""errores_sistema.fecha_hora"" )
 column=(type=char(255) update=yes updatewhereclause=yes name=lugar dbname=""errores_sistema.lugar"" )
 column=(type=char(255) update=yes updatewhereclause=yes name=evento dbname=""errores_sistema.evento"" )
 column=(type=char(255) update=yes updatewhereclause=yes name=objeto dbname=""errores_sistema.objeto"" )
 column=(type=long update=yes updatewhereclause=yes name=linea_script dbname=""errores_sistema.linea_script"" )
 column=(type=char(255) update=yes updatewhereclause=yes name=mensaje_error dbname=""errores_sistema.mensaje_error"" )
 retrieve=""  SELECT dba.errores_sistema.nro_error,   
			dba.errores_sistema.fecha_hora,   
         dba.errores_sistema.lugar,   
         dba.errores_sistema.evento,   
         dba.errores_sistema.objeto,   
         dba.errores_sistema.linea_script,   
			dba.errores_sistema.mensaje_error  
    FROM dba.errores_sistema   
         "" update=""dba.errores_sistema"" updatewhere=0 updatekeyinplace=no )
text(band=header alignment=""2"" text=""ERROR""border=""0"" color=""0"" x=""264"" y=""635"" height=""661"" width=""16218""  font.face=""Arial"" font.height=""-16"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""2"" background.color=""16777215"" )
line(band=summary x1=""211"" y1=""106"" x2=""16271"" y2=""106"" pen.style=""0"" pen.width=""26"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
line(band=detail x1=""132"" y1=""26"" x2=""16192"" y2=""26"" pen.style=""0"" pen.width=""26"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3624"" y=""873"" height=""423"" width=""10636"" format=""[general]""  name=lugar edit.limit=255 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3624"" y=""1481"" height=""423"" width=""10636"" format=""[general]""  name=objeto edit.limit=255 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=7 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3624"" y=""3307"" height=""1084"" width=""10636"" format=""[general]""  name=mensaje_error height.autosize=yes edit.limit=255 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes edit.autovscroll=yes edit.vscrollbar=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3624"" y=""2090"" height=""423"" width=""10636"" format=""[general]""  name=evento edit.limit=255 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=1 alignment=""2"" tabsequence=32766 border=""0"" color=""0"" x=""3598"" y=""264"" height=""423"" width=""1719"" format=""[general]""  name=nro_error edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=6 alignment=""2"" tabsequence=32766 border=""0"" color=""0"" x=""3624"" y=""2698"" height=""423"" width=""1719"" format=""[general]""  name=linea_script edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Hora:""border=""0"" color=""41943040"" x=""9260"" y=""238"" height=""343"" width=""952""  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=2 alignment=""2"" tabsequence=32766 border=""0"" color=""0"" x=""10451"" y=""211"" height=""423"" width=""3783"" format=""[shortdate] [time]""  name=fecha_hora editmask.mask=""dd/mm/yyyy    hh:mm:ss"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Objeto :""border=""0"" color=""41943040"" x=""2010"" y=""1481"" height=""423"" width=""1402""  name=object_t  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Evento :""border=""0"" color=""41943040"" x=""1931"" y=""2090"" height=""423"" width=""1481""  name=event_t  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Linea en el Script :""border=""0"" color=""41943040"" x=""396"" y=""2698"" height=""423"" width=""3016""  name=line_t  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Mensaje de Error :""border=""0"" color=""41943040"" x=""423"" y=""3307"" height=""423"" width=""2989""  name=message_t  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Numero de Error :""border=""0"" color=""41943040"" x=""502"" y=""238"" height=""423"" width=""2910""  name=enum_t  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Window/Menu :""border=""0"" color=""41943040"" x=""952"" y=""873"" height=""423"" width=""2460""  name=where_t  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
";
    }
}
