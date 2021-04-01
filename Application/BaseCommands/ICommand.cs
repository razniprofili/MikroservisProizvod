using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Application.BaseCommands
{
    public interface ICommand<TReq,TRes>
    {
        TRes Execute(TReq req);
    }
}
