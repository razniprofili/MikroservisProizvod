﻿using AutoMapper;
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

namespace MikroServisProizvod.Implementation.CommandImplementations
{
    public abstract class BasePagedSearchCommand<TEntity, TDto, TSearch> : BaseMapperCommand<TEntity,TDto>, ISearchCommand<TSearch>
        where TEntity : BaseEntity
        where TDto : BaseDto
        where TSearch : PagedSearch
    {
        protected BasePagedSearchCommand(IGenericRepository<TEntity> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        protected virtual string IncludedProperties => "";

        protected abstract Expression<Func<TEntity, bool>> SearchExpression(TSearch search);

        public virtual object Execute(TSearch search)
        {
            IQueryable<TEntity> entities = IncludedProperties.Length > 0
                ? _genericRepository.Search(SearchExpression(search), IncludedProperties)
                : _genericRepository.Search(SearchExpression(search));
            
            var totalCount = entities.Count();

            if (search.IsPagedResponse)
            {
                entities = entities.Skip((search.PageNumber > 0 ? search.PageNumber - 1 : 0) * search.PageSize).Take(search.PageSize);
            }
            else
            {
                return _mapper.Map<IEnumerable<TDto>>(entities.ToList());
            }

            var parsedDtos = _mapper.Map<IEnumerable<TDto>>(entities.ToList());

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
