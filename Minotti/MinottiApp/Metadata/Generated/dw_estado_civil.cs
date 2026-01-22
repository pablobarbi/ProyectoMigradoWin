using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dw_estado_civil : IDataWindowMetadata
    {
        public string DataObject => "dw_estado_civil";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "estado_civil",
    DbName = "mdp_estado_civil.estado_civil",
    Tipo = "decimal(0)",
    EsClave = true,
    EsIdentity = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "descripcion",
    DbName = "mdp_estado_civil.descripcion",
    Tipo = "char(40)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT mdp_estado_civil.estado_civil,
       mdp_estado_civil.descripcion
  FROM mdp_estado_civil";

        // PB: table.update
        public string Update => @"mdp_estado_civil";

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
        public string SrdRaw => @"$PBExportHeader$dw_estado_civil.srd
release 7;
datawindow(units=0 timer_interval=0 color=80269524 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=80 color=""536870912"" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes identity=yes name=estado_civil dbname=""mdp_estado_civil.estado_civil"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=descripcion dbname=""mdp_estado_civil.descripcion"" )
 retrieve=""SELECT mdp_estado_civil.estado_civil,
       mdp_estado_civil.descripcion
  FROM mdp_estado_civil
"" update=""mdp_estado_civil"" updatewhere=1 updatekeyinplace=no )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""6"" color=""0"" x=""14"" y=""4"" height=""68"" width=""599"" format=""[general]""  name=descripcion edit.limit=40 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
