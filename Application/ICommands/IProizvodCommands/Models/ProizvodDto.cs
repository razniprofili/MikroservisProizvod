using MikroServisProizvod.Application.BaseDtos;
using MikroServisProizvod.Application.SeparatedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.IServices.Commands.Models
{
    public class ProizvodDto : BaseDto
    {
        public string Naziv { get; set; }
        public double Cena { get; set; }
        public double Pdv { get; set; }
        public long TipProizvodaId { get; set; }
        public long JedinicaMereId { get; set; }
        public ICollection<long> Dobavljaci { get; set; }
    }

    public class ReadProizvodDto : BaseDto
    {
        public string Naziv { get; set; }
        public double Cena { get; set; }
        public double Pdv { get; set; }
        public TipProizvodaDto TipProizvoda { get; set; }
        public JedinicaMereDto JedinicaMere { get; set; }
        public List<DobavljacDto> Dobavljaci { get; set; }
    }
}
