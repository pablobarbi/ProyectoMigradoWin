using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_operaciones_x_perfil : IDataWindowMetadata
    {
        public string DataObject => "d_operaciones_x_perfil";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "operacion",
    DbName = "acc_operaciones.operacion",
    Tipo = "char(5)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "acc_operaciones.nombre",
    Tipo = "char(30)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "modulo",
    DbName = "acc_operaciones_x_modulo.modulo",
    Tipo = "char(5)",
    UpdateWhereClause = true,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT DISTINCT dba.acc_operaciones.operacion, 
                dba.acc_operaciones.nombre, 
                dba.acc_operaciones_x_modulo.modulo 
           FROM dba.acc_modulos_x_perfil, 
                dba.acc_operaciones_x_modulo, 
                dba.acc_operaciones 
          WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion 
            AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo 
            AND dba.acc_modulos_x_perfil.perfil = :perfil 
          ORDER BY dba.acc_operaciones_x_modulo.modulo, 
                   dba.acc_operaciones.operacion";

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
        public string SrdRaw => @"$PBExportHeader$d_operaciones_x_perfil.srd
$PBExportComments$Menúes. Lista de operaciones a las que tiene acceso un perfíl (a través de los módulos).
release 5;
datawindow(units=0 timer_interval=0 color=276856960 processing=0 print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.prompt=no )
header(height=101 color=""536870912"" )
summary(height=1 color=""536870912"" )
footer(height=1 color=""536870912"" )
detail(height=93 color=""553648127"" )
table(column=(type=char(5) updatewhereclause=yes name=operacion dbname=""acc_operaciones.operacion"" )
 column=(type=char(30) updatewhereclause=yes name=nombre dbname=""acc_operaciones.nombre"" )
 column=(type=char(5) updatewhereclause=yes name=modulo dbname=""acc_operaciones_x_modulo.modulo"" )
 retrieve=""SELECT DISTINCT dba.acc_operaciones.operacion, 
                dba.acc_operaciones.nombre, 
                dba.acc_operaciones_x_modulo.modulo 
           FROM dba.acc_modulos_x_perfil, 
                dba.acc_operaciones_x_modulo, 
                dba.acc_operaciones 
          WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion 
            AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo 
            AND dba.acc_modulos_x_perfil.perfil = :perfil 
          ORDER BY dba.acc_operaciones_x_modulo.modulo, 
                   dba.acc_operaciones.operacion"" arguments=((""perfil"", string))  sort=""modulo A operacion A "" )
text(band=header alignment=""2"" text=""Operación""border=""2"" color=""0"" x=""33"" y=""12"" height=""73"" width=""362""  name=operacion_t  font.face=""Arial"" font.height=""-11"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Nombre""border=""2"" color=""0"" x=""426"" y=""12"" height=""73"" width=""1495""  name=nombre_t  font.face=""Arial"" font.height=""-11"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=1 alignment=""1"" tabsequence=32766 border=""6"" color=""0"" x=""33"" y=""12"" height=""73"" width=""362"" format=""[general]""  name=operacion edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""6"" color=""0"" x=""426"" y=""12"" height=""73"" width=""1495"" format=""[general]""  name=nombre edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
";
    }
}
