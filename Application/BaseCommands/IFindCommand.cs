using MikroServisProizvod.Application.BaseCommands;
using MikroServisProizvod.Application.BaseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.DefaultServices
{
    public interface IFindCommand<TModel> : ICommand<long,TModel> 
        where TModel : BaseDto
    {
    }
}
