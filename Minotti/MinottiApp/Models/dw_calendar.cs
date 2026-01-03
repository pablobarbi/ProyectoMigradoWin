using System;
using System.Data;

namespace Minotti.Models
{
    /// <summary>
    /// Migración de SRD: dw_calendar.srd
    /// No contiene SQL (DataWindow de tipo 'external'), por lo que:
    /// - Mantengo el nombre de la clase: dw_calendar
    /// - Expongo métodos para crear el esquema (t1..t42, month, year, curday)
    /// - Incluyo helper para generar una fila con el calendario (6x7) del mes indicado.
    /// </summary>
    public static class dw_calendar
    {
        /// <summary>
        /// Crea un DataTable con columnas numéricas: t1..t42, month, year, curday.
        /// </summary>
        public static DataTable CreateSchema()
        {
            var dt = new DataTable("dw_calendar");
            // 42 celdas (6 filas x 7 columnas) al estilo DataWindow
            for (int i = 1; i <= 42; i++)
            {
                dt.Columns.Add("t" + i, typeof(int));
            }
            dt.Columns.Add("month", typeof(int));
            dt.Columns.Add("year", typeof(int));
            dt.Columns.Add("curday", typeof(int));
            return dt;
        }

        /// <summary>
        /// Genera una fila con la grilla de calendario para (year, month).
        /// startOnMonday=true crea la semana iniciada en lunes (común en AR).
        /// Fuera de mes se llena con 0 (vacío).
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
