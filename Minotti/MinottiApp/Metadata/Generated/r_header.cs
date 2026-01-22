using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class r_header : IDataWindowMetadata
    {
        public string DataObject => "r_header";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "compute_0001",
    DbName = "compute_0001",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT count(*) 
   FROM dba.acc_usuarios";

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
        public string SrdRaw => @"$PBExportHeader$r_header.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=248 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=0 color=""536870912"" )
table(column=(type=decimal(0) updatewhereclause=yes name=compute_0001 dbname=""compute_0001"" )
 retrieve=""SELECT count(*) 
   FROM dba.acc_usuarios"" )
text(band=header alignment=""0"" text=""Programa de Repertorización para Medicina Homeopática"" border=""0"" color=""0"" x=""27"" y=""16"" height=""64"" width=""1696"" html.valueishtml=""0""  name=t_1 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
bitmap(band=header filename=""C:\Trabajo\Minotti\Power10\imprimir.bmp"" x=""55"" y=""116"" height=""80"" width=""91"" border=""0""  name=bitmap visible=""1"" )
text(band=header alignment=""0"" text=""Fecha:"" border=""0"" color=""0"" x=""215"" y=""100"" height=""60"" width=""169"" html.valueishtml=""0""  name=t_2 visible=""1""  font.face=""Arial"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
compute(band=header alignment=""0"" expression=""String(Today(), ~""dd-mm-yyyy~"")""border=""0"" color=""0"" x=""402"" y=""100"" height=""60"" width=""325"" format=""[general]"" html.valueishtml=""0""  name=compute_2 visible=""1""  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=header alignment=""0"" expression=""String(Now(),~""hh:mm:ss~"")""border=""0"" color=""0"" x=""402"" y=""176"" height=""60"" width=""224"" format=""[general]"" html.valueishtml=""0""  name=compute_1 visible=""1""  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=header alignment=""0"" text=""Hora:"" border=""0"" color=""0"" x=""247"" y=""176"" height=""60"" width=""137"" html.valueishtml=""0""  name=t_3 visible=""1""  font.face=""Arial"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
htmltable(border=""0"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" encodeselflinkargs=""1"" netscapelayers=""0"" pagingmethod=0 generatedddwframes=""1"" )
xhtmlgen() cssgen(sessionspecific=""0"" )
xmlgen(inline=""0"" )
xsltgen()
jsgen()
export.xml(headgroups=""1"" includewhitespace=""0"" metadatatype=0 savemetadata=0 )
import.xml()
export.pdf(method=0 distill.custompostscript=""0"" xslfop.print=""0"" )
export.xhtml()
 ";
    }
}
