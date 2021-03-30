using AutoMapper;
using Domen;
using MikroServisProizvod.Application.IServices.ProizvodServices.Models;
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
            CreateMap<Proizvod, ProizvodDto>();
            CreateMap<ProizvodDto, Proizvod>()
                .ForMember(x => x.Dobavljaci, x => x.Ignore())
                .ForMember(x => x.JedinicaMere, x => x.Ignore())
                .ForMember(x => x.TipProizvoda, x => x.Ignore());
        }
    }
}
