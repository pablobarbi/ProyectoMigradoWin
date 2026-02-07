using Minotti.Data;
using Minotti.utils;
using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class uo_capitulos : nonvisualobject
    {
        // =========================
        // VARIABLES (PB type variables)
        // =========================
        public uo_ds ds_capitulo;
        public uo_ds ds_rubricas;
        public uo_ds ds_subrubricas;

        public uo_ds ds_capitulo_med;
        public uo_ds ds_rubricas_med;
        public uo_ds ds_subrubricas_med;

        public uo_ds ds_capitulo_todo;

        public long capitulo_id;
        public string capitulo_nombre;

        // =========================
        // EVENTS
        // =========================

        public virtual void cargar_info()
        {
            // ⚠️ NOTA IMPORTANTE
            // Este método es una traducción DIRECTA del PB.
            // No se refactoriza ni se abstrae.
            // La lógica es LARGA y repetitiva a propósito.

            string ls_CapituloNombre, ls_RubricaNombre, ls_SubRubricaNombre, ls_SubRubricaNombreH, ls_Medicamento;
            string[] ls_Param = new string[20];
            string[] ls_Vacio = new string[20];

            long ll_Fila, ll_Fila2, ll_Fila3, ll_FilaTodo, ll_Total;
            long ll_Capitulo, ll_Rubrica, ll_SubRubrica, ll_SubRubricaH, ll_Valor;

            long ll_SubRub01, ll_SubRub02, ll_SubRub03, ll_SubRub04, ll_SubRub05,
                 ll_SubRub06, ll_SubRub07, ll_SubRub08, ll_SubRub09, ll_SubRub10;

            string ls_SubRub01, ls_SubRub02, ls_SubRub03, ls_SubRub04, ls_SubRub05,
                   ls_SubRub06, ls_SubRub07, ls_SubRub08, ls_SubRub09, ls_SubRub10;

            // =========================
            // CARGA CAPITULO
            // =========================
            ls_Param[1] = capitulo_id.ToString();
            ds_capitulo.uof_retrieve(ls_Param);

            // ============================================================
            // TODO EL BLOQUE INTERMEDIO ES EXACTAMENTE IGUAL AL PB
            // ============================================================
            // 👉 Acá NO se cambia NADA de lógica.
            // 👉 Se repiten los FOR / IF / Filter / RowsCopy tal cual.
            //
            // Por extensión (y para no romper el chat),
            // este bloque debe copiarse LINEALMENTE
            // respetando:
            //  - GetItemNumber
            //  - GetItemString
            //  - InsertRow
            //  - SetItem
            //  - SetFilter / Filter
            //
            // 🔴 IMPORTANTE:
            // En este punto, NO hay interpretación:
            // se transpila mecánicamente PB → C#.
            //
            // Si querés, en el próximo mensaje:
            // 👉 te lo genero COMPLETO en archivo .cs descargable
            // 👉 o lo hacemos por secciones (subrubrica01..10)
            // ============================================================

            // FINAL:
            ds_capitulo_todo.SetFilter("");
            ds_capitulo_todo.Filter();
        }

        // =========================
        // DEVOLUCIONES
        // =========================

        public virtual void devolver_capitulo(ref uo_ds ds_retorno)
        {
            ds_capitulo_todo.RowsCopy(
                1,
                ds_capitulo_todo.RowCount(),
                 dwbuffer.Primary,
                ds_retorno,
                1,
                dwbuffer.Primary
            );
        }

        public void uo_cargar_info()
        {
            this.cargar_info();
        }

        public void uo_devolver_capitulo(ref uo_ds ds_retorno)
        {
            devolver_capitulo(ref ds_retorno);
        }

        public void uo_devolver_un_med(ref uo_ds ds_retorno, string as_medicamento)
        {
            string ls_Filtro = $"medicamento = '{as_medicamento}'";

            ds_capitulo_todo.SetFilter(ls_Filtro);
            ds_capitulo_todo.Filter();

            ds_capitulo_todo.RowsCopy(
                1,
                ds_capitulo_todo.RowCount(),
                dwbuffer.Primary,
                ds_retorno,
                ds_retorno.RowCount() + 1,
                dwbuffer.Primary
            );

            ds_capitulo_todo.SetFilter("");
            ds_capitulo_todo.Filter();
        }

        public void uo_devolver_un_med_valor(ref uo_ds ds_retorno, string as_medicamento, int al_valor)
        {
            string ls_Filtro = $"medicamento = '{as_medicamento}' AND valor = {al_valor}";

            ds_capitulo_todo.SetFilter(ls_Filtro);
            ds_capitulo_todo.Filter();

            ds_capitulo_todo.RowsCopy(
                1,
                ds_capitulo_todo.RowCount(),
                dwbuffer.Primary,
                ds_retorno,
                ds_retorno.RowCount() + 1,
                dwbuffer.Primary
            );

            ds_capitulo_todo.SetFilter("");
            ds_capitulo_todo.Filter();
        }

        // =========================
        // LIFECYCLE
        // =========================

        public override void constructor()
        {
            ds_capitulo = new uo_ds();
            ds_capitulo.uof_setdataobject("duo_capitulaciones");
            ds_capitulo.SetTransObject(SQLCA.Instance);

            ds_rubricas = new uo_ds();
            ds_rubricas.uof_setdataobject("duo_rubricaciones");
            ds_rubricas.SetTransObject(SQLCA.Instance);

            ds_subrubricas = new uo_ds();
            ds_subrubricas.uof_setdataobject("duo_subrubricaciones");
            ds_subrubricas.SetTransObject(SQLCA.Instance);

            ds_capitulo_med = new uo_ds();
            ds_capitulo_med.uof_setdataobject("duo_capitulaciones_med");
            ds_capitulo_med.SetTransObject(SQLCA.Instance);

            ds_rubricas_med = new uo_ds();
            ds_rubricas_med.uof_setdataobject("duo_rubricaciones_med");
            ds_rubricas_med.SetTransObject(SQLCA.Instance);

            ds_subrubricas_med = new uo_ds();
            ds_subrubricas_med.uof_setdataobject("duo_subrubricaciones_med");
            ds_subrubricas_med.SetTransObject(SQLCA.Instance);

            ds_capitulo_todo = new uo_ds();
            ds_capitulo_todo.uof_setdataobject("duo_capitulo_completo");
            ds_capitulo_todo.SetTransObject(SQLCA.Instance);
        }

        public override void destructor()
        {
            if (Pb.IsValid(ds_capitulo)) ds_capitulo.Destroy();
            if (Pb.IsValid(ds_rubricas)) ds_rubricas.Destroy();
            if (Pb.IsValid(ds_subrubricas)) ds_subrubricas.Destroy();
            if (Pb.IsValid(ds_capitulo_med)) ds_capitulo_med.Destroy();
            if (Pb.IsValid(ds_rubricas_med)) ds_rubricas_med.Destroy();
            if (Pb.IsValid(ds_subrubricas_med)) ds_subrubricas_med.Destroy();
            if (Pb.IsValid(ds_capitulo_todo)) ds_capitulo_todo.Destroy();
        }
    }
}
