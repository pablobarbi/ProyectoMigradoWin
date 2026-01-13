using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Repositories
{
    public class d_perfiles_x_usuario
    {
        private const string SQL = @"
                                        SELECT DISTINCT acc_perfiles.perfil,
                                                        acc_perfiles.nombre
                                        FROM acc_perfiles,
                                             acc_usuarios
                                        WHERE acc_perfiles.perfil = acc_usuarios.perfil
                                          AND acc_usuarios.usuario = :usuario";



        public static DataTable Retrieve(string usuario)
        {
            return SQLCA.ExecuteDataTable(SQL, cmd =>
            {
                var prm = cmd.CreateParameter();
                prm.Value = usuario;
                cmd.Parameters.Add(prm);
            });
        }

    }
}
