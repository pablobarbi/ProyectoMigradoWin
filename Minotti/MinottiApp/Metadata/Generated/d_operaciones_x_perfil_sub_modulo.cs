using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_operaciones_x_perfil_sub_modulo : IDataWindowMetadata
    {
        public string DataObject => "d_operaciones_x_perfil_sub_modulo";

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
    Tipo = "char(40)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "submodulo",
    DbName = "submodulo",
    Tipo = "char(15)",
    UpdateWhereClause = true,
    TabOrder = 10,
},

            new DataWindowColumn
{
    Nombre = "modulo",
    DbName = "acc_operaciones_x_modulo.modulo",
    Tipo = "char(5)",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT DISTINCT dba.acc_operaciones.operacion, 
                dba.acc_operaciones.nombre, 
                dba.acc_operaciones_x_modulo.modulo + '*****' + dba.acc_operaciones_x_modulo.submodulo submodulo,
                dba.acc_operaciones_x_modulo.modulo 
           FROM dba.acc_modulos_x_perfil, 
                dba.acc_operaciones_x_modulo, 
                dba.acc_operaciones 
          WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion 
            AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo 
            AND dba.acc_modulos_x_perfil.perfil = :perfil";

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
        public string SrdRaw => @"$PBExportHeader$d_operaciones_x_perfil_sub_modulo.srd
$PBExportComments$Menúes. Lista de operaciones a las que tiene acceso un perfíl (a través de los módulos y submódulos).
release 10.5;
datawindow(units=0 timer_interval=0 color=276856960 processing=0 HTMLDW=no print.printername="""" print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 97 print.margin.bottom = 97 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=100 color=""536870912"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=92 color=""553648127"" )
table(column=(type=char(5) updatewhereclause=yes name=operacion dbname=""acc_operaciones.operacion"" dbalias="".operacion"" )
 column=(type=char(40) updatewhereclause=yes name=nombre dbname=""acc_operaciones.nombre"" dbalias="".nombre"" )
 column=(type=char(15) updatewhereclause=yes name=submodulo dbname=""submodulo"" )
 column=(type=char(5) updatewhereclause=yes name=modulo dbname=""acc_operaciones_x_modulo.modulo"" dbalias="".modulo"" )
 retrieve=""SELECT DISTINCT dba.acc_operaciones.operacion, 
                dba.acc_operaciones.nombre, 
                dba.acc_operaciones_x_modulo.modulo + '*****' + dba.acc_operaciones_x_modulo.submodulo submodulo,
                dba.acc_operaciones_x_modulo.modulo 
           FROM dba.acc_modulos_x_perfil, 
                dba.acc_operaciones_x_modulo, 
                dba.acc_operaciones 
          WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion 
            AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo 
            AND dba.acc_modulos_x_perfil.perfil = :perfil 
"" arguments=((""perfil"", string))  sort=""modulo A submodulo A operacion A "" )
text(band=header alignment=""2"" text=""Operación"" border=""2"" color=""0"" x=""32"" y=""12"" height=""72"" width=""361"" html.valueishtml=""0""  name=operacion_t visible=""1""  font.face=""Arial"" font.height=""-11"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=header alignment=""2"" text=""Nombre"" border=""2"" color=""0"" x=""425"" y=""12"" height=""72"" width=""1495"" html.valueishtml=""0""  name=nombre_t visible=""1""  font.face=""Arial"" font.height=""-11"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=1 alignment=""1"" tabsequence=32766 border=""6"" color=""0"" x=""32"" y=""12"" height=""72"" width=""361"" format=""[general]"" html.valueishtml=""0""  name=operacion visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""6"" color=""0"" x=""425"" y=""12"" height=""72"" width=""1495"" format=""[general]"" html.valueishtml=""0""  name=nombre visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=3 alignment=""0"" tabsequence=10 border=""0"" color=""0"" x=""1943"" y=""20"" height=""60"" width=""229"" format=""[general]"" html.valueishtml=""0""  name=submodulo visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""2194"" y=""20"" height=""60"" width=""283"" format=""[general]"" html.valueishtml=""0""  name=modulo visible=""1"" edit.limit=0 edit.case=any edit.autoselect=yes  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
htmltable(border=""0"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" encodeselflinkargs=""1"" netscapelayers=""0"" pagingmethod=0 generatedddwframes=""1"" )
xhtmlgen() cssgen(sessionspecific=""0"" )
xmlgen(inline=""0"" )
xsltgen()
jsgen()
export.xml(headgroups=""1"" includewhitespace=""0"" metadatatype=0 savemetadata=0 )
import.xml()
export.pdf(method=0 distill.custompostscript=""0"" xslfop.print=""0"" )
export.xhtml()
 ";
    }
}
