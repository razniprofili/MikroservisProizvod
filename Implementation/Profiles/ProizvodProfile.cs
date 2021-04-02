using AutoMapper;
using Domen;
using Microsoft.EntityFrameworkCore;
using MikroServisProizvod.Application.IServices.ProizvodServices.Models;
using MikroServisProizvod.Application.SeparatedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.Profiles
{
    public class ProizvodProfile : Profile
    {
        public ProizvodProfile()
        {
            CreateMap<Proizvod, ReadProizvodDto>()
                .ForMember(x => x.Dobavljaci, x => x.MapFrom(z => z.Dobavljaci.Select(y => new DobavljacDto { Naziv = y.Dobavljac.Naziv, Id = y.DobavljacId })))
                .ForMember(x => x.TipProizvoda, x => x.MapFrom(z => new TipProizvodaDto { Naziv = z.TipProizvoda.Naziv, Id = z.TipProizvodaId }))
                .ForMember(x => x.JedinicaMere, x => x.MapFrom(z => new JedinicaMereDto { Naziv = z.JedinicaMere.Naziv, Id = z.JedinicaMereId }));
            CreateMap<ProizvodDto, Proizvod>()
                .ForMember(x => x.Dobavljaci, x => x.MapFrom(y => y.Dobavljaci.Select(z => new ProizvodDobavljac { DobavljacId = z })));
        }
    }
}
