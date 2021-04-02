using AutoMapper;
using Data;
using Domen;
using FluentValidation;
using MikroServisProizvod.Application.BaseDtos;
using MikroServisProizvod.Application.ICommands;
using MikroServisProizvod.Application.ICommands.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.CommandImplementations.Proizvod.Commands
{
    public class AddProizvodCommand : BaseAddCommand<Domen.Proizvod, ProizvodDto, ReadProizvodDto>, IAddProzivodCommand
    {
        public AddProizvodCommand(IGenericRepository<Domen.Proizvod> genericRepository, IMapper mapper, IValidator<ProizvodDto> validator) : base(genericRepository, mapper, validator)
        {
        }

        protected override string IncludedPropertiesOnExport => "JedinicaMere,TipProizvoda,Dobavljaci.Dobavljac";
    }
}
