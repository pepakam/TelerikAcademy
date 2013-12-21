using System;

namespace TopazOrganizer.OrganizerEvents
{
    public sealed class OrganizerEventFactory
    {
        public static OrganizerEvent CreateOrganizerEvent(OrganizerEventType type, string title, string location, DateTime start, DateTime end, bool allDay, params string[] otherFields)
        {
            OrganizerEvent newEvent = null;
            switch (type)
            { 
                case OrganizerEventType.Meeting:
                    newEvent = new MeetingEvent(title, location, start, end);
                    break;
                case OrganizerEventType.Lecture:
                    newEvent = new LectureEvent(title, location, start, end);
                    break;
                case OrganizerEventType.Exercise:
                    newEvent = new ExerciseEvent(title, location, start, end);
                    break;
                case OrganizerEventType.Deadline:
                    newEvent = new DeadlineEvent(title, location, start, end);
                    break;
                case OrganizerEventType.Other:
                    newEvent = new OtherEvent(title, location, start, end);
                    break;
            }
            return newEvent;
        }
    }
}
