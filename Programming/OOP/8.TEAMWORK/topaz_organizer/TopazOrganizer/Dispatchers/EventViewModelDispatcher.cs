using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using TopazOrganizer.Controls;
using TopazOrganizer.OrganizerEvents;
using TopazOrganizer.OrganizerExceptions;

namespace TopazOrganizer.Dispatchers
{
    /// <summary>
    /// This class is the main contractor between the Data source (Model) and its visual presentation (ViewModel).
    /// Together with PopupDispathcer and EventControlDispatcher classes is responsible for the update of controls, 
    /// their positioning, as well as addition of new events and thier manipulation.
    /// </summary>
    public class EventViewModelDispatcher:IDisposable
    {
        #region Constants
        public const double HourAsMinutes = 60.0d;
        public const double DayAsMinutes = 1440.0d;
        
        public const string DateStringFormat = "dd.MM.yyyy";
        public const string TimeFormat = "HH:mm";
        #endregion

        #region Fields
        DateTime weekOnFocusStart;
        DateTime weekOnFocusEnd;
        DateTime currentDate;
        DateTime dateOnFocus;
        int weekOnFocus;
        int yearOnFocus;

        IPopupDispatcher popupDispatcher;
        IEventControlDispatcher eventControlDispatcher;
        readonly DispatcherTimer currentTimeRefreshTimer;

        readonly List<IEventDataContainer> dataSources;
        WeekGridControl attachedWeekGridControl;
        #endregion

        #region Properties
        public List<IEventDataContainer> DataSources
        {
            get {return this.dataSources;}
        }
        
        public WeekGridControl AttachedWeekGridControl
        {
            get { return attachedWeekGridControl; }
        }

        public DateTime WeekOnFocusStart
        { get { return this.weekOnFocusStart; } }
        
        public DateTime WeekOnFocusEnd
        { get { return this.weekOnFocusEnd; } }
        
        public int WeekOnFocus
        {
            get { return weekOnFocus; }
        }

        public int YearOnFocus
        {
            get { return yearOnFocus; }
        }
        #endregion

        #region Events
        public event EventHandler WeekOnFocusChanged;
        public event EventHandler DataSourceItemAdded;
        public event EventHandler DataSourceItemRemoved;
        public event EventHandler EventControlClicked;
        public event EventHandler EmptyCellClicked;
        public event EventHandler AttachedControlSizeChanged;
        #endregion

        public EventViewModelDispatcher()
        {
            this.dataSources = new List<IEventDataContainer>();
            
            //Create the timer used for updating the current time, updates every 1 minute.
            this.currentDate = DateTime.Now;
            this.currentTimeRefreshTimer = new DispatcherTimer();
            this.currentTimeRefreshTimer.Tick += new EventHandler(CurrentTimeRefreshTimer_Tick);
            this.currentTimeRefreshTimer.Interval = new TimeSpan(0, 1, 0);
            this.currentTimeRefreshTimer.Start();
        }

        #region Methods for attaching/detaching IEventDataContainer datasources.
        public void AtachDataSource(IEventDataContainer dataSource)
        { 
            if (dataSource == null)
            {
                throw new NullDataSourceException();
            }
            if(this.dataSources.Contains(dataSource))
            {
                throw new DuplicateDataSourceException();
            }

            this.dataSources.Add(dataSource);
            this.SubscribeToDataSourceEvents(dataSource);
        }

        public void DetachDataSource(IEventDataContainer dataSource)
        { 
            if (dataSource == null)
            {
                throw new NullDataSourceException();
            }
            if(!this.dataSources.Contains(dataSource))
            {
                throw new DataSourceException();
            }

            this.dataSources.Remove(dataSource);
            this.UnSubscribeFromDataSourceEvents(dataSource);
        }
        
        private void SubscribeToDataSourceEvents(IEventDataContainer dataSource)
        {
            if (dataSource != null)
            {
                dataSource.EventAdded += new EventHandler(EventAdded);
                dataSource.EventRemoved += new EventHandler(EventRemoved);
                dataSource.DataRefreshed += new EventHandler(DataRefreshed);
            }
        }

        private void UnSubscribeFromDataSourceEvents(IEventDataContainer dataSource)
        {
            dataSource.EventAdded -= new EventHandler(EventAdded);
            dataSource.EventRemoved -= new EventHandler(EventRemoved);
            dataSource.DataRefreshed -= new EventHandler(DataRefreshed);
        }
        #endregion

        #region Methods for attaching/detaching a WeekGridControl.
        public void AttachControl(WeekGridControl weekGrid)
        {
            if (weekGrid == null)
            {
                throw new NullAttachedControlException();
            }
            
            //Throw exception if there is already an attached WeekGridControl and the control to be attached is not the same.
            if (this.attachedWeekGridControl != null
                && this.attachedWeekGridControl != weekGrid)
            {
                throw new AttachedControlException();
            }

            this.attachedWeekGridControl = weekGrid;
            
            popupDispatcher = new PopupDispatcher(this);
            
            eventControlDispatcher = new EventControlDispatcher(this);
            eventControlDispatcher.EventControlClick += new EventHandler(EventControl_Clicked);

            this.SubscribeToAttachedControlEvents(weekGrid);
            this.SetViewModelStateToShow(DateTime.Now);
        }
        
        public void DetachControl()
        {
            if (this.attachedWeekGridControl != null)
            {
                UnSubscribeFromAttachedControlEvents();
                this.attachedWeekGridControl = null;
                this.popupDispatcher = null;
                this.eventControlDispatcher = null;
            }
        }
        
        private void SubscribeToAttachedControlEvents(WeekGridControl weekGrid)
        {
             if (weekGrid == null)
            {
                throw new NullAttachedControlException();
            }

            //Subscribe fort Button.Clicked events for the buttons in the atached WeekGridControl.
            weekGrid.PreviousWeekButton.Click += new RoutedEventHandler(PreviousWeek_Clicked);
            weekGrid.NextWeekButton.Click += new RoutedEventHandler(NextWeek_Clicked);
            weekGrid.TodayButton.Click += new RoutedEventHandler(Today_Clicked);
            weekGrid.AddButton.Click += new RoutedEventHandler(Add_Clicked);
        
            //Subscribe for OnHourCellClicked event which fires when a cell from the hour grid is clicked.
            weekGrid.HourCellClick += new MouseButtonEventHandler(HourCell_Clicked);
            weekGrid.DayCellClick += new MouseButtonEventHandler(DayCell_Clicked);

            //Subscribe for the change of size.
            weekGrid.SizeChanged += new SizeChangedEventHandler(AttachedControlSize_Changed);
        }

        private void UnSubscribeFromAttachedControlEvents()
        {
             if (this.attachedWeekGridControl == null)
            {
                throw new NullAttachedControlException();
            }

            //Unsubscribe from Button.Clicked events for the buttons in the atached WeekGridControl.
            attachedWeekGridControl.PreviousWeekButton.Click -= PreviousWeek_Clicked;
            attachedWeekGridControl.NextWeekButton.Click -= NextWeek_Clicked;
            attachedWeekGridControl.TodayButton.Click -= Today_Clicked;
            attachedWeekGridControl.AddButton.Click -= Add_Clicked;
        
            //Unsubscribe from OnHourCellClicked event which fires when a cell from the hour grid is clicked.
            attachedWeekGridControl.HourCellClick -= HourCell_Clicked;
            attachedWeekGridControl.DayCellClick -= DayCell_Clicked;

            //Unsubscribe for the change of size.
            attachedWeekGridControl.SizeChanged -= AttachedControlSize_Changed;
        }
        #endregion

        #region Methods for modifying the contents of the attached WeekGridControl.
        private void SetViewModelStateToShow(DateTime dateOnFocus)
        {
            //Update time-related fields of this object
            UpdateDateTimeFieldsFrom(dateOnFocus);

            //Refresh Textblocks
            RefreshWeekDatesTexBlocks();

            //Get events for the week of date on focus  and refresh EventControls
            this.eventControlDispatcher.RefreshEventControlsFrom(this.GetEventsActiveInWeekOnFocus(), this.weekOnFocusStart, this.weekOnFocusStart);

            //Refresh current time pointers.
            RefreshCurrentTimePointers();
        }

        private void UpdateDateTimeFieldsFrom(DateTime dateOnFocus)
        {
            this.dateOnFocus = dateOnFocus;
            DateTimeSpan currentDateInfo = new DateTimeSpan(dateOnFocus);
            this.weekOnFocus = currentDateInfo.WeekNum;
            this.yearOnFocus = dateOnFocus.Year;
            this.weekOnFocusStart = currentDateInfo.WeekStartDate;
            this.weekOnFocusEnd = currentDateInfo.WeekEndDate;
        }
        
        private void RefreshWeekDatesTexBlocks()
        {
            //Update the texblocks for week start/end
            this.attachedWeekGridControl.WeekStartTextBlock.Text = string.Format("{0}", weekOnFocusStart.ToString(DateStringFormat));
            this.attachedWeekGridControl.WeekEndTextBlock.Text = string.Format("{0}", weekOnFocusEnd.ToString(DateStringFormat));

            //Update the textblock at each day column
            this.attachedWeekGridControl.Day1TextBlock.Text = weekOnFocusStart.ToString(DateStringFormat);
            this.attachedWeekGridControl.Day2TextBlock.Text = weekOnFocusStart.AddDays(1).ToString(DateStringFormat);
            this.attachedWeekGridControl.Day3TextBlock.Text = weekOnFocusStart.AddDays(2).ToString(DateStringFormat);
            this.attachedWeekGridControl.Day4TextBlock.Text = weekOnFocusStart.AddDays(3).ToString(DateStringFormat);
            this.attachedWeekGridControl.Day5TextBlock.Text = weekOnFocusStart.AddDays(4).ToString(DateStringFormat);
            this.attachedWeekGridControl.Day6TextBlock.Text = weekOnFocusStart.AddDays(5).ToString(DateStringFormat);
            this.attachedWeekGridControl.Day7TextBlock.Text = weekOnFocusEnd.ToString(DateStringFormat);
        }

        private void RefreshCurrentTimePointers()
        {
            double rowHeight = this.attachedWeekGridControl.HourRowHeight;
            double cellWidth = this.attachedWeekGridControl.HourColumnWidth;
            
            if (this.attachedWeekGridControl == null)
            {
                throw new NullAttachedControlException();
            }

            DateTime currentTime = this.currentDate;

            //Refresh the text of CurrentTimeTextBlock
            this.attachedWeekGridControl.CurrentTimeTextBlock.Text = currentTime.ToString(WeekGridControl.TimeFormat);

            //If week on focus is the current week draw the pointers
            if (weekOnFocusStart <= currentTime && currentTime <= weekOnFocusEnd)
            {
                //If pointers are hidden, unhide them.
                if (!this.attachedWeekGridControl.CurrentTimeLine.IsVisible)
                {
                    this.attachedWeekGridControl.CurrentTimeLine.Visibility = Visibility.Visible;
                }
                if (!this.attachedWeekGridControl.CurrentTimeTriangle.IsVisible)
                {
                    this.attachedWeekGridControl.CurrentTimeTriangle.Visibility = Visibility.Visible;
                }
                if (!this.attachedWeekGridControl.EventDayLine.IsVisible)
                {
                    this.attachedWeekGridControl.EventDayLine.Visibility = Visibility.Visible;
                }

                //Set position of pointers
                double topMargin = Math.Round(currentTime.Minute / HourAsMinutes * rowHeight, 0);
                int gridRow = currentTime.Hour;
                int dayOfWeekNumber = currentTime.DayOfWeek == DayOfWeek.Sunday? 6:  (int)currentTime.DayOfWeek - 1;
                int gridColumn = WeekGridControl.FirstHourCellColumn + dayOfWeekNumber;

                //Set the triangle
                Grid.SetRow(this.attachedWeekGridControl.CurrentTimeTriangle, currentTime.Hour);
                this.attachedWeekGridControl.CurrentTimeTriangle.Margin = new Thickness(0, topMargin - 5, 0, 0);

                //Set the horizontal hour timeline
                Grid.SetRow(this.attachedWeekGridControl.CurrentTimeLine, gridRow);
                Grid.SetColumn(this.attachedWeekGridControl.CurrentTimeLine, gridColumn);
                this.attachedWeekGridControl.CurrentTimeLine.Margin = new Thickness(3, topMargin - 1, 3, 0);

                //Set the vertical hour timeline
                double verticalTimeLineLeftMargin = Math.Round((currentTime.Minute + currentTime.Hour * HourAsMinutes) / DayAsMinutes
                    * cellWidth, 0);
                Grid.SetColumn(this.attachedWeekGridControl.EventDayLine, gridColumn);
                this.attachedWeekGridControl.EventDayLine.Margin = new Thickness(verticalTimeLineLeftMargin - 2, 1, 0, 1);
            }
            //If not, hide the pointers
            else
            {
                if (this.attachedWeekGridControl.CurrentTimeLine.IsVisible)
                {
                    this.attachedWeekGridControl.CurrentTimeLine.Visibility = Visibility.Hidden;
                }
                if (this.attachedWeekGridControl.CurrentTimeTriangle.IsVisible)
                {
                    this.attachedWeekGridControl.CurrentTimeTriangle.Visibility = Visibility.Hidden;
                }
                if (this.attachedWeekGridControl.EventDayLine.IsVisible)
                {
                    this.attachedWeekGridControl.EventDayLine.Visibility = Visibility.Hidden;
                }
            }
        }
        #endregion

        #region Helper Methods and Cleanup
        private bool EventIsFromWeekOnFocus(OrganizerEvent organizerEvent)
        {
            bool startsThisWeek = this.weekOnFocusStart <= organizerEvent.Start && organizerEvent.Start <= this.weekOnFocusEnd;
            bool endsThisWeek = this.weekOnFocusStart <= organizerEvent.End && organizerEvent.End <= this.weekOnFocusEnd;
            bool isActiveDuringThisWeek = organizerEvent.Start <= this.weekOnFocusStart && organizerEvent.End >= this.weekOnFocusEnd;

            return startsThisWeek || endsThisWeek || isActiveDuringThisWeek; 
        }
        
        private IEnumerable<OrganizerEvent> GetEventsActiveInWeekOnFocus()
        {
            List<OrganizerEvent> activeEvents = new List<OrganizerEvent>();
            foreach (var dataSource in this.dataSources)
            {
                activeEvents.AddRange(dataSource.Items.Where(x => EventIsFromWeekOnFocus(x) == true));
            }
            return activeEvents;
        }
        
        public void Dispose()
        {
            if(this.currentTimeRefreshTimer!=null)
            {
                this.currentTimeRefreshTimer.Tick -= CurrentTimeRefreshTimer_Tick;
                this.currentTimeRefreshTimer.Stop();
            }
            if (this.dataSources != null)
            {
                foreach (IEventDataContainer container in dataSources)
                {
                    DetachDataSource(container);
                }
            }
            if (this.attachedWeekGridControl != null)
            {
                DetachControl();
            }
        }
        #endregion

        #region Event Handlers

        #region Event Handlers for response to EventDataContainers change of content.
        //Method for response to addition of an object to the dataSource. 
        private void EventAdded(object sender, EventArgs data)
        {
            OrganizerEvent newEvent = (data as DataChangedEventArgs).Data;
            this.eventControlDispatcher.AddEventControl(newEvent);
        }

        //Method for response to removal of an object to the dataSource. 
        private void EventRemoved(object sender, EventArgs data)
        {
            OrganizerEvent removedEvent = (data as DataChangedEventArgs).Data;
            if (removedEvent != null)
            {
                this.eventControlDispatcher.RemoveEventControl(removedEvent);
            }
        }

        //Method for response to refresh of the list of an object to the dataSource. 
        private void DataRefreshed(object sender, EventArgs data)
        {
            var activeEventsDuringWeekOnFocus = 
                from OrganizerEvent organizerEvent in (sender as IEventDataContainer).Items
                where this.EventIsFromWeekOnFocus(organizerEvent) == true
                select organizerEvent;
            this.eventControlDispatcher.RefreshEventControlsFrom(activeEventsDuringWeekOnFocus,this.weekOnFocusStart, this.weekOnFocusStart);
        }
        #endregion
        #region Event Handlers for the attached WeekGridControl's buttons Click events.
        //Method for response to moving back 1 week in the attached WeekGridControl.
        private void PreviousWeek_Clicked(object sender, RoutedEventArgs data)
        {
            SetViewModelStateToShow(this.dateOnFocus.AddDays(-7));
            this.popupDispatcher.ClosePopup();
        }

        //Method for response to moving ahead 1 week in the attached WeekGridControl.
        private void NextWeek_Clicked(object sender, RoutedEventArgs data)
        { 
            SetViewModelStateToShow(this.dateOnFocus.AddDays(+7));
            this.popupDispatcher.ClosePopup();
        }

        //Method for response to moving to the current day in the attached WeekGridControl.
        private void Today_Clicked(object sender, RoutedEventArgs data)
        {
            SetViewModelStateToShow(this.currentDate);
            this.popupDispatcher.ClosePopup();
        }

        //Method for response to the '+' button being clicked in the attached WeekGridControl.
        private void Add_Clicked(object sender, RoutedEventArgs data)
        { }
        #endregion
        #region Event Handlers for the attached WeekGridControl's Hour and Day cells being clicked.
        private void HourCell_Clicked(object sender, MouseButtonEventArgs data)
        {
            this.popupDispatcher.ShowPopup(sender, PopupDialogType.Create);
        }

        private void DayCell_Clicked(object sender, MouseButtonEventArgs data)
        { 
            this.popupDispatcher.ShowPopup(sender, PopupDialogType.Create);
        }

        #endregion

        private void EventControl_Clicked(object sender, EventArgs data)
        {
            this.popupDispatcher.ShowPopup(sender, PopupDialogType.Edit);
        }

        //Event Handler called every time there is a change in the size of the attached WeekGridControl.
        private void AttachedControlSize_Changed(object sender, SizeChangedEventArgs data)
        {
            this.RefreshCurrentTimePointers();
            this.eventControlDispatcher.ResizeControls();
        }

        //Event Handler called every time currentTimeRefreshTimer ticks(used to update current Time)
        private void CurrentTimeRefreshTimer_Tick(object sender, EventArgs e)
        {
            this.currentDate = DateTime.Now;
            RefreshCurrentTimePointers();
        }
        #endregion

       
    }
}
