using System;

namespace TopazOrganizer.OrganizerEvents
{
    interface INotifyEventDataChanged
    {
        event EventHandler EventAdded;
        event EventHandler EventRemoved;
        event EventHandler DataRefreshed;
    }
}
