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

namespace DataBase_Marcin
{
    /// <summary>
    /// Logika interakcji dla klasy Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();

            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            var dosc = from d in db.wypozyczenia

                       select new
                       {    
                           ID_wypozyczenia = d.ID_wypozyczenia,
                           Data_wypozyczenia = d.Data_wypozyczenia,
                           Data_zwrotu = d.Data_zwrotu,
                           Stan_Licznika_Przed = d.Stan_licznika_przed,
                           Stan_Licznika_Po = d.Stan_licznika_po,
                           ID_samochodu = d.ID_samochodu,
                           ID_pracownika = d.ID_pracownika,
                           ID_klienta = d.ID_klienta 

                       };

            foreach (var item in dosc)
            {
                Console.WriteLine(item.Data_wypozyczenia);
                Console.WriteLine(item.Data_zwrotu);
                Console.WriteLine(item.Stan_Licznika_Przed);
                Console.WriteLine(item.ID_pracownika);
                Console.WriteLine(item.ID_klienta);
                Console.WriteLine(item.ID_samochodu);
            }

            this.WidokWypozyczenia.ItemsSource = dosc.ToList();
        }

        private void pOdswiez_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            this.WidokWypozyczenia.ItemsSource = db.wypozyczenia.ToList();
        }

        private void pDodaj_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pomyślnie dodano");
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            wypozyczenia wypozyczalniaObiekt = new wypozyczenia()
            {
                Data_wypozyczenia = (DateTime)twypozyczenia.SelectedDate,
                Data_zwrotu = (DateTime)tzwrotu.SelectedDate,
                Stan_licznika_po = Convert.ToInt32(textPo.Text),
                Stan_licznika_przed = Convert.ToInt32(textPrzed.Text),
                ID_pracownika = Convert.ToInt32(textPracownik.Text),
                ID_klienta = Convert.ToInt32(textKlient.Text),
                ID_samochodu = Convert.ToInt32(textSamochod.Text),

            };
            db.wypozyczenia.Add(wypozyczalniaObiekt);
            db.SaveChanges();
        }
    }
}
