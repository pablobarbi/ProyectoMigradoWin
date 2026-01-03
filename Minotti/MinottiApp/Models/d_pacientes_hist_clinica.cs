using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    public class d_pacientes_hist_clinica
    {
        // SELECT del DataWindow (adaptado a ODBC: ? en lugar de :paciente)
        public const string SqlRetrieve = @"
SELECT pacientes_historias.paciente,
       pacientes_historias.hist_clin
  FROM pacientes_historias
 WHERE pacientes_historias.paciente = ?";

        // UPDATE según el DW (update="pacientes_historias", key=paciente)
        public const string SqlUpdate = @"
UPDATE pacientes_historias
   SET hist_clin = ?
 WHERE paciente = ?";

        // INSERT equivalente para altas nuevas
        public const string SqlInsert = @"
INSERT INTO pacientes_historias (paciente, hist_clin)
VALUES (?, ?)";

        // DELETE por si necesitás borrar la historia clínica de un paciente
        public const string SqlDelete = @"
DELETE FROM pacientes_historias
 WHERE paciente = ?";

        /// <summary>
        /// Equivalente al retrieve del DataWindow:
        ///   argumentos=(("paciente", string))
        /// Devuelve un DataTable con columnas 'paciente' y 'hist_clin'.
        /// </summary>
        public static DataTable RetrieveToDataTable(object paciente)
        {
            return SQLCA.ExecuteDataTable(SqlRetrieve, cmd =>
            {
                var prm = cmd.CreateParameter();
                prm.Value = paciente ?? DBNull.Value;
                cmd.Parameters.Add(prm);
            });
        }

        /// <summary>
        /// Devuelve solo el primer registro (o null si no hay).
        /// </summary>
        public static (long paciente, string hist_clin)? RetrieveFirst(object paciente)
        {
            DataTable dt = RetrieveToDataTable(paciente);
            if (dt.Rows.Count == 0)
                return null;

            var row = dt.Rows[0];

            long pac = Convert.ToInt64(row["paciente"]);
            string hist = row["hist_clin"] as string ?? string.Empty;

            return (pac, hist);
        }

        /// <summary>
        /// Verifica si existe un registro en pacientes_historias para ese paciente.
        /// </summary>
        public static bool Exists(object paciente)
        {
            const string sql = @"
                SELECT COUNT(*)
                  FROM pacientes_historias
                 WHERE paciente = ?";

            int? count = SQLCA.ExecuteScalar<int>(sql, cmd =>
            {
                var prm = cmd.CreateParameter();
                prm.Value = paciente ?? DBNull.Value;
                cmd.Parameters.Add(prm);
            });

            return (count ?? 0) > 0;
        }

        /// <summary>
        /// Actualiza hist_clin para el paciente indicado.
        /// Usa SQLCA.Update (nuevo helper).
        /// Devuelve cantidad de filas afectadas.
        /// </summary>
        public static int Update(object paciente, string hist_clin)
        {
            return SQLCA.Update(SqlUpdate, cmd =>
            {
                var pHist = cmd.CreateParameter();
                pHist.Value = (object?)hist_clin ?? DBNull.Value;
                cmd.Parameters.Add(pHist);

                var pPac = cmd.CreateParameter();
                pPac.Value = paciente ?? DBNull.Value;
                cmd.Parameters.Add(pPac);
            });
        }

        /// <summary>
        /// Inserta un nuevo registro en pacientes_historias.
        /// Usa SQLCA.Insert (nuevo helper).
        /// Devuelve cantidad de filas afectadas.
        /// </summary>
        public static int Insert(object paciente, string hist_clin)
        {
            return SQLCA.Insert(SqlInsert, cmd =>
            {
                var pPac = cmd.CreateParameter();
                pPac.Value = paciente ?? DBNull.Value;
                cmd.Parameters.Add(pPac);

                var pHist = cmd.CreateParameter();
                pHist.Value = (object?)hist_clin ?? DBNull.Value;
                cmd.Parameters.Add(pHist);
            });
        }

        /// <summary>
        /// Borra el registro de pacientes_historias del paciente.
        /// Usa SQLCA.Delete (nuevo helper).
        /// Devuelve filas afectadas.
        /// </summary>
        public static int Delete(object paciente)
        {
            return SQLCA.Delete(SqlDelete, cmd =>
            {
                var prm = cmd.CreateParameter();
                prm.Value = paciente ?? DBNull.Value;
                cmd.Parameters.Add(prm);
            });
        }

        /// <summary>
        /// Guardar estilo DataWindow:
        /// - Si existe el paciente: UPDATE
        /// - Si no existe: INSERT
        /// Devuelve filas afectadas.
        /// </summary>
        public static int Save(object paciente, string hist_clin)
        {
            if (Exists(paciente))
                return Update(paciente, hist_clin);
            else
                return Insert(paciente, hist_clin);
        }
    }


    //public static DataTable Retrieve(OdbcConnection? externalConnection = null, params OdbcParameter[] parameters)
    //{
    //    var sql = GetSqlDefinition();
    //    if (string.IsNullOrWhiteSpace(sql)) return new DataTable();
    //    bool created = false;
    //    var cn = externalConnection;
    //    if (cn == null)
    //    {
    //        cn = new OdbcConnection("DSN=" + Config.AppConfig.SqlAnywhereDsn + ";UID=" + Config.AppConfig.SqlAnywhereUid + ";PWD=" + Config.AppConfig.SqlAnywherePwd);
    //        created = true;
    //    }
    //    using var cmd = cn.CreateCommand();
    //    cmd.CommandText = sql;
    //    if (parameters != null && parámetros := parameters) && parameters.Length > 0:
    //        cmd.Parameters.AddRange(parameters)
    //    var dt = new DataTable();
    //    try
    //    {
    //        if (created) cn.Open();
    //        using var da = new OdbcDataAdapter((OdbcCommand)cmd);
    //        da.Fill(dt);
    //    }
    //    finally
    //    {
    //        if (created && cn != null) cn.Dispose();
    //    }
    //    return dt;
    //}

    /* ===== UPDATE (tal cual en SRD) =====
pacientes_historias
    */

    /* ===== SRD original completo =====
﻿release 7;
datawindow(units=0 timer_interval=0 color=81324524 processing=0 HTMLDW=no print.documentname="" print.orientation = 0 print.margin.left = 110 print.margin.right = 110 print.margin.top = 96 print.margin.bottom = 96 print.paper.source = 0 print.paper.size = 0 print.prompt=no print.buttons=no print.preview.buttons=no )
summary(height=0 color="536870912" )
footer(height=0 color="536870912" )
detail(height=1144 color="536870912" )
table(column=(type=long update=yes updatewhereclause=yes key=yes name=paciente dbname="pacientes_historias.paciente" )
column=(type=char(32766) update=yes updatewhereclause=no name=hist_clin dbname="pacientes_historias.hist_clin" )
retrieve="SELECT pacientes_historias.paciente,
   pacientes_historias.hist_clin
FROM pacientes_historias
WHERE pacientes_historias.paciente = :paciente
" update="pacientes_historias" updatewhere=1 updatekeyinplace=no arguments=(("paciente", string)) )
text(band=detail alignment="1" text="Paciente:" border="0" color="8388608" x="37" y="24" height="64" width="274"  name=paciente_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=1 alignment="0" tabsequence=32766 border="0" color="0" x="329" y="24" height="76" width="1979" format="[general]"  name=paciente dddw.name=dw_pacientes dddw.displaycolumn=nombre dddw.datacolumn=paciente dddw.percentwidth=0 dddw.lines=6 dddw.limit=0 dddw.allowedit=no dddw.useasborder=no dddw.case=any dddw.nilisnull=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="553648127" )
text(band=detail alignment="2" text="Historia Clinica" border="0" color="8388608" x="32" y="140" height="64" width="2277"  name=hist_clin_t  font.face="Arial" font.height="-10" font.weight="700"  font.family="2" font.pitch="2" font.charset="0" background.mode="1" background.color="536870912" )
column(band=detail id=2 alignment="0" tabsequence=10 border="5" color="0" x="32" y="232" height="872" width="2277" format="[general]"  name=hist_clin edit.limit=32000 edit.case=any edit.focusrectangle=no edit.autoselect=no edit.required=yes edit.autohscroll=yes edit.autovscroll=yes edit.hscrollbar=yes edit.vscrollbar=yes  font.face="Arial" font.height="-10" font.weight="400"  font.family="2" font.pitch="2" font.charset="0" background.mode="2" background.color="16777215" )
htmltable(border="1" )
htmlgen(clientevents="1" clientvalidation="1" clientcomputedfields="1" clientformatting="0" clientscriptable="0" generatejavascript="1" )

    */ 

}
 