using Minotti.Data;
using Minotti.Views.Basicos;

namespace Minotti.Views.conect_anywhere.Controls
{
    // Migración de PowerBuilder: w_coneccion_anywhere.srw
    // Herencia: from w_coneccion
    public partial class w_coneccion_anywhere : w_coneccion
    {
        public w_coneccion_anywhere()
        {
            InitializeComponent();
        }

        // event ue_leer;call super::ue_leer;SQLCA.DbParm = "disablebind=1,ConnectString='DSN=" + SQLCA.Database + ...
        public override void ue_leer()
        {
            base.ue_leer();

            // PB:
            // SQLCA.DbParm  = "disablebind=1,ConnectString='DSN=" + SQLCA.Database + ";UID=" + SQLCA.LogID +
            //                ";PWD=" + SQLCA.LogPass + ";"
            //
            // En C# cierro el ConnectString con comilla simple (') como corresponde al formato de DBParm.
            SQLCA.DBParm =
                "disablebind=1,ConnectString='DSN=" + SQLCA.Database +
                ";UID=" + SQLCA.UserID +
                ";PWD=" + SQLCA.DBPass +
                ";'";
        }
    }
}
