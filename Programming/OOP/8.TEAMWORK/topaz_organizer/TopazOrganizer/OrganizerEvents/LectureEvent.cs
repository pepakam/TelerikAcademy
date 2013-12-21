using System;

namespace TopazOrganizer.OrganizerEvents
{
    class LectureEvent : OrganizerEvent
    {
        public LectureEvent(string title, string location, DateTime start, DateTime end)
            : base(title, location, start, end, OrganizerEventType.Lecture)
        {
        }
    }
}
