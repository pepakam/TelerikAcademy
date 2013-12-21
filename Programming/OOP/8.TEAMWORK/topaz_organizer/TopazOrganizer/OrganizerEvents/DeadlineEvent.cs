using System;
using System.Linq;

namespace TopazOrganizer.OrganizerEvents
{
    class DeadlineEvent : OrganizerEvent
    {
        public DeadlineEvent(string title, string location, DateTime start, DateTime end)
            : base(title, location, start, end, OrganizerEventType.Deadline)
        {
        }
    }
}
