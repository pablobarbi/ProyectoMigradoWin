using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_fecha_desde_hasta : IDataWindowMetadata
    {
        public string DataObject => "dp_fecha_desde_hasta";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "fecha_desde",
    DbName = "diagnosticos.fecha_desde",
    Tipo = "date",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "fecha_hasta",
    DbName = "diagnosticos.fecha_hasta",
    Tipo = "date",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 20,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT diagnosticos.fecha_visita as fecha_desde,
       diagnosticos.fecha_visita as fecha_hasta
  FROM diagnosticos";

        // PB: table.update
        public string Update => @"xxx";

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
        public string SrdRaw => @"$PBExportHeader$dp_fecha_desde_hasta.srd
release 7;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=160 color=""536870912"" )
table(column=(type=date update=yes updatewhereclause=yes key=yes name=fecha_desde dbname=""diagnosticos.fecha_desde"" initial=""01/01/1950"" )
 column=(type=date update=yes updatewhereclause=yes key=yes name=fecha_hasta dbname=""diagnosticos.fecha_hasta"" initial=""31/12/2050"" )
 retrieve=""SELECT diagnosticos.fecha_visita as fecha_desde,
       diagnosticos.fecha_visita as fecha_hasta
  FROM diagnosticos
"" update=""xxx"" updatewhere=0 updatekeyinplace=no )
column(band=detail id=2 alignment=""1"" tabsequence=20 border=""5"" color=""0"" x=""1463"" y=""40"" height=""68"" width=""375"" format=""dd/mm/yyyy""  name=fecha_hasta editmask.mask=""dd/mm/yyyy"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Fecha Desde:"" border=""0"" color=""8388608"" x=""174"" y=""40"" height=""68"" width=""393""  name=fecha_desde_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""1"" tabsequence=10 border=""5"" color=""0"" x=""585"" y=""40"" height=""68"" width=""375"" format=""dd/mm/yyyy""  name=fecha_desde editmask.mask=""dd/mm/yyyy"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Fecha Hasta:"" border=""0"" color=""8388608"" x=""1070"" y=""40"" height=""68"" width=""375""  name=fecha_hasta_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
