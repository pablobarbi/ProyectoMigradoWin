using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dw_pacientes_mas_todos : IDataWindowMetadata
    {
        public string DataObject => "dw_pacientes_mas_todos";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "paciente",
    DbName = "pacientes.paciente",
    Tipo = "long",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "pacientes.nombre",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT pacientes.paciente,
       pacientes.nombre
  FROM pacientes
 UNION
SELECT 0, ' Todos los pacientes'
 ORDER BY 2";

        // PB: table.update
        public string Update => @"pacientes";

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
        public string SrdRaw => @"$PBExportHeader$dw_pacientes_mas_todos.srd
release 7;
datawindow(units=0 timer_interval=0 color=80269524 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=72 color=""536870912""  height.autosize=yes)
table(column=(type=long update=yes updatewhereclause=yes key=yes name=paciente dbname=""pacientes.paciente"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=nombre dbname=""pacientes.nombre"" )
 retrieve=""SELECT pacientes.paciente,
       pacientes.nombre
  FROM pacientes
 UNION
SELECT 0, ' Todos los pacientes'
 ORDER BY 2
"" update=""pacientes"" updatewhere=1 updatekeyinplace=no )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""6"" color=""0"" x=""14"" y=""4"" height=""64"" width=""1399"" format=""[general]""  name=nombre height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
