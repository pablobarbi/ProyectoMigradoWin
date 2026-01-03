using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class dk_reperto_total_tabla_med
    {
        public static string Sql= @"SELECT reperto_total_med.reperto_total,        
                                                            reperto_total_med.reperto_sintoma, 
                                                            reperto_total_med.medicamento, 
                                                            reperto_total_med.puntuacion,       
                                                            0 AS valor1,
                                                            0 AS valor2,    
                                                            0 AS valor3, 
                                                            0 AS valor4,
                                                            0 AS valor5,
                                                            0 AS valor6,
                                                            0 AS valor7,
                                                            0 AS valor8,
                                                            0 AS valor9,  
                                                            0 AS valor10,
                                                            0 AS valor11, 
                                                            0 AS valor12,
                                                            0 AS valor13,        
                                                            0 AS valor14,
                                                            0 AS valor15,
                                                            0 AS valor16,
                                                            0 AS valor17,
                                                            0 AS valor18,
                                                            0 AS valor19,
                                                            0 AS valor20,
                                                            0 AS valor21,
                                                            0 AS valor22,
                                                            0 AS valor23,
                                                            0 AS valor24,        
                                                            0 AS valor25,        
                                                            0 AS valor26,        
                                                            0 AS valor27,        
                                                            0 AS valor28,        
                                                            0 AS valor29,        
                                                            0 AS valor30,        
                                                            0 AS valor31,        
                                                            0 AS valor32,       
                                                            0 AS valor33,        
                                                            0 AS valor34,        
                                                            0 AS valor35,        
                                                            0 AS valor36,        
                                                            0 AS valor37,        
                                                            0 AS valor38,        
                                                            0 AS valor39,        
                                                            0 AS valor40,        
                                                            0 AS valor41,        
                                                            0 AS valor42,        
                                                            0 AS valor43,        
                                                            0 AS valor44,        
                                                            0 AS valor45,        
                                                            0 AS valor46,        
                                                            0 AS valor47,      
                                                            0 AS valor48,        
                                                            0 AS valor49,      
                                                            0 AS valor50,   
                                                            0 AS valor51,    
                                                            0 AS valor52,     
                                                            0 AS valor53,     
                                                            0 AS valor54,     
                                                            0 AS valor55,      
                                                            0 AS valor56,  
                                                            0 AS valor57,   
                                                            0 AS valor58,    
                                                            0 AS valor59,    
                                                            0 AS valor60,    
                                                            0 AS valor61,    
                                                            0 AS valor62,     
                                                            0 AS valor63,     
                                                            0 AS valor64,     
                                                            0 AS valor65,    
                                                            0 AS valor66,    
                                                            0 AS valor67,     
                                                            0 AS valor68,      
                                                            0 AS valor69,      
                                                            0 AS valor70,    
                                                            reperto_total_med.orden, 
                                                            reperto_total_med.valor,   
                                                            0 AS cantidad   
                                                            FROM reperto_total_med";

        public static DataTable RetrieveToDataTable(params object[] parametros)
        {
            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
                
            });
        }

        /* ===== UPDATE (tal cual en SRD) =====
reperto_total_med
        */

        /* ===== SRD original completo =====
﻿release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="" print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=80 color="81324524" )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=88 color="536870912" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_total dbname="reperto_total_med.reperto_total" )
 column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_sintoma dbname="reperto_total_med.reperto_sintoma" )
 column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento dbname="reperto_total_med.medicamento" )
 column=(type=char(5) update=yes updatewhereclause=yes name=puntuacion dbname="reperto_total_med.puntuacion" )
 column=(type=long updatewhereclause=yes name=valor1 dbname="valor1" )
 column=(type=long updatewhereclause=yes name=valor2 dbname="valor2" )
 column=(type=long updatewhereclause=yes name=valor3 dbname="valor3" )
 column=(type=long updatewhereclause=yes name=valor4 dbname="valor4" )
 column=(type=long updatewhereclause=yes name=valor5 dbname="valor5" )
 column=(type=long updatewhereclause=yes name=valor6 dbname="valor6" )
 column=(type=long updatewhereclause=yes name=valor7 dbname="valor7" )
 column=(type=long updatewhereclause=yes name=valor8 dbname="valor8" )
 column=(type=long updatewhereclause=yes name=valor9 dbname="valor9" )
 column=(type=long updatewhereclause=yes name=valor10 dbname="valor10" )
 column=(type=long updatewhereclause=yes name=valor11 dbname="valor11" )
 column=(type=long updatewhereclause=yes name=valor12 dbname="valor12" )
 column=(type=long updatewhereclause=yes name=valor13 dbname="valor13" )
 column=(type=long updatewhereclause=yes name=valor14 dbname="valor14" )
 column=(type=long updatewhereclause=yes name=valor15 dbname="valor15" )
 column=(type=long updatewhereclause=yes name=valor16 dbname="valor16" )
 column=(type=long updatewhereclause=yes name=valor17 dbname="valor17" )
 column=(type=long updatewhereclause=yes name=valor18 dbname="valor18" )
 column=(type=long updatewhereclause=yes name=valor19 dbname="valor19" )
 column=(type=long updatewhereclause=yes name=valor20 dbname="valor20" )
 column=(type=long updatewhereclause=yes name=valor21 dbname="valor21" )
 column=(type=long updatewhereclause=yes name=valor22 dbname="valor22" )
 column=(type=long updatewhereclause=yes name=valor23 dbname="valor23" )
 column=(type=long updatewhereclause=yes name=valor24 dbname="valor24" )
 column=(type=long updatewhereclause=yes name=valor25 dbname="valor25" )
 column=(type=long updatewhereclause=yes name=valor26 dbname="valor26" )
 column=(type=long updatewhereclause=yes name=valor27 dbname="valor27" )
 column=(type=long updatewhereclause=yes name=valor28 dbname="valor28" )
 column=(type=long updatewhereclause=yes name=valor29 dbname="valor29" )
 column=(type=long updatewhereclause=yes name=valor30 dbname="valor30" )
 column=(type=long updatewhereclause=yes name=valor31 dbname="valor31" )
 column=(type=long updatewhereclause=yes name=valor32 dbname="valor32" )
 column=(type=long updatewhereclause=yes name=valor33 dbname="valor33" )
 column=(type=long updatewhereclause=yes name=valor34 dbname="valor34" )
 column=(type=long updatewhereclause=yes name=valor35 dbname="valor35" )
 column=(type=long updatewhereclause=yes name=valor36 dbname="valor36" )
 column=(type=long updatewhereclause=yes name=valor37 dbname="valor37" )
 column=(type=long updatewhereclause=yes name=valor38 dbname="valor38" )
 column=(type=long updatewhereclause=yes name=valor39 dbname="valor39" )
 column=(type=long updatewhereclause=yes name=valor40 dbname="valor40" )
 column=(type=long updatewhereclause=yes name=valor41 dbname="valor41" )
 column=(type=long updatewhereclause=yes name=valor42 dbname="valor42" )
 column=(type=long updatewhereclause=yes name=valor43 dbname="valor43" )
 column=(type=long updatewhereclause=yes name=valor44 dbname="valor44" )
 column=(type=long updatewhereclause=yes name=valor45 dbname="valor45" )
 column=(type=long updatewhereclause=yes name=valor46 dbname="valor46" )
 column=(type=long updatewhereclause=yes name=valor47 dbname="valor47" )
 column=(type=long updatewhereclause=yes name=valor48 dbname="valor48" )
 column=(type=long updatewhereclause=yes name=valor49 dbname="valor49" )
 column=(type=long updatewhereclause=yes name=valor50 dbname="valor50" )
 column=(type=long updatewhereclause=yes name=valor51 dbname="valor51" )
 column=(type=long updatewhereclause=yes name=valor52 dbname="valor52" )
 column=(type=long updatewhereclause=yes name=valor53 dbname="valor53" )
 column=(type=long updatewhereclause=yes name=valor54 dbname="valor54" )
 column=(type=long updatewhereclause=yes name=valor55 dbname="valor55" )
 column=(type=long updatewhereclause=yes name=valor56 dbname="valor56" )
 column=(type=long updatewhereclause=yes name=valor57 dbname="valor57" )
 column=(type=long updatewhereclause=yes name=valor58 dbname="valor58" )
 column=(type=long updatewhereclause=yes name=valor59 dbname="valor59" )
 column=(type=long updatewhereclause=yes name=valor60 dbname="valor60" )
 column=(type=long updatewhereclause=yes name=valor61 dbname="valor61" )
 column=(type=long updatewhereclause=yes name=valor62 dbname="valor62" )
 column=(type=long updatewhereclause=yes name=valor63 dbname="valor63" )
 column=(type=long updatewhereclause=yes name=valor64 dbname="valor64" )
 column=(type=long updatewhereclause=yes name=valor65 dbname="valor65" )
 column=(type=long updatewhereclause=yes name=valor66 dbname="valor66" )
 column=(type=long updatewhereclause=yes name=valor67 dbname="valor67" )
 column=(type=long updatewhereclause=yes name=valor68 dbname="valor68" )
 column=(type=long updatewhereclause=yes name=valor69 dbname="valor69" )
 column=(type=long updatewhereclause=yes name=valor70 dbname="valor70" )
 column=(type=decimal(5) update=yes updatewhereclause=yes name=orden dbname="reperto_total_med.orden" )
 column=(type=long update=yes updatewhereclause=yes name=valor dbname="reperto_total_med.valor" )
 column=(type=long updatewhereclause=yes name=cantidad dbname="cantidad" )
 retrieve="SELECT reperto_total_med.reperto_total,
       reperto_total_med.reperto_sintoma,
       reperto_total_med.medicamento,
       reperto_total_med.puntuacion,
       0 AS valor1,
       0 AS valor2,
       0 AS valor3,
       0 AS valor4,
       0 AS valor5,
       0 AS valor6,
       0 AS valor7,
       0 AS valor8,
       0 AS valor9,
       0 AS valor10,
       0 AS valor11,
       0 AS valor12,
       0 AS valor13,
       0 AS valor14,
       0 AS valor15,
       0 AS valor16,
       0 AS valor17,
       0 AS valor18,
       0 AS valor19,
       0 AS valor20,
       0 AS valor21,
       0 AS valor22,
       0 AS valor23,
       0 AS valor24,
       0 AS valor25,
       0 AS valor26,
       0 AS valor27,
       0 AS valor28,
       0 AS valor29,
       0 AS valor30,
       0 AS valor31,
       0 AS valor32,
       0 AS valor33,
       0 AS valor34,
       0 AS valor35,
       0 AS valor36,
       0 AS valor37,
       0 AS valor38,
       0 AS valor39,
       0 AS valor40,
       0 AS valor41,
       0 AS valor42,
       0 AS valor43,
       0 AS valor44,
       0 AS valor45,
       0 AS valor46,
       0 AS valor47,
       0 AS valor48,
       0 AS valor49,
       0 AS valor50,
       0 AS valor51,
       0 AS valor52,
       0 AS valor53,
       0 AS valor54,
       0 AS valor55,
       0 AS valor56,
       0 AS valor57,
       0 AS valor58,
       0 AS valor59,
       0 AS valor60,
       0 AS valor61,
       0 AS valor62,
       0 AS valor63,
       0 AS valor64,
       0 AS valor65,
       0 AS valor66,
       0 AS valor67,
       0 AS valor68,
       0 AS valor69,
       0 AS valor70,
       reperto_total_med.orden,
       reperto_total_med.valor,
      0 AS cantidad
  FROM reperto_total_med
" update="reperto_total_med" updatewhere=0 updatekeyinplace=no )
text(band=header alignment="2" text="Puntuación" border="2" color="8388608" x="393" y="8" height="64" width="311" html.valueishtml="0"  name=puntuacion_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text=" 1" border="2" color="8388608" x="722" y="8" height="64" width="174" html.valueishtml="0"  name=valor1_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text=" 2" border="2" color="8388608" x="914" y="8" height="64" width="174" html.valueishtml="0"  name=valor2_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text=" 3" border="2" color="8388608" x="1106" y="8" height="64" width="174" html.valueishtml="0"  name=valor3_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text=" 4" border="2" color="8388608" x="1298" y="8" height="64" width="174" html.valueishtml="0"  name=valor4_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text=" 5" border="2" color="8388608" x="1490" y="8" height="64" width="174" html.valueishtml="0"  name=valor5_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text=" 6" border="2" color="8388608" x="1682" y="8" height="64" width="174" html.valueishtml="0"  name=valor6_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text=" 7" border="2" color="8388608" x="1874" y="8" height="64" width="174" html.valueishtml="0"  name=valor7_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text=" 8" border="2" color="8388608" x="2066" y="8" height="64" width="174" html.valueishtml="0"  name=valor8_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text=" 9" border="2" color="8388608" x="2258" y="8" height="64" width="174" html.valueishtml="0"  name=valor9_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="10" border="2" color="8388608" x="2450" y="8" height="64" width="192" html.valueishtml="0"  name=valor10_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="11" border="2" color="8388608" x="2661" y="8" height="64" width="192" html.valueishtml="0"  name=valor11_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="12" border="2" color="8388608" x="2871" y="8" height="64" width="192" html.valueishtml="0"  name=valor12_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="13" border="2" color="8388608" x="3081" y="8" height="64" width="192" html.valueishtml="0"  name=valor13_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="14" border="2" color="8388608" x="3291" y="8" height="64" width="192" html.valueishtml="0"  name=valor14_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="15" border="2" color="8388608" x="3502" y="8" height="64" width="192" html.valueishtml="0"  name=valor15_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="16" border="2" color="8388608" x="3712" y="8" height="64" width="192" html.valueishtml="0"  name=valor16_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="17" border="2" color="8388608" x="3922" y="8" height="64" width="192" html.valueishtml="0"  name=valor17_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="20" border="2" color="8388608" x="4549" y="8" height="64" width="192" html.valueishtml="0"  name=valor20_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="21" border="2" color="8388608" x="4759" y="8" height="64" width="192" html.valueishtml="0"  name=valor21_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="19" border="2" color="8388608" x="4338" y="8" height="64" width="192" html.valueishtml="0"  name=valor19_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="18" border="2" color="8388608" x="4128" y="8" height="64" width="192" html.valueishtml="0"  name=valor18_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Medicamento" border="2" color="8388608" x="18" y="8" height="64" width="357" html.valueishtml="0"  name=medicamento_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=5 alignment="1" tabsequence=32766 border="2" color="0" x="722" y="8" height="76" width="174" format="[general]" html.valueishtml="0"  name=valor1 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=6 alignment="1" tabsequence=32766 border="2" color="0" x="914" y="8" height="76" width="174" format="[general]" html.valueishtml="0"  name=valor2 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=7 alignment="1" tabsequence=32766 border="2" color="0" x="1106" y="8" height="76" width="174" format="[general]" html.valueishtml="0"  name=valor3 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=8 alignment="1" tabsequence=32766 border="2" color="0" x="1298" y="8" height="76" width="174" format="[general]" html.valueishtml="0"  name=valor4 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=9 alignment="1" tabsequence=32766 border="2" color="0" x="1490" y="8" height="76" width="174" format="[general]" html.valueishtml="0"  name=valor5 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=10 alignment="1" tabsequence=32766 border="2" color="0" x="1682" y="8" height="76" width="174" format="[general]" html.valueishtml="0"  name=valor6 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=11 alignment="1" tabsequence=32766 border="2" color="0" x="1874" y="8" height="76" width="174" format="[general]" html.valueishtml="0"  name=valor7 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=12 alignment="1" tabsequence=32766 border="2" color="0" x="2066" y="8" height="76" width="174" format="[general]" html.valueishtml="0"  name=valor8 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=13 alignment="1" tabsequence=32766 border="2" color="0" x="2258" y="8" height="76" width="174" format="[general]" html.valueishtml="0"  name=valor9 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=14 alignment="1" tabsequence=32766 border="2" color="0" x="2450" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor10 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=15 alignment="1" tabsequence=32766 border="2" color="0" x="2661" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor11 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=16 alignment="1" tabsequence=32766 border="2" color="0" x="2871" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor12 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=17 alignment="1" tabsequence=32766 border="2" color="0" x="3081" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor13 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=18 alignment="1" tabsequence=32766 border="2" color="0" x="3291" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor14 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=19 alignment="1" tabsequence=32766 border="2" color="0" x="3502" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor15 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=20 alignment="1" tabsequence=32766 border="2" color="0" x="3712" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor16 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=21 alignment="1" tabsequence=32766 border="2" color="0" x="3922" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor17 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=24 alignment="1" tabsequence=32766 border="2" color="0" x="4549" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor20 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=25 alignment="1" tabsequence=32766 border="2" color="0" x="4759" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor21 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=26 alignment="1" tabsequence=32766 border="2" color="0" x="4969" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor22 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=27 alignment="1" tabsequence=32766 border="2" color="0" x="5179" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor23 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=28 alignment="1" tabsequence=32766 border="2" color="0" x="5390" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor24 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=29 alignment="1" tabsequence=32766 border="2" color="0" x="5600" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor25 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=30 alignment="1" tabsequence=32766 border="2" color="0" x="5810" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor26 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=31 alignment="1" tabsequence=32766 border="2" color="0" x="6021" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor27 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=32 alignment="1" tabsequence=32766 border="2" color="0" x="6231" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor28 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=23 alignment="1" tabsequence=32766 border="2" color="0" x="4338" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor19 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=22 alignment="1" tabsequence=32766 border="2" color="0" x="4128" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor18 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=4 alignment="1" tabsequence=32766 border="2" color="0" x="393" y="8" height="76" width="311" format="[general]" html.valueishtml="0"  name=puntuacion visible="1" edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=3 alignment="0" tabsequence=32766 border="2" color="0" x="18" y="8" height="76" width="357" format="[general]" html.valueishtml="0"  name=medicamento visible="1" edit.limit=0 edit.case=any edit.autoselect=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=33 alignment="1" tabsequence=32766 border="2" color="0" x="6441" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor29 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=34 alignment="1" tabsequence=32766 border="2" color="0" x="6651" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor30 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=35 alignment="1" tabsequence=32766 border="2" color="0" x="6862" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor31 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=36 alignment="0" tabsequence=32766 border="2" color="0" x="7072" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor32 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=37 alignment="0" tabsequence=32766 border="2" color="0" x="7282" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor33 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=38 alignment="0" tabsequence=32766 border="2" color="0" x="7493" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor34 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=39 alignment="0" tabsequence=32766 border="2" color="0" x="7703" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor35 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=40 alignment="0" tabsequence=32766 border="2" color="0" x="7913" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor36 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=41 alignment="0" tabsequence=32766 border="2" color="0" x="8123" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor37 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=42 alignment="0" tabsequence=32766 border="2" color="0" x="8334" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor38 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=43 alignment="0" tabsequence=32766 border="2" color="0" x="8544" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor39 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=44 alignment="0" tabsequence=32766 border="2" color="0" x="8754" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor40 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=45 alignment="0" tabsequence=32766 border="2" color="0" x="8960" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor41 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=46 alignment="0" tabsequence=32766 border="2" color="0" x="9170" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor42 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=47 alignment="0" tabsequence=32766 border="2" color="0" x="9381" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor43 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=48 alignment="0" tabsequence=32766 border="2" color="0" x="9591" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor44 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=49 alignment="0" tabsequence=32766 border="2" color="0" x="9801" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor45 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=50 alignment="0" tabsequence=32766 border="2" color="0" x="10011" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor46 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=51 alignment="0" tabsequence=32766 border="2" color="0" x="10222" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor47 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=52 alignment="0" tabsequence=32766 border="2" color="0" x="10432" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor48 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=53 alignment="0" tabsequence=32766 border="2" color="0" x="10642" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor49 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=54 alignment="0" tabsequence=32766 border="2" color="0" x="10853" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor50 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=55 alignment="0" tabsequence=32766 border="2" color="0" x="11063" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor51 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=56 alignment="0" tabsequence=32766 border="2" color="0" x="11273" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor52 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=57 alignment="0" tabsequence=32766 border="2" color="0" x="11483" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor53 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=58 alignment="0" tabsequence=32766 border="2" color="0" x="11694" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor54 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=59 alignment="0" tabsequence=32766 border="2" color="0" x="11904" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor55 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=60 alignment="0" tabsequence=32766 border="2" color="0" x="12114" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor56 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=61 alignment="0" tabsequence=32766 border="2" color="0" x="12320" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor57 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=62 alignment="0" tabsequence=32766 border="2" color="0" x="12530" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor58 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=63 alignment="0" tabsequence=32766 border="2" color="0" x="12741" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor59 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=64 alignment="0" tabsequence=32766 border="2" color="0" x="12951" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor60 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=65 alignment="0" tabsequence=32766 border="2" color="0" x="13161" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor61 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=66 alignment="0" tabsequence=32766 border="2" color="0" x="13371" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor62 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=67 alignment="0" tabsequence=32766 border="2" color="0" x="13582" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor63 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=68 alignment="0" tabsequence=32766 border="2" color="0" x="13792" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor64 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=69 alignment="0" tabsequence=32766 border="2" color="0" x="14002" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor65 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=70 alignment="0" tabsequence=32766 border="2" color="0" x="14213" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor66 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=71 alignment="0" tabsequence=32766 border="2" color="0" x="14423" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor67 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=72 alignment="0" tabsequence=32766 border="2" color="0" x="14633" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor68 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=73 alignment="0" tabsequence=32766 border="2" color="0" x="14843" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor69 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=74 alignment="0" tabsequence=32766 border="2" color="0" x="15054" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor70 visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="22" border="2" color="8388608" x="4969" y="8" height="64" width="192" html.valueishtml="0"  name=valor22_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="23" border="2" color="8388608" x="5179" y="8" height="64" width="192" html.valueishtml="0"  name=valor23_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="24" border="2" color="8388608" x="5390" y="8" height="64" width="192" html.valueishtml="0"  name=valor24_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="25" border="2" color="8388608" x="5600" y="8" height="64" width="192" html.valueishtml="0"  name=valor25_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="26" border="2" color="8388608" x="5810" y="8" height="64" width="192" html.valueishtml="0"  name=valor26_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="27" border="2" color="8388608" x="6021" y="8" height="64" width="192" html.valueishtml="0"  name=valor27_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="28" border="2" color="8388608" x="6231" y="8" height="64" width="192" html.valueishtml="0"  name=valor28_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="29" border="2" color="8388608" x="6441" y="8" height="64" width="192" html.valueishtml="0"  name=valor29_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="30" border="2" color="8388608" x="6651" y="8" height="64" width="192" html.valueishtml="0"  name=valor30_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="31" border="2" color="8388608" x="6862" y="8" height="64" width="192" html.valueishtml="0"  name=valor31_t visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="32" border="2" color="8388608" x="7072" y="8" height="64" width="192" html.valueishtml="0"  name=t_1 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="33" border="2" color="8388608" x="7282" y="8" height="64" width="192" html.valueishtml="0"  name=t_2 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="34" border="2" color="8388608" x="7493" y="8" height="64" width="192" html.valueishtml="0"  name=t_3 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="35" border="2" color="8388608" x="7703" y="8" height="64" width="192" html.valueishtml="0"  name=t_4 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="36" border="2" color="8388608" x="7913" y="8" height="64" width="192" html.valueishtml="0"  name=t_5 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="37" border="2" color="8388608" x="8123" y="8" height="64" width="192" html.valueishtml="0"  name=t_6 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="38" border="2" color="8388608" x="8334" y="8" height="64" width="192" html.valueishtml="0"  name=t_7 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="39" border="2" color="8388608" x="8544" y="8" height="64" width="192" html.valueishtml="0"  name=t_8 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="40" border="2" color="8388608" x="8754" y="8" height="64" width="192" html.valueishtml="0"  name=t_9 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="41" border="2" color="8388608" x="8965" y="8" height="64" width="192" html.valueishtml="0"  name=t_10 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="42" border="2" color="8388608" x="9175" y="8" height="64" width="192" html.valueishtml="0"  name=t_41 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="43" border="2" color="8388608" x="9385" y="8" height="64" width="192" html.valueishtml="0"  name=t_42 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="44" border="2" color="8388608" x="9595" y="8" height="64" width="192" html.valueishtml="0"  name=t_43 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="45" border="2" color="8388608" x="9806" y="8" height="64" width="192" html.valueishtml="0"  name=t_44 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="46" border="2" color="8388608" x="10016" y="8" height="64" width="192" html.valueishtml="0"  name=t_45 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="47" border="2" color="8388608" x="10226" y="8" height="64" width="192" html.valueishtml="0"  name=t_46 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="48" border="2" color="8388608" x="10437" y="8" height="64" width="192" html.valueishtml="0"  name=t_47 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="49" border="2" color="8388608" x="10647" y="8" height="64" width="192" html.valueishtml="0"  name=t_48 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="50" border="2" color="8388608" x="10857" y="8" height="64" width="192" html.valueishtml="0"  name=t_49 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="51" border="2" color="8388608" x="11067" y="8" height="64" width="192" html.valueishtml="0"  name=t_50 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="52" border="2" color="8388608" x="11278" y="8" height="64" width="192" html.valueishtml="0"  name=t_31 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="53" border="2" color="8388608" x="11488" y="8" height="64" width="192" html.valueishtml="0"  name=t_32 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="54" border="2" color="8388608" x="11698" y="8" height="64" width="192" html.valueishtml="0"  name=t_33 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="55" border="2" color="8388608" x="11909" y="8" height="64" width="192" html.valueishtml="0"  name=t_34 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="56" border="2" color="8388608" x="12119" y="8" height="64" width="192" html.valueishtml="0"  name=t_35 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="57" border="2" color="8388608" x="12329" y="8" height="64" width="192" html.valueishtml="0"  name=t_36 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="58" border="2" color="8388608" x="12539" y="8" height="64" width="192" html.valueishtml="0"  name=t_37 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="59" border="2" color="8388608" x="12750" y="8" height="64" width="192" html.valueishtml="0"  name=t_38 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="60" border="2" color="8388608" x="12960" y="8" height="64" width="192" html.valueishtml="0"  name=t_39 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="61" border="2" color="8388608" x="13170" y="8" height="64" width="192" html.valueishtml="0"  name=t_40 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="62" border="2" color="8388608" x="13381" y="8" height="64" width="192" html.valueishtml="0"  name=t_21 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="63" border="2" color="8388608" x="13591" y="8" height="64" width="192" html.valueishtml="0"  name=t_22 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="64" border="2" color="8388608" x="13801" y="8" height="64" width="192" html.valueishtml="0"  name=t_23 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="65" border="2" color="8388608" x="14011" y="8" height="64" width="192" html.valueishtml="0"  name=t_24 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="66" border="2" color="8388608" x="14222" y="8" height="64" width="192" html.valueishtml="0"  name=t_25 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="67" border="2" color="8388608" x="14432" y="8" height="64" width="192" html.valueishtml="0"  name=t_26 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="68" border="2" color="8388608" x="14642" y="8" height="64" width="192" html.valueishtml="0"  name=t_27 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="69" border="2" color="8388608" x="14853" y="8" height="64" width="192" html.valueishtml="0"  name=t_28 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="70" border="2" color="8388608" x="15063" y="8" height="64" width="192" html.valueishtml="0"  name=t_29 visible="1"  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
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