namespace DataBase_Marcin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("samochody")]
    public partial class samochody
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public samochody()
        {
            wypozyczenia = new HashSet<wypozyczenia>();
        }

        [Key]
        public int ID_samochodu { get; set; }

        [Required]
        [StringLength(15)]
        public string Marka { get; set; }

        [Required]
        [StringLength(15)]
        public string Model { get; set; }

        public bool Czy_sprawny { get; set; }

        public bool Czy_dostepny { get; set; }

        [Required]
        [StringLength(10)]
        public string Nr_rejestracyjny { get; set; }

        public int Przebieg { get; set; }

        [Required]
        [StringLength(17)]
        public string VIN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wypozyczenia> wypozyczenia { get; set; }
    }
}
