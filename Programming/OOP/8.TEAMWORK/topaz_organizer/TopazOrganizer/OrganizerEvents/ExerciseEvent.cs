using System;

namespace TopazOrganizer.OrganizerEvents
{
    class ExerciseEvent : OrganizerEvent
    {
        public ExerciseEvent(string title, string location, DateTime start, DateTime end)
            : base(title, location, start, end, OrganizerEventType.Exercise)
        {
        }
    }
}
