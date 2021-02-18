namespace DataBase_Marcin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pracownicy")]
    public partial class pracownicy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pracownicy()
        {
            wypozyczenia = new HashSet<wypozyczenia>();
        }

        [Key]
        public int ID_pracownika { get; set; }

        [Required]
        [StringLength(20)]
        public string Imie { get; set; }

        [Required]
        [StringLength(20)]
        public string Nazwisko { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_przyjecia { get; set; }

        [StringLength(11)]
        public string Pesel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wypozyczenia> wypozyczenia { get; set; }
    }
}
