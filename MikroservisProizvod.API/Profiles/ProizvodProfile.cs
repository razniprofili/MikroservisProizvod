using AutoMapper;
using Domen;
using MikroservisProizvod.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroservisProizvod.API.Profiles
{
    public class ProizvodProfile : Profile
    {
        public ProizvodProfile()
        {
            CreateMap<Proizvod, ProizvodModel>().ReverseMap();
            CreateMap<Dobavljac, DobavljacModel>().ReverseMap();
            CreateMap<TipProizvoda, TipProizvodaModel>().ReverseMap();
            CreateMap<JedinicaMere, JedinicaMereModel>().ReverseMap();

        }
    }
}
