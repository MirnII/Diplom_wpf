using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string name { get; set; }
        string roly { get; set; }
        int status_cod;
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            SQL s = new SQL();
            status_cod = s.go_in(Log.Text, Pass.Password);
            if (status_cod == 1)
            {
                name = s.Name;
                roly = s.Roly;
            }
            else
            {
                Log.BorderBrush = Brushes.Red;
                Pass.BorderBrush = Brushes.Red;
            }
        }

        private void cookie()
        {
            if(reme.IsChecked == true)
            {
                SQL s = new SQL();
                s.cookie_(Log.Text, Pass.Password, roly, name);
            }
        }

        private void Log_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Log_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Log.Text == "") Log.Text = "Логин";

        }

        private void Pass_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Pass.Password == "Пароль") Pass.Password = "";
        }

        private void Pass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Pass.Password == "") Pass.Password = "Пароль";
        }

        private void Log_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Log.Text == "Логин") Log.Text = "";
        }

        private void Reme_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
