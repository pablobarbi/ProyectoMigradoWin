using Minotti.utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Minotti.Views.Menues.Controls
{
    // PB: global type uo_calendar from datawindow
    public class uo_calendar : datawindow
    {
        // PB props (las dejo tal cual nombres PB)
        public int y = 472;
        public int width = 471;
        public int height = 456;
        public int taborder = 20;
        public string dataobject = "dw_calendar";
        public bool border = false;
        public bool livescroll = true;

        // PB events
        public event Action? ue_datechanged;
        public event Action? ue_escape;

        public uo_calendar()
        {
            // on constructor; setDate(day(today()), month(today()), year(today()))
            setdate(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);
        }

        // =========================
        // PB: event ue_datechanged; acceptText()
        // =========================
        public void On_ue_datechanged()
        {
            // call PB AcceptText
            this.AcceptText();
            ue_datechanged?.Invoke();
        }

        // =========================
        // PB: event key pbm_keyup
        // if keyDown(keyEscape!) then post ue_escape()
        // =========================
        public void pbm_keyup(Keys key)
        {
            if (key == Keys.Escape)
            {
                // Event post ue_escape()
                PostEvent(nameof(ue_escape));
            }
        }

        // PB: public function date getdate()
        public DateTime getdate()
        {
            // PB: date(getItemNumber(1,"year"), getItemNumber(1,"month"), getItemNumber(1,"curDay"))
            int year = (int)GetItemNumberInt(1, "year");
            int month = (int)GetItemNumberInt(1, "month");
            int day = (int)GetItemNumberInt(1, "curDay");
            return new DateTime(year, month, day);
        }

        // PB: public subroutine setmonth (integer themonth, integer theyear)
        public void setmonth(int themonth, int theyear)
        {
            DateTime startOfMonth;
            int firstDay, count, numDaysInMonth;

            Reset();
            InsertRow(0);

            startOfMonth = new DateTime(theyear, themonth, 1);
            firstDay = dayNumber(startOfMonth);
            numDaysInMonth = daysinmonth(themonth, theyear);

            for (count = 1; count <= numDaysInMonth; count++)
            {
                SetItem(1, "t" + (count + firstDay - 1).ToString(CultureInfo.InvariantCulture), count);
            }

            SetItem(1, "curDay", 1);
            SetItem(1, "month", themonth);
            SetItem(1, "year", theyear);

            this.PostEvent("ue_dateChanged");
        }

        // PB: public subroutine setdate (integer theday, integer themonth, integer theyear)
        public void setdate(int theday, int themonth, int theyear)
        {
            DateTime startOfMonth;
            int firstDay, count, numDaysInMonth;

            Reset();
            InsertRow(0);

            startOfMonth = new DateTime(theyear, themonth, 1);
            firstDay = dayNumber(startOfMonth);
            numDaysInMonth = daysinmonth(themonth, theyear);

            for (count = 1; count <= numDaysInMonth; count++)
            {
                SetItem(1, "t" + (count + firstDay - 1).ToString(CultureInfo.InvariantCulture), count);
            }

            // PB:
            // if theDay > numDaysInMonth or theDay < 1 or isNull(theDay) then theDay = 1
            if (theday > numDaysInMonth || theday < 1)
                theday = 1;

            SetItem(1, "curDay", theday);
            SetItem(1, "month", themonth);
            SetItem(1, "year", theyear);

            this.PostEvent("ue_dateChanged");
        }

        // PB: public function integer daysinmonth (integer themonth, integer theyear)
        public int daysinmonth(int themonth, int theyear)
        {
            int retVal = 0;

            switch (themonth)
            {
                case 1: retVal = 31; break;
                case 2:
                    // PB: if isDate("02/29/" + string(theYear)) then 29 else 28
                    retVal = isDate("02/29/" + theyear.ToString(CultureInfo.InvariantCulture)) ? 29 : 28;
                    break;
                case 3: retVal = 31; break;
                case 4: retVal = 30; break;
                case 5: retVal = 31; break;
                case 6: retVal = 30; break;
                case 7: retVal = 31; break;
                case 8: retVal = 31; break;
                case 9: retVal = 30; break;
                case 10: retVal = 31; break;
                case 11: retVal = 30; break;
                case 12: retVal = 31; break;
            }

            return retVal;
        }

        // =========================
        // PB: event clicked
        // =========================
        public void clicked()
        {
            string status;
            int newDay;

            status = GetObjectAtPointer();

            if (Len(status) > 0)
            {
                status = Left(status, Pos(status, "\t") - 1);
                if (Left(status, 4) != "hora")
                {
                    newDay = (int)GetItemNumber(1, status);
                    if (newDay > 0)
                    {
                        SetItem(1, "curDay", newDay);
                    }
                }
            }

            PostEvent("ue_dateChanged");
        }

        // =========================
        // PB: on itemchanged
        // =========================
        public void itemchanged()
        {
            string status;
            int theDay, theMonth, theYear;

            status = GetText();

            switch (GetColumnName())
            {
                case "month":
                    theDay = (int)GetItemNumber(1, "curDay");
                    theMonth = int.Parse(status, CultureInfo.InvariantCulture);
                    theYear = (int)GetItemNumber(1, "year");
                    setdate(theDay, theMonth, theYear);
                    break;

                case "year":
                    theDay = (int)GetItemNumber(1, "curDay");
                    theMonth = (int)GetItemNumber(1, "month");
                    theYear = int.Parse(status, CultureInfo.InvariantCulture);
                    setdate(theDay, theMonth, theYear);
                    break;
            }
        }

        // ==========================================================
        // Helpers PB-like (locales, SIN cambiar la lógica del PB)
        // ==========================================================

        // PB: reset()
        private void Reset()
        {
            // En tu datawindow no vi Reset(), así que dejo una versión mínima:
            // "vaciar datos" = borrar filas (si existe tabla primaria).
            // Si tu base ya tiene Reset real, podés borrar este método y llamar base.Reset().
            for (int r = RowCount(); r >= 1; r--)
                DeleteRow(r);

            SetRow(0);
        }

        // PB: insertRow(0)
        private int InsertRow(int beforeRowZeroMeansTop)
        {
            // Mínimo: insertar una fila al inicio.
            // Si tu datawindow base ya tiene InsertRow real, reemplazás por base.InsertRow(...)
            EnsurePrimaryTableViaHack();

            if (_primary == null) return -1;

            var dr = _primary.NewRow();
            _primary.Rows.InsertAt(dr, 0);
            SetRow(1);
            return 1;
        }

        // PB: postEvent("ue_dateChanged") / post ue_escape()
        private void PostEvent(string eventName)
        {
            // Mantengo comportamiento PB: "post" = async.
            // Si tenés DynamicEventInvoker.Trigger, podés cambiar a eso.
            if (string.Equals(eventName, "ue_escape", StringComparison.OrdinalIgnoreCase))
            {
                BeginInvokeIfPossible(() => ue_escape?.Invoke());
                return;
            }

            if (string.Equals(eventName, "ue_dateChanged", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(eventName, "ue_datechanged", StringComparison.OrdinalIgnoreCase))
            {
                BeginInvokeIfPossible(On_ue_datechanged);
                return;
            }

            // Si llega otro evento, lo intentamos por reflection sin inventar lógica.
            BeginInvokeIfPossible(() =>
            {
                var mi = GetType().GetMethod(eventName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.IgnoreCase);
                mi?.Invoke(this, null);
            });
        }

        private void BeginInvokeIfPossible(Action action)
        {
            if (Parent is Control c && c.IsHandleCreated)
                c.BeginInvoke(action);
            else
                action();
        }

        // PB: dayNumber(date)  -> lo uso como "día de semana" 1..7 (Lun..Dom)
        // PB original depende de locale; acá emulo simple: Sunday=1, Monday=2... (ajustalo si tu DW espera otro)
        private int dayNumber(DateTime dt)
        {
            // DayOfWeek: Sunday=0..Saturday=6  => 1..7
            return ((int)dt.DayOfWeek) + 1;
        }

        // PB: isDate("02/29/2024")
        private bool isDate(string s)
        {
            // PB interpreta mm/dd/yyyy típicamente
            return DateTime.TryParseExact(
                s,
                new[] { "MM/dd/yyyy", "M/d/yyyy" },
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _);
        }

        // PB: Len/Left/Pos helpers
        private static int Len(string? s) => s?.Length ?? 0;

        private static string Left(string s, int n)
        {
            if (n <= 0) return string.Empty;
            if (n >= s.Length) return s;
            return s.Substring(0, n);
        }

        // PB: Pos(string, find) devuelve 1-based; 0 si no encuentra
        private static int Pos(string s, string find, int start1 = 1)
        {
            if (s == null) return 0;
            int start0 = Math.Max(0, start1 - 1);
            if (start0 >= s.Length) return 0;
            int idx = s.IndexOf(find, start0, StringComparison.Ordinal);
            return idx >= 0 ? idx + 1 : 0;
        }

        // ----------------------------------------------------------
        // Hack mínimo para poder usar InsertRow sin tocar tu datawindow
        // (porque _primary es protected en tu clase).
        // ----------------------------------------------------------
        private void EnsurePrimaryTableViaHack()
        {
            // Esto depende de que en tu datawindow exista EnsurePrimaryTable() protected.
            // Como en tu código lo tenés, lo invoco por reflection para no cambiar base.
            var mi = typeof(datawindow).GetMethod("EnsurePrimaryTable", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            mi?.Invoke(this, null);
        }
    }
}
