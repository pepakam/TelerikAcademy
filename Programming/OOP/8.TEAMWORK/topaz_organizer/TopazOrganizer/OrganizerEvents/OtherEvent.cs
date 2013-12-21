using System;

namespace TopazOrganizer.OrganizerEvents
{
    class OtherEvent : OrganizerEvent
    {
        public OtherEvent(string title, string location, DateTime start, DateTime end)
            : base(title, location, start, end, OrganizerEventType.Other) { }
    }
}
