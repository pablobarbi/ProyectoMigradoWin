using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dsto_reperto_temporal : IDataWindowMetadata
    {
        public string DataObject => "dsto_reperto_temporal";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "reperto_parcial",
    DbName = "reperto_parcial.reperto_parcial",
    Tipo = "decimal(0)",
    EsClave = true,
    EsIdentity = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "capitulo",
    DbName = "reperto_parcial.capitulo",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "rubrica",
    DbName = "reperto_parcial.rubrica",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica",
    DbName = "reperto_parcial.subrubrica",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica2",
    DbName = "reperto_parcial.subrubrica2",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica3",
    DbName = "reperto_parcial.subrubrica3",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica4",
    DbName = "reperto_parcial.subrubrica4",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica5",
    DbName = "reperto_parcial.subrubrica5",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica6",
    DbName = "reperto_parcial.subrubrica6",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica7",
    DbName = "reperto_parcial.subrubrica7",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica8",
    DbName = "reperto_parcial.subrubrica8",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica9",
    DbName = "reperto_parcial.subrubrica9",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "subrubrica10",
    DbName = "reperto_parcial.subrubrica10",
    Tipo = "decimal(0)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT reperto_parcial, capitulo, rubrica, subrubrica, subrubrica2, subrubrica3, subrubrica4, subrubrica5, subrubrica6, subrubrica7, subrubrica8, subrubrica9, subrubrica10
	FROM reperto_parcial";

        // PB: table.update
        public string Update => @"reperto_parcial";

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
        public string SrdRaw => @"$PBExportHeader$dsto_reperto_temporal.srd
release 10.5;
datawindow(units=0 timer_interval=0 color=1073741824 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=136 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=96 color=""536870912"" )
table(column=(type=decimal(0) updatewhereclause=yes key=yes identity=yes name=reperto_parcial dbname=""reperto_parcial.reperto_parcial"" dbalias="".reperto_parcial"" )
 column=(type=decimal(0) updatewhereclause=yes name=capitulo dbname=""reperto_parcial.capitulo"" dbalias="".capitulo"" )
 column=(type=decimal(0) updatewhereclause=yes name=rubrica dbname=""reperto_parcial.rubrica"" dbalias="".rubrica"" )
 column=(type=decimal(0) updatewhereclause=yes name=subrubrica dbname=""reperto_parcial.subrubrica"" dbalias="".subrubrica"" )
 column=(type=decimal(0) updatewhereclause=yes name=subrubrica2 dbname=""reperto_parcial.subrubrica2"" dbalias="".subrubrica2"" )
 column=(type=decimal(0) updatewhereclause=yes name=subrubrica3 dbname=""reperto_parcial.subrubrica3"" dbalias="".subrubrica3"" )
 column=(type=decimal(0) updatewhereclause=yes name=subrubrica4 dbname=""reperto_parcial.subrubrica4"" dbalias="".subrubrica4"" )
 column=(type=decimal(0) updatewhereclause=yes name=subrubrica5 dbname=""reperto_parcial.subrubrica5"" dbalias="".subrubrica5"" )
 column=(type=decimal(0) updatewhereclause=yes name=subrubrica6 dbname=""reperto_parcial.subrubrica6"" dbalias="".subrubrica6"" )
 column=(type=decimal(0) updatewhereclause=yes name=subrubrica7 dbname=""reperto_parcial.subrubrica7"" dbalias="".subrubrica7"" )
 column=(type=decimal(0) updatewhereclause=yes name=subrubrica8 dbname=""reperto_parcial.subrubrica8"" dbalias="".subrubrica8"" )
 column=(type=decimal(0) updatewhereclause=yes name=subrubrica9 dbname=""reperto_parcial.subrubrica9"" dbalias="".subrubrica9"" )
 column=(type=decimal(0) updatewhereclause=yes name=subrubrica10 dbname=""reperto_parcial.subrubrica10"" dbalias="".subrubrica10"" )
 retrieve=""   SELECT reperto_parcial, capitulo, rubrica, subrubrica, subrubrica2, subrubrica3, subrubrica4, subrubrica5, subrubrica6, subrubrica7, subrubrica8, subrubrica9, subrubrica10
	FROM reperto_parcial
"" update=""reperto_parcial"" updatewhere=0 updatekeyinplace=no )
text(band=header alignment=""2"" text=""Tmp Reperto
Reperto Sintoma Nuevo"" border=""0"" color=""33554432"" x=""5"" y=""4"" height=""128"" width=""622"" html.valueishtml=""0""  name=tmp_reperto_reperto_sintoma_nuevo_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Reperto Total Sin
Capitulo"" border=""0"" color=""33554432"" x=""631"" y=""4"" height=""128"" width=""457"" html.valueishtml=""0""  name=reperto_total_sin_capitulo_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Reperto Total Sin
Rubrica"" border=""0"" color=""33554432"" x=""1093"" y=""4"" height=""128"" width=""457"" html.valueishtml=""0""  name=reperto_total_sin_rubrica_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Reperto Total Sin
Subrubrica"" border=""0"" color=""33554432"" x=""1554"" y=""4"" height=""128"" width=""457"" html.valueishtml=""0""  name=reperto_total_sin_subrubrica_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Reperto Total Sin
Subrubrica2"" border=""0"" color=""33554432"" x=""2016"" y=""4"" height=""128"" width=""457"" html.valueishtml=""0""  name=reperto_total_sin_subrubrica2_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Reperto Total Sin
Subrubrica3"" border=""0"" color=""33554432"" x=""2482"" y=""4"" height=""128"" width=""453"" html.valueishtml=""0""  name=reperto_total_sin_subrubrica3_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Reperto Total Sin
Subrubrica4"" border=""0"" color=""33554432"" x=""2944"" y=""4"" height=""128"" width=""457"" html.valueishtml=""0""  name=reperto_total_sin_subrubrica4_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Reperto Total Sin
Subrubrica5"" border=""0"" color=""33554432"" x=""3406"" y=""4"" height=""128"" width=""457"" html.valueishtml=""0""  name=reperto_total_sin_subrubrica5_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Reperto Total Sin
Subrubrica6"" border=""0"" color=""33554432"" x=""3867"" y=""4"" height=""128"" width=""457"" html.valueishtml=""0""  name=reperto_total_sin_subrubrica6_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Reperto Total Sin
Subrubrica7"" border=""0"" color=""33554432"" x=""4329"" y=""4"" height=""128"" width=""457"" html.valueishtml=""0""  name=reperto_total_sin_subrubrica7_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Reperto Total Sin
Subrubrica8"" border=""0"" color=""33554432"" x=""4791"" y=""4"" height=""128"" width=""457"" html.valueishtml=""0""  name=reperto_total_sin_subrubrica8_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Reperto Total Sin
Subrubrica9"" border=""0"" color=""33554432"" x=""5253"" y=""4"" height=""128"" width=""457"" html.valueishtml=""0""  name=reperto_total_sin_subrubrica9_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Reperto Total Sin
Subrubrica10"" border=""0"" color=""33554432"" x=""5714"" y=""4"" height=""128"" width=""457"" html.valueishtml=""0""  name=reperto_total_sin_subrubrica10_t visible=""1""  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""23"" y=""8"" height=""76"" width=""526"" format=""[general]"" html.valueishtml=""0""  name=reperto_parcial visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Tahoma"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""571"" y=""8"" height=""76"" width=""526"" format=""[general]"" html.valueishtml=""0""  name=capitulo visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Tahoma"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1120"" y=""12"" height=""76"" width=""526"" format=""[general]"" html.valueishtml=""0""  name=rubrica visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Tahoma"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1669"" y=""12"" height=""76"" width=""526"" format=""[general]"" html.valueishtml=""0""  name=subrubrica visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Tahoma"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2217"" y=""12"" height=""76"" width=""526"" format=""[general]"" html.valueishtml=""0""  name=subrubrica2 visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Tahoma"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=6 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2766"" y=""12"" height=""76"" width=""526"" format=""[general]"" html.valueishtml=""0""  name=subrubrica3 visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Tahoma"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=7 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3319"" y=""12"" height=""76"" width=""526"" format=""[general]"" html.valueishtml=""0""  name=subrubrica4 visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Tahoma"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=8 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3867"" y=""12"" height=""76"" width=""526"" format=""[general]"" html.valueishtml=""0""  name=subrubrica5 visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Tahoma"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=9 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""4416"" y=""12"" height=""76"" width=""526"" format=""[general]"" html.valueishtml=""0""  name=subrubrica6 visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Tahoma"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=10 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""4965"" y=""12"" height=""76"" width=""526"" format=""[general]"" html.valueishtml=""0""  name=subrubrica7 visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Tahoma"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=11 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""5513"" y=""12"" height=""76"" width=""526"" format=""[general]"" html.valueishtml=""0""  name=subrubrica8 visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Tahoma"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=12 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""6062"" y=""12"" height=""76"" width=""526"" format=""[general]"" html.valueishtml=""0""  name=subrubrica9 visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Tahoma"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=13 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""6610"" y=""12"" height=""76"" width=""526"" format=""[general]"" html.valueishtml=""0""  name=subrubrica10 visible=""1"" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face=""Tahoma"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" encodeselflinkargs=""1"" netscapelayers=""0"" pagingmethod=0 generatedddwframes=""1"" )
xhtmlgen() cssgen(sessionspecific=""0"" )
xmlgen(inline=""0"" )
xsltgen()
jsgen()
export.xml(headgroups=""1"" includewhitespace=""0"" metadatatype=0 savemetadata=0  template=(comment="""" encoding=""UTF-16LE"" name=""dsto_reperto_temporal"" xml=""<?xml version=~""1.0~"" encoding=~""UTF-16LE~"" standalone=~""no~""?><untitled><untitled_row __pbband=~""detail~""><tmp_reperto_reperto_sintoma_nuevo/><reperto_total_sin_capitulo>capitulo</reperto_total_sin_capitulo><reperto_total_sin_rubrica>rubrica</reperto_total_sin_rubrica><reperto_total_sin_subrubrica>subrubrica</reperto_total_sin_subrubrica><reperto_total_sin_subrubrica2>subrubrica2</reperto_total_sin_subrubrica2><reperto_total_sin_subrubrica3>subrubrica3</reperto_total_sin_subrubrica3><reperto_total_sin_subrubrica4>subrubrica4</reperto_total_sin_subrubrica4><reperto_total_sin_subrubrica5>subrubrica5</reperto_total_sin_subrubrica5><reperto_total_sin_subrubrica6>subrubrica6</reperto_total_sin_subrubrica6><reperto_total_sin_subrubrica7>subrubrica7</reperto_total_sin_subrubrica7><reperto_total_sin_subrubrica8>subrubrica8</reperto_total_sin_subrubrica8><reperto_total_sin_subrubrica9>subrubrica9</reperto_total_sin_subrubrica9><reperto_total_sin_subrubrica10>subrubrica10</reperto_total_sin_subrubrica10></untitled_row></untitled>""))
import.xml()
export.pdf(method=0 distill.custompostscript=""0"" xslfop.print=""0"" )
export.xhtml()
 ";
    }
}
