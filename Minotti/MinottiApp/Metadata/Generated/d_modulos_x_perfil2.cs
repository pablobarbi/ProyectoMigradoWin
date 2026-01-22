using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_modulos_x_perfil2 : IDataWindowMetadata
    {
        public string DataObject => "d_modulos_x_perfil2";

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
    TabOrder = 0,
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
        public string Sql => @"SELECT dba.acc_modulos_x_perfil.perfil,
			dba.acc_modulos_x_perfil.modulo,   
         dba.acc_modulos.nombre
  FROM dba.acc_modulos_x_perfil,   
         dba.acc_modulos  
   WHERE dba.acc_modulos.modulo = dba.acc_modulos_x_perfil.modulo and  
         dba.acc_modulos_x_perfil.perfil = :perf";

        // PB: table.update
        public string Update => @"acc_modulos_x_perfil";

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
        public string SrdRaw => @"$PBExportHeader$d_modulos_x_perfil2.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=180 color=""12632256"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=84 color=""553648127"" )
table(column=(type=char(5) update=yes updatewhereclause=yes key=yes name=perfil dbname=""acc_modulos_x_perfil.perfil"" )
 column=(type=char(5) update=yes updatewhereclause=yes key=yes name=modulo dbname=""acc_modulos_x_perfil.modulo"" )
 column=(type=char(40) updatewhereclause=yes name=nombre dbname=""acc_modulos.nombre"" )
 retrieve=""  SELECT dba.acc_modulos_x_perfil.perfil,
			dba.acc_modulos_x_perfil.modulo,   
         dba.acc_modulos.nombre
  FROM dba.acc_modulos_x_perfil,   
         dba.acc_modulos  
   WHERE dba.acc_modulos.modulo = dba.acc_modulos_x_perfil.modulo and  
         dba.acc_modulos_x_perfil.perfil = :perf    
"" update=""acc_modulos_x_perfil"" updatewhere=0 updatekeyinplace=no arguments=((""perf"", string)) )
text(band=header alignment=""2"" text=""Modulos por perfil"" border=""0"" color=""8388608"" x=""27"" y=""12"" height=""64"" width=""526""  name=t_1  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Modulo"" border=""6"" color=""8388608"" x=""23"" y=""96"" height=""68"" width=""251""  name=acc_modulos_perfil_modulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""306"" y=""8"" height=""68"" width=""1947"" format=""[general]""  name=nombre edit.limit=40 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Nombre"" border=""6"" color=""8388608"" x=""306"" y=""96"" height=""68"" width=""1947""  name=acc_modulos_nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=0 border=""0"" color=""0"" x=""14"" y=""8"" height=""64"" width=""274""  name=modulo  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
htmltable(border=""0"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
