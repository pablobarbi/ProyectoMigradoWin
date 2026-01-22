using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_campos_invisibles : IDataWindowMetadata
    {
        public string DataObject => "d_campos_invisibles";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "campo",
    DbName = "par_campoinvisible.campo",
    Tipo = "char(18)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.par_campoinvisible.campo
    FROM dba.par_campoinvisible";

        // PB: table.update
        public string Update => @"dba.par_campoinvisible";

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
        public string SrdRaw => @"$PBExportHeader$d_campos_invisibles.srd
$PBExportComments$Dw que se carga con los registros de la tabla CAMPOS_INVISIBLES. Esta tiene el nombre de los campos que deben ser ocultados en la Aplicacion porque segun en que lugar se instale, dichos campos son necesarios o no.
release 5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=77 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=89 color=""536870912"" )
table(column=(type=char(18) updatewhereclause=yes key=yes name=campo dbname=""par_campoinvisible.campo"" )
 retrieve=""  SELECT dba.par_campoinvisible.campo
    FROM dba.par_campoinvisible
"" update=""dba.par_campoinvisible"" updatewhere=0 updatekeyinplace=no )
text(band=header alignment=""2"" text=""Campo""border=""0"" color=""0"" x=""5"" y=""4"" height=""65"" width=""522""  name=campo_t  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""10"" y=""4"" height=""77"" width=""595"" format=""[general]""  name=campo edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
";
    }
}
