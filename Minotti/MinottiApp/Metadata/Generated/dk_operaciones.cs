using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_operaciones : IDataWindowMetadata
    {
        public string DataObject => "dk_operaciones";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "operacion",
    DbName = "acc_operaciones.operacion",
    Tipo = "char(5)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_operaciones.nombre",
    Tipo = "char(30)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "bitmap",
    DbName = "acc_operaciones.bitmap",
    Tipo = "char(40)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_operaciones.operacion,
       dba.acc_operaciones.nombre,
       dba.acc_operaciones.bitmap
  FROM dba.acc_operaciones  
 ORDER BY dba.acc_operaciones.nombre ASC
"" update=""dba.acc_operaciones"" updatewhere=0 updatekeyinplace=no  sort=""operacion A";

        // PB: table.update
        public string Update => @"dba.acc_operaciones"" updatewhere=0 updatekeyinplace=no  sort=""operacion A";

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
        public string SrdRaw => @"$PBExportHeader$dk_operaciones.srd
release 5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=89 color=""12632256"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=93 color=""536870912"" )
table(column=(type=char(5) update=yes updatewhereclause=yes key=yes name=operacion dbname=""acc_operaciones.operacion"" )
 column=(type=char(30) update=yes updatewhereclause=yes name=nombre dbname=""acc_operaciones.nombre"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=bitmap dbname=""acc_operaciones.bitmap"" )
 retrieve=""SELECT dba.acc_operaciones.operacion,
       dba.acc_operaciones.nombre,
       dba.acc_operaciones.bitmap
  FROM dba.acc_operaciones  
 ORDER BY dba.acc_operaciones.nombre ASC
"" update=""dba.acc_operaciones"" updatewhere=0 updatekeyinplace=no  sort=""operacion A "" )
text(band=header alignment=""2"" text=""Operación""border=""6"" color=""8388608"" x=""23"" y=""12"" height=""65"" width=""302""  name=operacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""23"" y=""12"" height=""65"" width=""302"" format=""[general]""  name=operacion edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""353"" y=""12"" height=""65"" width=""1189"" format=""[general]""  name=nombre edit.limit=30 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Nombre""border=""6"" color=""8388608"" x=""353"" y=""12"" height=""65"" width=""1189""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
