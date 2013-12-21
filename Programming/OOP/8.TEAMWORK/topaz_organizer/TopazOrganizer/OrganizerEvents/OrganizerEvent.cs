using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TopazOrganizer.OrganizerEvents
{
    /// <summary>
    /// Base class for all other [...]Event classes, INotifyPropertyChanged is implementented in order to binding functionality.
    /// </summary>
    public abstract class OrganizerEvent : INotifyPropertyChanged
    {
        #region Constants
        public const double MinimalDurationInMinutes = 1.0d;
        #endregion

        #region Fields
        string title;
        string location;
        DateTime start;
        DateTime end;
       
        TimeSpan duration;
        bool allDay;
        readonly OrganizerEventType eventType;
        string startEndString;
        #endregion

        #region Properties
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(this, "Title");
            }
        }
        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged(this, "Location");
            }
        }
        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                if ((value - start).TotalMinutes < MinimalDurationInMinutes)
                {
                    throw new ArgumentException(string.Format("Invalid End value. Event duration should be at least {0} minutes.",
                        MinimalDurationInMinutes));
                }
                end = value;
                Duration = end - start;
                StartEndString = string.Format("{0}-{1}", start.ToString("HH:mm"), end.ToString("HH:mm"));
                OnPropertyChanged(this, "End");
            }
        }
        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                if ((end - value).TotalMinutes < MinimalDurationInMinutes)
                {
                    throw new ArgumentException(string.Format("Invalid Start value. Event duration should be at least {0} minutes.",
                        MinimalDurationInMinutes));
                }
                start = value;
                Duration = end - start;
                StartEndString = string.Format("{0}-{1}", start.ToString("HH:mm"), end.ToString("HH:mm"));
                OnPropertyChanged(this, "Start");
            }
        }

        public TimeSpan Duration
        {
            get { return duration; }
            private set
            {
                duration = value;
                OnPropertyChanged(this, "Duration");
            }
        }
        public bool AllDay
        {
            get { return allDay; }
            set
            {
                allDay = value;
                OnPropertyChanged(this, "AllDay");
            }
        }
        public OrganizerEventType EventType
        {
            get { return eventType; }
        }
        public string StartEndString
        {
            get { return startEndString; }
            private set
            {
                startEndString = value;
                OnPropertyChanged(this, "StartEndString");
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        protected OrganizerEvent(string title, string location, DateTime start, DateTime end, OrganizerEventType type)
        {
            if (end < start)
            {
                MessageBox.Show("Event start should always be before its end.");

                // throw new ArgumentException("Event start should always be before its end.");
            }

            this.Title = title;
            this.Location = location;
            this.eventType = type;
            this.End = end;
            this.Start = start;


        }

        public override string ToString()
        {
            return string.Format("Title: {0}\nLocation: {1}\nStart time: {2}\nEnd time: {3}\nEventType: {4}", this.Title, this.Location, this.Start, this.End, this.EventType);
        }

        private void OnPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
