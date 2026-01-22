using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_pacientes : IDataWindowMetadata
    {
        public string DataObject => "dr_pacientes";

        public List<DataWindowColumn> Columns { get; } = new()
        {
            new DataWindowColumn
{
    Nombre = "paciente",
    DbName = "pacientes.paciente",
    Tipo = "long",
    EsClave = true,
    EsIdentity = true,
    UpdateWhereClause = true,
},

            new DataWindowColumn
{
    Nombre = "nombre",
    DbName = "pacientes.nombre",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "domicilio",
    DbName = "pacientes.domicilio",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "telefono",
    DbName = "pacientes.telefono",
    Tipo = "char(15)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "sexo",
    DbName = "pacientes.sexo",
    Tipo = "char(1)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "fecha_nacimiento",
    DbName = "pacientes.fecha_nacimiento",
    Tipo = "date",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "ultima_visita",
    DbName = "pacientes.ultima_visita",
    Tipo = "date",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "ocupacion",
    DbName = "pacientes.ocupacion",
    Tipo = "char(50)",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "estado_civil",
    DbName = "pacientes.estado_civil",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 32766,
},

            new DataWindowColumn
{
    Nombre = "cantidad_hijos",
    DbName = "pacientes.cantidad_hijos",
    Tipo = "long",
    UpdateWhereClause = true,
    TabOrder = 32766,
}
        };

        // PB: table.retrieve
        public string Sql => @"SELECT pacientes.paciente,
       pacientes.nombre,
       pacientes.domicilio,
       pacientes.telefono,
       pacientes.sexo,
       pacientes.fecha_nacimiento,
       pacientes.ultima_visita,
       pacientes.ocupacion,
       pacientes.estado_civil,
       pacientes.cantidad_hijos
  FROM pacientes
 WHERE (pacientes.paciente = :paciente) OR (:paciente = '0')";

        // PB: table.update
        public string Update => @"pacientes";

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
        public string SrdRaw => @"$PBExportHeader$dr_pacientes.srd
release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=144 color=""81324524"" )
summary(height=0 color=""536870912"" )
footer(height=0 color=""536870912"" )
detail(height=808 color=""536870912"" )
table(column=(type=long update=yes updatewhereclause=yes key=yes identity=yes name=paciente dbname=""pacientes.paciente"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=nombre dbname=""pacientes.nombre"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=domicilio dbname=""pacientes.domicilio"" )
 column=(type=char(15) update=yes updatewhereclause=yes name=telefono dbname=""pacientes.telefono"" )
 column=(type=char(1) update=yes updatewhereclause=yes name=sexo dbname=""pacientes.sexo"" values=""Masculino	M/Femenino	F/"" )
 column=(type=date update=yes updatewhereclause=yes name=fecha_nacimiento dbname=""pacientes.fecha_nacimiento"" )
 column=(type=date update=yes updatewhereclause=yes name=ultima_visita dbname=""pacientes.ultima_visita"" )
 column=(type=char(50) update=yes updatewhereclause=yes name=ocupacion dbname=""pacientes.ocupacion"" )
 column=(type=long update=yes updatewhereclause=yes name=estado_civil dbname=""pacientes.estado_civil"" )
 column=(type=long update=yes updatewhereclause=yes name=cantidad_hijos dbname=""pacientes.cantidad_hijos"" )
 retrieve=""SELECT pacientes.paciente,
       pacientes.nombre,
       pacientes.domicilio,
       pacientes.telefono,
       pacientes.sexo,
       pacientes.fecha_nacimiento,
       pacientes.ultima_visita,
       pacientes.ocupacion,
       pacientes.estado_civil,
       pacientes.cantidad_hijos
  FROM pacientes
 WHERE (pacientes.paciente = :paciente) OR (:paciente = '0')
"" update=""pacientes"" updatewhere=1 updatekeyinplace=no arguments=((""paciente"", string)) )
text(band=header alignment=""2"" text=""Pacientes"" border=""0"" color=""8388608"" x=""18"" y=""32"" height=""80"" width=""2629""  name=t_1  font.face=""Arial"" font.height=""-12"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""553648127"" )
line(band=detail x1=""18"" y1=""792"" x2=""2647"" y2=""792""  name=l_1 pen.style=""0"" pen.width=""5"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
text(band=detail alignment=""1"" text=""Nombre y Apellido:"" border=""0"" color=""8388608"" x=""46"" y=""32"" height=""68"" width=""558""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Domicilio:"" border=""0"" color=""8388608"" x=""105"" y=""116"" height=""68"" width=""498""  name=domicilio_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Telefono:"" border=""0"" color=""8388608"" x=""105"" y=""200"" height=""68"" width=""498""  name=telefono_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Sexo:"" border=""0"" color=""8388608"" x=""105"" y=""284"" height=""68"" width=""498""  name=sexo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Fecha Nacimiento:"" border=""0"" color=""8388608"" x=""59"" y=""368"" height=""68"" width=""544""  name=fecha_nacimiento_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Ocupación:"" border=""0"" color=""8388608"" x=""105"" y=""452"" height=""68"" width=""498""  name=ocupacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Estado Civil:"" border=""0"" color=""8388608"" x=""105"" y=""536"" height=""68"" width=""498""  name=estado_civ_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Cantidad Hijos:"" border=""0"" color=""8388608"" x=""105"" y=""620"" height=""68"" width=""498""  name=cantidad_hijos_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Ultima Visita:"" border=""0"" color=""8388608"" x=""105"" y=""704"" height=""68"" width=""498""  name=ultima_visita_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""631"" y=""32"" height=""68"" width=""1993"" format=""[general]""  name=nombre edit.limit=50 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""631"" y=""116"" height=""68"" width=""1993"" format=""[general]""  name=domicilio edit.limit=50 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""631"" y=""200"" height=""68"" width=""439"" format=""[general]""  name=telefono edit.limit=15 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""631"" y=""284"" height=""68"" width=""439"" format=""[general]""  name=sexo ddlb.limit=0 ddlb.allowedit=no ddlb.case=any ddlb.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=6 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""631"" y=""368"" height=""68"" width=""338"" format=""[general]""  name=fecha_nacimiento editmask.mask=""dd/mm/yyyy"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=8 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""631"" y=""452"" height=""68"" width=""1993"" format=""[general]""  name=ocupacion edit.limit=50 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=9 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""631"" y=""536"" height=""68"" width=""608"" format=""[general]""  name=estado_civil dddw.name=dw_estado_civil dddw.displaycolumn=descripcion dddw.datacolumn=estado_civil dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=10 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""631"" y=""620"" height=""68"" width=""197"" format=""[general]""  name=cantidad_hijos editmask.mask=""##"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=7 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""631"" y=""704"" height=""68"" width=""338"" format=""[general]""  name=ultima_visita editmask.mask=""dd/mm/yyyy"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
