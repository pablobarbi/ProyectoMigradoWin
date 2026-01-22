using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_pacientes_diagnosticos_tipo_fecha : IDataWindowMetadata
    {
        public string DataObject => "dr_pacientes_diagnosticos_tipo_fecha";

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
        public string SrdRaw => @"$PBExportHeader$dr_pacientes_diagnosticos_tipo_fecha.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=84 color=""81324524"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912""  height.autosize=yes)
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
"" update=""diagnosticos"" updatewhere=1 updatekeyinplace=no arguments=((""fecha_desde"", string),(""fecha_hasta"", string),(""diagnostico"", string),(""tipo_diagnostico"", string)) )
text(band=header alignment=""2"" text=""Paciente"" border=""6"" color=""8388608"" x=""18"" y=""12"" height=""64"" width=""1792""  name=paciente_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Curado"" border=""6"" color=""8388608"" x=""2286"" y=""12"" height=""64"" width=""229""  name=curado_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Fecha de visita"" border=""6"" color=""8388608"" x=""1829"" y=""12"" height=""64"" width=""439""  name=fecha_visita_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""18"" y=""4"" height=""76"" width=""1792"" format=""[general]""  name=paciente height.autosize=yes dddw.name=dw_pacientes dddw.displaycolumn=nombre dddw.datacolumn=paciente dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""2"" tabsequence=32766 border=""0"" color=""0"" x=""2286"" y=""4"" height=""76"" width=""229"" format=""[general]""  name=curado ddlb.limit=0 ddlb.allowedit=no ddlb.case=any ddlb.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""1829"" y=""4"" height=""76"" width=""439"" format=""dd/mm/yyyy""  name=fecha_visita editmask.mask=""dd/mm/yyyy"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
