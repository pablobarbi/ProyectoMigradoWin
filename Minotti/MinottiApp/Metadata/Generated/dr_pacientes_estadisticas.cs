using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_pacientes_estadisticas : IDataWindowMetadata
    {
        public string DataObject => "dr_pacientes_estadisticas";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "paciente",
    DbName = "diagnosticos.paciente",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 0,
},

            new DataWindowColumn
{
    Nombre = "primera",
    DbName = "diagnosticos.primera",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 0,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT diagnosticos.paciente,
       diagnosticos.primera
  FROM diagnosticos
 WHERE diagnosticos.fecha_visita >= YMD(SUBSTR(:fecha_desde, 7, 4), SUBSTR(:fecha_desde, 4, 2), SUBSTR(:fecha_desde, 1, 2))
   AND diagnosticos.fecha_visita <= YMD(SUBSTR(:fecha_hasta, 7, 4), SUBSTR(:fecha_hasta, 4, 2), SUBSTR(:fecha_hasta, 1, 2))
 ORDER BY diagnosticos.paciente";

        // PB: table.update
        public string Update => @"";

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
        public string SrdRaw => @"$PBExportHeader$dr_pacientes_estadisticas.srd
release 7;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=332 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=0 color=""536870912"" )
table(column=(type=long updatewhereclause=yes name=paciente dbname=""diagnosticos.paciente"" )
 column=(type=char(1) updatewhereclause=yes name=primera dbname=""diagnosticos.primera"" )
 retrieve=""SELECT diagnosticos.paciente,
       diagnosticos.primera
  FROM diagnosticos
 WHERE diagnosticos.fecha_visita >= YMD(SUBSTR(:fecha_desde, 7, 4), SUBSTR(:fecha_desde, 4, 2), SUBSTR(:fecha_desde, 1, 2))
   AND diagnosticos.fecha_visita <= YMD(SUBSTR(:fecha_hasta, 7, 4), SUBSTR(:fecha_hasta, 4, 2), SUBSTR(:fecha_hasta, 1, 2))
 ORDER BY diagnosticos.paciente
"" arguments=((""fecha_desde"", string),(""fecha_hasta"", string)) )
group(level=1 header.height=0 trailer.height=0 by=(""paciente"" ) header.color=""536870912"" trailer.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=0 border=""0"" color=""0"" x=""475"" y=""16"" height=""76"" width=""448""  name=paciente  font.face=""Arial"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=2 alignment=""0"" tabsequence=0 border=""0"" color=""0"" x=""969"" y=""16"" height=""76"" width=""489""  name=primera  font.face=""Arial"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=summary alignment=""1"" text=""Total de curados:"" border=""0"" color=""8388608"" x=""201"" y=""232"" height=""68"" width=""613""  name=t_3  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=summary alignment=""1"" expression=""sum(if ( primera = 'S' , 1 , 0 ) for all )""border=""0"" color=""0"" x=""841"" y=""232"" height=""68"" width=""270"" format=""[GENERAL]""  name=compute_1  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=summary alignment=""1"" expression=""count(paciente for all)""border=""0"" color=""0"" x=""841"" y=""132"" height=""68"" width=""270"" format=""[general]""  name=compute_2  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=summary alignment=""1"" expression=""sum(paciente for all)""border=""0"" color=""0"" x=""841"" y=""36"" height=""68"" width=""270"" format=""[general]""  name=compute_3  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=summary alignment=""1"" text=""Total de pacientes:"" border=""0"" color=""8388608"" x=""151"" y=""132"" height=""68"" width=""663""  name=t_1  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=summary alignment=""1"" text=""Total de visitas:"" border=""0"" color=""8388608"" x=""265"" y=""36"" height=""68"" width=""549""  name=t_2  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
