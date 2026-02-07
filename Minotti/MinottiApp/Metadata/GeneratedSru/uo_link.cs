using Minotti.utils;
using System.ComponentModel;
using System.Diagnostics;

namespace MinottiApp.Metadata.GeneratedSru
{
    public partial class uo_link : LinkLabel, IPowerObject
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
        private IPowerObject? ipo_target;
        private string? is_argument;
        private FormWindowState iws_state = FormWindowState.Normal;
        private int ii_action = NONE;

        private Color il_color = Color.FromArgb(0, 0, 255);
        private Color il_color_clicked = Color.FromArgb(128, 0, 0);

        // Evento PB
        public event EventHandler? link;

        public uo_link()
        {
            LinkBehavior = LinkBehavior.AlwaysUnderline;
            LinkColor = il_color;
            VisitedLinkColor = il_color_clicked;
            ActiveLinkColor = il_color;
            Text = " none"; // espacio inicial como en PB
            AutoSize = true;

            Click += OnLinkClickedInternal;
        }

        private void OnLinkClickedInternal(object? sender, EventArgs e)
        {
            try
            {
                DoAction();
            }
            catch
            {
                // PB style: swallow
            }

            link?.Invoke(this, EventArgs.Empty);
        }

        private void DoAction()
        {
            switch (ii_action)
            {
                case NONE:
                    return;

                case EXE_FILE:
                    ExecuteFile();
                    break;

                case OPEN_WINDOW:
                    OpenWindow();
                    break;

                case TRIGGER_EVENT:
                    ipo_target?.TriggerEvent(is_target!, is_argument);
                    LinkVisited = true;
                    break;

                case POST_EVENT:
                    ipo_target?.PostEvent(is_target!, is_argument);
                    LinkVisited = true;
                    break;

                case CUSTOM:
                    LinkVisited = true;
                    break;
            }
        }

        private void ExecuteFile()
        {
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

            LinkVisited = true;
        }

        private void OpenWindow()
        {
            if (iw_target == null) return;

            try
            {
                if (string.Equals(is_target, "modal", StringComparison.OrdinalIgnoreCase))
                    iw_target.ShowDialog(FindForm());
                else
                    iw_target.Show();
            }
            catch { }

            LinkVisited = true;
        }

        // ---------------------------------------------------------------------
        // API PB
        // ---------------------------------------------------------------------

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
            is_target = as_type;
            return 0;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int setlink(IPowerObject apo_target, string as_event)
        {
            return setlink(apo_target, as_event, null);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int setlink(IPowerObject apo_target, string as_event, string? as_argument)
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
            Text = " " + (as_text ?? string.Empty);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void setcolor(long al_color)
        {
            var c = FromPBColor(al_color);
            il_color = c;
            LinkColor = c;
            ActiveLinkColor = c;
            if (!LinkVisited) ForeColor = c;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void setclickedcolor(long al_color)
        {
            var c = FromPBColor(al_color);
            il_color_clicked = c;
            VisitedLinkColor = c;
            if (LinkVisited) ForeColor = c;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void changecolor()
        {
            LinkVisited = !LinkVisited;
            ForeColor = LinkVisited ? VisitedLinkColor : LinkColor;
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
