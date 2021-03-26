using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroservisProizvod.API.Models
{
    public class ProizvodModel
    {

        public long Id { get; set; }
        public string Naziv { get; set; }
        public double Cena { get; set; }
        public double Pdv { get; set; }
        public TipProizvodaModel TipProizvoda { get; set; }
        public JedinicaMereModel JedinicaMere { get; set; }
        public DobavljacModel Dobavljac { get; set; }

    }
}
