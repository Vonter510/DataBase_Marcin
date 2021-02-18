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
    /// Logika interakcji dla klasy Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();

            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            var dosc = from d in db.pracownicy

                       select new
                       {
                           ID = d.ID_pracownika,
                           Imie = d.Imie,
                           Nazwisko = d.Nazwisko,
                           PESEL = d.Pesel,
                           Data_Zatrudnienia = d.Data_przyjecia
                       };

            foreach (var item in dosc)
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.Imie);
                Console.WriteLine(item.Nazwisko);
                Console.WriteLine(item.PESEL);
                Console.WriteLine(item.Data_Zatrudnienia);
            }

            this.WidokPracownik.ItemsSource = dosc.ToList();
        }

        private void pDodaj_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            pracownicy pracownicyObiekt = new pracownicy()
            {
                Imie = textImie.Text,
                Nazwisko = textNazwisko.Text,
                Pesel = textPesel.Text,
                Data_przyjecia = (DateTime)tData.SelectedDate
            };
            db.pracownicy.Add(pracownicyObiekt);
            db.SaveChanges();

        }

        private void podswiez_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            this.WidokPracownik.ItemsSource = db.pracownicy.ToList();
        }

        private void WidokPracownik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(this.WidokPracownik.SelectedItems);
        }

        private void pModyfikuj_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            var z = from d in db.pracownicy
                    where d.ID_pracownika == 1
                    select d;

            foreach (var item in z)
            {
                MessageBox.Show(item.Imie);
            }

            db.SaveChanges();
        }
    }
}
