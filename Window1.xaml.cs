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
        private Page3 strona3 = new Page3();
        private Page4 strona4 = new Page4();
        public Window1()
        {
            InitializeComponent();

            Navigacja.Navigate(strona1);
        }

        private void Button_Pracownicy(object sender, RoutedEventArgs e)
        {
            Navigacja.Navigate(strona1);
        }

        private void Button_Samochody(object sender, RoutedEventArgs e)
        {
            Navigacja.Navigate(strona3);
        }

        private void Button_Klienci(object sender, RoutedEventArgs e)
        {
            Navigacja.Navigate(strona2);
        }

        private void Button_Wypozyczenia(object sender, RoutedEventArgs e)
        {
            Navigacja.Navigate(strona4);
        }
    }
}   
