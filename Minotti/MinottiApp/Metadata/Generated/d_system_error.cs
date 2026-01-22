using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_system_error : IDataWindowMetadata
    {
        public string DataObject => "d_system_error";

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
        public string SrdRaw => @"$PBExportHeader$d_system_error.srd
$PBExportComments$displays system error information.  Used by the w_system_error window.
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=1 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=657 color=""536870912"" )
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
text(band=detail alignment=""1"" text=""Numero de Error :""border=""0"" color=""41943040"" x=""87"" y=""16"" height=""65"" width=""503""  name=enum_t  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=2 alignment=""2"" tabsequence=32766 border=""6"" color=""0"" x=""1806"" y=""12"" height=""65"" width=""654"" format=""[shortdate] [time]""  name=fecha_hora editmask.mask=""dd/mm/yyyy    hh:mm:ss"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Hora:""border=""0"" color=""41943040"" x=""1601"" y=""16"" height=""53"" width=""165""  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""6"" color=""0"" x=""627"" y=""112"" height=""65"" width=""1838"" format=""[general]""  name=lugar edit.limit=255 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Window/Menu :""border=""0"" color=""41943040"" x=""165"" y=""112"" height=""65"" width=""426""  name=where_t  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""6"" color=""0"" x=""627"" y=""204"" height=""65"" width=""1838"" format=""[general]""  name=objeto edit.limit=255 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Objeto :""border=""0"" color=""41943040"" x=""348"" y=""204"" height=""65"" width=""243""  name=object_t  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Evento :""border=""0"" color=""41943040"" x=""334"" y=""296"" height=""65"" width=""257""  name=event_t  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Linea en el Script :""border=""0"" color=""41943040"" x=""69"" y=""388"" height=""65"" width=""522""  name=line_t  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Mensaje de Error :""border=""0"" color=""41943040"" x=""65"" y=""480"" height=""65"" width=""517""  name=message_t  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=7 alignment=""0"" tabsequence=32766 border=""6"" color=""0"" x=""627"" y=""480"" height=""165"" width=""1838"" format=""[general]""  name=mensaje_error height.autosize=yes edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.autohscroll=yes edit.autovscroll=yes edit.hscrollbar=yes edit.vscrollbar=yes edit.displayonly=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""6"" color=""0"" x=""627"" y=""296"" height=""65"" width=""1838"" format=""[general]""  name=evento edit.limit=255 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=1 alignment=""2"" tabsequence=32766 border=""6"" color=""0"" x=""622"" y=""20"" height=""65"" width=""298"" format=""[general]""  name=nro_error edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=6 alignment=""2"" tabsequence=32766 border=""6"" color=""0"" x=""627"" y=""388"" height=""65"" width=""298"" format=""[general]""  name=linea_script edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
";
    }
}
