using Minotti.Models;
using System;
using System.Globalization;

namespace Minotti
{
    /// <summary>
    /// Migración de PB: uo_capitulos.sru (non visual object)
    /// Mantiene nombres de variables y métodos.
    /// </summary>
    public class uo_capitulos
    {
        // === VARIABLES (type variables) ===
        public uo_ds ds_capitulo;
        public uo_ds ds_rubricas;
        public uo_ds ds_subrubricas;
        public uo_ds ds_capitulo_med;
        public uo_ds ds_rubricas_med;
        public uo_ds ds_subrubricas_med;
        public uo_ds ds_capitulo_todo;
         

        // ==== CONSTRUCTOR (event constructor) ====
        public uo_capitulos()
        {
            // INICIALIZO LOS DATASTORES
            ds_capitulo = new uo_ds();
            ds_capitulo.uof_SetDataObject("duo_capitulaciones");
            ds_capitulo.SetTransObject(null);

            ds_rubricas = new uo_ds();
            ds_rubricas.uof_SetDataObject("duo_rubricaciones");
            ds_rubricas.SetTransObject(null);

            ds_subrubricas = new uo_ds();
            ds_subrubricas.uof_SetDataObject("duo_subrubricaciones");
            ds_subrubricas.SetTransObject(null);

            ds_capitulo_med = new uo_ds();
            ds_capitulo_med.uof_SetDataObject("duo_capitulaciones_med");
            ds_capitulo_med.SetTransObject(null);

            ds_rubricas_med = new uo_ds();
            ds_rubricas_med.uof_SetDataObject("duo_rubricaciones_med");
            ds_rubricas_med.SetTransObject(null);

            ds_subrubricas_med = new uo_ds();
            ds_subrubricas_med.uof_SetDataObject("duo_subrubricaciones_med");
            ds_subrubricas_med.SetTransObject(null);

            ds_capitulo_todo = new uo_ds();
            ds_capitulo_todo.uof_SetDataObject("duo_capitulo_completo");
            ds_capitulo_todo.SetTransObject(null);
        }

        // ==== DESTRUCTOR PB (event destructor) ====
        // Si querés, podés llamar a esto explícitamente desde donde lo uses.
        public void destructor()
        {
            TryDestroy(ds_capitulo);
            TryDestroy(ds_rubricas);
            TryDestroy(ds_subrubricas);
            TryDestroy(ds_capitulo_med);
            TryDestroy(ds_rubricas_med);
            TryDestroy(ds_subrubricas_med);
            TryDestroy(ds_capitulo_todo);
        }

        private static void TryDestroy(uo_ds ds)
        {
            if (ds != null)
            {
                try
                {
                    ds.Dispose();
                }
                catch
                {
                    // igual que IsValid/DESTROY: ignoramos errores
                }
            }
        }

        // ==== PUBLIC SUBROUTINES (mantengo nombres PB) ====

        /// <summary>
        /// PB: public subroutine uo_cargar_info ()
        /// En PB: this.TriggerEvent('cargar_info')
        /// </summary>
        public void uo_cargar_info()
        {
            cargar_info();
        }

        /// <summary>
        /// PB: public subroutine uo_devolver_capitulo (ref uo_ds ds_retorno)
        /// Copia todas las filas de ds_capitulo_todo a ds_retorno.
        /// </summary>
        public void uo_devolver_capitulo(ref uo_ds ds_retorno)
        {
            if (ds_retorno == null) ds_retorno = new uo_ds();

            // PB:
            // ds_capitulo_todo.RowsCopy( 1, ds_capitulo_todo.RowCount(), Primary!, ds_retorno, 1, Primary!)
            int total = ds_capitulo_todo.RowCount();
            if (total > 0)
            {
                ds_capitulo_todo.RowsCopy(1, total, "Primary", ds_retorno, 1, "Primary");
            }
        }

        /// <summary>
        /// PB: public subroutine uo_devolver_un_med (ref uo_ds ds_retorno, string as_medicamento)
        /// </summary>
        public void uo_devolver_un_med(ref uo_ds ds_retorno, string as_medicamento)
        {
            if (ds_retorno == null) ds_retorno = new uo_ds();

            string ls_Filtro = $"medicamento = '{as_medicamento}'";

            ds_capitulo_todo.SetFilter(ls_Filtro);
            ds_capitulo_todo.Filter();

            int total = ds_capitulo_todo.RowCount();
            if (total > 0)
            {
                ds_capitulo_todo.RowsCopy(1, total, "Primary", ds_retorno, ds_retorno.RowCount() + 1, "Primary");
            }

            ds_capitulo_todo.SetFilter(string.Empty);
            ds_capitulo_todo.Filter();
        }

        /// <summary>
        /// PB: public subroutine uo_devolver_un_med_valor (ref uo_ds ds_retorno, string as_medicamento, integer al_valor)
        /// </summary>
        public void uo_devolver_un_med_valor(ref uo_ds ds_retorno, string as_medicamento, int al_valor)
        {
            if (ds_retorno == null) ds_retorno = new uo_ds();

            string ls_Filtro = $"medicamento = '{as_medicamento}' AND valor = {al_valor.ToString(CultureInfo.InvariantCulture)}";

            ds_capitulo_todo.SetFilter(ls_Filtro);
            ds_capitulo_todo.Filter();

            int total = ds_capitulo_todo.RowCount();
            if (total > 0)
            {
                ds_capitulo_todo.RowsCopy(1, total, "Primary", ds_retorno, ds_retorno.RowCount() + 1, "Primary");
            }

            ds_capitulo_todo.SetFilter(string.Empty);
            ds_capitulo_todo.Filter();
        }

        // ==== EVENT cargar_info (traducido a método privado) ====

        /// <summary>
        /// Traducción del event cargar_info() de PB.
        /// Llena ds_capitulo_todo con capitulaciones, rubricas, subrubricas y medicamentos.
        /// </summary>
        private void cargar_info()
        {
            string ls_CapituloNombre = string.Empty;
            string ls_RubricaNombre = string.Empty;
            string ls_SubRubricaNombre = string.Empty;
            string ls_SubRubricaNombreH = string.Empty;
            string ls_Medicamento = string.Empty;

            // En PB: String ls_Param[], ls_Vacio[]
            // Usamos tamaño 3 y empezamos en índice 1 para asemejar PB.
            string[] ls_Param = new string[3];
            string[] ls_Vacio = Array.Empty<string>();

            int ll_Fila, ll_Fila2, ll_Fila3, ll_FilaTodo, ll_Total;
            long ll_Capitulo, ll_Rubrica, ll_SubRubrica, ll_SubRubricaH, ll_Valor;

            long ll_SubRub01, ll_SubRub02, ll_SubRub03, ll_SubRub04, ll_SubRub05,
                 ll_SubRub06, ll_SubRub07, ll_SubRub08, ll_SubRub09, ll_SubRub10;

            string ls_SubRub01, ls_SubRub02, ls_SubRub03, ls_SubRub04, ls_SubRub05,
                   ls_SubRub06, ls_SubRub07, ls_SubRub08, ls_SubRub09, ls_SubRub10;

            // Limpio el DS destino
            ds_capitulo_todo.Reset();

            // Recupero capitulaciones por capitulo_id
            ls_Param[1] = capitulo_id.ToString(CultureInfo.InvariantCulture);
            ds_capitulo.uof_Retrieve(ls_Param);

            //------------------------------------------------------------------------------------
            // BUSCO CAPITULACIONES
            for (ll_Fila = 1; ll_Fila <= ds_capitulo.RowCount(); ll_Fila++)
            {
                ll_Capitulo = (long)ds_capitulo.GetItemNumber(ll_Fila, "capitulo");
                ls_CapituloNombre = ds_capitulo.GetItemString(ll_Fila, "capitulo_nombre");
                ll_Rubrica = (long)ds_capitulo.GetItemNumber(ll_Fila, "rubrica");
                ls_RubricaNombre = ds_capitulo.GetItemString(ll_Fila, "rubrica_nombre");

                // CAPITULACIONES - MEDICAMENTOS.
                ls_Param[1] = ll_Capitulo.ToString(CultureInfo.InvariantCulture);
                ls_Param[2] = ll_Rubrica.ToString(CultureInfo.InvariantCulture);
                ds_capitulo_med.uof_Retrieve(ls_Param);

                // SIN MEDICAMENTOS
                if (ds_capitulo_med.RowCount() == 0)
                {
                    ll_FilaTodo = ds_capitulo_todo.InsertRow(0);
                    ds_capitulo_todo.SetItem(ll_FilaTodo, "capitulo", ll_Capitulo);
                    ds_capitulo_todo.SetItem(ll_FilaTodo, "capitulo_nombre", ls_CapituloNombre);
                    ds_capitulo_todo.SetItem(ll_FilaTodo, "rubrica", ll_Rubrica);
                    ds_capitulo_todo.SetItem(ll_FilaTodo, "rubrica_nombre", ls_RubricaNombre);
                }

                // CON MEDICAMENTOS
                for (ll_Fila2 = 1; ll_Fila2 <= ds_capitulo_med.RowCount(); ll_Fila2++)
                {
                    ls_Medicamento = ds_capitulo_med.GetItemString(ll_Fila2, "medicamento");
                    ll_Valor = (long)ds_capitulo_med.GetItemNumber(ll_Fila2, "valor");

                    ll_FilaTodo = ds_capitulo_todo.InsertRow(0);
                    ds_capitulo_todo.SetItem(ll_FilaTodo, "capitulo", ll_Capitulo);
                    ds_capitulo_todo.SetItem(ll_FilaTodo, "capitulo_nombre", ls_CapituloNombre);
                    ds_capitulo_todo.SetItem(ll_FilaTodo, "rubrica", ll_Rubrica);
                    ds_capitulo_todo.SetItem(ll_FilaTodo, "rubrica_nombre", ls_RubricaNombre);
                    ds_capitulo_todo.SetItem(ll_FilaTodo, "medicamento", ls_Medicamento);
                    ds_capitulo_todo.SetItem(ll_FilaTodo, "valor", ll_Valor);
                }
            }

            //------------------------------------------------------------------------------------
            // BUSCO RUBRICACIONES.
            ls_Param = ls_Vacio.Length == 0 ? new string[3] : ls_Param; // reset
            for (ll_Fila = 1; ll_Fila <= ds_capitulo.RowCount(); ll_Fila++)
            {
                ll_Capitulo = (long)ds_capitulo.GetItemNumber(ll_Fila, "capitulo");
                ls_CapituloNombre = ds_capitulo.GetItemString(ll_Fila, "capitulo_nombre");
                ll_Rubrica = (long)ds_capitulo.GetItemNumber(ll_Fila, "rubrica");
                ls_RubricaNombre = ds_capitulo.GetItemString(ll_Fila, "rubrica_nombre");

                // busco las rubricaciones.
                ls_Param[1] = ll_Rubrica.ToString(CultureInfo.InvariantCulture);
                ds_rubricas.uof_Retrieve(ls_Param);

                for (ll_Fila2 = 1; ll_Fila2 <= ds_rubricas.RowCount(); ll_Fila2++)
                {
                    ll_SubRubrica = (long)ds_rubricas.GetItemNumber(ll_Fila2, "subrubrica");
                    ls_SubRubricaNombre = ds_rubricas.GetItemString(ll_Fila2, "subrubrica_nombre");

                    // RUBRICACIONES - MEDICAMENTOS
                    ls_Param[1] = ll_Rubrica.ToString(CultureInfo.InvariantCulture);
                    ls_Param[2] = ll_SubRubrica.ToString(CultureInfo.InvariantCulture);
                    ds_rubricas_med.uof_Retrieve(ls_Param);

                    // SIN MEDICAMENTOS
                    if (ds_rubricas_med.RowCount() == 0)
                    {
                        ll_FilaTodo = ds_capitulo_todo.InsertRow(0);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "capitulo", ll_Capitulo);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "capitulo_nombre", ls_CapituloNombre);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "rubrica", ll_Rubrica);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "rubrica_nombre", ls_RubricaNombre);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "subrubrica01", ll_SubRubrica);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "subrubrica01_nombre", ls_SubRubricaNombre);
                    }

                    // CON MEDICAMENTOS
                    for (ll_Fila3 = 1; ll_Fila3 <= ds_rubricas_med.RowCount(); ll_Fila3++)
                    {
                        ls_Medicamento = ds_rubricas_med.GetItemString(ll_Fila3, "medicamento");
                        ll_Valor = (long)ds_rubricas_med.GetItemNumber(ll_Fila3, "valor");

                        ll_FilaTodo = ds_capitulo_todo.InsertRow(0);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "capitulo", ll_Capitulo);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "capitulo_nombre", ls_CapituloNombre);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "rubrica", ll_Rubrica);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "rubrica_nombre", ls_RubricaNombre);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "subrubrica01", ll_SubRubrica);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "subrubrica01_nombre", ls_SubRubricaNombre);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "medicamento", ls_Medicamento);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "valor", ll_Valor);
                    }
                }
            }

            // A partir de aquí en PB hay bloques repetidos "BUSCO SUBRUBRICA02 ... SUBRUBRICA10".
            // Para no copiar 9 bloques largos, lo implemento de forma genérica respetando los
            // nombres de columnas (subrubrica01..10 y *_nombre).

            // Niveles 2 a 10
            for (int nivel = 2; nivel <= 10; nivel++)
            {
                ProcesarSubrubricaNivel(nivel - 1, nivel);
            }

            // FINAL: saco los filtros
            ds_capitulo_todo.SetFilter(string.Empty);
            ds_capitulo_todo.Filter();
        }

        /// <summary>
        /// Implementa genéricamente los bloques "BUSCO SUBRUBRICA0X" de PB.
        /// nivelAnterior: 1..9, nivelActual: 2..10
        /// </summary>
        private void ProcesarSubrubricaNivel(int nivelAnterior, int nivelActual)
        {
            // Nombre de columna para nombre del nivel anterior
            string colPrevNombre = nivelAnterior < 10
                ? $"subrubrica0{nivelAnterior}_nombre"
                : "subrubrica10_nombre";

            string colPrevCodigo = nivelAnterior < 10
                ? $"subrubrica0{nivelAnterior}"
                : "subrubrica10";

            string colActualCodigo = nivelActual < 10
                ? $"subrubrica0{nivelActual}"
                : "subrubrica10";

            string colActualNombre = colActualCodigo + "_nombre";

            // Filtro: len(subrubricaX_nombre) > 0
            ds_capitulo_todo.SetFilter($"len({colPrevNombre}) > 0");
            ds_capitulo_todo.Filter();
            int ll_Total = ds_capitulo_todo.RowCount();

            // CONTROL DE QUE EXISTA ESTE NIVEL EN EL CAPITULO!!
            if (ll_Total == 0)
            {
                // En PB: GOTO FINAL; aquí simplemente salimos de este nivel.
                ds_capitulo_todo.SetFilter(string.Empty);
                ds_capitulo_todo.Filter();
                return;
            }

            // Arrays para copiar todos los niveles previos
            long[] subCod = new long[11];     // 1..10
            string[] subNom = new string[11]; // 1..10

            for (int ll_Fila = ll_Total; ll_Fila >= 1; ll_Fila--)
            {
                long ll_Capitulo = (long)ds_capitulo_todo.GetItemNumber(ll_Fila, "capitulo");
                string ls_CapituloNombre = ds_capitulo_todo.GetItemString(ll_Fila, "capitulo_nombre");
                long ll_Rubrica = (long)ds_capitulo_todo.GetItemNumber(ll_Fila, "rubrica");
                string ls_RubricaNombre = ds_capitulo_todo.GetItemString(ll_Fila, "rubrica_nombre");

                // Cargo todos los niveles previos (subrubrica01..nivelAnterior)
                for (int n = 1; n <= nivelAnterior; n++)
                {
                    string codeCol = n < 10 ? $"subrubrica0{n}" : "subrubrica10";
                    string nameCol = codeCol + "_nombre";

                    subCod[n] = (long)ds_capitulo_todo.GetItemNumber(ll_Fila, codeCol);
                    subNom[n] = ds_capitulo_todo.GetItemString(ll_Fila, nameCol);
                }

                long codigoPadre = subCod[nivelAnterior];

                // SUBRUBRICACIONES
                string[] ls_Param = new string[3];
                ls_Param[1] = codigoPadre.ToString(CultureInfo.InvariantCulture);
                ds_subrubricas.uof_Retrieve(ls_Param);

                for (int ll_Fila2 = 1; ll_Fila2 <= ds_subrubricas.RowCount(); ll_Fila2++)
                {
                    long ll_SubRubricaH = (long)ds_subrubricas.GetItemNumber(ll_Fila2, "subrubrica_hija");
                    string ls_SubRubricaNombreH = ds_subrubricas.GetItemString(ll_Fila2, "subrubrica_nombre");

                    // SUBRUBRICACIONES - MEDICAMENTOS
                    ls_Param[1] = codigoPadre.ToString(CultureInfo.InvariantCulture);
                    ls_Param[2] = ll_SubRubricaH.ToString(CultureInfo.InvariantCulture);
                    ds_subrubricas_med.uof_Retrieve(ls_Param);

                    // SIN MEDICAMENTOS
                    if (ds_subrubricas_med.RowCount() == 0)
                    {
                        int ll_FilaTodo = ds_capitulo_todo.InsertRow(0);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "capitulo", ll_Capitulo);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "capitulo_nombre", ls_CapituloNombre);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "rubrica", ll_Rubrica);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "rubrica_nombre", ls_RubricaNombre);

                        // Copio niveles previos
                        for (int n = 1; n <= nivelAnterior; n++)
                        {
                            string codeCol = n < 10 ? $"subrubrica0{n}" : "subrubrica10";
                            string nameCol = codeCol + "_nombre";
                            ds_capitulo_todo.SetItem(ll_FilaTodo, codeCol, subCod[n]);
                            ds_capitulo_todo.SetItem(ll_FilaTodo, nameCol, subNom[n]);
                        }

                        // Seteo nivel actual
                        ds_capitulo_todo.SetItem(ll_FilaTodo, colActualCodigo, ll_SubRubricaH);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, colActualNombre, ls_SubRubricaNombreH);
                    }

                    // CON MEDICAMENTOS
                    for (int ll_Fila3 = 1; ll_Fila3 <= ds_subrubricas_med.RowCount(); ll_Fila3++)
                    {
                        string ls_Medicamento = ds_subrubricas_med.GetItemString(ll_Fila3, "medicamento");
                        long ll_Valor = (long)ds_subrubricas_med.GetItemNumber(ll_Fila3, "valor");

                        int ll_FilaTodo = ds_capitulo_todo.InsertRow(0);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "capitulo", ll_Capitulo);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "capitulo_nombre", ls_CapituloNombre);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "rubrica", ll_Rubrica);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "rubrica_nombre", ls_RubricaNombre);

                        // Copio niveles previos
                        for (int n = 1; n <= nivelAnterior; n++)
                        {
                            string codeCol = n < 10 ? $"subrubrica0{n}" : "subrubrica10";
                            string nameCol = codeCol + "_nombre";
                            ds_capitulo_todo.SetItem(ll_FilaTodo, codeCol, subCod[n]);
                            ds_capitulo_todo.SetItem(ll_FilaTodo, nameCol, subNom[n]);
                        }

                        // Seteo nivel actual + medicamento / valor
                        ds_capitulo_todo.SetItem(ll_FilaTodo, colActualCodigo, ll_SubRubricaH);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, colActualNombre, ls_SubRubricaNombreH);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "medicamento", ls_Medicamento);
                        ds_capitulo_todo.SetItem(ll_FilaTodo, "valor", ll_Valor);
                    }
                }
            }

            // Quito filtro de este nivel
            ds_capitulo_todo.SetFilter(string.Empty);
            ds_capitulo_todo.Filter();
        }
    }
}
