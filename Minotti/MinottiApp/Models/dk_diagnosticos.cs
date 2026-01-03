using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class dk_diagnosticos
    {
        public static string Sql = @"SELECT diagnosticos.paciente, 
                                                            diagnosticos.diagnostico,
                                                            diagnosticos.fecha_visita,
                                                            pacientes.nombre   
                                                     FROM diagnosticos, pacientes  
                                                     WHERE diagnosticos.paciente = pacientes.paciente  
                                                     ORDER BY pacientes.nombre,diagnosticos.diagnostico";

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
diagnosticos
        */

        /* ===== SRD original completo =====
﻿release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=88 color="80269524" )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=84 color="536870912"  height.autosize=yes)
table(column=(type=long update=yes updatewhereclause=yes key=yes name=paciente dbname="diagnosticos.paciente" )
 column=(type=long update=yes updatewhereclause=yes key=yes name=diagnostico dbname="diagnosticos.diagnostico" )
 column=(type=date update=yes updatewhereclause=yes name=fecha_visita dbname="diagnosticos.fecha_visita" )
 column=(type=char(50) updatewhereclause=yes name=pacientes_nombre dbname="pacientes.nombre" )
 retrieve="SELECT diagnosticos.paciente,
       diagnosticos.diagnostico,
       diagnosticos.fecha_visita,
       pacientes.nombre
  FROM diagnosticos, pacientes
 WHERE diagnosticos.paciente = pacientes.paciente
 ORDER BY pacientes.nombre,
       diagnosticos.diagnostico
       " update="diagnosticos" updatewhere=1 updatekeyinplace=no )
text(band=header alignment="2" text="Fecha Visita" border="6" color="8388608" x="2085" y="12" height="68" width="384"  name=fecha_visita_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Diagnostico" border="6" color="8388608" x="1719" y="12" height="68" width="347"  name=diagnostico_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Paciente" border="6" color="8388608" x="18" y="12" height="68" width="1682"  name=paciente_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=3 alignment="0" tabsequence=32766 border="0" color="0" x="2085" y="4" height="76" width="384" format="[general]"  name=fecha_visita editmask.mask="dd/mm/yyyy" editmask.focusrectangle=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=2 alignment="1" tabsequence=32766 border="0" color="0" x="1719" y="4" height="76" width="347" format="[general]"  name=diagnostico edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=4 alignment="0" tabsequence=32766 border="0" color="0" x="18" y="4" height="76" width="1682" format="[general]"  name=pacientes_nombre height.autosize=yes edit.limit=0 edit.case=any edit.autoselect=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
htmltable(border="1" )
htmlgen(clientevents="1" clientvalidation="1" clientcomputedfields="1" clientformatting="0" clientscriptable="0" generatejavascript="1" )
 
        */
    }
}