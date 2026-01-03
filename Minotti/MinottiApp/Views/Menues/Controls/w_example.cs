using Minotti.Views.Menues.Controls;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Minotti.Views.Menues.Controls
{
    /// <summary>
    /// Migración de PowerBuilder: w_example.srw
    /// Controles portados 1:1 (nombres PB): lnk_1..lnk_7, lnk_mail, st_3, st_4, st_5, st_7, gb_2..gb_6, cb_1, cb_2.
    /// </summary>
    public partial class w_example : Form
    {
        // === PB variables ===
        private c_class ic_class;

        public w_example()
        {
            InitializeComponent();
            this.Load += w_example_Load;
        }

        private void w_example_Load(object? sender, EventArgs e)
        {
            F_Window_Center(this);
        }

        // === PB: F_Window_Center(This) ===
        private static void F_Window_Center(Form f)
        {
            f.StartPosition = FormStartPosition.CenterScreen;
        }

        // === ShellExecuteA (PB prototype) ===
        [DllImport("shell32.dll", CharSet = CharSet.Ansi)]
        private static extern long ShellExecuteA(
            long hwnd,
            string lpOperation,
            string lpFile,
            string lpParameters,
            string lpDirectory,
            int nShowCmd
        );

        // ===================== EVENTS =====================

        private void cb_1_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_2_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "This application shows the use of the uo_link object.\r\n" +
                "This object provides a basic functionality to simulate a link like any web browser.\r\n\r\n" +
                "There are four standard actions supported:\r\n" +
                "· OPEN_WINDOW\r\n" +
                "· EXE_FILE\r\n" +
                "· TRIGGER_EVENT\r\n" +
                "· POST_EVENT\r\n\r\n" +
                "Source by JoseMan.",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void lnk_mail_Link(object? sender, EventArgs e)
        {
            const int SW_SHOWNORMAL = 1;
            ShellExecuteA(this.Handle.ToInt64(), "open",
                "mailto:jose.man@airtel.net", "", "", SW_SHOWNORMAL);
        }
    }
}
