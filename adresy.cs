namespace DataBase_Marcin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("adresy")]
    public partial class adresy
    {
        [Key]
        public int ID_adresu { get; set; }

        [Required]
        [StringLength(15)]
        public string Miasto { get; set; }

        [Required]
        [StringLength(15)]
        public string Ulica { get; set; }

        [Required]
        [StringLength(6)]
        public string Nr_domu { get; set; }

        [Required]
        [StringLength(6)]
        public string Kod_pocztowy { get; set; }

        public int? ID_klienta { get; set; }

        public virtual klienci klienci { get; set; }
    }
}
