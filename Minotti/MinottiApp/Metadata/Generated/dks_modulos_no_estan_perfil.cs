using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dks_modulos_no_estan_perfil : IDataWindowMetadata
    {
        public string DataObject => "dks_modulos_no_estan_perfil";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "modulo",
    DbName = "acc_modulos.modulo",
    Tipo = "char(8)",
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
        public string Sql => @"SELECT dba.acc_modulos.modulo,   
         dba.acc_modulos.nombre  
    FROM dba.acc_modulos

         
   WHERE NOT EXISTS (SELECT ''  
                     FROM dba.acc_modulos_perfil
                     WHERE dba.acc_modulos_perfil.perfil = :perf AND  
                     dba.acc_modulos_perfil.modulo = dba.acc_modulos.modulo)";

        // PB: table.update
        public string Update => @"dba.acc_modulos";

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
        public string SrdRaw => @"$PBExportHeader$dks_modulos_no_estan_perfil.srd
release 5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=177 color=""12632256"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=85 color=""553648127"" )
table(column=(type=char(8) update=yes updatewhereclause=yes key=yes name=modulo dbname=""acc_modulos.modulo"" )
 column=(type=char(40) update=yes updatewhereclause=yes name=nombre dbname=""acc_modulos.nombre"" )
 retrieve="" SELECT dba.acc_modulos.modulo,   
         dba.acc_modulos.nombre  
    FROM dba.acc_modulos

         
   WHERE NOT EXISTS (SELECT ''  
                     FROM dba.acc_modulos_perfil
                     WHERE dba.acc_modulos_perfil.perfil = :perf AND  
                     dba.acc_modulos_perfil.modulo = dba.acc_modulos.modulo)
						"" update=""dba.acc_modulos"" updatewhere=0 updatekeyinplace=no arguments=((""perf"", string)) )
text(band=header alignment=""2"" text=""Modulos""border=""0"" color=""8388608"" x=""33"" y=""12"" height=""65"" width=""243""  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Nombre""border=""6"" color=""8388608"" x=""307"" y=""96"" height=""69"" width=""1025""  name=acc_modulos_nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""307"" y=""8"" height=""69"" width=""1025"" format=""[general]""  name=nombre edit.limit=40 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=header alignment=""2"" text=""Modulo""border=""6"" color=""8388608"" x=""23"" y=""96"" height=""69"" width=""252""  name=acc_modulos_perfil_modulo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=1 alignment=""0"" tabsequence=0 border=""0"" color=""0"" x=""28"" y=""4"" height=""69"" width=""252""  name=modulo  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
";
    }
}
