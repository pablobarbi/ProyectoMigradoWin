using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_medicamentos_de_la_rubrica_vfinal_bug : IDataWindowMetadata
    {
        public string DataObject => "dk_medicamentos_de_la_rubrica_vfinal_bug";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "medicamento",
    DbName = "capitulacion_med.medicamento",
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
    DbName = "capitulacion_med.valor",
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
        public string Sql => @"SELECT capitulacion_med.medicamento,
       medicamentos.descripcion,
       capitulacion_med.valor,
       'S' seleccionado
  FROM capitulacion_med,
       medicamentos
 WHERE capitulacion_med.medicamento = medicamentos.medicamento
   AND capitulacion_med.capitulo = :capitulo
   AND capitulacion_med.rubrica = :rubrica
 UNION
SELECT medicamentos.medicamento,
       medicamentos.descripcion,
       ' ' valor,
       'N' seleccionado
  FROM medicamentos
 WHERE medicamentos.medicamento NOT IN ( SELECT capitulacion_med.medicamento FROM capitulacion_med
                                          WHERE capitulacion_med.capitulo = :capitulo AND capitulacion_med.rubrica = :rubrica )";

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
        public string SrdRaw => @"$PBExportHeader$dk_medicamentos_de_la_rubrica_vfinal_bug.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=88 color=""82899184"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=88 color=""536870912"" height.autosize=yes )
table(column=(type=char(10) updatewhereclause=yes name=medicamento dbname=""capitulacion_med.medicamento"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=descripcion dbname=""medicamentos.descripcion"" )
 column=(type=decimal(6) updatewhereclause=yes name=valor dbname=""capitulacion_med.valor"" values=""1	1/2	2/3	3/"" )
 column=(type=char(1) updatewhereclause=yes name=seleccionado dbname=""seleccionado"" )
 retrieve=""SELECT capitulacion_med.medicamento,
       medicamentos.descripcion,
       capitulacion_med.valor,
       'S' seleccionado
  FROM capitulacion_med,
       medicamentos
 WHERE capitulacion_med.medicamento = medicamentos.medicamento
   AND capitulacion_med.capitulo = :capitulo
   AND capitulacion_med.rubrica = :rubrica
 UNION
SELECT medicamentos.medicamento,
       medicamentos.descripcion,
       ' ' valor,
       'N' seleccionado
  FROM medicamentos
 WHERE medicamentos.medicamento NOT IN ( SELECT capitulacion_med.medicamento FROM capitulacion_med
                                          WHERE capitulacion_med.capitulo = :capitulo AND capitulacion_med.rubrica = :rubrica )


"" arguments=((""capitulo"", string),(""rubrica"", string)) )
group(level=1 header.height=88 trailer.height=0 by=(""seleccionado"" ) header.color=""536870912"" trailer.color=""536870912"" )
text(band=header alignment=""2"" text=""Descripcion"" border=""6"" color=""8388608"" x=""457"" y=""12"" height=""64"" width=""1399"" html.valueishtml=""0""  name=descripcion_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Medicamento"" border=""6"" color=""8388608"" x=""18"" y=""12"" height=""64"" width=""421"" html.valueishtml=""0""  name=medicamento_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Valor"" border=""6"" color=""8388608"" x=""1879"" y=""12"" height=""64"" width=""210"" html.valueishtml=""0""  name=t_1 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=header.1 alignment=""0"" expression=""if (  seleccionado = 'S' , 'Los siguientes medicamentos ya pertenecen a la rubrica:', 'Los siguientes medicamentos no estan seleccionados en la rubrica:' )""border=""0"" color=""128"" x=""18"" y=""12"" height=""64"" width=""2057"" format=""[GENERAL]"" html.valueishtml=""0""  name=compute_1 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""457"" y=""4"" height=""76"" width=""1399"" format=""[general]"" html.valueishtml=""0""  name=descripcion visible=""1"" edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""18"" y=""4"" height=""76"" width=""421"" format=""[general]"" html.valueishtml=""0""  name=medicamento visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=10 border=""0"" color=""0"" x=""1879"" y=""4"" height=""76"" width=""210"" format=""[general]"" html.valueishtml=""0""  name=valor visible=""1"" ddlb.limit=0 ddlb.allowedit=no ddlb.case=any ddlb.nilisnull=yes ddlb.vscrollbar=yes ddlb.useasborder=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
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
