using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows;
using System.IO;
using System.Collections;

namespace TopazOrganizer.Controls
{
    public class NotesList
    {
        public delegate void MouseEventHandler(Object sender, MouseEventArgs e);

        private List<NoteItem> NoteItems { get; set; }

        public NotesList()
        {
            this.NoteItems = new List<NoteItem>();
        }

        public UIElement Render()
        {
            var list = new System.Windows.Controls.ListBox();
            foreach (var noteItem in this.NoteItems)
            {
                var renderedNoteItem = noteItem.Render(this.NoteItems.IndexOf(noteItem));

                var listNodeItemItem = new ListBoxItem();
                listNodeItemItem.Content = renderedNoteItem;
                var deleteButtons = (renderedNoteItem as System.Windows.Controls.Panel).Children.OfType<System.Windows.Controls.Button>();
                foreach (var delButton in deleteButtons)
                {

                    delButton.PreviewMouseDown += (snd, args) =>
                    {
                        //have to find the index of the item, that should be deleted !!!
                        
                        var toBeDeleted = this.NoteItems[(int)delButton.DataContext];
                        this.NoteItems.RemoveAt((int)delButton.DataContext); //[index]
                        list.Items.RemoveAt((int)delButton.DataContext);
                        RemoveFromFile(toBeDeleted);
                        CopyData();
                        
                    };
                }
                
                list.Items.Add(listNodeItemItem);
            }
            return list;
        }

        private void RemoveFromFile(NoteItem noteItem)
        {
            StringBuilder output = new StringBuilder();
            StreamReader file = new StreamReader("todo-items.txt");
            using (file)
            {
                string line = file.ReadLine();
                while (line != null)
                {
                    if (line != noteItem.Serialize())
                    {
                        output.AppendLine(line);
                    }
                    line = file.ReadLine();
                }
            }
            file.Close();
            StreamWriter result = new StreamWriter("todo-list.txt", false);
            using (result)
            {
                result.Write(output.ToString());
            }
        }

        private void CopyData()
        {
            StreamReader fileRead = new StreamReader("todo-list.txt");
            StreamWriter fileWrite = new StreamWriter("todo-items.txt", false);
            using(fileRead)
            {
                using(fileWrite)
                {
                    String copiedData = String.Empty;
                    copiedData = fileRead.ReadToEnd();
                    fileWrite.Write(copiedData);
                }
            }
        }

        public void AddNote(string text)
        {
            var noteItem = new NoteItem(text);
            this.NoteItems.Add(noteItem);
            //StreamWriter writer = new StreamWriter("todo-items.txt", true);
            //using (writer)
            //{
            //    writer.WriteLine(text);
            //}
        }

        public string Serialize()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var noteItem in this.NoteItems)
            {
                builder.Append(noteItem.Serialize());
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }

        public static NotesList Deserialize(string serializedData)
        {
            var serializedNoteItems = serializedData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var notesList = new NotesList();
            for (var i = 0; i < serializedNoteItems.Length; i++)
            {
                notesList.AddNote(serializedNoteItems[i]);
            }
            return notesList;
        }
    }
}
