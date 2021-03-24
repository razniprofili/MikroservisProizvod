using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domen
{
    public class Proizvod
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public double Cena { get; set; }
        [Required]
        public double Pdv { get; set; }

        public long TipProizvodaId { get; set; }
        public TipProizvoda TipProizvoda { get; set; }

        public List<Dobavljac> Dobavljaci { get; set; }

        // jedinica mere?
    }
}
