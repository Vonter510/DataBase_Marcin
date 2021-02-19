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
    /// Logika interakcji dla klasy Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();

            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            var dosc = from d in db.klienci

                       select new
                       {
                           ID = d.ID_klienta,
                           Imie = d.Imie,
                           Nazwisko = d.Nazwisko,
                           PESEL = d.Pesel,
                           Data_Urodzenia = d.Data_urodzenia,
                           Numer_komorkowy = d.Nr_komorkowy

                       };

            foreach (var item in dosc)
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.Imie);
                Console.WriteLine(item.Nazwisko);
                Console.WriteLine(item.PESEL);
                Console.WriteLine(item.Data_Urodzenia);
                Console.WriteLine(item.Numer_komorkowy);
            }

            this.WidokKlient.ItemsSource = db.klienci.ToList();
        }
        private void WidokPracownik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(this.WidokKlient.SelectedItems);
        }
        private void pDodaj_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            klienci klientObiekt = new klienci()
            {
                Imie = textImie.Text,
                Nazwisko = textNazwisko.Text,
                Pesel = textPesel.Text,
                Data_urodzenia = (DateTime)tData.SelectedDate,
                Nr_komorkowy =  textkom.Text
            };
            db.klienci.Add(klientObiekt);
            db.SaveChanges();
            Odswiez();
            MessageBox.Show("Pomyślnie dodano");
        }

        private void pOdswiez_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            this.WidokKlient.ItemsSource = db.klienci.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();
            int id = (WidokKlient.SelectedItem as klienci).ID_klienta;
            var usunKli = db.klienci.Where(m => m.ID_klienta == id).SingleOrDefault();
            var usunAdr = db.adresy.Where(s => s.ID_klienta == id);
            var usunwyp = db.wypozyczenia.Where(s => s.ID_klienta == id);
            db.wypozyczenia.RemoveRange(usunwyp);
            db.SaveChanges();
            db.adresy.RemoveRange(usunAdr);
            db.SaveChanges();
            db.klienci.Remove(usunKli);
            db.SaveChanges();
            WidokKlient.ItemsSource = db.klienci.ToList();
        }
        public void Odswiez()
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            this.WidokKlient.ItemsSource = db.klienci.ToList();
        }
    }
}
