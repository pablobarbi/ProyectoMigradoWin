using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_rubricas_del_capitulo : IDataWindowMetadata
    {
        public string DataObject => "dk_rubricas_del_capitulo";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "capitulaciones_capitulo",
    DbName = "capitulaciones.capitulo",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "capitulaciones_rubrica",
    DbName = "capitulaciones.rubrica",
    Tipo = "decimal(0)",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "rubricas_nombre",
    DbName = "rubricas.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT capitulaciones.capitulo,
       capitulaciones.rubrica,
       rubricas.nombre
  FROM capitulaciones,
       rubricas
 WHERE capitulaciones.rubrica = rubricas.rubrica
   AND capitulaciones.capitulo = :capitulo    
 ORDER BY rubricas.nombre";

        // PB: table.update
        public string Update => @"capitulaciones";

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
        public string SrdRaw => @"$PBExportHeader$dk_rubricas_del_capitulo.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=92 color=""82899184"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=92 color=""536870912""  height.autosize=yes)
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=capitulaciones_capitulo dbname=""capitulaciones.capitulo"" )
 column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=capitulaciones_rubrica dbname=""capitulaciones.rubrica"" )
 column=(type=char(255) updatewhereclause=yes name=rubricas_nombre dbname=""rubricas.nombre"" )
 retrieve=""SELECT capitulaciones.capitulo,
       capitulaciones.rubrica,
       rubricas.nombre
  FROM capitulaciones,
       rubricas
 WHERE capitulaciones.rubrica = rubricas.rubrica
   AND capitulaciones.capitulo = :capitulo    
 ORDER BY rubricas.nombre
"" update=""capitulaciones"" updatewhere=0 updatekeyinplace=no arguments=((""capitulo"", string)) )
text(band=header alignment=""2"" text=""Rubricas"" border=""6"" color=""8388608"" x=""14"" y=""16"" height=""68"" width=""2770""  name=rubricas_nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""14"" y=""8"" height=""76"" width=""2770"" format=""[general]""  name=rubricas_nombre height.autosize=yes editmask.mask=""!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
