using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dw_subrubricas : IDataWindowMetadata
    {
        public string DataObject => "dw_subrubricas";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "subrubrica",
    DbName = "subrubricas.subrubrica",
    Tipo = "decimal(0)",
    EsClave = true,
    EsIdentity = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "subrubricas.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 10,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT subrubricas.subrubrica,
       subrubricas.nombre
  FROM subrubricas
ORDER BY 2";

        // PB: table.update
        public string Update => @"subrubricas";

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
        public string SrdRaw => @"$PBExportHeader$dw_subrubricas.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=0 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=80 color=""536870912"" height.autosize=yes )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes identity=yes name=subrubrica dbname=""subrubricas.subrubrica"" dbalias="".subrubrica"" )
 column=(type=char(255) update=yes updatewhereclause=yes name=nombre dbname=""subrubricas.nombre"" dbalias="".nombre"" )
 retrieve=""SELECT subrubricas.subrubrica,
       subrubricas.nombre
  FROM subrubricas
ORDER BY 2"" update=""subrubricas"" updatewhere=1 updatekeyinplace=no )
column(band=detail id=2 alignment=""0"" tabsequence=10 border=""6"" color=""0"" x=""18"" y=""4"" height=""68"" width=""997"" format=""[general]"" html.valueishtml=""0""  name=nombre visible=""1"" height.autosize=yes edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
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
