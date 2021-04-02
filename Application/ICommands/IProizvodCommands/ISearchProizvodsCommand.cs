using MikroServisProizvod.Application.DefaultServices;
using MikroServisProizvod.Application.IServices.Commands.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.IServices
{
    public interface ISearchProizvodsCommand : ISearchCommand<ProizvodSearch>
    {
    }
}
