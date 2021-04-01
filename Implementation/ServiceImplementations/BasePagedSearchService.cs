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
    public abstract class BasePagedSearchService<TEntity, TDto, TSearch> : BaseMapperCommand<TEntity,TDto>, ISearchCommand<TSearch>
        where TEntity : BaseEntity
        where TDto : BaseDto
        where TSearch : PagedSearch
    {
        protected BasePagedSearchService(IGenericRepository<TEntity> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        protected virtual string IncludedProperties => "";

        protected abstract Expression<Func<TEntity, bool>> SearchExpression(TSearch search);

        public object Execute(TSearch search)
        {
            IQueryable<TEntity> entities;

            if (IncludedProperties.Length > 0)
            {
                entities = GenericRepository.Search(SearchExpression(search), IncludedProperties);//"TipProizvoda,JedinicaMere,Dobavljaci"
            }
            else
            {
                entities = GenericRepository.Search(SearchExpression(search));
            }

            var totalCount = entities.Count();

            if (search.IsPagedResponse)
            {
                entities = entities.Skip((search.PageNumber > 0 ? search.PageNumber - 1 : 0) * search.PageSize).Take(search.PageSize);
            }
            else
            {
                return Mapper.Map<IEnumerable<TDto>>(entities.ToList());
            }

            var parsedDtos = Mapper.Map<IEnumerable<TDto>>(entities.ToList());

            return new PagedResponse<TDto>
            {
                CurrentPage = search.PageNumber,
                Data = parsedDtos,
                PageSize = search.PageSize,
                TotalPages = (int)Math.Ceiling((decimal)totalCount / search.PageSize),
                TotalCount = totalCount
            };
        }
    }
}
