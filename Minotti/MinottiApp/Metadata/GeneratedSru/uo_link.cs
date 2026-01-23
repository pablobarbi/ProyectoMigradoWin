// -----------------------------------------------------------------------------
// AUTO-MIGRADO desde PowerBuilder (.sru)
// Origen: uo_link
// -----------------------------------------------------------------------------

#nullable enable
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;


namespace Minotti.Metadata.GeneratedSru
{
    /// <summary>
    /// PB: uo_link
    /// HiperLink object.
    /// </summary>
    public class uo_link : label
    {
        // ---------------------------------------------------------------------
        // CONSTANTES (type variables)
        // ---------------------------------------------------------------------

        // link action type
        public const int NONE = 0;
        public const int EXE_FILE = 1;
        public const int OPEN_WINDOW = 2;
        public const int TRIGGER_EVENT = 3;
        public const int POST_EVENT = 4;
        public const int CUSTOM = 5;

        public const int MAX_ACTIONS = 5;

        // ---------------------------------------------------------------------
        // VARIABLES
        // ---------------------------------------------------------------------

        protected string? is_target;
        protected windowstate iws_state;

        protected window? iw_target;

        protected powerobject? ipo_target;
        protected string? is_argument;

        protected int ii_action = NONE;

        protected long il_color = RGB(0, 0, 255);
        protected long il_color_clicked = RGB(128, 0, 0);

        // ---------------------------------------------------------------------
        // EVENT: link
        // ---------------------------------------------------------------------
        public virtual void link()
        {
            /*
             * Performs preconfigured action.
             * If action is CUSTOM, this event must be overloaded (but not overwritten)
             */

            switch (ii_action)
            {
                case OPEN_WINDOW:
                    Open(iw_target, is_target);
                    break;

                case EXE_FILE:
                    Run(is_target, iws_state);
                    break;

                case TRIGGER_EVENT:
                    if (!IsNull(is_argument))
                    {
                        message.StringParm = is_argument;
                    }
                    ipo_target?.TriggerEvent(is_target);
                    break;

                case POST_EVENT:
                    if (!IsNull(is_argument))
                    {
                        message.StringParm = is_argument;
                    }
                    ipo_target?.PostEvent(is_target);
                    break;
            }

            this.Post(ChangeColor);
            return;
        }

        // ---------------------------------------------------------------------
        // settext
        // ---------------------------------------------------------------------
        public void settext(string as_text)
        {
            this.Text = " " + as_text;
        }

        // ---------------------------------------------------------------------
        // setlink (string)
        // ---------------------------------------------------------------------
        public int setlink(string as_target)
        {
            return this.setlink(as_target, windowstate.Normal);
        }

        // ---------------------------------------------------------------------
        // setaction
        // ---------------------------------------------------------------------
        public int setaction(int ai_action)
        {
            if (ai_action < 0 || ai_action > MAX_ACTIONS)
                return -1;

            ii_action = ai_action;
            return 0;
        }

        // ---------------------------------------------------------------------
        // setcolor
        // ---------------------------------------------------------------------
        public void setcolor(long al_color)
        {
            this.il_color = al_color;
            this.TextColor = il_color;
        }

        // ---------------------------------------------------------------------
        // setlink (string, windowstate)
        // ---------------------------------------------------------------------
        public int setlink(string as_target, windowstate aws_state)
        {
            if (ii_action == NONE) return -1;
            if (ii_action != EXE_FILE) return -2;
            if (IsNull(as_target) || Trim(as_target) == "" || IsNull(aws_state)) return -3;

            is_target = as_target;
            iws_state = aws_state;
            return 0;
        }

        // ---------------------------------------------------------------------
        // setlink (window, string)
        // ---------------------------------------------------------------------
        public int setlink(window aw_window, string as_type)
        {
            if (ii_action == NONE) return -1;
            if (ii_action != OPEN_WINDOW) return -2;
            if (IsNull(as_type) || as_type == "") return -3;

            iw_target = aw_window;
            is_target = as_type;
            return 0;
        }

        // ---------------------------------------------------------------------
        // setclickedcolor
        // ---------------------------------------------------------------------
        public void setclickedcolor(long al_color)
        {
            il_color_clicked = al_color;
        }

        // ---------------------------------------------------------------------
        // changecolor
        // ---------------------------------------------------------------------
        public void ChangeColor()
        {
            this.TextColor = il_color_clicked;
        }

        // ---------------------------------------------------------------------
        // setlink (powerobject, event)
        // ---------------------------------------------------------------------
        public int setlink(powerobject apo_target, string as_event)
        {
            if (ii_action == NONE) return -1;
            if (ii_action != TRIGGER_EVENT && ii_action != POST_EVENT) return -2;
            if (IsNull(as_event) || Trim(as_event) == "") return -3;
            if (IsNull(apo_target) || !IsValid(apo_target)) return -4;

            ipo_target = apo_target;
            is_target = as_event;
            SetNull(ref is_argument);
            return 0;
        }

        // ---------------------------------------------------------------------
        // setlink (powerobject, event, argument)
        // ---------------------------------------------------------------------
        public int setlink(powerobject apo_target, string as_event, string as_argument)
        {
            if (ii_action == NONE) return -1;
            if (ii_action != TRIGGER_EVENT && ii_action != POST_EVENT) return -2;
            if (IsNull(as_event) || Trim(as_event) == "") return -3;
            if (IsNull(apo_target) || !IsValid(apo_target)) return -4;

            ipo_target = apo_target;
            is_target = as_event;
            is_argument = as_argument;
            return 0;
        }

        // ---------------------------------------------------------------------
        // EVENT: clicked
        // ---------------------------------------------------------------------
        public override void clicked()
        {
            if (ii_action == NONE) return;

            this.Post(link);
            return;
        }

        // ---------------------------------------------------------------------
        // EVENT: constructor
        // ---------------------------------------------------------------------
        public override void constructor()
        {
            this.TextColor = il_color;
        }
    }
}
