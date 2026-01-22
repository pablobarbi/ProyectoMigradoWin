using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_modulos_por_perfil : IDataWindowMetadata
    {
        public string DataObject => "d_modulos_por_perfil";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "perfil",
    DbName = "acc_modulos_x_perfil.perfil",
    Tipo = "char(5)",
    EsClave = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "modulo",
    DbName = "acc_modulos_x_perfil.modulo",
    Tipo = "char(5)",
    EsClave = true,
    UpdateWhereClause = true,
    TabOrder = 20,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT dba.acc_modulos_x_perfil.perfil,
       dba.acc_modulos_x_perfil.modulo
  FROM dba.acc_modulos_x_perfil
 WHERE dba.acc_modulos_x_perfil.perfil = :perfil";

        // PB: table.update
        public string Update => @"dba.acc_modulos_x_perfil";

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
        public string SrdRaw => @"$PBExportHeader$d_modulos_por_perfil.srd
release 5;
datawindow(units=0 timer_interval=0 color=12632256 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=97 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=93 color=""536870912"" )
table(column=(type=char(5) update=yes updatewhereclause=yes key=yes name=perfil dbname=""acc_modulos_x_perfil.perfil"" )
 column=(type=char(5) update=yes updatewhereclause=yes key=yes name=modulo dbname=""acc_modulos_x_perfil.modulo"" )
 retrieve=""SELECT dba.acc_modulos_x_perfil.perfil,
       dba.acc_modulos_x_perfil.modulo
  FROM dba.acc_modulos_x_perfil
 WHERE dba.acc_modulos_x_perfil.perfil = :perfil
"" update=""dba.acc_modulos_x_perfil"" updatewhere=0 updatekeyinplace=no arguments=((""perfil"", string)) )
text(band=header alignment=""2"" text=""Módulo""border=""2"" color=""8388608"" x=""33"" y=""16"" height=""65"" width=""1175""  name=modulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=20 border=""6"" color=""0"" x=""33"" y=""12"" height=""65"" width=""1175"" format=""[general]""  name=modulo dddw.name=dw_modulos dddw.displaycolumn=display dddw.datacolumn=modulo dddw.percentwidth=100 dddw.lines=6 dddw.limit=0 dddw.allowedit=yes dddw.useasborder=yes dddw.case=any dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
