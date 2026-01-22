using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dw_medicamentos : IDataWindowMetadata
    {
        public string DataObject => "dw_medicamentos";

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
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT medicamentos.medicamento
  FROM medicamentos
 ORDER BY medicamentos.medicamento";

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
        public string SrdRaw => @"$PBExportHeader$dw_medicamentos.srd
release 7;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=72 color=""536870912"" )
table(column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento dbname=""medicamentos.medicamento"" )
 retrieve=""SELECT medicamentos.medicamento
  FROM medicamentos
 ORDER BY medicamentos.medicamento
"" update=""medicamentos"" updatewhere=1 updatekeyinplace=no )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""6"" color=""0"" x=""18"" y=""8"" height=""60"" width=""503"" format=""[general]""  name=medicamento edit.limit=10 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
