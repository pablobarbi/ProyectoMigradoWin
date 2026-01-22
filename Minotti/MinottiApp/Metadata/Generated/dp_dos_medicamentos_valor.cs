using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_dos_medicamentos_valor : IDataWindowMetadata
    {
        public string DataObject => "dp_dos_medicamentos_valor";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "capitulo",
    DbName = "capitulacion_med.capitulo",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    EsRequerido = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "medicamento",
    DbName = "capitulacion_med.medicamento",
    Tipo = "char(10)",
    EsClave = true,
    UpdateWhereClause = true,
    EsRequerido = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "valor",
    DbName = "capitulacion_med.valor",
    Tipo = "long",
    EsClave = true,
    UpdateWhereClause = true,
    EsRequerido = true,
    TabOrder = 30,
},

            new DataWindowColumn
{
    Nombre = "medicamento2",
    DbName = "medicamento2",
    Tipo = "char(10)",
    EsClave = true,
    UpdateWhereClause = true,
    EsRequerido = true,
    TabOrder = 40,
},

            new DataWindowColumn
{
    Nombre = "valor2",
    DbName = "valor2",
    Tipo = "long",
    EsClave = true,
    UpdateWhereClause = true,
    EsRequerido = true,
    TabOrder = 50,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT capitulacion_med.capitulo,
       capitulacion_med.medicamento,
       capitulacion_med.valor,
       capitulacion_med.medicamento medicamento2,
       capitulacion_med.valor valor2
  FROM capitulacion_med";

        // PB: table.update
        public string Update => @"a";

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
        public string SrdRaw => @"$PBExportHeader$dp_dos_medicamentos_valor.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=0 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=204 color=""536870912"" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=capitulo dbname=""capitulacion_med.capitulo"" )
 column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento dbname=""capitulacion_med.medicamento"" )
 column=(type=long update=yes updatewhereclause=yes key=yes name=valor dbname=""capitulacion_med.valor"" values=""1	1/2	2/3	3/"" )
 column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento2 dbname=""medicamento2"" )
 column=(type=long update=yes updatewhereclause=yes key=yes name=valor2 dbname=""valor2"" values=""1	1/2	2/3	3/"" )
 retrieve=""SELECT capitulacion_med.capitulo,
       capitulacion_med.medicamento,
       capitulacion_med.valor,
       capitulacion_med.medicamento medicamento2,
       capitulacion_med.valor valor2
  FROM capitulacion_med
"" update=""a"" updatewhere=0 updatekeyinplace=no )
text(band=detail alignment=""1"" text=""Valor:"" border=""0"" color=""8388608"" x=""2569"" y=""16"" height=""68"" width=""197"" html.valueishtml=""0""  name=valor_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""1"" tabsequence=30 border=""5"" color=""0"" x=""2793"" y=""16"" height=""68"" width=""242"" format=""[general]"" html.valueishtml=""0""  name=valor visible=""1"" ddlb.limit=0 ddlb.allowedit=no ddlb.case=any ddlb.required=yes ddlb.nilisnull=yes ddlb.useasborder=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Valor:"" border=""0"" color=""8388608"" x=""2569"" y=""112"" height=""68"" width=""197"" html.valueishtml=""0""  name=t_1 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""0"" tabsequence=50 border=""5"" color=""0"" x=""2793"" y=""112"" height=""64"" width=""242"" format=""[general]"" html.valueishtml=""0""  name=valor2 visible=""1"" ddlb.limit=0 ddlb.allowedit=no ddlb.case=any ddlb.required=yes ddlb.nilisnull=yes ddlb.useasborder=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=2 alignment=""0"" tabsequence=20 border=""5"" color=""0"" x=""1925"" y=""16"" height=""68"" width=""608"" format=""[general]"" html.valueishtml=""0""  name=medicamento visible=""1"" dddw.name=dw_medicamentos dddw.displaycolumn=medicamento dddw.datacolumn=medicamento dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=yes dddw.case=any dddw.required=yes dddw.nilisnull=yes dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=4 alignment=""0"" tabsequence=40 border=""5"" color=""0"" x=""1925"" y=""112"" height=""64"" width=""608"" format=""[general]"" html.valueishtml=""0""  name=medicamento2 visible=""1"" dddw.name=dw_medicamentos dddw.displaycolumn=medicamento dddw.datacolumn=medicamento dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=yes dddw.case=any dddw.required=yes dddw.nilisnull=yes dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Medicamento:"" border=""0"" color=""8388608"" x=""1486"" y=""16"" height=""68"" width=""411"" html.valueishtml=""0""  name=medicamento_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Medicamento:"" border=""0"" color=""8388608"" x=""1486"" y=""112"" height=""68"" width=""411"" html.valueishtml=""0""  name=t_2 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Capítulo:"" border=""0"" color=""8388608"" x=""23"" y=""52"" height=""68"" width=""283"" html.valueishtml=""0""  name=capitulo_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""1"" tabsequence=10 border=""5"" color=""0"" x=""334"" y=""52"" height=""68"" width=""1115"" format=""[general]"" html.valueishtml=""0""  name=capitulo visible=""1"" dddw.name=dw_capitulos dddw.displaycolumn=nombre dddw.datacolumn=capitulo dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=yes dddw.case=any dddw.required=yes dddw.nilisnull=yes dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
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
