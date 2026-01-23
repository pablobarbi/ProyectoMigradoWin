using Minotti.Data;
using Minotti.Metadata;
using Minotti.Metadata.Generated;
using Minotti.utils;

namespace MinottiApp.Metadata
{
    public static class MetadataFactory
    {
        private static readonly Dictionary<string, IDataWindowMetadata> _map = new()
        {


            ["d_agregar_capitulos"] = new d_agregar_capitulos(),
            ["d_agregar_rubricas"] = new d_agregar_rubricas(),
            ["d_agregar_subrubricas"] = new d_agregar_subrubricas(),
            ["d_ayuda"] = new d_ayuda(),
            ["d_buscar"] = new d_buscar(),
            ["d_campos_invisibles"] = new d_campos_invisibles(),
            ["d_carpetas"] = new d_carpetas(),
            ["d_diagnosticos"] = new d_diagnosticos(),
            ["d_medicamentos"] = new d_medicamentos(),
            ["d_medicamentos_sin_blob"] = new d_medicamentos_sin_blob(),
            ["d_modulo"] = new d_modulo(),
            ["d_modulos_por_perfil"] = new d_modulos_por_perfil(),
            ["d_modulos_x_perfil"] = new d_modulos_x_perfil(),
            ["d_modulos_x_perfil2"] = new d_modulos_x_perfil2(),
            ["d_operacion"] = new d_operacion(),
            ["d_operaciones"] = new d_operaciones(),
            ["d_operaciones_x_modulo"] = new d_operaciones_x_modulo(),
            ["d_operaciones_x_modulo__"] = new d_operaciones_x_modulo__(),
            ["d_operaciones_x_perfil"] = new d_operaciones_x_perfil(),
            ["d_operaciones_x_perfil_sub_modulo"] = new d_operaciones_x_perfil_sub_modulo(),
            ["d_pacientes"] = new d_pacientes(),
            ["d_pacientes_hist_clinica"] = new d_pacientes_hist_clinica(),
            ["d_param_x_operacion"] = new d_param_x_operacion(),
            ["d_parametros"] = new d_parametros(),
            ["d_parametros_x_operacion"] = new d_parametros_x_operacion(),
            ["d_perfil"] = new d_perfil(),
            ["d_perfiles_x_usuario"] = new d_perfiles_x_usuario(),
            ["d_reperto_total"] = new d_reperto_total(),
            ["d_reperto_total_diagnosticos"] = new d_reperto_total_diagnosticos(),
            ["d_reperto_total_diagnosticos_multiple"] = new d_reperto_total_diagnosticos_multiple(),
            ["d_reperto_total_diagnosticos_ver"] = new d_reperto_total_diagnosticos_ver(),
            ["d_reperto_total_medicamentos"] = new d_reperto_total_medicamentos(),
            ["d_reperto_total_sintomas"] = new d_reperto_total_sintomas(),
            ["d_saveas"] = new d_saveas(),
            ["d_sortdragdrop"] = new d_sortdragdrop(),
            ["d_sub_modulos_x_perfil"] = new d_sub_modulos_x_perfil(),
            ["d_submodulos"] = new d_submodulos(),
            ["d_system_error"] = new d_system_error(),
            ["d_system_error_impresion"] = new d_system_error_impresion(),
            ["d_usuario"] = new d_usuario(),
            ["d_valor_inicial"] = new d_valor_inicial(),
            ["dk_capitulos"] = new dk_capitulos(),
            ["dk_diagnosticos"] = new dk_diagnosticos(),
            ["dk_medicamentos"] = new dk_medicamentos(),
            ["dk_medicamentos_de_la_rubrica"] = new dk_medicamentos_de_la_rubrica(),
            ["dk_medicamentos_de_la_rubrica_vfinal_bug"] = new dk_medicamentos_de_la_rubrica_vfinal_bug(),
            ["dk_medicamentos_de_la_subrubrica"] = new dk_medicamentos_de_la_subrubrica(),
            ["dk_medicamentos_de_la_subrubrica_ph"] = new dk_medicamentos_de_la_subrubrica_ph(),
            ["dk_medicamentos_ejemplos"] = new dk_medicamentos_ejemplos(),
            ["dk_mig_subrubricas"] = new dk_mig_subrubricas(),
            ["dk_modulos"] = new dk_modulos(),
            ["dk_modulos_x_perfil"] = new dk_modulos_x_perfil(),
            ["dk_operaciones"] = new dk_operaciones(),
            ["dk_operaciones_x_modulo"] = new dk_operaciones_x_modulo(),
            ["dk_pacientes"] = new dk_pacientes(),
            ["dk_perfiles"] = new dk_perfiles(),
            ["dk_reperto_lista_para_multiple"] = new dk_reperto_lista_para_multiple(),
            ["dk_reperto_total"] = new dk_reperto_total(),
            ["dk_reperto_total_tabla_med"] = new dk_reperto_total_tabla_med(),
            ["dk_reperto_total_tabla_med_multiple"] = new dk_reperto_total_tabla_med_multiple(),
            ["dk_repertos_parciales"] = new dk_repertos_parciales(),
            ["dk_repertos_parciales_multiple"] = new dk_repertos_parciales_multiple(),
            ["dk_repertos_parciales_sin_usar"] = new dk_repertos_parciales_sin_usar(),
            ["dk_repertos_parciales_v1"] = new dk_repertos_parciales_v1(),
            ["dk_repertos_totales"] = new dk_repertos_totales(),
            ["dk_repertos_totales_bak"] = new dk_repertos_totales_bak(),
            ["dk_repertos_totales_multiple"] = new dk_repertos_totales_multiple(),
            ["dk_repertos_totales_sintomas"] = new dk_repertos_totales_sintomas(),
            ["dk_repertos_totales_sintomas_graba"] = new dk_repertos_totales_sintomas_graba(),
            ["dk_rubricas_del_capitulo"] = new dk_rubricas_del_capitulo(),
            ["dk_submodulos"] = new dk_submodulos(),
            ["dk_subrubricas_de_la_rubrica"] = new dk_subrubricas_de_la_rubrica(),
            ["dk_subrubricas_de_la_subrubrica"] = new dk_subrubricas_de_la_subrubrica(),
            ["dk_usuarios"] = new dk_usuarios(),
            ["dks_modulos_no_estan_perfil"] = new dks_modulos_no_estan_perfil(),
            ["dl_capitulo_completo"] = new dl_capitulo_completo(),
            ["dl_capitulo_matriz"] = new dl_capitulo_matriz(),
            ["dl_dos_medicamentos"] = new dl_dos_medicamentos(),
            ["dl_dos_medicamentos_un_valor"] = new dl_dos_medicamentos_un_valor(),
            ["dl_medicamentos_desde_hasta"] = new dl_medicamentos_desde_hasta(),
            ["dl_modulos"] = new dl_modulos(),
            ["dl_operaciones"] = new dl_operaciones(),
            ["dl_operaciones_por_modulo"] = new dl_operaciones_por_modulo(),
            ["dl_operaciones_por_perfil"] = new dl_operaciones_por_perfil(),
            ["dl_operaciones_por_usuario"] = new dl_operaciones_por_usuario(),
            ["dl_pacientes"] = new dl_pacientes(),
            ["dl_pacientes_diagnostico"] = new dl_pacientes_diagnostico(),
            ["dl_pacientes_diagnosticos_tipo_fecha"] = new dl_pacientes_diagnosticos_tipo_fecha(),
            ["dl_pacientes_estadisticas"] = new dl_pacientes_estadisticas(),
            ["dl_pacientes_historia_clinica"] = new dl_pacientes_historia_clinica(),
            ["dl_perfiles"] = new dl_perfiles(),
            ["dl_un_medicamento"] = new dl_un_medicamento(),
            ["dl_un_medicamento_un_valor"] = new dl_un_medicamento_un_valor(),
            ["dl_usuarios"] = new dl_usuarios(),
            ["dp_actualizar_matriz"] = new dp_actualizar_matriz(),
            ["dp_capitulo_medicamento_valor"] = new dp_capitulo_medicamento_valor(),
            ["dp_capitulos"] = new dp_capitulos(),
            ["dp_diagnosticos"] = new dp_diagnosticos(),
            ["dp_dos_medicamentos"] = new dp_dos_medicamentos(),
            ["dp_dos_medicamentos_valor"] = new dp_dos_medicamentos_valor(),
            ["dp_fecha_desde_hasta"] = new dp_fecha_desde_hasta(),
            ["dp_filtro_todo"] = new dp_filtro_todo(),
            ["dp_global_busqueda"] = new dp_global_busqueda(),
            ["dp_medicamentos_desde_hasta"] = new dp_medicamentos_desde_hasta(),
            ["dp_pacientes"] = new dp_pacientes(),
            ["dp_pacientes_mas_todos"] = new dp_pacientes_mas_todos(),
            ["dp_perfil"] = new dp_perfil(),
            ["dp_reperto_multiples"] = new dp_reperto_multiples(),
            ["dp_un_medicamento"] = new dp_un_medicamento(),
            ["dp_un_medicamento_valor"] = new dp_un_medicamento_valor(),
            ["dp_usuario"] = new dp_usuario(),
            ["dr_actualizar_matriz"] = new dr_actualizar_matriz(),
            ["dr_capitulo_completo"] = new dr_capitulo_completo(),
            ["dr_capitulo_matriz"] = new dr_capitulo_matriz(),
            ["dr_dos_medicamentos"] = new dr_dos_medicamentos(),
            ["dr_dos_medicamentos_un_valor"] = new dr_dos_medicamentos_un_valor(),
            ["dr_global_capitulos"] = new dr_global_capitulos(),
            ["dr_global_diagnosticos"] = new dr_global_diagnosticos(),
            ["dr_global_medicamentos"] = new dr_global_medicamentos(),
            ["dr_global_rubricas"] = new dr_global_rubricas(),
            ["dr_global_subrubricas"] = new dr_global_subrubricas(),
            ["dr_medicamentos_desde_hasta"] = new dr_medicamentos_desde_hasta(),
            ["dr_modulos"] = new dr_modulos(),
            ["dr_operaciones"] = new dr_operaciones(),
            ["dr_operaciones_por_modulo"] = new dr_operaciones_por_modulo(),
            ["dr_operaciones_por_perfil"] = new dr_operaciones_por_perfil(),
            ["dr_operaciones_por_usuario"] = new dr_operaciones_por_usuario(),
            ["dr_pacientes"] = new dr_pacientes(),
            ["dr_pacientes_diagnostico"] = new dr_pacientes_diagnostico(),
            ["dr_pacientes_diagnosticos_tipo_fecha"] = new dr_pacientes_diagnosticos_tipo_fecha(),
            ["dr_pacientes_estadisticas"] = new dr_pacientes_estadisticas(),
            ["dr_pacientes_historia_clinica"] = new dr_pacientes_historia_clinica(),
            ["dr_perfiles"] = new dr_perfiles(),
            ["dr_un_medicamento"] = new dr_un_medicamento(),
            ["dr_un_medicamento_un_valor"] = new dr_un_medicamento_un_valor(),
            ["dr_usuarios"] = new dr_usuarios(),
            ["dsto_actualiza_capitulacion_med"] = new dsto_actualiza_capitulacion_med(),
            ["dsto_actualiza_rubricacion_med"] = new dsto_actualiza_rubricacion_med(),
            ["dsto_actualiza_rubricas"] = new dsto_actualiza_rubricas(),
            ["dsto_actualiza_subrubricacion_med"] = new dsto_actualiza_subrubricacion_med(),
            ["dsto_actualiza_subrubricas"] = new dsto_actualiza_subrubricas(),
            ["dsto_medicamentos_reperto_parc"] = new dsto_medicamentos_reperto_parc(),
            ["dsto_medicamentos_rubrica"] = new dsto_medicamentos_rubrica(),
            ["dsto_medicamentos_subrubrica"] = new dsto_medicamentos_subrubrica(),
            ["dsto_medicamentos_subrubrica_ph"] = new dsto_medicamentos_subrubrica_ph(),
            ["dsto_reperto_parcial"] = new dsto_reperto_parcial(),
            ["dsto_reperto_parcial_med"] = new dsto_reperto_parcial_med(),
            ["dsto_reperto_temporal"] = new dsto_reperto_temporal(),
            ["dsto_reperto_total"] = new dsto_reperto_total(),
            ["dsto_reperto_total_sintoma"] = new dsto_reperto_total_sintoma(),
            ["duo_capitulaciones"] = new duo_capitulaciones(),
            ["duo_capitulaciones_med"] = new duo_capitulaciones_med(),
            ["duo_capitulo_completo"] = new duo_capitulo_completo(),
            ["duo_rubricaciones"] = new duo_rubricaciones(),
            ["duo_rubricaciones_med"] = new duo_rubricaciones_med(),
            ["duo_subrubricaciones"] = new duo_subrubricaciones(),
            ["duo_subrubricaciones_med"] = new duo_subrubricaciones_med(),
            ["dw_calendar"] = new dw_calendar(),
            ["dw_calendar_anterior"] = new dw_calendar_anterior(),
            ["dw_calendar_bak"] = new dw_calendar_bak(),
            ["dw_capitulos"] = new dw_capitulos(),
            ["dw_estado_civil"] = new dw_estado_civil(),
            ["dw_medicamentos"] = new dw_medicamentos(),
            ["dw_modulos"] = new dw_modulos(),
            ["dw_operaciones"] = new dw_operaciones(),
            ["dw_pacientes"] = new dw_pacientes(),
            ["dw_pacientes_mas_todos"] = new dw_pacientes_mas_todos(),
            ["dw_perfiles"] = new dw_perfiles(),
            ["dw_rubricas"] = new dw_rubricas(),
            ["dw_submodulos"] = new dw_submodulos(),
            ["dw_subrubricas"] = new dw_subrubricas(),
            ["dw_usuarios"] = new dw_usuarios(),
            ["r_header"] = new r_header(),
            ["r_header_landscape"] = new r_header_landscape(),
            ["r_summary"] = new r_summary(),

        };

        public static IDataWindowMetadata Get(string dataObject)
        {
            if (string.IsNullOrWhiteSpace(dataObject))
                return EmptyMetadata.Instance;

            if (_map.TryGetValue(dataObject, out var meta) && meta != null)
                return meta;

            // PB-like: no existe metadata → seguimos circuito
            return EmptyMetadata.Instance;
        }




        /// <summary>
        /// PB-like: crea un datastore usando metadata + SQLCA
        /// El SQL se toma del SRD asociado al DataObject
        /// </summary>
        public static datastore CreateDataStore(string dataObject)
        {
            if (string.IsNullOrWhiteSpace(dataObject))
                throw new ArgumentException("DataObject vacío", nameof(dataObject));

            // valida que exista metadata
            var metadata = Get(dataObject);

            var ds = new datastore();
            ds.SetTransObject(SQLCA.Instance);
            ds.DataObject = metadata.DataObject;

            return ds;
        }

        public static bool Exists(string dataObject)
        {
            if (string.IsNullOrWhiteSpace(dataObject))
                return false;

            return _map.ContainsKey(dataObject);
        }


    }
}
