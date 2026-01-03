using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Minotti.UserObjects
{
    public partial class uo_link : LinkLabel
    {
        public const int NONE = 0;
        public const int EXE_FILE = 1;
        public const int OPEN_WINDOW = 2;
        public const int TRIGGER_EVENT = 3;
        public const int POST_EVENT = 4;
        public const int CUSTOM = 5;
        public const int MAX_ACTIONS = 5;

        private string? is_target;
        private Form? iw_target;
        private object? ipo_target;
        private string? is_argument;
        private FormWindowState iws_state = FormWindowState.Normal;
        private int ii_action = NONE;

        private Color il_color = Color.FromArgb(0, 0, 255);      // RGB(0,0,255)
        private Color il_color_clicked = Color.FromArgb(128, 0, 0); // RGB(128,0,0)

        public event EventHandler? link; // evento PB

        public uo_link()
        {
            InitializeComponent();
            this.LinkBehavior = LinkBehavior.AlwaysUnderline;
            this.LinkColor = il_color;
            this.VisitedLinkColor = il_color_clicked;
            this.ActiveLinkColor = il_color;
            this.Text = " none"; // espacio inicial como en PB
            this.AutoSize = true;
            this.Click += OnLinkClickedInternal;
        }

        private void OnLinkClickedInternal(object? sender, EventArgs e)
        {
            try { DoAction(); } catch { }
            link?.Invoke(this, EventArgs.Empty);
        }

        private void DoAction()
        {
            switch (ii_action)
            {
                case NONE:
                    return;

                case EXE_FILE:
                    if (string.IsNullOrWhiteSpace(is_target)) return;
                    var psi = new ProcessStartInfo
                    {
                        FileName = is_target!,
                        UseShellExecute = true,
                        WindowStyle = iws_state switch
                        {
                            FormWindowState.Minimized => ProcessWindowStyle.Minimized,
                            FormWindowState.Maximized => ProcessWindowStyle.Maximized,
                            _ => ProcessWindowStyle.Normal
                        }
                    };
                    try { Process.Start(psi); } catch { }
                    this.LinkVisited = true;
                    break;

                case OPEN_WINDOW:
                    if (iw_target == null) return;
                    if (string.Equals(is_target, "modal", StringComparison.OrdinalIgnoreCase))
                        try { iw_target.ShowDialog(FindForm()); } catch { }
                    else
                        try { iw_target.Show(); } catch { }
                    this.LinkVisited = true;
                    break;

                case TRIGGER_EVENT:
                case POST_EVENT:
                    if (ipo_target == null || string.IsNullOrWhiteSpace(is_target)) return;
                    var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase;
                    var mi = ipo_target.GetType().GetMethod(is_target!, flags);
                    if (mi != null)
                    {
                        var pars = mi.GetParameters();
                        object?[] args = pars.Length switch
                        {
                            0 => Array.Empty<object?>(),
                            1 => new object?[] { is_argument },
                            _ => new object?[] { is_argument }
                        };

                        if (ii_action == POST_EVENT)
                            BeginInvoke(new Action(() => { try { mi.Invoke(ipo_target, args); } catch { } }));
                        else
                            try { mi.Invoke(ipo_target, args); } catch { }

                        this.LinkVisited = true;
                    }
                    break;

                case CUSTOM:
                    this.LinkVisited = true;
                    break;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int setaction(int ai_action)
        {
            if (ai_action < 0 || ai_action > MAX_ACTIONS) return -1;
            ii_action = ai_action;
            return 0;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int setlink(string as_target)
            => setlink(as_target, FormWindowState.Normal);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int setlink(string as_target, FormWindowState aws_state)
        {
            if (ii_action == NONE) return -1;
            if (ii_action != EXE_FILE) return -2;
            if (string.IsNullOrWhiteSpace(as_target)) return -3;

            is_target = as_target;
            iws_state = aws_state;
            return 0;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int setlink(Form aw_window, string as_type)
        {
            if (ii_action == NONE) return -1;
            if (ii_action != OPEN_WINDOW) return -2;
            if (string.IsNullOrWhiteSpace(as_type)) return -3;

            iw_target = aw_window;
            is_target = as_type; // "modal" -> Dialog, otro -> Show
            return 0;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int setlink(object apo_target, string as_event)
        {
            if (ii_action == NONE) return -1;
            if (ii_action != TRIGGER_EVENT && ii_action != POST_EVENT) return -2;
            if (string.IsNullOrWhiteSpace(as_event)) return -3;
            if (apo_target is null) return -4;

            ipo_target = apo_target;
            is_target = as_event;
            is_argument = null;
            return 0;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int setlink(object apo_target, string as_event, string as_argument)
        {
            if (ii_action == NONE) return -1;
            if (ii_action != TRIGGER_EVENT && ii_action != POST_EVENT) return -2;
            if (string.IsNullOrWhiteSpace(as_event)) return -3;
            if (apo_target is null) return -4;

            ipo_target = apo_target;
            is_target = as_event;
            is_argument = as_argument;
            return 0;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void settext(string as_text)
        {
            this.Text = " " + (as_text ?? string.Empty);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void setcolor(long al_color)
        {
            var c = FromPBColor(al_color);
            il_color = c;
            this.LinkColor = c;
            this.ActiveLinkColor = c;
            if (!this.LinkVisited) this.ForeColor = c;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void setclickedcolor(long al_color)
        {
            var c = FromPBColor(al_color);
            il_color_clicked = c;
            this.VisitedLinkColor = c;
            if (this.LinkVisited) this.ForeColor = c;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void changecolor()
        {
            this.LinkVisited = !this.LinkVisited;
            this.ForeColor = this.LinkVisited ? this.VisitedLinkColor : this.LinkColor;
        }

        private static Color FromPBColor(long pbColor)
        {
            int r = (int)(pbColor & 0xFF);
            int g = (int)((pbColor >> 8) & 0xFF);
            int b = (int)((pbColor >> 16) & 0xFF);
            return Color.FromArgb(r, g, b);
        }
    }
}
