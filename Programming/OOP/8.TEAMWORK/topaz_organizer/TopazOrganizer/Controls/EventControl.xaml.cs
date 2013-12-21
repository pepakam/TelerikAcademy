using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using TopazOrganizer.OrganizerEvents;
using TopazOrganizer.OrganizerExceptions;

namespace TopazOrganizer.Controls
{
    /// <summary>
    /// Interaction logic for EventControl.xaml
    /// </summary>
    public partial class EventControl : UserControl
    {
        #region Constants
        //String constants used when there is empty data.
        public const string EmptyTitleText = "(no title)";
        public const string EmptyLocationText = "(empty location)";
        
        //String constant for time format
        public const string TimeFormat = "HH:mm";

        //Colors for the different types events to be displayed.
        public static readonly Color TabColorForMeeting = Colors.SteelBlue;
        public static readonly Color TabColorForLecture = Colors.YellowGreen;
        public static readonly Color TabColorForExercise = Colors.Gold;
        public static readonly Color TabColorForDeadline = Colors.Tomato;
        public static readonly Color TabColorForOther = Colors.NavajoWhite;

        //Margin thickness for the sides of the control.
        public const double SingleDayLeftMargin = 2;
        public const double SingleDayRightMargin = 2;
        public const double MultyDayMargin = 2;
        
        //Date constants
        const int WeekInDays = 7;
        const double HourAsMinutes = 60.0d;
        const double DayAsMinutes = 1440.0d;    
        #endregion

        #region Fields
        private bool singleDay;
        private OrganizerEventType type;
        private OrganizerEvent dataSource;
        #endregion

        #region Properties
        //A Property for binding to the dataSource Title. The "DependencyProperty" objects are used to enable the binding.
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(EventControl));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        //A Property for binding to the dataSource Location. The "DependencyProperty" objects are used to enable the binding.
        public static readonly DependencyProperty LocationProperty =
            DependencyProperty.Register("Location", typeof(string), typeof(EventControl));
        public string Location
        {
            get { return (string)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }

        //A Property for binding to the dataSource Start property. The "DependencyProperty" objects are used to enable the binding.
        public static readonly DependencyProperty StartTimeProperty =
            DependencyProperty.Register("StartTime", typeof(DateTime), typeof(EventControl));
        public DateTime StartTime
        {
            get { return (DateTime)GetValue(StartTimeProperty); }
            set { SetValue(StartTimeProperty, value); }
        }
  
        //A Property for binding to the dataSource End property. The "DependencyProperty" objects are used to enable the binding.
        public static readonly DependencyProperty EndTimeProperty =
            DependencyProperty.Register("EndTime", typeof(DateTime), typeof(EventControl));
        public DateTime EndTime
        {
            get { return (DateTime)GetValue(EndTimeProperty); }
            set { SetValue(EndTimeProperty, value); }     
        }

        //A Property for binding to the dataSource End property. The "DependencyProperty" objects are used to enable the binding.
        public static readonly DependencyProperty AllDayProperty =
            DependencyProperty.Register("AllDay", typeof(bool), typeof(EventControl));
        public bool AllDay
        {
            get { return (bool)GetValue(AllDayProperty); }
            set { SetValue(AllDayProperty, value); }
        }

        //A Property for binding to the parent grid's row height.
        public static readonly DependencyProperty ParentRowHeightProperty =
            DependencyProperty.Register("ParentRowHeight", typeof(double), typeof(EventControl));
        public double ParentRowHeight
        {
            get { return (double)GetValue(ParentRowHeightProperty); }
            private set { }
        }

        //A Property for binding to the parent grid's cell width.
        public static readonly DependencyProperty ParentCellWidthProperty =
            DependencyProperty.Register("ParentCellWidth", typeof(double), typeof(EventControl));
        public double ParentCellWidth
        {
            get { return (double)GetValue(ParentCellWidthProperty); }
            private set { }
        }

        //A Property for storing the single/multiday status of the EventControl
        public bool SingleDay
        {
            get { return singleDay; }
            set 
            { 
                if(!singleDay == value)
                {
                    singleDay = value; 
                    this.OnSingleDayChanged(this);
                }
            }
        }

        //A property for storing the dataSource Type. 
        public OrganizerEventType Type
        {
            get { return type; }
            private set 
            {
                type = value;
                
                //Update appearance of control.
                SetTabColor(value);
            }
        }
        
        public OrganizerEvent DataSource
        {
            get { return dataSource; }
            private set { dataSource = value; }
        }
        #endregion

        #region Events
        public event EventHandler SingleDayChanged;
        public event EventHandler DataSourcePropertyChanged;
        public event MouseButtonEventHandler Click
        {
            add { this.MouseLeftButtonDown += value; }
            remove { this.MouseLeftButtonDown -= value; }
        }
        #endregion

        public EventControl(OrganizerEvent dataSource)
        {
            if (dataSource == null)
            {
                throw new NullDataSourceException();
            }
            
            this.InitializeComponent();
            
            //Bind to the properties of the data source OrganizerEvent object.
            this.BindTo(dataSource);
                        
            //Store a reference to dataSOurce
            this.DataSource = dataSource;

            //Subscibe to dataSource's events
            this.SubscribeToDataSourceEvents();

            //Initially set size, position and text of control.
            this.SingleDay = CheckSingleDayStatus();
            this.SetTimeText();
        }

        #region Public Methods
        public void BindTo(OrganizerEvent dataSource)
        {
            if (dataSource != null)
            {
                //Bind event Title.
                Binding titleBinding = new Binding("Title");
                titleBinding.Source = dataSource;
                this.SetBinding(EventControl.TitleProperty, titleBinding);

                //Bind event Location.
                Binding locationBinding = new Binding("Location");
                locationBinding.Source = dataSource;
                this.SetBinding(EventControl.LocationProperty, locationBinding);

                //Get event Type. (eventType field is readony for the derived types of OrganizerEvent class)
                this.Type = dataSource.EventType;

                //Bind event start.
                Binding startBinding = new Binding("Start");
                startBinding.Source = dataSource;
                this.SetBinding(EventControl.StartTimeProperty, startBinding);
                
                //Bind event end.
                Binding endBinding = new Binding("End");
                endBinding.Source = dataSource;
                this.SetBinding(EventControl.EndTimeProperty, endBinding);
            }
        }

        public void SubscribeToDataSourceEvents()
        {
            dataSource.PropertyChanged += this.OnDataSourcePropertyChanged;
        }

        public void UnSubscribeToDataSourceEvents()
        {
            dataSource.PropertyChanged -= this.OnDataSourcePropertyChanged;
            this.dataSource = null;
        }
        #endregion

        #region Private Methods
        //Method for updating the control's tab color according to the type of the event being displayed. Colors are set as constants at top of this file.
        private void SetTabColor(OrganizerEventType type)
        {
            Color tabColor;
            switch (type)
            {
                case OrganizerEventType.Meeting:
                    tabColor = TabColorForMeeting;
                    break;
                case OrganizerEventType.Lecture:
                    tabColor = TabColorForLecture;
                    break;
                case OrganizerEventType.Exercise:
                    tabColor = TabColorForExercise;
                    break;
                case OrganizerEventType.Deadline:
                    tabColor = TabColorForDeadline;
                    break;
                default:
                    tabColor = TabColorForOther;
                    break;
            }
            SolidColorBrush fill = new SolidColorBrush(tabColor);
            this.Body.Background = fill;
        }

        //Method for setting the text of the TextBlock showing the start and end times of the data source for the control.
        private void SetTimeText()
        {
            this.TimeTextBlock.Text = string.Format("{0}-{1}", StartTime.ToString("HH:mm"), EndTime.ToString("HH:mm"));
        }
       
        private bool CheckSingleDayStatus()
        { 
            DateTime start = this.StartTime;
            DateTime end = this.EndTime;
            bool isSingleDayEvent = (start.Year == end.Year && start.Month == end.Month && start.Day == end.Day  
                && this.AllDay == false);

            return isSingleDayEvent;
        }
        #endregion

        #region Event Handlers

        private void OnDataSourcePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //Update appearance of control when there is a change in the start/end.
            switch (e.PropertyName)
            {
                case "Start":
                case "End":
                case "AllDay":
                    this.SingleDay = CheckSingleDayStatus();
                    SetTimeText();
                    this.DataSourcePropertyChanged(this, e);
                    break;
            }
        }
        
        private void OnSingleDayChanged(object sender)
        {
            if (this.SingleDayChanged != null)
            {
                SingleDayChanged(sender, EventArgs.Empty);
            }
        }
        
        #endregion

    }
}
