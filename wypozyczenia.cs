namespace DataBase_Marcin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wypozyczenia")]
    public partial class wypozyczenia
    {
        [Key]
        public int ID_wypozyczenia { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_wypozyczenia { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_zwrotu { get; set; }

        public int ID_pracownika { get; set; }

        public int ID_klienta { get; set; }

        public int ID_samochodu { get; set; }

        public int Stan_licznika_przed { get; set; }

        public int Stan_licznika_po { get; set; }

        public virtual klienci klienci { get; set; }

        public virtual pracownicy pracownicy { get; set; }

        public virtual samochody samochody { get; set; }
    }
}
