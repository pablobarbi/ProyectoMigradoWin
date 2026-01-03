using Minotti.Views.Pbl.Models;

namespace Minotti.Functions
{
    public class f_cargar_datos_operacion_dbf
    {
        public static int F_cargar_datos_operacion_dbf(ref Operacion at_operacion)
        {
            string Alta, Baja, Modificacion;

            // Simulación de consulta a base de datos (usando ADO.NET o similar)
            string query = "SELECT operac.nombre, " +
                           "oper_mod.alta, " +
                           "oper_mod.baja, " +
                           "oper_mod.modificacion " +
                           "FROM oper_mod, operac " +
                           "WHERE oper_mod.modulo = @modulo " +
                           "AND oper_mod.operacion = operac.operacion " +
                           "AND operac.operacion = @operacion;";

            // Simulación de valores que deberían ser traídos desde la base de datos
            // Estos valores serían obtenidos de la base de datos realmente
            Alta = "true"; // Debe venir de la base de datos
            Baja = "false"; // Debe venir de la base de datos
            Modificacion = "true"; // Debe venir de la base de datos

            // Si la consulta falla, se devuelve -1 (simulando código de error SQL)
            if (/* Aquí va la verificación real de error SQL */ false)
            {
                return -1; // Error de consulta
            }

            // Asignación de los valores obtenidos de la base de datos al objeto `at_operacion`
            at_operacion.Alta = f_string_a_boolean(Alta);
            at_operacion.Modificacion = f_string_a_boolean(Modificacion);
            at_operacion.Baja = f_string_a_boolean(Baja);

            return 1;
        }

        // Convertir "Alta", "Baja" y "Modificacion" de string a boolean
        private static bool f_string_a_boolean(string value)
        {
            return value.ToLower() == "true";
        }
    }
}
