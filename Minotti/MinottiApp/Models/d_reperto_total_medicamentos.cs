using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class d_reperto_total_medicamentos
    {
        public static string GetSqlDefinition() => @"SELECT reperto_total_med.reperto_total,        reperto_total_med.reperto_sintoma,        reperto_total_med.medicamento,        reperto_total_med.orden,        reperto_total_med.puntuacion   FROM reperto_total_med  WHERE reperto_total_med.reperto_total = :reperto_total    AND reperto_total_med.reperto_sintoma = :reperto_sintoma";

        public static DataTable Retrieve(OdbcConnection? externalConnection = null, params OdbcParameter[] parameters)
        {
            var sql = GetSqlDefinition();
            if (string.IsNullOrWhiteSpace(sql)) return new DataTable();
            bool created = false;
            var cn = externalConnection;
            if (cn == null)
            {
                cn = new OdbcConnection("DSN=" + Config.AppConfig.SqlAnywhereDsn + ";UID=" + Config.AppConfig.SqlAnywhereUid + ";PWD=" + Config.AppConfig.SqlAnywherePwd);
                created = true;
            }
            using var cmd = cn.CreateCommand();
            cmd.CommandText = sql;
            if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
            var dt = new DataTable();
            try
            {
                if (created) cn.Open();
                using var da = new OdbcDataAdapter((OdbcCommand)cmd);
                da.Fill(dt);
            }
            finally
            {
                if (created && cn != null) cn.Dispose();
            }
            return dt;
        }

        /* ===== UPDATE (tal cual en SRD) =====
reperto_total_med
        */

        /* ===== SRD original completo =====
﻿release 10.5;
datawindow(units=0 timer_interval=0 color=1090519039 processing=0 HTMLDW=no print.printername="" print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no rows_per_detail = 3 )
header(height=80 color="81324524" )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=84 color="536870912" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_total dbname="reperto_total_med.reperto_total" dbalias=".reperto_total" )
 column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_sintoma dbname="reperto_total_med.reperto_sintoma" dbalias=".reperto_sintoma" )
 column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento dbname="reperto_total_med.medicamento" dbalias=".medicamento" )
 column=(type=decimal(5) update=yes updatewhereclause=yes name=orden dbname="reperto_total_med.orden" dbalias=".orden" )
 column=(type=char(5) update=yes updatewhereclause=yes name=puntuacion dbname="reperto_total_med.puntuacion" dbalias=".puntuacion" )
 retrieve="SELECT reperto_total_med.reperto_total,
       reperto_total_med.reperto_sintoma,
       reperto_total_med.medicamento,
       reperto_total_med.orden,
       reperto_total_med.puntuacion
  FROM reperto_total_med
 WHERE reperto_total_med.reperto_total = :reperto_total
   AND reperto_total_med.reperto_sintoma = :reperto_sintoma
" update="reperto_total_med" updatewhere=1 updatekeyinplace=no arguments=(("reperto_total", string),("reperto_sintoma", string)) )
text(band=header alignment="2" text="Medicamento" border="6" color="8388608" x="23" y="4" height="64" width="416" html.valueishtml="0"  name=medicamento_t_1 visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Puntuación" border="6" color="8388608" x="805" y="4" height="64" width="370" html.valueishtml="0"  name=puntuacion_t_1 visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Orden" border="6" color="8388608" x="457" y="4" height="64" width="329" html.valueishtml="0"  name=orden_t_1 visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Orden" border="6" color="8388608" x="1678" y="4" height="64" width="329" html.valueishtml="0"  name=orden_t_2 visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Puntuación" border="6" color="8388608" x="2025" y="4" height="64" width="370" html.valueishtml="0"  name=puntuacion_t_2 visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Medicamento" border="6" color="8388608" x="1243" y="4" height="64" width="416" html.valueishtml="0"  name=medicamento_t_2 visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=3 alignment="0" tabsequence=32766 border="0" color="33554432" x="23" y="4" height="76" width="416" format="[general]" html.valueishtml="0" row_in_detail=1  name=medicamento_1 visible="1" edit.limit=10 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=5 alignment="2" tabsequence=32766 border="0" color="33554432" x="805" y="4" height="76" width="370" format="[general]" html.valueishtml="0" row_in_detail=1  name=puntuacion_1 visible="1" edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=4 alignment="2" tabsequence=32766 border="0" color="33554432" x="457" y="4" height="76" width="329" format="[general]" html.valueishtml="0" row_in_detail=1  name=orden_1 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=4 alignment="2" tabsequence=32766 border="0" color="33554432" x="1678" y="4" height="76" width="329" format="[general]" html.valueishtml="0" row_in_detail=2  name=orden_2 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=5 alignment="2" tabsequence=32766 border="0" color="33554432" x="2025" y="4" height="76" width="370" format="[general]" html.valueishtml="0" row_in_detail=2  name=puntuacion_2 visible="1" edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=3 alignment="0" tabsequence=32766 border="0" color="33554432" x="1243" y="4" height="76" width="416" format="[general]" html.valueishtml="0" row_in_detail=2  name=medicamento_2 visible="1" edit.limit=10 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
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