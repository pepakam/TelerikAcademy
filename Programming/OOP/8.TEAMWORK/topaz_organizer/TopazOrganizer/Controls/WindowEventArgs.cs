using System;
using System.Linq;
using TopazOrganizer.OrganizerEvents;

namespace TopazOrganizer.Controls
{
    public class WindowEventArgs : EventArgs
    {
        public OrganizerEvent NewEvent { get; set; }

        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EventType;

        public WindowEventArgs(string title, string location, DateTime startTime, DateTime endTime, string type)
        {
            if (type == "Exercise")
            {
                NewEvent = new ExerciseEvent(title, location, startTime, endTime);
            }
            
            this.Title = title;
            this.Location = location;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.EventType = type.ToString();
        }

    }
}