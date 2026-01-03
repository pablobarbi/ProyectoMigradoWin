using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class d_pacientes
    {
        public static string Sql= @"SELECT pacientes.paciente,        
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
                                                        WHERE pacientes.paciente = ?";

        public static DataTable RetrieveToDataTable(params object[] parametros)
        {           

            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
                foreach (var p in parametros)
                {
                    var prm = cmd.CreateParameter();
                    prm.Value = p ?? DBNull.Value;
                    cmd.Parameters.Add(prm);
                }
            });
        }

        /* ===== UPDATE (tal cual en SRD) =====
pacientes
        */

        /* ===== SRD original completo =====
﻿release 10.5;
datawindow(units=0 timer_interval=0 color=80269524 processing=0 HTMLDW=no print.printername="" print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=8 color="536870912" )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=872 color="536870912" )
table(column=(type=long update=yes updatewhereclause=yes key=yes identity=yes name=paciente dbname="pacientes.paciente" )
 column=(type=char(50) update=yes updatewhereclause=yes name=nombre dbname="pacientes.nombre" )
 column=(type=char(50) update=yes updatewhereclause=yes name=domicilio dbname="pacientes.domicilio" )
 column=(type=char(15) update=yes updatewhereclause=yes name=telefono dbname="pacientes.telefono" )
 column=(type=char(1) update=yes updatewhereclause=yes name=sexo dbname="pacientes.sexo" values="Masculino	M/Femenino	F/" )
 column=(type=date update=yes updatewhereclause=yes name=fecha_nacimiento dbname="pacientes.fecha_nacimiento" )
 column=(type=date update=yes updatewhereclause=yes name=ultima_visita dbname="pacientes.ultima_visita" )
 column=(type=char(50) update=yes updatewhereclause=yes name=ocupacion dbname="pacientes.ocupacion" )
 column=(type=long update=yes updatewhereclause=yes name=estado_civil dbname="pacientes.estado_civil" )
 column=(type=long update=yes updatewhereclause=yes name=cantidad_hijos dbname="pacientes.cantidad_hijos" )
 retrieve="SELECT pacientes.paciente,
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
 WHERE pacientes.paciente = :paciente
" update="pacientes" updatewhere=1 updatekeyinplace=no arguments=(("paciente", string)) )
column(band=detail id=2 alignment="0" tabsequence=20 border="5" color="0" x="709" y="28" height="68" width="1399" format="[General]" html.valueishtml="0"  name=nombre visible="1" dddw.name=dw_pacientes dddw.displaycolumn=nombre dddw.datacolumn=nombre dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=yes dddw.useasborder=yes dddw.case=upper dddw.required=yes dddw.nilisnull=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=5 alignment="0" tabsequence=50 border="5" color="0" x="709" y="320" height="68" width="439" format="[general]" html.valueishtml="0"  name=sexo visible="1" ddlb.limit=0 ddlb.allowedit=no ddlb.case=any ddlb.nilisnull=yes ddlb.useasborder=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=3 alignment="0" tabsequence=30 border="5" color="0" x="709" y="128" height="68" width="1399" format="[general]" html.valueishtml="0"  name=domicilio visible="1" editmask.mask="!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" editmask.focusrectangle=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=4 alignment="0" tabsequence=40 border="5" color="0" x="709" y="224" height="68" width="439" format="[general]" html.valueishtml="0"  name=telefono visible="1" edit.limit=15 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=6 alignment="1" tabsequence=60 border="5" color="0" x="709" y="416" height="68" width="338" format="[general]" html.valueishtml="0"  name=fecha_nacimiento visible="1" editmask.mask="dd/mm/yyyy" editmask.focusrectangle=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=8 alignment="0" tabsequence=70 border="5" color="0" x="709" y="504" height="68" width="1399" format="[general]" html.valueishtml="0"  name=ocupacion visible="1" editmask.mask="!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" editmask.focusrectangle=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=9 alignment="0" tabsequence=80 border="5" color="0" x="709" y="600" height="68" width="608" format="[general]" html.valueishtml="0"  name=estado_civil visible="1" dddw.name=dw_estado_civil dddw.displaycolumn=descripcion dddw.datacolumn=estado_civil dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=yes dddw.case=any dddw.nilisnull=yes dddw.vscrollbar=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=10 alignment="1" tabsequence=90 border="5" color="0" x="709" y="688" height="68" width="197" format="[general]" html.valueishtml="0"  name=cantidad_hijos visible="1" editmask.mask="##" editmask.focusrectangle=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=7 alignment="1" tabsequence=100 border="5" color="0" x="709" y="776" height="68" width="338" format="[general]" html.valueishtml="0"  name=ultima_visita visible="1" editmask.mask="dd/mm/yyyy" editmask.focusrectangle=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
text(band=detail alignment="1" text="Fecha de Nacimiento:" border="0" color="8388608" x="46" y="416" height="64" width="635" html.valueishtml="0"  name=fecha_nacimiento_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Ocupación:" border="0" color="8388608" x="183" y="504" height="64" width="498" html.valueishtml="0"  name=ocupacion_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Estado Civil:" border="0" color="8388608" x="183" y="600" height="64" width="498" html.valueishtml="0"  name=estado_civ_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Cantidad de Hijos:" border="0" color="8388608" x="151" y="688" height="68" width="530" html.valueishtml="0"  name=cantidad_hijos_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Ultima Visita:" border="0" color="8388608" x="183" y="776" height="68" width="498" html.valueishtml="0"  name=ultima_visita_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Nombre y Apellido:" border="0" color="8388608" x="123" y="32" height="64" width="558" html.valueishtml="0"  name=nombre_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Domicilio:" border="0" color="8388608" x="183" y="128" height="68" width="498" html.valueishtml="0"  name=domicilio_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Telefono:" border="0" color="8388608" x="183" y="224" height="68" width="498" html.valueishtml="0"  name=telefono_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Sexo:" border="0" color="8388608" x="183" y="320" height="68" width="498" html.valueishtml="0"  name=sexo_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
htmltable(border="1" )
htmlgen(clientevents="1" clientvalidation="1" clientcomputedfields="1" clientformatting="0" clientscriptable="0" generatejavascript="1" encodeselflinkargs="1" netscapelayers="0" pagingmethod=0 generatedddwframes="1" )
xhtmlgen() cssgen(sessionspecific="0" )
xmlgen(inline="0" )
xsltgen()
jsgen()
export.xml(headgroups="1" includewhitespace="0" metadatatype=0 savemetadata=0 )
import.xml()
export.pdf(method=0 distill.custompostscript="0" xslfop.print="0" )
export.xhtml()
 
        */
    }
}