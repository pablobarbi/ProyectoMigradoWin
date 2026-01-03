using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class dk_reperto_total_tabla_med_multiple
    {
        public static string Sql = @"SELECT reperto_total_med.reperto_total,    
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
reperto_total_med.orden,  
reperto_total_med.valor 
FROM reperto_total_med 
WHERE reperto_total_med.reperto_total in ( :reperto )";

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
reperto_total_med
        */

        /* ===== SRD original completo =====
﻿release 10.5;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.printername="" print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.canusedefaultprinter=yes print.prompt=no print.buttons=no print.preview.buttons=no print.cliptext=no print.overrideprintjob=no print.collate=yes print.preview.outline=yes hidegrayline=no )
header(height=80 color="81324524" )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=88 color="536870912" )
table(column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_total dbname="reperto_total_med.reperto_total" dbalias=".reperto_total" )
 column=(type=decimal(0) update=yes updatewhereclause=yes key=yes name=reperto_sintoma dbname="reperto_total_med.reperto_sintoma" dbalias=".reperto_sintoma" )
 column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento dbname="reperto_total_med.medicamento" dbalias=".medicamento" )
 column=(type=char(5) update=yes updatewhereclause=yes name=puntuacion dbname="reperto_total_med.puntuacion" dbalias=".puntuacion" )
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
 column=(type=decimal(5) update=yes updatewhereclause=yes name=orden dbname="reperto_total_med.orden" dbalias=".orden" )
 column=(type=long update=yes updatewhereclause=yes name=valor dbname="reperto_total_med.valor" dbalias=".valor" )
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
       reperto_total_med.orden,
       reperto_total_med.valor
  FROM reperto_total_med
 WHERE reperto_total_med.reperto_total in ( :reperto )
" update="reperto_total_med" updatewhere=0 updatekeyinplace=no arguments=(("reperto", string)) )
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
column(band=detail id=33 alignment="1" tabsequence=32766 border="2" color="0" x="6441" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor29 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=34 alignment="1" tabsequence=32766 border="2" color="0" x="6651" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor30 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=35 alignment="1" tabsequence=32766 border="2" color="0" x="6862" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor31 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=23 alignment="1" tabsequence=32766 border="2" color="0" x="4338" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor19 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=22 alignment="1" tabsequence=32766 border="2" color="0" x="4128" y="8" height="76" width="192" format="[general]" html.valueishtml="0"  name=valor18 visible="1" edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=4 alignment="1" tabsequence=32766 border="2" color="0" x="393" y="8" height="76" width="311" format="[general]" html.valueishtml="0"  name=puntuacion visible="1" edit.limit=5 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=3 alignment="0" tabsequence=32766 border="2" color="0" x="18" y="8" height="76" width="357" format="[general]" html.valueishtml="0"  name=medicamento visible="1" edit.limit=0 edit.case=any edit.autoselect=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=37 alignment="0" tabsequence=0 border="0" color="0" x="7054" y="0" height="64" width="2135" html.valueishtml="0"  name=valor visible="1" edit.limit=0 edit.case=any edit.focusrectangle=no edit.autoselect=no  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
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