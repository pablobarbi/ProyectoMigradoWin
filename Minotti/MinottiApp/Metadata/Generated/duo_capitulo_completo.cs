using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class duo_capitulo_completo : IDataWindowMetadata
    {
        public string DataObject => "duo_capitulo_completo";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "capitulo",
    DbName = "capitulacion_med.capitulo",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "capitulo_nombre",
    DbName = "capitulos.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "rubrica",
    DbName = "rubricas.rubrica",
    Tipo = "decimal(0)",
    EsIdentity = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "rubrica_nombre",
    DbName = "rubricas.nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica01",
    DbName = "subrubricas.subrubrica01",
    Tipo = "decimal(0)",
    EsIdentity = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica01_nombre",
    DbName = "subrubricas.subrubrica01_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica02",
    DbName = "subrubricas.subrubrica02",
    Tipo = "decimal(0)",
    EsIdentity = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica02_nombre",
    DbName = "subrubricas.subrubrica02_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica03",
    DbName = "subrubricas.subrubrica03",
    Tipo = "decimal(0)",
    EsIdentity = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica03_nombre",
    DbName = "subrubricas.subrubrica03_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica04",
    DbName = "subrubricas.subrubrica04",
    Tipo = "decimal(0)",
    EsIdentity = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica04_nombre",
    DbName = "subrubricas.subrubrica04_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica05",
    DbName = "subrubricas.subrubrica05",
    Tipo = "decimal(0)",
    EsIdentity = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica05_nombre",
    DbName = "subrubricas.subrubrica05_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica06",
    DbName = "subrubricas.subrubrica06",
    Tipo = "decimal(0)",
    EsIdentity = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica06_nombre",
    DbName = "subrubricas.subrubrica06_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica07",
    DbName = "subrubricas.subrubrica07",
    Tipo = "decimal(0)",
    EsIdentity = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica07_nombre",
    DbName = "subrubricas.subrubrica07_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica08",
    DbName = "subrubricas.subrubrica08",
    Tipo = "decimal(0)",
    EsIdentity = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica08_nombre",
    DbName = "subrubricas.subrubrica08_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica09",
    DbName = "subrubricas.subrubrica09",
    Tipo = "decimal(0)",
    EsIdentity = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica09_nombre",
    DbName = "subrubricas.subrubrica09_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica10",
    DbName = "subrubricas.subrubrica10",
    Tipo = "decimal(0)",
    EsIdentity = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica10_nombre",
    DbName = "subrubricas.subrubrica10_nombre",
    Tipo = "char(255)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "medicamento",
    DbName = "capitulacion_med.medicamento",
    Tipo = "char(10)",
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
         capitulos.nombre,
         rubricas.rubrica,
         rubricas.nombre,
         subrubricas.subrubrica AS subrubrica01,
         subrubricas.nombre  AS subrubrica01_nombre,
         subrubricas.subrubrica AS subrubrica02,
         subrubricas.nombre  AS subrubrica02_nombre,
         subrubricas.subrubrica AS subrubrica03,
         subrubricas.nombre  AS subrubrica03_nombre,
         subrubricas.subrubrica AS subrubrica04,
         subrubricas.nombre  AS subrubrica04_nombre,
         subrubricas.subrubrica AS subrubrica05,
         subrubricas.nombre  AS subrubrica05_nombre,
         subrubricas.subrubrica AS subrubrica06,
         subrubricas.nombre  AS subrubrica06_nombre,
         subrubricas.subrubrica AS subrubrica07,
         subrubricas.nombre  AS subrubrica07_nombre,
         subrubricas.subrubrica AS subrubrica08,
         subrubricas.nombre  AS subrubrica08_nombre,
         subrubricas.subrubrica AS subrubrica09,
         subrubricas.nombre  AS subrubrica09_nombre,
         subrubricas.subrubrica AS subrubrica10,
         subrubricas.nombre  AS subrubrica10_nombre,
         capitulacion_med.medicamento,
         capitulacion_med.valor
    FROM capitulacion_med,
         capitulos,
         rubricas,
         subrubricas
   WHERE capitulacion_med.capitulo = capitulos.capitulo
     AND capitulacion_med.rubrica = rubricas.rubrica";

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
        public string SrdRaw => @"$PBExportHeader$duo_capitulo_completo.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=0 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=224 color=""536870912"" )
table(column=(type=decimal(0) updatewhereclause=yes name=capitulo dbname=""capitulacion_med.capitulo"" dbalias="".capitulo"" )
 column=(type=char(255) updatewhereclause=yes name=capitulo_nombre dbname=""capitulos.nombre"" dbalias="".nombre"" )
 column=(type=decimal(0) updatewhereclause=yes identity=yes name=rubrica dbname=""rubricas.rubrica"" dbalias="".rubrica"" )
 column=(type=char(255) updatewhereclause=yes name=rubrica_nombre dbname=""rubricas.nombre"" dbalias="".nombre"" )
 column=(type=decimal(0) updatewhereclause=yes identity=yes name=subrubrica01 dbname=""subrubricas.subrubrica01"" dbalias="".subrubrica01"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica01_nombre dbname=""subrubricas.subrubrica01_nombre"" dbalias="".subrubrica01_nombre"" )
 column=(type=decimal(0) updatewhereclause=yes identity=yes name=subrubrica02 dbname=""subrubricas.subrubrica02"" dbalias="".subrubrica02"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica02_nombre dbname=""subrubricas.subrubrica02_nombre"" dbalias="".subrubrica02_nombre"" )
 column=(type=decimal(0) updatewhereclause=yes identity=yes name=subrubrica03 dbname=""subrubricas.subrubrica03"" dbalias="".subrubrica03"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica03_nombre dbname=""subrubricas.subrubrica03_nombre"" dbalias="".subrubrica03_nombre"" )
 column=(type=decimal(0) updatewhereclause=yes identity=yes name=subrubrica04 dbname=""subrubricas.subrubrica04"" dbalias="".subrubrica04"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica04_nombre dbname=""subrubricas.subrubrica04_nombre"" dbalias="".subrubrica04_nombre"" )
 column=(type=decimal(0) updatewhereclause=yes identity=yes name=subrubrica05 dbname=""subrubricas.subrubrica05"" dbalias="".subrubrica05"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica05_nombre dbname=""subrubricas.subrubrica05_nombre"" dbalias="".subrubrica05_nombre"" )
 column=(type=decimal(0) updatewhereclause=yes identity=yes name=subrubrica06 dbname=""subrubricas.subrubrica06"" dbalias="".subrubrica06"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica06_nombre dbname=""subrubricas.subrubrica06_nombre"" dbalias="".subrubrica06_nombre"" )
 column=(type=decimal(0) updatewhereclause=yes identity=yes name=subrubrica07 dbname=""subrubricas.subrubrica07"" dbalias="".subrubrica07"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica07_nombre dbname=""subrubricas.subrubrica07_nombre"" dbalias="".subrubrica07_nombre"" )
 column=(type=decimal(0) updatewhereclause=yes identity=yes name=subrubrica08 dbname=""subrubricas.subrubrica08"" dbalias="".subrubrica08"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica08_nombre dbname=""subrubricas.subrubrica08_nombre"" dbalias="".subrubrica08_nombre"" )
 column=(type=decimal(0) updatewhereclause=yes identity=yes name=subrubrica09 dbname=""subrubricas.subrubrica09"" dbalias="".subrubrica09"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica09_nombre dbname=""subrubricas.subrubrica09_nombre"" dbalias="".subrubrica09_nombre"" )
 column=(type=decimal(0) updatewhereclause=yes identity=yes name=subrubrica10 dbname=""subrubricas.subrubrica10"" dbalias="".subrubrica10"" )
 column=(type=char(255) updatewhereclause=yes name=subrubrica10_nombre dbname=""subrubricas.subrubrica10_nombre"" dbalias="".subrubrica10_nombre"" )
 column=(type=char(10) updatewhereclause=yes name=medicamento dbname=""capitulacion_med.medicamento"" dbalias="".medicamento"" )
 column=(type=long updatewhereclause=yes name=valor dbname=""capitulacion_med.valor"" dbalias="".valor"" )
 retrieve=""  SELECT capitulacion_med.capitulo,
         capitulos.nombre,
         rubricas.rubrica,
         rubricas.nombre,
         subrubricas.subrubrica AS subrubrica01,
         subrubricas.nombre  AS subrubrica01_nombre,
         subrubricas.subrubrica AS subrubrica02,
         subrubricas.nombre  AS subrubrica02_nombre,
         subrubricas.subrubrica AS subrubrica03,
         subrubricas.nombre  AS subrubrica03_nombre,
         subrubricas.subrubrica AS subrubrica04,
         subrubricas.nombre  AS subrubrica04_nombre,
         subrubricas.subrubrica AS subrubrica05,
         subrubricas.nombre  AS subrubrica05_nombre,
         subrubricas.subrubrica AS subrubrica06,
         subrubricas.nombre  AS subrubrica06_nombre,
         subrubricas.subrubrica AS subrubrica07,
         subrubricas.nombre  AS subrubrica07_nombre,
         subrubricas.subrubrica AS subrubrica08,
         subrubricas.nombre  AS subrubrica08_nombre,
         subrubricas.subrubrica AS subrubrica09,
         subrubricas.nombre  AS subrubrica09_nombre,
         subrubricas.subrubrica AS subrubrica10,
         subrubricas.nombre  AS subrubrica10_nombre,
         capitulacion_med.medicamento,
         capitulacion_med.valor
    FROM capitulacion_med,
         capitulos,
         rubricas,
         subrubricas
   WHERE capitulacion_med.capitulo = capitulos.capitulo
     AND capitulacion_med.rubrica = rubricas.rubrica
"" )
column(band=detail id=3 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""18"" y=""120"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=rubrica visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""379"" y=""120"" height=""76"" width=""786"" format=""[general]"" html.valueishtml=""0""  name=rubrica_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""18"" y=""20"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=capitulo visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""379"" y=""20"" height=""76"" width=""786"" format=""[general]"" html.valueishtml=""0""  name=capitulo_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""1198"" y=""20"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica01 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=6 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1559"" y=""20"" height=""76"" width=""786"" format=""[general]"" html.valueishtml=""0""  name=subrubrica01_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=7 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""1207"" y=""120"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica02 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=8 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1568"" y=""120"" height=""76"" width=""786"" format=""[general]"" html.valueishtml=""0""  name=subrubrica02_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=9 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""2386"" y=""24"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica03 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=11 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""2391"" y=""120"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica04 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=17 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""4850"" y=""24"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica07 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=19 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""4855"" y=""132"" height=""76"" width=""325"" format=""[general]"" html.valueishtml=""0""  name=subrubrica08 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=10 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2761"" y=""16"" height=""76"" width=""786"" format=""[general]"" html.valueishtml=""0""  name=subrubrica03_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=12 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2752"" y=""120"" height=""76"" width=""786"" format=""[general]"" html.valueishtml=""0""  name=subrubrica04_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=25 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""7237"" y=""24"" height=""76"" width=""370"" format=""[general]"" html.valueishtml=""0""  name=medicamento visible=""1"" edit.limit=10 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=26 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""7237"" y=""136"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=valor visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=21 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""6057"" y=""28"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica09 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=23 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""6075"" y=""128"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica10 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=22 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""6423"" y=""28"" height=""76"" width=""786"" format=""[general]"" html.valueishtml=""0""  name=subrubrica09_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=24 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""6432"" y=""132"" height=""76"" width=""786"" format=""[general]"" html.valueishtml=""0""  name=subrubrica10_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=18 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""5230"" y=""20"" height=""76"" width=""786"" format=""[general]"" html.valueishtml=""0""  name=subrubrica07_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=20 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""5243"" y=""120"" height=""76"" width=""782"" format=""[general]"" html.valueishtml=""0""  name=subrubrica08_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=13 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""3643"" y=""20"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica05 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=15 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""3653"" y=""124"" height=""76"" width=""329"" format=""[general]"" html.valueishtml=""0""  name=subrubrica06 visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=14 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3995"" y=""24"" height=""76"" width=""786"" format=""[general]"" html.valueishtml=""0""  name=subrubrica05_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=16 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""4009"" y=""128"" height=""76"" width=""786"" format=""[general]"" html.valueishtml=""0""  name=subrubrica06_nombre visible=""1"" edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" encodeselflinkargs=""1"" netscapelayers=""0"" pagingmethod=0 generatedddwframes=""1"" )
xhtmlgen() cssgen(sessionspecific=""0"" )
xmlgen(inline=""0"" )
xsltgen()
jsgen()
export.xml(headgroups=""1"" includewhitespace=""0"" metadatatype=0 savemetadata=0 )
import.xml()
export.pdf(method=0 distill.custompostscript=""0"" xslfop.print=""0"" )
export.xhtml()
 ";
    }
}
