using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Repositories
{
    public sealed class w_reporte_actualizar_matriz_dao
    {
        public void DeleteCapitulacionesMatriz()
            => ExecNonQuery(@"
DELETE FROM capitulaciones_matriz WHERE 1 = 1
");

        public void InsertNivel8()
            => ExecNonQuery(@"
INSERT INTO capitulaciones_matriz ( capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre, subrubrica03, subrubrica03_nombre, subrubrica04, subrubrica04_nombre, subrubrica05, subrubrica05_nombre, subrubrica06, subrubrica06_nombre, subrubrica07, subrubrica07_nombre , subrubrica08, subrubrica08_nombre ) 
  SELECT capitulos.capitulo,
         capitulos.nombre,
         rubricas.rubrica,
         rubricas.nombre,
         subrubricas.subrubrica AS subrubrica,
         subrubricas.nombre  AS subrubrica_nombre,
         sub1.subrubrica AS subrubrica01,
         sub1.nombre  AS subrubrica01_nombre,
         sub2.subrubrica AS subrubrica02,
         sub2.nombre  AS subrubrica02_nombre,
         sub3.subrubrica AS subrubrica03,
         sub3.nombre  AS subrubrica03_nombre,
         sub4.subrubrica AS subrubrica04,
         sub4.nombre  AS subrubrica04_nombre,
         sub5.subrubrica AS subrubrica05,
         sub5.nombre  AS subrubrica05_nombre,
         sub6.subrubrica AS subrubrica06,
         sub6.nombre  AS subrubrica06_nombre,
         sub7.subrubrica AS subrubrica07,
         sub7.nombre  AS subrubrica07_nombre,
         sub8.subrubrica AS subrubrica08,
         sub8.nombre  AS subrubrica08_nombre
    FROM capitulaciones
        , capitulos
        , rubricas
        , rubricaciones 
        , subrubricas 
        , subrubricaciones subr1
        , subrubricas         sub1
        , subrubricaciones subr2
        , subrubricas         sub2
        , subrubricaciones subr3
        , subrubricas         sub3
        , subrubricaciones subr4
        , subrubricas         sub4
        , subrubricaciones subr5
        , subrubricas         sub5
        , subrubricaciones subr6
        , subrubricas         sub6
        , subrubricaciones subr7
        , subrubricas         sub7
        , subrubricaciones subr8
        , subrubricas         sub8
   WHERE capitulaciones.capitulo = capitulos.capitulo
     AND capitulaciones.rubrica = rubricas.rubrica
     AND rubricaciones.rubrica = rubricas.rubrica
     AND rubricaciones.subrubrica = subrubricas.subrubrica
     AND subr1.subrubrica_padre = subrubricas.subrubrica
     AND subr1.subrubrica_hija = sub1.subrubrica
     AND subr2.subrubrica_padre = sub1.subrubrica
     AND subr2.subrubrica_hija = sub2.subrubrica
     AND subr3.subrubrica_padre = sub2.subrubrica
     AND subr3.subrubrica_hija = sub3.subrubrica
     AND subr4.subrubrica_padre = sub3.subrubrica
     AND subr4.subrubrica_hija = sub4.subrubrica
     AND subr5.subrubrica_padre = sub4.subrubrica
     AND subr5.subrubrica_hija = sub5.subrubrica
     AND subr6.subrubrica_padre = sub5.subrubrica
     AND subr6.subrubrica_hija = sub6.subrubrica
     AND subr7.subrubrica_padre = sub6.subrubrica
     AND subr7.subrubrica_hija = sub7.subrubrica
     AND subr8.subrubrica_padre = sub7.subrubrica
     AND subr8.subrubrica_hija = sub8.subrubrica
");

        public void InsertNivel7() => ExecNonQuery(/* SQL EXACTO */ @"
INSERT INTO capitulaciones_matriz ( capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre, subrubrica03, subrubrica03_nombre, subrubrica04, subrubrica04_nombre, subrubrica05, subrubrica05_nombre, subrubrica06, subrubrica06_nombre, subrubrica07, subrubrica07_nombre ) 
  SELECT capitulos.capitulo,
         capitulos.nombre,
         rubricas.rubrica,
         rubricas.nombre,
         subrubricas.subrubrica AS subrubrica,
         subrubricas.nombre  AS subrubrica_nombre,
         sub1.subrubrica AS subrubrica01,
         sub1.nombre  AS subrubrica01_nombre,
         sub2.subrubrica AS subrubrica02,
         sub2.nombre  AS subrubrica02_nombre,
         sub3.subrubrica AS subrubrica03,
         sub3.nombre  AS subrubrica03_nombre,
         sub4.subrubrica AS subrubrica04,
         sub4.nombre  AS subrubrica04_nombre,
         sub5.subrubrica AS subrubrica05,
         sub5.nombre  AS subrubrica05_nombre,
         sub6.subrubrica AS subrubrica06,
         sub6.nombre  AS subrubrica06_nombre,
         sub7.subrubrica AS subrubrica07,
         sub7.nombre  AS subrubrica07_nombre
    FROM capitulaciones
        , capitulos
        , rubricas
        , rubricaciones 
        , subrubricas 
        , subrubricaciones subr1
        , subrubricas         sub1
        , subrubricaciones subr2
        , subrubricas         sub2
        , subrubricaciones subr3
        , subrubricas         sub3
        , subrubricaciones subr4
        , subrubricas         sub4
        , subrubricaciones subr5
        , subrubricas         sub5
        , subrubricaciones subr6
        , subrubricas         sub6
        , subrubricaciones subr7
        , subrubricas         sub7
   WHERE capitulaciones.capitulo = capitulos.capitulo
     AND capitulaciones.rubrica = rubricas.rubrica
     AND rubricaciones.rubrica = rubricas.rubrica
     AND rubricaciones.subrubrica = subrubricas.subrubrica
     AND subr1.subrubrica_padre = subrubricas.subrubrica
     AND subr1.subrubrica_hija = sub1.subrubrica
     AND subr2.subrubrica_padre = sub1.subrubrica
     AND subr2.subrubrica_hija = sub2.subrubrica
     AND subr3.subrubrica_padre = sub2.subrubrica
     AND subr3.subrubrica_hija = sub3.subrubrica
     AND subr4.subrubrica_padre = sub3.subrubrica
     AND subr4.subrubrica_hija = sub4.subrubrica
     AND subr5.subrubrica_padre = sub4.subrubrica
     AND subr5.subrubrica_hija = sub5.subrubrica
     AND subr6.subrubrica_padre = sub5.subrubrica
     AND subr6.subrubrica_hija = sub6.subrubrica
     AND subr7.subrubrica_padre = sub6.subrubrica
     AND subr7.subrubrica_hija = sub7.subrubrica
");

        // Los siguientes siguen el mismo patrón (SQL exacto del PB).
        // Te los dejo completos para pegar (son largos pero 1:1):

        public void InsertNivel6() => ExecNonQuery(@"
INSERT INTO capitulaciones_matriz ( capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre, subrubrica03, subrubrica03_nombre, subrubrica04, subrubrica04_nombre, subrubrica05, subrubrica05_nombre, subrubrica06, subrubrica06_nombre ) 
SELECT * 
FROM (SELECT capitulos.capitulo AS capitulo,
         capitulos.nombre AS capitulo_nombre,
         rubricas.rubrica AS rubrica,
         rubricas.nombre AS rubrica_nombre,
         subrubricas.subrubrica AS subrubrica,
         subrubricas.nombre  AS subrubrica_nombre,
         sub1.subrubrica AS subrubrica01,
         sub1.nombre  AS subrubrica01_nombre,
         sub2.subrubrica AS subrubrica02,
         sub2.nombre  AS subrubrica02_nombre,
         sub3.subrubrica AS subrubrica03,
         sub3.nombre  AS subrubrica03_nombre,
         sub4.subrubrica AS subrubrica04,
         sub4.nombre  AS subrubrica04_nombre,
         sub5.subrubrica AS subrubrica05,
         sub5.nombre  AS subrubrica05_nombre,
         sub6.subrubrica AS subrubrica06,
         sub6.nombre  AS subrubrica06_nombre
    FROM capitulaciones
        , capitulos
        , rubricas
        , rubricaciones 
        , subrubricas 
        , subrubricaciones subr1
        , subrubricas         sub1
        , subrubricaciones subr2
        , subrubricas         sub2
        , subrubricaciones subr3
        , subrubricas         sub3
        , subrubricaciones subr4
        , subrubricas         sub4
        , subrubricaciones subr5
        , subrubricas         sub5
        , subrubricaciones subr6
        , subrubricas         sub6
   WHERE capitulaciones.capitulo = capitulos.capitulo
     AND capitulaciones.rubrica = rubricas.rubrica
     AND rubricaciones.rubrica = rubricas.rubrica
     AND rubricaciones.subrubrica = subrubricas.subrubrica
     AND subr1.subrubrica_padre = subrubricas.subrubrica
     AND subr1.subrubrica_hija = sub1.subrubrica
     AND subr2.subrubrica_padre = sub1.subrubrica
     AND subr2.subrubrica_hija = sub2.subrubrica
     AND subr3.subrubrica_padre = sub2.subrubrica
     AND subr3.subrubrica_hija = sub3.subrubrica
     AND subr4.subrubrica_padre = sub3.subrubrica
     AND subr4.subrubrica_hija = sub4.subrubrica
     AND subr5.subrubrica_padre = sub4.subrubrica
     AND subr5.subrubrica_hija = sub5.subrubrica
     AND subr6.subrubrica_padre = sub5.subrubrica
     AND subr6.subrubrica_hija = sub6.subrubrica) subr6
WHERE NOT EXISTS ( select '' from capitulaciones_matriz cm
                    where cm.capitulo     = subr6.capitulo 
                      and cm.rubrica      = subr6.rubrica
                      and cm.subrubrica   = subr6.subrubrica
                      and cm.subrubrica01 = subr6.subrubrica01
                      and cm.subrubrica02 = subr6.subrubrica02
                      and cm.subrubrica03 = subr6.subrubrica03
                      and cm.subrubrica04 = subr6.subrubrica04
                      and cm.subrubrica05 = subr6.subrubrica05
                      and cm.subrubrica06 = subr6.subrubrica06 )
");

        public void InsertNivel5() => ExecNonQuery(@"
INSERT INTO capitulaciones_matriz ( capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre, subrubrica03, subrubrica03_nombre, subrubrica04, subrubrica04_nombre, subrubrica05, subrubrica05_nombre ) 
SELECT * 
FROM (  SELECT capitulos.capitulo AS capitulo,
         capitulos.nombre AS capitulo_nombre,
         rubricas.rubrica AS rubrica, 
         rubricas.nombre AS rubrica_nombre,
         subrubricas.subrubrica AS subrubrica,
         subrubricas.nombre  AS subrubrica_nombre,
         sub1.subrubrica AS subrubrica01,
         sub1.nombre  AS subrubrica01_nombre,
         sub2.subrubrica AS subrubrica02,
         sub2.nombre  AS subrubrica02_nombre,
         sub3.subrubrica AS subrubrica03,
         sub3.nombre  AS subrubrica03_nombre,
         sub4.subrubrica AS subrubrica04,
         sub4.nombre  AS subrubrica04_nombre,
         sub5.subrubrica AS subrubrica05,
         sub5.nombre  AS subrubrica05_nombre
    FROM capitulaciones
        , capitulos
        , rubricas
        , rubricaciones 
        , subrubricas 
        , subrubricaciones subr1
        , subrubricas         sub1
        , subrubricaciones subr2
        , subrubricas         sub2
        , subrubricaciones subr3
        , subrubricas         sub3
        , subrubricaciones subr4
        , subrubricas         sub4
        , subrubricaciones subr5
        , subrubricas         sub5
   WHERE capitulaciones.capitulo = capitulos.capitulo
     AND capitulaciones.rubrica = rubricas.rubrica
     AND rubricaciones.rubrica = rubricas.rubrica
     AND rubricaciones.subrubrica = subrubricas.subrubrica
     AND subr1.subrubrica_padre = subrubricas.subrubrica
     AND subr1.subrubrica_hija = sub1.subrubrica
     AND subr2.subrubrica_padre = sub1.subrubrica
     AND subr2.subrubrica_hija = sub2.subrubrica
     AND subr3.subrubrica_padre = sub2.subrubrica
     AND subr3.subrubrica_hija = sub3.subrubrica
     AND subr4.subrubrica_padre = sub3.subrubrica
     AND subr4.subrubrica_hija = sub4.subrubrica
     AND subr5.subrubrica_padre = sub4.subrubrica
     AND subr5.subrubrica_hija = sub5.subrubrica) subr6
WHERE NOT EXISTS ( select '' from capitulaciones_matriz cm
                    where cm.capitulo     = subr6.capitulo 
                      and cm.rubrica      = subr6.rubrica
                      and cm.subrubrica   = subr6.subrubrica
                      and cm.subrubrica01 = subr6.subrubrica01
                      and cm.subrubrica02 = subr6.subrubrica02
                      and cm.subrubrica03 = subr6.subrubrica03
                      and cm.subrubrica04 = subr6.subrubrica04
                      and cm.subrubrica05 = subr6.subrubrica05 )
");

        public void InsertNivel4() => ExecNonQuery(@"
INSERT INTO capitulaciones_matriz ( capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre, subrubrica03, subrubrica03_nombre, subrubrica04, subrubrica04_nombre ) 
SELECT * 
FROM (  SELECT capitulos.capitulo AS capitulo,
         capitulos.nombre AS capitulo_nombre,
         rubricas.rubrica AS rubrica, 
         rubricas.nombre AS rubrica_nombre,
         subrubricas.subrubrica AS subrubrica,
         subrubricas.nombre  AS subrubrica_nombre,
         sub1.subrubrica AS subrubrica01,
         sub1.nombre  AS subrubrica01_nombre,
         sub2.subrubrica AS subrubrica02,
         sub2.nombre  AS subrubrica02_nombre,
         sub3.subrubrica AS subrubrica03,
         sub3.nombre  AS subrubrica03_nombre,
         sub4.subrubrica AS subrubrica04,
         sub4.nombre  AS subrubrica04_nombre
    FROM capitulaciones
        , capitulos
        , rubricas
        , rubricaciones 
        , subrubricas 
        , subrubricaciones subr1
        , subrubricas         sub1
        , subrubricaciones subr2
        , subrubricas         sub2
        , subrubricaciones subr3
        , subrubricas         sub3
        , subrubricaciones subr4
        , subrubricas         sub4
   WHERE capitulaciones.capitulo = capitulos.capitulo
     AND capitulaciones.rubrica = rubricas.rubrica
     AND rubricaciones.rubrica = rubricas.rubrica
     AND rubricaciones.subrubrica = subrubricas.subrubrica
     AND subr1.subrubrica_padre = subrubricas.subrubrica
     AND subr1.subrubrica_hija = sub1.subrubrica
     AND subr2.subrubrica_padre = sub1.subrubrica
     AND subr2.subrubrica_hija = sub2.subrubrica
     AND subr3.subrubrica_padre = sub2.subrubrica
     AND subr3.subrubrica_hija = sub3.subrubrica
     AND subr4.subrubrica_padre = sub3.subrubrica
     AND subr4.subrubrica_hija = sub4.subrubrica) subr6
WHERE NOT EXISTS ( select '' from capitulaciones_matriz cm
                    where cm.capitulo     = subr6.capitulo 
                      and cm.rubrica      = subr6.rubrica
                      and cm.subrubrica   = subr6.subrubrica
                      and cm.subrubrica01 = subr6.subrubrica01
                      and cm.subrubrica02 = subr6.subrubrica02
                      and cm.subrubrica03 = subr6.subrubrica03
                      and cm.subrubrica04 = subr6.subrubrica04 )
");

        public void InsertNivel3() => ExecNonQuery(@"
INSERT INTO capitulaciones_matriz ( capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre, subrubrica03, subrubrica03_nombre ) 
SELECT * 
FROM (  SELECT capitulos.capitulo AS capitulo,
         capitulos.nombre AS capitulo_nombre,
         rubricas.rubrica AS rubrica, 
         rubricas.nombre AS rubrica_nombre,
         subrubricas.subrubrica AS subrubrica,
         subrubricas.nombre  AS subrubrica_nombre,
         sub1.subrubrica AS subrubrica01,
         sub1.nombre  AS subrubrica01_nombre,
         sub2.subrubrica AS subrubrica02,
         sub2.nombre  AS subrubrica02_nombre,
         sub3.subrubrica AS subrubrica03,
         sub3.nombre  AS subrubrica03_nombre
    FROM capitulaciones
        , capitulos
        , rubricas
        , rubricaciones 
        , subrubricas 
        , subrubricaciones subr1
        , subrubricas         sub1
        , subrubricaciones subr2
        , subrubricas         sub2
        , subrubricaciones subr3
        , subrubricas         sub3
   WHERE capitulaciones.capitulo = capitulos.capitulo
     AND capitulaciones.rubrica = rubricas.rubrica
     AND rubricaciones.rubrica = rubricas.rubrica
     AND rubricaciones.subrubrica = subrubricas.subrubrica
     AND subr1.subrubrica_padre = subrubricas.subrubrica
     AND subr1.subrubrica_hija = sub1.subrubrica
     AND subr2.subrubrica_padre = sub1.subrubrica
     AND subr2.subrubrica_hija = sub2.subrubrica
     AND subr3.subrubrica_padre = sub2.subrubrica
     AND subr3.subrubrica_hija = sub3.subrubrica) subr6
WHERE NOT EXISTS ( select '' from capitulaciones_matriz cm
                    where cm.capitulo     = subr6.capitulo 
                      and cm.rubrica      = subr6.rubrica
                      and cm.subrubrica   = subr6.subrubrica
                      and cm.subrubrica01 = subr6.subrubrica01
                      and cm.subrubrica02 = subr6.subrubrica02
                      and cm.subrubrica03 = subr6.subrubrica03 )
");

        public void InsertNivel2() => ExecNonQuery(@"
INSERT INTO capitulaciones_matriz ( capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre ) 
SELECT * 
FROM (  SELECT capitulos.capitulo AS capitulo,
         capitulos.nombre AS capitulo_nombre,
         rubricas.rubrica AS rubrica, 
         rubricas.nombre AS rubrica_nombre,
         subrubricas.subrubrica AS subrubrica,
         subrubricas.nombre  AS subrubrica_nombre,
         sub1.subrubrica AS subrubrica01,
         sub1.nombre  AS subrubrica01_nombre,
         sub2.subrubrica AS subrubrica02,
         sub2.nombre  AS subrubrica02_nombre
    FROM capitulaciones
        , capitulos
        , rubricas
        , rubricaciones 
        , subrubricas 
        , subrubricaciones subr1
        , subrubricas         sub1
        , subrubricaciones subr2
        , subrubricas         sub2
   WHERE capitulaciones.capitulo = capitulos.capitulo
     AND capitulaciones.rubrica = rubricas.rubrica
     AND rubricaciones.rubrica = rubricas.rubrica
     AND rubricaciones.subrubrica = subrubricas.subrubrica
     AND subr1.subrubrica_padre = subrubricas.subrubrica
     AND subr1.subrubrica_hija = sub1.subrubrica
     AND subr2.subrubrica_padre = sub1.subrubrica
     AND subr2.subrubrica_hija = sub2.subrubrica) subr6
WHERE NOT EXISTS ( select '' from capitulaciones_matriz cm
                    where cm.capitulo     = subr6.capitulo 
                      and cm.rubrica      = subr6.rubrica
                      and cm.subrubrica   = subr6.subrubrica
                      and cm.subrubrica01 = subr6.subrubrica01
                      and cm.subrubrica02 = subr6.subrubrica02 )
");

        public void InsertNivel1() => ExecNonQuery(@"
INSERT INTO capitulaciones_matriz ( capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre ) 
SELECT * 
FROM (  SELECT capitulos.capitulo AS capitulo,
         capitulos.nombre AS capitulo_nombre,
         rubricas.rubrica AS rubrica, 
         rubricas.nombre AS rubrica_nombre,
         subrubricas.subrubrica AS subrubrica,
         subrubricas.nombre  AS subrubrica_nombre,
         sub1.subrubrica AS subrubrica01,
         sub1.nombre  AS subrubrica01_nombre
    FROM capitulaciones
        , capitulos
        , rubricas
        , rubricaciones 
        , subrubricas 
        , subrubricaciones subr1
        , subrubricas         sub1
   WHERE capitulaciones.capitulo = capitulos.capitulo
     AND capitulaciones.rubrica = rubricas.rubrica
     AND rubricaciones.rubrica = rubricas.rubrica
     AND rubricaciones.subrubrica = subrubricas.subrubrica
     AND subr1.subrubrica_padre = subrubricas.subrubrica
     AND subr1.subrubrica_hija = sub1.subrubrica) subr6
WHERE NOT EXISTS ( select '' from capitulaciones_matriz cm
                    where cm.capitulo     = subr6.capitulo 
                      and cm.rubrica      = subr6.rubrica
                      and cm.subrubrica   = subr6.subrubrica
                      and cm.subrubrica01 = subr6.subrubrica01 )
");

        public void InsertNivelRubricaciones() => ExecNonQuery(@"
INSERT INTO capitulaciones_matriz ( capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre ) 
SELECT * 
FROM (  SELECT capitulos.capitulo AS capitulo,
         capitulos.nombre AS capitulo_nombre,
         rubricas.rubrica AS rubrica, 
         rubricas.nombre AS rubrica_nombre,
         subrubricas.subrubrica AS subrubrica,
         subrubricas.nombre  AS subrubrica_nombre
    FROM capitulaciones
        , capitulos
        , rubricas
        , rubricaciones 
        , subrubricas 
   WHERE capitulaciones.capitulo = capitulos.capitulo
     AND capitulaciones.rubrica = rubricas.rubrica
     AND rubricaciones.rubrica = rubricas.rubrica
     AND rubricaciones.subrubrica = subrubricas.subrubrica) subr6
WHERE NOT EXISTS ( select '' from capitulaciones_matriz cm
                    where cm.capitulo     = subr6.capitulo 
                      and cm.rubrica      = subr6.rubrica
                      and cm.subrubrica   = subr6.subrubrica )
");

        public void InsertNivelCapitulaciones() => ExecNonQuery(@"
INSERT INTO capitulaciones_matriz ( capitulo, capitulo_nombre, rubrica, rubrica_nombre ) 
SELECT * 
FROM (  SELECT capitulos.capitulo AS capitulo,
         capitulos.nombre AS capitulo_nombre,
         rubricas.rubrica AS rubrica, 
         rubricas.nombre AS rubrica_nombre
    FROM capitulaciones
        , capitulos
        , rubricas
   WHERE capitulaciones.capitulo = capitulos.capitulo
     AND capitulaciones.rubrica = rubricas.rubrica) subr6
WHERE NOT EXISTS ( select '' from capitulaciones_matriz cm
                    where cm.capitulo     = subr6.capitulo 
                      and cm.rubrica      = subr6.rubrica )
");

        private static void ExecNonQuery(string sql)
        {
            // Ejecuta usando SQLCA (ODBC) en la transacción actual
            using var cmd = new OdbcCommand(sql, SQLCA.Connection, SQLCA.CurrentTransaction);
            SQLCA.ExecuteNonQuery(cmd);
        }
    }
}
