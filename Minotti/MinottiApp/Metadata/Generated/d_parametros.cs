using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_parametros : IDataWindowMetadata
    {
        public string DataObject => "d_parametros";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "operacion",
    DbName = "acc_parametros.operacion",
    Tipo = "char(8)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "orden",
    DbName = "acc_parametros.orden",
    Tipo = "long",
    EsClave = true,
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
    Tipo = "char(255)",
    UpdateWhereClause = true,
    EsRequerido = true,
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
        public string Sql => @"Select
		dba.acc_parametros.operacion,   
         dba.acc_parametros.orden,   
         dba.acc_parametros.titulo,   
         dba.acc_parametros.objeto,   
         dba.acc_parametros.parametros,   
         dba.acc_parametros.cierra  
    from
		dba.acc_parametros  
   where
		dba.acc_parametros.operacion = :opera";

        // PB: table.update
        public string Update => @"dba.acc_parametros";

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
        public string SrdRaw => @"$PBExportHeader$d_parametros.srd
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=77 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=85 color=""536870912"" )
table(column=(type=char(8) update=yes updatewhereclause=yes key=yes name=operacion dbname=""acc_parametros.operacion"" )
 column=(type=long update=yes updatewhereclause=yes key=yes name=orden dbname=""acc_parametros.orden"" )
 column=(type=char(80) update=yes updatewhereclause=yes name=titulo dbname=""acc_parametros.titulo"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=objeto dbname=""acc_parametros.objeto"" )
 column=(type=char(255) update=yes updatewhereclause=yes name=parametros dbname=""acc_parametros.parametros"" )
 column=(type=char(1) update=yes updatewhereclause=yes name=cierra dbname=""acc_parametros.cierra"" initial=""N"" values=""SI	S/NO	N/"" )
 retrieve=""  Select
		dba.acc_parametros.operacion,   
         dba.acc_parametros.orden,   
         dba.acc_parametros.titulo,   
         dba.acc_parametros.objeto,   
         dba.acc_parametros.parametros,   
         dba.acc_parametros.cierra  
    from
		dba.acc_parametros  
   where
		dba.acc_parametros.operacion = :opera    
"" update=""dba.acc_parametros"" updatewhere=0 updatekeyinplace=no arguments=((""opera"", string)) )
text(band=header alignment=""2"" text=""Titulo""border=""6"" color=""8388608"" x=""389"" y=""4"" height=""65"" width=""769""  name=titulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Objeto""border=""6"" color=""8388608"" x=""1198"" y=""4"" height=""65"" width=""755""  name=objeto_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Parametros""border=""6"" color=""8388608"" x=""1985"" y=""4"" height=""65"" width=""2122""  name=parametros_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Oper.""border=""6"" color=""8388608"" x=""19"" y=""4"" height=""65"" width=""161""  name=operacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Orden""border=""6"" color=""8388608"" x=""206"" y=""4"" height=""65"" width=""165""  name=orden_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Cierra""border=""6"" color=""8388608"" x=""4142"" y=""4"" height=""65"" width=""202""  name=cierra_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""1"" tabsequence=20 border=""5"" color=""0"" x=""215"" y=""4"" height=""65"" width=""138"" format=""[general]""  name=orden edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=3 alignment=""0"" tabsequence=30 border=""5"" color=""0"" x=""389"" y=""4"" height=""65"" width=""769"" format=""[general]""  name=titulo edit.limit=80 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=4 alignment=""0"" tabsequence=40 border=""5"" color=""0"" x=""1198"" y=""4"" height=""65"" width=""755"" format=""[general]""  name=objeto edit.limit=40 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=5 alignment=""0"" tabsequence=50 border=""5"" color=""0"" x=""1985"" y=""4"" height=""65"" width=""2122"" format=""[general]""  name=parametros edit.limit=255 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.required=yes edit.nilisnull=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=6 alignment=""0"" tabsequence=60 border=""5"" color=""0"" x=""4142"" y=""4"" height=""65"" width=""202"" format=""[general]""  name=cierra edit.name=""ddlb_Si_No"" ddlb.limit=0 ddlb.allowedit=no ddlb.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=1 alignment=""0"" tabsequence=10 border=""5"" color=""0"" x=""14"" y=""4"" height=""65"" width=""170"" format=""[general]""  name=operacion edit.limit=8 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
";
    }
}
