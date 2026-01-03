using System;
using System.Data.Odbc;
using System.Windows.Forms;
namespace Minotti
{
    public partial class w_reperto_capitulos : Form
    {
        public string Dsn { get; set; } = string.Empty;
        public w_reperto_capitulos()
        {
            InitializeComponent();
            this.cb_reperto_parcial.Click += (s, e) => cb_reperto_parcial_clicked();
            this.cb_reperto_total.Click += (s, e) => cb_reperto_total_clicked();
        }
        public void cb_reperto_parcial_clicked() { }
        public void cb_reperto_total_clicked() { }
        public void uo_borrar_todo_reperto_parcial()
        {
            if (string.IsNullOrWhiteSpace(this.Dsn)) throw new InvalidOperationException("Debe asignar DSN para ejecutar SQL (USING SQLCA).");
            using var cn = new OdbcConnection($"DSN={this.Dsn};");
            cn.Open();
            using var tx = cn.BeginTransaction();
            try
            {
                using (var cmd = cn.CreateCommand()){ cmd.Transaction = tx; cmd.CommandText = "DELETE FROM reperto_parcial_med"; cmd.ExecuteNonQuery(); }
                using (var cmd = cn.CreateCommand()){ cmd.Transaction = tx; cmd.CommandText = "DELETE FROM reperto_parcial"; cmd.ExecuteNonQuery(); }
                tx.Commit();
            } catch { try { tx.Rollback(); } catch {} throw; }
        }
    }
}