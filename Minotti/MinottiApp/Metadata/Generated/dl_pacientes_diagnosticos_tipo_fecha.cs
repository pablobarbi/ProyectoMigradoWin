using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dl_pacientes_diagnosticos_tipo_fecha : IDataWindowMetadata
    {
        public string DataObject => "dl_pacientes_diagnosticos_tipo_fecha";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "paciente",
    DbName = "diagnosticos.paciente",
    Tipo = "long",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "diagnostico",
    DbName = "diagnosticos.diagnostico",
    Tipo = "long",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "fecha_visita",
    DbName = "diagnosticos.fecha_visita",
    Tipo = "date",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "curado",
    DbName = "diagnosticos.curado",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT diagnosticos.paciente,
       diagnosticos.diagnostico,
       diagnosticos.fecha_visita,
       diagnosticos.curado
  FROM diagnosticos
 WHERE (   (:tipo_diagnostico = 'N') AND (diagnosticos.diag_nosologico like :diagnostico)
        OR (:tipo_diagnostico = 'M') AND (diagnosticos.diag_medicamentoso like :diagnostico)
        OR (:tipo_diagnostico = 'I') AND (diagnosticos.diag_miasmatico like :diagnostico)
        OR (:tipo_diagnostico = 'O') AND (diagnosticos.diag_otro like :diagnostico) )
   AND diagnosticos.fecha_visita  >= YMD(SUBSTR(:fecha_desde, 7, 4), SUBSTR(:fecha_desde, 4, 2), SUBSTR(:fecha_desde, 1, 2))
   AND diagnosticos.fecha_visita  <= YMD(SUBSTR(:fecha_hasta, 7, 4), SUBSTR(:fecha_hasta, 4, 2), SUBSTR(:fecha_hasta, 1, 2))";

        // PB: table.update
        public string Update => @"diagnosticos";

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
        public string SrdRaw => @"$PBExportHeader$dl_pacientes_diagnosticos_tipo_fecha.srd
release 7;
datawindow(units=3 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 2 print.margin.left = 2000 print.margin.right = 1000 print.margin.top = 2000 print.margin.bottom = 1000 print.paper.source = 0 print.paper.size = 9 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=3492 color=""553648127"" )
summary(height=0 color=""536870912"" )
footer(height=608 color=""536870912"" )
detail(height=582 color=""536870912""  height.autosize=yes)
table(column=(type=long update=yes updatewhereclause=yes key=yes name=paciente dbname=""diagnosticos.paciente"" )
 column=(type=long update=yes updatewhereclause=yes key=yes name=diagnostico dbname=""diagnosticos.diagnostico"" )
 column=(type=date update=yes updatewhereclause=yes name=fecha_visita dbname=""diagnosticos.fecha_visita"" )
 column=(type=char(1) update=yes updatewhereclause=yes name=curado dbname=""diagnosticos.curado"" values=""Si	S/No	N/"" )
 retrieve=""SELECT diagnosticos.paciente,
       diagnosticos.diagnostico,
       diagnosticos.fecha_visita,
       diagnosticos.curado
  FROM diagnosticos
 WHERE (   (:tipo_diagnostico = 'N') AND (diagnosticos.diag_nosologico like :diagnostico)
        OR (:tipo_diagnostico = 'M') AND (diagnosticos.diag_medicamentoso like :diagnostico)
        OR (:tipo_diagnostico = 'I') AND (diagnosticos.diag_miasmatico like :diagnostico)
        OR (:tipo_diagnostico = 'O') AND (diagnosticos.diag_otro like :diagnostico) )
   AND diagnosticos.fecha_visita  >= YMD(SUBSTR(:fecha_desde, 7, 4), SUBSTR(:fecha_desde, 4, 2), SUBSTR(:fecha_desde, 1, 2))
   AND diagnosticos.fecha_visita  <= YMD(SUBSTR(:fecha_hasta, 7, 4), SUBSTR(:fecha_hasta, 4, 2), SUBSTR(:fecha_hasta, 1, 2))
"" update=""diagnosticos"" updatewhere=1 updatekeyinplace=no arguments=((""fecha_desde"", string),(""fecha_hasta"", string),(""tipo_diagnostico"", string),(""diagnostico"", string)) )
report(band=header dataobject=""r_header"" x=""132"" y=""105"" height=""1666"" width=""17488"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  name=dw_1  slideup=directlyabove )
text(band=header alignment=""2"" text=""Estadísticas de Diagnósticos"" border=""0"" color=""0"" x=""105"" y=""1957"" height=""529"" width=""17488""  name=t_1  font.face=""Arial"" font.height=""-12"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=4 alignment=""2"" tabsequence=32766 border=""0"" color=""0"" x=""16245"" y=""26"" height=""502"" width=""1322"" format=""[general]""  name=curado ddlb.limit=0 ddlb.allowedit=no ddlb.case=any ddlb.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""13387"" y=""26"" height=""502"" width=""2751"" format=""dd/mm/yyyy""  name=fecha_visita editmask.mask=""dd/mm/yyyy"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""105"" y=""26"" height=""502"" width=""13176"" format=""[general]""  name=paciente height.autosize=yes dddw.name=dw_pacientes dddw.displaycolumn=nombre dddw.datacolumn=paciente dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Curado"" border=""2"" color=""0"" x=""16245"" y=""3016"" height=""423"" width=""1322""  name=curado_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Fecha de visita"" border=""2"" color=""0"" x=""13387"" y=""3016"" height=""423"" width=""2751""  name=fecha_visita_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Paciente"" border=""2"" color=""0"" x=""105"" y=""3016"" height=""423"" width=""13176""  name=paciente_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
line(band=footer x1=""105"" y1=""26"" x2=""17594"" y2=""26""  name=l_2 pen.style=""0"" pen.width=""26"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
compute(band=footer alignment=""1"" expression=""'Pag. ' + page() + ' de ' + pageCount()""border=""0"" color=""0"" x=""12594"" y=""106"" height=""423"" width=""4947"" format=""[general]""  name=page_1  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=footer alignment=""0"" expression=""today()""border=""0"" color=""0"" x=""185"" y=""132"" height=""396"" width=""3042"" format=""dd/mm/yyyy""  name=date_1  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
