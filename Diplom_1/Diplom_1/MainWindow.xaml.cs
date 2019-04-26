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
        string Login_="q";
        int status_cod;
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login_ = Log.Text;
            SQL s = new SQL();
            bool connect_status = s.connect_status();
            if (connect_status == true)
            {
                status_cod = s.go_in(Log.Text, Pass.Password);
                if (status_cod == 1)
                {
                    
                    name = s.Name;
                    roly = s.Roly;
                    cookie_go_in();
                    hi.Visibility = Visibility.Hidden;
                    Control_p.Visibility = Visibility.Hidden;
                    control_panel_sotrudnik.Visibility = Visibility.Visible;
                    employee_screen.Visibility = Visibility.Visible;
                    L_Hi.Text = "Добро пожаловать в HelpDesk, " + name;
                }
                else
                {
                    Log.BorderBrush = Brushes.Red;
                    Pass.BorderBrush = Brushes.Red;
                    MessageBox.Show("Неправильный пароль или логин");
                }
            }else
            {
                MessageBox.Show("Нет связи с сервером.");
            }
        }
        private void go_in()
        {

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
            if (s.connect_status() == true)
            {
                int num = s.Register_user(Data);
                if (num == 1)
                {
                    Log.Text = Data[0];
                    Pass.Password = Data[2];
                    MessageBox.Show("Теперь вы можете войти");
                    reg_panel.Visibility = Visibility.Hidden;
                }
                else MessageBox.Show("Логин занят");
                
            }
            else MessageBox.Show("Нет связи с сервером");

        }     
        private void Prog_Click(object sender, RoutedEventArgs e)
        {
            grid_install.Visibility = Visibility.Visible;
            grid_repair.Visibility = Visibility.Hidden;
            zamena.Visibility = Visibility.Hidden;
            grid_mer.Visibility = Visibility.Hidden;
        }
        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            grid_repair.Visibility = Visibility.Visible;
            grid_install.Visibility = Visibility.Hidden;
            grid_mer.Visibility = Visibility.Hidden;
            zamena.Visibility = Visibility.Hidden;
        }
        private void Cartridge_Click(object sender, RoutedEventArgs e)
        {
            grid_repair.Visibility = Visibility.Hidden;
            zamena.Visibility = Visibility.Visible;
            grid_install.Visibility = Visibility.Hidden;
            grid_mer.Visibility = Visibility.Hidden;
        }
        private void Note_Click(object sender, RoutedEventArgs e)
        {
            grid_repair.Visibility = Visibility.Hidden;
            zamena.Visibility = Visibility.Hidden;
            grid_install.Visibility = Visibility.Hidden;
            grid_mer.Visibility = Visibility.Visible;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            control_panel_sotrudnik.Visibility = Visibility.Hidden;
            employee_screen.Visibility = Visibility.Hidden;
            hi.Visibility = Visibility.Visible;
            Control_p.Visibility = Visibility.Visible;
        }
        private void Repair_sp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void Suite_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://zabgc.ru/");
        }
        private void _eth0_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void _eth01_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Create_r_Click(object sender, RoutedEventArgs e)
        {
            if (repair_sp.Text != "-Выбирите поломку-" && kab.Text != "" && kab.Text != "№ Кабинета")
            {
                SQL s = new SQL();
                if (s.connect_status() == true)
                {
                    if (s.repair_(repair_sp.Text, Login_, kab.Text) == 1) MessageBox.Show("Ваша заявка принята на рассмотрение");
                    else MessageBox.Show("Проблема подачи заявки");
                }
                else MessageBox.Show("Нет связи с сервером");
            }
            else MessageBox.Show("Выбирите категорию поломки и укажите номер кабинета");
        }
        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            grid_eth.Visibility = Visibility.Visible;
            grid_print.Visibility = Visibility.Hidden;
            grid_prog.Visibility = Visibility.Hidden;
            grid_audio.Visibility = Visibility.Hidden;
            grid_im.Visibility = Visibility.Hidden;
        }
        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            grid_eth.Visibility = Visibility.Hidden;
            grid_print.Visibility = Visibility.Visible;
            grid_prog.Visibility = Visibility.Hidden;
            grid_im.Visibility = Visibility.Hidden;
            grid_audio.Visibility = Visibility.Hidden;
        }
        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            grid_eth.Visibility = Visibility.Hidden;
            grid_im.Visibility = Visibility.Hidden;
            grid_print.Visibility = Visibility.Hidden;
            grid_prog.Visibility = Visibility.Visible;
            grid_audio.Visibility = Visibility.Hidden;
        }
        private void ComboBoxItem_Selected_4(object sender, RoutedEventArgs e)
        {
            grid_im.Visibility = Visibility.Hidden;
            grid_eth.Visibility = Visibility.Hidden;
            grid_print.Visibility = Visibility.Hidden;
            grid_prog.Visibility = Visibility.Hidden;
            grid_audio.Visibility = Visibility.Visible;
        }
        private void ComboBoxItem_Selected_5(object sender, RoutedEventArgs e)
        {
            grid_eth.Visibility = Visibility.Hidden;
            grid_print.Visibility = Visibility.Hidden;
            grid_prog.Visibility = Visibility.Hidden;
            grid_audio.Visibility = Visibility.Hidden;
            grid_im.Visibility = Visibility.Visible;
        }
        private void Creaet_p_Click(object sender, RoutedEventArgs e)
        {
            if (repair_sp.Text != "-Выбирите поломку-" && kab.Text != "" && kab.Text != "№ Кабинета")
            {
                SQL s = new SQL();
                if (s.connect_status() == true)
                {
                    if (s.repair_(repair_sp.Text, Login_, kab.Text) == 1) MessageBox.Show("Ваша заявка принята на рассмотрение");
                    else MessageBox.Show("Проблема подачи заявки");
                }
                else MessageBox.Show("Нет связи с сервером");
            }
            else MessageBox.Show("Выбирите категорию поломки и укажите номер кабинета");

        }
        private void Creat_prog_Click(object sender, RoutedEventArgs e)
        {
            if (repair_sp.Text != "-Выбирите поломку-" && kab.Text != "" && kab.Text != "№ Кабинета")
            {
                SQL s = new SQL();
                if (s.connect_status() == true)
                {
                    if (s.repair_(repair_sp.Text, Login_, kab.Text) == 1) MessageBox.Show("Ваша заявка принята на рассмотрение");
                    else MessageBox.Show("Проблема подачи заявки");
                }
                else MessageBox.Show("Нет связи с сервером");
            }
            else MessageBox.Show("Выбирите категорию поломки и укажите номер кабинета");
        }
        private void Create_zv_Click(object sender, RoutedEventArgs e)
        {
            if (repair_sp.Text != "-Выбирите поломку-" && kab.Text != "" && kab.Text != "№ Кабинета")
            {
                SQL s = new SQL();
                if (s.connect_status() == true)
                {
                    if (s.repair_(repair_sp.Text, Login_, kab.Text) == 1) MessageBox.Show("Ваша заявка принята на рассмотрение");
                    else MessageBox.Show("Проблема подачи заявки");
                }
                else MessageBox.Show("Нет связи с сервером");
            }
            else MessageBox.Show("Выбирите категорию поломки и укажите номер кабинета");
        }
        private void Creat_im_Click(object sender, RoutedEventArgs e)
        {
            if (repair_sp.Text != "-Выбирите поломку-" && kab.Text != "" && kab.Text != "№ Кабинета")
            {
                SQL s = new SQL();
                if (s.connect_status() == true)
                {
                    if (s.repair_(repair_sp.Text, Login_, kab.Text) == 1) MessageBox.Show("Ваша заявка принята на рассмотрение");
                    else MessageBox.Show("Проблема подачи заявки");
                }
                else MessageBox.Show("Нет связи с сервером");
            }
            else MessageBox.Show("Выбирите категорию поломки и укажите номер кабинета");
        }
        private void Name_cart_GotFocus(object sender, RoutedEventArgs e)
        {
            if (name_cart.Text == "Название принтера/картриджа") name_cart.Text = "";
        }
        private void Name_cart_LostFocus(object sender, RoutedEventArgs e)
        {
            if (name_cart.Text == "") name_cart.Text = "Название принтера/картриджа";
        }
        private void Creat_zamena_Click(object sender, RoutedEventArgs e)
        {
            if (name_cart.Text != "Название принтера/картриджа" && Kab_cart.Text != "№ Кабинета")
            {
                SQL s = new SQL();
                if (s.connect_status() == true)
                {
                    if (s.zamena(name_cart.Text, Login_, Kab_cart.Text) == 1) MessageBox.Show("Ваша заявка принята на рассмотрение");
                    else MessageBox.Show("Ошибка подачи заявки");
                }
                else MessageBox.Show("Нет связи с сервером");
            }
            else MessageBox.Show("Укажите название принтера/картрижа и номер кабинета");
        }
        private void Name_install_GotFocus(object sender, RoutedEventArgs e)
        {
            if (name_install.Text == "Название программы") name_install.Text = "";
        }
        private void Name_install_LostFocus(object sender, RoutedEventArgs e)
        {
            if (name_install.Text == "") name_install.Text = "Название программы";
        }
        private void Create_install_Click(object sender, RoutedEventArgs e)
        {
            if (name_install.Text != "" && name_install.Text != "Название программы" && kab_inst.Text != "" && kab_inst.Text != "№ Кабинета")
            {
                SQL s = new SQL();
                if (s.connect_status() == true)
                {
                    if(s.install(Login_, name_install.Text, kab_inst.Text) == 1) MessageBox.Show("Ваша заявка принята на рассмотрение");
                    else MessageBox.Show("Ошибка подачи заявки");
                }
                else MessageBox.Show("Нет связи с сервером");
            }
            else MessageBox.Show("Укажите название программы и номер кабинета");
        }
        private void Name_mer_GotFocus(object sender, RoutedEventArgs e)
        {
            if (name_mer.Text == "Название мероприятия") name_mer.Text = "";
        }
        private void Name_mer_LostFocus(object sender, RoutedEventArgs e)
        {
            if (name_mer.Text == "") name_mer.Text = "Название мероприятия";
        }
        private void Sv_mer_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sv_mer.Text == "Описание") sv_mer.Text = "";
        }
        private void Sv_mer_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sv_mer.Text == "") sv_mer.Text = "Описание";
        }
        private void Date_mer_GotFocus(object sender, RoutedEventArgs e)
        {
            if (date_mer.Text == "Дата/время") date_mer.Text = "";
            
        }
        private void Date_mer_LostFocus(object sender, RoutedEventArgs e)
        {
            if (date_mer.Text == "") date_mer.Text = "Дата/время";
            
        }
        private void Kab_GotFocus(object sender, RoutedEventArgs e)
        {
            if (kab.Text == "№ Кабинета") kab.Text = "";
        }
        private void Kab_LostFocus(object sender, RoutedEventArgs e)
        {
            if (kab.Text == "") kab.Text = "№ Кабинета";
        }
        private void Kab_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Kab_inst_GotFocus(object sender, RoutedEventArgs e)
        {
            if (kab_inst.Text == "№ Кабинета") kab_inst.Text = "";
        }
        private void Kab_inst_LostFocus(object sender, RoutedEventArgs e)
        {
            if (kab_inst.Text == "") kab_inst.Text = "№ Кабинета";
        }
        private void Kab_cart_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Kab_cart.Text == "№ Кабинета") Kab_cart.Text = "";
        }
        private void Kab_cart_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Kab_cart.Text == "") Kab_cart.Text = "№ Кабинета";
        }
        private void Create_mer_Click(object sender, RoutedEventArgs e)
        {
            if (name_mer.Text != "" && name_mer.Text != "Название мероприятия" && date_mer.Text != "" && date_mer.Text != "Дата/время" && sv_mer.Text != "" && sv_mer.Text != "Описание")
            {
                SQL s = new SQL();
                if (s.connect_status() == true)
                {
                    if (s.Mer(name_mer.Text, sv_mer.Text, date_mer.Text, name) == 1) MessageBox.Show("Ваша заявка принята на рассмотрение");
                    else MessageBox.Show("Ошибка подачи заявки");
                }
                else MessageBox.Show("Нет связи с сервером");
            }
            else MessageBox.Show("Заполните все поля");
        }
        private void Date_mer_TextChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Zav_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
