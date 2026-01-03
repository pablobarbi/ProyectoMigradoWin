using System;
using System.Windows.Forms;

namespace Minotti
{
    // Migrado desde PowerBuilder Window: w_reporte_capitulo_filtro_todo.srw
    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.
    public partial class w_reporte_capitulo_filtro_todoOld : Form
    {
        public w_reporte_capitulo_filtro_todo()
        {
            InitializeComponent();
        }

        /*
        ================== CONTENIDO ORIGINAL .SRW ==================
﻿forward
global type w_reporte_capitulo_filtro_todo from w_reporte
end type
end forward


global type w_reporte_capitulo_filtro_todo from w_reporte 
end type

global w_reporte_capitulo_filtro_todo w_reporte_capitulo_filtro_todo

type variables
uo_ds		ds_reporte

end variables

on w_reporte_capitulo_filtro_todo.create
call super::create
end on

on w_reporte_capitulo_filtro_todo.destroy
call super::destroy
end on

event ue_procesar;/*
	 ATENCION !!! ANCESTOR SCRIPT OVERRIDE
*/
        uo_capitulos ls_capitulos
Long ll_capitulo
String ls_filtro, ls_filtrar


SetPointer(HourGlass!)

If dw_param.AcceptText() <> 1 Then
    dw_param.SetFocus()

    Return
End If


ds_reporte = create uo_ds
ds_reporte.SetTransObject(SQLCA)
ds_reporte.uof_SetDataObject('dr_capitulo_completo')


ll_capitulo = 0 
ls_filtro = dw_param.GetItemString( 1, "nombre")
If IsNull(ls_filtro) Then
    MessageBox('Atención', 'No hay registros')

    If isValid(dw_param) Then dw_param.SetFocus()

    Return
End If

ls_capitulos = CREATE uo_capitulos
ls_capitulos.capitulo_id = ll_Capitulo
ls_capitulos.uo_cargar_info()
ls_capitulos.uo_devolver_capitulo(ds_reporte)

// comparto el buffer.
ds_reporte.ShareData(dw_reporte)

/* Si no encontró datos, envía un mensaje */
If dw_reporte.RowCount() < 1 Then
    MessageBox('Atención', 'No hay registros')

    If isValid(dw_param) Then dw_param.SetFocus()

    Return
Else

    dw_reporte.SetFocus()
End If

/* HAGO LOS FILTROS POR CADA UNO DE LOS NIVELES */
ls_filtrar = "(upper(capitulo_nombre) like '%" + upper(ls_filtro) + "%')" &
       +" OR (upper(rubrica_nombre) like '%" + upper(ls_filtro) + "%')" &
       +" OR (upper(subrubrica01_nombre) like '%" + upper(ls_filtro) + "%')" &
       +" OR (upper(subrubrica02_nombre) like '%" + upper(ls_filtro) + "%')" &
       +" OR (upper(subrubrica03_nombre) like '%" + upper(ls_filtro) + "%')" &
       +" OR (upper(subrubrica04_nombre) like '%" + upper(ls_filtro) + "%')" &
       +" OR (upper(subrubrica05_nombre) like '%" + upper(ls_filtro) + "%')" &
       +" OR (upper(subrubrica06_nombre) like '%" + upper(ls_filtro) + "%')" &
       +" OR (upper(subrubrica07_nombre) like '%" + upper(ls_filtro) + "%')" &
       +" OR (upper(subrubrica08_nombre) like '%" + upper(ls_filtro) + "%')" &
       +" OR (upper(subrubrica09_nombre) like '%" + upper(ls_filtro) + "%')" &
       +" OR (upper(subrubrica10_nombre) like '%" + upper(ls_filtro) + "%')"

dw_reporte.SetFilter(ls_filtrar)
dw_reporte.Filter()
If dw_reporte.RowCount() < 1 Then
    MessageBox('Atención', 'No hay registros')

    If isValid(dw_param) Then dw_param.SetFocus()
Else
    dw_reporte.SetFocus()
End If




end event

        ================== FIN CONTENIDO ORIGINAL .SRW ==============

        ================== CONTENIDO ORIGINAL .SRW.XAML =============
﻿<pbwpf:Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="w_reporte_capitulo_filtro_todo" x:ClassModifier="internal">
	<Canvas>
	</Canvas>
</pbwpf:Window>
        ================== FIN CONTENIDO ORIGINAL .SRW.XAML =========
        */
    }
    }


    public partial class w_reporte_capitulo_filtro_todo : Form
    {
        // type variables (PB): uo_ds ds_reporte
        private uo_ds ds_reporte;

        public w_reporte_capitulo_filtro_todo()
        {
            InitializeComponent();
        }

        // === Traducción directa del event ue_procesar ===
        public void ue_procesar()
        {
            // /*
            // 	 ATENCION !!! ANCESTOR SCRIPT OVERRIDE
            // */
            uo_capitulos ls_capitulos;
            long ll_capitulo;
            string ls_filtro, ls_filtrar;

            // SetPointer(HourGlass!)
            Cursor.Current = Cursors.WaitCursor;

            if (dw_param.AcceptText() != 1)
            {
                dw_param.SetFocus();
                return;
            }

            ds_reporte = new uo_ds();
            ds_reporte.SetTransObject(Globals.sqlca);
            ds_reporte.uof_SetDataObject("dr_capitulo_completo");

            ll_capitulo = 0;
            ls_filtro = dw_param.GetItemString(1, "nombre");
            if (ls_filtro == null)
            {
                MessageBox.Show("No hay registros", "Atención");
                if (dw_param != null) dw_param.SetFocus();
                return;
            }

            ls_capitulos = new uo_capitulos();
            ls_capitulos.capitulo_id = Globals.gl_Capitulo;
            ls_capitulos.uo_cargar_info();
            ls_capitulos.uo_devolver_capitulo(ds_reporte);

            // comparto el buffer.
            ds_reporte.ShareData(dw_reporte);

            // Si no encontró datos, envía un mensaje
            if (dw_reporte.RowCount() < 1)
            {
                MessageBox.Show("No hay registros", "Atención");
                if (dw_param != null) dw_param.SetFocus();
                return;
            }
            else
            {
                dw_reporte.SetFocus();
            }

            // HAGO LOS FILTROS POR CADA UNO DE LOS NIVELES
            ls_filtrar =
                "(upper(capitulo_nombre) like '%" + ls_filtro.ToUpperInvariant() + "%')" +
                " OR (upper(rubrica_nombre) like '%" + ls_filtro.ToUpperInvariant() + "%')" +
                " OR (upper(subrubrica01_nombre) like '%" + ls_filtro.ToUpperInvariant() + "%')" +
                " OR (upper(subrubrica02_nombre) like '%" + ls_filtro.ToUpperInvariant() + "%')" +
                " OR (upper(subrubrica03_nombre) like '%" + ls_filtro.ToUpperInvariant() + "%')" +
                " OR (upper(subrubrica04_nombre) like '%" + ls_filtro.ToUpperInvariant() + "%')" +
                " OR (upper(subrubrica05_nombre) like '%" + ls_filtro.ToUpperInvariant() + "%')" +
                " OR (upper(subrubrica06_nombre) like '%" + ls_filtro.ToUpperInvariant() + "%')" +
                " OR (upper(subrubrica07_nombre) like '%" + ls_filtro.ToUpperInvariant() + "%')" +
                " OR (upper(subrubrica08_nombre) like '%" + ls_filtro.ToUpperInvariant() + "%')" +
                " OR (upper(subrubrica09_nombre) like '%" + ls_filtro.ToUpperInvariant() + "%')" +
                " OR (upper(subrubrica10_nombre) like '%" + ls_filtro.ToUpperInvariant() + "%')";

            dw_reporte.SetFilter(ls_filtrar);
            dw_reporte.Filter();

            if (dw_reporte.RowCount() < 1)
            {
                MessageBox.Show("No hay registros", "Atención");
                if (dw_param != null) dw_param.SetFocus();
            }
            else
            {
                dw_reporte.SetFocus();
            }
        }

        // ====== Stubs mínimos para que compile sin “interpretar” ======

        // Simula los controles PB DataWindow usados en el script
        private readonly DataWindow dw_param = new DataWindow();
        private readonly DataWindow dw_reporte = new DataWindow();

        private class DataWindow
        {
            public int AcceptText() => 1;
            public void SetFocus() { }
            public string GetItemString(int row, string column) => null;
            public void SetFilter(string expr) { }
            public void Filter() { }
            public int RowCount() => 0;
        }

        // Simula uo_ds y sus métodos llamados
        private class uo_ds
        {
            public void SetTransObject(transaction t) { }
            public void uof_SetDataObject(string name) { }
            public void ShareData(DataWindow dw) { }
        }

        // Simula uo_capitulos y métodos llamados
        private class uo_capitulos
        {
            public long capitulo_id;
            public void uo_cargar_info() { }
            public void uo_devolver_capitulo(uo_ds ds) { }
        }
    }



}



