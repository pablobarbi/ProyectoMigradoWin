using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class d_reperto_total
    {
        public static string Sql = @"SELECT reperto_total.reperto_total,        
                                                            reperto_total.reperto_sintoma,
                                                            reperto_total.orden   
                                                    FROM reperto_total  
                                                    WHERE reperto_total.reperto_total = ?";



        public DataTable RetrieveToDataTable(object rep_total)
        {
            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
                // 1er parámetro → primer "?"
                var p1 = cmd.CreateParameter();
                p1.Value = rep_total ?? DBNull.Value;
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
reperto_total
        */

        /* ===== SRD original completo =====
﻿release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=388 color="536870912" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_total dbname="reperto_total.reperto_total" )
 column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_sintoma dbname="reperto_total.reperto_sintoma" )
 column=(type=long update=yes updatewhereclause=yes name=orden dbname="reperto_total.orden" )
 retrieve="SELECT reperto_total.reperto_total,
       reperto_total.reperto_sintoma,
       reperto_total.orden
  FROM reperto_total
 WHERE reperto_total.reperto_total = :rep_total
" update="reperto_total" updatewhere=1 updatekeyinplace=no arguments=(("rep_total", string)) )
text(band=detail alignment="1" text="Reperto Total:" border="0" color="0" x="37" y="4" height="64" width="425"  name=reperto_total_t  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=1 alignment="1" tabsequence=32766 border="0" color="0" x="480" y="4" height="76" width="329" format="[general]"  name=reperto_total edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Reperto Parcial:" border="0" color="0" x="37" y="140" height="64" width="425"  name=reperto_parcial_t  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Orden:" border="0" color="0" x="37" y="276" height="64" width="425"  name=orden_t  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=3 alignment="1" tabsequence=20 border="0" color="0" x="480" y="276" height="76" width="329" format="[general]"  name=orden edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=2 alignment="0" tabsequence=0 border="0" color="0" x="494" y="136" height="64" width="1161"  name=reperto_sintoma  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
htmltable(border="1" )
htmlgen(clientevents="1" clientvalidation="1" clientcomputedfields="1" clientformatting="0" clientscriptable="0" generatejavascript="1" )
 
        */
    }
}