using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class duo_capitulaciones_med : IDataWindowMetadata
    {
        public string DataObject => "duo_capitulaciones_med";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "capitulo",
    DbName = "capitulacion_med.capitulo",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "rubrica",
    DbName = "capitulacion_med.rubrica",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "medicamento",
    DbName = "capitulacion_med.medicamento",
    Tipo = "char(10)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "valor",
    DbName = "capitulacion_med.valor",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT capitulacion_med.capitulo,
       capitulacion_med.rubrica,
       capitulacion_med.medicamento,
       capitulacion_med.valor
  FROM capitulacion_med
 WHERE capitulacion_med.capitulo = :capitulo
   AND capitulacion_med.rubrica = :rubrica";

        // PB: table.update
        public string Update => @"capitulacion_med";

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
        public string SrdRaw => @"$PBExportHeader$duo_capitulaciones_med.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912"" )
table(column=(type=decimal(0) updatewhereclause=yes key=yes name=capitulo dbname=""capitulacion_med.capitulo"" )
 column=(type=decimal(0) updatewhereclause=yes key=yes name=rubrica dbname=""capitulacion_med.rubrica"" )
 column=(type=char(10) updatewhereclause=yes key=yes name=medicamento dbname=""capitulacion_med.medicamento"" )
 column=(type=long updatewhereclause=yes name=valor dbname=""capitulacion_med.valor"" )
 retrieve=""SELECT capitulacion_med.capitulo,
       capitulacion_med.rubrica,
       capitulacion_med.medicamento,
       capitulacion_med.valor
  FROM capitulacion_med
 WHERE capitulacion_med.capitulo = :capitulo
   AND capitulacion_med.rubrica = :rubrica
"" update=""capitulacion_med"" updatewhere=0 updatekeyinplace=no arguments=((""capitulo"", string),(""rubrica"", string)) )
column(band=detail id=1 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""5"" y=""8"" height=""68"" width=""329"" format=""[general]""  name=capitulo edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""375"" y=""8"" height=""68"" width=""329"" format=""[general]""  name=rubrica edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""745"" y=""8"" height=""68"" width=""407"" format=""[general]""  name=medicamento edit.limit=10 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""1193"" y=""8"" height=""68"" width=""329"" format=""[general]""  name=valor edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
