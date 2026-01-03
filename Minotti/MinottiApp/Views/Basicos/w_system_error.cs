using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_system_error.srw
    // Herencia en PB: w_system_error from w_response
    // PB: global type w_system_error from w_response
    public partial class w_system_error : w_response
    {
        // ======================================================
        // Campo que emula el "error" global de PowerBuilder
        // (lo cargás cuando instanciás la ventana)
        // ======================================================
        public PBSystemError error { get; set; }

        public w_system_error()
        {
            InitializeComponent();
            this.Load += w_system_error_Load;
        }

        public w_system_error(PBSystemError error) : this()
        {
            this.error = error;
        }

        // ======================================================
        // OPEN (PB) → Load (C#)
        // ======================================================
        private void w_system_error_Load(object? sender, EventArgs e)
        {
            // Equivalente a:
            // DateTime fh
            // fh = DateTime(today(), now())
            var fh = DateTime.Now;

            // DataWindow / UO
            // PB: dw_error.DataObject = 'd_system_error'
            dw_error.uof_setdataobject("d_system_error");

            // PB:
            // dw_error.insertrow (1)
            // dw_error.setitem (...)
            dw_error.InsertRow(1);

            if (error != null)
            {
                dw_error.SetItem(1, "nro_error", error.Number);
                dw_error.SetItem(1, "mensaje_error", error.Text ?? string.Empty);
                dw_error.SetItem(1, "lugar", error.WindowMenu ?? string.Empty);
                dw_error.SetItem(1, "objeto", error.Object ?? string.Empty);
                dw_error.SetItem(1, "evento", error.ObjectEvent ?? string.Empty);
                dw_error.SetItem(1, "linea_script", error.Line);
                dw_error.SetItem(1, "fecha_hora", fh);
            }

            // Asigno la dw de impresión
            // PB: dw_error.uof_setdwimpresion('d_system_error_impresion')
            dw_error.uof_setdwimpresion("d_system_error_impresion");

            // Si no hay SQLCA válido, no intento grabar
            if (SQLCA.Instance == null || SQLCA.Connection == null)
                return;

            // -----------------------------------------------------------------
            // Inserto el error en la base de datos (equivalente al INSERT PB)
            // -----------------------------------------------------------------
            try
            {
                using (var cmd = SQLCA.Connection.CreateCommand())
                {
                    cmd.CommandText = @"
INSERT INTO dba.par_error_sistema
    (nro_error,
     fecha_hora,
     lugar,
     objeto,
     evento,
     linea_script,
     mensaje_error)
VALUES (?,?,?,?,?,?,?)";

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(CreateParam(cmd, error?.Number ?? 0));
                    cmd.Parameters.Add(CreateParam(cmd, fh));
                    cmd.Parameters.Add(CreateParam(cmd, error?.WindowMenu ?? string.Empty));
                    cmd.Parameters.Add(CreateParam(cmd, error?.Object ?? string.Empty));
                    cmd.Parameters.Add(CreateParam(cmd, error?.ObjectEvent ?? string.Empty));
                    cmd.Parameters.Add(CreateParam(cmd, error?.Line ?? 0));
                    cmd.Parameters.Add(CreateParam(cmd, error?.Text ?? string.Empty));

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al grabar mensaje de error\n\nMensaje: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }
        }

        // Helper para parámetros ODBC
        private static OdbcParameter CreateParam(OdbcCommand cmd, object value)
        {
            var p = cmd.CreateParameter();
            p.Value = value ?? DBNull.Value;
            return p;
        }

        // ======================================================
        // Eventos de los botones (equivalentes a PB)
        // ======================================================

        // PB: cb_imprimir.clicked: dw_error.uof_Imprimir()
        private void cb_imprimir_Click(object? sender, EventArgs e)
        {
            dw_error.uof_imprimir();
        }

        // PB: cb_salir.clicked: Halt Close
        private void cb_salir_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        // PB: cb_continuar.clicked: Close(parent)
        private void cb_continuar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }

    // ==========================================================
    // STUB para el "error" de PowerBuilder
    // (si ya lo tenés definido en otro lado, borrá esto)
    // ==========================================================
    public class PBSystemError
    {
        public int Number { get; set; }
        public string? Text { get; set; }
        public string? WindowMenu { get; set; }
        public string? Object { get; set; }
        public string? ObjectEvent { get; set; }
        public int Line { get; set; }
    }

    // ==========================================================
    // STUB mínimo de SQLCA para compilar
    // (si ya tenés tu propia clase SQLCA, borrá o adaptá esto)
    // ==========================================================
    //public static class SQLCA
    //{
    //    public static OdbcConnection? Connection { get; set; }
    //    public static int SqlCode { get; set; }
    //    public static string? SqlErrText { get; set; }
    //}
}
