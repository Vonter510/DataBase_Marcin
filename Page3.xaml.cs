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
    /// Logika interakcji dla klasy Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();

            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            var dosc = from d in db.samochody

                       select new
                       {
                           ID = d.ID_samochodu,
                           Marka = d.Marka,
                           Model = d.Model,
                           Czy_dostepny = d.Czy_dostepny,
                           Czy_sprawny = d.Czy_sprawny,
                           Numer_rejestracyjny = d.Nr_rejestracyjny,
                           Przebieg = d.Przebieg,
                           Vin = d.VIN


                       };

            foreach (var item in dosc)
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.Marka);
                Console.WriteLine(item.Model);
                Console.WriteLine(item.Czy_sprawny);
                Console.WriteLine(item.Czy_dostepny);
                Console.WriteLine(item.Numer_rejestracyjny);
                Console.WriteLine(item.Przebieg);
                Console.WriteLine(item.Vin);
            }

            this.WidokSamochodu.ItemsSource = db.samochody.ToList();
        }

        private void pOdswiez_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            this.WidokSamochodu.ItemsSource = db.samochody.ToList();
        }

        private void pDodaj_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            samochody samochodyObiekt = new samochody()
            {
                Marka = textMarka.Text,
                Model = textModel.Text,
                Czy_dostepny = (bool)textdostepny.IsChecked,
                Czy_sprawny = (bool)textsprawny.IsChecked,
                Nr_rejestracyjny = textNumerR.Text,
                Przebieg = Convert.ToInt32(textPrzebieg.Text),
                VIN = textVin.Text
            };
            db.samochody.Add(samochodyObiekt);
            db.SaveChanges();
            MessageBox.Show("Pomyślnie dodano");
            Odswiez();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();
            int id = (WidokSamochodu.SelectedItem as samochody).ID_samochodu;
            var usunSam = db.samochody.Where(m => m.ID_samochodu == id).SingleOrDefault();
            var usunwyp = db.wypozyczenia.Where(s => s.ID_samochodu == id);
            db.wypozyczenia.RemoveRange(usunwyp);
            db.SaveChanges();
            db.samochody.Remove(usunSam);
            db.SaveChanges();
            WidokSamochodu.ItemsSource = db.samochody.ToList();
        }
        public void Odswiez()
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            this.WidokSamochodu.ItemsSource = db.samochody.ToList();
        }
    }
}
