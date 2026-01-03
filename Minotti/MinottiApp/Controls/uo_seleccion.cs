using System;
using System.Windows.Forms;
using Minotti.Models;

namespace Minotti.Controls
{
    // Migración de PowerBuilder: uo_seleccion.sru (userobject visual)
    // Se mantiene el nombre del tipo: uo_seleccion
    public partial class uo_seleccion : UserControl
    {
        // ===== Variables del SRU =====
        public st_espacios s_esp { get; set; } = new st_espacios();
        public int cant_columnas_dw1 { get; set; } = 0;
        public int cant_columnas_dw2 { get; set; } = 0;
        public int cant_columnas { get; set; } = 0;

        // Claves (según uof_setclaves)
        public string[] is_claves { get; set; } = Array.Empty<string>();

        public uo_seleccion()
        {
            InitializeComponent();
        }

        // ===== Funciones públicas (firmas preservadas) =====

        // public function integer uof_ancho_objeto ()
        public int uof_ancho_objeto()
        {
            // Ancho total aproximado del objeto (dw1 + botones + dw2 + bordes)
            int sep = 8;
            return dw_1.Width + sep + panel_botones.Width + sep + dw_2.Width + (s_esp?.borde ?? 0) * 2;
        }

        // public function integer uof_insertar (integer fila)
        public int uof_insertar(int fila)
        {
            // En PB podría mover la fila seleccionada de dw_1 a dw_2; aquí dejamos stub mínimo
            // Si querés, implemento el movimiento copiando celdas cuando las DataTables existan.
            return 1;
        }

        // public function integer uof_eliminar (integer fila)
        public int uof_eliminar(int fila)
        {
            // Intenta borrar una fila en dw_2
            try
            {
                return dw_2.deleterow(fila);
            }
            catch
            {
                return 0;
            }
        }

        // ===== Subrutinas públicas (firmas preservadas) =====

        // public subroutine uof_habilitar_objetos (boolean accion)
        public void uof_habilitar_objetos(bool accion)
        {
            dw_1.Enabled = accion;
            dw_2.Enabled = accion;
            pb_agregar.Enabled = accion;
            pb_eliminar.Enabled = accion;
        }

        // public subroutine uof_setclaves (string ais_claves[])
        public void uof_setclaves(string[] ais_claves)
        {
            is_claves = ais_claves ?? Array.Empty<string>();
        }

        // public subroutine uof_resetupdate ()
        public void uof_resetupdate()
        {
            // En PB: dw_2.ResetUpdate()
            // Nuestro uo_dw no expone ResetUpdate; el equivalente sería aceptar cambios del DataTable si se usa
            // Dejamos stub sin efecto para compatibilidad
        }

        // ===== Eventos PB convertidos a métodos =====

        public void ue_insertar()
        {
            // Si hay fila actual en dw_1, llamar a uof_insertar
            int fila = GetFilaActual(dw_1);
            if (fila > 0) uof_insertar(fila);
        }

        public void ue_eliminar()
        {
            int fila = GetFilaActual(dw_2);
            if (fila > 0) uof_eliminar(fila);
        }

        // Utilitario: obtener fila 1-based desde DataGridView
        private int GetFilaActual(uo_dw dw)
        {
            if (dw?.grid?.CurrentCell == null) return 0;
            return dw.grid.CurrentCell.RowIndex + 1;
        }
    }
}
