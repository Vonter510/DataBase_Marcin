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

namespace DataBase_Marcin
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>


    public partial class Window1 : Window
    {
        private Page1 strona1 = new Page1();
        private Page2 strona2 = new Page2();
        public Window1()
        {
            InitializeComponent();

            Navigacja.Navigate(strona1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigacja.Navigate(strona1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Navigacja.Navigate(strona2);
        }
    }
}
