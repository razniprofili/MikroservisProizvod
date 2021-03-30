using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProizvodRepository : GenericRepository<Proizvod>, IProizvodRepository
    {
        public ProizvodRepository(Context context) : base(context)
        {

        }
    }
}
