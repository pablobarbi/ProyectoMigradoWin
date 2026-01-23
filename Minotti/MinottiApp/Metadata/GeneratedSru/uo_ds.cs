// -----------------------------------------------------------------------------
// uo_ds (PB: datastore con funcionalidad adicional)
// -----------------------------------------------------------------------------
#nullable enable
using Minotti.utils;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Minotti.Metadata.GeneratedSru
{
    // Cambiá "DataStore" por la clase base real de tu solución si difiere.
    public class uo_ds : datastore
    {
        private bool ib_registrar_usuario = false;

        public cat_columna[] at_col = Array.Empty<cat_columna>();
        public int[] ii_claves = Array.Empty<int>();

        public string uof_getfiltroclave(long row)
        {
            int cantidad = ii_claves?.Length ?? 0;
            string filtro = string.Empty;

            for (int i = 0; i < cantidad; i++)
            {
                int idxCol = ii_claves[i];
                if (idxCol <= 0 || idxCol > at_col.Length) continue;

                filtro += at_col[idxCol - 1].Nombre + " = '" + uof_getitem(row, idxCol) + "'";
                if (i < cantidad - 1) filtro += " and ";
            }

            return filtro;
        }

        public void uof_setdataobject(string data_object)
        {
            int campos = 0;
            try
            {
                campos = Pb.PBInt(guo_app?.ds_valor_inicial?.RowCount());
            }
            catch { campos = 0; }

            this.DataObject = data_object;

            string param = this.Describe("DataWindow.Objects");
            while (!Pb.IsNullOrEmpty(param))
            {
                string sAux = Pb.Cut(ref param, "\t");
                if (sAux == "usr_upd") ib_registrar_usuario = true;
            }

            int colCount = Pb.PBInt(this.Describe("DataWindow.Column.Count"));
            if (colCount < 0) colCount = 0;

            at_col = new cat_columna[colCount];
            var claves = new List<int>();

            for (int iAux = 1; iAux <= colCount; iAux++)
            {
                var col = new cat_columna();
                col.Nombre = this.Describe("#" + iAux.ToString(CultureInfo.InvariantCulture) + ".Name");
                col.Titulo = this.Describe(col.Nombre + "_t.Text");
                col.Tipo = Left(this.Describe("#" + iAux.ToString(CultureInfo.InvariantCulture) + ".Coltype"), 5);

                col.TabOrder = Pb.PBInt(this.Describe("#" + iAux.ToString(CultureInfo.InvariantCulture) + ".TabSequence"));

                if (Upper(this.Describe("#" + iAux + ".Criteria.Dialog")) == "YES")
                {
                    col.Filtro = true;
                    this.Modify("#" + iAux + ".Criteria.Dialog=NO");
                }
                else col.Filtro = false;

                col.Requerido = false;
                if (Upper(this.Describe("#" + iAux + ".Edit.Required")) == "YES")
                {
                    col.Requerido = true;
                    this.Modify("#" + iAux + ".Edit.Required=NO");
                }
                else if (Upper(this.Describe("#" + iAux + ".DDLB.Required")) == "YES")
                {
                    col.Requerido = true;
                    this.Modify("#" + iAux + ".DDLB.Required=NO");
                }
                else if (Upper(this.Describe("#" + iAux + ".DDDW.Required")) == "YES")
                {
                    col.Requerido = true;
                    this.Modify("#" + iAux + ".DDDW.Required=NO");
                }
                else if (Upper(this.Describe("#" + iAux + ".EditMask.Required")) == "YES")
                {
                    col.Requerido = true;
                    this.Modify("#" + iAux + ".EditMask.Required=NO");
                }

                if (Upper(this.Describe("#" + iAux + ".Key")) == "YES")
                    claves.Add(iAux);

                if (campos > 0)
                {
                    try
                    {
                        int m = Pb.PBInt(guo_app.ds_valor_inicial.Find("campo = '" + col.Nombre + "'", 1, campos));
                        if (m > 0)
                        {
                            string v = guo_app.ds_valor_inicial.GetItemString(m, "valor_inicial");
                            this.Modify(col.Nombre + ".Initial='" + v + "'");
                        }
                    }
                    catch { }
                }

                at_col[iAux - 1] = col;
            }

            ii_claves = claves.ToArray();
        }

        public string uof_getitem(long fila, int columna)
        {
            if (columna <= 0 || columna > (at_col?.Length ?? 0)) return string.Empty;
            if (fila <= 0 || fila > this.RowCount()) return string.Empty;

            string tipo = at_col[columna - 1].Tipo ?? string.Empty;
            string retorno;

            switch (tipo)
            {
                case "char(":
                    retorno = this.GetItemString(fila, columna);
                    break;
                case "long":
                case "numbe":
                case "real":
                    retorno = Pb.PBString(this.GetItemNumber(fila, columna));
                    break;
                case "decim":
                    retorno = Pb.PBString(this.GetItemDecimal(fila, columna));
                    break;
                case "date":
                    retorno = f_date_a_string(this.GetItemDate(fila, columna));
                    break;
                case "datet":
                    retorno = f_datetime_a_string(this.GetItemDateTime(fila, columna));
                    break;
                case "time":
                    retorno = Pb.PBString(this.GetItemTime(fila, columna));
                    break;
                default:
                    retorno = Pb.PBString(this.GetItemString(fila, columna));
                    break;
            }

            return retorno ?? string.Empty;
        }

        public long uof_retrieve(string[] parametros)
        {
            parametros ??= Array.Empty<string>();
            for (int i = 0; i < parametros.Length; i++)
                if (parametros[i] == null) parametros[i] = string.Empty;

            int n = parametros.Length;

            return n switch
            {
                0 => this.Retrieve(),
                1 => this.Retrieve(parametros[0]),
                2 => this.Retrieve(parametros[0], parametros[1]),
                3 => this.Retrieve(parametros[0], parametros[1], parametros[2]),
                4 => this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3]),
                5 => this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3], parametros[4]),
                6 => this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3], parametros[4], parametros[5]),
                7 => this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3], parametros[4], parametros[5], parametros[6]),
                8 => this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3], parametros[4], parametros[5], parametros[6], parametros[7]),
                9 => this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3], parametros[4], parametros[5], parametros[6], parametros[7], parametros[8]),
                10 => this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3], parametros[4], parametros[5], parametros[6], parametros[7], parametros[8], parametros[9]),
                _ => throw new InvalidOperationException($"uo_ds.uof_retrieve: demasiados parámetros ({n}). PB soportaba hasta 10.")
            };
        }

        public long uof_retrieve() => uof_retrieve(Array.Empty<string>());

        public bool uof_getclaves(ref string[] parametros, int fila)
        {
            parametros = Array.Empty<string>();
            if (ii_claves == null || ii_claves.Length == 0) return true;

            var tmp = new string[ii_claves.Length];
            bool retorno = true;

            for (int i = 0; i < ii_claves.Length; i++)
            {
                tmp[i] = uof_getitem(fila, ii_claves[i]);
                if (tmp[i] == null) retorno = false;
            }

            parametros = tmp;
            return retorno;
        }

        private static string Upper(string? s) => (s ?? string.Empty).ToUpperInvariant();
        private static string Left(string? s, int len)
        {
            s ??= string.Empty;
            if (len <= 0) return string.Empty;
            return s.Length <= len ? s : s.Substring(0, len);
        }

        private static string f_date_a_string(DateTime dt) => dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        private static string f_datetime_a_string(DateTime dt) => dt.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

        // Runtime PB deps (inyectable)
        public dynamic? guo_app { get; set; }
    }
}
