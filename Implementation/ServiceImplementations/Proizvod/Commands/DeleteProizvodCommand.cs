﻿using Data;
using MikroServisProizvod.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.ServiceImplementations.Proizvod.Services
{
    public class DeleteProizvodCommand : BaseDeleteCommand<Domen.Proizvod>, IDeleteProizvodCommand
    {
        public DeleteProizvodCommand(IGenericRepository<Domen.Proizvod> genericRepository) : base(genericRepository)
        {
        }
    }
}
