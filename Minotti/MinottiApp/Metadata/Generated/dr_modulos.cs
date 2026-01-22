using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_modulos : IDataWindowMetadata
    {
        public string DataObject => "dr_modulos";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "modulo",
    DbName = "acc_modulos.modulo",
    Tipo = "char(5)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_modulos.nombre",
    Tipo = "char(20)",
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "bitmap",
    DbName = "acc_modulos.bitmap",
    Tipo = "char(40)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_modulos.modulo,
       dba.acc_modulos.nombre,
       dba.acc_modulos.bitmap
  FROM dba.acc_modulos
 ORDER BY dba.acc_modulos.nombre";

        // PB: table.update
        public string Update => @"acc_modulos";

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
        public string SrdRaw => @"$PBExportHeader$dr_modulos.srd
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=85 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=93 color=""536870912"" )
table(column=(type=char(5) update=yes updatewhereclause=yes key=yes name=modulo dbname=""acc_modulos.modulo"" )
 column=(type=char(20) update=yes updatewhereclause=yes name=nombre dbname=""acc_modulos.nombre"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=bitmap dbname=""acc_modulos.bitmap"" )
 retrieve=""SELECT dba.acc_modulos.modulo,
       dba.acc_modulos.nombre,
       dba.acc_modulos.bitmap
  FROM dba.acc_modulos
 ORDER BY dba.acc_modulos.nombre"" update=""acc_modulos"" updatewhere=1 updatekeyinplace=no )
column(band=detail id=2 alignment=""0"" tabsequence=20 border=""6"" color=""0"" x=""307"" y=""12"" height=""65"" width=""1363"" format=""[general]""  name=nombre edit.limit=20 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=10 border=""6"" color=""0"" x=""23"" y=""12"" height=""65"" width=""252"" format=""[general]""  name=modulo edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Nombre""border=""2"" color=""8388608"" x=""307"" y=""12"" height=""65"" width=""1363""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Módulo""border=""2"" color=""8388608"" x=""23"" y=""12"" height=""65"" width=""252""  name=modulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
