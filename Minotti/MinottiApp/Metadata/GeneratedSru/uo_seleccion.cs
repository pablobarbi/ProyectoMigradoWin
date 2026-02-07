// -----------------------------------------------------------------------------
// AUTO-MIGRADO desde PowerBuilder (.sru)
// Origen: uo_seleccion
// -----------------------------------------------------------------------------

#nullable enable
using Minotti.Data;
using Minotti.Functions;
using Minotti.UserObjects;
using Minotti.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class uo_seleccion : UserObject
    {
        // ---------------------------------------------------------------------
        // CONTROLES
        // ---------------------------------------------------------------------
        public uo_dw dw_1;
        public uo_dw dw_2;
        public picturebutton pb_agregar;
        public picturebutton pb_eliminar;

        // ---------------------------------------------------------------------
        // VARIABLES
        // ---------------------------------------------------------------------
        protected st_espacios s_esp;

        protected int cant_filas = 8;
        protected int ancho;
        protected int alto;
        protected bool ib_acomodar;

        protected string[] is_claves = Array.Empty<string>();
        protected int[] is_campos = Array.Empty<int>();

        protected int espacio_entre_obj = 80;

        protected int cant_columnas_dw1;
        protected int cant_columnas_dw2;
        protected int cant_columnas;

        // ---------------------------------------------------------------------
        // EVENTOS PB
        // ---------------------------------------------------------------------

        public virtual void ue_insertar()
        {
            int filas = dw_1.RowCount();
            if (filas < 1) return;

            int rtn = Convert.ToInt32(
                Parent.EventDynamicTrigger("ue_us_inserta_before", dw_2)
            );

            if (rtn < 0)
            {
                dw_2.SelectRow(0, false);
                return;
            }

            int iAux = dw_1.GetSelectedRow(0);
            while (iAux > 0)
            {
                rtn = uof_insertar(iAux);
                if (rtn == -1) iAux++;
                iAux = dw_1.GetSelectedRow(iAux - 1);
            }

            ue_habilitar_botones();

            Parent.EventDynamicTrigger("ue_us_insertar_end", dw_2);
        }

        public virtual void ue_eliminar()
        {
            int filas = dw_2.RowCount();
            if (filas < 1) return;

            int rtn = Convert.ToInt32(
                Parent.EventDynamicTrigger("ue_us_eliminar_before", dw_2)
            );

            if (rtn < 0)
            {
                dw_2.SelectRow(0, false);
                return;
            }

            int iAux = dw_2.GetSelectedRow(0);
            while (iAux > 0)
            {
                rtn = uof_eliminar(iAux);
                if (rtn == -2) iAux++;
                iAux = dw_2.GetSelectedRow(iAux - 1);
            }

            ue_habilitar_botones();

            Parent.EventDynamicTrigger("ue_us_eliminar_end", dw_2);
        }

        public virtual void ue_habilitar_botones()
        {
            if (is_claves == null || is_claves.Length == 0)
            {
                pb_agregar.Enabled = false;
                pb_eliminar.Enabled = false;
            }

            pb_agregar.Enabled = dw_1.RowCount() > 0;
            pb_eliminar.Enabled = dw_2.RowCount() > 0;
        }

        public virtual void ue_leer_parametros(ref string parametros)
        {
            dw_1.uof_setdataobject(f_proxparam.fproxparam(ref parametros));
            dw_1.SetTransObject(SQLCA.Instance);
            dw_1.uof_marcar_seleccion(2);

            dw_2.uof_setdataobject(f_proxparam.fproxparam(ref parametros));
            dw_2.SetTransObject(SQLCA.Instance);
            dw_2.uof_marcar_seleccion(2);

            cant_filas = Convert.ToInt32(f_proxparam.fproxparam(ref parametros));
            if (cant_filas <= 0) cant_filas = 8;

            dw_1.cant_filas = cant_filas;
            dw_2.cant_filas = cant_filas;
        }

        public virtual void ue_iniciar(string[] ais_claves)
        {
            is_claves = ais_claves;

            dw_1.uof_retrieve(is_claves);
            dw_2.uof_retrieve(is_claves);

            dw_1.uof_edicion(0, "N");

            cant_columnas_dw1 = dw_1.at_col.Length;
            cant_columnas_dw2 = dw_2.at_col.Length;

            is_campos = new int[cant_columnas_dw1];

            for (int i = 0; i < cant_columnas_dw1; i++)
            {
                for (int j = 0; j < cant_columnas_dw2; j++)
                {
                    if (dw_1.at_col[i].Nombre == dw_2.at_col[j].Nombre)
                    {
                        is_campos[i] = j + 1;
                        break;
                    }
                }
            }

            cant_columnas = is_campos.Length;
            ue_habilitar_botones();
        }

        public virtual long ue_retrieve(string[] ais_claves)
        {
            return dw_2.uof_retrieve(ais_claves);
        }

        public virtual bool ue_aceptar_datos()
        {
            if (dw_2.AcceptText() != 1) return false;
            return true;
        }

        public virtual void ue_reiniciar()
        {
            is_claves = Array.Empty<string>();
            dw_1.Reset();
            dw_2.Reset();
        }

        // ---------------------------------------------------------------------
        // FUNCIONES
        // ---------------------------------------------------------------------

        public int uof_ancho()
        {
            return dw_1.uof_ancho() + dw_2.uof_ancho()
                   + pb_agregar.Width + espacio_entre_obj * 2;
        }

        public int uof_largo()
        {
            return dw_1.uof_largo() + espacio_entre_obj * 2;
        }

        public bool uof_cambios_pendientes()
        {
            dw_2.AcceptText();
            return dw_2.ModifiedCount() > 0 || dw_2.DeletedCount() > 0;
        }

        public void uof_resetupdate()
        {
            dw_2.ResetUpdate();
        }

        public int uof_insertar(int fila)
        {
            int row = dw_2.InsertRow(0);
            if (row <= 0) return -1;

            for (int i = 1; i <= cant_columnas_dw1; i++)
            {
                dw_2.uof_setitem(row, is_campos[i - 1], dw_1.uof_getitem(fila, i));
            }

            int rtn = Convert.ToInt32(
                Parent.EventDynamicTrigger("ue_us_insertar_fila", dw_2, row)
            );

            if (rtn < 0)
            {
                dw_2.DeleteRow(row);
                return -1;
            }

            dw_1.RowsDiscard(fila, fila, dwbuffer.Primary);
            return 1;
        }

        public int uof_eliminar(int fila)
        {
            int rtn = Convert.ToInt32(
                Parent.EventDynamicTrigger("ue_us_eliminar_fila", dw_2, fila)
            );

            if (rtn < 0) return -1;

            int row = dw_1.InsertRow(0);
            if (row <= 0) return -2;

            for (int i = 1; i <= cant_columnas; i++)
            {
                dw_1.uof_setitem(row, i, dw_2.uof_getitem(fila, is_campos[i - 1]));
            }

            dw_2.DeleteRow(fila);
            return 1;
        }

        // ---------------------------------------------------------------------
        // CREATE / DESTROY
        // ---------------------------------------------------------------------

        public override void create()
        {
            dw_1 = new uo_dw();
            dw_2 = new uo_dw();
            pb_agregar = new picturebutton();
            pb_eliminar = new picturebutton();

            this.Control = new object[]
            {
                dw_1,
                dw_2,
                pb_agregar,
                pb_eliminar
            };
        }

        //public override void destroy()
        //{
        //    dw_1?.Destroy();
        //    dw_2?.Destroy();
        //    //pb_agregar?.Destroy();
        //    //pb_eliminar?.Destroy();
        //}
    }
}
