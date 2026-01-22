using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_global_diagnosticos : IDataWindowMetadata
    {
        public string DataObject => "dr_global_diagnosticos";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "paciente",
    DbName = "diagnosticos.paciente",
    Tipo = "long",
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
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT diagnosticos.paciente,
       diagnosticos.fecha_visita,
       diagnosticos.diag_nosologico,
       diagnosticos.diag_medicamentoso,
       diagnosticos.diag_miasmatico,
       diagnosticos.diag_otro
  FROM diagnosticos
 WHERE diagnosticos.diag_nosologico like :campo  OR  
       diagnosticos.diag_medicamentoso like :campo  OR  
       diagnosticos.diag_miasmatico like :campo  OR  
       diagnosticos.diag_otro like :campo";

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
        public string SrdRaw => @"$PBExportHeader$dr_global_diagnosticos.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=92 color=""81324524"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=80 color=""536870912""  height.autosize=yes)
table(column=(type=long updatewhereclause=yes name=paciente dbname=""diagnosticos.paciente"" )
 column=(type=date updatewhereclause=yes name=fecha_visita dbname=""diagnosticos.fecha_visita"" )
 column=(type=char(50) updatewhereclause=yes name=diag_nosologico dbname=""diagnosticos.diag_nosologico"" )
 column=(type=char(50) updatewhereclause=yes name=diag_medicamentoso dbname=""diagnosticos.diag_medicamentoso"" )
 column=(type=char(50) updatewhereclause=yes name=diag_miasmatico dbname=""diagnosticos.diag_miasmatico"" )
 column=(type=char(50) updatewhereclause=yes name=diag_otro dbname=""diagnosticos.diag_otro"" )
 retrieve=""SELECT diagnosticos.paciente,
       diagnosticos.fecha_visita,
       diagnosticos.diag_nosologico,
       diagnosticos.diag_medicamentoso,
       diagnosticos.diag_miasmatico,
       diagnosticos.diag_otro
  FROM diagnosticos
 WHERE diagnosticos.diag_nosologico like :campo  OR  
       diagnosticos.diag_medicamentoso like :campo  OR  
       diagnosticos.diag_miasmatico like :campo  OR  
       diagnosticos.diag_otro like :campo

            
"" arguments=((""campo"", string)) )
text(band=header alignment=""2"" text=""Fecha Visita"" border=""6"" color=""8388608"" x=""9"" y=""12"" height=""68"" width=""357""  name=fecha_visita_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Paciente"" border=""6"" color=""8388608"" x=""384"" y=""12"" height=""68"" width=""960""  name=paciente_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Diag Nosologico"" border=""6"" color=""8388608"" x=""1362"" y=""12"" height=""68"" width=""960""  name=diag_nosologico_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Diag Medicamentoso"" border=""6"" color=""8388608"" x=""2341"" y=""12"" height=""68"" width=""960""  name=diag_medicamentoso_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Diag Miasmatico"" border=""6"" color=""8388608"" x=""3319"" y=""12"" height=""68"" width=""960""  name=diag_miasmatico_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Diag Otro"" border=""6"" color=""8388608"" x=""4297"" y=""12"" height=""68"" width=""960""  name=diag_otro_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""9"" y=""8"" height=""68"" width=""357"" format=""[general]""  name=fecha_visita edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""384"" y=""8"" height=""68"" width=""960"" format=""[general]""  name=paciente height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1362"" y=""8"" height=""68"" width=""960"" format=""[general]""  name=diag_nosologico height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2341"" y=""8"" height=""68"" width=""960"" format=""[general]""  name=diag_medicamentoso height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3319"" y=""8"" height=""68"" width=""960"" format=""[general]""  name=diag_miasmatico height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=6 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""4297"" y=""8"" height=""68"" width=""960"" format=""[general]""  name=diag_otro height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
