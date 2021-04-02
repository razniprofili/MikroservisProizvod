using Data;
using MikroServisProizvod.Application.ICommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.CommandImplementations.Proizvod.Commands
{
    public class DeleteProizvodCommand : BaseDeleteCommand<Domen.Proizvod>, IDeleteProizvodCommand
    {
        public DeleteProizvodCommand(IGenericRepository<Domen.Proizvod> genericRepository) : base(genericRepository)
        {
        }
    }
}
