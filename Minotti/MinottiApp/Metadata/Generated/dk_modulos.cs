using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_modulos : IDataWindowMetadata
    {
        public string DataObject => "dk_modulos";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "modulo",
    DbName = "acc_modulos.modulo",
    Tipo = "char(5)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_modulos.nombre",
    Tipo = "char(40)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_modulos.modulo,
       dba.acc_modulos.nombre
  FROM dba.acc_modulos
 ORDER BY dba.acc_modulos.nombre";

        // PB: table.update
        public string Update => @"acc_modulos";

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
        public string SrdRaw => @"$PBExportHeader$dk_modulos.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=96 color=""12632256"" )
summary(height=4 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""553648127"" )
table(column=(type=char(5) update=yes updatewhereclause=yes key=yes name=modulo dbname=""acc_modulos.modulo"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=nombre dbname=""acc_modulos.nombre"" )
 retrieve=""SELECT dba.acc_modulos.modulo,
       dba.acc_modulos.nombre
  FROM dba.acc_modulos
 ORDER BY dba.acc_modulos.nombre"" update=""acc_modulos"" updatewhere=0 updatekeyinplace=no )
text(band=header alignment=""0"" text=""Modulo"" border=""6"" color=""8388608"" x=""27"" y=""16"" height=""68"" width=""242""  name=modulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Nombre"" border=""6"" color=""8388608"" x=""306"" y=""16"" height=""68"" width=""905""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""306"" y=""8"" height=""68"" width=""905"" format=""[general]""  name=nombre edit.limit=20 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""27"" y=""8"" height=""68"" width=""242"" format=""[general]""  name=modulo edit.limit=5 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""0"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
