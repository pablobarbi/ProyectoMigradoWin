using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dw_submodulos : IDataWindowMetadata
    {
        public string DataObject => "dw_submodulos";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "submodulo",
    DbName = "acc_submodulos.submodulo",
    Tipo = "char(5)",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_submodulos.nombre",
    Tipo = "char(40)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT acc_submodulos.submodulo,   
       acc_submodulos.nombre  
  FROM acc_submodulos";

        // PB: table.update
        public string Update => @"acc_submodulos";

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
        public string SrdRaw => @"$PBExportHeader$dw_submodulos.srd
release 7;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=96 color=""536870912"" )
table(column=(type=char(5) update=yes updatewhereclause=yes key=yes name=submodulo dbname=""acc_submodulos.submodulo"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=nombre dbname=""acc_submodulos.nombre"" )
 retrieve=""SELECT acc_submodulos.submodulo,   
       acc_submodulos.nombre  
  FROM acc_submodulos   
"" update=""acc_submodulos"" updatewhere=1 updatekeyinplace=no )
compute(band=detail alignment=""0"" expression=""nombre + ' - (' + submodulo + ')'""border=""6"" color=""0"" x=""23"" y=""12"" height=""72"" width=""1061"" format=""[general]""  name=display  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""0"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
