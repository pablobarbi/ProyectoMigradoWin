using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_global_medicamentos : IDataWindowMetadata
    {
        public string DataObject => "dr_global_medicamentos";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "medicamento",
    DbName = "medicamentos.medicamento",
    Tipo = "char(10)",
    EsClave = true,
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
    Nombre = "observaciones",
    DbName = "medicamentos.observaciones",
    Tipo = "char(32766)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT medicamentos.medicamento,
       medicamentos.descripcion,
       medicamentos.observaciones
  FROM medicamentos
 WHERE medicamentos.descripcion like :campo  OR  
       medicamentos.observaciones like :campo";

        // PB: table.update
        public string Update => @"medicamentos";

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
        public string SrdRaw => @"$PBExportHeader$dr_global_medicamentos.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=72 color=""81324524"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912""  height.autosize=yes)
table(column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento dbname=""medicamentos.medicamento"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=descripcion dbname=""medicamentos.descripcion"" )
 column=(type=char(32766) update=yes updatewhereclause=yes name=observaciones dbname=""medicamentos.observaciones"" )
 retrieve=""SELECT medicamentos.medicamento,
       medicamentos.descripcion,
       medicamentos.observaciones
  FROM medicamentos
 WHERE medicamentos.descripcion like :campo  OR  
       medicamentos.observaciones like :campo    
"" update=""medicamentos"" updatewhere=1 updatekeyinplace=no arguments=((""campo"", string)) )
text(band=header alignment=""2"" text=""Descripcion"" border=""6"" color=""8388608"" x=""425"" y=""4"" height=""64"" width=""1399""  name=descripcion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Observaciones"" border=""6"" color=""8388608"" x=""1842"" y=""4"" height=""64"" width=""1399""  name=observaciones_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Medicamento"" border=""6"" color=""8388608"" x=""9"" y=""4"" height=""64"" width=""398""  name=medicamento_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""9"" y=""8"" height=""68"" width=""398"" format=""[general]""  name=medicamento edit.limit=10 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1842"" y=""8"" height=""68"" width=""1399"" format=""[general]""  name=observaciones height.autosize=yes edit.limit=32000 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""425"" y=""8"" height=""68"" width=""1399"" format=""[general]""  name=descripcion height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
