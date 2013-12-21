using System;
using System.Windows;
using TopazOrganizer.Dispatchers;
using TopazOrganizer.OrganizerEvents;

namespace TopazOrganizer.Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OrganizerEventData eventData;
        EventViewModelDispatcher eventViewModelDispatcher;

        public MainWindow()
        {
            InitializeComponent();
            //this.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            
            eventData = new OrganizerEventData();
            eventData.GetEventsFromDatabase();
            
            eventViewModelDispatcher = new EventViewModelDispatcher();
            eventViewModelDispatcher.AtachDataSource(eventData);
            eventViewModelDispatcher.AttachControl(this.WeekGrid);
        }

        private void NotesButton_Click(object sender, RoutedEventArgs e)
        {
            NotesDialog notes = new NotesDialog();
            notes.Show();
        }

       
    }
}
