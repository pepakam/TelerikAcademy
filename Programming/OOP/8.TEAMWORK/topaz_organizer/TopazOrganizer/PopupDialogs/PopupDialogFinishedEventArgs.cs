using System;
using TopazOrganizer.Controls;
using TopazOrganizer.OrganizerEvents;

namespace TopazOrganizer.PopupDialogs
{
    public class PopupDialogFinishedEventArgs : EventArgs
    {
        public OrganizerEvent TargetEvent { get; private set; }

        public EventControl TargetControl { get; private set; }

        public PopupDialogFinishedEventArgs()
            : this(null, null) { }

        public PopupDialogFinishedEventArgs(OrganizerEvent targetEvent, EventControl targetControl)
        {
            this.TargetEvent = targetEvent;
            this.TargetControl = targetControl;
        }
    }
}
