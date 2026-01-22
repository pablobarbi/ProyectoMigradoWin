using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dl_pacientes_historia_clinica : IDataWindowMetadata
    {
        public string DataObject => "dl_pacientes_historia_clinica";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "paciente",
    DbName = "pacientes_historias.paciente",
    Tipo = "long",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "hist_clin",
    DbName = "pacientes_historias.hist_clin",
    Tipo = "char(32766)",
    EsRequerido = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT pacientes_historias.paciente,
       pacientes_historias.hist_clin
  FROM pacientes_historias
 WHERE pacientes_historias.paciente = :paciente";

        // PB: table.update
        public string Update => @"pacientes_historias";

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
        public string SrdRaw => @"$PBExportHeader$dl_pacientes_historia_clinica.srd
release 7;
datawindow(units=3 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 2 print.margin.left = 2000 print.margin.right = 1000 print.margin.top = 2000 print.margin.bottom = 1000 print.paper.source = 0 print.paper.size = 9 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=2487 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=12356 color=""536870912""  height.autosize=yes)
table(column=(type=long update=yes updatewhereclause=yes key=yes name=paciente dbname=""pacientes_historias.paciente"" )
 column=(type=char(32766) update=yes updatewhereclause=no name=hist_clin dbname=""pacientes_historias.hist_clin"" )
 retrieve=""SELECT pacientes_historias.paciente,
       pacientes_historias.hist_clin
  FROM pacientes_historias
 WHERE pacientes_historias.paciente = :paciente
"" update=""pacientes_historias"" updatewhere=1 updatekeyinplace=no arguments=((""paciente"", string)) )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1905"" y=""159"" height=""502"" width=""15742"" format=""[general]""  name=paciente dddw.name=dw_pacientes dddw.displaycolumn=nombre dddw.datacolumn=paciente dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
report(band=header dataobject=""r_header"" x=""132"" y=""158"" height=""1561"" width=""17488"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  name=dw_1  slideup=directlyabove )
text(band=detail alignment=""1"" text=""Paciente:"" border=""0"" color=""0"" x=""211"" y=""159"" height=""423"" width=""1587""  name=paciente_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Historias Clínicas"" border=""0"" color=""0"" x=""132"" y=""1878"" height=""529"" width=""17488""  name=t_1  font.face=""Arial"" font.height=""-12"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""2"" text=""Detalle"" border=""0"" color=""0"" x=""185"" y=""927"" height=""423"" width=""17488""  name=hist_clin_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""2"" color=""0"" x=""185"" y=""1535"" height=""10054"" width=""17488"" format=""[general]""  name=hist_clin edit.limit=32000 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.required=yes edit.autovscroll=yes edit.vscrollbar=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
