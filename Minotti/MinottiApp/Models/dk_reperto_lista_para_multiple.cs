using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class dk_reperto_lista_para_multiple
    {
        public static string Sql = @"SELECT reperto_total_diag.reperto_total,        
                                                            reperto_total_diag.fecha, 
                                                            reperto_total_diag.comentario,
                                                            reperto_total_diag.paciente,
                                                            reperto_total_diag.marca,        
                                                            'N' seleccionado   
                                                    FROM reperto_total_diag  
                                                    WHERE reperto_total_diag.reperto_total >= ?    AND 
                                                          reperto_total_diag.reperto_total <= ?    AND 
                                                          reperto_total_diag.fecha >= YMD(SUBSTR(?, 7, 4), 
                                                          SUBSTR(?, 4, 2), SUBSTR(?, 1, 2))    AND 
                                                          reperto_total_diag.fecha <= YMD(SUBSTR(?, 7, 4), 
                                                          SUBSTR(?, 4, 2), SUBSTR(?, 1, 2))    AND 
                                                         ((reperto_total_diag.paciente = ?) OR (? = '0'))";

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
reperto_total_diag
        */

        /* ===== SRD original completo =====
﻿release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=196 color="81324524" )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=84 color="536870912"  height.autosize=yes)
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_total dbname="reperto_total_diag.reperto_total" )
 column=(type=date update=yes updatewhereclause=yes name=fecha dbname="reperto_total_diag.fecha" )
 column=(type=char(50) update=yes updatewhereclause=yes name=comentario dbname="reperto_total_diag.comentario" )
 column=(type=long update=yes updatewhereclause=yes name=paciente dbname="reperto_total_diag.paciente" )
 column=(type=char(1) update=yes updatewhereclause=yes name=marca dbname="reperto_total_diag.marca" )
 column=(type=char(1) updatewhereclause=yes name=seleccionado dbname="seleccionado" values="	S/	N" )
 retrieve="SELECT reperto_total_diag.reperto_total,
       reperto_total_diag.fecha,
       reperto_total_diag.comentario,
       reperto_total_diag.paciente,
       reperto_total_diag.marca,
       'N' seleccionado
  FROM reperto_total_diag
 WHERE reperto_total_diag.reperto_total >= :rep_desde
   AND reperto_total_diag.reperto_total <= :rep_hasta
   AND reperto_total_diag.fecha >= YMD(SUBSTR(:fecha_desde, 7, 4), SUBSTR(:fecha_desde, 4, 2), SUBSTR(:fecha_desde, 1, 2))
   AND reperto_total_diag.fecha <= YMD(SUBSTR(:fecha_hasta, 7, 4), SUBSTR(:fecha_hasta, 4, 2), SUBSTR(:fecha_hasta, 1, 2))
   AND ((reperto_total_diag.paciente = :paciente) OR (:paciente = '0'))
" update="reperto_total_diag" updatewhere=1 updatekeyinplace=no arguments=(("rep_desde", string),("rep_hasta", string),("fecha_desde", string),("fecha_hasta", string),("paciente", string)) )
text(band=header alignment="2" text="Paciente" border="6" color="8388608" x="389" y="124" height="64" width="1061"  name=paciente_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Comentario" border="6" color="8388608" x="1467" y="124" height="64" width="1061"  name=comentario_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Fecha" border="6" color="8388608" x="23" y="124" height="64" width="347"  name=fecha_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Seleccionar" border="6" color="8388608" x="2546" y="124" height="64" width="375"  name=t_1  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="553648127" )
text(band=header alignment="0" text="Seleccione las repertorizaciones guardadas para volver a repertorizar:" border="0" color="128" x="27" y="24" height="64" width="2889"  name=t_2  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" font.italic="1" background.mode="1" background.color="553648127" )
column(band=detail id=4 alignment="0" tabsequence=32766 border="0" color="0" x="389" y="4" height="76" width="1061" format="[general]"  name=paciente height.autosize=yes dddw.name=dw_pacientes dddw.displaycolumn=nombre dddw.datacolumn=paciente dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=3 alignment="0" tabsequence=32766 border="0" color="0" x="1467" y="4" height="76" width="1061" format="[general]"  name=comentario edit.limit=50 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=2 alignment="1" tabsequence=32766 border="0" color="0" x="23" y="4" height="76" width="347" format="[general]"  name=fecha edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=6 alignment="0" tabsequence=10 border="0" color="0" x="2706" y="16" height="52" width="59" format="[general]"  name=seleccionado checkbox.text="" checkbox.on="S" checkbox.off="N" checkbox.scale=no checkbox.threed=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
htmltable(border="1" )
htmlgen(clientevents="1" clientvalidation="1" clientcomputedfields="1" clientformatting="0" clientscriptable="0" generatejavascript="1" )
 
        */
    }
}