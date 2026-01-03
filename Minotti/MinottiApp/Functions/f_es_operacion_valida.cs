
using Microsoft.VisualBasic;
using Minotti;
using Minotti.Data;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using MinottiApp.utils;
using System;
using System.Data;
using System.Windows.Forms;


namespace Minotti.Functions
{
    public static class f_es_operacion_valida
    {
        /// <summary>
        /// Verifica si un nro de operacion es válido.
        /// Esta función chequea si existe y si el usuario que quiere ejecutarla
        /// tiene permiso para ella. (Comentario original de PowerBuilder)
        /// </summary>
        /// <param name="operacion">Código de operación</param>
        /// <param name="nivel">Nivel de la operación (mismo significado que en PB)</param>
        /// <param name="sqlca">Conexión a BD que reemplaza a SQLCA</param>
        /// <returns>1 si es válida y se abre la operación, -1 en error / sin permiso</returns>
        // PB: global function integer f_es_operacion_valida (string operacion, integer nivel)
        public static int fes_operacion_valida(string operacion, int nivel)
        {
            w_operacion wAux = null!; // en PB: w_operacion wAux (instancia para OpenSheetWithParm)
            cat_operacion at_operacion = new cat_operacion();
            cat_usuario at_usuario;
            int cantidad = 0;
            int retorno;

            // /* Obtengo el usuario */
            at_usuario = guo_app.uof_GetUsuario();

            // /* Verifico que la Operacion exista ... y tenga permiso alta='S' */
            const string sqlCount = @"
SELECT COUNT(*)
  FROM dba.acc_modulos_perfil
 WHERE dba.acc_modulos_perfil.perfil = ?
   AND dba.acc_modulos_perfil.modulo IN
       (SELECT dba.acc_operacion_mod.modulo
          FROM dba.acc_operacion_mod
         WHERE dba.acc_operacion_mod.operacion = ?
           AND dba.acc_operacion_mod.alta      = 'S')";

            try
            {
                DataTable dtCount = SQLCA.ExecuteDataTable(sqlCount, cmd =>
                {
                    SQLCA.AddParam(cmd, at_usuario.Perfil);
                    SQLCA.AddParam(cmd, operacion);
                });

                if (SQLCA.SqlCode == 0 && dtCount.Rows.Count > 0)
                {
                    // COUNT(*) siempre viene en la primera columna
                    cantidad = Convert.ToInt32(dtCount.Rows[0][0]);
                }
            }
            catch
            {
                // SQLCA ya setea SqlCode/SqlErrText. PB seguiría retornando 1 al final,
                // pero ante excepción real en C# mejor respetar el flujo de error:
                return -1;
            }

            if (SQLCA.SqlCode == 0 && cantidad == 1)
            {
                // /* Selecciono el Modulo en donde se encuentra la operacion */
                const string sqlModulo = @"
SELECT dba.acc_operacion_mod.modulo
  FROM dba.acc_operacion_mod
 WHERE dba.acc_operacion_mod.operacion = ?
   AND dba.acc_operacion_mod.modulo IN
       (SELECT dba.acc_modulos_perfil.modulo
          FROM dba.acc_modulos_perfil
         WHERE dba.acc_modulos_perfil.perfil = ?)";

                try
                {
                    DataTable dtModulo = SQLCA.ExecuteDataTable(sqlModulo, cmd =>
                    {
                        SQLCA.AddParam(cmd, operacion);
                        SQLCA.AddParam(cmd, at_usuario.Perfil);
                    });

                    if (SQLCA.SqlCode == 0 && dtModulo.Rows.Count > 0)
                    {
                        at_operacion.Modulo = Convert.ToString(dtModulo.Rows[0][0]) ?? string.Empty;
                    }
                    else
                    {
                        return -1;
                    }
                }
                catch
                {
                    return -1;
                }

                // /* Lee los datos de la operación que va a ejecutar */
                at_operacion.Operacion = operacion;

                if (f_cargar_datos_operacion.fcargar_datos_operacion(at_operacion) != 1)
                {
                    MessageBox.Show("No se encontró la operación", "Atención!!!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return -1;
                }

                // /* Recupero los parametros de la Operacion */
                const string sqlParametros = @"
SELECT dba.acc_parametros.objeto,
       dba.acc_parametros.titulo,
       dba.acc_parametros.parametros
  FROM dba.acc_parametros
 WHERE dba.acc_parametros.operacion = ?
   AND dba.acc_parametros.Orden     = ?";

                try
                {
                    DataTable dtPar = SQLCA.ExecuteDataTable(sqlParametros, cmd =>
                    {
                        SQLCA.AddParam(cmd, operacion);
                        SQLCA.AddParam(cmd, nivel);
                    });

                    if (SQLCA.SqlCode == 0 && dtPar.Rows.Count > 0)
                    {
                        // PB: at_operacion.at_nvl[Nivel].Objeto/Titulo/parametros
                        // OJO: PB usa 1-based. Si tu at_nvl es 0-based en C#, ajustá el índice acá.
                        at_operacion.at_nvl[nivel].Objeto = Convert.ToString(dtPar.Rows[0]["objeto"]) ?? string.Empty;
                        at_operacion.at_nvl[nivel].Titulo = Convert.ToString(dtPar.Rows[0]["titulo"]) ?? string.Empty;
                        at_operacion.at_nvl[nivel].Parametros = Convert.ToString(dtPar.Rows[0]["parametros"]) ?? string.Empty;

                        at_operacion.at_nvl[nivel].Cierra = "N";
                        at_operacion.Accion = "A";
                        at_operacion.Orden = nivel;

                        // /* Abre la ventana detalle */
                        // PB:
                        // Retorno = OpenSheetWithParm (wAux, at_operacion, at_operacion.uof_GetObjeto(Nivel),
                        //                             guo_app.uof_Getmdi(), guo_app.Menu.Colgar, Original!)
                        retorno = OpenSheetWithParmPB.OpenSheetWithParm(
                            wAux,
                            at_operacion,
                            at_operacion.uof_getobjeto(nivel),
                            guo_app.uof_Getmdi(),
                            guo_app.Menu.Colgar,
                            PBOpenMode.Original);

                        // En PB no usa retorno para decidir acá.
                    }
                    else
                    {
                        // en PB sólo entra al IF si SQLCode = 0, sino no hace nada y cae al Return 1
                        // pero si no hay fila, no pudo leer parámetros => -1
                        return -1;
                    }
                }
                catch
                {
                    return -1;
                }
            }

            return 1;
        }
    }
}