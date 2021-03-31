using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.DefaultServices
{
    public interface IDeleteCommand
    {
        void Delete(long id);
    }
}
