using AutoMapper;
using Data;
using MikroServisProizvod.Application.BaseModels;
using MikroServisProizvod.Application.ICommands;
using MikroServisProizvod.Application.ICommands.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MikroServisProizvod.Implementation.CommandImplementations.Proizvod.Commands
{
    public class SearchProizvodsCommand : BasePagedSearchCommand<Domen.Proizvod, ReadProizvodDto, ProizvodSearch>, ISearchProizvodsCommand
    {
        public SearchProizvodsCommand(IGenericRepository<Domen.Proizvod> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        protected override Expression<Func<Domen.Proizvod, bool>> SearchExpression(ProizvodSearch search)
        {
            Expression<Func<Domen.Proizvod, bool>> expression;

            if (String.IsNullOrEmpty(search.Keyword)) // ako je keyword prazan, onda nemamo uslov za pretragu, vracamo sve
            {
                expression = p => true;
                return expression;
            }

            expression = p => p.Cena.ToString().Contains(search.Keyword)
                    || p.Naziv.Contains(search.Keyword)
                    || p.Pdv.ToString().Contains(search.Keyword)
                    || p.Id.ToString().Contains(search.Keyword);

            return expression;
        }

        protected override string IncludedProperties => "JedinicaMere,TipProizvoda,Dobavljaci.Dobavljac";
    }
}
