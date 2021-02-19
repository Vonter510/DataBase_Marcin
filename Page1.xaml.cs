using System;
using System.Collections.Generic;
using System.Data;
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
        int id;
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
            this.WidokPracownik.ItemsSource = db.pracownicy.ToList();
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
            MessageBox.Show("Pomyślnie dodano");
            Odswiez();

        }

        private void podswiez_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            this.WidokPracownik.ItemsSource = db.pracownicy.ToList();
        }
        private void pUsun_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            var r = from d in db.pracownicy
                    where d.ID_pracownika == this.zmienneID
                    select d;

            pracownicy obj = r.SingleOrDefault();

            if (obj != null)
            {
                db.pracownicy.Remove(obj);
                db.SaveChanges();
            }
        }
        private int zmienneID = 0;
        private void WidokPracownik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(this.WidokPracownik.SelectedItems);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();
            int id = (WidokPracownik.SelectedItem as pracownicy).ID_pracownika;
            var usunPrac = db.pracownicy.Where(m => m.ID_pracownika == id).SingleOrDefault();
            var usunwyp = db.wypozyczenia.Where(s => s.ID_pracownika == id);
            db.wypozyczenia.RemoveRange(usunwyp);
            db.SaveChanges();
            db.pracownicy.Remove(usunPrac);
            db.SaveChanges();
            WidokPracownik.ItemsSource = db.pracownicy.ToList();
        }
        public void Odswiez()
        {
            WypozyczalniaEntities1 db = new WypozyczalniaEntities1();

            this.WidokPracownik.ItemsSource = db.pracownicy.ToList();
        }
    }
}
