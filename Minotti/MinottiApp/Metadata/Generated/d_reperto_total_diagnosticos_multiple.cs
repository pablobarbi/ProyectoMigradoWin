using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_reperto_total_diagnosticos_multiple : IDataWindowMetadata
    {
        public string DataObject => "d_reperto_total_diagnosticos_multiple";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "reperto_total",
    DbName = "reperto_total_diag.reperto_total",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "fecha",
    DbName = "reperto_total_diag.fecha",
    Tipo = "date",
    UpdateWhereClause = true,
    EsRequerido = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "comentario",
    DbName = "reperto_total_diag.comentario",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 30,
},

            new DataWindowColumn
{
    Nombre = "paciente",
    DbName = "reperto_total_diag.paciente",
    Tipo = "long",
    UpdateWhereClause = true,
    EsRequerido = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "marca",
    DbName = "reperto_total_diag.marca",
    Tipo = "char(1)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT reperto_total_diag.reperto_total,
       reperto_total_diag.fecha,
       reperto_total_diag.comentario,
       reperto_total_diag.paciente,
       reperto_total_diag.marca
  FROM reperto_total_diag
 WHERE reperto_total_diag.reperto_total = :reperto_total";

        // PB: table.update
        public string Update => @"reperto_total_diag";

        // PB: table.updatewhere (0/1)
        public int UpdateWhere => 0;

        // PB: table.updatekeyinplace (yes/no)
        public bool UpdateKeyInPlace => false;

        public string[] Estilos => Array.Empty<string>();
        public string[] SeleccionFila => Array.Empty<string>();
        public string Operaciones => string.Empty;

        // Inferidos (conservador) por presencia de columnas técnicas
        public bool UsaUsuario => false;
        public bool UsaFecha => true;

        // SRD completo (lossless) por si todavía no existe property en C#
        public string SrdRaw => @"$PBExportHeader$d_reperto_total_diagnosticos_multiple.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=88 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=80 color=""536870912"" height.autosize=yes )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_total dbname=""reperto_total_diag.reperto_total"" dbalias="".reperto_total"" )
 column=(type=date update=yes updatewhereclause=yes name=fecha dbname=""reperto_total_diag.fecha"" dbalias="".fecha"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=comentario dbname=""reperto_total_diag.comentario"" dbalias="".comentario"" )
 column=(type=long update=yes updatewhereclause=yes name=paciente dbname=""reperto_total_diag.paciente"" dbalias="".paciente"" )
 column=(type=char(1) update=yes updatewhereclause=yes name=marca dbname=""reperto_total_diag.marca"" dbalias="".marca"" )
 retrieve=""SELECT reperto_total_diag.reperto_total,
       reperto_total_diag.fecha,
       reperto_total_diag.comentario,
       reperto_total_diag.paciente,
       reperto_total_diag.marca
  FROM reperto_total_diag
 WHERE reperto_total_diag.reperto_total = :reperto_total
"" update=""reperto_total_diag"" updatewhere=0 updatekeyinplace=no arguments=((""reperto_total"", string)) )
text(band=header alignment=""2"" text=""Nro."" border=""6"" color=""8388608"" x=""18"" y=""12"" height=""64"" width=""416"" html.valueishtml=""0""  name=t_1 visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Fecha"" border=""6"" color=""8388608"" x=""457"" y=""12"" height=""64"" width=""416"" html.valueishtml=""0""  name=fecha_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Paciente"" border=""6"" color=""8388608"" x=""896"" y=""12"" height=""64"" width=""1358"" html.valueishtml=""0""  name=paciente_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Comentario"" border=""6"" color=""8388608"" x=""2277"" y=""12"" height=""64"" width=""1234"" html.valueishtml=""0""  name=comentario_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=30 border=""5"" color=""0"" x=""2277"" y=""8"" height=""64"" width=""1234"" format=""[general]"" html.valueishtml=""0""  name=comentario visible=""1"" height.autosize=yes edit.limit=50 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=4 alignment=""1"" tabsequence=20 border=""5"" color=""0"" x=""896"" y=""8"" height=""64"" width=""1358"" format=""[general]"" html.valueishtml=""0""  name=paciente visible=""1"" height.autosize=yes dddw.name=dw_pacientes dddw.displaycolumn=nombre dddw.datacolumn=paciente dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.required=yes dddw.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=2 alignment=""1"" tabsequence=10 border=""5"" color=""0"" x=""457"" y=""8"" height=""64"" width=""416"" format=""dd/mm/yyyy"" html.valueishtml=""0""  name=fecha visible=""1"" editmask.required=yes editmask.mask=""dd/mm/yyyy"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=1 alignment=""1"" tabsequence=32766 border=""5"" color=""0"" x=""18"" y=""8"" height=""64"" width=""416"" format=""[general]"" html.valueishtml=""0""  name=reperto_total visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
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
