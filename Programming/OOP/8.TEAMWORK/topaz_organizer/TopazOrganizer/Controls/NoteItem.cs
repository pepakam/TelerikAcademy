using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.IO;

namespace TopazOrganizer.Controls
{
    public class NoteItem
    {
        public string Text { get; private set; }
        //public DateTime DateTaken { get; private set; }

        public NoteItem(string text)
        {
            this.Text = text;
            //this.DateTaken = timeTaken;
        }

        

        public UIElement Render(int index)
        {
            GridLengthConverter myGridLengthConverter = new GridLengthConverter();
            GridLength gl1 = (GridLength)myGridLengthConverter.ConvertFrom("372");
            var container = new Grid();
            container.Name = "container";
            var colDef = new ColumnDefinition();
            var colDefSecond = new ColumnDefinition();
            container.HorizontalAlignment = HorizontalAlignment.Center;
            //container.VerticalAlignment = VerticalAlignment.Stretch;
            //container.Width = 380;
            container.ColumnDefinitions.Add(colDef);
            container.ColumnDefinitions[0].Width = gl1;
         

            //creating the TextBox for the Text of the Todo
            var textTextBox = new TextBlock();
            textTextBox.Width = 400;
            textTextBox.Padding = new Thickness(0);
            textTextBox.Text = this.Text;
            textTextBox.FontWeight = FontWeights.Bold;
            textTextBox.Foreground = Brushes.LightGray;
            //textTextBox.Background = Brushes.White;
            textTextBox.Background = new SolidColorBrush(Color.FromArgb(255, 28, 102, 126));
            textTextBox.FontSize = 12;
            container.Children.Add(textTextBox);



            //creating the Delete button
            var deleteButton = new Button();
            deleteButton.Content = "X";
            deleteButton.Width = 20;
            deleteButton.Height = 20;
            deleteButton.DataContext = index;
            deleteButton.HorizontalAlignment = HorizontalAlignment.Right;
            container.Children.Add(deleteButton);

            return container;
        }

        public string Serialize()
        {
            return string.Format("{0}", this.Text);
        }
    }
}
