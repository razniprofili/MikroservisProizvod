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
    public class FindProizvodCommand : BaseFindCommand<Domen.Proizvod, ProizvodDto>, IFindProizvodCommand
    {
        public FindProizvodCommand(IGenericRepository<Domen.Proizvod> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public override string IncludedEntities => "JedinicaMere,TipProizvoda,Dobavljaci";
    }
}
