using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dl_capitulo_matriz : IDataWindowMetadata
    {
        public string DataObject => "dl_capitulo_matriz";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "capitulo_nombre",
    DbName = "capitulaciones_matriz.capitulo_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "rubrica_nombre",
    DbName = "capitulaciones_matriz.rubrica_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica_nombre",
    DbName = "capitulaciones_matriz.subrubrica_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 0,
},

            new DataWindowColumn
{
    Nombre = "subrubrica01_nombre",
    DbName = "capitulaciones_matriz.subrubrica01_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica02_nombre",
    DbName = "capitulaciones_matriz.subrubrica02_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica03_nombre",
    DbName = "capitulaciones_matriz.subrubrica03_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica04_nombre",
    DbName = "capitulaciones_matriz.subrubrica04_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica05_nombre",
    DbName = "capitulaciones_matriz.subrubrica05_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica06_nombre",
    DbName = "capitulaciones_matriz.subrubrica06_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica07_nombre",
    DbName = "capitulaciones_matriz.subrubrica07_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica08_nombre",
    DbName = "capitulaciones_matriz.subrubrica08_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica09_nombre",
    DbName = "capitulaciones_matriz.subrubrica09_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica10_nombre",
    DbName = "capitulaciones_matriz.subrubrica10_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT capitulo_nombre,
         rubrica_nombre,
         subrubrica_nombre,
         subrubrica01_nombre,
         subrubrica02_nombre,
         subrubrica03_nombre,
         subrubrica04_nombre,
         subrubrica05_nombre,
         subrubrica06_nombre,
         subrubrica07_nombre,
         subrubrica08_nombre,
         subrubrica09_nombre,
         subrubrica10_nombre
    FROM capitulaciones_matriz
   WHERE UPPER(capitulo_nombre    ) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(rubrica_nombre     ) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica_nombre  ) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica01_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica02_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica03_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica04_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica05_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica06_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica07_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica08_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica09_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica10_nombre) LIKE '%' + UPPER(:filtro) + '%'
ORDER BY 1,2,3";

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
        public string SrdRaw => @"$PBExportHeader$dl_capitulo_matriz.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=428 color=""553648127"" )
summary(height=0 color=""536870912"" )
footer(height=104 color=""536870912"" )
detail(height=620 color=""536870912"" )
table(column=(type=char(255) updatewhereclause=yes name=capitulo_nombre dbname=""capitulaciones_matriz.capitulo_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=rubrica_nombre dbname=""capitulaciones_matriz.rubrica_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica_nombre dbname=""capitulaciones_matriz.subrubrica_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica01_nombre dbname=""capitulaciones_matriz.subrubrica01_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica02_nombre dbname=""capitulaciones_matriz.subrubrica02_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica03_nombre dbname=""capitulaciones_matriz.subrubrica03_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica04_nombre dbname=""capitulaciones_matriz.subrubrica04_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica05_nombre dbname=""capitulaciones_matriz.subrubrica05_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica06_nombre dbname=""capitulaciones_matriz.subrubrica06_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica07_nombre dbname=""capitulaciones_matriz.subrubrica07_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica08_nombre dbname=""capitulaciones_matriz.subrubrica08_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica09_nombre dbname=""capitulaciones_matriz.subrubrica09_nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica10_nombre dbname=""capitulaciones_matriz.subrubrica10_nombre"" )
 retrieve=""  SELECT capitulo_nombre,
         rubrica_nombre,
         subrubrica_nombre,
         subrubrica01_nombre,
         subrubrica02_nombre,
         subrubrica03_nombre,
         subrubrica04_nombre,
         subrubrica05_nombre,
         subrubrica06_nombre,
         subrubrica07_nombre,
         subrubrica08_nombre,
         subrubrica09_nombre,
         subrubrica10_nombre
    FROM capitulaciones_matriz
   WHERE UPPER(capitulo_nombre    ) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(rubrica_nombre     ) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica_nombre  ) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica01_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica02_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica03_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica04_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica05_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica06_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica07_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica08_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica09_nombre) LIKE '%' + UPPER(:filtro) + '%'
      OR UPPER(subrubrica10_nombre) LIKE '%' + UPPER(:filtro) + '%'
ORDER BY 1,2,3"" arguments=((""filtro"", string)) )
report(band=header dataobject=""r_header"" x=""23"" y=""16"" height=""252"" width=""3022"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  name=dw_1 visible=""1""  slideup=directlyabove )
text(band=header alignment=""2"" text=""REPORTE DE CAPÍTULOS COMPLETO FILTRADO POR:"" border=""0"" color=""0"" x=""46"" y=""316"" height=""80"" width=""1957"" html.valueishtml=""0""  name=t_2 visible=""1""  font.face=""Arial"" font.height=""-12"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=header alignment=""0"" expression=""if ( isNull(  filtro ), '--' , filtro )""border=""0"" color=""0"" x=""2016"" y=""316"" height=""80"" width=""1202"" format=""[GENERAL]"" html.valueishtml=""0""  name=compute_1 visible=""1""  font.face=""Arial"" font.height=""-12"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Capítulo:"" border=""0"" color=""0"" x=""151"" y=""12"" height=""64"" width=""261"" html.valueishtml=""0""  name=t_1 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Rubrica:"" border=""0"" color=""0"" x=""165"" y=""104"" height=""68"" width=""242"" html.valueishtml=""0""  name=t_3 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""430"" y=""12"" height=""68"" width=""1198"" format=""[general]"" html.valueishtml=""0""  name=capitulo_nombre visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
line(band=detail x1=""23"" y1=""604"" x2=""3296"" y2=""604""  name=l_1 visible=""1"" pen.style=""0"" pen.width=""5"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Subrubrica  6:"" border=""0"" color=""0"" x=""1673"" y=""180"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_10 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  7:"" border=""0"" color=""0"" x=""1673"" y=""264"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_9 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  8:"" border=""0"" color=""0"" x=""1673"" y=""348"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_12 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  9:"" border=""0"" color=""0"" x=""1673"" y=""432"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_11 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica 10:"" border=""0"" color=""0"" x=""1659"" y=""516"" height=""68"" width=""384"" html.valueishtml=""0""  name=t_13 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  5:"" border=""0"" color=""0"" x=""1678"" y=""96"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_8 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=8 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2071"" y=""96"" height=""68"" width=""1198"" format=""[general]"" html.valueishtml=""0""  name=subrubrica05_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=9 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2066"" y=""180"" height=""68"" width=""1198"" format=""[general]"" html.valueishtml=""0""  name=subrubrica06_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=10 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2066"" y=""264"" height=""68"" width=""1198"" format=""[general]"" html.valueishtml=""0""  name=subrubrica07_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=11 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2066"" y=""348"" height=""68"" width=""1198"" format=""[general]"" html.valueishtml=""0""  name=subrubrica08_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=12 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2066"" y=""432"" height=""68"" width=""1198"" format=""[general]"" html.valueishtml=""0""  name=subrubrica09_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=13 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2066"" y=""516"" height=""68"" width=""1198"" format=""[general]"" html.valueishtml=""0""  name=subrubrica10_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  1:"" border=""0"" color=""0"" x=""37"" y=""268"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_4 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  2:"" border=""0"" color=""0"" x=""37"" y=""352"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_5 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  3:"" border=""0"" color=""0"" x=""37"" y=""436"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_7 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  4:"" border=""0"" color=""0"" x=""37"" y=""520"" height=""68"" width=""370"" html.valueishtml=""0""  name=t_6 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""430"" y=""268"" height=""68"" width=""1193"" format=""[general]"" html.valueishtml=""0""  name=subrubrica01_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""430"" y=""352"" height=""68"" width=""1198"" format=""[general]"" html.valueishtml=""0""  name=subrubrica02_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=6 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""430"" y=""436"" height=""68"" width=""1198"" format=""[general]"" html.valueishtml=""0""  name=subrubrica03_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=7 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""430"" y=""520"" height=""68"" width=""1198"" format=""[general]"" html.valueishtml=""0""  name=subrubrica04_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Subrubrica  0:"" border=""0"" color=""0"" x=""37"" y=""184"" height=""64"" width=""370"" html.valueishtml=""0""  name=t_14 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
line(band=footer x1=""18"" y1=""8"" x2=""3278"" y2=""8""  name=l_2 visible=""1"" pen.style=""0"" pen.width=""5"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
compute(band=footer alignment=""1"" expression=""'Pag. ' + page() + ' de ' + pageCount()""border=""0"" color=""0"" x=""2418"" y=""20"" height=""64"" width=""855"" format=""[general]"" html.valueishtml=""0""  name=page_1 visible=""1""  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=footer alignment=""0"" expression=""today()""border=""0"" color=""0"" x=""32"" y=""24"" height=""60"" width=""526"" format=""dd/mm/yyyy"" html.valueishtml=""0""  name=date_1 visible=""1""  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""430"" y=""100"" height=""68"" width=""1198"" format=""[general]"" html.valueishtml=""0""  name=rubrica_nombre visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=3 alignment=""0"" tabsequence=0 border=""0"" color=""0"" x=""430"" y=""184"" height=""64"" width=""1198"" html.valueishtml=""0""  name=subrubrica_nombre visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
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
