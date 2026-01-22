using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_pacientes_hist_clinica : IDataWindowMetadata
    {
        public string DataObject => "d_pacientes_hist_clinica";

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
    TabOrder = 10,
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
        public string SrdRaw => @"$PBExportHeader$d_pacientes_hist_clinica.srd
release 7;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=1144 color=""536870912"" )
table(column=(type=long update=yes updatewhereclause=yes key=yes name=paciente dbname=""pacientes_historias.paciente"" )
 column=(type=char(32766) update=yes updatewhereclause=no name=hist_clin dbname=""pacientes_historias.hist_clin"" )
 retrieve=""SELECT pacientes_historias.paciente,
       pacientes_historias.hist_clin
  FROM pacientes_historias
 WHERE pacientes_historias.paciente = :paciente
"" update=""pacientes_historias"" updatewhere=1 updatekeyinplace=no arguments=((""paciente"", string)) )
text(band=detail alignment=""1"" text=""Paciente:"" border=""0"" color=""8388608"" x=""37"" y=""24"" height=""64"" width=""274""  name=paciente_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""329"" y=""24"" height=""76"" width=""1979"" format=""[general]""  name=paciente dddw.name=dw_pacientes dddw.displaycolumn=nombre dddw.datacolumn=paciente dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""2"" text=""Historia Clinica"" border=""0"" color=""8388608"" x=""32"" y=""140"" height=""64"" width=""2277""  name=hist_clin_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=10 border=""5"" color=""0"" x=""32"" y=""232"" height=""872"" width=""2277"" format=""[general]""  name=hist_clin edit.limit=32000 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.required=yes edit.autohscroll=yes edit.autovscroll=yes edit.hscrollbar=yes edit.vscrollbar=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
