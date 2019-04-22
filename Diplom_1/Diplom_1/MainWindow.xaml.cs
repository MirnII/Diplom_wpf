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
                cookie_go_in();
                hi.Visibility = Visibility.Hidden;
                employee_screen.Visibility = Visibility.Visible;
                L_Hi.Text = "Добро пожаловать в HelpDesk, " + name;
            }
            else
            {
                Log.BorderBrush = Brushes.Red;
                Pass.BorderBrush = Brushes.Red;
            }
        }

        private void cookie_go_in()
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

        private void Reg_a_Click(object sender, RoutedEventArgs e)
        {
            reg_panel.Visibility = Visibility.Visible;
        }

        private void Login_Reg_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Login_Reg.Text == "Логин") Login_Reg.Text = "";
        }

        private void Login_Reg_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Login_Reg.Text == "") Login_Reg.Text = "Логин";
        }

        private void Name_Reg_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Name_Reg.Text == "Имя") Name_Reg.Text = "";
        }

        private void Name_Reg_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Name_Reg.Text == "") Name_Reg.Text = "Имя";
        }

        private void Password_Reg_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Password_Reg.Password == "Пароль") Password_Reg.Password = "";
        }

        private void Password_Reg_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Password_Reg.Password == "") Password_Reg.Password = "Пароль";
            if (Password_Reg.Password == Password_Repeat_Reg.Password)
            {
                Password_Reg.BorderBrush = Brushes.Green;
                Password_Repeat_Reg.BorderBrush = Brushes.Green;
            }
            else
            {
                Password_Reg.BorderBrush = Brushes.Red;
                Password_Repeat_Reg.BorderBrush = Brushes.Red;
            }
        }

        private void Password_Repeat_Reg_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Password_Repeat_Reg.Password == "Пароль") Password_Repeat_Reg.Password = "";
        }

        private void Password_Repeat_Reg_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Password_Repeat_Reg.Password == "") Password_Repeat_Reg.Password = "Пароль";
            if (Password_Reg.Password == Password_Repeat_Reg.Password)
            {
                Password_Reg.BorderBrush = Brushes.Green;
                Password_Repeat_Reg.BorderBrush = Brushes.Green;
            }
            else
            {
                Password_Reg.BorderBrush = Brushes.Red;
                Password_Repeat_Reg.BorderBrush = Brushes.Red;
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            string[] Data = {null, null, null, null};
            Data[0] = Login_Reg.Text;
            Data[1] = Name_Reg.Text;
            Data[2] = Password_Repeat_Reg.Password;
            Data[3] = "Сотрудник";
            SQL s = new SQL();
            int num = s.Register_user(Data);
            if(num == 1)
            {
                Log.Text = Data[0];
                Pass.Password = Data[2];
                MessageBox.Show("Теперь вы можете войти");
                reg_panel.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Логин занят");
            }
        }

        

        private void Prog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Repair_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cartridge_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Note_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
