using MikroServisProizvod.Application.BaseCommands;
using MikroServisProizvod.Application.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.DefaultServices
{
    public interface IDeleteCommand : ICommand<long,Empty>
    {
    }
}
