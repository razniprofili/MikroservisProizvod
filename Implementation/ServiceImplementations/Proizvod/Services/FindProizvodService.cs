using AutoMapper;
using Data;
using MikroServisProizvod.Application.IServices;
using MikroServisProizvod.Application.IServices.ProizvodServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.ServiceImplementations.Proizvod.Services
{
    public class FindProizvodService : BaseFindService<Domen.Proizvod, ProizvodDto>, IFindProizvodService
    {
        public FindProizvodService(IGenericRepository<Domen.Proizvod> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
