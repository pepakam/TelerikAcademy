using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace TopazOrganizer.Controls
{
    /// <summary>
    /// Interaction logic for NotesDialog.xaml
    /// </summary>
    public partial class NotesDialog : Window
    {
        private NotesList noteList;

        public NotesDialog()
        {
            InitializeComponent();
            this.InitializeNoteList();
            this.RenderNotes();
        }

        private void InitializeNoteList()
        {
            var reader = new StreamReader(new FileStream("todo-items.txt", FileMode.OpenOrCreate, FileAccess.Read));
            var serializedData = reader.ReadToEnd();
            reader.Close();
            this.noteList = NotesList.Deserialize(serializedData);
        }

        public void OnAddNoteButtonClick(object sender, RoutedEventArgs e)
        {
            var text = this.NoteTextBox.Text;
            this.noteList.AddNote(text);
            if (text != String.Empty)
            {
                StreamWriter writer = new StreamWriter("todo-items.txt", true);
                using (writer)
                {
                    writer.WriteLine(text);
                }
            }
            this.NoteTextBox.Text = "";
            this.RenderNotes();
        }
         
        private void RenderNotes()
        {
            this.NotesContainer.Children.Clear();
            this.NotesContainer.Children.Add(this.noteList.Render());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //StreamWriter writer = new StreamWriter("todo-items.txt", false);  //new FileStream("todo-items.txt", FileMode.OpenOrCreate, FileAccess.Write)
            //using (writer)
            //{
            //    writer.Write(this.noteList.Serialize());
            //}
        }
    }
}
