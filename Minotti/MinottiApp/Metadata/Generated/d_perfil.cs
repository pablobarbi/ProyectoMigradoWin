using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_perfil : IDataWindowMetadata
    {
        public string DataObject => "d_perfil";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "perfil",
    DbName = "acc_perfiles.perfil",
    Tipo = "char(8)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_perfiles.nombre",
    Tipo = "char(20)",
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "bitmap",
    DbName = "acc_perfiles.bitmap",
    Tipo = "char(40)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_perfiles.perfil,
       dba.acc_perfiles.nombre,
       dba.acc_perfiles.bitmap
  FROM dba.acc_perfiles
 WHERE dba.acc_perfiles.perfil = :perfil";

        // PB: table.update
        public string Update => @"dba.acc_perfiles";

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
        public string SrdRaw => @"$PBExportHeader$d_perfil.srd
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=1 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=409 color=""536870912"" )
table(column=(type=char(8) update=yes updatewhereclause=yes key=yes name=perfil dbname=""acc_perfiles.perfil"" )
 column=(type=char(20) update=yes updatewhereclause=yes name=nombre dbname=""acc_perfiles.nombre"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=bitmap dbname=""acc_perfiles.bitmap"" )
 retrieve=""SELECT dba.acc_perfiles.perfil,
       dba.acc_perfiles.nombre,
       dba.acc_perfiles.bitmap
  FROM dba.acc_perfiles
 WHERE dba.acc_perfiles.perfil = :perfil    
"" update=""dba.acc_perfiles"" updatewhere=0 updatekeyinplace=no arguments=((""perfil"", string)) )
column(band=detail id=1 alignment=""0"" tabsequence=10 border=""5"" color=""0"" x=""348"" y=""60"" height=""77"" width=""279"" format=""[general]""  name=perfil edit.limit=8 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""1086902488"" )
column(band=detail id=2 alignment=""0"" tabsequence=20 border=""5"" color=""0"" x=""348"" y=""248"" height=""77"" width=""938"" format=""[general]""  name=nombre edit.limit=20 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""1086902488"" )
text(band=detail alignment=""1"" text=""Perfíl:""border=""0"" color=""8388608"" x=""142"" y=""60"" height=""77"" width=""174""  name=perfil_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Nombre:""border=""0"" color=""8388608"" x=""69"" y=""248"" height=""77"" width=""247""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
