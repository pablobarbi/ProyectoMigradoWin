using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dsto_medicamentos_subrubrica : IDataWindowMetadata
    {
        public string DataObject => "dsto_medicamentos_subrubrica";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "rubrica",
    DbName = "rubricacion_med.rubrica",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "subrubrica",
    DbName = "rubricacion_med.subrubrica",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "medicamento",
    DbName = "rubricacion_med.medicamento",
    Tipo = "char(10)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "valor",
    DbName = "rubricacion_med.valor",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT rubricacion_med.rubrica,
       rubricacion_med.subrubrica,
       rubricacion_med.medicamento,
       rubricacion_med.valor
  FROM rubricacion_med
 WHERE rubricacion_med.rubrica = :rubrica
   AND rubricacion_med.subrubrica = :subrubrica";

        // PB: table.update
        public string Update => @"rubricacion_med";

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
        public string SrdRaw => @"$PBExportHeader$dsto_medicamentos_subrubrica.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=72 color=""81324524"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912"" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=rubrica dbname=""rubricacion_med.rubrica"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=subrubrica dbname=""rubricacion_med.subrubrica"" )
 column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento dbname=""rubricacion_med.medicamento"" )
 column=(type=long update=yes updatewhereclause=yes name=valor dbname=""rubricacion_med.valor"" )
 retrieve=""SELECT rubricacion_med.rubrica,
       rubricacion_med.subrubrica,
       rubricacion_med.medicamento,
       rubricacion_med.valor
  FROM rubricacion_med
 WHERE rubricacion_med.rubrica = :rubrica
   AND rubricacion_med.subrubrica = :subrubrica
"" update=""rubricacion_med"" updatewhere=1 updatekeyinplace=no arguments=((""rubrica"", string),(""subrubrica"", string)) )
column(band=detail id=4 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""695"" y=""4"" height=""76"" width=""329"" format=""[general]""  name=valor edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Valor"" border=""6"" color=""8388608"" x=""695"" y=""4"" height=""64"" width=""329""  name=valor_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""23"" y=""4"" height=""76"" width=""654"" format=""[general]""  name=medicamento edit.limit=10 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Medicamento"" border=""6"" color=""8388608"" x=""23"" y=""4"" height=""64"" width=""654""  name=medicamento_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
