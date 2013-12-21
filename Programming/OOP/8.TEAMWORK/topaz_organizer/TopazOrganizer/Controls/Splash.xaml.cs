using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace TopazOrganizer.Controls
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        public Splash()
        {
            InitializeComponent();
        }
        private void Move(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((Un.Text == "123") & (Pw.Password == "123"))
            {
                this.Hide();
                MainWindow m = new MainWindow();
                m.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect User name or password!");
            }

        }
    }
}
