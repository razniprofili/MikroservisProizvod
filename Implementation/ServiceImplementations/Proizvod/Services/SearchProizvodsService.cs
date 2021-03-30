using AutoMapper;
using Data;
using MikroServisProizvod.Application.BaseModels;
using MikroServisProizvod.Application.IServices;
using MikroServisProizvod.Application.IServices.ProizvodServices.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MikroServisProizvod.Implementation.ServiceImplementations.Proizvod.Services
{
    public class SearchProizvodsService : BasePagedSearchService<Domen.Proizvod, ProizvodDto, ProizvodSearch>, ISearchProizvodsService
    {
        public SearchProizvodsService(IGenericRepository<Domen.Proizvod> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        protected override Expression<Func<Domen.Proizvod, bool>> Expression(ProizvodSearch search)
        {
            Expression<Func<Domen.Proizvod, bool>> expression = p => p.Cena.ToString().Contains(search.Keyword)
                    || p.Naziv.Contains(search.Keyword)
                    || p.Pdv.ToString().Contains(search.Keyword)
                    || p.Id.ToString().Contains(search.Keyword);

            return expression;
        }

        protected override string IncludedProperties => "JedinicaMere,TipProizvoda,Dobavljaci";
    }
}
