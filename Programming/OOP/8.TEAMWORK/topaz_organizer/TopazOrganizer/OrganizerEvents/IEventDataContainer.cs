using System;
using System.Collections.Generic;

namespace TopazOrganizer.OrganizerEvents
{
    public interface IEventDataContainer
    {
        event EventHandler EventAdded;
        event EventHandler EventRemoved;
        event EventHandler DataRefreshed;

        IEnumerable<OrganizerEvent> Items { get; }

        void Add(OrganizerEvent newEvent);
        void Remove(OrganizerEvent eventToBeRemoved);

        void OnEventAdded(DataChangedEventArgs data);
        void OnEventChanged(DataChangedEventArgs data);
        void OnDataRefreshed();

        IEnumerable<OrganizerEvent> GetEventsStartingBetween(DateTime startDay, DateTime lastDay);
    }
}
