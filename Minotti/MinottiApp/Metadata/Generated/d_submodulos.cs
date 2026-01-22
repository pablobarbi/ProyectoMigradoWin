using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_submodulos : IDataWindowMetadata
    {
        public string DataObject => "d_submodulos";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "submodulo",
    DbName = "acc_submodulos.submodulo",
    Tipo = "char(8)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_submodulos.nombre",
    Tipo = "char(20)",
    UpdateWhereClause = true,
    EsRequerido = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "bitmap",
    DbName = "acc_submodulos.bitmap",
    Tipo = "char(40)",
    UpdateWhereClause = true,
    TabOrder = 30,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_submodulos.submodulo,   
         dba.acc_submodulos.nombre,   
         dba.acc_submodulos.bitmap  
    FROM dba.acc_submodulos
	WHERE dba.acc_submodulos.submodulo = :submod";

        // PB: table.update
        public string Update => @"dba.acc_submodulos";

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
        public string SrdRaw => @"$PBExportHeader$d_submodulos.srd
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=1 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=385 color=""536870912"" )
table(column=(type=char(8) update=yes updatewhereclause=yes key=yes name=submodulo dbname=""acc_submodulos.submodulo"" )
 column=(type=char(20) update=yes updatewhereclause=yes name=nombre dbname=""acc_submodulos.nombre"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=bitmap dbname=""acc_submodulos.bitmap"" )
 retrieve=""  SELECT dba.acc_submodulos.submodulo,   
         dba.acc_submodulos.nombre,   
         dba.acc_submodulos.bitmap  
    FROM dba.acc_submodulos
	WHERE dba.acc_submodulos.submodulo = :submod  
"" update=""dba.acc_submodulos"" updatewhere=0 updatekeyinplace=no arguments=((""submod"", string)) )
column(band=detail id=1 alignment=""0"" tabsequence=10 border=""5"" color=""0"" x=""403"" y=""20"" height=""69"" width=""311"" format=""[general]""  name=submodulo edit.limit=8 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=2 alignment=""0"" tabsequence=20 border=""5"" color=""0"" x=""403"" y=""160"" height=""69"" width=""577"" format=""[general]""  name=nombre edit.limit=20 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.required=yes edit.nilisnull=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Nombre:""border=""0"" color=""8388608"" x=""124"" y=""160"" height=""69"" width=""247""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=30 border=""5"" color=""0"" x=""403"" y=""296"" height=""69"" width=""1125"" format=""[general]""  name=bitmap edit.limit=40 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Bitmap:""border=""0"" color=""8388608"" x=""147"" y=""296"" height=""69"" width=""225""  name=bitmap_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Submodulo:""border=""0"" color=""8388608"" x=""19"" y=""20"" height=""69"" width=""353""  name=submodulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
