using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class d_diagnosticos
    {
        public static string Sql = @"SELECT diagnosticos.paciente,
                                           diagnosticos.diagnostico,
                                           diagnosticos.fecha_visita,
                                           diagnosticos.diag_nosologico,
                                           diagnosticos.diag_medicamentoso,
                                           diagnosticos.diag_miasmatico,
                                           diagnosticos.diag_otro,
                                           diagnosticos.repertorizacion,
                                           diagnosticos.primera,
                                           diagnosticos.curado   
                                    FROM diagnosticos  
                                    WHERE diagnosticos.paciente = ?
                                      AND diagnosticos.diagnostico = ?";

        public DataTable RetrieveToDataTable(object paciente, object diagnostico)
        {
            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
                // 1er parámetro → primer "?"
                var p1 = cmd.CreateParameter();
                p1.Value = paciente ?? DBNull.Value;
                cmd.Parameters.Add(p1);

                // 2do parámetro → segundo "?"
                var p2 = cmd.CreateParameter();
                p2.Value = diagnostico ?? DBNull.Value;
                cmd.Parameters.Add(p2);
            });
        }

        /* ===== UPDATE (tal cual en SRD) =====
diagnosticos
        */

        /* ===== SRD original completo =====
﻿release 7;
datawindow(units=0 timer_interval=0 color=80269524 processing=0 HTMLDW=no print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=868 color="536870912" )
table(column=(type=long update=yes updatewhereclause=yes key=yes name=paciente dbname="diagnosticos.paciente" )
 column=(type=long update=yes updatewhereclause=yes key=yes name=diagnostico dbname="diagnosticos.diagnostico" )
 column=(type=date update=yes updatewhereclause=yes name=fecha_visita dbname="diagnosticos.fecha_visita" )
 column=(type=char(50) update=yes updatewhereclause=yes name=diag_nosologico dbname="diagnosticos.diag_nosologico" )
 column=(type=char(50) update=yes updatewhereclause=yes name=diag_medicamentoso dbname="diagnosticos.diag_medicamentoso" )
 column=(type=char(50) update=yes updatewhereclause=yes name=diag_miasmatico dbname="diagnosticos.diag_miasmatico" )
 column=(type=char(50) update=yes updatewhereclause=yes name=diag_otro dbname="diagnosticos.diag_otro" )
 column=(type=long update=yes updatewhereclause=yes name=repertorizacion dbname="diagnosticos.repertorizacion" )
 column=(type=char(1) update=yes updatewhereclause=yes name=primera dbname="diagnosticos.primera" values="	S/	N" )
 column=(type=char(1) update=yes updatewhereclause=yes name=curado dbname="diagnosticos.curado" values="	S/	N" )
 retrieve="SELECT diagnosticos.paciente,
       diagnosticos.diagnostico,
       diagnosticos.fecha_visita,
       diagnosticos.diag_nosologico,
       diagnosticos.diag_medicamentoso,
       diagnosticos.diag_miasmatico,
       diagnosticos.diag_otro,
       diagnosticos.repertorizacion,
       diagnosticos.primera,
       diagnosticos.curado
  FROM diagnosticos
 WHERE diagnosticos.paciente = :paciente
   AND diagnosticos.diagnostico = :diagnostico
" update="diagnosticos" updatewhere=1 updatekeyinplace=no arguments=(("paciente", string),("diagnostico", string)) )
groupbox(band=detail text="Diagnósticos:"border="5" color="128" x="105" y="228" height="456" width="2523"  name=gb_1  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" font.italic="1" background.mode="1" background.color="553648127" )
column(band=detail id=4 alignment="0" tabsequence=40 border="5" color="0" x="645" y="292" height="68" width="1943" format="[general]"  name=diag_nosologico edit.limit=50 edit.case=upper edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=5 alignment="0" tabsequence=50 border="5" color="0" x="645" y="388" height="68" width="1943" format="[general]"  name=diag_medicamentoso edit.limit=50 edit.case=upper edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=6 alignment="0" tabsequence=60 border="5" color="0" x="645" y="488" height="68" width="1943" format="[general]"  name=diag_miasmatico edit.limit=50 edit.case=upper edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=7 alignment="0" tabsequence=70 border="5" color="0" x="645" y="584" height="68" width="1943" format="[general]"  name=diag_otro edit.limit=50 edit.case=upper edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
text(band=detail alignment="1" text="Medicamentoso:" border="0" color="8388608" x="119" y="388" height="68" width="503"  name=diag_medicamentoso_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Miasmático:" border="0" color="8388608" x="119" y="488" height="68" width="503"  name=diag_miasmatico_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Otro:" border="0" color="8388608" x="119" y="584" height="68" width="503"  name=diag_otro_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Nosológico:" border="0" color="8388608" x="119" y="292" height="68" width="503"  name=diag_nosologico_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=1 alignment="1" tabsequence=10 border="5" color="0" x="709" y="32" height="68" width="1888" format="[general]"  name=paciente dddw.name=dw_pacientes dddw.displaycolumn=nombre dddw.datacolumn=paciente dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=yes dddw.case=any dddw.required=yes dddw.nilisnull=yes dddw.vscrollbar=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
text(band=detail alignment="1" text="Paciente:" border="0" color="8388608" x="110" y="32" height="68" width="576"  name=paciente_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=2 alignment="1" tabsequence=20 border="5" color="0" x="704" y="128" height="68" width="329" format="[general]"  name=diagnostico edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.nilisnull=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
text(band=detail alignment="1" text="Nro. de diagnóstico:" border="0" color="8388608" x="101" y="128" height="68" width="581"  name=diagnostico_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=3 alignment="0" tabsequence=30 border="5" color="0" x="1838" y="132" height="68" width="329" format="dd/mm/yyyy"  name=fecha_visita editmask.mask="dd/mm/yyyy" editmask.focusrectangle=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
text(band=detail alignment="1" text="Fecha de visita:" border="0" color="8388608" x="1239" y="132" height="64" width="576"  name=fecha_visita_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Repertorizacion:" border="0" color="8388608" x="119" y="736" height="68" width="521"  name=repertorizacion_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=8 alignment="1" tabsequence=80 border="5" color="0" x="663" y="736" height="68" width="329" format="######"  name=repertorizacion editmask.mask="######" editmask.focusrectangle=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
text(band=detail alignment="0" text="Primera:" border="0" color="8388608" x="1079" y="736" height="64" width="251"  name=t_1  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="553648127" )
text(band=detail alignment="0" text="Curado:" border="0" color="8388608" x="1513" y="736" height="64" width="229"  name=t_2  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="553648127" )
column(band=detail id=10 alignment="0" tabsequence=100 border="0" color="8388608" x="1765" y="744" height="52" width="59" format="[general]"  name=curado checkbox.text="" checkbox.on="S" checkbox.off="N" checkbox.lefttext=yes checkbox.scale=no checkbox.threed=yes  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="553648127" )
column(band=detail id=9 alignment="0" tabsequence=90 border="0" color="8388608" x="1353" y="744" height="52" width="64" format="[general]"  name=primera checkbox.text="" checkbox.on="S" checkbox.off="N" checkbox.lefttext=yes checkbox.scale=no checkbox.threed=yes  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="553648127" )
htmltable(border="1" )
htmlgen(clientevents="1" clientvalidation="1" clientcomputedfields="1" clientformatting="0" clientscriptable="0" generatejavascript="1" )
 
        */
    }
}