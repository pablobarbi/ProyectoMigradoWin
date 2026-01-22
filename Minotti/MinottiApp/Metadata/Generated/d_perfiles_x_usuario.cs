using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_perfiles_x_usuario : IDataWindowMetadata
    {
        public string DataObject => "d_perfiles_x_usuario";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "acc_perfiles_perfil",
    DbName = "acc_perfiles.perfil",
    Tipo = "char(5)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "acc_perfiles_nombre",
    DbName = "acc_perfiles.nombre",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT DISTINCT acc_perfiles.perfil, 
                acc_perfiles.nombre 
           FROM acc_perfiles, 
                acc_usuarios 
          WHERE acc_perfiles.perfil = acc_usuarios.perfil 
            AND acc_usuarios.usuario = :usuario";

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
        public string SrdRaw => @"$PBExportHeader$d_perfiles_x_usuario.srd
$PBExportComments$Menúes. Datos del perfíl de un usuario.
release 7;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""536870912"" )
table(column=(type=char(5) updatewhereclause=yes name=acc_perfiles_perfil dbname=""acc_perfiles.perfil"" )
 column=(type=char(50) updatewhereclause=yes name=acc_perfiles_nombre dbname=""acc_perfiles.nombre"" )
 retrieve=""SELECT DISTINCT acc_perfiles.perfil, 
                acc_perfiles.nombre 
           FROM acc_perfiles, 
                acc_usuarios 
          WHERE acc_perfiles.perfil = acc_usuarios.perfil 
            AND acc_usuarios.usuario = :usuario
"" arguments=((""usuario"", string)) )
column(band=detail id=1 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""5"" y=""4"" height=""76"" width=""160"" format=""[general]""  name=acc_perfiles_perfil edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""174"" y=""4"" height=""76"" width=""1600"" format=""[general]""  name=acc_perfiles_nombre edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-12"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"" )
htmltable(border=""0"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
