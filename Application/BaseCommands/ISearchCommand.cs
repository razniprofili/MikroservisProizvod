using MikroServisProizvod.Application.BaseCommands;
using MikroServisProizvod.Application.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MikroServisProizvod.Application.DefaultServices
{
    public interface ISearchCommand<TSearch>  : ICommand<TSearch,object>
        where TSearch : PagedSearch
    {
    }
}
