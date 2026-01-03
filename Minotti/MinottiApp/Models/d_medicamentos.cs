using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class d_medicamentos
    {
        public static string Sql= @"SELECT medicamentos.medicamento,        medicamentos.descripcion,        medicamentos.observaciones,        medicamentos.imagen_asociada   FROM medicamentos  WHERE medicamentos.medicamento = :medicamento";

        public DataTable RetrieveToDataTable()
        {
            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
                // sin parámetros
            });
        }

        /* ===== UPDATE (tal cual en SRD) =====
medicamentos
        */

        /* ===== SRD original completo =====
﻿release 10.5;
datawindow(units=0 timer_interval=0 color=80269524 processing=0 HTMLDW=no print.printername="" print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=0 color="536870912" )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=1420 color="536870912" )
table(column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento dbname="medicamentos.medicamento" )
 column=(type=char(50) update=yes updatewhereclause=yes name=descripcion dbname="medicamentos.descripcion" )
 column=(type=char(32766) update=yes updatewhereclause=yes name=observaciones dbname="medicamentos.observaciones" )
 column=(type=char(255) update=yes updatewhereclause=yes name=imagen_asociada dbname="medicamentos.imagen_asociada" )
 retrieve="SELECT medicamentos.medicamento,
       medicamentos.descripcion,
       medicamentos.observaciones,
       medicamentos.imagen_asociada
  FROM medicamentos
 WHERE medicamentos.medicamento = :medicamento
" update="medicamentos" updatewhere=1 updatekeyinplace=no arguments=(("medicamento", string)) )
text(band=detail alignment="1" text="Medicamento:" border="0" color="8388608" x="55" y="16" height="68" width="411" html.valueishtml="0"  name=medicamento_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=1 alignment="0" tabsequence=10 border="5" color="0" x="494" y="16" height="68" width="411" format="[general]" html.valueishtml="0"  name=medicamento visible="1" edit.limit=10 edit.case=upper edit.focusrectangle=no edit.autoselect=no edit.required=yes edit.nilisnull=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=4 alignment="0" tabsequence=30 border="5" color="0" x="485" y="216" height="68" width="2144" format="[general]" html.valueishtml="0"  name=imagen_asociada visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=yes edit.nilisnull=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
button(band=detail text="Buscar imagen..." filename="" enabled=yes action="0" border="0" color="16777215" x="2089" y="304" height="100" width="530" vtextalign="0" htextalign="0"  name=b_imagen visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="128" )
bitmap(band=detail filename="C:\Trabajo\Adrian\imagenes\graficos_humanos\boca.jpg" x="2674" y="12" height="500" width="590" border="0"  name=p_1 visible="1" )
text(band=detail alignment="1" text="Observaciones:" border="0" color="8388608" x="37" y="444" height="68" width="443" html.valueishtml="0"  name=observaciones_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=3 alignment="0" tabsequence=40 border="5" color="0" x="27" y="536" height="860" width="3227" format="[general]" html.valueishtml="0"  name=observaciones visible="1" edit.limit=32000 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autovscroll=yes edit.vscrollbar=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
text(band=detail alignment="1" text="Imagen:" border="0" color="8388608" x="50" y="216" height="68" width="407" html.valueishtml="0"  name=t_1 visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Descripción:" border="0" color="8388608" x="59" y="116" height="68" width="407" html.valueishtml="0"  name=descripcion_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=2 alignment="0" tabsequence=20 border="5" color="0" x="494" y="116" height="68" width="2121" format="[general]" html.valueishtml="0"  name=descripcion visible="1" edit.limit=50 edit.case=upper edit.focusrectangle=no edit.autoselect=no edit.required=yes edit.nilisnull=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
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