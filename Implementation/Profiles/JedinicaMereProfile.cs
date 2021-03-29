using AutoMapper;
using Domen;
using MikroServisProizvod.Application.SeparatedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.Profiles
{
    public class JedinicaMereProfile : Profile
    {
        public JedinicaMereProfile()
        {
            CreateMap<JedinicaMere, JedinicaMereDto>();
            CreateMap<JedinicaMereDto, JedinicaMere>();
        }
    }
}
