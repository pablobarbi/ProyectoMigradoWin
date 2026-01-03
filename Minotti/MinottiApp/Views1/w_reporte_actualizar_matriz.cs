using System;
using System.Windows.Forms;

namespace Minotti
{
    //    // Migrado desde PowerBuilder Window: w_reporte_actualizar_matriz.srw
    //    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.
    //    public partial class w_reporte_actualizar_matriz : Form
    //    {
    //        public w_reporte_actualizar_matriz()
    //        {
    //            InitializeComponent();
    //        }

    //        /*
    //        ================== CONTENIDO ORIGINAL .SRW ==================
    //﻿forward
    //global type w_reporte_actualizar_matriz from w_reporte
    //end type
    //end forward


    //global type w_reporte_actualizar_matriz from w_reporte 
    //end type

    //global w_reporte_actualizar_matriz w_reporte_actualizar_matriz

    //on w_reporte_actualizar_matriz.create
    //call super::create
    //end on

    //on w_reporte_actualizar_matriz.destroy
    //call super::destroy
    //end on

    //event ue_procesar;/*  
    //    ATENCION!!! ANCESTOR SCRIPT OVERRIDE!!!
    //*/

    //        Integer fila


    //// ABRIENDO TRANSACCION
    //SetNull(guo_app.at_error_db.SqlDbCode)
    //SetNull(guo_app.at_error_db.SqlErrText)
    //SetNull(guo_app.at_error_db.UserErrorCode)
    //SetNull(guo_app.at_error_db.UserErrorText)

    //This.ib_AutoCommit = SQLCA.AutoCommit
    //SQLCA.AutoCommit = FALSE

    //ib_grabar = true


    ////-------------------------------------------------------------------------------------------
    ////-- ELIMINO LOS DATOS QUE TENGA CARGADA LA TABLA DE CAPITULACIONES
    //DELETE FROM capitulaciones_matriz WHERE 1 = 1 USING SQLCA;

    //        If SQLCA.SqlCode<> 0 Then ib_grabar = false


    ////--------------------------------------
    ////-- 8 niveles de subrubricaciones = 0
    //if ib_grabar = true then
    //        INSERT INTO capitulaciones_matriz (capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre, subrubrica03, subrubrica03_nombre, subrubrica04, subrubrica04_nombre, subrubrica05, subrubrica05_nombre, subrubrica06, subrubrica06_nombre, subrubrica07, subrubrica07_nombre, subrubrica08, subrubrica08_nombre)
    //          SELECT capitulos.capitulo,
    //                 capitulos.nombre,
    //                 rubricas.rubrica,
    //                 rubricas.nombre,
    //                 subrubricas.subrubrica AS subrubrica,
    //                 subrubricas.nombre AS subrubrica_nombre,
    //                 sub1.subrubrica AS subrubrica01,
    //                 sub1.nombre AS subrubrica01_nombre,
    //                 sub2.subrubrica AS subrubrica02,
    //                 sub2.nombre AS subrubrica02_nombre,
    //                 sub3.subrubrica AS subrubrica03,
    //                 sub3.nombre AS subrubrica03_nombre,
    //                 sub4.subrubrica AS subrubrica04,
    //                 sub4.nombre AS subrubrica04_nombre,
    //                 sub5.subrubrica AS subrubrica05,
    //                 sub5.nombre AS subrubrica05_nombre,
    //                 sub6.subrubrica AS subrubrica06,
    //                 sub6.nombre AS subrubrica06_nombre,
    //                 sub7.subrubrica AS subrubrica07,
    //                 sub7.nombre AS subrubrica07_nombre,
    //                 sub8.subrubrica AS subrubrica08,
    //                 sub8.nombre AS subrubrica08_nombre
    //            FROM capitulaciones

    //                , capitulos

    //                , rubricas

    //                , rubricaciones

    //                , subrubricas

    //                , subrubricaciones subr1
    //                , subrubricas sub1
    //                , subrubricaciones subr2
    //                , subrubricas sub2
    //                , subrubricaciones subr3
    //                , subrubricas sub3
    //                , subrubricaciones subr4
    //                , subrubricas sub4
    //                , subrubricaciones subr5
    //                , subrubricas sub5
    //                , subrubricaciones subr6
    //                , subrubricas sub6
    //                , subrubricaciones subr7
    //                , subrubricas sub7
    //                , subrubricaciones subr8
    //                , subrubricas sub8

    //           WHERE capitulaciones.capitulo = capitulos.capitulo

    //             AND capitulaciones.rubrica = rubricas.rubrica

    //             AND rubricaciones.rubrica = rubricas.rubrica

    //             AND rubricaciones.subrubrica = subrubricas.subrubrica

    //             AND subr1.subrubrica_padre = subrubricas.subrubrica

    //             AND subr1.subrubrica_hija = sub1.subrubrica

    //             AND subr2.subrubrica_padre = sub1.subrubrica

    //             AND subr2.subrubrica_hija = sub2.subrubrica

    //             AND subr3.subrubrica_padre = sub2.subrubrica

    //             AND subr3.subrubrica_hija = sub3.subrubrica

    //             AND subr4.subrubrica_padre = sub3.subrubrica

    //             AND subr4.subrubrica_hija = sub4.subrubrica

    //             AND subr5.subrubrica_padre = sub4.subrubrica

    //             AND subr5.subrubrica_hija = sub5.subrubrica

    //             AND subr6.subrubrica_padre = sub5.subrubrica

    //             AND subr6.subrubrica_hija = sub6.subrubrica

    //             AND subr7.subrubrica_padre = sub6.subrubrica

    //             AND subr7.subrubrica_hija = sub7.subrubrica

    //             AND subr8.subrubrica_padre = sub7.subrubrica

    //             AND subr8.subrubrica_hija = sub8.subrubrica
    //        USING SQLCA;
    //        end if

    //This.SetRedraw(FALSE)

    //fila = dw_reporte.InsertRow(0)
    //dw_reporte.SetItem(fila, 'renglon', 'Actualizando matriz nivel 8')

    //This.SetRedraw(TRUE)

    //If SQLCA.SqlCode<> 0 Then ib_grabar = false

    //if ib_grabar = true then
    ////--------------------------------------
    ////-- 7 niveles de subrubricaciones = 6
    //INSERT INTO capitulaciones_matriz(capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre, subrubrica03, subrubrica03_nombre, subrubrica04, subrubrica04_nombre, subrubrica05, subrubrica05_nombre, subrubrica06, subrubrica06_nombre, subrubrica07, subrubrica07_nombre )
    //  SELECT capitulos.capitulo,
    //         capitulos.nombre,
    //         rubricas.rubrica,
    //         rubricas.nombre,
    //         subrubricas.subrubrica AS subrubrica,
    //         subrubricas.nombre AS subrubrica_nombre,
    //         sub1.subrubrica AS subrubrica01,
    //         sub1.nombre AS subrubrica01_nombre,
    //         sub2.subrubrica AS subrubrica02,
    //         sub2.nombre AS subrubrica02_nombre,
    //         sub3.subrubrica AS subrubrica03,
    //         sub3.nombre AS subrubrica03_nombre,
    //         sub4.subrubrica AS subrubrica04,
    //         sub4.nombre AS subrubrica04_nombre,
    //         sub5.subrubrica AS subrubrica05,
    //         sub5.nombre AS subrubrica05_nombre,
    //         sub6.subrubrica AS subrubrica06,
    //         sub6.nombre AS subrubrica06_nombre,
    //         sub7.subrubrica AS subrubrica07,
    //         sub7.nombre AS subrubrica07_nombre
    //    FROM capitulaciones
    //        , capitulos
    //        , rubricas
    //        , rubricaciones
    //        , subrubricas
    //        , subrubricaciones subr1
    //        , subrubricas sub1
    //        , subrubricaciones subr2
    //        , subrubricas sub2
    //        , subrubricaciones subr3
    //        , subrubricas sub3
    //        , subrubricaciones subr4
    //        , subrubricas sub4
    //        , subrubricaciones subr5
    //        , subrubricas sub5
    //        , subrubricaciones subr6
    //        , subrubricas sub6
    //        , subrubricaciones subr7
    //        , subrubricas sub7
    //   WHERE capitulaciones.capitulo = capitulos.capitulo
    //     AND capitulaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.subrubrica = subrubricas.subrubrica
    //     AND subr1.subrubrica_padre = subrubricas.subrubrica
    //     AND subr1.subrubrica_hija = sub1.subrubrica
    //     AND subr2.subrubrica_padre = sub1.subrubrica
    //     AND subr2.subrubrica_hija = sub2.subrubrica
    //     AND subr3.subrubrica_padre = sub2.subrubrica
    //     AND subr3.subrubrica_hija = sub3.subrubrica
    //     AND subr4.subrubrica_padre = sub3.subrubrica
    //     AND subr4.subrubrica_hija = sub4.subrubrica
    //     AND subr5.subrubrica_padre = sub4.subrubrica
    //     AND subr5.subrubrica_hija = sub5.subrubrica
    //     AND subr6.subrubrica_padre = sub5.subrubrica
    //     AND subr6.subrubrica_hija = sub6.subrubrica
    //     AND subr7.subrubrica_padre = sub6.subrubrica
    //     AND subr7.subrubrica_hija = sub7.subrubrica
    //USING SQLCA;
    //        end if

    //This.SetRedraw(FALSE)

    //fila = dw_reporte.InsertRow(0)
    //dw_reporte.SetItem(fila, 'renglon', 'Actualizando matriz nivel 7')

    //This.SetRedraw(TRUE)


    //If SQLCA.SqlCode<> 0 Then ib_grabar = false

    //if ib_grabar = true then
    ////--------------------------------------
    ////-- 6 niveles de subrubricaciones = 13
    //INSERT INTO capitulaciones_matriz(capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre, subrubrica03, subrubrica03_nombre, subrubrica04, subrubrica04_nombre, subrubrica05, subrubrica05_nombre, subrubrica06, subrubrica06_nombre )

    //SELECT*
    //FROM(SELECT capitulos.capitulo AS capitulo,
    //         capitulos.nombre AS capitulo_nombre,
    //         rubricas.rubrica AS rubrica,
    //         rubricas.nombre AS rubrica_nombre,
    //         subrubricas.subrubrica AS subrubrica,
    //         subrubricas.nombre AS subrubrica_nombre,
    //         sub1.subrubrica AS subrubrica01,
    //         sub1.nombre AS subrubrica01_nombre,
    //         sub2.subrubrica AS subrubrica02,
    //         sub2.nombre AS subrubrica02_nombre,
    //         sub3.subrubrica AS subrubrica03,
    //         sub3.nombre AS subrubrica03_nombre,
    //         sub4.subrubrica AS subrubrica04,
    //         sub4.nombre AS subrubrica04_nombre,
    //         sub5.subrubrica AS subrubrica05,
    //         sub5.nombre AS subrubrica05_nombre,
    //         sub6.subrubrica AS subrubrica06,
    //         sub6.nombre AS subrubrica06_nombre
    //    FROM capitulaciones
    //        , capitulos
    //        , rubricas
    //        , rubricaciones
    //        , subrubricas
    //        , subrubricaciones subr1
    //        , subrubricas sub1
    //        , subrubricaciones subr2
    //        , subrubricas sub2
    //        , subrubricaciones subr3
    //        , subrubricas sub3
    //        , subrubricaciones subr4
    //        , subrubricas sub4
    //        , subrubricaciones subr5
    //        , subrubricas sub5
    //        , subrubricaciones subr6
    //        , subrubricas sub6
    //   WHERE capitulaciones.capitulo = capitulos.capitulo
    //     AND capitulaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.subrubrica = subrubricas.subrubrica
    //     AND subr1.subrubrica_padre = subrubricas.subrubrica
    //     AND subr1.subrubrica_hija = sub1.subrubrica
    //     AND subr2.subrubrica_padre = sub1.subrubrica
    //     AND subr2.subrubrica_hija = sub2.subrubrica
    //     AND subr3.subrubrica_padre = sub2.subrubrica
    //     AND subr3.subrubrica_hija = sub3.subrubrica
    //     AND subr4.subrubrica_padre = sub3.subrubrica
    //     AND subr4.subrubrica_hija = sub4.subrubrica
    //     AND subr5.subrubrica_padre = sub4.subrubrica
    //     AND subr5.subrubrica_hija = sub5.subrubrica
    //     AND subr6.subrubrica_padre = sub5.subrubrica
    //     AND subr6.subrubrica_hija = sub6.subrubrica) subr6
    //WHERE NOT EXISTS(select '' from capitulaciones_matriz cm
    //                    where cm.capitulo     = subr6.capitulo
    //                      and cm.rubrica      = subr6.rubrica
    //                      and cm.subrubrica   = subr6.subrubrica
    //                      and cm.subrubrica01 = subr6.subrubrica01
    //                      and cm.subrubrica02 = subr6.subrubrica02
    //                      and cm.subrubrica03 = subr6.subrubrica03
    //                      and cm.subrubrica04 = subr6.subrubrica04
    //                      and cm.subrubrica05 = subr6.subrubrica05
    //                      and cm.subrubrica06 = subr6.subrubrica06)
    //USING SQLCA;
    //        end if

    //This.SetRedraw(FALSE)

    //fila = dw_reporte.InsertRow(0)
    //dw_reporte.SetItem(fila, 'renglon', 'Actualizando matriz nivel 6')

    //This.SetRedraw(TRUE)

    //If SQLCA.SqlCode<> 0 Then ib_grabar = false

    //if ib_grabar = true then
    ////--------------------------------------
    ////-- 5 niveles de subrubricaciones = 181
    //INSERT INTO capitulaciones_matriz(capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre, subrubrica03, subrubrica03_nombre, subrubrica04, subrubrica04_nombre, subrubrica05, subrubrica05_nombre )

    //SELECT*
    //FROM(SELECT capitulos.capitulo AS capitulo,
    //         capitulos.nombre AS capitulo_nombre,
    //         rubricas.rubrica AS rubrica,
    //         rubricas.nombre AS rubrica_nombre,
    //         subrubricas.subrubrica AS subrubrica,
    //         subrubricas.nombre AS subrubrica_nombre,
    //         sub1.subrubrica AS subrubrica01,
    //         sub1.nombre AS subrubrica01_nombre,
    //         sub2.subrubrica AS subrubrica02,
    //         sub2.nombre AS subrubrica02_nombre,
    //         sub3.subrubrica AS subrubrica03,
    //         sub3.nombre AS subrubrica03_nombre,
    //         sub4.subrubrica AS subrubrica04,
    //         sub4.nombre AS subrubrica04_nombre,
    //         sub5.subrubrica AS subrubrica05,
    //         sub5.nombre AS subrubrica05_nombre
    //    FROM capitulaciones
    //        , capitulos
    //        , rubricas
    //        , rubricaciones
    //        , subrubricas
    //        , subrubricaciones subr1
    //        , subrubricas sub1
    //        , subrubricaciones subr2
    //        , subrubricas sub2
    //        , subrubricaciones subr3
    //        , subrubricas sub3
    //        , subrubricaciones subr4
    //        , subrubricas sub4
    //        , subrubricaciones subr5
    //        , subrubricas sub5
    //   WHERE capitulaciones.capitulo = capitulos.capitulo
    //     AND capitulaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.subrubrica = subrubricas.subrubrica
    //     AND subr1.subrubrica_padre = subrubricas.subrubrica
    //     AND subr1.subrubrica_hija = sub1.subrubrica
    //     AND subr2.subrubrica_padre = sub1.subrubrica
    //     AND subr2.subrubrica_hija = sub2.subrubrica
    //     AND subr3.subrubrica_padre = sub2.subrubrica
    //     AND subr3.subrubrica_hija = sub3.subrubrica
    //     AND subr4.subrubrica_padre = sub3.subrubrica
    //     AND subr4.subrubrica_hija = sub4.subrubrica
    //     AND subr5.subrubrica_padre = sub4.subrubrica
    //     AND subr5.subrubrica_hija = sub5.subrubrica) subr6
    //WHERE NOT EXISTS(select '' from capitulaciones_matriz cm
    //                    where cm.capitulo     = subr6.capitulo
    //                      and cm.rubrica      = subr6.rubrica
    //                      and cm.subrubrica   = subr6.subrubrica
    //                      and cm.subrubrica01 = subr6.subrubrica01
    //                      and cm.subrubrica02 = subr6.subrubrica02
    //                      and cm.subrubrica03 = subr6.subrubrica03
    //                      and cm.subrubrica04 = subr6.subrubrica04
    //                      and cm.subrubrica05 = subr6.subrubrica05)
    //USING SQLCA;
    //        end if

    //This.SetRedraw(FALSE)

    //fila = dw_reporte.InsertRow(0)
    //dw_reporte.SetItem(fila, 'renglon', 'Actualizando matriz nivel 5')

    //This.SetRedraw(TRUE)

    //If SQLCA.SqlCode<> 0 Then ib_grabar = false

    //if ib_grabar = true then
    ////-----------------------------------------
    ////-- 4 niveles de subrubricaciones = 1606
    //INSERT INTO capitulaciones_matriz(capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre, subrubrica03, subrubrica03_nombre, subrubrica04, subrubrica04_nombre )

    //SELECT*
    //FROM(SELECT capitulos.capitulo AS capitulo,
    //         capitulos.nombre AS capitulo_nombre,
    //         rubricas.rubrica AS rubrica,
    //         rubricas.nombre AS rubrica_nombre,
    //         subrubricas.subrubrica AS subrubrica,
    //         subrubricas.nombre AS subrubrica_nombre,
    //         sub1.subrubrica AS subrubrica01,
    //         sub1.nombre AS subrubrica01_nombre,
    //         sub2.subrubrica AS subrubrica02,
    //         sub2.nombre AS subrubrica02_nombre,
    //         sub3.subrubrica AS subrubrica03,
    //         sub3.nombre AS subrubrica03_nombre,
    //         sub4.subrubrica AS subrubrica04,
    //         sub4.nombre AS subrubrica04_nombre
    //    FROM capitulaciones
    //        , capitulos
    //        , rubricas
    //        , rubricaciones
    //        , subrubricas
    //        , subrubricaciones subr1
    //        , subrubricas sub1
    //        , subrubricaciones subr2
    //        , subrubricas sub2
    //        , subrubricaciones subr3
    //        , subrubricas sub3
    //        , subrubricaciones subr4
    //        , subrubricas sub4
    //   WHERE capitulaciones.capitulo = capitulos.capitulo
    //     AND capitulaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.subrubrica = subrubricas.subrubrica
    //     AND subr1.subrubrica_padre = subrubricas.subrubrica
    //     AND subr1.subrubrica_hija = sub1.subrubrica
    //     AND subr2.subrubrica_padre = sub1.subrubrica
    //     AND subr2.subrubrica_hija = sub2.subrubrica
    //     AND subr3.subrubrica_padre = sub2.subrubrica
    //     AND subr3.subrubrica_hija = sub3.subrubrica
    //     AND subr4.subrubrica_padre = sub3.subrubrica
    //     AND subr4.subrubrica_hija = sub4.subrubrica) subr6
    //WHERE NOT EXISTS(select '' from capitulaciones_matriz cm
    //                    where cm.capitulo     = subr6.capitulo
    //                      and cm.rubrica      = subr6.rubrica
    //                      and cm.subrubrica   = subr6.subrubrica
    //                      and cm.subrubrica01 = subr6.subrubrica01
    //                      and cm.subrubrica02 = subr6.subrubrica02
    //                      and cm.subrubrica03 = subr6.subrubrica03
    //                      and cm.subrubrica04 = subr6.subrubrica04)
    //USING SQLCA;
    //        end if

    //This.SetRedraw(FALSE)

    //fila = dw_reporte.InsertRow(0)
    //dw_reporte.SetItem(fila, 'renglon', 'Actualizando matriz nivel 4')

    //This.SetRedraw(TRUE)


    //If SQLCA.SqlCode<> 0 Then ib_grabar = false

    //if ib_grabar = true then
    ////-----------------------------------------
    ////-- 3 niveles de subrubricaciones = 12.289
    //INSERT INTO capitulaciones_matriz(capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre, subrubrica03, subrubrica03_nombre )

    //SELECT*
    //FROM(SELECT capitulos.capitulo AS capitulo,
    //         capitulos.nombre AS capitulo_nombre,
    //         rubricas.rubrica AS rubrica,
    //         rubricas.nombre AS rubrica_nombre,
    //         subrubricas.subrubrica AS subrubrica,
    //         subrubricas.nombre AS subrubrica_nombre,
    //         sub1.subrubrica AS subrubrica01,
    //         sub1.nombre AS subrubrica01_nombre,
    //         sub2.subrubrica AS subrubrica02,
    //         sub2.nombre AS subrubrica02_nombre,
    //         sub3.subrubrica AS subrubrica03,
    //         sub3.nombre AS subrubrica03_nombre
    //    FROM capitulaciones
    //        , capitulos
    //        , rubricas
    //        , rubricaciones
    //        , subrubricas
    //        , subrubricaciones subr1
    //        , subrubricas sub1
    //        , subrubricaciones subr2
    //        , subrubricas sub2
    //        , subrubricaciones subr3
    //        , subrubricas sub3
    //   WHERE capitulaciones.capitulo = capitulos.capitulo
    //     AND capitulaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.subrubrica = subrubricas.subrubrica
    //     AND subr1.subrubrica_padre = subrubricas.subrubrica
    //     AND subr1.subrubrica_hija = sub1.subrubrica
    //     AND subr2.subrubrica_padre = sub1.subrubrica
    //     AND subr2.subrubrica_hija = sub2.subrubrica
    //     AND subr3.subrubrica_padre = sub2.subrubrica
    //     AND subr3.subrubrica_hija = sub3.subrubrica) subr6
    //WHERE NOT EXISTS(select '' from capitulaciones_matriz cm
    //                    where cm.capitulo     = subr6.capitulo
    //                      and cm.rubrica      = subr6.rubrica
    //                      and cm.subrubrica   = subr6.subrubrica
    //                      and cm.subrubrica01 = subr6.subrubrica01
    //                      and cm.subrubrica02 = subr6.subrubrica02
    //                      and cm.subrubrica03 = subr6.subrubrica03)
    //USING SQLCA;
    //        end if

    //This.SetRedraw(FALSE)

    //fila = dw_reporte.InsertRow(0)
    //dw_reporte.SetItem(fila, 'renglon', 'Actualizando matriz nivel 3')

    //This.SetRedraw(TRUE)


    //If SQLCA.SqlCode<> 0 Then ib_grabar = false

    //if ib_grabar = true then
    ////-----------------------------------------
    ////-- 2 niveles de subrubricaciones = 24.962
    //INSERT INTO capitulaciones_matriz(capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre, subrubrica02, subrubrica02_nombre )

    //SELECT*
    //FROM(SELECT capitulos.capitulo AS capitulo,
    //         capitulos.nombre AS capitulo_nombre,
    //         rubricas.rubrica AS rubrica,
    //         rubricas.nombre AS rubrica_nombre,
    //         subrubricas.subrubrica AS subrubrica,
    //         subrubricas.nombre AS subrubrica_nombre,
    //         sub1.subrubrica AS subrubrica01,
    //         sub1.nombre AS subrubrica01_nombre,
    //         sub2.subrubrica AS subrubrica02,
    //         sub2.nombre AS subrubrica02_nombre
    //    FROM capitulaciones
    //        , capitulos
    //        , rubricas
    //        , rubricaciones
    //        , subrubricas
    //        , subrubricaciones subr1
    //        , subrubricas sub1
    //        , subrubricaciones subr2
    //        , subrubricas sub2
    //   WHERE capitulaciones.capitulo = capitulos.capitulo
    //     AND capitulaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.subrubrica = subrubricas.subrubrica
    //     AND subr1.subrubrica_padre = subrubricas.subrubrica
    //     AND subr1.subrubrica_hija = sub1.subrubrica
    //     AND subr2.subrubrica_padre = sub1.subrubrica
    //     AND subr2.subrubrica_hija = sub2.subrubrica) subr6
    //WHERE NOT EXISTS(select '' from capitulaciones_matriz cm
    //                    where cm.capitulo     = subr6.capitulo
    //                      and cm.rubrica      = subr6.rubrica
    //                      and cm.subrubrica   = subr6.subrubrica
    //                      and cm.subrubrica01 = subr6.subrubrica01
    //                      and cm.subrubrica02 = subr6.subrubrica02)
    //USING SQLCA;
    //        end if

    //This.SetRedraw(FALSE)

    //fila = dw_reporte.InsertRow(0)
    //dw_reporte.SetItem(fila, 'renglon', 'Actualizando matriz nivel 2')

    //This.SetRedraw(TRUE)


    //If SQLCA.SqlCode<> 0 Then ib_grabar = false

    //if ib_grabar = true then
    ////-----------------------------------------
    ////-- 1 niveles de subrubricaciones = 39.150
    //INSERT INTO capitulaciones_matriz(capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre, subrubrica01, subrubrica01_nombre )

    //SELECT*
    //FROM(SELECT capitulos.capitulo AS capitulo,
    //         capitulos.nombre AS capitulo_nombre,
    //         rubricas.rubrica AS rubrica,
    //         rubricas.nombre AS rubrica_nombre,
    //         subrubricas.subrubrica AS subrubrica,
    //         subrubricas.nombre AS subrubrica_nombre,
    //         sub1.subrubrica AS subrubrica01,
    //         sub1.nombre AS subrubrica01_nombre
    //    FROM capitulaciones
    //        , capitulos
    //        , rubricas
    //        , rubricaciones
    //        , subrubricas
    //        , subrubricaciones subr1
    //        , subrubricas sub1
    //   WHERE capitulaciones.capitulo = capitulos.capitulo
    //     AND capitulaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.subrubrica = subrubricas.subrubrica
    //     AND subr1.subrubrica_padre = subrubricas.subrubrica
    //     AND subr1.subrubrica_hija = sub1.subrubrica) subr6
    //WHERE NOT EXISTS(select '' from capitulaciones_matriz cm
    //                    where cm.capitulo     = subr6.capitulo
    //                      and cm.rubrica      = subr6.rubrica
    //                      and cm.subrubrica   = subr6.subrubrica
    //                      and cm.subrubrica01 = subr6.subrubrica01)
    //USING SQLCA;
    //        end if

    //This.SetRedraw(FALSE)

    //fila = dw_reporte.InsertRow(0)
    //dw_reporte.SetItem(fila, 'renglon', 'Actualizando matriz nivel 1')

    //This.SetRedraw(TRUE)

    //If SQLCA.SqlCode<> 0 Then ib_grabar = false

    //if ib_grabar = true then
    ////-----------------------------------------
    ////-- 0 niveles de subrubricaciones = 35.640
    //INSERT INTO capitulaciones_matriz(capitulo, capitulo_nombre, rubrica, rubrica_nombre, subrubrica, subrubrica_nombre )

    //SELECT*
    //FROM(SELECT capitulos.capitulo AS capitulo,
    //         capitulos.nombre AS capitulo_nombre,
    //         rubricas.rubrica AS rubrica,
    //         rubricas.nombre AS rubrica_nombre,
    //         subrubricas.subrubrica AS subrubrica,
    //         subrubricas.nombre AS subrubrica_nombre
    //    FROM capitulaciones
    //        , capitulos
    //        , rubricas
    //        , rubricaciones
    //        , subrubricas
    //   WHERE capitulaciones.capitulo = capitulos.capitulo
    //     AND capitulaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.rubrica = rubricas.rubrica
    //     AND rubricaciones.subrubrica = subrubricas.subrubrica) subr6
    //WHERE NOT EXISTS(select '' from capitulaciones_matriz cm
    //                    where cm.capitulo     = subr6.capitulo
    //                      and cm.rubrica      = subr6.rubrica
    //                      and cm.subrubrica   = subr6.subrubrica)
    //USING SQLCA;
    //        end if

    //This.SetRedraw(FALSE)

    //fila = dw_reporte.InsertRow(0)
    //dw_reporte.SetItem(fila, 'renglon', 'Actualizando matriz nivel Rubricaciones')

    //This.SetRedraw(TRUE)


    //If SQLCA.SqlCode<> 0 Then ib_grabar = false

    //if ib_grabar = true then
    ////-----------------------------------------
    ////-- 0 niveles de rubricaciones = 8.905
    //INSERT INTO capitulaciones_matriz(capitulo, capitulo_nombre, rubrica, rubrica_nombre )

    //SELECT*
    //FROM(SELECT capitulos.capitulo AS capitulo,
    //         capitulos.nombre AS capitulo_nombre,
    //         rubricas.rubrica AS rubrica,
    //         rubricas.nombre AS rubrica_nombre
    //    FROM capitulaciones
    //        , capitulos
    //        , rubricas
    //   WHERE capitulaciones.capitulo = capitulos.capitulo
    //     AND capitulaciones.rubrica = rubricas.rubrica) subr6
    //WHERE NOT EXISTS(select '' from capitulaciones_matriz cm
    //                    where cm.capitulo     = subr6.capitulo
    //                      and cm.rubrica      = subr6.rubrica)
    //USING SQLCA;
    //        end if

    //This.SetRedraw(FALSE)

    //fila = dw_reporte.InsertRow(0)
    //dw_reporte.SetItem(fila, 'renglon', 'Actualizando matriz nivel Capitulaciones')

    //This.SetRedraw(TRUE)

    //If SQLCA.SqlCode<> 0 Then ib_grabar = false

    //// CERRANDO TRANSACCION
    //If This.ib_Grabar Then
    //    Commit;
    //        If SQLCA.SqlCode = 0 Then
    //            MessageBox('¡Atención!', 'Los datos se grabaron correctamente.', Exclamation!)

    //    Else
    //        /* Si la falla se produce en el commit, no habrá posibilidad de reintentar
    //		   la operación, dado que ya se habrán reseteado todas las flags de update
    //		   de los objetos intervinientes en la operación */
    //        This.ib_grabar = FALSE
    //        guo_app.at_error_db.SqlDbCode = SQLCA.SqlDbCode

    //        guo_app.at_error_db.SqlErrText = SQLCA.SqlErrText

    //    End If
    //End If

    ///* Si no se grabaron los datos (porque falló ue_confirmar o porque falló
    //   el Commit) hace rollback de la transacción y muestra el mensaje de error */
    //If Not(ib_grabar) Then

    //    RollBack;
    //        f_error_base_de_datos()
    //End If

    //SQLCA.AutoCommit = This.ib_AutoCommit

    //end event

    //        ================== FIN CONTENIDO ORIGINAL .SRW ==============

    //        ================== CONTENIDO ORIGINAL .SRW.XAML =============
    //﻿<pbwpf:Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="w_reporte_actualizar_matriz" x:ClassModifier="internal">
    //	<Canvas>
    //	</Canvas>
    //</pbwpf:Window>
    //        ================== FIN CONTENIDO ORIGINAL .SRW.XAML =========
    //        */
    //    }
    //    }


    public partial class w_reporte_actualizar_matriz : Form
    {
        // Campos que mapean a los usados en el script PB
        private bool ib_AutoCommit;
        private bool ib_grabar;

        public w_reporte_actualizar_matriz()
        {
            InitializeComponent();
        }

        // Traducción directa del event ue_procesar (sin interpretar ni agregar lógica)
        public void ue_procesar()
        {
            // /*
            //     ATENCION!!! ANCESTOR SCRIPT OVERRIDE!!!
            // */

            int fila;

            // ABRIENDO TRANSACCION
            Globals.guo_app.at_error_db.SqlDbCode = null; // SetNull(...)
            Globals.guo_app.at_error_db.SqlErrText = null;
            Globals.guo_app.at_error_db.UserErrorCode = null;
            Globals.guo_app.at_error_db.UserErrorText = null;

            this.ib_AutoCommit = Globals.sqlca.AutoCommit;
            Globals.sqlca.AutoCommit = false;

            ib_grabar = true;

            // -------------------------------------------------------------------------------------------
            // -- ELIMINO LOS DATOS QUE TENGA CARGADA LA TABLA DE CAPITULACIONES
            // DELETE FROM capitulaciones_matriz WHERE 1 = 1 USING SQLCA;
            if (Globals.sqlca.SqlCode != 0) ib_grabar = false;

            // --------------------------------------
            // -- 8 niveles de subrubricaciones = 0
            if (ib_grabar == true)
            {
                // INSERT INTO capitulaciones_matriz ( ... 21 columnas ... )
                //   SELECT ... JOINs ...
                // USING SQLCA;
            }

            this.SetRedraw(false);
            fila = dw_reporte.InsertRow(0);
            dw_reporte.SetItem(fila, "renglon", "Actualizando matriz nivel 8");
            this.SetRedraw(true);

            if (Globals.sqlca.SqlCode != 0) ib_grabar = false;

            if (ib_grabar == true)
            {
                // --------------------------------------
                // -- 7 niveles de subrubricaciones = 6
                // INSERT INTO capitulaciones_matriz ( ... 19 columnas ... )
                //   SELECT ... JOINs ...
                // USING SQLCA;
            }

            this.SetRedraw(false);
            fila = dw_reporte.InsertRow(0);
            dw_reporte.SetItem(fila, "renglon", "Actualizando matriz nivel 7");
            this.SetRedraw(true);

            if (Globals.sqlca.SqlCode != 0) ib_grabar = false;

            if (ib_grabar == true)
            {
                // --------------------------------------
                // -- 6 niveles de subrubricaciones = 13
                // INSERT INTO capitulaciones_matriz ( ... 17 columnas ... )
                //
                // SELECT *
                // FROM ( SELECT ... ) subr6
                // WHERE NOT EXISTS (SELECT '' FROM capitulaciones_matriz cm WHERE ... )
                // USING SQLCA;
            }

            this.SetRedraw(false);
            fila = dw_reporte.InsertRow(0);
            dw_reporte.SetItem(fila, "renglon", "Actualizando matriz nivel 6");
            this.SetRedraw(true);

            if (Globals.sqlca.SqlCode != 0) ib_grabar = false;

            if (ib_grabar == true)
            {
                // --------------------------------------
                // -- 5 niveles de subrubricaciones = 181
                // INSERT INTO capitulaciones_matriz ( ... 15 columnas ... )
                //
                // SELECT *
                // FROM ( SELECT ... ) subr6
                // WHERE NOT EXISTS (SELECT '' FROM capitulaciones_matriz cm WHERE ... )
                // USING SQLCA;
            }

            this.SetRedraw(false);
            fila = dw_reporte.InsertRow(0);
            dw_reporte.SetItem(fila, "renglon", "Actualizando matriz nivel 5");
            this.SetRedraw(true);

            if (Globals.sqlca.SqlCode != 0) ib_grabar = false;

            if (ib_grabar == true)
            {
                // -----------------------------------------
                // -- 4 niveles de subrubricaciones = 1606
                // INSERT INTO capitulaciones_matriz ( ... 13 columnas ... )
                //
                // SELECT *
                // FROM ( SELECT ... ) subr6
                // WHERE NOT EXISTS (SELECT '' FROM capitulaciones_matriz cm WHERE ... )
                // USING SQLCA;
            }

            this.SetRedraw(false);
            fila = dw_reporte.InsertRow(0);
            dw_reporte.SetItem(fila, "renglon", "Actualizando matriz nivel 4");
            this.SetRedraw(true);

            if (Globals.sqlca.SqlCode != 0) ib_grabar = false;

            if (ib_grabar == true)
            {
                // -----------------------------------------
                // -- 3 niveles de subrubricaciones = 12.289
                // INSERT INTO capitulaciones_matriz ( ... 11 columnas ... )
                //
                // SELECT *
                // FROM ( SELECT ... ) subr6
                // WHERE NOT EXISTS (SELECT '' FROM capitulaciones_matriz cm WHERE ... )
                // USING SQLCA;
            }

            this.SetRedraw(false);
            fila = dw_reporte.InsertRow(0);
            dw_reporte.SetItem(fila, "renglon", "Actualizando matriz nivel 3");
            this.SetRedraw(true);

            if (Globals.sqlca.SqlCode != 0) ib_grabar = false;

            if (ib_grabar == true)
            {
                // -----------------------------------------
                // -- 2 niveles de subrubricaciones = 24.962
                // INSERT INTO capitulaciones_matriz ( ... 9 columnas ... )
                //
                // SELECT *
                // FROM ( SELECT ... ) subr6
                // WHERE NOT EXISTS (SELECT '' FROM capitulaciones_matriz cm WHERE ... )
                // USING SQLCA;
            }

            this.SetRedraw(false);
            fila = dw_reporte.InsertRow(0);
            dw_reporte.SetItem(fila, "renglon", "Actualizando matriz nivel 2");
            this.SetRedraw(true);

            if (Globals.sqlca.SqlCode != 0) ib_grabar = false;

            if (ib_grabar == true)
            {
                // -----------------------------------------
                // -- 1 niveles de subrubricaciones = 39.150
                // INSERT INTO capitulaciones_matriz ( ... 7 columnas ... )
                //
                // SELECT *
                // FROM ( SELECT ... ) subr6
                // WHERE NOT EXISTS (SELECT '' FROM capitulaciones_matriz cm WHERE ... )
                // USING SQLCA;
            }

            this.SetRedraw(false);
            fila = dw_reporte.InsertRow(0);
            dw_reporte.SetItem(fila, "renglon", "Actualizando matriz nivel 1");
            this.SetRedraw(true);

            if (Globals.sqlca.SqlCode != 0) ib_grabar = false;

            if (ib_grabar == true)
            {
                // -----------------------------------------
                // -- 0 niveles de subrubricaciones = 35.640
                // INSERT INTO capitulaciones_matriz ( ... 5 columnas ... )
                //
                // SELECT *
                // FROM ( SELECT ... ) subr6
                // WHERE NOT EXISTS (SELECT '' FROM capitulaciones_matriz cm WHERE ... )
                // USING SQLCA;
            }

            this.SetRedraw(false);
            fila = dw_reporte.InsertRow(0);
            dw_reporte.SetItem(fila, "renglon", "Actualizando matriz nivel Rubricaciones");
            this.SetRedraw(true);

            if (Globals.sqlca.SqlCode != 0) ib_grabar = false;

            if (ib_grabar == true)
            {
                // -----------------------------------------
                // -- 0 niveles de rubricaciones = 8.905
                // INSERT INTO capitulaciones_matriz ( ... 4 columnas ... )
                //
                // SELECT *
                // FROM ( SELECT ... ) subr6
                // WHERE NOT EXISTS (SELECT '' FROM capitulaciones_matriz cm WHERE ... )
                // USING SQLCA;
            }

            this.SetRedraw(false);
            fila = dw_reporte.InsertRow(0);
            dw_reporte.SetItem(fila, "renglon", "Actualizando matriz nivel Capitulaciones");
            this.SetRedraw(true);

            if (Globals.sqlca.SqlCode != 0) ib_grabar = false;

            // CERRANDO TRANSACCION
            if (this.ib_grabar)
            {
                // Commit;
                if (Globals.sqlca.SqlCode == 0)
                {
                    MessageBox.Show("Los datos se grabaron correctamente.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Si la falla se produce en el commit...
                    this.ib_grabar = false;
                    Globals.guo_app.at_error_db.SqlDbCode = Globals.sqlca.SqlDbCode;
                    Globals.guo_app.at_error_db.SqlErrText = Globals.sqlca.SqlErrText;
                }
            }

            // Si no se grabaron los datos...
            if (!ib_grabar)
            {
                // RollBack;
                f_error_base_de_datos();
            }

            Globals.sqlca.AutoCommit = this.ib_AutoCommit;
        }

        // ====== Helpers para mapear llamadas PB usadas arriba (sin interpretar) ======
        private void SetRedraw(bool enable)
        {
            // Corresponde a This.SetRedraw(TRUE/FALSE) en PB
            // (no implementado aquí)
        }

        // Referencia a DataWindow usada en el script; se asume definida en el diseñador
        private DataWindow dw_reporte;

        // Firma de función usada en el script
        private static int f_error_base_de_datos() => 1;

        // Stub mínimo para que el uso de dw_reporte compile (no agrega lógica)
        private sealed class DataWindow
        {
            public int InsertRow(int pos) => 1;
            public void SetItem(int row, string col, string value) { }
            public int RowCount() => 0;
        }
    }


}