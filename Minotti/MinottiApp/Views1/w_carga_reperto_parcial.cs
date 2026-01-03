using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PowerBuilder Window 'w_carga_reperto_parcial' (deriva de w_carga).
    /// Se preservan nombres de controles y eventos. LÓGICA integrada únicamente donde está explícita en SRW.
    /// </summary>
    public partial class w_carga_reperto_parcial : Form
    {
        /// <summary>Emula variable PB 'is_Pasada'</summary>
        public string is_Pasada { get; set; } = string.Empty;

        /// <summary>Emula variable PB 'il_Modo'</summary>
        public int il_Modo { get; set; } = 0;

        /// <summary>DSN ODBC para emular USING SQLCA (SQL Anywhere 9)</summary>
        public string Dsn { get; set; } = string.Empty;

        public w_carga_reperto_parcial()
        {
            InitializeComponent();

            // Wire del evento 'clicked' de cb_reperto_parcial: is_Pasada = 'PARCIAL'; wf_dibujar_detalle()
            this.cb_reperto_parcial.Click += (s, e) =>
            {
                // PB: is_Pasada = 'PARCIAL'
                this.is_Pasada = "PARCIAL";
                // PB: wf_dibujar_detalle()
                this.wf_dibujar_detalle();
            };
        }

        /// <summary>
        /// event ue_iniciar; (extracto del SRW)
        /// - astp_w_seleccion = Message.PowerObjectParm
        /// - ls_Argumentos = astp_w_seleccion.Parametros
        /// - dw_1.uof_Retrieve(ls_Argumentos)
        /// - Luego des-selecciona síntomas por defecto
        /// </summary>
        public void ue_iniciar(string[] ls_Argumentos)
        {
            // En PB: dw_1.uof_Retrieve(ls_Argumentos)
            // Aquí dejamos el hook; el llenado real de dw_1 depende del DataWindow original (.srd).
            // Des-seleccionar síntomas por defecto si existe columna 'seleccionado'.
            if (dw_1.DataSource is DataTable dt)
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Columns.Contains("seleccionado"))
                        r["seleccionado"] = DBNull.Value;
                }
            }
        }

        /// <summary>
        /// Stub preservando el nombre PB. Se llama desde el 'clicked' de cb_reperto_parcial.
        /// </summary>
        public void wf_dibujar_detalle()
        {
            // Implementación real pertenece al PB original y otras unidades;
            // se conserva el nombre para no romper referencias.
        }
    }
}