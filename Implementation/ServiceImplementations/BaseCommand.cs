using AutoMapper;
using Data;
using Domen;
using MikroServisProizvod.Application.BaseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Implementation.ServiceImplementations
{
    public abstract class BaseCommand<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IGenericRepository<TEntity> GenericRepository;

        protected BaseCommand(IGenericRepository<TEntity> genericRepository)
        {
            GenericRepository = genericRepository;
        }
    }

    public abstract class BaseMapperCommand<TEntity, TDto> : BaseCommand<TEntity>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected readonly IMapper Mapper;
        protected BaseMapperCommand(IGenericRepository<TEntity> genericRepository, IMapper mapper) : base(genericRepository)
        {
            Mapper = mapper;
        }
    }
}
