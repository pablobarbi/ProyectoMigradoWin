using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class d_reperto_total_diagnosticos_multiple
    {
        public static string Sql = @"SELECT reperto_total_diag.reperto_total,
                                                            reperto_total_diag.fecha,
                                                            reperto_total_diag.comentario,
                                                            reperto_total_diag.paciente,
                                                            reperto_total_diag.marca   
                                                    FROM reperto_total_diag  
                                                    WHERE reperto_total_diag.reperto_total = :reperto_total";


        public DataTable RetrieveToDataTable(object reperto_total)
        {
            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
                // 1er parámetro → primer "?"
                var p1 = cmd.CreateParameter();
                p1.Value = reperto_total ?? DBNull.Value;
                cmd.Parameters.Add(p1);


            });
        }


        //public static DataTable Retrieve(OdbcConnection? externalConnection = null, params OdbcParameter[] parameters)
        //{
        //    var sql = GetSqlDefinition();
        //    if (string.IsNullOrWhiteSpace(sql)) return new DataTable();
        //    bool created = false;
        //    var cn = externalConnection;
        //    if (cn == null)
        //    {
        //        cn = new OdbcConnection("DSN=" + Config.AppConfig.SqlAnywhereDsn + ";UID=" + Config.AppConfig.SqlAnywhereUid + ";PWD=" + Config.AppConfig.SqlAnywherePwd);
        //        created = true;
        //    }
        //    using var cmd = cn.CreateCommand();
        //    cmd.CommandText = sql;
        //    if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
        //    var dt = new DataTable();
        //    try
        //    {
        //        if (created) cn.Open();
        //        using var da = new OdbcDataAdapter((OdbcCommand)cmd);
        //        da.Fill(dt);
        //    }
        //    finally
        //    {
        //        if (created && cn != null) cn.Dispose();
        //    }
        //    return dt;
        //}

        /* ===== UPDATE (tal cual en SRD) =====
reperto_total_diag
        */

        /* ===== SRD original completo =====
﻿release 10.5;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.printername="" print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=88 color="536870912" )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=80 color="536870912" height.autosize=yes )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_total dbname="reperto_total_diag.reperto_total" dbalias=".reperto_total" )
 column=(type=date update=yes updatewhereclause=yes name=fecha dbname="reperto_total_diag.fecha" dbalias=".fecha" )
 column=(type=char(50) update=yes updatewhereclause=yes name=comentario dbname="reperto_total_diag.comentario" dbalias=".comentario" )
 column=(type=long update=yes updatewhereclause=yes name=paciente dbname="reperto_total_diag.paciente" dbalias=".paciente" )
 column=(type=char(1) update=yes updatewhereclause=yes name=marca dbname="reperto_total_diag.marca" dbalias=".marca" )
 retrieve="SELECT reperto_total_diag.reperto_total,
       reperto_total_diag.fecha,
       reperto_total_diag.comentario,
       reperto_total_diag.paciente,
       reperto_total_diag.marca
  FROM reperto_total_diag
 WHERE reperto_total_diag.reperto_total = :reperto_total
" update="reperto_total_diag" updatewhere=0 updatekeyinplace=no arguments=(("reperto_total", string)) )
text(band=header alignment="2" text="Nro." border="6" color="8388608" x="18" y="12" height="64" width="416" html.valueishtml="0"  name=t_1 visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="553648127" )
text(band=header alignment="2" text="Fecha" border="6" color="8388608" x="457" y="12" height="64" width="416" html.valueishtml="0"  name=fecha_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Paciente" border="6" color="8388608" x="896" y="12" height="64" width="1358" html.valueishtml="0"  name=paciente_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Comentario" border="6" color="8388608" x="2277" y="12" height="64" width="1234" html.valueishtml="0"  name=comentario_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=3 alignment="0" tabsequence=30 border="5" color="0" x="2277" y="8" height="64" width="1234" format="[general]" html.valueishtml="0"  name=comentario visible="1" height.autosize=yes edit.limit=50 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=4 alignment="1" tabsequence=20 border="5" color="0" x="896" y="8" height="64" width="1358" format="[general]" html.valueishtml="0"  name=paciente visible="1" height.autosize=yes dddw.name=dw_pacientes dddw.displaycolumn=nombre dddw.datacolumn=paciente dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.required=yes dddw.nilisnull=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=2 alignment="1" tabsequence=10 border="5" color="0" x="457" y="8" height="64" width="416" format="dd/mm/yyyy" html.valueishtml="0"  name=fecha visible="1" editmask.required=yes editmask.mask="dd/mm/yyyy" editmask.focusrectangle=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=1 alignment="1" tabsequence=32766 border="5" color="0" x="18" y="8" height="64" width="416" format="[general]" html.valueishtml="0"  name=reperto_total visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.nilisnull=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
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