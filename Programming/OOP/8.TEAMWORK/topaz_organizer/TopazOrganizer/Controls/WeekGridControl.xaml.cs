using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace TopazOrganizer.Controls
{
    /// <summary>
    /// Interaction logic for WeekGridControl.xaml
    /// </summary>
    public partial class WeekGridControl : UserControl
    {
        #region Constants
        public const string DateStringFormat = "dd.MM.yyyy";
        public const string TimeFormat = "HH:mm";
        
        public const int FirstHourCellRow = 0;
        public const int FirstHourCellColumn = 1;
        #endregion

        #region Properties
        public double HourRowHeight 
        {
            get { return this.HoursGrid.RowDefinitions[FirstHourCellRow].ActualHeight; }
        }
        public double HourColumnWidth
        { 
            get { return this.HoursGrid.ColumnDefinitions[FirstHourCellColumn].ActualWidth; }
        }
        public double DayRowHeight
        {
            get { return this.DaysGrid.RowDefinitions[0].ActualHeight; }
        }
        public double DayColumnWidth
        {
            get { return this.DaysGrid.ColumnDefinitions[0].ActualWidth; }
        }
        #endregion

        #region Events
        public event MouseButtonEventHandler HourCellClick;
        public event MouseButtonEventHandler DayCellClick;
        #endregion

        public WeekGridControl()
        {
            //Initialize control's elements.
            InitializeComponent();
            CreateHoursGridCellElements();
            CreateDaysGridCellElements();
        }

        #region Private Methods
        //Method for creating the elements used for HoursGrid and selection functionality.
        private void CreateHoursGridCellElements()
        {
            //Create the cell elements for the Hours grid.
            int lastHourRow = FirstHourCellRow + 24;
            int lastHourCellColumn = FirstHourCellColumn + 7;
            for (int currentRow = FirstHourCellRow; currentRow < lastHourRow; currentRow++)
            {
                for (int currentColumn = FirstHourCellColumn; currentColumn < lastHourCellColumn; currentColumn++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Style = (Style)FindResource("CellRectangleStyle");
                    rectangle.Tag = string.Format("{0} {1} SingleDay", currentRow, currentColumn);
                    Grid.SetRow(rectangle, currentRow);
                    Grid.SetColumn(rectangle, currentColumn);
                    this.HoursGrid.Children.Add(rectangle);
                    
                    rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(this.OnHourCellClick);
                }
            }
        }

        //Method for creating the elements used for DaysGrid and selection functionality.
        private void CreateDaysGridCellElements()
        {
            //Create the cell elements for the Hours grid.
            int lastDayCellColumn = FirstHourCellColumn + 7;
            for (int currentColumn = FirstHourCellColumn; currentColumn < lastDayCellColumn; currentColumn++)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Style = (Style)FindResource("CellRectangleStyle");
                rectangle.Tag = string.Format("{0} {1} MultiDay", 0, currentColumn);
                Grid.SetRow(rectangle, 0);
                Grid.SetColumn(rectangle, currentColumn);
                this.DaysGrid.Children.Add(rectangle);
                
                rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(this.OnDayCellClick);
            }
        }
        #endregion

        #region Event Handlers
        private void OnHourCellClick(object sender, MouseButtonEventArgs e)
        {
            if (this.HourCellClick != null)
            {
                this.HourCellClick(sender, e);
            }
        }

        private void OnDayCellClick(object sender, MouseButtonEventArgs e)
        {
            if (this.DayCellClick != null)
            {
                this.DayCellClick(sender, e);
            }
        }

        #endregion
    }
}
