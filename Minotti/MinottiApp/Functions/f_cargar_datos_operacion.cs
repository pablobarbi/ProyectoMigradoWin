using Minotti.Views.Basicos.Models;

namespace Minotti.Functions
{
    public class f_cargar_datos_operacion
    {
        public static int fcargar_datos_operacion(cat_operacion at_operacion)
        {
            string Alta, Baja, Modificacion;

            // Simulación de consulta a base de datos
            // Debes reemplazar este bloque por código para hacer la consulta real
            string query = "SELECT acc_operaciones.nombre, " +
                           "acc_operaciones.descripcion, " +
                           "acc_operaciones_x_modulo.alta, " +
                           "acc_operaciones_x_modulo.baja, " +
                           "acc_operaciones_x_modulo.modificacion " +
                           "FROM acc_operaciones_x_modulo, acc_operaciones " +
                           "WHERE acc_operaciones_x_modulo.modulo = @modulo " +
                           "AND acc_operaciones_x_modulo.operacion = acc_operaciones.operacion " +
                           "AND acc_operaciones.operacion = @operacion;";

            // Suponiendo que ejecutamos la consulta con algún ORM o ADO.NET
            // A continuación, simularíamos la asignación de valores del resultado
            Alta = "true"; // Debe venir de la base de datos
            Baja = "false"; // Debe venir de la base de datos
            Modificacion = "true"; // Debe venir de la base de datos

            // Si la consulta falla (simulando código de error)
            if (/* Aquí va la verificación real de error SQL */ false)
            {
                return -1; // Error de consulta
            }

            // Asignación de valores a la clase Operacion
            at_operacion.Alta = f_string_a_boolean(Alta);
            at_operacion.Modificacion = f_string_a_boolean(Modificacion);
            at_operacion.Baja = f_string_a_boolean(Baja);

            if (string.IsNullOrEmpty(at_operacion.Descripcion))
            {
                at_operacion.Descripcion = at_operacion.Nombre;
            }

            return 1;
        }

        // Convertir "Alta", "Baja" y "Modificacion" de string a boolean
        private static bool f_string_a_boolean(string value)
        {
            return value.ToLower() == "true";
        }
    }
}
