using System;
using System.Collections.Generic;
using TopazOrganizer.OrganizerEvents;

namespace TopazOrganizer.Dispatchers
{
    interface IEventControlDispatcher
    {
        event EventHandler EventControlClick;

        void AddEventControl(OrganizerEvent eventToBeDisplayed);

        void RemoveEventControl(OrganizerEvent eventBeingDisplayed);
     
        void RefreshEventControlsFrom(IEnumerable<OrganizerEvent> organizerEvents, DateTime weekOnFocusStart, DateTime weekOnFocusEnd);

        void ResizeControls();
    }
}
