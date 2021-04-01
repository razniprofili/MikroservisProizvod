using MikroServisProizvod.Application.BaseCommands;
using MikroServisProizvod.Application.BaseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.DefaultServices
{
    public interface IUpdateCommand<TReq,TRes> : ICommand<TReq, TRes>
        where TReq : BaseDto
        where TRes : BaseDto
    {
    }
}
