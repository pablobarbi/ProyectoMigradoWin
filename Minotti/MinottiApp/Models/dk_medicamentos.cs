using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class dk_medicamentos
    {
        public static string Sql = @"SELECT medicamentos.medicamento,       
                                                            medicamentos.descripcion   
                                                     FROM medicamentos  
                                                    ORDER BY medicamentos.medicamento";

        public static DataTable RetrieveToDataTable(params object[] parametros)
        {


            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
         
            });
        }

        /* ===== UPDATE (tal cual en SRD) =====
medicamentos
        */

        /* ===== SRD original completo =====
﻿release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="" print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=84 color="80269524" )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=84 color="536870912" )
table(column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento dbname="medicamentos.medicamento" )
 column=(type=char(50) update=yes updatewhereclause=yes name=descripcion dbname="medicamentos.descripcion" )
 retrieve="SELECT medicamentos.medicamento,
       medicamentos.descripcion
  FROM medicamentos
 ORDER BY medicamentos.medicamento
" update="medicamentos" updatewhere=1 updatekeyinplace=no )
text(band=header alignment="2" text="Medicamento" border="6" color="8388608" x="9" y="8" height="68" width="489" html.valueishtml="0"  name=medicamento_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Descripción" border="6" color="8388608" x="517" y="8" height="68" width="1559" html.valueishtml="0"  name=descripcion_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=1 alignment="0" tabsequence=32766 border="0" color="0" x="9" y="4" height="76" width="489" format="[general]" html.valueishtml="0"  name=medicamento visible="1" editmask.mask="!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" editmask.focusrectangle=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=2 alignment="0" tabsequence=32766 border="0" color="0" x="517" y="4" height="76" width="1559" format="[general]" html.valueishtml="0"  name=descripcion visible="1" editmask.mask="!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" editmask.focusrectangle=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
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