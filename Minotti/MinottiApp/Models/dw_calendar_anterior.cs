using System;
using System.Data;

namespace Minotti.Models
{
    /// <summary>
    /// Migración de SRD: dw_calendar_anterior.srd
    /// DataWindow de tipo "external" (sin SQL).
    /// Mantengo el nombre base y creo utilitarios para esquema y generación de la grilla.
    /// Columnas: t1..t42 (int), month (int), year (int), curday (int).
    /// </summary>
    public static class dw_calendar_anterior
    {
        /// <summary>
        /// Crea un DataTable con columnas numéricas: t1..t42, month, year, curday.
        /// </summary>
        public static DataTable CreateSchema()
        {
            var dt = new DataTable("dw_calendar_anterior");
            for (int i = 1; i <= 42; i++)
                dt.Columns.Add("t" + i, typeof(int));
            dt.Columns.Add("month", typeof(int));
            dt.Columns.Add("year", typeof(int));
            dt.Columns.Add("curday", typeof(int));
            return dt;
        }

        /// <summary>
        /// Genera una fila con la grilla de calendario para (year, month).
        /// startOnMonday=true usa semana iniciada en lunes (común en AR).
        /// Celdas fuera del mes se completan con 0.
        /// </summary>
        public static DataRow CreateRow(int year, int month, int curday = 0, bool startOnMonday = true)
        {
            var dt = CreateSchema();
            var row = dt.NewRow();

            int daysInMonth = DateTime.DaysInMonth(year, month);
            var first = new DateTime(year, month, 1);
            int dow = (int)first.DayOfWeek; // 0=Sunday..6=Saturday
            int offset = startOnMonday ? ((dow == 0) ? 6 : dow - 1) : dow; // lunes=0

            for (int cell = 1; cell <= 42; cell++)
            {
                int val = cell - offset;
                if (val < 1 || val > daysInMonth) val = 0;
                row["t" + cell] = val;
            }

            row["month"] = month;
            row["year"] = year;
            row["curday"] = curday > 0 ? curday : DateTime.Today.Day;
            dt.Rows.Add(row);
            return row;
        }
    }
}
