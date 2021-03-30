using AutoMapper;
using Data;
using Domen;
using MikroServisProizvod.Application.BaseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Implementation.ServiceImplementations
{
    public abstract class BaseService<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IGenericRepository<TEntity> GenericRepository;

        protected BaseService(IGenericRepository<TEntity> genericRepository)
        {
            GenericRepository = genericRepository;
        }
    }

    public abstract class BaseMapperService<TEntity, TDto> : BaseService<TEntity>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected readonly IMapper Mapper;
        protected BaseMapperService(IGenericRepository<TEntity> genericRepository, IMapper mapper) : base(genericRepository)
        {
            Mapper = mapper;
        }
    }
}
