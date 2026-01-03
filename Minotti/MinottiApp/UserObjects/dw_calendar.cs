using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Drawing; 
using System.Windows.Forms;
 

namespace Minotti.UserObjects
{
    /// <summary>
    /// Migración de PowerBuilder: uo_calendar.sru (desde datawindow).
    /// UserControl WinForms manteniendo el nombre de clase: uo_calendar.
    /// Eventos PB mapeados: ue_datechanged, pbm_keyup, ue_escape.
    /// Métodos: setDate(int day,int month,int year), getDate(), getItemNumber(int row,string column).
    /// Variables: theDay, theMonth, theYear.
    /// </summary>
    public partial class dw_calendar : UserControl
    {
        private int curday;

        public dw_calendar()
        {
            InitializeComponent();

            // values del DataWindow
            month.Items.AddRange(new object[]
            {
                "Enero","Febrero","Marzo","Abril","Mayo","Junio",
                "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"
            });

            var now = DateTime.Now;

            curday = now.Day;
            year.Text = now.Year.ToString("0000");
            month.SelectedIndex = now.Month - 1;

            month.SelectedIndexChanged += (_, __) => BuildCalendar();
            year.TextChanged += (_, __) => BuildCalendar();

            timer1.Tick += (_, __) => RefreshHora();
            timer1.Start();

            RefreshHora();
            BuildCalendar();
        }

        private void RefreshHora()
        {
            var now = DateTime.Now;

            // compute hora
            hora.Text = now.ToString("HH:mm");

            // compute thedate
            thedate.Text = now.ToString("g");
        }

        private void BuildCalendar()
        {
            if (month.SelectedIndex < 0) return;
            if (!int.TryParse(year.Text, out int y)) return;

            int m = month.SelectedIndex + 1;
            DateTime first = new DateTime(y, m, 1);
            int daysInMonth = DateTime.DaysInMonth(y, m);

            TextBox[] cells = GetCells();

            // limpiar
            foreach (var c in cells)
            {
                c.Text = "";
                c.Enabled = false;
                c.ReadOnly = true;
                c.BackColor = SystemColors.Control;
                c.Font = new Font(c.Font, FontStyle.Regular);
            }

            int start = (int)first.DayOfWeek; // Domingo = 0
            int idx = start;

            for (int d = 1; d <= daysInMonth; d++)
            {
                if (idx >= cells.Length) break;

                var tb = cells[idx];
                tb.Text = d.ToString();
                tb.Enabled = true;
                tb.ReadOnly = false;

                // background.color del DW
                tb.BackColor = Color.FromArgb(224, 224, 224);

                // border logic (tif(tX = curday))
                if (d == curday &&
                    DateTime.Now.Month == m &&
                    DateTime.Now.Year == y)
                {
                    tb.BackColor = Color.White;
                    tb.Font = new Font(tb.Font, FontStyle.Bold);
                }

                idx++;
            }
        }

        private TextBox[] GetCells()
        {
            return new[]
            {
                t1,t2,t3,t4,t5,t6,t7,
                t8,t9,t10,t11,t12,t13,t14,
                t15,t16,t17,t18,t19,t20,t21,
                t22,t23,t24,t25,t26,t27,t28,
                t29,t30,t31,t32,t33,t34,t35,
                t36,t37,t38,t39,t40,t41,t42
            };
        }
    }
}
