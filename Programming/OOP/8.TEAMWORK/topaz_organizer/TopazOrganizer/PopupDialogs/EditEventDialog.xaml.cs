using System;
using System.Linq;
using System.Windows.Controls;
using TopazOrganizer.OrganizerEvents;
using TopazOrganizer.OrganizerExceptions;

namespace TopazOrganizer.PopupDialogs
{
    /// <summary>
    /// Interaction logic for EditEventDialog.xaml
    /// </summary>
    public partial class EditEventDialog : UserControl
    {
        public OrganizerEvent DataSource
        { get; private set; }

        public EditEventDialog()
        {
            InitializeComponent();
            this.EventTypeComboBox.ItemsSource = Enum.GetValues(typeof(OrganizerEventType)).Cast<OrganizerEventType>();
        }

        public void FillData(OrganizerEvent dataSource)
        {
            if (dataSource == null)
            {
                throw new NullDataSourceException();  
            }
            this.DataSource = dataSource;
            FillData(dataSource.Title, dataSource.Location, dataSource.EventType, dataSource.Start, dataSource.End, dataSource.AllDay);
        }

        public void FillData(string title, string location, OrganizerEventType type, DateTime? start, DateTime? end, bool allDay)
        {
            this.TitleTextBox.Text = title;
            this.LocationTextBox.Text = location;
            this.EventTypeComboBox.SelectedValue = type;
            this.StartTimePicker.Value = start;
            this.EndTimePicker.Value = end;
            this.AllDayCheckBox.IsChecked = allDay;
        }

    }
}
