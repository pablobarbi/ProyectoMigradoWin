using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_medicamentos_de_la_subrubrica : IDataWindowMetadata
    {
        public string DataObject => "dk_medicamentos_de_la_subrubrica";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "medicamento",
    DbName = "rubricacion_med.medicamento",
    Tipo = "char(10)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "descripcion",
    DbName = "medicamentos.descripcion",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "valor",
    DbName = "rubricacion_med.valor",
    Tipo = "decimal(6)",
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "seleccionado",
    DbName = "seleccionado",
    Tipo = "char(1)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT rubricacion_med.medicamento,
       medicamentos.descripcion,
       rubricacion_med.valor,
       'S' seleccionado
  FROM rubricacion_med,
       medicamentos
 WHERE rubricacion_med.medicamento = medicamentos.medicamento
   AND rubricacion_med.rubrica = :rubrica
   AND rubricacion_med.subrubrica = :subrubrica
 UNION
SELECT medicamentos.medicamento,
       medicamentos.descripcion,
       ' ' valor,
       'N' seleccionado
  FROM medicamentos
 WHERE medicamentos.medicamento NOT IN ( SELECT rubricacion_med.medicamento FROM rubricacion_med
                                          WHERE rubricacion_med.rubrica = :rubrica AND rubricacion_med.subrubrica = :subrubrica )
ORDER BY 3 DESC , 1 ASC";

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
        public string SrdRaw => @"$PBExportHeader$dk_medicamentos_de_la_subrubrica.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=88 color=""82899184"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912"" )
table(column=(type=char(10) updatewhereclause=yes name=medicamento dbname=""rubricacion_med.medicamento"" )
 column=(type=char(50) updatewhereclause=yes name=descripcion dbname=""medicamentos.descripcion"" )
 column=(type=decimal(6) updatewhereclause=yes name=valor dbname=""rubricacion_med.valor"" values=""1	1/2	2/3	3/0	0/"" )
 column=(type=char(1) updatewhereclause=yes name=seleccionado dbname=""seleccionado"" )
 retrieve=""SELECT rubricacion_med.medicamento,
       medicamentos.descripcion,
       rubricacion_med.valor,
       'S' seleccionado
  FROM rubricacion_med,
       medicamentos
 WHERE rubricacion_med.medicamento = medicamentos.medicamento
   AND rubricacion_med.rubrica = :rubrica
   AND rubricacion_med.subrubrica = :subrubrica
 UNION
SELECT medicamentos.medicamento,
       medicamentos.descripcion,
       ' ' valor,
       'N' seleccionado
  FROM medicamentos
 WHERE medicamentos.medicamento NOT IN ( SELECT rubricacion_med.medicamento FROM rubricacion_med
                                          WHERE rubricacion_med.rubrica = :rubrica AND rubricacion_med.subrubrica = :subrubrica )
ORDER BY 3 DESC , 1 ASC

"" arguments=((""rubrica"", string),(""subrubrica"", string)) )
text(band=header alignment=""2"" text=""Medicamento"" border=""6"" color=""8388608"" x=""18"" y=""12"" height=""64"" width=""421"" html.valueishtml=""0""  name=medicamento_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Descripcion"" border=""6"" color=""8388608"" x=""457"" y=""12"" height=""64"" width=""1399"" html.valueishtml=""0""  name=descripcion_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Valor"" border=""6"" color=""8388608"" x=""1883"" y=""12"" height=""64"" width=""210"" html.valueishtml=""0""  name=valor_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""18"" y=""4"" height=""76"" width=""421"" format=""[general]"" html.valueishtml=""0""  name=medicamento visible=""1"" editmask.mask=""!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""457"" y=""4"" height=""76"" width=""1399"" format=""[general]"" html.valueishtml=""0""  name=descripcion visible=""1"" editmask.mask=""!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=10 border=""0"" color=""0"" x=""1879"" y=""4"" height=""76"" width=""210"" format=""#"" html.valueishtml=""0""  name=valor visible=""1"" ddlb.limit=0 ddlb.allowedit=no ddlb.case=any ddlb.nilisnull=yes ddlb.vscrollbar=yes ddlb.useasborder=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
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
