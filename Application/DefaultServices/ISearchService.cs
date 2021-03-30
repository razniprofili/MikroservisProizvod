﻿using MikroServisProizvod.Application.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.DefaultServices
{
    public interface ISearchService<TSearch> 
        where TSearch : PagedSearch
    {
        object Search(TSearch search);
    }
}
