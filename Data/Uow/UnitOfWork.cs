using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        public DbContext DbContext => _context ?? (_context = new Context());

        public IProizvodRepository Proizvodi { get; set; }

        public UnitOfWork()
        {
            Proizvodi = new ProizvodRepository(DbContext);
        }
    }
}
