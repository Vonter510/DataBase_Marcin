namespace DataBase_Marcin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("klienci")]
    public partial class klienci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public klienci()
        {
            adresy = new HashSet<adresy>();
            wypozyczenia = new HashSet<wypozyczenia>();
        }

        [Key]
        public int ID_klienta { get; set; }

        [Required]
        [StringLength(20)]
        public string Imie { get; set; }

        [Required]
        [StringLength(20)]
        public string Nazwisko { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_urodzenia { get; set; }

        [Required]
        [StringLength(20)]
        public string Nr_komorkowy { get; set; }

        [StringLength(11)]
        public string Pesel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<adresy> adresy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wypozyczenia> wypozyczenia { get; set; }
    }
}
