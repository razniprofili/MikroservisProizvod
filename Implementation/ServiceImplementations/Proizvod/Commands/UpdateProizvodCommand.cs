using AutoMapper;
using Data;
using FluentValidation;
using MikroServisProizvod.Application.IServices;
using MikroServisProizvod.Application.IServices.ProizvodServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.ServiceImplementations.Proizvod.Services
{
    public class UpdateProizvodCommand : BaseUpdateCommand<Domen.Proizvod, ProizvodDto>, IUpdateProizvodCommand
    {
        public UpdateProizvodCommand(IGenericRepository<Domen.Proizvod> genericRepository, IMapper mapper, IValidator<ProizvodDto> validator) : base(genericRepository, mapper, validator)
        {
        }
    }
}
