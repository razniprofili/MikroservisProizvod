using Common;
using Common.Helpers;
using Data.Uow;
using Domen;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ProizvodService : IProizvodService
    {
        private readonly IUnitOfWork _uow;

        public ProizvodService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Proizvod Add(Proizvod proizvod)
        {
            throw new NotImplementedException();
        }

        public Proizvod Get(long id)
        {
            var proizvod = _uow.Proizvodi.FirstOrDefault(x => x.Id == id, "TipProizvoda,JedinicaMere");
            ValidationHelper.ValidateNotNull(proizvod);

            return proizvod;
        }

        public List<Proizvod> Search(ResourceParameters parameters)
        {
            ICollection<Proizvod> proizvodi = !string.IsNullOrWhiteSpace(parameters.SearchQuery)
                ? _uow.Proizvodi.Search(p => p.Cena.ToString() == parameters.SearchQuery
                    || p.Naziv.Contains(parameters.SearchQuery)
                    || p.Pdv.ToString() == parameters.SearchQuery
                    || p.Id.ToString() == parameters.SearchQuery)
                : _uow.Proizvodi.GetAll();

            return PagedList<Proizvod>.Create(proizvodi, parameters.PageNumber, parameters.PageSize);

        }

        public Proizvod Update(Proizvod proizvod)
        {
            throw new NotImplementedException();
        }

    }
}
