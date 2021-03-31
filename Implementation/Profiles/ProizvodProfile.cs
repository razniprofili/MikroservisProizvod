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
        public ProizvodProfile(Context context)
        {
            CreateMap<Proizvod, ReadProizvodDto>()
                .ForMember(x => x.Dobavljaci, x => x.MapFrom(z => context.Proizvod
                        .Include(inc => inc.Dobavljaci)
                                .FirstOrDefault(y => y.Id == z.Id).Dobavljaci
                                        .Select(res => new OnlyNazivDto { Naziv = res.Naziv, Id = res.Id })))
                .ForMember(x => x.JedinicaMere, x => x.MapFrom((x,y) => {
                    var jedinica = context.Proizvod.Include(inc => inc.JedinicaMere)
                                .FirstOrDefault(y => y.Id == x.Id)
                                .JedinicaMere;

                    return new OnlyNazivDto
                    {
                        Id = jedinica.Id,
                        Naziv = jedinica.Naziv
                    };
                }))
                .ForMember(x => x.TipProizvoda, x => x.MapFrom((x,y) =>
                {
                    var tipProizvoda = context.Proizvod.Include(inc => inc.TipProizvoda)
                                .FirstOrDefault(y => y.Id == x.Id)
                                .TipProizvoda;

                    return new OnlyNazivDto
                    {
                        Id = tipProizvoda.Id,
                        Naziv = tipProizvoda.Naziv
                    };
                }));
                                        
                
            CreateMap<ProizvodDto, Proizvod>()
                .ForMember(x => x.Dobavljaci, x => x.Ignore())
                .ForMember(x => x.JedinicaMere, x => x.Ignore())
                .ForMember(x => x.TipProizvoda, x => x.Ignore());
        }
    }
}
