using Minotti.Data;
using Minotti.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minotti.Views.Basicos.Controls
{
    /// <summary>
    /// Migración del UserObject uo_seleccion de PowerBuilder.
    /// Maneja dos DataWindows: una lista de selección (dw_1) y una lista destino (dw_2).
    /// </summary>
    public class uo_seleccion : UserControl
    {
        // ============================================
        //  Controles internos
        // ============================================
        private readonly uo_dw dw_1;
        private readonly uo_dw dw_2;
        private readonly Button pb_agregar;
        private readonly Button pb_eliminar;

        // ============================================
        //  Variables PB migradas
        // ============================================

        // st_espacios s_esp  -> no se usa en el código activo; se omite

        private int cant_filas = 8;
        private bool ib_acomodar;
        private readonly int espacio_entre_obj = 80;

        // Claves de la DW de la ventana (maestro)
        private string[] is_claves = Array.Empty<string>();

        // Posición de los campos de dw_1 dentro de dw_2
        private int[] is_campos = Array.Empty<int>();

        private int cant_columnas_dw1;
        private int cant_columnas_dw2;
        private int cant_columnas;

        // ============================================
        //  Delegates para simular Parent.Event dynamic Trigger
        // ============================================

        public delegate int UeUsInsertarBeforeHandler(uo_dw dw2);
        public delegate void UeUsInsertarEndHandler(uo_dw dw2);
        public delegate int UeUsEliminarBeforeHandler(uo_dw dw2);
        public delegate void UeUsEliminarEndHandler(uo_dw dw2);
        public delegate int UeUsInsertarFilaHandler(uo_dw dw2, int row);
        public delegate int UeUsEliminarFilaHandler(uo_dw dw2, int row);
        public delegate int UeDwItemChangedHandler(uo_dw obj, long row, object dwo, string data);

        public event UeUsInsertarBeforeHandler ue_us_inserta_before;
        public event UeUsInsertarEndHandler ue_us_insertar_end;
        public event UeUsEliminarBeforeHandler ue_us_eliminar_before;
        public event UeUsEliminarEndHandler ue_us_eliminar_end;
        public event UeUsInsertarFilaHandler ue_us_insertar_fila;
        public event UeUsEliminarFilaHandler ue_us_eliminar_fila;
        public event UeDwItemChangedHandler ue_dw_itemchanged_parent;

        // ============================================
        //  Constructor
        // ============================================

        public uo_seleccion()
        {
            // Tamaño inicial aproximado
            Width = 1783;
            Height = 557;
            BackColor = System.Drawing.ColorTranslator.FromOle(12632256);

            // ----- Instanciar controles -----
            dw_1 = new uo_dw
            {
                Left = 46,
                Top = 73,
                BorderStyle = BorderStyle.Fixed3D
            };

            dw_2 = new uo_dw
            {
                Left = 1025,
                Top = 85,
                BorderStyle = BorderStyle.Fixed3D
            };

            pb_agregar = new Button
            {
                Left = 791,
                Top = 57,
                Width = 174,
                Height = 153,
                Text = string.Empty, // solo imagen si querés
                TabIndex = 20
            };

            pb_eliminar = new Button
            {
                Left = 787,
                Top = 329,
                Width = 179,
                Height = 153,
                Text = string.Empty,
                TabIndex = 30
            };

            // Si tenés recursos con las imágenes "derecha.bmp" / "izq.bmp", podés asignarlos acá:
            pb_agregar.Image = Image.FromFile(FileUtils.GetAppFile("Pictures", "derecha.bmp")); //Properties.Resources.derecha;
             pb_eliminar.Image = Image.FromFile(FileUtils.GetAppFile("Pictures", "izq.bmp")); //Properties.Resources.izq;

            

            // Clicks -> eventos ue_insertar / ue_eliminar
            pb_agregar.Click += (s, e) => ue_insertar();
            pb_eliminar.Click += (s, e) => ue_eliminar();

            // Agregar al UserControl
            Controls.Add(dw_1);
            Controls.Add(dw_2);
            Controls.Add(pb_agregar);
            Controls.Add(pb_eliminar);

            // Redimensionar dinámico
            Resize += (s, e) =>
            {
                ue_resize(Width, Height);
            };
        }

        // ============================================================
        //  Helper interno: equivalente a f_Proxparam(parametros)
        // ============================================================
        private static string ProxParam(ref string parametros)
        {
            if (string.IsNullOrWhiteSpace(parametros))
                return string.Empty;

            int idx = parametros.IndexOf(',');
            if (idx < 0)
            {
                string res = parametros.Trim();
                parametros = string.Empty;
                return res;
            }

            string token = parametros.Substring(0, idx).Trim();
            parametros = parametros.Substring(idx + 1);
            return token;
        }

        // ============================================================
        //  Eventos UE_* migrados
        // ============================================================

        /// <summary>
        /// PB: ue_insertar – pasa filas seleccionadas de dw_1 a dw_2.
        /// </summary>
        public void ue_insertar()
        {
            int filas = dw_1.RowCount();
            if (filas < 1) return;

            // Parent.Event dynamic Trigger ue_us_inserta_before(dw_2)
            int rtn = ue_us_inserta_before?.Invoke(dw_2) ?? 1;
            if (rtn < 0)
            {
                dw_2.SelectRow(0, false);
                return;
            }

            int iAux = dw_1.GetSelectedRow(0);
            while (iAux > 0)
            {
                rtn = uof_insertar(iAux);
                if (rtn == -1)
                {
                    // En PB: si no borra la fila, incrementa para evitar loop
                    iAux = iAux + 1;
                }
                iAux = dw_1.GetSelectedRow(iAux - 1);
            }

            ue_habilitar_botones();

            // Parent.Event dynamic Trigger ue_us_insertar_end(dw_2)
            ue_us_insertar_end?.Invoke(dw_2);
        }

        /// <summary>
        /// PB: ue_eliminar – pasa filas seleccionadas de dw_2 a dw_1.
        /// </summary>
        public void ue_eliminar()
        {
            int filas = dw_2.RowCount();
            if (filas < 1) return;

            int rtn = ue_us_eliminar_before?.Invoke(dw_2) ?? 1;
            if (rtn < 0)
            {
                dw_2.SelectRow(0, false);
                return;
            }

            int iAux = dw_2.GetSelectedRow(0);
            while (iAux > 0)
            {
                rtn = uof_eliminar(iAux);
                if (rtn == -2)
                {
                    iAux = iAux + 1;
                }
                iAux = dw_2.GetSelectedRow(iAux - 1);
            }

            ue_habilitar_botones();

            ue_us_eliminar_end?.Invoke(dw_2);
        }

        /// <summary>
        /// PB: ue_deshabilitar_clave – no lo estoy usando por ahora, pero dejo el hook.
        /// </summary>
        public void ue_deshabilitar_clave()
        {
            // En PB hace juego con dw_1.ii_claves / dw_2.ii_claves y Describe/Modify.
            // Podés migrar cuando tengas claro el modelo de claves en uo_dw C#.
            // Lo dejo como no-op para no romper nada.
        }

        /// <summary>
        /// PB: ue_habilitar_botones
        /// </summary>
        public void ue_habilitar_botones()
        {
            // Si la dw principal (maestro) no tiene clave -> deshabilitar todo (caso INSERT)
            if (is_claves == null || is_claves.Length == 0)
            {
                pb_agregar.Enabled = false;
                pb_eliminar.Enabled = false;
                return;
            }

            pb_agregar.Enabled = dw_1.RowCount() > 0;
            pb_eliminar.Enabled = dw_2.RowCount() > 0;
        }

        /// <summary>
        /// PB: ue_leer_parametros(ref string parametros)
        /// Recibe: &lt;dataobject lista&gt;, &lt;dataobject detalle&gt;, &lt;cant_filas&gt;
        /// </summary>
        public void ue_leer_parametros(string parametros)
        {
            // Param 1: dataobject lista (dw_1)
            string dataObjectLista = ProxParam(ref parametros);

            // Param 2: dataobject detalle (dw_2)
            string dataObjectDetalle = ProxParam(ref parametros);

            // Param 3: cantidad de filas
            string cantFilasStr = ProxParam(ref parametros);

            if (!string.IsNullOrWhiteSpace(dataObjectLista))
            {
                dw_1.uof_setdataobject(dataObjectLista);
                dw_1.SetTransObject(SQLCA.Connection!);
                dw_1.uof_marcar_seleccion(2);
            }

            if (!string.IsNullOrWhiteSpace(dataObjectDetalle))
            {
                dw_2.uof_setdataobject(dataObjectDetalle);
                dw_2.SetTransObject(SQLCA.Connection!);
                dw_2.uof_marcar_seleccion(2);
            }

            if (int.TryParse(cantFilasStr, out var cf) && cf > 0)
                cant_filas = cf;
            else
                cant_filas = 8;

            dw_1.cant_filas = cant_filas;
            dw_2.cant_filas = cant_filas;

            // En PB aquí llamaba ue_ajustar_tamaño + ue_acomodar_objetos.
            ue_ajustar_tamaño();
            ue_acomodar_objetos();
        }

        /// <summary>
        /// PB: ue_iniciar(string ais_claves[])
        /// </summary>
        public void ue_iniciar(string[] ais_claves)
        {
            uof_setclaves(ais_claves);

            dw_1.uof_retrieve(is_claves);
            dw_2.uof_retrieve(is_claves);

            // Deshabilita campos en dw_1
            dw_1.uof_edicion(0, "N");

            // Mapeo de columnas: dw_1 -> dw_2 (por nombre)
            cant_columnas_dw1 = dw_1.at_col.Length - 1; // suponiendo at_col[0] sin uso
            cant_columnas_dw2 = dw_2.at_col.Length - 1;

            is_campos = new int[cant_columnas_dw1 + 1]; // index 0 sin uso

            for (int i = 1; i <= cant_columnas_dw1; i++)
            {
                string nombre1 = dw_1.at_col[i].Nombre;
                for (int j = 1; j <= cant_columnas_dw2; j++)
                {
                    if (dw_2.at_col[j].Nombre == nombre1)
                    {
                        is_campos[i] = j;
                        break;
                    }
                }
            }

            cant_columnas = cant_columnas_dw1;

            ue_habilitar_botones();
        }

        /// <summary>
        /// PB: ue_retrieve(string ais_claves[])
        /// </summary>
        public int ue_retrieve(string[] ais_claves)
        {
            int cantidad = (int)dw_2.uof_retrieve(ais_claves);
            return cantidad;
        }

        /// <summary>
        /// PB: ue_ajustar_tamaño
        /// </summary>
        public void ue_ajustar_tamaño()
        {
            // PB (versión activa):
            // this.width = dw_1.uof_ancho() + espacio_entre_obj + pb_agregar.Width + espacio_entre_obj + dw_2.uof_ancho()
            // this.height = dw_1.uof_ancho()

            int ancho = dw_1.uof_ancho() + espacio_entre_obj + pb_agregar.Width + espacio_entre_obj + dw_2.uof_ancho();
            int alto = dw_1.uof_largo(); // acá corrijo lo que en PB parece un bug evidente

            if (ancho < 100) ancho = Width;
            if (alto < 50) alto = Height;

            Width = ancho;
            Height = alto;
        }

        /// <summary>
        /// PB: ue_acomodar_objetos
        /// </summary>
        public void ue_acomodar_objetos()
        {
            SuspendLayout();

            int ancho_dw = (int)((Width - 2 * espacio_entre_obj - pb_agregar.Width) / 2.0);
            int largo_dw = Height;

            int ancho_dw1 = Math.Min(ancho_dw, dw_1.uof_ancho());
            int ancho_dw2 = Math.Min(ancho_dw, dw_2.uof_ancho());
            int largo_dw1 = largo_dw;
            int largo_dw2 = largo_dw;

            if (ancho_dw1 + ancho_dw2 < 2 * ancho_dw)
            {
                if (Math.Min(ancho_dw1, ancho_dw2) == ancho_dw1)
                    ancho_dw2 = 2 * ancho_dw - ancho_dw1;
                else
                    ancho_dw1 = 2 * ancho_dw - ancho_dw2;
            }

            // DW_1
            dw_1.Left = 1;
            dw_1.Top = 1;
            dw_1.Width = ancho_dw1;
            dw_1.Height = largo_dw1;

            // Botones
            pb_agregar.Left = dw_1.Left + dw_1.Width + espacio_entre_obj;
            pb_agregar.Top = (int)(dw_1.Height / 4.0) - (int)(pb_agregar.Height / 2.0);

            pb_eliminar.Width = pb_agregar.Width;
            pb_eliminar.Left = pb_agregar.Left;
            pb_eliminar.Top = (int)(dw_1.Height * 3 / 4.0) - (int)(pb_eliminar.Height / 2.0);

            // DW_2
            dw_2.Left = ancho_dw1 + 2 * espacio_entre_obj + pb_eliminar.Width;
            dw_2.Top = 1;
            dw_2.Width = ancho_dw2;
            dw_2.Height = largo_dw2;

            ResumeLayout();
        }

        /// <summary>
        /// PB: ue_resize(ancho_total, largo_total)
        /// </summary>
        public void ue_resize(int ancho_total, int largo_total)
        {
            Width = ancho_total;
            Height = largo_total;
            ue_acomodar_objetos();
        }

        /// <summary>
        /// PB: ue_dw_itemchanged – llama al del padre.
        /// </summary>
        public int ue_dw_itemchanged(uo_dw arg_objeto, long row, object dwo, string data)
        {
            return ue_dw_itemchanged_parent?.Invoke(arg_objeto, row, dwo, data) ?? 1;
        }

        public bool ue_aceptar_datos()
        {
            if (dw_2.AcceptText() != 1) return false;
            return true;
        }

        public int ue_rowsdiscard(int desde, int hasta, dwbuffer buffer)
        {
            return dw_2.RowsDiscard(desde, hasta, buffer);
        }

        public void ue_reiniciar()
        {
            is_claves = Array.Empty<string>();
            dw_1.Reset();
            dw_2.Reset();
        }

        // ============================================================
        //  Métodos UOF (helpers públicos)
        // ============================================================

        public int uof_ancho_objeto()
        {
            // PB mostraba MessageBox avisando que se usara uof_ancho(); acá ya devolvemos el nuevo.
            return uof_ancho();
        }

        public int uof_alto_objeto()
        {
            // Igual que arriba: devolvemos uof_largo.
            return uof_largo();
        }

        public void uof_habilitar_objetos(bool accion)
        {
            dw_1.Enabled = accion;
            dw_2.Enabled = accion;
            pb_agregar.Enabled = accion;
            pb_eliminar.Enabled = accion;
        }

        /// <summary>
        /// PB: uof_update(flag1, flag2) – update sobre dw_2.
        /// </summary>
        public int uof_update(bool flag1, bool flag2)
        {
            int filas = dw_2.RowCount();

            for (int i = 1; i <= filas; i++)
            {
                var estado = dw_2.GetItemStatus(i, 0, dwbuffer.Primary);
                if (estado == dwitemstatus.New || estado == dwitemstatus.NewModified)
                {
                    dw_2.uof_setclaves(is_claves, i);
                }
            }

            int res = dw_2.Update(flag1, flag2);
            if (res != 1) return -1;
            return 1;
        }

        public void uof_setclaves(string[] ais_claves)
        {
            is_claves = ais_claves?.ToArray() ?? Array.Empty<string>();
        }

        public int uof_limpiar_dw()
        {
            int cant = dw_2.RowCount();

            for (int iAux = cant; iAux >= 1; iAux--)
            {
                int row = dw_1.InsertRow(0);
                if (row <= 0) continue;

                for (int i = 1; i <= cant_columnas; i++)
                {
                    int col2 = is_campos[i];
                    string valor = dw_2.uof_getitem(iAux, col2);
                    dw_1.uof_setitem(row, i, valor);
                }

                dw_2.DeleteRow(iAux);
            }

            return 1;
        }

        public int uof_ancho()
        {
            int tam = dw_1.uof_ancho() + dw_2.uof_ancho() + pb_agregar.Width + espacio_entre_obj * 2;
            return tam;
        }

        public int uof_largo()
        {
            int tam = dw_1.uof_largo() + espacio_entre_obj * 2;
            return tam;
        }

        public bool uof_cambios_pendientes()
        {
            dw_2.AcceptText();
            if (dw_2.ModifiedCount() > 0 || dw_2.DeletedCount() > 0)
                return true;

            return false;
        }

        public void uof_resetupdate()
        {
            dw_2.ResetUpdate();
        }

        /// <summary>
        /// PB: uof_insertar(fila) – fila seleccionada pasa de dw_1 a dw_2.
        /// </summary>
        public int uof_insertar(int fila)
        {
            int row = dw_2.InsertRow(0);
            if (row <= 0) return -1;

            for (int i = 1; i <= cant_columnas_dw1; i++)
            {
                int col2 = is_campos[i];
                if (col2 <= 0) continue;

                string valor = dw_1.uof_getitem(fila, i);
                dw_2.uof_setitem(row, col2, valor);
            }

            int rtn = ue_us_insertar_fila?.Invoke(dw_2, row) ?? 1;
            if (rtn < 0)
            {
                dw_2.DeleteRow(row);
                return -1;
            }
            else
            {
                dw_1.RowsDiscard(fila, fila, dwbuffer.Primary);
            }

            return 1;
        }

        /// <summary>
        /// PB: uof_eliminar(fila) – fila pasa de dw_2 a dw_1.
        /// </summary>
        public int uof_eliminar(int fila)
        {
            int rtn = ue_us_eliminar_fila?.Invoke(dw_2, fila) ?? 1;
            if (rtn < 0)
            {
                return -1;
            }

            int row = dw_1.InsertRow(0);
            if (row <= 0) return -2;

            for (int i = 1; i <= cant_columnas; i++)
            {
                int col2 = is_campos[i];
                if (col2 <= 0) continue;

                string valor = dw_2.uof_getitem(fila, col2);
                dw_1.uof_setitem(row, i, valor);
            }

            dw_2.DeleteRow(fila);

            return 1;
        }
    }

    // Si todavía no tenés estos enums/clases, podés definirlos así provisorios:
    //public enum DWBuffer { Primary }
    //public enum DWItemStatus { New, NewModified, DataModified, NotModified }
}
