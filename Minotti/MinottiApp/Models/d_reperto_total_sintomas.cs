using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class d_reperto_total_sintomas
    {
        public static string Sql = @"SELECT reperto_total.reperto_total,
                                                            reperto_total.reperto_sintoma,
                                                            reperto_total.orden,
                                                            reperto_total_sin.capitulo,
                                                            reperto_total_sin.rubrica,
                                                            reperto_total_sin.subrubrica,
                                                            reperto_total_sin.subrubrica2,
                                                            reperto_total_sin.subrubrica3,
                                                            reperto_total_sin.subrubrica4,
                                                            reperto_total_sin.subrubrica5,
                                                            reperto_total_sin.subrubrica6,
                                                            reperto_total_sin.subrubrica7,
                                                            reperto_total_sin.subrubrica8, 
                                                            reperto_total_sin.subrubrica9,
                                                            reperto_total_sin.subrubrica10,
                                                            sub1.nombre,    
                                                            sub2.nombre, 
                                                            sub3.nombre, 
                                                            sub4.nombre, 
                                                            sub5.nombre,
                                                            sub6.nombre,
                                                            sub7.nombre,
                                                            sub8.nombre,   
                                                            sub9.nombre,
                                                            sub10.nombre   
                                                       FROM reperto_total,
                                                                reperto_total_sin 
                                                            left outer join subrubricas sub1 ON reperto_total_sin.subrubrica = sub1.subrubrica       
                                                            left outer join subrubricas sub2 ON reperto_total_sin.subrubrica2 = sub2.subrubrica       
                                                            left outer join subrubricas sub3 ON reperto_total_sin.subrubrica3 = sub3.subrubrica       
                                                            left outer join subrubricas sub4 ON reperto_total_sin.subrubrica4 = sub4.subrubrica       
                                                            left outer join subrubricas sub5 ON reperto_total_sin.subrubrica5 = sub5.subrubrica       
                                                            left outer join subrubricas sub6 ON reperto_total_sin.subrubrica6 = sub6.subrubrica       
                                                            left outer join subrubricas sub7 ON reperto_total_sin.subrubrica7 = sub7.subrubrica       
                                                            left outer join subrubricas sub8 ON reperto_total_sin.subrubrica8 = sub8.subrubrica       
                                                            left outer join subrubricas sub9 ON reperto_total_sin.subrubrica9 = sub9.subrubrica       
                                                            left outer join subrubricas sub10 ON reperto_total_sin.subrubrica10 = sub10.subrubrica  
                                                      WHERE reperto_total.reperto_sintoma = reperto_total_sin.reperto_sintoma    AND 
                                                            reperto_total.reperto_total = reperto_total_sin.reperto_total    AND 
                                                            reperto_total.reperto_total = :reperto_total  
                                                      ORDER BY reperto_total.reperto_sintoma;";

        /// <summary>
        /// Equivalente al retrieve del DataWindow:
        /// argumentos=(("reperto_total", string))
        /// Devuelve el detalle de subrúbricas para ese reperto_total.
        /// </summary>
        public static DataTable RetrieveByRepertoTotal(object reperto_total)
        {
            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
                var prm = cmd.CreateParameter();
                prm.Value = reperto_total ?? DBNull.Value;
                cmd.Parameters.Add(prm);
            });
        }

        /* ===== UPDATE (tal cual en SRD) =====
(No se detectó bloque UPDATE en el SRD)
        */

        /* ===== SRD original completo =====
﻿release 10.5;
datawindow(units=0 timer_interval=0 color=1073741824 processing=0 HTMLDW=no print.printername="" print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=80 color="67108864" )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=84 color="536870912" height.autosize=yes )
table(column=(type=decimal(0) updatewhereclause=yes name=reperto_total_reperto_total dbname="reperto_total.reperto_total" dbalias=".reperto_total" )
 column=(type=decimal(0) updatewhereclause=yes name=reperto_total_reperto_sintoma dbname="reperto_total.reperto_sintoma" dbalias=".reperto_sintoma" )
 column=(type=long updatewhereclause=yes name=reperto_total_orden dbname="reperto_total.orden" dbalias=".orden" )
 column=(type=decimal(0) updatewhereclause=yes name=reperto_total_sin_capitulo dbname="reperto_total_sin.capitulo" dbalias=".capitulo" )
 column=(type=decimal(0) updatewhereclause=yes name=reperto_total_sin_rubrica dbname="reperto_total_sin.rubrica" dbalias=".rubrica" )
 column=(type=decimal(0) updatewhereclause=yes name=reperto_total_sin_subrubrica dbname="reperto_total_sin.subrubrica" dbalias=".subrubrica" )
 column=(type=decimal(0) updatewhereclause=yes name=reperto_total_sin_subrubrica2 dbname="reperto_total_sin.subrubrica2" dbalias=".subrubrica2" )
 column=(type=decimal(0) updatewhereclause=yes name=reperto_total_sin_subrubrica3 dbname="reperto_total_sin.subrubrica3" dbalias=".subrubrica3" )
 column=(type=decimal(0) updatewhereclause=yes name=reperto_total_sin_subrubrica4 dbname="reperto_total_sin.subrubrica4" dbalias=".subrubrica4" )
 column=(type=decimal(0) updatewhereclause=yes name=reperto_total_sin_subrubrica5 dbname="reperto_total_sin.subrubrica5" dbalias=".subrubrica5" )
 column=(type=decimal(0) updatewhereclause=yes name=reperto_total_sin_subrubrica6 dbname="reperto_total_sin.subrubrica6" dbalias=".subrubrica6" )
 column=(type=decimal(0) updatewhereclause=yes name=reperto_total_sin_subrubrica7 dbname="reperto_total_sin.subrubrica7" dbalias=".subrubrica7" )
 column=(type=decimal(0) updatewhereclause=yes name=reperto_total_sin_subrubrica8 dbname="reperto_total_sin.subrubrica8" dbalias=".subrubrica8" )
 column=(type=decimal(0) updatewhereclause=yes name=reperto_total_sin_subrubrica9 dbname="reperto_total_sin.subrubrica9" dbalias=".subrubrica9" )
 column=(type=decimal(0) updatewhereclause=yes name=reperto_total_sin_subrubrica10 dbname="reperto_total_sin.subrubrica10" dbalias=".subrubrica10" )
 column=(type=char(255) updatewhereclause=yes name=subrubricas_nombre dbname="subrubricas.nombre" dbalias="sub1.nombre" )
 column=(type=char(255) updatewhereclause=yes name=subrubricas_nombre dbname="subrubricas.nombre" dbalias="sub2.nombre" )
 column=(type=char(255) updatewhereclause=yes name=subrubricas_nombre dbname="subrubricas.nombre" dbalias="sub3.nombre" )
 column=(type=char(255) updatewhereclause=yes name=subrubricas_nombre dbname="subrubricas.nombre" dbalias="sub4.nombre" )
 column=(type=char(255) updatewhereclause=yes name=subrubricas_nombre dbname="subrubricas.nombre" dbalias="sub5.nombre" )
 column=(type=char(255) updatewhereclause=yes name=subrubricas_nombre dbname="subrubricas.nombre" dbalias="sub6.nombre" )
 column=(type=char(255) updatewhereclause=yes name=subrubricas_nombre dbname="subrubricas.nombre" dbalias="sub7.nombre" )
 column=(type=char(255) updatewhereclause=yes name=subrubricas_nombre dbname="subrubricas.nombre" dbalias="sub8.nombre" )
 column=(type=char(255) updatewhereclause=yes name=subrubricas_nombre dbname="subrubricas.nombre" dbalias="sub9.nombre" )
 column=(type=char(255) updatewhereclause=yes name=subrubricas_nombre dbname="subrubricas.nombre" dbalias="sub10.nombre" )
 retrieve="SELECT reperto_total.reperto_total,
       reperto_total.reperto_sintoma,
       reperto_total.orden,
       reperto_total_sin.capitulo,
       reperto_total_sin.rubrica,
       reperto_total_sin.subrubrica,
       reperto_total_sin.subrubrica2,
       reperto_total_sin.subrubrica3,
       reperto_total_sin.subrubrica4,
       reperto_total_sin.subrubrica5,
       reperto_total_sin.subrubrica6,
       reperto_total_sin.subrubrica7,
       reperto_total_sin.subrubrica8,
       reperto_total_sin.subrubrica9,
       reperto_total_sin.subrubrica10,
       sub1.nombre,
       sub2.nombre,
       sub3.nombre,
       sub4.nombre,
       sub5.nombre,
       sub6.nombre,
       sub7.nombre,
       sub8.nombre,
       sub9.nombre,
       sub10.nombre
  FROM reperto_total,
       reperto_total_sin
      left outer join subrubricas sub1 ON reperto_total_sin.subrubrica = sub1.subrubrica
      left outer join subrubricas sub2 ON reperto_total_sin.subrubrica2 = sub2.subrubrica
      left outer join subrubricas sub3 ON reperto_total_sin.subrubrica3 = sub3.subrubrica
      left outer join subrubricas sub4 ON reperto_total_sin.subrubrica4 = sub4.subrubrica
      left outer join subrubricas sub5 ON reperto_total_sin.subrubrica5 = sub5.subrubrica
      left outer join subrubricas sub6 ON reperto_total_sin.subrubrica6 = sub6.subrubrica
      left outer join subrubricas sub7 ON reperto_total_sin.subrubrica7 = sub7.subrubrica
      left outer join subrubricas sub8 ON reperto_total_sin.subrubrica8 = sub8.subrubrica
      left outer join subrubricas sub9 ON reperto_total_sin.subrubrica9 = sub9.subrubrica
      left outer join subrubricas sub10 ON reperto_total_sin.subrubrica10 = sub10.subrubrica
 WHERE reperto_total.reperto_sintoma = reperto_total_sin.reperto_sintoma
   AND reperto_total.reperto_total = reperto_total_sin.reperto_total
   AND reperto_total.reperto_total = :reperto_total
 ORDER BY reperto_total.reperto_sintoma;

" arguments=(("reperto_total", string)) )
text(band=header alignment="2" text="Subrúbrica" border="6" color="8388608" x="11749" y="4" height="64" width="1029" html.valueishtml="0"  name=subrubrica10_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Subrúbrica" border="6" color="8388608" x="10702" y="4" height="64" width="1029" html.valueishtml="0"  name=subrubrica9_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Subrúbrica" border="6" color="8388608" x="9655" y="4" height="64" width="1029" html.valueishtml="0"  name=subrubrica8_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Subrúbrica" border="6" color="8388608" x="8608" y="4" height="64" width="1029" html.valueishtml="0"  name=subrubrica7_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Subrúbrica" border="6" color="8388608" x="7561" y="4" height="64" width="1029" html.valueishtml="0"  name=subrubrica6_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Subrúbrica" border="6" color="8388608" x="6514" y="4" height="64" width="1029" html.valueishtml="0"  name=subrubrica5_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Subrúbrica" border="6" color="8388608" x="5467" y="4" height="64" width="1029" html.valueishtml="0"  name=subrubrica4_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Subrúbrica" border="6" color="8388608" x="4421" y="4" height="64" width="1029" html.valueishtml="0"  name=subrubrica3_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Subrúbrica" border="6" color="8388608" x="3374" y="4" height="64" width="1029" html.valueishtml="0"  name=subrubrica2_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Orden" border="6" color="8388608" x="9" y="4" height="64" width="206" html.valueishtml="0"  name=reperto_total_orden_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="CapÍtulo" border="6" color="8388608" x="233" y="4" height="64" width="1029" html.valueishtml="0"  name=reperto_parcial_capitulo_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Rúbrica" border="6" color="8388608" x="1280" y="4" height="64" width="1029" html.valueishtml="0"  name=reperto_parcial_rubrica_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Subrúbrica" border="6" color="8388608" x="2327" y="4" height="64" width="1029" html.valueishtml="0"  name=reperto_parcial_subrubrica_t visible="1"  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=3 alignment="1" tabsequence=32766 border="0" color="33554432" x="9" y="0" height="76" width="206" format="[general]" html.valueishtml="0"  name=reperto_total_orden visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=4 alignment="0" tabsequence=32766 border="0" color="33554432" x="233" y="4" height="76" width="1029" format="[general]" html.valueishtml="0"  name=reperto_total_sin_capitulo visible="1" height.autosize=yes dddw.name=dw_capitulos dddw.displaycolumn=nombre dddw.datacolumn=capitulo dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=5 alignment="0" tabsequence=32766 border="0" color="33554432" x="1280" y="4" height="76" width="1029" format="[general]" html.valueishtml="0"  name=reperto_total_sin_rubrica visible="1" height.autosize=yes dddw.name=dw_rubricas dddw.displaycolumn=nombre dddw.datacolumn=rubrica dddw.percentwidth=0 dddw.lines=0 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=16 alignment="0" tabsequence=32766 border="0" color="33554432" x="2327" y="8" height="72" width="1029" format="[general]" html.valueishtml="0"  name=subrubricas_nombre visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=17 alignment="0" tabsequence=32766 border="0" color="33554432" x="3374" y="8" height="64" width="1033" format="[general]" html.valueishtml="0"  name=subrubricas_nombre_1 visible="1" height.autosize=yes edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=18 alignment="0" tabsequence=32766 border="0" color="33554432" x="4425" y="8" height="64" width="1033" format="[general]" html.valueishtml="0"  name=subrubricas_nombre_2 visible="1" height.autosize=yes edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=19 alignment="0" tabsequence=32766 border="0" color="33554432" x="5477" y="8" height="64" width="1033" format="[general]" html.valueishtml="0"  name=subrubricas_nombre_3 visible="1" height.autosize=yes edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=20 alignment="0" tabsequence=32766 border="0" color="33554432" x="6528" y="8" height="64" width="1033" format="[general]" html.valueishtml="0"  name=subrubricas_nombre_4 visible="1" height.autosize=yes edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=21 alignment="0" tabsequence=32766 border="0" color="33554432" x="7579" y="8" height="64" width="1033" format="[general]" html.valueishtml="0"  name=subrubricas_nombre_5 visible="1" height.autosize=yes edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=22 alignment="0" tabsequence=32766 border="0" color="33554432" x="8635" y="8" height="64" width="1033" format="[general]" html.valueishtml="0"  name=subrubricas_nombre_6 visible="1" height.autosize=yes edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=23 alignment="0" tabsequence=32766 border="0" color="33554432" x="9687" y="8" height="64" width="1033" format="[general]" html.valueishtml="0"  name=subrubricas_nombre_7 visible="1" height.autosize=yes edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=24 alignment="0" tabsequence=32766 border="0" color="33554432" x="10738" y="8" height="64" width="1033" format="[general]" html.valueishtml="0"  name=subrubricas_nombre_8 visible="1" height.autosize=yes edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=25 alignment="0" tabsequence=32766 border="0" color="33554432" x="11790" y="8" height="64" width="1033" format="[general]" html.valueishtml="0"  name=subrubricas_nombre_9 visible="1" height.autosize=yes edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
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