using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_sub_modulos_x_perfil : IDataWindowMetadata
    {
        public string DataObject => "d_sub_modulos_x_perfil";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "submodulo",
    DbName = "submodulo",
    Tipo = "char(18)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_submodulos.nombre",
    Tipo = "char(40)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "acc_operaciones_x_modulo_modulo",
    DbName = "acc_operaciones_x_modulo.modulo",
    Tipo = "char(5)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT DISTINCT acc_operaciones_x_modulo.modulo || '********' || acc_operaciones_x_modulo.submodulo as submodulo,
       acc_submodulos.nombre,
       acc_operaciones_x_modulo.modulo
  FROM acc_submodulos,
       acc_operaciones_x_modulo,
       acc_modulos_x_perfil
 WHERE acc_operaciones_x_modulo.submodulo = acc_submodulos.submodulo
   AND acc_operaciones_x_modulo.modulo = acc_modulos_x_perfil.modulo
   AND acc_modulos_x_perfil.perfil = :perfil";

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
        public string SrdRaw => @"$PBExportHeader$d_sub_modulos_x_perfil.srd
$PBExportComments$Menúes. Lista de los submódulos que tienen asignados las operaciones de los distintos módulos.
release 7;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=88 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=92 color=""536870912"" )
table(column=(type=char(18) updatewhereclause=yes name=submodulo dbname=""submodulo"" )
 column=(type=char(40) updatewhereclause=yes name=nombre dbname=""acc_submodulos.nombre"" )
 column=(type=char(5) updatewhereclause=yes name=acc_operaciones_x_modulo_modulo dbname=""acc_operaciones_x_modulo.modulo"" )
 retrieve=""SELECT DISTINCT acc_operaciones_x_modulo.modulo || '********' || acc_operaciones_x_modulo.submodulo as submodulo,
       acc_submodulos.nombre,
       acc_operaciones_x_modulo.modulo
  FROM acc_submodulos,
       acc_operaciones_x_modulo,
       acc_modulos_x_perfil
 WHERE acc_operaciones_x_modulo.submodulo = acc_submodulos.submodulo
   AND acc_operaciones_x_modulo.modulo = acc_modulos_x_perfil.modulo
   AND acc_modulos_x_perfil.perfil = :perfil 
"" arguments=((""perfil"", string))  sort=""submodulo A "" )
text(band=header alignment=""2"" text=""Nombre"" border=""2"" color=""8388608"" x=""864"" y=""16"" height=""60"" width=""951""  name=nombre_t  font.face=""Arial"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Módulo"" border=""2"" color=""8388608"" x=""1842"" y=""16"" height=""60"" width=""229""  name=modulo_t  font.face=""Arial"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""6"" color=""0"" x=""864"" y=""16"" height=""64"" width=""951"" format=""[general]""  name=nombre edit.limit=20 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""1865"" y=""12"" height=""60"" width=""178"" format=""[general]""  name=acc_operaciones_x_modulo_modulo edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Sub Módulo"" border=""2"" color=""8388608"" x=""18"" y=""16"" height=""60"" width=""814""  name=submodulo_t  font.face=""Arial"" font.height=""-9"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""6"" color=""0"" x=""18"" y=""16"" height=""64"" width=""814"" format=""[general]""  name=submodulo edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""0"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
