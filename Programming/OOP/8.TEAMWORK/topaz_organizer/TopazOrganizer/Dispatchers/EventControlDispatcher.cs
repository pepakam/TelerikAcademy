using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TopazOrganizer.Controls;
using TopazOrganizer.OrganizerEvents;
using TopazOrganizer.OrganizerExceptions;

namespace TopazOrganizer.Dispatchers
{
    public class EventControlDispatcher:IEventControlDispatcher
    {
        #region Constants
        //Date constants
        const int WeekInDays = 7;
        const double HourAsMinutes = 60.0d;
        const double DayAsMinutes = 1440.0d;    
        #endregion

        #region Fileds
        readonly List<EventControl> eventControls;
        readonly WeekGridControl attachedWeekGrid;
        readonly EventViewModelDispatcher masterDispatcher;

        DateTime weekOnFocusStart;
        DateTime weekOnFocusEnd;
        #endregion

        #region Properties
        public List<EventControl> EventControls
        {
            get { return eventControls; }
        }
        #endregion
        
        #region Events
        public event EventHandler EventControlClick;
        #endregion

        public EventControlDispatcher(EventViewModelDispatcher masterDispatcher)
        {
            if (masterDispatcher == null)
            {
                throw new NullDispatcherException();
            }
            this.masterDispatcher = masterDispatcher;
            this.attachedWeekGrid = this.masterDispatcher.AttachedWeekGridControl;

            this.eventControls = new List<EventControl>();
        }
        
        #region Public Methods
        public void AddEventControl(OrganizerEvent eventToBeDisplayed)
        {
            //Create control and add it to the VisualTree
            EventControl eventControl = new EventControl(eventToBeDisplayed);
            if (eventControl.SingleDay == true)
            {
                this.attachedWeekGrid.HoursGrid.Children.Add(eventControl);
            }
            else
            {
                this.attachedWeekGrid.DaysGrid.Children.Add(eventControl);
            }

            //Add the new control to the list of controls
            eventControls.Add(eventControl);


            //Subscribe for the control's events
            eventControl.SingleDayChanged += this.EventControl_SingleDayChanged;
            eventControl.DataSourcePropertyChanged += this.EventControlDataSourceProperty_Changed;
            eventControl.Click += this.OnEventControlClick;

            this.SetControlSizeAndPosition(eventControl);
        }
  
        public void RemoveEventControl(EventControl controlToBeRemoved)
        {
            if (controlToBeRemoved != null)
            {
                bool singleDay = controlToBeRemoved.SingleDay;
                if (singleDay == true)
                {
                    this.attachedWeekGrid.HoursGrid.Children.Remove(controlToBeRemoved);
                }
                else
                {
                    this.attachedWeekGrid.DaysGrid.Children.Remove(controlToBeRemoved);
                }
                this.eventControls.Remove(controlToBeRemoved);
                controlToBeRemoved.UnSubscribeToDataSourceEvents();
                controlToBeRemoved.SingleDayChanged -= this.EventControl_SingleDayChanged;
                controlToBeRemoved.DataSourcePropertyChanged -= this.EventControlDataSourceProperty_Changed;
            }
        }
  
        public void RemoveEventControl(OrganizerEvent eventBeingDisplayed)
        {
            EventControl controlToBeRemoved = this.EventControls.First(x => x.DataSource == eventBeingDisplayed);
            this.RemoveEventControl(controlToBeRemoved);
        }
  
        public void RefreshEventControlsFrom(IEnumerable<OrganizerEvent> organizerEvents, DateTime weekOnFocusStart, DateTime weekOnFocusEnd)
        {
            if (organizerEvents == null)
            {
                throw new NullDataSourceException();
            }

            this.weekOnFocusStart = weekOnFocusStart;
            this.weekOnFocusEnd = weekOnFocusEnd;

            //Remove old controls from grid.
            ClearEventControls();
            //Add new controls binded to the events.
            AddNewEventControlsFrom(organizerEvents);
        }

        public void ResizeControls()
        {
            foreach (EventControl eventControl in this.eventControls)
            {
                this.SetControlMargins(eventControl);
            }
        }
        #endregion
        
        #region Private methods
        private void ClearEventControls()
        {
            if (eventControls.Count != 0)
            {
                foreach (EventControl eventControl in eventControls)
                {
                    bool singleDay = eventControl.SingleDay;
                    if (singleDay == true)
                    {
                        this.attachedWeekGrid.HoursGrid.Children.Remove(eventControl);
                    }
                    else
                    {
                        this.attachedWeekGrid.DaysGrid.Children.Remove(eventControl);
                    }

                    eventControl.UnSubscribeToDataSourceEvents();
                    eventControl.SingleDayChanged -= this.EventControl_SingleDayChanged;
                }
                eventControls.Clear();
            }
        }

        private void RepositionControl(EventControl changedControl)
        { 
            //check if the dataSource event is still active in the week on focus
            DateTime start = changedControl.StartTime;
            DateTime end = changedControl.EndTime;
            
            bool startsThisWeek = this.weekOnFocusStart <= start && start <= this.weekOnFocusEnd;
            bool endsThisWeek = this.weekOnFocusStart <= end && end <= this.weekOnFocusEnd;
            bool isActiveDuringThisWeek = start <= this.weekOnFocusStart && end >= this.weekOnFocusEnd;

            if ((startsThisWeek || endsThisWeek || isActiveDuringThisWeek) == false)
            {
                this.RemoveEventControl(changedControl);
            }
            else
            {
                SetControlSizeAndPosition(changedControl);
            }
        }

        private void SetControlSizeAndPosition(EventControl eventControl)
        { 
            
            //Set grid row/clumn position and margins of control.
            if (eventControl.SingleDay == true)
            {
                SetSizeAndPositionSingleDay(eventControl);
            }
            else
            {
                SetSizeAndPositionMultiDay(eventControl);
            }
            //Set Margins.
            SetControlMargins(eventControl);
        }

        private void SetControlMargins(EventControl eventControl)
        {
            DateTime weekOnFocusStart = masterDispatcher.WeekOnFocusStart;
            DateTime weekOnFocusEnd = masterDispatcher.WeekOnFocusEnd;
            double parentGridRowHeight = this.attachedWeekGrid.HourRowHeight;
            double parentGridCellWidth = this.attachedWeekGrid.HourColumnWidth;
                
            if (eventControl.SingleDay == true)
            {
                SetControlMarginsSingleDay(eventControl, parentGridRowHeight);
            }
            else
            {
                SetControlMarginsMultiDay(eventControl, weekOnFocusStart, weekOnFocusEnd, parentGridCellWidth);
            }
        }

        private void SetSizeAndPositionSingleDay(EventControl eventControl)
        {
            DateTime start = eventControl.StartTime;
            DateTime end = eventControl.EndTime;
            
            int startDayOfWeek = start.DayOfWeek == DayOfWeek.Sunday? 6:  (int)start.DayOfWeek - 1;
            
            //Set control's position:
            Grid.SetRow(eventControl, WeekGridControl.FirstHourCellRow + start.Hour);
            Grid.SetColumn(eventControl, WeekGridControl.FirstHourCellColumn + startDayOfWeek);

            //Set control's size:
            Grid.SetColumnSpan(eventControl, 1);
            int rowSpan;

            if (start.Hour == end.Hour)
            {
                rowSpan = 1;
            }
            else
            {
                rowSpan = 1 + end.Hour - start.Hour;
            }
            Grid.SetRowSpan(eventControl, rowSpan);
        }

        private void SetSizeAndPositionMultiDay(EventControl eventControl)
        {
            DateTime start = eventControl.StartTime;
            DateTime end = eventControl.EndTime;
            DateTime weekOnFocusStart = masterDispatcher.WeekOnFocusStart;
            DateTime weekOnFocusEnd = masterDispatcher.WeekOnFocusEnd;
            
            int startDayOfWeek = start.DayOfWeek == DayOfWeek.Sunday? 6:  (int)start.DayOfWeek - 1;
            int endDayOfWeek = end.DayOfWeek == DayOfWeek.Sunday? 6:  (int)end.DayOfWeek - 1;

            bool startsThisWeek = weekOnFocusStart <= start && start <= weekOnFocusEnd;
            bool endsThisWeek = weekOnFocusStart <= end && end <= weekOnFocusEnd;
            bool isSingleWeek = startsThisWeek && endsThisWeek;
            if (isSingleWeek == true)
            {
                int gridCol = WeekGridControl.FirstHourCellColumn + startDayOfWeek;
                int gridColSpan = 1 + endDayOfWeek - startDayOfWeek;
                if (end.Day > start.Day)
                {
                    Grid.SetRow(eventControl, 0);
                    Grid.SetColumn(eventControl, gridCol);
                    Grid.SetColumnSpan(eventControl, gridColSpan);
                }

            }
            else if (startsThisWeek == true)
            {
                int gridCol = WeekGridControl.FirstHourCellColumn + startDayOfWeek;
                int gridColSpan = WeekInDays - startDayOfWeek;
                Grid.SetRow(eventControl, 0);
                Grid.SetColumn(eventControl, gridCol);
                Grid.SetColumnSpan(eventControl, gridColSpan);
            }
            else if (endsThisWeek == true)
            {
                int gridCol = WeekGridControl.FirstHourCellColumn;
                int gridColSpan = 1 + endDayOfWeek;
                Grid.SetRow(eventControl, 0);
                Grid.SetColumn(eventControl, gridCol);
                Grid.SetColumnSpan(eventControl, gridColSpan);
            }
            else
            {
                Grid.SetRow(eventControl, 0);
                Grid.SetColumn(eventControl, WeekGridControl.FirstHourCellColumn);
                Grid.SetColumnSpan(eventControl, WeekInDays);
            }
        }
        
        private void SetControlMarginsSingleDay(EventControl eventControl, double parentGridRowHeight)
        {
            DateTime start = eventControl.StartTime;
            DateTime end = eventControl.EndTime;
            
            double topMargin = Math.Round(start.Minute / HourAsMinutes * parentGridRowHeight, 0);
            double bottomMargin = Math.Round((HourAsMinutes - end.Minute) / HourAsMinutes * parentGridRowHeight, 0);
            int rowSpan = Grid.GetRowSpan(eventControl);
            //double height = Math.Round(parentGridRowHeight * rowSpan - topMargin - bottomMargin, 0);

            eventControl.Margin = new Thickness(EventControl.SingleDayLeftMargin, topMargin, EventControl.SingleDayRightMargin, bottomMargin);
            //eventControl.Body.Height = height;
        }

        private void SetControlMarginsMultiDay(EventControl eventControl, DateTime weekOnFocusStart, DateTime weekOnFocusEnd, double parentGridCellWidth)
        {
            const double MultyDayMargin = EventControl.MultyDayMargin;
            
            DateTime start = eventControl.StartTime;
            DateTime end = eventControl.EndTime;
            
            bool startsThisWeek = weekOnFocusStart <= start && start <= weekOnFocusEnd;
            bool endsThisWeek = weekOnFocusStart <= end && end <= weekOnFocusEnd;
            bool isSingleWeek = startsThisWeek && endsThisWeek;
            if (isSingleWeek == true)
            {
                double leftMargin = Math.Round((start.Minute + start.Hour * HourAsMinutes) / DayAsMinutes * parentGridCellWidth, 0);
                double rightMargin = Math.Round((1.0d - (end.Minute + end.Hour * HourAsMinutes) / DayAsMinutes) * parentGridCellWidth, 0);
                eventControl.Margin = new Thickness(leftMargin, MultyDayMargin, rightMargin, MultyDayMargin);
            }
            else if (startsThisWeek == true)
            {
                double leftMargin = Math.Round((start.Minute + start.Hour * HourAsMinutes) / DayAsMinutes * parentGridCellWidth, 0);
                double rightMargin = 0;
                eventControl.Margin = new Thickness(leftMargin, MultyDayMargin, rightMargin, MultyDayMargin);
            }
            else if (endsThisWeek == true)
            {
                double leftMargin = 0;
                double rightMargin = Math.Round((1.0d - (end.Minute + end.Hour * HourAsMinutes) / DayAsMinutes) * parentGridCellWidth, 0);
                eventControl.Margin = new Thickness(leftMargin, MultyDayMargin, rightMargin, MultyDayMargin);
            }
            else
            {
                eventControl.Margin = new Thickness(MultyDayMargin);
            }
        }

        private void AddNewEventControlsFrom(IEnumerable<OrganizerEvent> events)
        {
            foreach (OrganizerEvent organizerEvent in events)
            {
                AddEventControl(organizerEvent);
            }
        }
    
        private void MoveControlToHourEventsGrid(EventControl changedControl)
        {
            if (!this.eventControls.Contains(changedControl))
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("EventControl is not a member of this WeekGrid.");
                //  throw new InvalidOperationException("EventControl is not a member of this WeekGrid.");
            }
            else
            {
                this.attachedWeekGrid.DaysGrid.Children.Remove(changedControl);
                
                this.attachedWeekGrid.HoursGrid.Children.Add(changedControl);
            }
        }

        private void MoveControlToDaysEventsGrid(EventControl changedControl)
        {
            if (!this.eventControls.Contains(changedControl))
            {
               System.Windows.MessageBox.Show("EventControl is not a member of this WeekGrid.");
               // throw new InvalidOperationException("EventControl is not a member of this WeekGrid.");
            }
            else
            {
                this.attachedWeekGrid.HoursGrid.Children.Remove(changedControl);
                this.attachedWeekGrid.DaysGrid.Children.Add(changedControl);
            }
        }
        #endregion

        #region Event Handlers
        private void OnEventControlClick(object sender, EventArgs e)
        {
            if (this.EventControlClick != null)
            {
                this.EventControlClick(sender, e);
            }
        }

        private void EventControl_SingleDayChanged(object sender, EventArgs e)
        {
            EventControl changedControl = sender as EventControl;
            if (changedControl != null)
            {
                if (changedControl.SingleDay == false)
                {
                    this.MoveControlToDaysEventsGrid(changedControl);
                }
                else
                {
                    this.MoveControlToHourEventsGrid(changedControl);
                }
            }
            SetControlSizeAndPosition(changedControl);
        }

        private void EventControlDataSourceProperty_Changed(object sender, EventArgs e)
        { 
            EventControl changedControl = sender as EventControl;
            if (changedControl != null)
            {
                this.RepositionControl(changedControl); ;
            }
        }
        #endregion
    }
}
