using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dw_operaciones : IDataWindowMetadata
    {
        public string DataObject => "dw_operaciones";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "operacion",
    DbName = "acc_operaciones.operacion",
    Tipo = "char(5)",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_operaciones.nombre",
    Tipo = "char(30)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_operaciones.operacion,
       dba.acc_operaciones.nombre
  FROM dba.acc_operaciones
 ORDER BY dba.acc_operaciones.nombre";

        // PB: table.update
        public string Update => @"acc_operaciones";

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
        public string SrdRaw => @"$PBExportHeader$dw_operaciones.srd
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=1 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=85 color=""536870912"" )
table(column=(type=char(5) update=yes updatewhereclause=yes key=yes name=operacion dbname=""acc_operaciones.operacion"" )
 column=(type=char(30) update=yes updatewhereclause=yes name=nombre dbname=""acc_operaciones.nombre"" )
 retrieve=""SELECT dba.acc_operaciones.operacion,
       dba.acc_operaciones.nombre
  FROM dba.acc_operaciones
 ORDER BY dba.acc_operaciones.nombre
"" update=""acc_operaciones"" updatewhere=1 updatekeyinplace=no )
compute(band=detail alignment=""0"" expression=""nombre + ' - ( ' + operacion + ' )'""border=""6"" color=""0"" x=""14"" y=""12"" height=""65"" width=""1541""  name=display  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
