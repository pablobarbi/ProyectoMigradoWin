using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dl_pacientes_estadisticas : IDataWindowMetadata
    {
        public string DataObject => "dl_pacientes_estadisticas";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "paciente",
    DbName = "diagnosticos.paciente",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "primera",
    DbName = "diagnosticos.primera",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
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
        public string SrdRaw => @"$PBExportHeader$dl_pacientes_estadisticas.srd
release 7;
datawindow(units=3 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 2 print.margin.left = 2000 print.margin.right = 1000 print.margin.top = 2000 print.margin.bottom = 1000 print.paper.source = 0 print.paper.size = 9 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=2672 color=""536870912"" )
summary(height=2566 color=""536870912"" )
footer(height=608 color=""536870912"" )
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
report(band=header dataobject=""r_header"" x=""132"" y=""105"" height=""1666"" width=""17488"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  name=dw_1  slideup=directlyabove )
text(band=header alignment=""2"" text=""Estadísticas de Pacientes"" border=""0"" color=""0"" x=""105"" y=""1957"" height=""529"" width=""17488""  name=t_4  font.face=""Arial"" font.height=""-12"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2751"" y=""105"" height=""502"" width=""2592"" format=""[general]""  name=paciente edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""5609"" y=""105"" height=""502"" width=""2831"" format=""[general]""  name=primera edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
compute(band=summary alignment=""1"" expression=""sum(if ( primera = 'S' , 1 , 0 ) for all )""border=""0"" color=""0"" x=""9842"" y=""1852"" height=""449"" width=""1561"" format=""[GENERAL]""  name=compute_1  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=summary alignment=""1"" expression=""count(paciente for all)""border=""0"" color=""0"" x=""9842"" y=""1191"" height=""449"" width=""1561"" format=""[general]""  name=compute_2  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=summary alignment=""1"" expression=""sum(paciente for all)""border=""0"" color=""0"" x=""9842"" y=""556"" height=""449"" width=""1561"" format=""[general]""  name=compute_3  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=summary alignment=""1"" text=""Total de curados:"" border=""0"" color=""0"" x=""6138"" y=""1852"" height=""449"" width=""3545""  name=t_3  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=summary alignment=""1"" text=""Total de pacientes:"" border=""0"" color=""0"" x=""5847"" y=""1191"" height=""449"" width=""3836""  name=t_1  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=summary alignment=""1"" text=""Total de visitas:"" border=""0"" color=""0"" x=""6508"" y=""556"" height=""449"" width=""3175""  name=t_2  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
line(band=footer x1=""105"" y1=""26"" x2=""17594"" y2=""26""  name=l_2 pen.style=""0"" pen.width=""26"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
compute(band=footer alignment=""1"" expression=""'Pag. ' + page() + ' de ' + pageCount()""border=""0"" color=""0"" x=""12594"" y=""105"" height=""423"" width=""4947"" format=""[general]""  name=page_1  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=footer alignment=""0"" expression=""today()""border=""0"" color=""0"" x=""185"" y=""132"" height=""396"" width=""3042"" format=""dd/mm/yyyy""  name=date_1  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
