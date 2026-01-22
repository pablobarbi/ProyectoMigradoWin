using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_global_subrubricas : IDataWindowMetadata
    {
        public string DataObject => "dr_global_subrubricas";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "capitulo",
    DbName = "capitulos.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "rubrica",
    DbName = "rubricas.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica",
    DbName = "subrubricas.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT capitulos.nombre,
       rubricas.nombre,
       subrubricas.nombre
  FROM subrubricas, subrubricaciones, rubricaciones, rubricas, capitulaciones, capitulos

 WHERE subrubricas.nombre like :campo   

   AND rubricas.rubrica = capitulaciones.rubrica
   AND capitulos.capitulo = capitulaciones.capitulo

   AND rubricaciones.rubrica = rubricas.rubrica
   AND rubricaciones.subrubrica = subrubricaciones.subrubrica_padre

   AND ( (subrubricaciones.subrubrica_padre = subrubricas.subrubrica) OR (subrubricaciones.subrubrica_hija = subrubricas.subrubrica) )";

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
        public string SrdRaw => @"$PBExportHeader$dr_global_subrubricas.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=92 color=""81324524"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912""  height.autosize=yes)
table(column=(type=char(255) updatewhereclause=yes name=capitulo dbname=""capitulos.nombre"" )
 column=(type=char(255) updatewhereclause=yes name=rubrica dbname=""rubricas.nombre"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica dbname=""subrubricas.nombre"" )
 retrieve=""SELECT capitulos.nombre,
       rubricas.nombre,
       subrubricas.nombre
  FROM subrubricas, subrubricaciones, rubricaciones, rubricas, capitulaciones, capitulos

 WHERE subrubricas.nombre like :campo   

   AND rubricas.rubrica = capitulaciones.rubrica
   AND capitulos.capitulo = capitulaciones.capitulo

   AND rubricaciones.rubrica = rubricas.rubrica
   AND rubricaciones.subrubrica = subrubricaciones.subrubrica_padre

   AND ( (subrubricaciones.subrubrica_padre = subrubricas.subrubrica) OR (subrubricaciones.subrubrica_hija = subrubricas.subrubrica) )
"" arguments=((""campo"", string)) )
text(band=header alignment=""2"" text=""Capitulo"" border=""6"" color=""8388608"" x=""18"" y=""16"" height=""64"" width=""1102""  name=capitulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Rubrica"" border=""6"" color=""8388608"" x=""1138"" y=""16"" height=""64"" width=""1102""  name=rubrica_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""14"" y=""8"" height=""64"" width=""1102"" format=""[general]""  name=capitulo height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=header alignment=""2"" text=""Subrubrica"" border=""6"" color=""8388608"" x=""2258"" y=""16"" height=""64"" width=""1193""  name=subrubrica_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1134"" y=""8"" height=""64"" width=""1102"" format=""[general]""  name=rubrica height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2341"" y=""8"" height=""68"" width=""1102"" format=""[general]""  name=subrubrica height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""0"" text=""..."" border=""0"" color=""0"" x=""2254"" y=""8"" height=""68"" width=""69""  name=t_1  font.face=""Arial"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
