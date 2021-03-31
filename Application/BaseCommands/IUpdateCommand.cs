using MikroServisProizvod.Application.BaseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.DefaultServices
{
    public interface IUpdateCommand<T>
        where T : BaseDto
    {
        T Update(T dto);
    }
}
