using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domen
{
    public class Proizvod : BaseEntity
    {
        [Required]
        public double Cena { get; set; }
        [Required]
        public double Pdv { get; set; }

        public long TipProizvodaId { get; set; }
        public TipProizvoda TipProizvoda { get; set; }

        public long JedinicaMereId { get; set; }
        public JedinicaMere JedinicaMere { get; set; }

        public List<Dobavljac> Dobavljaci { get; set; }

        
    }
}
