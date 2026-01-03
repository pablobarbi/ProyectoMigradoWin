using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.UserObjects
{
    partial class dw_calendar
    {
        private IContainer components;
        private System.Windows.Forms.Timer timer1;

        private ComboBox month;
        private TextBox year;
        private Label hora_t;
        private Label hora;
        private Label t_1;
        private Label thedate;

        private TableLayoutPanel grid;

        private TextBox t1, t2, t3, t4, t5, t6, t7,
                        t8, t9, t10, t11, t12, t13, t14,
                        t15, t16, t17, t18, t19, t20, t21,
                        t22, t23, t24, t25, t26, t27, t28,
                        t29, t30, t31, t32, t33, t34, t35,
                        t36, t37, t38, t39, t40, t41, t42;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            timer1 = new System.Windows.Forms.Timer(components) { Interval = 1000 };

            hora_t = new Label { Text = "Hora Actual:", AutoSize = true };
            hora = new Label { Text = "00:00", AutoSize = true };
            t_1 = new Label { Text = "D   L   M   M   J   V   S", TextAlign = ContentAlignment.MiddleCenter };
            thedate = new Label { AutoSize = true };

            month = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            year = new TextBox();

            grid = new TableLayoutPanel
            {
                ColumnCount = 7,
                RowCount = 6,
                Dock = DockStyle.None,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            for (int i = 0; i < 7; i++)
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            for (int i = 0; i < 6; i++)
                grid.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));

            t1 = NewCell(); t2 = NewCell(); t3 = NewCell(); t4 = NewCell(); t5 = NewCell(); t6 = NewCell(); t7 = NewCell();
            t8 = NewCell(); t9 = NewCell(); t10 = NewCell(); t11 = NewCell(); t12 = NewCell(); t13 = NewCell(); t14 = NewCell();
            t15 = NewCell(); t16 = NewCell(); t17 = NewCell(); t18 = NewCell(); t19 = NewCell(); t20 = NewCell(); t21 = NewCell();
            t22 = NewCell(); t23 = NewCell(); t24 = NewCell(); t25 = NewCell(); t26 = NewCell(); t27 = NewCell(); t28 = NewCell();
            t29 = NewCell(); t30 = NewCell(); t31 = NewCell(); t32 = NewCell(); t33 = NewCell(); t34 = NewCell(); t35 = NewCell();
            t36 = NewCell(); t37 = NewCell(); t38 = NewCell(); t39 = NewCell(); t40 = NewCell(); t41 = NewCell(); t42 = NewCell();

            TextBox[] all =
            {
                t1,t2,t3,t4,t5,t6,t7,
                t8,t9,t10,t11,t12,t13,t14,
                t15,t16,t17,t18,t19,t20,t21,
                t22,t23,t24,t25,t26,t27,t28,
                t29,t30,t31,t32,t33,t34,t35,
                t36,t37,t38,t39,t40,t41,t42
            };

            int idx = 0;
            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 7; c++)
                    grid.Controls.Add(all[idx++], c, r);

            Controls.Add(hora_t);
            Controls.Add(hora);
            Controls.Add(month);
            Controls.Add(year);
            Controls.Add(t_1);
            Controls.Add(grid);
            Controls.Add(thedate);

            Name = "dw_calendar";
            Size = new System.Drawing.Size(580, 450);
        }

        private TextBox NewCell()
        {
            return new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Center,
                ReadOnly = true,
                Enabled = false,
                BorderStyle = BorderStyle.FixedSingle,
                TabStop = false
            };
        }
    }
}
