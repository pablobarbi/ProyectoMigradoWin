using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class dk_mig_subrubricas
    {
        public const string Sql = @"SELECT mig_subrubricas.capitulo,        
                                           mig_subrubricas.padre,
                                           mig_subrubricas.codigo,        
                                           mig_subrubricas.descripcio   
                                   FROM mig_subrubricas";

        public static DataTable RetrieveToDataTable(params object[] parametros)
        {
            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {

            });
        }

        /* ===== UPDATE (tal cual en SRD) =====
(No se detectó bloque UPDATE en el SRD)
        */

        /* ===== SRD original completo =====
﻿release 7;
datawindow(units=0 timer_interval=0 color=16777215 processing=0 HTMLDW=no print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
header(height=72 color="536870912" )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=84 color="536870912" )
table(column=(type=number updatewhereclause=yes name=capitulo dbname="mig_subrubricas.capitulo" )
 column=(type=number updatewhereclause=yes name=padre dbname="mig_subrubricas.padre" )
 column=(type=number updatewhereclause=yes name=codigo dbname="mig_subrubricas.codigo" )
 column=(type=char(255) updatewhereclause=yes name=descripcio dbname="mig_subrubricas.descripcio" )
 retrieve="SELECT mig_subrubricas.capitulo,
       mig_subrubricas.padre,
       mig_subrubricas.codigo,
       mig_subrubricas.descripcio
  FROM mig_subrubricas
"  sort="codigo A " )
text(band=header alignment="2" text="Capitulo" border="0" color="0" x="5" y="4" height="64" width="329"  name=capitulo_t  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Padre" border="0" color="0" x="338" y="4" height="64" width="329"  name=padre_t  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Codigo" border="0" color="0" x="672" y="4" height="64" width="329"  name=codigo_t  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=header alignment="2" text="Descripcio" border="0" color="0" x="1006" y="4" height="64" width="4389"  name=descripcio_t  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=1 alignment="1" tabsequence=10 border="0" color="0" x="5" y="4" height="76" width="329" format="[general]"  name=capitulo edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=2 alignment="1" tabsequence=20 border="0" color="0" x="338" y="4" height="76" width="329" format="[general]"  name=padre edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=3 alignment="1" tabsequence=30 border="0" color="0" x="672" y="4" height="76" width="329" format="[general]"  name=codigo edit.limit=0 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=4 alignment="0" tabsequence=40 border="0" color="0" x="1006" y="4" height="76" width="4389" format="[general]"  name=descripcio edit.limit=255 edit.case=any edit.autoselect=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
htmltable(border="1" )
htmlgen(clientevents="1" clientvalidation="1" clientcomputedfields="1" clientformatting="0" clientscriptable="0" generatejavascript="1" )
 
        */
    }
}