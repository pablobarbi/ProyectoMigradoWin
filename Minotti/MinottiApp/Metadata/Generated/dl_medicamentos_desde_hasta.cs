using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dl_medicamentos_desde_hasta : IDataWindowMetadata
    {
        public string DataObject => "dl_medicamentos_desde_hasta";

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
},

            new DataWindowColumn
{
    Nombre = "descripcion",
    DbName = "medicamentos.descripcion",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT medicamentos.medicamento,
       medicamentos.descripcion
  FROM medicamentos
 WHERE medicamentos.medicamento >= :desde
   AND medicamentos.medicamento <= :hasta";

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
        public string SrdRaw => @"$PBExportHeader$dl_medicamentos_desde_hasta.srd
release 7;
datawindow(units=3 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 2 print.margin.left = 2000 print.margin.right = 1000 print.margin.top = 2000 print.margin.bottom = 1000 print.paper.source = 0 print.paper.size = 9 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=3651 color=""553648127"" )
summary(height=0 color=""536870912"" )
footer(height=582 color=""536870912"" )
detail(height=555 color=""536870912""  height.autosize=yes)
table(column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento dbname=""medicamentos.medicamento"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=descripcion dbname=""medicamentos.descripcion"" )
 retrieve=""SELECT medicamentos.medicamento,
       medicamentos.descripcion
  FROM medicamentos
 WHERE medicamentos.medicamento >= :desde
   AND medicamentos.medicamento <= :hasta
"" update=""medicamentos"" updatewhere=1 updatekeyinplace=no arguments=((""desde"", string),(""hasta"", string)) )
text(band=header alignment=""2"" text=""Medicamento"" border=""2"" color=""0"" x=""105"" y=""3148"" height=""449"" width=""3280""  name=medicamento_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Descripción"" border=""2"" color=""0"" x=""3492"" y=""3148"" height=""449"" width=""14128""  name=descripcion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
report(band=header dataobject=""r_header"" x=""132"" y=""105"" height=""1666"" width=""17488"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  name=dw_1  slideup=directlyabove )
text(band=header alignment=""2"" text=""REPORTE DE MEDICAMENTOS"" border=""0"" color=""0"" x=""132"" y=""2196"" height=""529"" width=""17488""  name=t_1  font.face=""Arial"" font.height=""-12"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3492"" y=""26"" height=""502"" width=""14128"" format=""[general]""  name=descripcion height.autosize=yes edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""132"" y=""26"" height=""502"" width=""3280"" format=""[general]""  name=medicamento height.autosize=yes edit.limit=10 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
line(band=footer x1=""105"" y1=""26"" x2=""17594"" y2=""26""  name=l_2 pen.style=""0"" pen.width=""26"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
compute(band=footer alignment=""1"" expression=""'Pag. ' + page() + ' de ' + pageCount()""border=""0"" color=""0"" x=""12594"" y=""106"" height=""423"" width=""4947"" format=""[general]""  name=page_1  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=footer alignment=""0"" expression=""today()""border=""0"" color=""0"" x=""185"" y=""132"" height=""396"" width=""3042"" format=""dd/mm/yyyy""  name=date_1  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
