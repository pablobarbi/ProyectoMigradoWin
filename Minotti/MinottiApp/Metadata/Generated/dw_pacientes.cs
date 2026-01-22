using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dw_pacientes : IDataWindowMetadata
    {
        public string DataObject => "dw_pacientes";

        public List<DataWindowColumn> Columns { get; } = new()
        {
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
        public string Sql => @"SELECT nombre
   FROM pacientes
 ORDER BY 1";

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
        public string SrdRaw => @"$PBExportHeader$dw_pacientes.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=67108864 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=0 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912"" )
table(column=(type=char(50) updatewhereclause=yes name=nombre dbname=""pacientes.nombre"" )
 retrieve=""SELECT nombre
   FROM pacientes
 ORDER BY 1
"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""6"" color=""33554432"" x=""14"" y=""8"" height=""68"" width=""1490"" format=""[general]"" html.valueishtml=""0""  name=nombre visible=""1"" edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
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
