using Minotti.Data;
using System.Data;

namespace Minotti.Repositories
{
    public static class AccesoSql
    {
        // === dk_modulos_x_perfil (perf) ===
        private const string Q_ModulosPorPerfil = @"
SELECT dba.acc_modulos_x_perfil.perfil,
       dba.acc_modulos_x_perfil.modulo,
       dba.acc_modulos.nombre
  FROM dba.acc_modulos_x_perfil,
       dba.acc_modulos
 WHERE dba.acc_modulos.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = ?";

        // === DISTINCT modulos (perfil) ===
        private const string Q_ModulosDistinctPorPerfil = @"
SELECT DISTINCT dba.acc_modulos.modulo,
                dba.acc_modulos.nombre,
                dba.acc_modulos_x_perfil.perfil
  FROM dba.acc_modulos,
       dba.acc_modulos_x_perfil
 WHERE dba.acc_modulos.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = ?
 ORDER BY dba.acc_modulos.modulo";

        // === operaciones por perfil (perfil) ===
        private const string Q_OperacionesPorPerfil = @"
SELECT DISTINCT dba.acc_operaciones.operacion,
                dba.acc_operaciones.nombre,
                dba.acc_operaciones_x_modulo.modulo
  FROM dba.acc_modulos_x_perfil,
       dba.acc_operaciones_x_modulo,
       dba.acc_operaciones
 WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = ?
 ORDER BY dba.acc_operaciones_x_modulo.modulo,
          dba.acc_operaciones.operacion";

        // === operaciones + submodulo concatenado (perfil) (release 10.5) ===
        private const string Q_OperacionesSubmoduloPorPerfil = @"
SELECT DISTINCT dba.acc_operaciones.operacion,
                dba.acc_operaciones.nombre,
                dba.acc_operaciones_x_modulo.modulo + '*****' + dba.acc_operaciones_x_modulo.submodulo AS submodulo,
                dba.acc_operaciones_x_modulo.modulo
  FROM dba.acc_modulos_x_perfil,
       dba.acc_operaciones_x_modulo,
       dba.acc_operaciones
 WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = ?";

        // === submodulos (perfil) ===
        private const string Q_SubmodulosPorPerfil = @"
SELECT DISTINCT dba.acc_operaciones_x_modulo.modulo + '*****' + dba.acc_operaciones_x_modulo.submodulo AS submodulo,
                dba.acc_submodulos.nombre,
                dba.acc_operaciones_x_modulo.modulo
  FROM dba.acc_submodulos,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil
 WHERE dba.acc_operaciones_x_modulo.submodulo = dba.acc_submodulos.submodulo
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = ?";

        // === capitulos (capitulo) ===
        private const string Q_CapituloNombre = @"
SELECT capitulos.nombre
  FROM capitulos
 WHERE capitulos.capitulo = ?";

        // === rubricas (sin args) ===
        private const string Q_Rubricas = @"
SELECT rubricas.nombre
  FROM rubricas";

        // === subrubricas (sin args) ===
        private const string Q_Subrubricas = @"
SELECT subrubricas.nombre
  FROM subrubricas";

        // ==== API ====

        public static DataTable GetModulosPorPerfil(string perf) =>
            SQLCA.ExecuteDataTable(Q_ModulosPorPerfil, perf);

        public static DataTable GetModulosDistinctPorPerfil(string perfil) =>
            SQLCA.ExecuteDataTable(Q_ModulosDistinctPorPerfil, perfil);

        public static DataTable GetOperacionesPorPerfil(string perfil) =>
            SQLCA.ExecuteDataTable(Q_OperacionesPorPerfil, perfil);

        public static DataTable GetOperacionesSubmoduloPorPerfil(string perfil) =>
            SQLCA.ExecuteDataTable(Q_OperacionesSubmoduloPorPerfil, perfil);

        public static DataTable GetSubmodulosPorPerfil(string perfil) =>
            SQLCA.ExecuteDataTable(Q_SubmodulosPorPerfil, perfil);

        public static DataTable GetCapituloNombre(string capitulo) =>
            SQLCA.ExecuteDataTable(Q_CapituloNombre, capitulo);

        public static DataTable GetRubricas() =>
            SQLCA.ExecuteDataTable(Q_Rubricas);

        public static DataTable GetSubrubricas() =>
            SQLCA.ExecuteDataTable(Q_Subrubricas);
    }
}
