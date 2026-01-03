using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public static class r_header1
    {
        public const string Sql = @"SELECT count(*)     FROM dba.acc_usuarios";

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
(No se detectó bloque UPDATE en el SRD)
        */

        /* ===== SRD original completo =====
﻿release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="" print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=236 color="536870912" )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=0 color="536870912" )
table(column=(type=decimal(0) updatewhereclause=yes name=compute_0001 dbname="compute_0001" )
 retrieve="SELECT count(*) 
   FROM dba.acc_usuarios" )
bitmap(band=header filename="C:\Trabajo\Adrian\Power\hahnemann_2.bmp" x="14" y="12" height="204" width="288" border="0"  name=logo_izq visible="1" )
line(band=header x1="0" y1="224" x2="2985" y2="224"  name=l_1 visible="1" pen.style="0" pen.width="9" pen.color="0"  background.mode="2" background.color="16777215" )
text(band=header alignment="2" text="Programa de repertorización para Medicina Homeopática" border="0" color="0" x="325" y="132" height="64" width="2651" html.valueishtml="0"  name=t_2 visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
text(band=header alignment="2" text="MINOTTI 2000 PLUS versión 2020" border="0" color="0" x="325" y="24" height="80" width="2651" html.valueishtml="0"  name=t_1 visible="1"  font.face="Arial" font.height="-12" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
htmltable(border="0" )
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