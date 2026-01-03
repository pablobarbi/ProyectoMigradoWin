using System;
using System.Data;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PB Window 'w_carga_reperto_total_multiple_bak' (deriva de w_carga).
    /// Se preservan nombres y se integra la lógica visible del SRW sin inventar.
    /// </summary>
    public partial class w_carga_reperto_total_multiple_bak : Form
    {
        /// <summary>Emula variable PB 'il_Modo'</summary>
        public int il_Modo { get; set; } = 0;

        public w_carga_reperto_total_multiple_bak()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Extracto literal del SRW (sin inventar):
        /// ELSEIF il_Modo = 1 THEN
        ///     // HAY QUE REDIBUJAR LA VENTANA Y MOSTRAR LA NUEVA DATAWINDOW.
        ///     il_Modo = 2
        ///     ll_Fila = dw_3.InsertRow(0)
        ///     ld_Fecha = Today()
        ///     dw_3.SetItem( ll_Fila, "fecha", ld_Fecha)
        ///     Parent.TriggerEvent("ue_acomodar_objetos")
        /// END IF
        /// 
        /// Lo mapeamos a un helper que podés invocar cuando corresponda en tu flujo actual.
        /// </summary>
        public void uo_redibujar_y_marcar_fecha_hoy()
        {
            if (this.il_Modo == 1)
            {
                this.il_Modo = 2;
                if (dw_3.DataSource is not DataTable dt3)
                {
                    dt3 = new DataTable();
                    dt3.Columns.Add("fecha", typeof(DateTime));
                    dw_3.DataSource = dt3;
                }
                // InsertRow(0) en PB agrega al principio. En DataTable, simplificamos agregando nueva fila.
                var r = dt3.NewRow();
                r["fecha"] = DateTime.Today;
                dt3.Rows.InsertAt(r, 0);

                // Parent.TriggerEvent("ue_acomodar_objetos") no tiene equivalente directo en WinForms;
                // se documenta la intención. Si tenés el manejador, lo invocás acá.
            }
        }
    }
}