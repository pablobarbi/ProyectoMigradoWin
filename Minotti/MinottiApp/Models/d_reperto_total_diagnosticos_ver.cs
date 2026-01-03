using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class d_reperto_total_diagnosticos_ver
    {
        public static string Sql = @"SELECT reperto_total_diag.reperto_total,
                                                            reperto_total_diag.fecha,
                                                            reperto_total_diag.comentario,
                                                            reperto_total_diag.paciente,
                                                            reperto_total_diag.marca   
                                                     FROM reperto_total_diag  
                                                     WHERE reperto_total_diag.reperto_total = ?";


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
﻿release 7;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=236 color="536870912" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_total dbname="reperto_total_diag.reperto_total" )
 column=(type=date update=yes updatewhereclause=yes name=fecha dbname="reperto_total_diag.fecha" )
 column=(type=char(50) update=yes updatewhereclause=yes name=comentario dbname="reperto_total_diag.comentario" )
 column=(type=long update=yes updatewhereclause=yes name=paciente dbname="reperto_total_diag.paciente" )
 column=(type=char(1) update=yes updatewhereclause=yes name=marca dbname="reperto_total_diag.marca" )
 retrieve="SELECT reperto_total_diag.reperto_total,
       reperto_total_diag.fecha,
       reperto_total_diag.comentario,
       reperto_total_diag.paciente,
       reperto_total_diag.marca
  FROM reperto_total_diag
 WHERE reperto_total_diag.reperto_total = :reperto_total
" update="reperto_total_diag" updatewhere=1 updatekeyinplace=no arguments=(("reperto_total", string)) )
text(band=detail alignment="1" text="Comentario:" border="0" color="8388608" x="41" y="128" height="64" width="370"  name=comentario_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Fecha:" border="0" color="8388608" x="41" y="20" height="64" width="370"  name=fecha_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Paciente:" border="0" color="8388608" x="887" y="20" height="64" width="370"  name=paciente_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=3 alignment="0" tabsequence=32766 border="0" color="0" x="430" y="128" height="76" width="2729" format="[general]"  name=comentario edit.limit=50 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="553648127" )
text(band=detail alignment="0" text="ea,ea,ea,ea,ea" border="0" color="0" x="1207" y="264" height="76" width="485"  name=xx_estilos_edicion visible="1~t0"  font.face="Arial" font.height="-12" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=2 alignment="0" tabsequence=32766 border="0" color="0" x="430" y="20" height="76" width="416" format="dd/mm/yyyy"  name=fecha editmask.required=yes editmask.mask="dd/mm/yyyy" editmask.focusrectangle=no  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="553648127" )
column(band=detail id=4 alignment="0" tabsequence=32766 border="0" color="0" x="1275" y="20" height="76" width="1888" format="[general]"  name=paciente dddw.name=dw_pacientes dddw.displaycolumn=nombre dddw.datacolumn=paciente dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.required=yes dddw.nilisnull=yes dddw.vscrollbar=yes  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="553648127" )
htmltable(border="1" )
htmlgen(clientevents="1" clientvalidation="1" clientcomputedfields="1" clientformatting="0" clientscriptable="0" generatejavascript="1" )
 
        */
    }
}