using System;
using System.Globalization;
using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    /// <summary>
    /// PB:
    /// $PBExportHeader$uo_calendar.sru
    /// A 3D calendar object
    /// </summary>
    public class uo_calendar : uo_dw
    {
        // ============================
        // PB: propiedades del DataWindow
        // ============================
        public uo_calendar()
        {
            // Posición / tamaño
            this.Top = 472;
            this.Width = 471;
            this.Height = 456;
            this.TabIndex = 20;

            // DataObject
            this.uof_setdataobject("dw_calendar");

            // Flags
            this.BorderStyle = false;
            this.LiveScroll = true;

            // PB: constructor
            constructor();
        }

        // ============================
        // EVENTS
        // ============================

        /// <summary>
        /// PB: event ue_datechanged
        /// </summary>
        protected virtual void ue_datechanged()
        {
            this.AcceptText();
        }

        /// <summary>
        /// PB: key event
        /// </summary>
        protected virtual void key(int key)
        {
            if (key == KeyCodes.KeyEscape)
            {
                // PB: Event post ue_escape()
                this.PostEvent(nameof(ue_escape));
            }
        }

        /// <summary>
        /// PB: event ue_escape
        /// </summary>
        protected virtual void ue_escape()
        {
        }

        /// <summary>
        /// PB: event clicked
        /// </summary>
        protected virtual void clicked()
        {
            string status;
            int newDay;

            status = this.GetObjectAtPointer();

            if (status.Length > 0)
            {
                status = status.Substring(0, status.IndexOf('\t'));
                if (status.Substring(0, 4) != "hora")
                {
                    newDay = this.GetItemNumber(1, status);
                    if (!IsNull(newDay) && newDay > 0)
                    {
                        this.SetItem(1, "curDay", newDay);
                    }
                }
            }

            this.PostEvent(nameof(ue_datechanged));
        }

        /// <summary>
        /// PB: itemchanged
        /// </summary>
        protected virtual void itemchanged()
        {
            string status;
            int theDay, theMonth, theYear;

            status = this.GetText();

            switch (this.GetColumnName())
            {
                case "month":
                    theDay = this.GetItemNumber(1, "curDay");
                    theMonth = int.Parse(status, CultureInfo.InvariantCulture);
                    theYear = this.GetItemNumber(1, "year");

                    setdate(theDay, theMonth, theYear);
                    break;

                case "year":
                    theDay = this.GetItemNumber(1, "curDay");
                    theMonth = this.GetItemNumber(1, "month");
                    theYear = int.Parse(status, CultureInfo.InvariantCulture);

                    setdate(theDay, theMonth, theYear);
                    break;
            }
        }

        // ============================
        // PUBLIC FUNCTIONS / SUBROUTINES
        // ============================

        public DateTime getdate()
        {
            return new DateTime(
                this.GetItemNumber(1, "year"),
                this.GetItemNumber(1, "month"),
                this.GetItemNumber(1, "curDay")
            );
        }

        public void setmonth(int themonth, int theyear)
        {
            DateTime startOfMonth;
            int firstDay, count, numDaysInMonth;

            this.Reset();
            this.InsertRow(0);

            startOfMonth = new DateTime(theyear, themonth, 1);
            firstDay = DayNumber(startOfMonth);
            numDaysInMonth = daysinmonth(themonth, theyear);

            for (count = 1; count <= numDaysInMonth; count++)
            {
                this.SetItem(1, "t" + (count + firstDay - 1), count);
            }

            this.SetItem(1, "curDay", 1);
            this.SetItem(1, "month", themonth);
            this.SetItem(1, "year", theyear);

            this.PostEvent(nameof(ue_datechanged));
        }

        public void setdate(int theday, int themonth, int theyear)
        {
            DateTime startOfMonth;
            int firstDay, count, numDaysInMonth;

            this.Reset();
            this.InsertRow(0);

            startOfMonth = new DateTime(theyear, themonth, 1);
            firstDay = DayNumber(startOfMonth);
            numDaysInMonth = daysinmonth(themonth, theyear);

            for (count = 1; count <= numDaysInMonth; count++)
            {
                this.SetItem(1, "t" + (count + firstDay - 1), count);
            }

            if (theday > numDaysInMonth || theday < 1 || IsNull(theday))
            {
                theday = 1;
            }

            this.SetItem(1, "curDay", theday);
            this.SetItem(1, "month", themonth);
            this.SetItem(1, "year", theyear);

            this.PostEvent(nameof(ue_datechanged));
        }

        public int daysinmonth(int themonth, int theyear)
        {
            int retVal = 0;

            switch (themonth)
            {
                case 1: retVal = 31; break;
                case 2:
                    retVal = DateTime.IsLeapYear(theyear) ? 29 : 28;
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

        // ============================
        // PB: constructor event
        // ============================
        protected virtual void constructor()
        {
            setdate(
                DateTime.Today.Day,
                DateTime.Today.Month,
                DateTime.Today.Year
            );
        }
    }
}
