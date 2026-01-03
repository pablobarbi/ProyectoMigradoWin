using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class d_medicamentos_sin_blob
    {
        public static string Sql = @"SELECT medicamentos.medicamento,
                                            medicamentos.descripcion,
                                            medicamentos.observaciones,
                                            medicamentos.imagen_asociada   
                                    FROM medicamentos  
                                    WHERE medicamentos.medicamento = :medicamento";

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
﻿release 7;
datawindow(units=0 timer_interval=0 color=80269524 processing=0 HTMLDW=no print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=752 color="536870912" )
table(column=(type=char(10) update=yes updatewhereclause=yes key=yes name=medicamento dbname="medicamentos.medicamento" )
 column=(type=char(50) update=yes updatewhereclause=yes name=descripcion dbname="medicamentos.descripcion" )
 column=(type=char(255) update=yes updatewhereclause=yes name=observaciones dbname="medicamentos.observaciones" )
 column=(type=char(255) update=yes updatewhereclause=yes name=imagen_asociada dbname="medicamentos.imagen_asociada" )
 retrieve="SELECT medicamentos.medicamento,
       medicamentos.descripcion,
       medicamentos.observaciones,
       medicamentos.imagen_asociada
  FROM medicamentos
 WHERE medicamentos.medicamento = :medicamento
" update="medicamentos" updatewhere=1 updatekeyinplace=no arguments=(("medicamento", string)) )
text(band=detail alignment="1" text="Medicamento:" border="0" color="8388608" x="55" y="16" height="68" width="411"  name=medicamento_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Descripción:" border="0" color="8388608" x="59" y="108" height="64" width="407"  name=descripcion_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
text(band=detail alignment="1" text="Observaciones:" border="0" color="8388608" x="23" y="200" height="68" width="443"  name=observaciones_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=1 alignment="0" tabsequence=10 border="5" color="0" x="494" y="16" height="68" width="411" format="[general]"  name=medicamento edit.limit=10 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.required=yes edit.nilisnull=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=2 alignment="0" tabsequence=20 border="5" color="0" x="494" y="108" height="68" width="1399" format="[general]"  name=descripcion edit.limit=50 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.required=yes edit.nilisnull=yes edit.autohscroll=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=3 alignment="0" tabsequence=30 border="5" color="0" x="494" y="200" height="320" width="1399" format="[general]"  name=observaciones edit.limit=255 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.nilisnull=yes edit.autovscroll=yes edit.vscrollbar=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
column(band=detail id=4 alignment="0" tabsequence=32766 border="0" color="0" x="480" y="572" height="64" width="1403" format="[general]"  name=imagen_asociada edit.limit=0 edit.case=any edit.autoselect=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
button(band=detail text="Buscar imagen..."filename=""action="0" border="0" color="16777215" x="1934" y="552" height="100" width="530" vtextalign="0" htextalign="0"  name=b_imagen  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="128" )
bitmap(band=detail filename="C:\Trabajo\Adrian\imagenes\graficos_humanos\boca.jpg" x="1966" y="16" height="500" width="590" border="0"  name=p_1 )
htmltable(border="1" )
htmlgen(clientevents="1" clientvalidation="1" clientcomputedfields="1" clientformatting="0" clientscriptable="0" generatejavascript="1" )
 
        */
    }
}