﻿using AutoMapper;
using Data;
using Domen;
using FluentValidation;
using MikroServisProizvod.Application.BaseDtos;
using MikroServisProizvod.Application.IServices;
using MikroServisProizvod.Application.IServices.ProizvodServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.ServiceImplementations.Proizvod.Services
{
    public class AddProizvodCommand : BaseAddCommand<Domen.Proizvod, ProizvodDto>, IAddProzivodCommand
    {
        public AddProizvodCommand(IGenericRepository<Domen.Proizvod> genericRepository, IMapper mapper, IValidator<ProizvodDto> validator) : base(genericRepository, mapper, validator)
        {
        }
    }
}
