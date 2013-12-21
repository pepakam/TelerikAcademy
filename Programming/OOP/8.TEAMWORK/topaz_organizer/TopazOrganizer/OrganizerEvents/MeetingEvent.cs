using System;

namespace TopazOrganizer.OrganizerEvents
{
    class MeetingEvent:OrganizerEvent
    {
        public MeetingEvent(string title, string location, DateTime start, DateTime end)
            : base(title, location, start, end, OrganizerEventType.Meeting) { }
    }
}
