using System;
using System.Linq;
using System.Windows;
using TopazOrganizer.OrganizerEvents;

namespace TopazOrganizer.Controls
{
    /// <summary>
    /// Interaction logic for NewEventWindow.xaml
    /// </summary>
    public partial class NewEventWindow : Window
    {
        public event EventHandler<WindowEventArgs> DialogFinished;

        public NewEventWindow()
        {
            InitializeComponent();
            string[] eventTypes = Enum.GetNames(typeof(OrganizerEventType));
            this.ComboBoxEventType.ItemsSource = eventTypes;
            //int[] days = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
            //this.ComboBoxDay.ItemsSource = days;
            //this.ComboBoxDay2.ItemsSource = days;
            //string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "Octomber", "November", "December" };
            //this.ComboBoxMonth.ItemsSource = months;
            //this.ComboBoxMonth2.ItemsSource = months;
            //int[] years = { 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020 };
            //this.ComboBoxYear.ItemsSource = years;
            //this.ComboBoxYear2.ItemsSource = years;
            string[] hours = { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" };
            this.ComboBoxHour.ItemsSource = hours;
            this.ComboBoxHour2.ItemsSource = hours;
            string[] minutes = { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" };
            this.ComboBoxMinutes.ItemsSource = minutes;
            this.ComboBoxMinutes2.ItemsSource = minutes;
        }

        public NewEventWindow(DateTime dateTime)
            : this()
        {
            StartDate.SelectedDate = dateTime.Date;
            EndDate.SelectedDate = dateTime.Date;
            /* ComboBoxHour.SelectedValue = dateTime.Hour;
             ComboBoxHour2.SelectedValue = dateTime.Hour;
              ComboBoxMinutes.SelectedValue = dateTime.Minute;
              ComboBoxMinutes2.SelectedValue = dateTime.Minute;*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnDialogClosed(object sender, EventArgs e)
        {
            if (DialogFinished != null)
            {
                string[] dateArrStart = this.StartDate.ToString().Split('.');
                dateArrStart[2] = dateArrStart[2].Remove(dateArrStart[2].Length - 2, 2);
                string[] dateArrEnd = this.EndDate.ToString().Split('.');
                dateArrEnd[2] = dateArrEnd[2].Remove(dateArrEnd[2].Length - 2, 2);
                DateTime startTime = new DateTime(int.Parse(dateArrStart[2]), int.Parse(dateArrStart[1]), int.Parse(dateArrStart[0]), int.Parse(this.ComboBoxHour.Text), int.Parse(this.ComboBoxMinutes.Text), 0);
                DateTime endTime = new DateTime(int.Parse(dateArrEnd[2]), int.Parse(dateArrEnd[1]), int.Parse(dateArrEnd[0]), int.Parse(this.ComboBoxHour2.Text), int.Parse(this.ComboBoxMinutes2.Text), 0);
                DialogFinished(this, new WindowEventArgs(this.Title.Text, this.Location.Text, startTime, endTime, this.ComboBoxEventType.Text));
            }
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
