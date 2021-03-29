using AutoMapper;
using Common.Helpers;
using Data;
using Domen;
using MikroServisProizvod.Application.BaseDtos;
using MikroServisProizvod.Application.BaseModels;
using MikroServisProizvod.Application.DefaultServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.ServiceImplementations
{
    public abstract class BasePagedSearchService<TEntity, TDto, TSearch> : BaseMapperService<TEntity,TDto>, ISearchService<TSearch>
        where TEntity : BaseEntity
        where TDto : BaseDto
        where TSearch : PagedSearch
    {
        private readonly IMapper Mapper;
        protected BasePagedSearchService(IGenericRepository<TEntity> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
            Mapper = mapper;
        }

        public virtual object Search(TSearch search)
        {
            var entities = GenericRepository.Search(Expression(search), "TipProizvoda,JedinicaMere,Dobavljaci");

            var totalCount = entities.Count();

            if (search.IsPagedResponse)
            {
                entities = entities.Skip((search.PageNumber > 0 ? search.PageNumber - 1 : 0) * search.PageSize);
            }
            else
            {
                return Mapper.Map<IEnumerable<TDto>>(entities.ToList());
            }

            var parsedDtos = Mapper.Map<IEnumerable<TDto>>(entities);

            return new PagedResponse<TDto>
            {
                CurrentPage = search.PageNumber,
                Data = parsedDtos,
                PageSize = search.PageSize,
                TotalPages = (int)Math.Ceiling((decimal)totalCount/search.PageSize),
                TotalCount = totalCount
            };
        }

        protected abstract Expression<Func<TEntity, bool>> Expression(TSearch search);
    }
}
