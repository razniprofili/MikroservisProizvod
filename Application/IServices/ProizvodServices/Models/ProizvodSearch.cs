using MikroServisProizvod.Application.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.IServices.ProizvodServices.Models
{
    public class ProizvodSearch : PagedSearch
    {
        public string Keyword { get; set; }
    }
}
