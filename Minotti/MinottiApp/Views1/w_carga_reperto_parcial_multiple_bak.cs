using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PB Window 'w_carga_reperto_parcial_multiple_bak' (deriva de w_carga).
    /// Se preservan nombres y se integra lógica visible (sin inventar).
    /// </summary>
    public partial class w_carga_reperto_parcial_multiple_bak : Form
    {
        /// <summary>Emula variable PB 'is_Pasada'</summary>
        public string is_Pasada { get; set; } = string.Empty;

        /// <summary>DSN ODBC para emular USING SQLCA (SQL Anywhere 9)</summary>
        public string Dsn { get; set; } = string.Empty;

        public w_carga_reperto_parcial_multiple_bak()
        {
            InitializeComponent();

            // Evento 'clicked' detectado en el SRW (segmento mostrado):
            // is_Pasada = 'PARCIAL'
            // wf_dibujar_detalle()
            this.cb_grabar.Click += (s, e) =>
            {
                // Si el clicked corresponde a cb_grabar o botón asociado según el SRW, mantenemos la intención.
                this.is_Pasada = "PARCIAL";
                this.wf_dibujar_detalle();
            };
        }

        /// <summary>
        /// Stub preservando nombre de PB. Llamado desde el clic que setea is_Pasada='PARCIAL'.
        /// </summary>
        public void wf_dibujar_detalle()
        {
            // Implementación real está en otras unidades en PB; no se inventa aquí.
        }

        /// <summary>
        /// Extraído del SRW: en cierto flujo, asigna fecha a dw_3 y dispara ue_acomodar_objetos en el padre.
        /// Aquí se preserva como helper si necesitás llamarlo desde el lugar correspondiente.
        /// </summary>
        public void uo_set_fecha_dw3_y_acomodar(DateTime ld_Fecha, int ll_Fila)
        {
            if (dw_3.DataSource is DataTable dt && dt.Columns.Contains("fecha") && ll_Fila > 0 && ll_Fila <= dt.Rows.Count)
            {
                dt.Rows[ll_Fila - 1]["fecha"] = ld_Fecha;
            }
            // Parent.TriggerEvent("ue_acomodar_objetos") no tiene equivalente directo; se podría exponer un evento .NET.
            // Se conserva la intención sin inventar comportamiento adicional.
        }
    }
}