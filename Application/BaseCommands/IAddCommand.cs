using MikroServisProizvod.Application.BaseCommands;
using MikroServisProizvod.Application.BaseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.DefaultServices
{
    public interface IAddCommand<TDto, TRes> : ICommand<TDto, TRes>
        where TDto : BaseDto
        where TRes : BaseDto
    {
    }
}
