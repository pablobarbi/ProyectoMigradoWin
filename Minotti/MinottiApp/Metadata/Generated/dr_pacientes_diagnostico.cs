using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_pacientes_diagnostico : IDataWindowMetadata
    {
        public string DataObject => "dr_pacientes_diagnostico";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "paciente",
    DbName = "diagnosticos.paciente",
    Tipo = "long",
    EsClave = true,
    UpdateWhereClause = true,
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
        public string SrdRaw => @"$PBExportHeader$dr_pacientes_diagnostico.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 2 print.margin.left = 347 print.margin.right = 174 print.margin.top = 304 print.margin.bottom = 152 print.paper.source = 0 print.paper.size = 9 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=112 color=""81324524"" )
summary(height=0 color=""536870912"" )
footer(height=4 color=""536870912"" )
detail(height=492 color=""536870912""  height.autosize=yes)
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
text(band=header alignment=""2"" text=""Curado"" border=""2"" color=""0"" x=""4370"" y=""528"" height=""72"" width=""210""  name=curado_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Diagnósticos"" border=""6"" color=""8388608"" x=""18"" y=""20"" height=""80"" width=""3017""  name=t_2  font.face=""Arial"" font.height=""-12"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""599"" y=""12"" height=""76"" width=""302"" format=""dd/mm/yyyy""  name=fecha_visita edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""590"" y=""104"" height=""76"" width=""2446"" format=""[general]""  name=diag_nosologico height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""590"" y=""196"" height=""76"" width=""2446"" format=""[general]""  name=diag_medicamentoso height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=6 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""590"" y=""288"" height=""76"" width=""2446"" format=""[general]""  name=diag_miasmatico height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=7 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""590"" y=""380"" height=""76"" width=""2446"" format=""[general]""  name=diag_otro height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
line(band=detail x1=""23"" y1=""476"" x2=""3040"" y2=""476""  name=l_2 pen.style=""0"" pen.width=""5"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
column(band=detail id=10 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2821"" y=""12"" height=""76"" width=""210"" format=""[general]""  name=curado ddlb.limit=0 ddlb.allowedit=no ddlb.case=any  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1705"" y=""12"" height=""76"" width=""233"" format=""[general]""  name=diagnostico edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""2"" text=""Curado:"" border=""0"" color=""8388608"" x=""2578"" y=""12"" height=""76"" width=""224""  name=t_3  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Nro.:"" border=""0"" color=""8388608"" x=""1449"" y=""12"" height=""76"" width=""233""  name=diagnostico_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Fecha:"" border=""0"" color=""8388608"" x=""279"" y=""12"" height=""76"" width=""302""  name=fecha_visita_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Nosológico:"" border=""0"" color=""8388608"" x=""32"" y=""104"" height=""76"" width=""539""  name=diag_nosologico_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Medicamentoso:"" border=""0"" color=""8388608"" x=""32"" y=""196"" height=""76"" width=""539""  name=diag_medicamentoso_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Miasmático:"" border=""0"" color=""8388608"" x=""32"" y=""288"" height=""76"" width=""539""  name=diag_miasmatico_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Otro:"" border=""0"" color=""8388608"" x=""32"" y=""380"" height=""76"" width=""539""  name=diag_otro_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
