using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class duo_subrubricaciones : IDataWindowMetadata
    {
        public string DataObject => "duo_subrubricaciones";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "subrubrica_padre",
    DbName = "subrubricaciones.subrubrica_padre",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica_hija",
    DbName = "subrubricaciones.subrubrica_hija",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "posicion",
    DbName = "subrubricaciones.posicion",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 0,
},

            new DataWindowColumn
{
    Nombre = "subrubrica_nombre",
    DbName = "subrubricas.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT subrubricaciones.subrubrica_padre,
       subrubricaciones.subrubrica_hija,
       subrubricaciones.posicion,
       subrubricas.nombre
  FROM subrubricaciones,
       subrubricas
 WHERE subrubricaciones.subrubrica_hija = subrubricas.subrubrica
   AND subrubricaciones.subrubrica_padre = :subrubrica
 ORDER by subrubricaciones.posicion";

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
        public string SrdRaw => @"$PBExportHeader$duo_subrubricaciones.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=4 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912"" )
table(column=(type=decimal(0) updatewhereclause=yes name=subrubrica_padre dbname=""subrubricaciones.subrubrica_padre"" )
 column=(type=decimal(0) updatewhereclause=yes name=subrubrica_hija dbname=""subrubricaciones.subrubrica_hija"" )
 column=(type=long updatewhereclause=yes name=posicion dbname=""subrubricaciones.posicion"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica_nombre dbname=""subrubricas.nombre"" )
 retrieve=""SELECT subrubricaciones.subrubrica_padre,
       subrubricaciones.subrubrica_hija,
       subrubricaciones.posicion,
       subrubricas.nombre
  FROM subrubricaciones,
       subrubricas
 WHERE subrubricaciones.subrubrica_hija = subrubricas.subrubrica
   AND subrubricaciones.subrubrica_padre = :subrubrica
 ORDER by subrubricaciones.posicion
"" arguments=((""subrubrica"", string)) )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1266"" y=""8"" height=""68"" width=""576"" format=""[general]""  name=subrubrica_nombre edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""59"" y=""8"" height=""64"" width=""576"" format=""[general]""  name=subrubrica_padre edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""658"" y=""8"" height=""64"" width=""576"" format=""[general]""  name=subrubrica_hija edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=0 border=""0"" color=""0"" x=""1870"" y=""8"" height=""64"" width=""754"" format=""[General]""  name=posicion  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
