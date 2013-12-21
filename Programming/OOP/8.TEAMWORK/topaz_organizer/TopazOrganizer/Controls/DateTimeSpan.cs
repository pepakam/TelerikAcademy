using System;
using System.Globalization;
using System.Windows.Forms;

namespace TopazOrganizer.Controls
{
    public class DateTimeSpan
    {
        public const DayOfWeek FirstDayOfWeek = DayOfWeek.Monday;

        public DateTime WeekStartDate;
        public DateTime WeekEndDate;
        public DateTime MonthStartDate;
        public DateTime MonthEndDate;
        public DateTime YearStartDate;
        public DateTime YearEndDate;
        public int WeekNum;

        public DateTimeSpan(DateTime date)
        {
            if (date == null)
            {
                MessageBox.Show("Date shouldn't be empty.");
                // throw new ArgumentNullException();
            }

            WeekNum = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, FirstDayOfWeek);
            WeekStartDate = GetFirstDayOfWeek(date);
            WeekEndDate = GetLastDayOfWeek(date);
            MonthStartDate = new DateTime(date.Year, date.Month, 1);
            int numberOfDays = DateTime.DaysInMonth(date.Year, date.Month);
            DateTime last = new DateTime(date.Year, date.Month, numberOfDays);
            MonthEndDate = last;
            YearStartDate = new DateTime(date.Year, 1, 1);
            numberOfDays = DateTime.DaysInMonth(date.Year, 12);
            last = new DateTime(date.Year, 12, numberOfDays);
            YearEndDate = last;
        }

        static DateTime GetFirstDayOfWeek(DateTime date)
        {
            var firstDayOfWeek = date.AddDays(-((date.DayOfWeek - FirstDayOfWeek + 7) % 7));
            if (firstDayOfWeek.Year != date.Year)
                firstDayOfWeek = new DateTime(date.Year, 1, 1);
            firstDayOfWeek = new DateTime(firstDayOfWeek.Year, firstDayOfWeek.Month, firstDayOfWeek.Day, 0, 0, 0, 0);
            return firstDayOfWeek;
        }

        static DateTime GetLastDayOfWeek(DateTime date)
        {
            var firstDayOfWeek = date.AddDays(((FirstDayOfWeek - 1 - date.DayOfWeek + 7) % 7));
            if (firstDayOfWeek.Year != date.Year)
                firstDayOfWeek = new DateTime(date.Year, 12, 31);
            firstDayOfWeek = new DateTime(firstDayOfWeek.Year, firstDayOfWeek.Month, firstDayOfWeek.Day, 23, 59, 59, 999);
            return firstDayOfWeek;
        }
    }
}