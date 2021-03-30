using MikroServisProizvod.Application.BaseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.DefaultServices
{
    public interface IFindService<TModel>
        where TModel : BaseDto
    {
        TModel Find(long id);
    }
}
