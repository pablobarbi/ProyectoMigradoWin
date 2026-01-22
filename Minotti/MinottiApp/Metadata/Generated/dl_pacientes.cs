using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dl_pacientes : IDataWindowMetadata
    {
        public string DataObject => "dl_pacientes";

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
 WHERE (pacientes.paciente = :paciente) OR (:paciente = '')";

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
        public string SrdRaw => @"$PBExportHeader$dl_pacientes.srd
release 7;
datawindow(units=3 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="""" print.orientation = 2 print.margin.left = 2000 print.margin.right = 1000 print.margin.top = 2000 print.margin.bottom = 1000 print.paper.source = 0 print.paper.size = 9 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=2645 color=""553648127"" )
summary(height=0 color=""536870912"" )
footer(height=582 color=""536870912"" )
detail(height=5900 color=""536870912""  height.autosize=yes)
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
 WHERE (pacientes.paciente = :paciente) OR (:paciente = '')
"" update=""pacientes"" updatewhere=1 updatekeyinplace=no arguments=((""paciente"", string)) )
report(band=header dataobject=""r_header"" x=""132"" y=""105"" height=""1666"" width=""17488"" border=""0""  height.autosize=yes criteria="""" trail_footer = yes  name=dw_1  slideup=directlyabove )
text(band=header alignment=""2"" text=""Pacientes"" border=""0"" color=""0"" x=""105"" y=""1957"" height=""529"" width=""17488""  name=t_1  font.face=""Arial"" font.height=""-12"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=7 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""3651"" y=""5133"" height=""449"" width=""1957"" format=""[general]""  name=ultima_visita editmask.mask=""dd/mm/yyyy"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=6 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""3651"" y=""2752"" height=""449"" width=""1957"" format=""[general]""  name=fecha_nacimiento editmask.mask=""dd/mm/yyyy"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=10 alignment=""1"" tabsequence=32766 border=""0"" color=""0"" x=""3651"" y=""4551"" height=""449"" width=""1137"" format=""[general]""  name=cantidad_hijos editmask.mask=""##"" editmask.focusrectangle=no  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
text(band=detail alignment=""1"" text=""Ultima Visita:"" border=""0"" color=""0"" x=""608"" y=""5133"" height=""449"" width=""2883""  name=ultima_visita_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Nombre y Apellido:"" border=""0"" color=""0"" x=""264"" y=""212"" height=""423"" width=""3227""  name=nombre_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Domicilio:"" border=""0"" color=""0"" x=""608"" y=""847"" height=""449"" width=""2883""  name=domicilio_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Telefono:"" border=""0"" color=""0"" x=""608"" y=""1482"" height=""449"" width=""2883""  name=telefono_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Sexo:"" border=""0"" color=""0"" x=""608"" y=""2117"" height=""449"" width=""2883""  name=sexo_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Fecha Nacimiento:"" border=""0"" color=""0"" x=""343"" y=""2752"" height=""449"" width=""3148""  name=fecha_nacimiento_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Ocupación:"" border=""0"" color=""0"" x=""608"" y=""3334"" height=""423"" width=""2883""  name=ocupacion_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Estado Civil:"" border=""0"" color=""0"" x=""608"" y=""3969"" height=""423"" width=""2883""  name=estado_civ_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
text(band=detail alignment=""1"" text=""Cantidad Hijos:"" border=""0"" color=""0"" x=""608"" y=""4551"" height=""449"" width=""2883""  name=cantidad_hijos_t  font.face=""Arial"" font.height=""-10"" font.weight=""700""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""536870912"" )
line(band=detail x1=""105"" y1=""5742"" x2=""17594"" y2=""5742""  name=l_1 pen.style=""0"" pen.width=""26"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
column(band=detail id=2 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3651"" y=""212"" height=""449"" width=""13864"" format=""[general]""  name=nombre edit.limit=50 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=3 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3651"" y=""847"" height=""449"" width=""13864"" format=""[general]""  name=domicilio edit.limit=50 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=8 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3651"" y=""3334"" height=""449"" width=""13864"" format=""[general]""  name=ocupacion edit.limit=50 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=4 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3651"" y=""1482"" height=""449"" width=""4762"" format=""[general]""  name=telefono edit.limit=15 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=5 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3651"" y=""2117"" height=""449"" width=""4762"" format=""[general]""  name=sexo ddlb.limit=0 ddlb.allowedit=no ddlb.case=any ddlb.nilisnull=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
column(band=detail id=9 alignment=""0"" tabsequence=32766 border=""0"" color=""0"" x=""3651"" y=""3969"" height=""449"" width=""4762"" format=""[general]""  name=estado_civil dddw.name=dw_estado_civil dddw.displaycolumn=descripcion dddw.datacolumn=estado_civil dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes dddw.vscrollbar=yes  font.face=""Arial"" font.height=""-10"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
line(band=footer x1=""105"" y1=""27"" x2=""17594"" y2=""27""  name=l_2 pen.style=""0"" pen.width=""26"" pen.color=""0""  background.mode=""2"" background.color=""16777215"" )
compute(band=footer alignment=""1"" expression=""'Pag. ' + page() + ' de ' + pageCount()""border=""0"" color=""0"" x=""12594"" y=""106"" height=""423"" width=""4947"" format=""[general]""  name=page_1  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
compute(band=footer alignment=""0"" expression=""today()""border=""0"" color=""0"" x=""185"" y=""132"" height=""396"" width=""3042"" format=""dd/mm/yyyy""  name=date_1  font.face=""Arial"" font.height=""-9"" font.weight=""400""  font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""1"" background.color=""553648127"" )
htmltable(border=""1"" )
htmlgen(clientevents=""1"" clientvalidation=""1"" clientcomputedfields=""1"" clientformatting=""0"" clientscriptable=""0"" generatejavascript=""1"" )
";
    }
}
