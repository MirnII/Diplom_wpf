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
using System.Windows.Shapes;

namespace Diplom_1
{
    /// <summary>
    /// Interaction logic for assessment.xaml
    /// </summary>
    public partial class assessment : Window
    {
        int ass;
        public int id { get; set; }
        public string engineer { get; set; }

        public assessment()
        {
            
            InitializeComponent();
            
        }

        private void Ent_a_Click(object sender, RoutedEventArgs e)
        {
            SQL s = new SQL();
            if (s.Close_z(id, ass, engineer) == 2) MessageBox.Show("Заявка закрыта");
            else MessageBox.Show("Заявка не закрыта");
            Close();
        }

        private void A_five_Checked(object sender, RoutedEventArgs e)
        {
            ass = 5; 
        }

        private void A_four_Checked(object sender, RoutedEventArgs e)
        {
            ass = 4;
        }

        private void A_three_Checked(object sender, RoutedEventArgs e)
        {
            ass = 3;
        }

        private void A_two_Checked(object sender, RoutedEventArgs e)
        {
            ass = 2;
        }
    }
}
