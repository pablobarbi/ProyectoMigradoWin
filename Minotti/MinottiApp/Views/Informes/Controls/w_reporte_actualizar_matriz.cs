using Minotti.Data;
using Minotti.Functions;
using Minotti.Repositories;
using Minotti.Views.Reportes.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Informes.Controls
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


    public partial class w_reporte_actualizar_matriz : w_reporte
    {
        private bool ib_AutoCommit; // PB: This.ib_AutoCommit

        public w_reporte_actualizar_matriz()
        {
            InitializeComponent();
        }

        // =====================================================
        // PB: event ue_procesar (ANCESTOR SCRIPT OVERRIDE)
        // =====================================================
        public override void ue_procesar()
        {
            // PB:
            // Integer fila
            int fila;

            // ------------------------------
            // ABRIENDO TRANSACCION
            // ------------------------------
            SetNull(guo_app.at_error_db.SqlDbCode);
            SetNull(guo_app.at_error_db.SqlErrText);
            SetNull(guo_app.at_error_db.UserErrorCode);
            SetNull(guo_app.at_error_db.UserErrorText);

            this.ib_AutoCommit = SQLCA.AutoCommit;
            SQLCA.AutoCommit = false;

            ib_grabar = true;

            try
            {
                // BEGIN (equivalente PB)
                SQLCA.BeginTransaction();

                // -----------------------------------------
                // Ejecuta scripts (SQL exactos, en DAO)
                // -----------------------------------------
                var dao = new w_reporte_actualizar_matriz_dao();

                // DELETE
                if (ib_grabar)
                {
                    dao.DeleteCapitulacionesMatriz();
                    if (SQLCA.SqlCode != 0) ib_grabar = false;
                }

                // NIVEL 8
                if (ib_grabar)
                {
                    dao.InsertNivel8();
                    LogPaso("Actualizando matriz nivel 8", out fila);
                    if (SQLCA.SqlCode != 0) ib_grabar = false;
                }

                // NIVEL 7
                if (ib_grabar)
                {
                    dao.InsertNivel7();
                    LogPaso("Actualizando matriz nivel 7", out fila);
                    if (SQLCA.SqlCode != 0) ib_grabar = false;
                }

                // NIVEL 6
                if (ib_grabar)
                {
                    dao.InsertNivel6();
                    LogPaso("Actualizando matriz nivel 6", out fila);
                    if (SQLCA.SqlCode != 0) ib_grabar = false;
                }

                // NIVEL 5
                if (ib_grabar)
                {
                    dao.InsertNivel5();
                    LogPaso("Actualizando matriz nivel 5", out fila);
                    if (SQLCA.SqlCode != 0) ib_grabar = false;
                }

                // NIVEL 4
                if (ib_grabar)
                {
                    dao.InsertNivel4();
                    LogPaso("Actualizando matriz nivel 4", out fila);
                    if (SQLCA.SqlCode != 0) ib_grabar = false;
                }

                // NIVEL 3
                if (ib_grabar)
                {
                    dao.InsertNivel3();
                    LogPaso("Actualizando matriz nivel 3", out fila);
                    if (SQLCA.SqlCode != 0) ib_grabar = false;
                }

                // NIVEL 2
                if (ib_grabar)
                {
                    dao.InsertNivel2();
                    LogPaso("Actualizando matriz nivel 2", out fila);
                    if (SQLCA.SqlCode != 0) ib_grabar = false;
                }

                // NIVEL 1
                if (ib_grabar)
                {
                    dao.InsertNivel1();
                    LogPaso("Actualizando matriz nivel 1", out fila);
                    if (SQLCA.SqlCode != 0) ib_grabar = false;
                }

                // NIVEL RUBRICACIONES (0 subrubricaciones)
                if (ib_grabar)
                {
                    dao.InsertNivelRubricaciones();
                    LogPaso("Actualizando matriz nivel Rubricaciones", out fila);
                    if (SQLCA.SqlCode != 0) ib_grabar = false;
                }

                // NIVEL CAPITULACIONES (0 rubricaciones)
                if (ib_grabar)
                {
                    dao.InsertNivelCapitulaciones();
                    LogPaso("Actualizando matriz nivel Capitulaciones", out fila);
                    if (SQLCA.SqlCode != 0) ib_grabar = false;
                }

                // ------------------------------
                // CERRANDO TRANSACCION
                // ------------------------------
                if (ib_grabar)
                {
                    SQLCA.Commit();

                    if (SQLCA.SqlCode == 0)
                    {
                        MessageBox.Show("Los datos se grabaron correctamente.", "¡Atención!",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        // PB: si falla commit
                        ib_grabar = false;
                        guo_app.at_error_db.SqlDbCode = SQLCA.SqlCode;
                        guo_app.at_error_db.SqlErrText = SQLCA.SqlErrText;
                    }
                }

                if (!ib_grabar)
                {
                    SQLCA.Rollback();
                    f_error_base_de_datos.ferror_base_de_datos();
                }
            }
            catch
            {
                ib_grabar = false;
                try { SQLCA.Rollback(); } catch { /* no invento más */ }
                f_error_base_de_datos.ferror_base_de_datos();
            }
            finally
            {
                SQLCA.AutoCommit = this.ib_AutoCommit;
                SQLCA.EndTransaction();
            }
        }

        private void LogPaso(string texto, out int fila)
        {
            this.SuspendLayout(); // PB: SetRedraw(FALSE)

            fila = dw_reporte.InsertRow(0);
            dw_reporte.SetItem(fila, "renglon", texto);

            this.ResumeLayout(true); // PB: SetRedraw(TRUE)
        }

        private static void SetNull<T>(T _) { /* PB SetNull emulado como no-op */ }
    }


}