using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TopazOrganizer.Controls;

namespace TopazOrganizer.OrganizerEvents
{
    public class OrganizerEventData:INotifyEventDataChanged, IEventDataContainer
    {
        List<OrganizerEvent> items;
        
        public IEnumerable<OrganizerEvent> Items
        {
            get { return items; }
        }

        public event EventHandler EventAdded;
        public event EventHandler EventRemoved;
        public event EventHandler DataRefreshed;

        public OrganizerEventData()
        {
            this.items = new List<OrganizerEvent>();
        }

        public OrganizerEventData(IEnumerable<OrganizerEvent> collection)
            :base()
        {
            if (collection != null)
            {
                this.ImportDataFrom(collection);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void Add(OrganizerEvent organizerEvent)
        {
            if (organizerEvent != null)
            {
                items.Add(organizerEvent);
                this.SaveEventsInDatabase(organizerEvent);
                this.OnEventAdded(new DataChangedEventArgs(organizerEvent, this));
            }
            else
            {
                MessageBox.Show("OrganizerEvent parameters are empty.");
             //   throw new ArgumentNullException();
            } 
        }

        public void Remove(OrganizerEvent organizerEvent)
        {
            if (organizerEvent != null)
            {
                items.Remove(organizerEvent);
                this.OnEventRemoved(new DataChangedEventArgs(organizerEvent, this));
            }
            else
            {
                throw new ArgumentNullException();
            } 
        }
        
        public void OnEventAdded(DataChangedEventArgs data)
        { 
            if(EventAdded != null)
                EventAdded(this, data);
        }

        public void OnEventRemoved(DataChangedEventArgs data)
        { 
            if(EventRemoved != null)
                EventRemoved(this, data);
        }

        public void OnEventChanged(DataChangedEventArgs data)
        { 
            if(EventRemoved != null)
                EventRemoved(this, data);
        }

        public void OnDataRefreshed()
        { 
            if(DataRefreshed != null)
                DataRefreshed(this, new DataChangedEventArgs(this));
        }

        public IEnumerable<OrganizerEvent> GetEventsStartingBetween(DateTime startDay, DateTime lastDay)
        {
            IEnumerable<OrganizerEvent> eventsList = 
                from organizerEvent in items
                where organizerEvent.Start>=startDay && organizerEvent.End<=lastDay
                select organizerEvent;
            List<OrganizerEvent> events = eventsList.ToList();
            return events;
        }

        public void SaveEventsInDatabase(OrganizerEvent evn)
        {
            StreamWriter file = new StreamWriter(@"..\..\database.txt", true);
            using (file)
            {
                file.WriteLine(evn.ToString());
            }
        }

        public List<OrganizerEvent> GetEventsFromDatabase()
        {
            StreamReader file = new StreamReader(new FileStream(@"..\..\database.txt", FileMode.Open, FileAccess.Read));
            using (file)
            {
                string line = file.ReadLine();
                StringBuilder title = new StringBuilder();
                StringBuilder location = new StringBuilder();
                int day = 0;
                int month = 0;
                int year = 0;
                int hour = 0;
                int mins = 0;
                string type = "";
                DateTime start = new DateTime(2012, 1, 1);
                DateTime end = new DateTime(2012, 1, 1);

                while (line != null)
                {
                    int lineNum = 0;

                    while (lineNum < 5)
                    {
                        line = line.TrimEnd();
                        string[] words = line.Split(' ');
                        //extracting the title
                        if (lineNum == 0)
                        {
                            for (int i = 1; i < words.Length; i++)
                            {
                                title.Append(words[i] + " ");
                            }
                        }
                        //extracting location
                        else if (lineNum == 1)
                        {
                            for (int i = 1; i < words.Length; i++)
                            {
                                location.Append(words[i] + " ");
                            }
                        }
                        //extracting date and time
                        else if (lineNum == 2 || lineNum == 3)
                        {
                            string[] date = words[2].Split('.');
                            day = int.Parse(date[0]);
                            month = int.Parse(date[1]);
                            year = int.Parse(date[2]);
                            string[] hourParams = words[4].Split(':');
                            hour = int.Parse(hourParams[0]);
                            mins = int.Parse(hourParams[1]);
                            if (lineNum == 2)
                            {
                                start = new DateTime(year, month, day, hour, mins, 0);
                            }
                            else
                                end = new DateTime(year, month, day, hour, mins, 0);
                        }
                        else
                        {
                            type = words[1];
                            if (type == "Meeting" && items.Contains(new MeetingEvent(title.ToString(), location.ToString(), start, end)) == false)
                            {
                                items.Add(new MeetingEvent(title.ToString(), location.ToString(), start, end));
                            }
                            else if (type == "Lecture" && items.Contains(new LectureEvent(title.ToString(), location.ToString(), start, end)) == false)
                            {
                                items.Add(new LectureEvent(title.ToString(), location.ToString(), start, end));
                            }
                            else if (type == "Exercise" && items.Contains(new ExerciseEvent(title.ToString(), location.ToString(), start, end)) == false)
                            {
                                items.Add(new ExerciseEvent(title.ToString(), location.ToString(), start, end));
                            }
                            else if (type == "Deadline" && items.Contains(new DeadlineEvent(title.ToString(), location.ToString(), start, end)) == false)
                            {
                                items.Add(new DeadlineEvent(title.ToString(), location.ToString(), start, end));
                            }
                            else if (type == "Other" && items.Contains(new OtherEvent(title.ToString(), location.ToString(), start, end)) == false)
                            {
                                items.Add(new OtherEvent(title.ToString(), location.ToString(), start, end));
                            }
                        }
                        line = file.ReadLine();
                        lineNum++;
                    }
                    title.Clear();
                    location.Clear();
                }
            }
            return this.items;
        }

        public void DeleteDataFromFile(List<EventControl> controls)
        {
            CopyData();
            StreamWriter fileToBeRewritten = new StreamWriter(new FileStream(@"..\..\database.txt", FileMode.Open, FileAccess.Write));
            StreamReader readingFile = new StreamReader(new FileStream(@"..\..\databaseCopy.txt", FileMode.OpenOrCreate, FileAccess.Read));
            StringBuilder toBeWritten = new StringBuilder();
            foreach (EventControl evCntrl in controls)
            {
                string eventToBeDeleted = string.Format("{0}\n{1}\n{2}\n{3}\n{4}", evCntrl.Title, evCntrl.Location, evCntrl.StartTime, evCntrl.EndTime, evCntrl.Type);
                using (fileToBeRewritten)
                {
                    using (readingFile)
                    {
                        string line = readingFile.ReadLine();
                        while (line != null)
                        {
                            if (line != eventToBeDeleted)
                            {
                                toBeWritten.AppendLine(line);
                            }
                            line = readingFile.ReadLine();
                        }
                        fileToBeRewritten.Write(toBeWritten);
                        toBeWritten.Clear();
                    }
                }
            }
        }

        public bool Contains(OrganizerEvent data)
        {
            StreamReader read = new StreamReader(new FileStream(@"..\..\database.txt", FileMode.Open, FileAccess.Read));
            using (read)
            {
                StringBuilder currentLine = new StringBuilder();
                int i = 0;
                bool check = false;

                while (read.ReadLine() != null)
                {
                    currentLine.AppendLine(read.ReadLine());
                    currentLine.AppendLine(read.ReadLine());
                    currentLine.AppendLine(read.ReadLine());
                    currentLine.AppendLine(read.ReadLine());
                    currentLine.AppendLine(read.ReadLine());

                    if (currentLine.ToString() == data.ToString())
                    {
                        check = true;
                        break;
                    }
                    currentLine.Clear();
                }
                return check;
            }
        }

        public void CopyData()
        {
            StreamReader parent = new StreamReader(new FileStream(@"..\..\database.txt", FileMode.OpenOrCreate, FileAccess.Read));
            StreamWriter child = new StreamWriter(new FileStream(@"..\..\databaseCopy.txt", FileMode.OpenOrCreate, FileAccess.Write));
            using (parent)
            {
                using (child)
                {
                    string line = parent.ReadLine();
                    while (line != null)
                    {
                        child.WriteLine(line);
                        line = parent.ReadLine();
                    }
                }
            }
        }

        private void ImportDataFrom(IEnumerable<OrganizerEvent> collection)
        {
            if (collection != null)
            {
                this.items = collection.ToList();
                this.OnDataRefreshed();
            }
            else
            {
                MessageBox.Show("OrganizerEvent parameters are empty.");
              //  throw new ArgumentNullException();
            }   
        }
    }
}
