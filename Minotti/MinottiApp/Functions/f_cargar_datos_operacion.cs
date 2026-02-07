using Minotti.Data;
using Minotti.Metadata.GeneratedSru;

namespace Minotti.Functions
{
    public class f_cargar_datos_operacion
    {
        public static int fcargar_datos_operacion(ref cat_operacion at_operacion)
        {
            if (at_operacion == null)
                return -1;

            const string SQL = @"
                                    SELECT acc_operaciones.nombre,
                                           acc_operaciones.descripcion,
                                           acc_operaciones_x_modulo.alta,
                                           acc_operaciones_x_modulo.baja,
                                           acc_operaciones_x_modulo.modificacion
                                      FROM acc_operaciones_x_modulo,
                                           acc_operaciones
                                     WHERE acc_operaciones_x_modulo.modulo     = ?
                                       AND acc_operaciones_x_modulo.operacion  = acc_operaciones.operacion
                                       AND acc_operaciones.operacion           = ?";

            try
            {
                using var cmd = SQLCA.CreateCommand(SQL);

                // === parámetros PB (posicionales) ===
                SQLCA.AddParam(cmd, at_operacion.Modulo);
                SQLCA.AddParam(cmd, at_operacion.Operacion);

                using var dr = SQLCA.ExecuteReader(cmd);

                if (!dr.Read())
                    return -1; // PB: SQLCA.SqlCode <> 0

                string alta = dr.IsDBNull(2) ? "" : dr.GetString(2);
                string baja = dr.IsDBNull(3) ? "" : dr.GetString(3);
                string modificacion = dr.IsDBNull(4) ? "" : dr.GetString(4);

                at_operacion.Nombre = dr.IsDBNull(0) ? "" : dr.GetString(0);
                at_operacion.Descripcion = dr.IsDBNull(1) ? "" : dr.GetString(1);

                at_operacion.Alta = f_string_a_boolean(alta);
                at_operacion.Baja = f_string_a_boolean(baja);
                at_operacion.Modificacion = f_string_a_boolean(modificacion);

                // === PB: fallback descripcion ===
                if (string.IsNullOrWhiteSpace(at_operacion.Descripcion))
                    at_operacion.Descripcion = at_operacion.Nombre;

                return 1;
            }
            catch
            {
                // Equivalente PB: SQLCA.SqlCode <> 0
                return -1;
            }
        }

        // Convertir "Alta", "Baja" y "Modificacion" de string a boolean
        private static bool f_string_a_boolean(string value)
        {
            return value.ToLower() == "s";
        }
    }
}
