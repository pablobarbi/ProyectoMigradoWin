using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_ayuda : IDataWindowMetadata
    {
        public string DataObject => "d_ayuda";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "titulo",
    DbName = "titulo",
    Tipo = "char(100)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "descripcion",
    DbName = "descripcion",
    Tipo = "char(256)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"";

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
        public string SrdRaw => @"$PBExportHeader$d_ayuda.srd
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=97 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=141 color=""553648127""  height.autosize=yes)
table(column=(type=char(100) updatewhereclause=yes name=titulo dbname=""titulo"" )
 column=(type=char(256) updatewhereclause=yes name=descripcion dbname=""descripcion"" )
 )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""16711680"" x=""19"" y=""4"" height=""61"" width=""1939"" format=""[general]""  name=titulo edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""MS Sans Serif"" font.height=""-11"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""138"" y=""68"" height=""61"" width=""1943"" format=""[general]""  name=descripcion height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""MS Sans Serif"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""0"" text=""Descripción de los datos de la Ventana""border=""0"" color=""0"" x=""19"" y=""12"" height=""65"" width=""1422""  font.face=""MS Sans Serif"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""553648127"" )
";
    }
}
