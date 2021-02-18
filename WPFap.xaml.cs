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
    /// Logika interakcji dla klasy WPFap.xaml
    /// </summary>
    public partial class WPFap : Window
    {
        public WPFap()
        {
            InitializeComponent();

            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            var dosc = from d in db.pracownicy

                       select new
                       {
                           ID = d.ID_pracownika,
                           Imie = d.Imie,
                           Nazwisko = d.Nazwisko,
                           Data_Zatrudnienia = d.Data_przyjecia
                       };

            foreach (var item in dosc)
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.Imie);
                Console.WriteLine(item.Nazwisko);
                Console.WriteLine(item.Data_Zatrudnienia);
            }

            this.WidokPracownik.ItemsSource = dosc.ToList();
        }
    }
}
