using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dw_perfiles : IDataWindowMetadata
    {
        public string DataObject => "dw_perfiles";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "perfil",
    DbName = "acc_perfiles.perfil",
    Tipo = "char(5)",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_perfiles.nombre",
    Tipo = "char(20)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_perfiles.perfil,
       dba.acc_perfiles.nombre
  FROM dba.acc_perfiles
 ORDER BY dba.acc_perfiles.nombre";

        // PB: table.update
        public string Update => @"acc_perfiles";

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
        public string SrdRaw => @"$PBExportHeader$dw_perfiles.srd
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=1 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=97 color=""536870912"" )
table(column=(type=char(5) update=yes updatewhereclause=yes key=yes name=perfil dbname=""acc_perfiles.perfil"" )
 column=(type=char(20) update=yes updatewhereclause=yes name=nombre dbname=""acc_perfiles.nombre"" )
 retrieve=""SELECT dba.acc_perfiles.perfil,
       dba.acc_perfiles.nombre
  FROM dba.acc_perfiles
 ORDER BY dba.acc_perfiles.nombre"" update=""acc_perfiles"" updatewhere=1 updatekeyinplace=no )
compute(band=detail alignment=""0"" expression=""nombre + ' - (' + perfil + ')'""border=""6"" color=""0"" x=""14"" y=""16"" height=""65"" width=""1125"" format=""[general]""  name=display  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
