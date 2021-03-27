using Common;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProizvodService
    {
        Proizvod Add(Proizvod proizvod);
        Proizvod Update(Proizvod proizvod);
        Proizvod Get(long id);
        List<Proizvod> Search(ResourceParameters parameters);

    }
}
