using MikroServisProizvod.Application.DefaultServices;
using MikroServisProizvod.Application.ICommands.Commands.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.ICommands
{
    public interface IAddProzivodCommand : IAddCommand<ProizvodDto,ReadProizvodDto>
    {
    }
}
