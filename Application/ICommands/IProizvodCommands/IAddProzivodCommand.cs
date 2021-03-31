using MikroServisProizvod.Application.DefaultServices;
using MikroServisProizvod.Application.IServices.ProizvodServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.IServices
{
    public interface IAddProzivodCommand : IAddCommand<ProizvodDto>
    {
    }
}
