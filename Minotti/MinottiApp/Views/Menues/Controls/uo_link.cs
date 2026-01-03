using MinottiApp.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minotti.Views.Menues.Controls
{
    // PB: global type uo_link from statictext
    public partial class uo_link : Label
    {
        // ===============================
        // PB constants
        // ===============================
        public const int NONE = 0;
        public const int EXE_FILE = 1;
        public const int OPEN_WINDOW = 2;
        public const int TRIGGER_EVENT = 3;
        public const int POST_EVENT = 4;
        public const int CUSTOM = 5;

        public const int MAX_ACTIONS = 5;

        // ===============================
        // PB variables
        // ===============================
        private string? is_target;
        private FormWindowState iws_state;

        private Form? iw_target;
        private object? ipo_target;
        private string? is_argument;

        private int ii_action = NONE;

        private Color il_color = Color.Blue;
        private Color il_color_clicked = Color.Maroon;

        // PB: event Link (se usa como: lnk_mail.Link += handler)
        public event EventHandler? Link;

        public uo_link()
        {
            InitializeComponent();

            // PB: constructor
            this.ForeColor = il_color;
            this.Cursor = Cursors.Hand;

            this.Click += uo_link_Click;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            // Dispara el evento PB-like
            Link?.Invoke(this, EventArgs.Empty);
        }

        // =====================================================
        // PB event: clicked
        // =====================================================
        private void uo_link_Click(object? sender, EventArgs e)
        {
            if (ii_action == NONE)
                return;

            // This.Post Event link()
            BeginInvoke(new Action(link));
        }

        // =====================================================
        // PB event: link
        // =====================================================
        public virtual void link()
        {
            switch (ii_action)
            {
                case OPEN_WINDOW:
                    if (iw_target != null)
                    {
                        iw_target.WindowState = iws_state;
                        iw_target.Show();
                    }
                    break;

                case EXE_FILE:
                    if (!string.IsNullOrWhiteSpace(is_target))
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = is_target,
                            UseShellExecute = true
                        });
                    break;

                case TRIGGER_EVENT:
                    if (is_argument != null)
                       utils.Message.StringParm = is_argument;

                    DynamicEventInvoker.TriggerEvent(ipo_target!, is_target!);
                    break;

                case POST_EVENT:
                    if (is_argument != null)
                        utils.Message.StringParm = is_argument;

                    DynamicEventInvoker.TriggerEvent(ipo_target!, is_target!);
                    break;
            }

            // This.Post ChangeColor()
            BeginInvoke(new Action(changecolor));
        }

        // =====================================================
        // PB: settext
        // =====================================================
        public void settext(string as_text)
        {
            this.Text = " " + as_text;
        }

        // =====================================================
        // PB: setaction
        // =====================================================
        public int setaction(int ai_action)
        {
            if (ai_action < 0 || ai_action > MAX_ACTIONS)
                return -1;

            ii_action = ai_action;
            return 0;
        }

        // =====================================================
        // PB: setcolor
        // =====================================================
        public void setcolor(long al_color)
        {
            il_color = ColorTranslator.FromOle((int)al_color);
            this.ForeColor = il_color;
        }

        // =====================================================
        // PB: setclickedcolor
        // =====================================================
        public void setclickedcolor(long al_color)
        {
            il_color_clicked = ColorTranslator.FromOle((int)al_color);
        }

        // =====================================================
        // PB: changecolor
        // =====================================================
        public void changecolor()
        {
            this.ForeColor = il_color_clicked;
        }

        // =====================================================
        // PB overloads: setlink
        // =====================================================

        public int setlink(string as_target)
        {
            return setlink(as_target, FormWindowState.Normal);
        }

        public int setlink(string as_target, FormWindowState aws_state)
        {
            if (ii_action == NONE) return -1;
            if (ii_action != EXE_FILE) return -2;
            if (string.IsNullOrWhiteSpace(as_target)) return -3;

            is_target = as_target;
            iws_state = aws_state;
            return 0;
        }

        public int setlink(Form aw_window, string as_type)
        {
            if (ii_action == NONE) return -1;
            if (ii_action != OPEN_WINDOW) return -2;
            if (string.IsNullOrWhiteSpace(as_type)) return -3;

            iw_target = aw_window;
            is_target = as_type;
            return 0;
        }

        public int setlink(object apo_target, string as_event)
        {
            if (ii_action == NONE) return -1;
            if (ii_action != TRIGGER_EVENT && ii_action != POST_EVENT) return -2;
            if (string.IsNullOrWhiteSpace(as_event)) return -3;
            if (apo_target == null) return -4;

            ipo_target = apo_target;
            is_target = as_event;
            is_argument = null;
            return 0;
        }

        public int setlink(object apo_target, string as_event, string as_argument)
        {
            if (ii_action == NONE) return -1;
            if (ii_action != TRIGGER_EVENT && ii_action != POST_EVENT) return -2;
            if (string.IsNullOrWhiteSpace(as_event)) return -3;
            if (apo_target == null) return -4;

            ipo_target = apo_target;
            is_target = as_event;
            is_argument = as_argument;
            return 0;
        }
         
    }
}
