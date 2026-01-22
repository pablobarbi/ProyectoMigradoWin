using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_diagnosticos : IDataWindowMetadata
    {
        public string DataObject => "dp_diagnosticos";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "paciente",
    DbName = "diagnosticos.paciente",
    Tipo = "long",
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "fecha_desde",
    DbName = "diagnosticos.fecha_desde",
    Tipo = "date",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 20,
},

            new DataWindowColumn
{
    Nombre = "fecha_hasta",
    DbName = "diagnosticos.fecha_hasta",
    Tipo = "date",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 30,
},

            new DataWindowColumn
{
    Nombre = "diag_nosologico",
    DbName = "diagnosticos.diag_nosologico",
    Tipo = "char(50)",
    EsClave = true,
    UpdateWhereClause = true,
    EsRequerido = true,
    TabOrder = 50,
},

            new DataWindowColumn
{
    Nombre = "tipo_diagnostico",
    DbName = "tipo_diagnostico",
    Tipo = "char(1)",
    EsClave = true,
    UpdateWhereClause = true,
    EsRequerido = true,
    TabOrder = 40,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT diagnosticos.paciente,
       diagnosticos.fecha_visita fecha_desde,
       diagnosticos.fecha_visita fecha_hasta,
       diagnosticos.diag_nosologico,
       'N' tipo_diagnostico
  FROM diagnosticos";

        // PB: table.update
        public string Update => @"xxx";

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
        public string SrdRaw => @"$PBExportHeader$dp_diagnosticos.srd
release 7;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=196 color=""536870912"" )
table(column=(type=long update=yes updatewhereclause=yes name=paciente dbname=""diagnosticos.paciente"" )
 column=(type=date updatewhereclause=yes key=yes name=fecha_desde dbname=""diagnosticos.fecha_desde"" initial=""01/01/1950"" )
 column=(type=date updatewhereclause=yes key=yes name=fecha_hasta dbname=""diagnosticos.fecha_hasta"" initial=""31/12/2050"" )
 column=(type=char(50) updatewhereclause=yes key=yes name=diag_nosologico dbname=""diagnosticos.diag_nosologico"" )
 column=(type=char(1) updatewhereclause=yes key=yes name=tipo_diagnostico dbname=""tipo_diagnostico"" values=""Nosológico	N/Medicamentoso	M/Miasmático	I/Otro	O/"" )
 retrieve=""SELECT diagnosticos.paciente,
       diagnosticos.fecha_visita fecha_desde,
       diagnosticos.fecha_visita fecha_hasta,
       diagnosticos.diag_nosologico,
       'N' tipo_diagnostico
  FROM diagnosticos
"" update=""xxx"" updatewhere=0 updatekeyinplace=no )
text(band=detail alignment=""1"" text=""Fecha Desde:"" border=""0"" color=""8388608"" x=""37"" y=""20"" height=""68"" width=""416""  name=fecha_desde_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Fecha Hasta:"" border=""0"" color=""8388608"" x=""50"" y=""112"" height=""68"" width=""398""  name=fecha_hasta_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=5 alignment=""0"" tabsequence=40 border=""5"" color=""0"" x=""1467"" y=""20"" height=""68"" width=""608"" format=""[general]""  name=tipo_diagnostico ddlb.limit=0 ddlb.allowedit=no ddlb.case=any ddlb.required=yes ddlb.nilisnull=yes ddlb.useasborder=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=4 alignment=""0"" tabsequence=50 border=""5"" color=""0"" x=""1239"" y=""112"" height=""68"" width=""837"" format=""[general]""  name=diag_nosologico edit.limit=50 edit.case=upper edit.focusrectangle=no edit.autoselect=no edit.required=yes edit.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""0"" text=""Tipo de diagnóstico:"" border=""0"" color=""8388608"" x=""846"" y=""20"" height=""68"" width=""590""  name=tipo_diagnostico_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""0"" text=""Diagnóstico:"" border=""0"" color=""8388608"" x=""846"" y=""112"" height=""68"" width=""370""  name=diag_nosologico_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""1"" tabsequence=20 border=""5"" color=""0"" x=""475"" y=""20"" height=""68"" width=""329"" format=""dd/mm/yyyy""  name=fecha_desde editmask.mask=""dd/mm/yyyy"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=3 alignment=""1"" tabsequence=30 border=""5"" color=""0"" x=""471"" y=""112"" height=""68"" width=""329"" format=""dd/mm/yyyy""  name=fecha_hasta editmask.mask=""dd/mm/yyyy"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
