using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_global_rubricas : IDataWindowMetadata
    {
        public string DataObject => "dr_global_rubricas";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "capitulo",
    DbName = "capitulos.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 0,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "rubricas.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT capitulos.nombre,
       rubricas.nombre
  FROM rubricas, capitulaciones, capitulos
 WHERE rubricas.nombre like :campo   
   AND rubricas.rubrica = capitulaciones.rubrica
   AND capitulos.capitulo = capitulaciones.capitulo";

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
        public string SrdRaw => @"$PBExportHeader$dr_global_rubricas.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=88 color=""81324524"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912""  height.autosize=yes)
table(column=(type=char(255) updatewhereclause=yes name=capitulo dbname=""capitulos.nombre"" )
 column=(type=char(255) update=yes updatewhereclause=yes name=nombre dbname=""rubricas.nombre"" )
 retrieve=""SELECT capitulos.nombre,
       rubricas.nombre
  FROM rubricas, capitulaciones, capitulos
 WHERE rubricas.nombre like :campo   
   AND rubricas.rubrica = capitulaciones.rubrica
   AND capitulos.capitulo = capitulaciones.capitulo
"" arguments=((""campo"", string)) )
text(band=header alignment=""2"" text=""Rúbrica"" border=""6"" color=""8388608"" x=""1815"" y=""12"" height=""64"" width=""1774""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Capítulo"" border=""6"" color=""8388608"" x=""23"" y=""12"" height=""64"" width=""1774""  name=capitulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1815"" y=""8"" height=""68"" width=""1774"" format=""[general]""  name=nombre height.autosize=yes edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=0 border=""0"" color=""0"" x=""23"" y=""8"" height=""68"" width=""1774""  name=capitulo height.autosize=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
