using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dl_pacientes_diagnostico : IDataWindowMetadata
    {
        public string DataObject => "dl_pacientes_diagnostico";

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
    TabOrder = 32766,
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
    Nombre = "diag_nosologico",
    DbName = "diagnosticos.diag_nosologico",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "diag_medicamentoso",
    DbName = "diagnosticos.diag_medicamentoso",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "diag_miasmatico",
    DbName = "diagnosticos.diag_miasmatico",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "diag_otro",
    DbName = "diagnosticos.diag_otro",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "repertorizacion",
    DbName = "diagnosticos.repertorizacion",
    Tipo = "long",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "primera",
    DbName = "diagnosticos.primera",
    Tipo = "char(1)",
    UpdateWhereClause = true,
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
       diagnosticos.diag_nosologico,
       diagnosticos.diag_medicamentoso,
       diagnosticos.diag_miasmatico,
       diagnosticos.diag_otro,
       diagnosticos.repertorizacion,
       diagnosticos.primera,
       diagnosticos.curado
  FROM diagnosticos
 WHERE diagnosticos.paciente = :paciente";

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
        public string SrdRaw => @"$PBExportHeader$dl_pacientes_diagnostico.srd
release 7;
datawindow(units=3 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 2 print.margin.left = 2000 print.margin.right = 1000 print.margin.top = 2000 print.margin.bottom = 1000 print.paper.source = 0 print.paper.size = 9 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=3466 color=""553648127"" )
summary(height=0 color=""536870912"" )
footer(height=608 color=""536870912"" )
detail(height=3254 color=""536870912""  height.autosize=yes)
table(column=(type=long update=yes updatewhereclause=yes key=yes name=paciente dbname=""diagnosticos.paciente"" )
 column=(type=long update=yes updatewhereclause=yes key=yes name=diagnostico dbname=""diagnosticos.diagnostico"" )
 column=(type=date update=yes updatewhereclause=yes name=fecha_visita dbname=""diagnosticos.fecha_visita"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=diag_nosologico dbname=""diagnosticos.diag_nosologico"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=diag_medicamentoso dbname=""diagnosticos.diag_medicamentoso"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=diag_miasmatico dbname=""diagnosticos.diag_miasmatico"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=diag_otro dbname=""diagnosticos.diag_otro"" )
 column=(type=long update=yes updatewhereclause=yes name=repertorizacion dbname=""diagnosticos.repertorizacion"" )
 column=(type=char(1) update=yes updatewhereclause=yes name=primera dbname=""diagnosticos.primera"" values=""Si	S/No	N/"" )
 column=(type=char(1) update=yes updatewhereclause=yes name=curado dbname=""diagnosticos.curado"" values=""Si	S/No	N/"" )
 retrieve=""SELECT diagnosticos.paciente,
       diagnosticos.diagnostico,
       diagnosticos.fecha_visita,
       diagnosticos.diag_nosologico,
       diagnosticos.diag_medicamentoso,
       diagnosticos.diag_miasmatico,
       diagnosticos.diag_otro,
       diagnosticos.repertorizacion,
       diagnosticos.primera,
       diagnosticos.curado
  FROM diagnosticos
 WHERE diagnosticos.paciente = :paciente
"" update=""diagnosticos"" updatewhere=1 updatekeyinplace=no arguments=((""paciente"", string)) )
text(band=header alignment=""0"" text=""Paciente:"" border=""0"" color=""0"" x=""132"" y=""2857"" height=""449"" width=""1587""  name=t_1  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Curado"" border=""2"" color=""0"" x=""25294"" y=""3492"" height=""476"" width=""1217""  name=curado_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
compute(band=footer alignment=""0"" expression=""today()""border=""0"" color=""0"" x=""132"" y=""132"" height=""396"" width=""2116"" format=""[general]""  name=date_1  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
report(band=header dataobject=""r_header"" x=""105"" y=""158"" height=""1640"" width=""17462"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  name=dw_1  slideup=directlyabove )
text(band=header alignment=""2"" text=""Diagnósticos"" border=""0"" color=""0"" x=""105"" y=""2116"" height=""529"" width=""17462""  name=t_2  font.face=""Arial"" font.height=""-12"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""536870912"" )
column(band=header id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1825"" y=""2857"" height=""449"" width=""15689"" format=""[general]""  name=paciente dddw.name=dw_pacientes dddw.displaycolumn=nombre dddw.datacolumn=paciente dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
line(band=footer x1=""105"" y1=""52"" x2=""17568"" y2=""52""  name=l_1 pen.style=""0"" pen.width=""26"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
compute(band=footer alignment=""1"" expression=""'Pag. ' + page() + ' de ' + pageCount()""border=""0"" color=""0"" x=""13943"" y=""132"" height=""396"" width=""3624"" format=""[general]""  name=page_1  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Nosológico:"" border=""0"" color=""0"" x=""185"" y=""688"" height=""502"" width=""3122""  name=diag_nosologico_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Miasmático:"" border=""0"" color=""0"" x=""185"" y=""1905"" height=""502"" width=""3122""  name=diag_miasmatico_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Otro:"" border=""0"" color=""0"" x=""185"" y=""2514"" height=""502"" width=""3122""  name=diag_otro_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Medicamentoso:"" border=""0"" color=""0"" x=""185"" y=""1297"" height=""502"" width=""3122""  name=diag_medicamentoso_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Fecha:"" border=""0"" color=""0"" x=""1613"" y=""80"" height=""502"" width=""1746""  name=fecha_visita_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""3466"" y=""80"" height=""502"" width=""1746"" format=""dd/mm/yyyy""  name=fecha_visita edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3413"" y=""688"" height=""502"" width=""14155"" format=""[general]""  name=diag_nosologico height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3413"" y=""1297"" height=""502"" width=""14155"" format=""[general]""  name=diag_medicamentoso height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=6 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3413"" y=""1905"" height=""502"" width=""14155"" format=""[general]""  name=diag_miasmatico height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=7 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3413"" y=""2514"" height=""502"" width=""14155"" format=""[general]""  name=diag_otro height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
line(band=detail x1=""132"" y1=""3149"" x2=""17594"" y2=""3149""  name=l_2 pen.style=""0"" pen.width=""26"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""2"" text=""Curado:"" border=""0"" color=""0"" x=""14922"" y=""80"" height=""502"" width=""1296""  name=t_3  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=10 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""16324"" y=""80"" height=""502"" width=""1217"" format=""[general]""  name=curado ddlb.limit=0 ddlb.allowedit=no ddlb.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Nro.:"" border=""0"" color=""0"" x=""8387"" y=""80"" height=""502"" width=""1349""  name=diagnostico_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""9868"" y=""80"" height=""502"" width=""1349"" format=""[general]""  name=diagnostico edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
