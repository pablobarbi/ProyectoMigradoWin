using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_modulos_x_perfil : IDataWindowMetadata
    {
        public string DataObject => "d_modulos_x_perfil";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "modulo",
    DbName = "acc_modulos.modulo",
    Tipo = "char(5)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_modulos.nombre",
    Tipo = "char(20)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "perfil",
    DbName = "acc_modulos_x_perfil.perfil",
    Tipo = "char(5)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT DISTINCT dba.acc_modulos.modulo, 
                dba.acc_modulos.nombre, 
                dba.acc_modulos_x_perfil.perfil 
           FROM dba.acc_modulos, 
                dba.acc_modulos_x_perfil 
          WHERE dba.acc_modulos.modulo = dba.acc_modulos_x_perfil.modulo 
            AND dba.acc_modulos_x_perfil.perfil = :perfil 
          ORDER BY dba.acc_modulos.modulo";

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
        public string SrdRaw => @"$PBExportHeader$d_modulos_x_perfil.srd
$PBExportComments$Menúes. Lista de módulos a los que tiene acceso un perfíl.
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=1 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=85 color=""536870912"" )
table(column=(type=char(5) update=yes updatewhereclause=yes name=modulo dbname=""acc_modulos.modulo"" )
 column=(type=char(20) update=yes updatewhereclause=yes name=nombre dbname=""acc_modulos.nombre"" )
 column=(type=char(5) updatewhereclause=yes name=perfil dbname=""acc_modulos_x_perfil.perfil"" )
 retrieve=""SELECT DISTINCT dba.acc_modulos.modulo, 
                dba.acc_modulos.nombre, 
                dba.acc_modulos_x_perfil.perfil 
           FROM dba.acc_modulos, 
                dba.acc_modulos_x_perfil 
          WHERE dba.acc_modulos.modulo = dba.acc_modulos_x_perfil.modulo 
            AND dba.acc_modulos_x_perfil.perfil = :perfil 
          ORDER BY dba.acc_modulos.modulo"" arguments=((""perfil"", string))  sort=""modulo A "" )
column(band=detail id=1 alignment=""1"" tabsequence=32766 border=""6"" color=""0"" x=""19"" y=""12"" height=""61"" width=""238"" format=""[general]""  name=modulo edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""6"" color=""0"" x=""293"" y=""12"" height=""61"" width=""1162"" format=""[general]""  name=nombre edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
";
    }
}
