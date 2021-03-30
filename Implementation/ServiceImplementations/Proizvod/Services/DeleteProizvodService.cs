using Data;
using MikroServisProizvod.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.ServiceImplementations.Proizvod.Services
{
    public class DeleteProizvodService : BaseDeleteService<Domen.Proizvod>, IDeleteProizvodService
    {
        public DeleteProizvodService(IGenericRepository<Domen.Proizvod> genericRepository) : base(genericRepository)
        {
        }
    }
}
